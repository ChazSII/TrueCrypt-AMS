<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChangePassword
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
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.txtPasswordField1 = New System.Windows.Forms.TextBox()
        Me.txtPasswordField2 = New System.Windows.Forms.TextBox()
        Me.btnChangePassword = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.chkShowPassword = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblTitle.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.lblTitle.Location = New System.Drawing.Point(95, 36)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(110, 13)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Change {0} Password"
        '
        'txtPasswordField1
        '
        Me.txtPasswordField1.Location = New System.Drawing.Point(104, 52)
        Me.txtPasswordField1.Name = "txtPasswordField1"
        Me.txtPasswordField1.Size = New System.Drawing.Size(238, 20)
        Me.txtPasswordField1.TabIndex = 1
        Me.txtPasswordField1.UseSystemPasswordChar = True
        '
        'txtPasswordField2
        '
        Me.txtPasswordField2.Location = New System.Drawing.Point(104, 78)
        Me.txtPasswordField2.Name = "txtPasswordField2"
        Me.txtPasswordField2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPasswordField2.Size = New System.Drawing.Size(238, 20)
        Me.txtPasswordField2.TabIndex = 4
        Me.txtPasswordField2.UseSystemPasswordChar = True
        '
        'btnChangePassword
        '
        Me.btnChangePassword.Enabled = False
        Me.btnChangePassword.Location = New System.Drawing.Point(153, 104)
        Me.btnChangePassword.Name = "btnChangePassword"
        Me.btnChangePassword.Size = New System.Drawing.Size(108, 23)
        Me.btnChangePassword.TabIndex = 5
        Me.btnChangePassword.Text = "&Change Password"
        Me.btnChangePassword.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(267, 104)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'chkShowPassword
        '
        Me.chkShowPassword.AutoSize = True
        Me.chkShowPassword.BackColor = System.Drawing.Color.Transparent
        Me.chkShowPassword.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.chkShowPassword.Location = New System.Drawing.Point(104, 108)
        Me.chkShowPassword.Name = "chkShowPassword"
        Me.chkShowPassword.Size = New System.Drawing.Size(53, 17)
        Me.chkShowPassword.TabIndex = 7
        Me.chkShowPassword.Text = "&Show"
        Me.chkShowPassword.UseVisualStyleBackColor = False
        '
        'ChangePassword
        '
        Me.AcceptButton = Me.btnChangePassword
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.AutoMountSecured.My.Resources.Resources.LoginBackground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(444, 152)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnChangePassword)
        Me.Controls.Add(Me.txtPasswordField2)
        Me.Controls.Add(Me.txtPasswordField1)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.chkShowPassword)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "ChangePassword"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ChangePassword"
        Me.TopMost = True
        Me.TransparencyKey = System.Drawing.Color.Maroon
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents txtPasswordField1 As System.Windows.Forms.TextBox
    Friend WithEvents txtPasswordField2 As System.Windows.Forms.TextBox
    Friend WithEvents btnChangePassword As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents chkShowPassword As System.Windows.Forms.CheckBox
End Class
