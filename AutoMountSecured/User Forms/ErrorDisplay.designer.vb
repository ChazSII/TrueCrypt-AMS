<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ErrorDisplay
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
        Me.txtError = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'txtError
        '
        Me.txtError.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtError.Location = New System.Drawing.Point(0, 0)
        Me.txtError.Name = "txtError"
        Me.txtError.Size = New System.Drawing.Size(634, 412)
        Me.txtError.TabIndex = 0
        Me.txtError.Text = ""
        '
        'ErrorDisplay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(634, 412)
        Me.Controls.Add(Me.txtError)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "ErrorDisplay"
        Me.Text = "Error Display"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtError As System.Windows.Forms.RichTextBox
End Class
