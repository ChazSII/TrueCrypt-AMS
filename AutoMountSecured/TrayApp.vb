Imports TrueCryptDriver
Imports TrueCryptDriver.Common.Enums
Imports TrueCryptDriver.Common.Structures
Imports SimpleCrypto

Public Class TrayApp
    Implements IDisposable

    Const AUTO_MOUNT_LABEL As String = "Auto-Mount"
    Const UMOUNT_LABEL As String = "Lock SECURED Volume"
    Const MOUNT_LABEL As String = "Unlock SECURED Volume"
    Const SETTINGS_LABEL As String = "Settings"
    Const EXIT_LABEL As String = "Exit"
    Const DRIVE_WAITING_LABEL As String = "Waiting for [{0}]..."
    Const DRIVE_AVAILABLE_LABEL As String = "[{0}] Available"
    Const DRIVE_UNLOCKED_LABEL As String = "Secured storage unlocked"

    Private Auto_Mount As Boolean = False

    Private TARGET_VOLUME As String = ""
    Private SECURED_LETTER As String = ""

    Private WithEvents Tray As NotifyIcon
    Private WithEvents MainMenu As ContextMenuStrip
    Private WithEvents mnuAuto As ToolStripMenuItem
    Private WithEvents mnuUmount As ToolStripMenuItem
    Private WithEvents mnuSep1 As ToolStripSeparator
    Private WithEvents mnuSetting As ToolStripMenuItem
    Private WithEvents mnuSep2 As ToolStripSeparator
    Private WithEvents mnuExit As ToolStripMenuItem

    Private WithEvents VolumeMonitor As MonitorVolume
    Private WithEvents TrueCryptDriver As TC_Driver

    Public Sub New()
        ' Initialize the menus
        mnuAuto = New ToolStripMenuItem(AUTO_MOUNT_LABEL) With {.Checked = True, .CheckOnClick = True}
        mnuUmount = New ToolStripMenuItem(MOUNT_LABEL) With {.Enabled = False}
        mnuSep1 = New ToolStripSeparator()
        mnuSetting = New ToolStripMenuItem(SETTINGS_LABEL)
        mnuSep2 = New ToolStripSeparator()
        mnuExit = New ToolStripMenuItem(EXIT_LABEL)

        MainMenu = New ContextMenuStrip
        MainMenu.Items.AddRange(New ToolStripItem() {mnuAuto, mnuUmount, mnuSep1, mnuSetting, mnuSep2, mnuExit})


        ' Initialize the tray
        Tray = New NotifyIcon
        Tray.ContextMenuStrip = MainMenu
        Tray.Visible = True
        Tray.Icon = My.Resources.Encrypted

        Try
            ' Load Settings
            TARGET_VOLUME = CurrentSettings.DeviceSetings.CONTAINER_LABEL
            SECURED_LETTER = CurrentSettings.DeviceSetings.SECURED_LETTER

            ' Load the TrueCrypt Driver
            TrueCryptDriver = New TC_Driver()

            ' Initialize the volume monitor
            VolumeMonitor = New MonitorVolume
            VolumeMonitor.StartMonitor(TARGET_VOLUME, SECURED_LETTER)

            Auto_Mount = True
        Catch ex As Exception
            Throw New ArgumentException("Initialization failed. See inner exception for details.", ex)
        End Try
    End Sub

    Private Sub VolumeMonitor_DriveChange(sender As Object, e As StatusChangeEventArgs) Handles VolumeMonitor.DriveChange
        With VolumeMonitor
            Select Case e.Event
                Case StatusChange.Insert
                    ' Drive Inserted

                    Select Case e.Volume
                        Case VolumeType.Target
                            Tray.Icon = My.Resources.Encrypted
                            Tray.Text = String.Format(DRIVE_AVAILABLE_LABEL, TARGET_VOLUME)

                            mnuUmount.Enabled = True

                            If Auto_Mount Then
                                MountTrueCrypt(VolumeMonitor.TargetDriveLetter)
                            End If
                        Case VolumeType.Secured
                            Tray.Icon = My.Resources.decrypted
                            Tray.Text = DRIVE_UNLOCKED_LABEL

                            mnuUmount.Text = UMOUNT_LABEL
                    End Select

                Case StatusChange.Removing
                    ' Drive removal requested

                    Select Case e.Volume
                        Case VolumeType.Target
                            If VolumeMonitor.IsSecuredDriveMounted Then
                                UMountTrueCrypt()
                            End If
                        Case VolumeType.Secured
                            ' Do nothing at the moment
                    End Select

                Case StatusChange.Removed
                    ' Drive removed

                    Select Case e.Volume
                        Case VolumeType.Target
                            Tray.Text = String.Format(DRIVE_WAITING_LABEL, TARGET_VOLUME)

                            mnuUmount.Enabled = False
                        Case VolumeType.Secured
                            Tray.Icon = My.Resources.Encrypted
                            Tray.Text = String.Format(DRIVE_AVAILABLE_LABEL, TARGET_VOLUME)

                            mnuUmount.Text = MOUNT_LABEL
                    End Select

            End Select
        End With
    End Sub

