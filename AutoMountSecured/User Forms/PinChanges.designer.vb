<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PinChanges
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
        Me.txtPINField1 = New System.Windows.Forms.TextBox()
        Me.txtPINField2 = New System.Windows.Forms.TextBox()
        Me.btnChangePIN = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblTitle.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.lblTitle.Location = New System.Drawing.Point(94, 40)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(42, 13)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "{0} PIN"
        '
        'txtPINField1
        '
        Me.txtPINField1.Location = New System.Drawing.Point(107, 64)
        Me.txtPINField1.Name = "txtPINField1"
        Me.txtPINField1.Size = New System.Drawing.Size(126, 20)
        Me.txtPINField1.TabIndex = 1
        Me.txtPINField1.UseSystemPasswordChar = True
        '
        'txtPINField2
        '
        Me.txtPINField2.Location = New System.Drawing.Point(107, 90)
        Me.txtPINField2.MaxLength = 6
        Me.txtPINField2.Name = "txtPINField2"
        Me.txtPINField2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPINField2.Size = New System.Drawing.Size(126, 20)
        Me.txtPINField2.TabIndex = 4
        Me.txtPINField2.UseSystemPasswordChar = True
        '
        'btnChangePIN
        '
        Me.btnChangePIN.Enabled = False
        Me.btnChangePIN.Location = New System.Drawing.Point(239, 61)
        Me.btnChangePIN.Name = "btnChangePIN"
        Me.btnChangePIN.Size = New System.Drawing.Size(108, 23)
        Me.btnChangePIN.TabIndex = 5
        Me.btnChangePIN.Text = "&{0} PIN"
        Me.btnChangePIN.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(239, 90)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(108, 23)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'PinChanges
        '
        Me.AcceptButton = Me.btnChangePIN
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.AutoMountSecured.My.Resources.Resources.LoginBackground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(444, 152)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnChangePIN)
        Me.Controls.Add(Me.txtPINField2)
        Me.Controls.Add(Me.txtPINField1)
        Me.Controls.Add(Me.lblTitle)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "PinChanges"
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
    Friend WithEvents txtPINField1 As System.Windows.Forms.TextBox
    Friend WithEvents txtPINField2 As System.Windows.Forms.TextBox
    Friend WithEvents btnChangePIN As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
End Class
