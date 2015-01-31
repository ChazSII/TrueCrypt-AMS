Imports SimpleCrypto.AES256

Module DialogHandler
    Public Sub SettingsForm()
        Using SettingDialog As New Settings(CurrentSettings)
            If SettingDialog.ShowDialog = DialogResult.OK Then
                CurrentSettings = SettingDialog.NewSettings
                CurrentSettings.Dispose()
            End If
        End Using
    End Sub

    Public Sub ExitForm()
        If MessageBox.Show("Do you really want to exit?", "TrueCrypt-AMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

    Public Function GetPIN() As String
        Using Pin As New PinChanges("Enter")
            If Pin.ShowDialog = Windows.Forms.DialogResult.OK Then
                Return Pin.PINField
            End If

            Return Nothing
        End Using
    End Function

    Public Function CheckPassword(ByVal PasswordHash As String, Optional ByRef SecretKey As String = Nothing) As Boolean?
        Dim EnteredPassword As String
        CheckPassword = False

        Try
            Dim CheckType As String
            If IsNothing(SecretKey) Then
                CheckType = "Check"
            Else
                CheckType = "Unlock"
            End If

            Using PasswordForm As New PasswordCheck(CheckType)
                If PasswordForm.ShowDialog = DialogResult.OK Then
                    EnteredPassword = PasswordForm.Password

                    If HashString(EnteredPassword) = PasswordHash Then
                        If Not IsNothing(SecretKey) Then SecretKey = PasswordForm.PIN & PasswordHash
                        CheckPassword = True
                        Exit Try
                    End If
                Else
                    CheckPassword = Nothing
                End If
            End Using
        Catch ex As Exception
            SecretKey = Nothing
            CheckPassword = False
        Finally
            If Not IsNothing(CheckPassword) AndAlso Not CheckPassword Then
                If MessageBox.Show("Password entered is incorrect ", "Error Mounting Volume", MessageBoxButtons.RetryCancel) = DialogResult.Retry Then
                    CheckPassword = CheckPassword(PasswordHash, SecretKey)
                End If
            End If
            EnteredPassword = Nothing
        End Try
    End Function
End Module
