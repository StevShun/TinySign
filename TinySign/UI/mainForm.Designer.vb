﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.menuStrip = New System.Windows.Forms.MenuStrip()
        Me.fileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.openMapMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.closeMapMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mapInfoMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.resignMapMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.aboutMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.currentSigLabel = New System.Windows.Forms.Label()
        Me.applySigLabel = New System.Windows.Forms.Label()
        Me.currentSigTextBox = New System.Windows.Forms.TextBox()
        Me.applySigTextBox = New System.Windows.Forms.TextBox()
        Me.mapIconBox = New System.Windows.Forms.PictureBox()
        Me.statusStrip = New System.Windows.Forms.StatusStrip()
        Me.toolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.menuStrip.SuspendLayout()
        CType(Me.mapIconBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.statusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'menuStrip
        '
        Me.menuStrip.BackColor = System.Drawing.SystemColors.MenuBar
        Me.menuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.fileToolStripMenuItem, Me.toolsToolStripMenuItem, Me.aboutMenuItem})
        resources.ApplyResources(Me.menuStrip, "menuStrip")
        Me.menuStrip.Name = "menuStrip"
        '
        'fileToolStripMenuItem
        '
        Me.fileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.openMapMenuItem, Me.closeMapMenuItem})
        Me.fileToolStripMenuItem.Name = "fileToolStripMenuItem"
        resources.ApplyResources(Me.fileToolStripMenuItem, "fileToolStripMenuItem")
        '
        'openMapMenuItem
        '
        Me.openMapMenuItem.Name = "openMapMenuItem"
        resources.ApplyResources(Me.openMapMenuItem, "openMapMenuItem")
        '
        'closeMapMenuItem
        '
        Me.closeMapMenuItem.Name = "closeMapMenuItem"
        resources.ApplyResources(Me.closeMapMenuItem, "closeMapMenuItem")
        '
        'toolsToolStripMenuItem
        '
        Me.toolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mapInfoMenuItem, Me.resignMapMenuItem})
        Me.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem"
        resources.ApplyResources(Me.toolsToolStripMenuItem, "toolsToolStripMenuItem")
        '
        'mapInfoMenuItem
        '
        Me.mapInfoMenuItem.Name = "mapInfoMenuItem"
        resources.ApplyResources(Me.mapInfoMenuItem, "mapInfoMenuItem")
        '
        'resignMapMenuItem
        '
        Me.resignMapMenuItem.Name = "resignMapMenuItem"
        resources.ApplyResources(Me.resignMapMenuItem, "resignMapMenuItem")
        '
        'aboutMenuItem
        '
        Me.aboutMenuItem.Name = "aboutMenuItem"
        resources.ApplyResources(Me.aboutMenuItem, "aboutMenuItem")
        '
        'currentSigLabel
        '
        resources.ApplyResources(Me.currentSigLabel, "currentSigLabel")
        Me.currentSigLabel.Name = "currentSigLabel"
        '
        'applySigLabel
        '
        resources.ApplyResources(Me.applySigLabel, "applySigLabel")
        Me.applySigLabel.Name = "applySigLabel"
        '
        'currentSigTextBox
        '
        resources.ApplyResources(Me.currentSigTextBox, "currentSigTextBox")
        Me.currentSigTextBox.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.currentSigTextBox.Name = "currentSigTextBox"
        Me.currentSigTextBox.ReadOnly = True
        '
        'applySigTextBox
        '
        resources.ApplyResources(Me.applySigTextBox, "applySigTextBox")
        Me.applySigTextBox.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.applySigTextBox.ForeColor = System.Drawing.SystemColors.WindowText
        Me.applySigTextBox.Name = "applySigTextBox"
        Me.applySigTextBox.ReadOnly = True
        '
        'mapIconBox
        '
        Me.mapIconBox.BackColor = System.Drawing.SystemColors.Control
        resources.ApplyResources(Me.mapIconBox, "mapIconBox")
        Me.mapIconBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.mapIconBox.Cursor = System.Windows.Forms.Cursors.Hand
        Me.mapIconBox.Image = Global.TinySign.My.Resources.Resources.Unknown_Map
        Me.mapIconBox.InitialImage = Global.TinySign.My.Resources.Resources.Unknown_Map
        Me.mapIconBox.Name = "mapIconBox"
        Me.mapIconBox.TabStop = False
        '
        'statusStrip
        '
        resources.ApplyResources(Me.statusStrip, "statusStrip")
        Me.statusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripStatusLabel})
        Me.statusStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow
        Me.statusStrip.Name = "statusStrip"
        Me.statusStrip.ShowItemToolTips = True
        Me.statusStrip.SizingGrip = False
        '
        'toolStripStatusLabel
        '
        Me.toolStripStatusLabel.AutoToolTip = True
        Me.toolStripStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner
        Me.toolStripStatusLabel.Name = "toolStripStatusLabel"
        resources.ApplyResources(Me.toolStripStatusLabel, "toolStripStatusLabel")
        '
        'mainForm
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.statusStrip)
        Me.Controls.Add(Me.applySigTextBox)
        Me.Controls.Add(Me.currentSigTextBox)
        Me.Controls.Add(Me.applySigLabel)
        Me.Controls.Add(Me.currentSigLabel)
        Me.Controls.Add(Me.mapIconBox)
        Me.Controls.Add(Me.menuStrip)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MainMenuStrip = Me.menuStrip
        Me.MaximizeBox = False
        Me.Name = "mainForm"
        Me.menuStrip.ResumeLayout(False)
        Me.menuStrip.PerformLayout()
        CType(Me.mapIconBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.statusStrip.ResumeLayout(False)
        Me.statusStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents menuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents fileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents openMapMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents closeMapMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents resignMapMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mapInfoMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mapIconBox As System.Windows.Forms.PictureBox
    Friend WithEvents currentSigLabel As System.Windows.Forms.Label
    Friend WithEvents applySigLabel As System.Windows.Forms.Label
    Friend WithEvents currentSigTextBox As System.Windows.Forms.TextBox
    Friend WithEvents applySigTextBox As System.Windows.Forms.TextBox
    Friend WithEvents aboutMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents statusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents toolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel

End Class
