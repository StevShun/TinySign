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
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenMapToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseMapToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResignMapToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MapInfoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CurrentSignatureLabel = New System.Windows.Forms.Label()
        Me.ApplySignatureLabel = New System.Windows.Forms.Label()
        Me.CurrentSigTextBox = New System.Windows.Forms.TextBox()
        Me.ApplySigTextBox = New System.Windows.Forms.TextBox()
        Me.MapIconBox = New System.Windows.Forms.PictureBox()
        Me.MenuStrip.SuspendLayout()
        CType(Me.MapIconBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.BackColor = System.Drawing.SystemColors.MenuBar
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ToolsToolStripMenuItem, Me.AboutToolStripMenuItem, Me.ToolStripMenuItem1})
        resources.ApplyResources(Me.MenuStrip, "MenuStrip")
        Me.MenuStrip.Name = "MenuStrip"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenMapToolStripMenuItem, Me.CloseMapToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        resources.ApplyResources(Me.FileToolStripMenuItem, "FileToolStripMenuItem")
        '
        'OpenMapToolStripMenuItem
        '
        Me.OpenMapToolStripMenuItem.Name = "OpenMapToolStripMenuItem"
        resources.ApplyResources(Me.OpenMapToolStripMenuItem, "OpenMapToolStripMenuItem")
        '
        'CloseMapToolStripMenuItem
        '
        Me.CloseMapToolStripMenuItem.Name = "CloseMapToolStripMenuItem"
        resources.ApplyResources(Me.CloseMapToolStripMenuItem, "CloseMapToolStripMenuItem")
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ResignMapToolStripMenuItem, Me.MapInfoToolStripMenuItem})
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        resources.ApplyResources(Me.ToolsToolStripMenuItem, "ToolsToolStripMenuItem")
        '
        'ResignMapToolStripMenuItem
        '
        Me.ResignMapToolStripMenuItem.Name = "ResignMapToolStripMenuItem"
        resources.ApplyResources(Me.ResignMapToolStripMenuItem, "ResignMapToolStripMenuItem")
        '
        'MapInfoToolStripMenuItem
        '
        Me.MapInfoToolStripMenuItem.Name = "MapInfoToolStripMenuItem"
        resources.ApplyResources(Me.MapInfoToolStripMenuItem, "MapInfoToolStripMenuItem")
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        resources.ApplyResources(Me.AboutToolStripMenuItem, "AboutToolStripMenuItem")
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        resources.ApplyResources(Me.ToolStripMenuItem1, "ToolStripMenuItem1")
        '
        'CurrentSignatureLabel
        '
        resources.ApplyResources(Me.CurrentSignatureLabel, "CurrentSignatureLabel")
        Me.CurrentSignatureLabel.Name = "CurrentSignatureLabel"
        '
        'ApplySignatureLabel
        '
        resources.ApplyResources(Me.ApplySignatureLabel, "ApplySignatureLabel")
        Me.ApplySignatureLabel.Name = "ApplySignatureLabel"
        '
        'CurrentSigTextBox
        '
        Me.CurrentSigTextBox.BackColor = System.Drawing.SystemColors.ButtonFace
        resources.ApplyResources(Me.CurrentSigTextBox, "CurrentSigTextBox")
        Me.CurrentSigTextBox.Name = "CurrentSigTextBox"
        Me.CurrentSigTextBox.ReadOnly = True
        '
        'ApplySigTextBox
        '
        Me.ApplySigTextBox.BackColor = System.Drawing.SystemColors.ButtonFace
        resources.ApplyResources(Me.ApplySigTextBox, "ApplySigTextBox")
        Me.ApplySigTextBox.Name = "ApplySigTextBox"
        Me.ApplySigTextBox.ReadOnly = True
        '
        'MapIconBox
        '
        resources.ApplyResources(Me.MapIconBox, "MapIconBox")
        Me.MapIconBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MapIconBox.Image = Global.TinySign.My.Resources.Resources.Unknown_Map
        Me.MapIconBox.InitialImage = Global.TinySign.My.Resources.Resources.Unknown_Map
        Me.MapIconBox.Name = "MapIconBox"
        Me.MapIconBox.TabStop = False
        '
        'MainWindow
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ApplySigTextBox)
        Me.Controls.Add(Me.CurrentSigTextBox)
        Me.Controls.Add(Me.ApplySignatureLabel)
        Me.Controls.Add(Me.CurrentSignatureLabel)
        Me.Controls.Add(Me.MapIconBox)
        Me.Controls.Add(Me.MenuStrip)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MainMenuStrip = Me.MenuStrip
        Me.MaximizeBox = False
        Me.Name = "MainWindow"
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        CType(Me.MapIconBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenMapToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseMapToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ResignMapToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MapInfoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MapIconBox As System.Windows.Forms.PictureBox
    Friend WithEvents CurrentSignatureLabel As System.Windows.Forms.Label
    Friend WithEvents ApplySignatureLabel As System.Windows.Forms.Label
    Friend WithEvents CurrentSigTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ApplySigTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
