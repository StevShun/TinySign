<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class mainForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(mainForm))
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.fileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.openMapToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.closeMapToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.resignMapToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mapInfoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.aboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.currentSignatureLabel = New System.Windows.Forms.Label()
        Me.applySignatureLabel = New System.Windows.Forms.Label()
        Me.currentSigTextBox = New System.Windows.Forms.TextBox()
        Me.applySigTextBox = New System.Windows.Forms.TextBox()
        Me.mapIconBox = New System.Windows.Forms.PictureBox()
        Me.MenuStrip.SuspendLayout()
        CType(Me.mapIconBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.BackColor = System.Drawing.SystemColors.MenuBar
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.fileToolStripMenuItem, Me.toolsToolStripMenuItem, Me.aboutToolStripMenuItem, Me.ToolStripMenuItem1})
        resources.ApplyResources(Me.MenuStrip, "MenuStrip")
        Me.MenuStrip.Name = "MenuStrip"
        '
        'fileToolStripMenuItem
        '
        Me.fileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.openMapToolStripMenuItem, Me.closeMapToolStripMenuItem})
        Me.fileToolStripMenuItem.Name = "fileToolStripMenuItem"
        resources.ApplyResources(Me.fileToolStripMenuItem, "fileToolStripMenuItem")
        '
        'openMapToolStripMenuItem
        '
        Me.openMapToolStripMenuItem.Name = "openMapToolStripMenuItem"
        resources.ApplyResources(Me.openMapToolStripMenuItem, "openMapToolStripMenuItem")
        '
        'closeMapToolStripMenuItem
        '
        Me.closeMapToolStripMenuItem.Name = "closeMapToolStripMenuItem"
        resources.ApplyResources(Me.closeMapToolStripMenuItem, "closeMapToolStripMenuItem")
        '
        'toolsToolStripMenuItem
        '
        Me.toolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.resignMapToolStripMenuItem, Me.mapInfoToolStripMenuItem})
        Me.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem"
        resources.ApplyResources(Me.toolsToolStripMenuItem, "toolsToolStripMenuItem")
        '
        'resignMapToolStripMenuItem
        '
        Me.resignMapToolStripMenuItem.Name = "resignMapToolStripMenuItem"
        resources.ApplyResources(Me.resignMapToolStripMenuItem, "resignMapToolStripMenuItem")
        '
        'mapInfoToolStripMenuItem
        '
        Me.mapInfoToolStripMenuItem.Name = "mapInfoToolStripMenuItem"
        resources.ApplyResources(Me.mapInfoToolStripMenuItem, "mapInfoToolStripMenuItem")
        '
        'aboutToolStripMenuItem
        '
        Me.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem"
        resources.ApplyResources(Me.aboutToolStripMenuItem, "aboutToolStripMenuItem")
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        resources.ApplyResources(Me.ToolStripMenuItem1, "ToolStripMenuItem1")
        '
        'currentSignatureLabel
        '
        resources.ApplyResources(Me.currentSignatureLabel, "currentSignatureLabel")
        Me.currentSignatureLabel.Name = "currentSignatureLabel"
        '
        'applySignatureLabel
        '
        resources.ApplyResources(Me.applySignatureLabel, "applySignatureLabel")
        Me.applySignatureLabel.Name = "applySignatureLabel"
        '
        'currentSigTextBox
        '
        Me.currentSigTextBox.BackColor = System.Drawing.SystemColors.ButtonFace
        resources.ApplyResources(Me.currentSigTextBox, "currentSigTextBox")
        Me.currentSigTextBox.Name = "currentSigTextBox"
        Me.currentSigTextBox.ReadOnly = True
        '
        'applySigTextBox
        '
        Me.applySigTextBox.BackColor = System.Drawing.SystemColors.ButtonFace
        resources.ApplyResources(Me.applySigTextBox, "applySigTextBox")
        Me.applySigTextBox.Name = "applySigTextBox"
        Me.applySigTextBox.ReadOnly = True
        '
        'mapIconBox
        '
        resources.ApplyResources(Me.mapIconBox, "mapIconBox")
        Me.mapIconBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mapIconBox.Image = Global.TinySign.My.Resources.Resources.Unknown_Map
        Me.mapIconBox.InitialImage = Global.TinySign.My.Resources.Resources.Unknown_Map
        Me.mapIconBox.Name = "mapIconBox"
        Me.mapIconBox.TabStop = False
        '
        'mainForm
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.applySigTextBox)
        Me.Controls.Add(Me.currentSigTextBox)
        Me.Controls.Add(Me.applySignatureLabel)
        Me.Controls.Add(Me.currentSignatureLabel)
        Me.Controls.Add(Me.mapIconBox)
        Me.Controls.Add(Me.MenuStrip)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MainMenuStrip = Me.MenuStrip
        Me.MaximizeBox = False
        Me.Name = "mainForm"
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        CType(Me.mapIconBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents fileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents openMapToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents closeMapToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents resignMapToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mapInfoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mapIconBox As System.Windows.Forms.PictureBox
    Friend WithEvents currentSignatureLabel As System.Windows.Forms.Label
    Friend WithEvents applySignatureLabel As System.Windows.Forms.Label
    Friend WithEvents currentSigTextBox As System.Windows.Forms.TextBox
    Friend WithEvents applySigTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents aboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
