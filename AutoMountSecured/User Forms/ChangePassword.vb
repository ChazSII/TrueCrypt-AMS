Public Class ChangePassword
    Private _PasswordType As String

    Public ReadOnly Property PasswordField As String
        Get
            Return txtPasswordField1.Text
        End Get
    End Property

    Public Sub New(ByVal PasswordType As String)
        InitializeComponent()
        _PasswordType = PasswordType
    End Sub

    Private Sub ChangePassword_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Select Case _PasswordType
            Case "Master"
                If MessageBox.Show("Changing the Master Password will invalidate the Truecrypt password." _
                                   & vbCrLf & vbCrLf & "Would you like to continue?", "Continue?", _
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                    Me.DialogResult = Windows.Forms.DialogResult.Cancel
                    Me.Close()
                    Exit Sub
                End If
            Case "Truecrypt"
                chkShowPassword.Checked = True
        End Select

        If CheckPassword(CurrentSettings.PasswordSettings.Master) Then
            Me.Activate()
        Else
            DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If

        lblTitle.Text = String.Format(lblTitle.Text, _PasswordType)
    End Sub

    Private Sub chkShowPassword_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowPassword.CheckStateChanged
        txtPasswordField2.Enabled = Not chkShowPassword.Checked
        txtPasswordField2.ReadOnly = chkShowPassword.Checked
        txtPasswordField1.UseSystemPasswordChar = Not chkShowPassword.Checked

        If chkShowPassword.Checked Then
            txtPasswordField2.Text = ""
        End If
    End Sub

    Private Sub FieldRequirements() Handles txtPasswordField1.TextChanged, txtPasswordField2.TextChanged, chkShowPassword.CheckStateChanged
        If chkShowPassword.Checked Then
            If txtPasswordField1.TextLength > 0 Then btnChangePassword.Enabled = True Else btnChangePassword.Enabled = False
        Else
            If txtPasswordField1.TextLength > 0 And txtPasswordField2.TextLength > 0 Then btnChangePassword.Enabled = True Else btnChangePassword.Enabled = False
        End If
    End Sub

    Private Sub btnChangePassword_Click(sender As Object, e As EventArgs) Handles btnChangePassword.Click
        If Not chkShowPassword.Checked AndAlso Not txtPasswordField1.Text.Equals(txtPasswordField2.Text, StringComparison.Ordinal) Then
            MessageBox.Show("Passwords do not match!", "Change Password Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        txtPasswordField1.Text = ""
        txtPasswordField2.Text = ""
    End Sub

End Class