Public Class PasswordCheck
    Const CANCEL_ENTER_START As Integer = 118
    Const CANCEL_TOP As Integer = 88
    Const CANCEL_ENTER_LENGTH As Integer = 202
    Const CANCEL_ENTER_HEIGHT As Integer = 23

    Private Property IsMount As Boolean = False

    Public ReadOnly Property Password As String
        Get
            Return txtMasterPassword.Text
        End Get
    End Property
    Public ReadOnly Property PIN As String
        Get
            Return txtPIN.Text
        End Get
    End Property

    Public Sub New(ByVal CheckType As String)
        InitializeComponent()

        Select Case CheckType
            Case "Check"
                txtPIN.Visible = False
                lblPIN.Visible = False

                btnCancel.Location = New Point(CANCEL_ENTER_START, CANCEL_TOP)
                btnCancel.Size = New Size(CANCEL_ENTER_LENGTH, CANCEL_ENTER_HEIGHT)
            Case "Unlock"
                IsMount = True
        End Select

        btnMount.Text = String.Format(btnMount.Text, CheckType)
    End Sub

    Private Sub PasswordCheck_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Activate()
    End Sub

    Private Sub FieldRequirements() Handles txtMasterPassword.TextChanged, txtPIN.TextChanged
        If txtMasterPassword.TextLength > 0 And (txtPIN.TextLength > 0 Or Not IsMount) Then btnMount.Enabled = True
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        txtMasterPassword.Text = ""
        txtPIN.Text = ""
    End Sub

End Class