#Region " TrayIcon Events "

    Private Sub mnuAuto_Click(sender As Object, e As EventArgs) Handles mnuAuto.CheckStateChanged
        Auto_Mount = (mnuAuto.CheckState = CheckState.Checked)
    End Sub

    Private Sub mnuUmount_Click(sender As Object, e As EventArgs) Handles mnuUmount.Click
        If mnuUmount.Text = UMOUNT_LABEL Then
            UMountTrueCrypt()
        Else
            MountTrueCrypt(VolumeMonitor.TargetDriveLetter)
        End If
    End Sub

    Private Sub mnuSetting_Click(sender As Object, e As EventArgs) Handles mnuSetting.Click
        SettingsForm()

        ' Restart the Volume monitor after settings changes
        VolumeMonitor.Dispose()

        ' Load Settings
        TARGET_VOLUME = CurrentSettings.DeviceSetings.CONTAINER_LABEL
        SECURED_LETTER = CurrentSettings.DeviceSetings.SECURED_LETTER

        ' Load the TrueCrypt Driver
        TrueCryptDriver = New TC_Driver()

        ' Initialize the volume monitor
        VolumeMonitor = New MonitorVolume
        VolumeMonitor.StartMonitor(TARGET_VOLUME, SECURED_LETTER)
    End Sub

    Private Sub mnuExit_Click(sender As Object, e As System.EventArgs) Handles mnuExit.Click
        ExitForm()
    End Sub

#End Region

#Region " TrueCrypt Methods "

    Private Function MountTrueCrypt(ByVal DriveLetter As String) As Boolean
        Dim KeyFileLocation As String
        Dim ContainerLocation As String
        Dim SecretKey As String = ""
        Dim MountSucceed As TC_ERROR

        Dim MountSettings As SettingsXML = CurrentSettings
        Dim PasswordSettings = MountSettings.PasswordSettings
        Dim ContainerData = MountSettings.ContainerData

        Try
            Dim IsVerifed As Boolean? = CheckPassword(PasswordSettings.Master, SecretKey)

            If Not IsNothing(IsVerifed) AndAlso IsVerifed Then
                Dim TrueCryptOptions As New MOUNT_OPTIONS With {.Removable = ContainerData.Removable, .ReadOnly = ContainerData.ReadOnly, .UseBackupHeader = ContainerData.UseBackup}
                Dim TrueCyptPassword As New Security.Password With {.Password = AES256.Decrypt(PasswordSettings.TrueCrypt, SecretKey)}

                If ContainerData.UseKeyFile Then
                    KeyFileLocation = String.Format(ContainerData.KeyFile, DriveLetter)
                    TrueCyptPassword.KeyFile.Add(New Security.KeyFile(KeyFileLocation))
                End If

                ContainerLocation = String.Format(ContainerData.Location, DriveLetter)
                MountSucceed = TrueCryptDriver.MountContainer(ContainerLocation, SECURED_LETTER, TrueCyptPassword, TrueCryptOptions)

                TrueCryptOptions = Nothing
                TrueCyptPassword = Nothing

                If MountSucceed = TC_ERROR.SUCCESS Then
                    Return True
                Else
                    Throw New Exception(String.Format("Drive not mounted: {0}", [Enum].GetName(MountSucceed.GetType, MountSucceed)))
                End If
            ElseIf IsNothing(IsVerifed) Then
                Exit Try
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Mounting Volume", MessageBoxButtons.OK)
        Finally
            MountSettings.Dispose()
            PasswordSettings = Nothing
            ContainerData = Nothing

            KeyFileLocation = Nothing
            ContainerLocation = Nothing
            SecretKey = Nothing
            MountSucceed = Nothing
        End Try

        Return False

    End Function

    Private Function UMountTrueCrypt() As Boolean
        Try
            Dim DismountSucceed As TC_ERROR = TrueCryptDriver.Dismount(SECURED_LETTER, True)

            If Not DismountSucceed = TC_ERROR.SUCCESS Then
                Throw New Exception(String.Format("Drive not unmounted: {0}", [Enum].GetName(DismountSucceed.GetType, DismountSucceed)))
            End If

            DismountSucceed = Nothing

            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Un-mounting Volume", MessageBoxButtons.OK)
        End Try

        Return False
    End Function

#End Region


#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects).
                VolumeMonitor.Dispose()
                TrueCryptDriver.Dispose()

                Tray.Visible = False
                Tray.Dispose()
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
            ''DeviceMonitor = Nothing
            ''TrueCrypt_API = Nothing
        End If
        Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class
