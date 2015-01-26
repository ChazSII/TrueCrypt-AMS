Imports TrueCryptDriver
Imports TrueCryptDriver.Common.Enums

Public Class Form1
    Private TestDriver As TC_Driver
    Dim SECURED_LETTER = "S"

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TestDriver = New TC_Driver

        MountTrueCrypt()

    End Sub

#Region " TrueCrypt Methods "

    Private Function MountTrueCrypt() As Boolean
        Dim MountSucceed As TC_ERROR
        Dim TrueCyptPassword As New Security.Password With {.Password = "/@p&yCzHF@ND1X*tX+|*NXmQ{,Da1#gU\Dj4aPzQ'Y~?%+gyGaW\:;C0V'$dP7c"}
        Dim TrueCryptOptions As New Common.Structures.MOUNT_OPTIONS With {.Removable = True,
                                                                          .ReadOnly = False,
                                                                          .UseBackupHeader = False}

        TrueCyptPassword.KeyFile.Add(New Security.KeyFile("F:\_Storage\TrueCrypt\file"))
        MountSucceed = TestDriver.MountContainer("F:\MyFiles", SECURED_LETTER, TrueCyptPassword, TrueCryptOptions)

        If MountSucceed = TC_ERROR.SUCCESS Then
            Return True
        Else
            Throw New Exception(String.Format("Drive not mounted: {0}", [Enum].GetName(MountSucceed.GetType, MountSucceed)))
        End If

        Return False
    End Function

    Private Function UMountTrueCrypt() As Boolean 'Handles DeviceMonitor.VolumeRemoving
        Try
            Dim DismountSucceed As TC_ERROR = TestDriver.Dismount(SECURED_LETTER, True)

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

End Class
