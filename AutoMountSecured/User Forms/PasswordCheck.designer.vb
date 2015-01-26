<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PasswordCheck
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.txtMasterPassword = New System.Windows.Forms.TextBox()
        Me.lblPIN = New System.Windows.Forms.Label()
        Me.txtPIN = New System.Windows.Forms.TextBox()
        Me.btnMount = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.BackColor = System.Drawing.Color.Transparent
        Me.lblPassword.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.lblPassword.Location = New System.Drawing.Point(118, 40)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(88, 13)
        Me.lblPassword.TabIndex = 0
        Me.lblPassword.Text = "Master Password"
        '
        'txtMasterPassword
        '
        Me.txtMasterPassword.Location = New System.Drawing.Point(121, 56)
        Me.txtMasterPassword.Name = "txtMasterPassword"
        Me.txtMasterPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtMasterPassword.Size = New System.Drawing.Size(103, 20)
        Me.txtMasterPassword.TabIndex = 1
        Me.txtMasterPassword.UseSystemPasswordChar = True
        '
        'lblPIN
        '
        Me.lblPIN.AutoSize = True
        Me.lblPIN.BackColor = System.Drawing.Color.Transparent
        Me.lblPIN.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.lblPIN.Location = New System.Drawing.Point(118, 88)
        Me.lblPIN.Name = "lblPIN"
        Me.lblPIN.Size = New System.Drawing.Size(25, 13)
        Me.lblPIN.TabIndex = 3
        Me.lblPIN.Text = "PIN"
        '
        'txtPIN
        '
        Me.txtPIN.Location = New System.Drawing.Point(150, 85)
        Me.txtPIN.MaxLength = 6
        Me.txtPIN.Name = "txtPIN"
        Me.txtPIN.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPIN.Size = New System.Drawing.Size(74, 20)
        Me.txtPIN.TabIndex = 4
        Me.txtPIN.UseSystemPasswordChar = True
        '
        'btnMount
        '
        Me.btnMount.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnMount.Enabled = False
        Me.btnMount.Location = New System.Drawing.Point(245, 53)
        Me.btnMount.Name = "btnMount"
        Me.btnMount.Size = New System.Drawing.Size(75, 23)
        Me.btnMount.TabIndex = 5
        Me.btnMount.Text = "&{0}"
        Me.btnMount.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(245, 82)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'PasswordCheck
        '
        Me.AcceptButton = Me.btnMount
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.AutoMountSecured.My.Resources.Resources.LoginBackground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(444, 148)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnMount)
        Me.Controls.Add(Me.txtPIN)
        Me.Controls.Add(Me.lblPIN)
        Me.Controls.Add(Me.txtMasterPassword)
        Me.Controls.Add(Me.lblPassword)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "PasswordCheck"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PasswordCheck"
        Me.TopMost = True
        Me.TransparencyKey = System.Drawing.Color.Maroon
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents txtMasterPassword As System.Windows.Forms.TextBox
    Friend WithEvents lblPIN As System.Windows.Forms.Label
    Friend WithEvents txtPIN As System.Windows.Forms.TextBox
    Friend WithEvents btnMount As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
End Class
