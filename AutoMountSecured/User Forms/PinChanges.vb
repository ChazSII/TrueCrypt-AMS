Public Class PinChanges
    Const CANCEL_ENTER_START As Integer = 107
    Const CANCEL_TOP As Integer = 90
    Const CANCEL_ENTER_LENGTH As Integer = 240
    Const CANCEL_ENTER_HEIGHT As Integer = 23

    Public ReadOnly Property PINField As String
        Get
            Return txtPINField1.Text
        End Get
    End Property

    Private Property IsChange As Boolean = False

    Public Sub New(ByVal PINType As String)
        InitializeComponent()

        Select Case PINType
            Case "Enter"
                txtPINField2.Visible = False
                btnCancel.Location = New Point(CANCEL_ENTER_START, CANCEL_TOP)
                btnCancel.Size = New Size(CANCEL_ENTER_LENGTH, CANCEL_ENTER_HEIGHT)
            Case "Change"
                IsChange = True
        End Select

        lblTitle.Text = String.Format(lblTitle.Text, PINType)
        btnChangePIN.Text = String.Format(btnChangePIN.Text, PINType)
    End Sub

    Private Sub PINChanges_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Activate()
    End Sub

    Private Sub FieldRequirements() Handles txtPINField1.TextChanged, txtPINField2.TextChanged
        If IsChange Then
            If txtPINField1.TextLength > 0 And txtPINField1.TextLength > 0 Then btnChangePIN.Enabled = True Else btnChangePIN.Enabled = False
        Else
            If txtPINField1.TextLength > 0 Then btnChangePIN.Enabled = True Else btnChangePIN.Enabled = False
        End If
    End Sub

    Private Sub btnChangePIN_Click(sender As Object, e As EventArgs) Handles btnChangePIN.Click
        If IsChange Then
            If Not txtPINField1.Text.Equals(txtPINField2.Text, StringComparison.Ordinal) Then
                MessageBox.Show("PINs do not match!", "Change PIN Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        End If

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        txtPINField1.Text = ""
        txtPINField2.Text = ""
    End Sub

End Class