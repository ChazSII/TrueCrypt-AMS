<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Settings
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
                NewSettings.Dispose()
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Settings))
        Me.lblContainer = New System.Windows.Forms.Label()
        Me.txtContainer = New System.Windows.Forms.TextBox()
        Me.chkUseKeyfile = New System.Windows.Forms.CheckBox()
        Me.txtKeyfile = New System.Windows.Forms.TextBox()
        Me.btnContainer = New System.Windows.Forms.Button()
        Me.btnKeyfile = New System.Windows.Forms.Button()
        Me.chkRemovable = New System.Windows.Forms.CheckBox()
        Me.btnMountPassword = New System.Windows.Forms.Button()
        Me.btnMasterPassword = New System.Windows.Forms.Button()
        Me.gpbMountOptions = New System.Windows.Forms.GroupBox()
        Me.chkBackupHeader = New System.Windows.Forms.CheckBox()
        Me.chkReadOnly = New System.Windows.Forms.CheckBox()
        Me.gpbPasswordSettings = New System.Windows.Forms.GroupBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.lblMountLetter = New System.Windows.Forms.Label()
        Me.txtMountLetter = New System.Windows.Forms.TextBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportSettingsFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportSettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SaveSettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CancelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.dlgImportSetttings = New System.Windows.Forms.OpenFileDialog()
        Me.dlgExportSettings = New System.Windows.Forms.SaveFileDialog()
        Me.gpbMountOptions.SuspendLayout()
        Me.gpbPasswordSettings.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblContainer
        '
        Me.lblContainer.AutoSize = True
        Me.lblContainer.Location = New System.Drawing.Point(12, 32)
        Me.lblContainer.Name = "lblContainer"
        Me.lblContainer.Size = New System.Drawing.Size(55, 13)
        Me.lblContainer.TabIndex = 0
        Me.lblContainer.Text = "Container:"
        '
        'txtContainer
        '
        Me.txtContainer.Location = New System.Drawing.Point(73, 29)
        Me.txtContainer.Name = "txtContainer"
        Me.txtContainer.ReadOnly = True
        Me.txtContainer.Size = New System.Drawing.Size(220, 20)
        Me.txtContainer.TabIndex = 1
        '
        'chkUseKeyfile
        '
        Me.chkUseKeyfile.AutoSize = True
        Me.chkUseKeyfile.Location = New System.Drawing.Point(15, 64)
        Me.chkUseKeyfile.Name = "chkUseKeyfile"
        Me.chkUseKeyfile.Size = New System.Drawing.Size(82, 17)
        Me.chkUseKeyfile.TabIndex = 2
        Me.chkUseKeyfile.Text = "Use &Keyfile:"
        Me.chkUseKeyfile.UseVisualStyleBackColor = True
        '
        'txtKeyfile
        '
        Me.txtKeyfile.Location = New System.Drawing.Point(100, 62)
        Me.txtKeyfile.Name = "txtKeyfile"
        Me.txtKeyfile.ReadOnly = True
        Me.txtKeyfile.Size = New System.Drawing.Size(193, 20)
        Me.txtKeyfile.TabIndex = 3
        '
        'btnContainer
        '
        Me.btnContainer.Location = New System.Drawing.Point(299, 27)
        Me.btnContainer.Name = "btnContainer"
        Me.btnContainer.Size = New System.Drawing.Size(60, 23)
        Me.btnContainer.TabIndex = 4
        Me.btnContainer.Text = "&Browse"
        Me.btnContainer.UseVisualStyleBackColor = True
        '
        'btnKeyfile
        '
        Me.btnKeyfile.Location = New System.Drawing.Point(299, 60)
        Me.btnKeyfile.Name = "btnKeyfile"
        Me.btnKeyfile.Size = New System.Drawing.Size(60, 23)
        Me.btnKeyfile.TabIndex = 5
        Me.btnKeyfile.Text = "Bro&wse"
        Me.btnKeyfile.UseVisualStyleBackColor = True
        '
        'chkRemovable
        '
        Me.chkRemovable.AutoSize = True
        Me.chkRemovable.Location = New System.Drawing.Point(16, 19)
        Me.chkRemovable.Name = "chkRemovable"
        Me.chkRemovable.Size = New System.Drawing.Size(110, 17)
        Me.chkRemovable.TabIndex = 8
        Me.chkRemovable.Text = "&Removable Mode"
        Me.chkRemovable.UseVisualStyleBackColor = True
        '
        'btnMountPassword
        '
        Me.btnMountPassword.Location = New System.Drawing.Point(16, 15)
        Me.btnMountPassword.Name = "btnMountPassword"
        Me.btnMountPassword.Size = New System.Drawing.Size(169, 23)
        Me.btnMountPassword.TabIndex = 9
        Me.btnMountPassword.Text = "Change Mount &Password"
        Me.btnMountPassword.UseVisualStyleBackColor = True
        '
        'btnMasterPassword
        '
        Me.btnMasterPassword.Location = New System.Drawing.Point(16, 44)
        Me.btnMasterPassword.Name = "btnMasterPassword"
        Me.btnMasterPassword.Size = New System.Drawing.Size(169, 23)
        Me.btnMasterPassword.TabIndex = 10
        Me.btnMasterPassword.Text = "Change &Master Password"
        Me.btnMasterPassword.UseVisualStyleBackColor = True
        '
        'gpbMountOptions
        '
        Me.gpbMountOptions.Controls.Add(Me.chkBackupHeader)
        Me.gpbMountOptions.Controls.Add(Me.chkReadOnly)
        Me.gpbMountOptions.Controls.Add(Me.chkRemovable)
        Me.gpbMountOptions.Location = New System.Drawing.Point(11, 89)
        Me.gpbMountOptions.Name = "gpbMountOptions"
        Me.gpbMountOptions.Size = New System.Drawing.Size(142, 86)
        Me.gpbMountOptions.TabIndex = 11
        Me.gpbMountOptions.TabStop = False
        Me.gpbMountOptions.Text = "Mount Options"
        '
        'chkBackupHeader
        '
        Me.chkBackupHeader.AutoSize = True
        Me.chkBackupHeader.Location = New System.Drawing.Point(16, 65)
        Me.chkBackupHeader.Name = "chkBackupHeader"
        Me.chkBackupHeader.Size = New System.Drawing.Size(123, 17)
        Me.chkBackupHeader.TabIndex = 10
        Me.chkBackupHeader.Text = "Use &Backup Header"
        Me.chkBackupHeader.UseVisualStyleBackColor = True
        '
        'chkReadOnly
        '
        Me.chkReadOnly.AutoSize = True
        Me.chkReadOnly.Location = New System.Drawing.Point(16, 42)
        Me.chkReadOnly.Name = "chkReadOnly"
        Me.chkReadOnly.Size = New System.Drawing.Size(76, 17)
        Me.chkReadOnly.TabIndex = 9
        Me.chkReadOnly.Text = "Read &Only"
        Me.chkReadOnly.UseVisualStyleBackColor = True
        '
        'gpbPasswordSettings
        '
        Me.gpbPasswordSettings.Controls.Add(Me.btnMountPassword)
        Me.gpbPasswordSettings.Controls.Add(Me.btnMasterPassword)
        Me.gpbPasswordSettings.Location = New System.Drawing.Point(159, 89)
        Me.gpbPasswordSettings.Name = "gpbPasswordSettings"
        Me.gpbPasswordSettings.Size = New System.Drawing.Size(200, 75)
        Me.gpbPasswordSettings.TabIndex = 12
        Me.gpbPasswordSettings.TabStop = False
        Me.gpbPasswordSettings.Text = "Password Settings"
        '
        'btnSave
        '
        Me.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnSave.Location = New System.Drawing.Point(159, 178)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(90, 23)
        Me.btnSave.TabIndex = 13
        Me.btnSave.Text = "&Save Settings"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(269, 178)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(90, 23)
        Me.btnCancel.TabIndex = 14
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'lblMountLetter
        '
        Me.lblMountLetter.AutoSize = True
        Me.lblMountLetter.Location = New System.Drawing.Point(12, 184)
        Me.lblMountLetter.Name = "lblMountLetter"
        Me.lblMountLetter.Size = New System.Drawing.Size(70, 13)
        Me.lblMountLetter.TabIndex = 15
        Me.lblMountLetter.Text = "Mount Letter:"
        '
        'txtMountLetter
        '
        Me.txtMountLetter.Location = New System.Drawing.Point(88, 181)
        Me.txtMountLetter.MaxLength = 1
        Me.txtMountLetter.Name = "txtMountLetter"
        Me.txtMountLetter.Size = New System.Drawing.Size(49, 20)
        Me.txtMountLetter.TabIndex = 16
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SettingsToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(371, 24)
        Me.MenuStrip1.TabIndex = 17
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImportSettingsFileToolStripMenuItem, Me.ExportSettingsToolStripMenuItem, Me.ToolStripSeparator1, Me.SaveSettingsToolStripMenuItem, Me.CancelToolStripMenuItem})
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.SettingsToolStripMenuItem.Text = "Settings"
        '
        'ImportSettingsFileToolStripMenuItem
        '
        Me.ImportSettingsFileToolStripMenuItem.Name = "ImportSettingsFileToolStripMenuItem"
        Me.ImportSettingsFileToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.ImportSettingsFileToolStripMenuItem.Text = "Import Settings"
        '
        'ExportSettingsToolStripMenuItem
        '
        Me.ExportSettingsToolStripMenuItem.Name = "ExportSettingsToolStripMenuItem"
        Me.ExportSettingsToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.ExportSettingsToolStripMenuItem.Text = "Export Settings"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(152, 6)
        '
        'SaveSettingsToolStripMenuItem
        '
        Me.SaveSettingsToolStripMenuItem.Name = "SaveSettingsToolStripMenuItem"
        Me.SaveSettingsToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.SaveSettingsToolStripMenuItem.Text = "Save Settings"
        '
        'CancelToolStripMenuItem
        '
        Me.CancelToolStripMenuItem.Name = "CancelToolStripMenuItem"
        Me.CancelToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.CancelToolStripMenuItem.Text = "Cancel"
        '
        'dlgImportSetttings
        '
        Me.dlgImportSetttings.FileName = "*.ams"
        Me.dlgImportSetttings.Filter = "Auto Mount Settings|*.ams"
        '
        'dlgExportSettings
        '
        Me.dlgExportSettings.FileName = "Settings.ams"
        Me.dlgExportSettings.Filter = "Auto Mount Settings|*.ams"
        '
        'Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(371, 214)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtMountLetter)
        Me.Controls.Add(Me.lblMountLetter)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.gpbPasswordSettings)
        Me.Controls.Add(Me.gpbMountOptions)
        Me.Controls.Add(Me.btnKeyfile)
        Me.Controls.Add(Me.btnContainer)
        Me.Controls.Add(Me.txtKeyfile)
        Me.Controls.Add(Me.chkUseKeyfile)
        Me.Controls.Add(Me.txtContainer)
        Me.Controls.Add(Me.lblContainer)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Settings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Settings"
        Me.gpbMountOptions.ResumeLayout(False)
        Me.gpbMountOptions.PerformLayout()
        Me.gpbPasswordSettings.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblContainer As System.Windows.Forms.Label
    Friend WithEvents txtContainer As System.Windows.Forms.TextBox
    Friend WithEvents chkUseKeyfile As System.Windows.Forms.CheckBox
    Friend WithEvents txtKeyfile As System.Windows.Forms.TextBox
    Friend WithEvents btnContainer As System.Windows.Forms.Button
    Friend WithEvents btnKeyfile As System.Windows.Forms.Button
    Friend WithEvents chkRemovable As System.Windows.Forms.CheckBox
    Friend WithEvents btnMountPassword As System.Windows.Forms.Button
    Friend WithEvents btnMasterPassword As System.Windows.Forms.Button
    Friend WithEvents gpbMountOptions As System.Windows.Forms.GroupBox
    Friend WithEvents chkReadOnly As System.Windows.Forms.CheckBox
    Friend WithEvents gpbPasswordSettings As System.Windows.Forms.GroupBox
    Friend WithEvents chkBackupHeader As System.Windows.Forms.CheckBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lblMountLetter As System.Windows.Forms.Label
    Friend WithEvents txtMountLetter As System.Windows.Forms.TextBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents SettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImportSettingsFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportSettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SaveSettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CancelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dlgImportSetttings As System.Windows.Forms.OpenFileDialog
    Friend WithEvents dlgExportSettings As System.Windows.Forms.SaveFileDialog
End Class
