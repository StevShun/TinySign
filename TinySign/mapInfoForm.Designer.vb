<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class mapInfoForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(mapInfoForm))
        Me.mapNameLabel = New System.Windows.Forms.Label()
        Me.internalNameLabel = New System.Windows.Forms.Label()
        Me.mapNameTextBox = New System.Windows.Forms.TextBox()
        Me.internalNameTextBox = New System.Windows.Forms.TextBox()
        Me.correctSigLabel = New System.Windows.Forms.Label()
        Me.correctSigTextBox = New System.Windows.Forms.TextBox()
        Me.correctScenPathLabel = New System.Windows.Forms.Label()
        Me.correctScenPathTextBox = New System.Windows.Forms.TextBox()
        Me.statusStrip = New System.Windows.Forms.StatusStrip()
        Me.statusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.statusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'mapNameLabel
        '
        Me.mapNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.mapNameLabel.AutoSize = True
        Me.mapNameLabel.Location = New System.Drawing.Point(11, 6)
        Me.mapNameLabel.Name = "mapNameLabel"
        Me.mapNameLabel.Size = New System.Drawing.Size(62, 13)
        Me.mapNameLabel.TabIndex = 0
        Me.mapNameLabel.Text = "Map Name:"
        '
        'internalNameLabel
        '
        Me.internalNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.internalNameLabel.AutoSize = True
        Me.internalNameLabel.Location = New System.Drawing.Point(11, 45)
        Me.internalNameLabel.Name = "internalNameLabel"
        Me.internalNameLabel.Size = New System.Drawing.Size(76, 13)
        Me.internalNameLabel.TabIndex = 1
        Me.internalNameLabel.Text = "Internal Name:"
        '
        'mapNameTextBox
        '
        Me.mapNameTextBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.mapNameTextBox.BackColor = System.Drawing.SystemColors.ControlLight
        Me.mapNameTextBox.Location = New System.Drawing.Point(15, 22)
        Me.mapNameTextBox.Name = "mapNameTextBox"
        Me.mapNameTextBox.ReadOnly = True
        Me.mapNameTextBox.Size = New System.Drawing.Size(240, 20)
        Me.mapNameTextBox.TabIndex = 2
        '
        'internalNameTextBox
        '
        Me.internalNameTextBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.internalNameTextBox.BackColor = System.Drawing.SystemColors.ControlLight
        Me.internalNameTextBox.Location = New System.Drawing.Point(15, 61)
        Me.internalNameTextBox.Name = "internalNameTextBox"
        Me.internalNameTextBox.ReadOnly = True
        Me.internalNameTextBox.Size = New System.Drawing.Size(240, 20)
        Me.internalNameTextBox.TabIndex = 3
        '
        'correctSigLabel
        '
        Me.correctSigLabel.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.correctSigLabel.AutoSize = True
        Me.correctSigLabel.Location = New System.Drawing.Point(11, 123)
        Me.correctSigLabel.Name = "correctSigLabel"
        Me.correctSigLabel.Size = New System.Drawing.Size(92, 13)
        Me.correctSigLabel.TabIndex = 1
        Me.correctSigLabel.Text = "Correct Signature:"
        '
        'correctSigTextBox
        '
        Me.correctSigTextBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.correctSigTextBox.BackColor = System.Drawing.SystemColors.ControlLight
        Me.correctSigTextBox.Location = New System.Drawing.Point(14, 139)
        Me.correctSigTextBox.Name = "correctSigTextBox"
        Me.correctSigTextBox.ReadOnly = True
        Me.correctSigTextBox.Size = New System.Drawing.Size(240, 20)
        Me.correctSigTextBox.TabIndex = 3
        '
        'correctScenPathLabel
        '
        Me.correctScenPathLabel.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.correctScenPathLabel.AutoSize = True
        Me.correctScenPathLabel.Location = New System.Drawing.Point(11, 84)
        Me.correctScenPathLabel.Name = "correctScenPathLabel"
        Me.correctScenPathLabel.Size = New System.Drawing.Size(114, 13)
        Me.correctScenPathLabel.TabIndex = 1
        Me.correctScenPathLabel.Text = "Correct Scenario Path:"
        '
        'correctScenPathTextBox
        '
        Me.correctScenPathTextBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.correctScenPathTextBox.BackColor = System.Drawing.SystemColors.ControlLight
        Me.correctScenPathTextBox.Location = New System.Drawing.Point(14, 100)
        Me.correctScenPathTextBox.Name = "correctScenPathTextBox"
        Me.correctScenPathTextBox.ReadOnly = True
        Me.correctScenPathTextBox.Size = New System.Drawing.Size(240, 20)
        Me.correctScenPathTextBox.TabIndex = 3
        '
        'statusStrip
        '
        Me.statusStrip.Enabled = False
        Me.statusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.statusLabel})
        Me.statusStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow
        Me.statusStrip.Location = New System.Drawing.Point(0, 167)
        Me.statusStrip.Name = "statusStrip"
        Me.statusStrip.Size = New System.Drawing.Size(267, 17)
        Me.statusStrip.TabIndex = 4
        Me.statusStrip.Text = "statusStrip"
        '
        'statusLabel
        '
        Me.statusLabel.Font = New System.Drawing.Font("Segoe UI", 7.0!)
        Me.statusLabel.Name = "statusLabel"
        Me.statusLabel.Size = New System.Drawing.Size(121, 12)
        Me.statusLabel.Text = "Status: Ready to copy text."
        '
        'mapInfoForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(267, 184)
        Me.Controls.Add(Me.statusStrip)
        Me.Controls.Add(Me.correctSigTextBox)
        Me.Controls.Add(Me.correctScenPathTextBox)
        Me.Controls.Add(Me.internalNameTextBox)
        Me.Controls.Add(Me.correctSigLabel)
        Me.Controls.Add(Me.mapNameTextBox)
        Me.Controls.Add(Me.correctScenPathLabel)
        Me.Controls.Add(Me.internalNameLabel)
        Me.Controls.Add(Me.mapNameLabel)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(483, 222)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(283, 222)
        Me.Name = "mapInfoForm"
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Map Information"
        Me.TopMost = True
        Me.statusStrip.ResumeLayout(False)
        Me.statusStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents mapNameLabel As System.Windows.Forms.Label
    Friend WithEvents internalNameLabel As System.Windows.Forms.Label
    Friend WithEvents mapNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents internalNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents correctSigLabel As System.Windows.Forms.Label
    Friend WithEvents correctSigTextBox As System.Windows.Forms.TextBox
    Friend WithEvents correctScenPathLabel As System.Windows.Forms.Label
    Friend WithEvents correctScenPathTextBox As System.Windows.Forms.TextBox
    Friend WithEvents statusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents statusLabel As System.Windows.Forms.ToolStripStatusLabel
End Class
