Imports SimpleCrypto

Public Class Settings

    Private NewMasterPassword As String
    Private NewTruecrypt As String
    Private Keyfile_DriveLabel As String
    Private ContainerFile_DriveLabel As String

    Private LoadedSettings As SettingsXML

    Public ReadOnly Property NewSettings As SettingsXML
        Get
            NewSettings = New SettingsXML With { _
                .ContainerData = New SettingsFileContainerData With { _
                    .KeyFile = Replace(txtKeyfile.Text, Keyfile_DriveLabel, "{0}"), _
                    .Location = Replace(txtContainer.Text, ContainerFile_DriveLabel, "{0}"), _
                    .ReadOnly = chkReadOnly.Checked, _
                    .Removable = chkRemovable.Checked, _
                    .UseBackup = chkBackupHeader.Checked, _
                    .UseKeyFile = chkUseKeyfile.Checked _
                }, _
                .DeviceSetings = New SettingsFileDeviceSetings With { _
                    .SECURED_LETTER = txtMountLetter.Text, _
                    .CONTAINER_LABEL = ContainerFile_DriveLabel, _
                    .KEYFILE_LABEL = Keyfile_DriveLabel _
                }, _
                .PasswordSettings = New SettingsFilePasswordSettings With { _
                    .Master = NewMasterPassword, _
                    .TrueCrypt = NewTruecrypt
                } _
            }

        End Get
    End Property

    Private Structure BrowseFile
        Public Property File_Location As String
        Public Property File_VolumeName As String
    End Structure

    Private Function BrowseFiles() As BrowseFile
        Using OpenFile As New OpenFileDialog
            If OpenFile.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Return New BrowseFile With { _
                    .File_Location = Mid(OpenFile.FileName, 3), _
                    .File_VolumeName = New IO.DriveInfo(Mid(OpenFile.FileName, 1, 3)).VolumeLabel
                }
            End If

            Return Nothing
        End Using
    End Function

    Private Sub LoadSettings()
        With LoadedSettings
            ContainerFile_DriveLabel = .DeviceSetings.CONTAINER_LABEL
            Keyfile_DriveLabel = .DeviceSetings.KEYFILE_LABEL
            txtMountLetter.Text = .DeviceSetings.SECURED_LETTER

            With .ContainerData
                chkBackupHeader.Checked = .UseBackup
                chkReadOnly.Checked = .ReadOnly
                chkRemovable.Checked = .Removable
                chkUseKeyfile.Checked = .UseKeyFile
                btnKeyfile.Enabled = .UseKeyFile

                txtContainer.Text = String.Format(.Location, ContainerFile_DriveLabel)
                txtKeyfile.Text = String.Format(.KeyFile, Keyfile_DriveLabel)
            End With

            With .PasswordSettings
                NewMasterPassword = .Master
                NewTruecrypt = .TrueCrypt
            End With

            Me.Activate()

        End With
    End Sub

#Region "Constructors"
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Public Sub New(ByVal FormSettings As SettingsXML)
        InitializeComponent()
        LoadedSettings = FormSettings
    End Sub
#End Region

#Region "Menu Events"

    Private Sub ImportSettingsFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportSettingsFileToolStripMenuItem.Click
        With dlgImportSetttings
            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim reader As New System.Xml.Serialization.XmlSerializer(GetType(SettingsXML), "")
                Using file As New System.IO.StreamReader(.OpenFile)
                    LoadedSettings = CType(reader.Deserialize(file), SettingsXML)
                End Using
                reader = Nothing
            End If
        End With

        LoadSettings()
    End Sub

    Private Sub ExportSettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportSettingsToolStripMenuItem.Click
        With dlgExportSettings
            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                Using file As New System.IO.StreamWriter(.OpenFile())
                    Dim writer As New System.Xml.Serialization.XmlSerializer(GetType(SettingsXML))
                    writer.Serialize(file, LoadedSettings)
                    writer = Nothing
                End Using
            End If
        End With
    End Sub

    Private Sub SaveSettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveSettingsToolStripMenuItem.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub CancelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelToolStripMenuItem.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

#End Region

#Region "Form Events"

    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If CheckPassword(CurrentSettings.PasswordSettings.Master) Then
            LoadSettings()
        Else
            DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub chkUseKeyfile_CheckedChanged(sender As Object, e As EventArgs) Handles chkUseKeyfile.CheckedChanged
        Me.btnKeyfile.Enabled = sender.checked
    End Sub

    Private Sub btnContainer_Click(sender As Object, e As EventArgs) Handles btnContainer.Click
        Dim ContainerFile As BrowseFile = BrowseFiles()
        If Not IsNothing(ContainerFile) Then
            ContainerFile_DriveLabel = ContainerFile.File_VolumeName
            txtContainer.Text = ContainerFile.File_VolumeName & ContainerFile.File_Location
        End If
        ContainerFile = Nothing
    End Sub

    Private Sub btnKeyfile_Click(sender As Object, e As EventArgs) Handles btnKeyfile.Click
        Dim KeyFile As BrowseFile = BrowseFiles()
        If Not IsNothing(KeyFile) Then
            Keyfile_DriveLabel = KeyFile.File_VolumeName
            txtKeyfile.Text = KeyFile.File_VolumeName & KeyFile.File_Location
        End If
        KeyFile = Nothing
    End Sub

    Private Sub btnMountPassword_Click(sender As Object, e As EventArgs) Handles btnMountPassword.Click
        Me.Hide()
        Using ChangePasswordForm As New ChangePassword("Truecrypt")
            If ChangePasswordForm.ShowDialog = DialogResult.OK Then
                Dim PIN As String = GetPIN()
                If Not IsNothing(PIN) Then
                    NewTruecrypt = AES256.Encrypt(ChangePasswordForm.PasswordField, PIN & NewMasterPassword)
                    CurrentSettings = NewSettings
                End If
            End If
        End Using
        Me.Show()
    End Sub

    Private Sub btnMasterPassword_Click(sender As Object, e As EventArgs) Handles btnMasterPassword.Click
        Me.Hide()
        Using ChangePasswordForm As New ChangePassword("Master")
            If ChangePasswordForm.ShowDialog = DialogResult.OK Then
                NewMasterPassword = AES256.HashString(ChangePasswordForm.PasswordField)
                CurrentSettings = NewSettings
            End If
        End Using
        Me.Show()
    End Sub

#End Region

End Class