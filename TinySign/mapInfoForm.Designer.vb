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
        Me.currentScenPathLabel = New System.Windows.Forms.Label()
        Me.currentScenPathTextBox = New System.Windows.Forms.TextBox()
        Me.stockScenPathLabel = New System.Windows.Forms.Label()
        Me.stockScenPathTextBox = New System.Windows.Forms.TextBox()
        Me.statusStrip = New System.Windows.Forms.StatusStrip()
        Me.statusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.stockSignatureLabel = New System.Windows.Forms.Label()
        Me.stockSignatureTextBox = New System.Windows.Forms.TextBox()
        Me.currentSignatureLabel = New System.Windows.Forms.Label()
        Me.currentSignatureTextBox = New System.Windows.Forms.TextBox()
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
        'currentScenPathLabel
        '
        Me.currentScenPathLabel.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.currentScenPathLabel.AutoSize = True
        Me.currentScenPathLabel.Location = New System.Drawing.Point(11, 123)
        Me.currentScenPathLabel.Name = "currentScenPathLabel"
        Me.currentScenPathLabel.Size = New System.Drawing.Size(114, 13)
        Me.currentScenPathLabel.TabIndex = 1
        Me.currentScenPathLabel.Text = "Current Scenario Path:"
        '
        'currentScenPathTextBox
        '
        Me.currentScenPathTextBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.currentScenPathTextBox.BackColor = System.Drawing.SystemColors.ControlLight
        Me.currentScenPathTextBox.Location = New System.Drawing.Point(14, 139)
        Me.currentScenPathTextBox.Name = "currentScenPathTextBox"
        Me.currentScenPathTextBox.ReadOnly = True
        Me.currentScenPathTextBox.Size = New System.Drawing.Size(240, 20)
        Me.currentScenPathTextBox.TabIndex = 3
        '
        'stockScenPathLabel
        '
        Me.stockScenPathLabel.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.stockScenPathLabel.AutoSize = True
        Me.stockScenPathLabel.Location = New System.Drawing.Point(11, 84)
        Me.stockScenPathLabel.Name = "stockScenPathLabel"
        Me.stockScenPathLabel.Size = New System.Drawing.Size(108, 13)
        Me.stockScenPathLabel.TabIndex = 1
        Me.stockScenPathLabel.Text = "Stock Scenario Path:"
        '
        'stockScenPathTextBox
        '
        Me.stockScenPathTextBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.stockScenPathTextBox.BackColor = System.Drawing.SystemColors.ControlLight
        Me.stockScenPathTextBox.Location = New System.Drawing.Point(14, 100)
        Me.stockScenPathTextBox.Name = "stockScenPathTextBox"
        Me.stockScenPathTextBox.ReadOnly = True
        Me.stockScenPathTextBox.Size = New System.Drawing.Size(240, 20)
        Me.stockScenPathTextBox.TabIndex = 3
        '
        'statusStrip
        '
        Me.statusStrip.Enabled = False
        Me.statusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.statusLabel})
        Me.statusStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow
        Me.statusStrip.Location = New System.Drawing.Point(0, 245)
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
        'stockSignatureLabel
        '
        Me.stockSignatureLabel.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.stockSignatureLabel.AutoSize = True
        Me.stockSignatureLabel.Location = New System.Drawing.Point(11, 162)
        Me.stockSignatureLabel.Name = "stockSignatureLabel"
        Me.stockSignatureLabel.Size = New System.Drawing.Size(86, 13)
        Me.stockSignatureLabel.TabIndex = 1
        Me.stockSignatureLabel.Text = "Stock Signature:"
        '
        'stockSignatureTextBox
        '
        Me.stockSignatureTextBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.stockSignatureTextBox.BackColor = System.Drawing.SystemColors.ControlLight
        Me.stockSignatureTextBox.Location = New System.Drawing.Point(14, 178)
        Me.stockSignatureTextBox.Name = "stockSignatureTextBox"
        Me.stockSignatureTextBox.ReadOnly = True
        Me.stockSignatureTextBox.Size = New System.Drawing.Size(240, 20)
        Me.stockSignatureTextBox.TabIndex = 3
        '
        'currentSignatureLabel
        '
        Me.currentSignatureLabel.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.currentSignatureLabel.AutoSize = True
        Me.currentSignatureLabel.Location = New System.Drawing.Point(11, 201)
        Me.currentSignatureLabel.Name = "currentSignatureLabel"
        Me.currentSignatureLabel.Size = New System.Drawing.Size(92, 13)
        Me.currentSignatureLabel.TabIndex = 1
        Me.currentSignatureLabel.Text = "Current Signature:"
        '
        'currentSignatureTextBox
        '
        Me.currentSignatureTextBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.currentSignatureTextBox.BackColor = System.Drawing.SystemColors.ControlLight
        Me.currentSignatureTextBox.Location = New System.Drawing.Point(14, 217)
        Me.currentSignatureTextBox.Name = "currentSignatureTextBox"
        Me.currentSignatureTextBox.ReadOnly = True
        Me.currentSignatureTextBox.Size = New System.Drawing.Size(240, 20)
        Me.currentSignatureTextBox.TabIndex = 3
        '
        'mapInfoForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(267, 262)
        Me.Controls.Add(Me.statusStrip)
        Me.Controls.Add(Me.currentSignatureTextBox)
        Me.Controls.Add(Me.stockSignatureTextBox)
        Me.Controls.Add(Me.currentScenPathTextBox)
        Me.Controls.Add(Me.stockScenPathTextBox)
        Me.Controls.Add(Me.internalNameTextBox)
        Me.Controls.Add(Me.currentSignatureLabel)
        Me.Controls.Add(Me.stockSignatureLabel)
        Me.Controls.Add(Me.currentScenPathLabel)
        Me.Controls.Add(Me.mapNameTextBox)
        Me.Controls.Add(Me.stockScenPathLabel)
        Me.Controls.Add(Me.internalNameLabel)
        Me.Controls.Add(Me.mapNameLabel)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(483, 300)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(283, 300)
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
    Friend WithEvents currentScenPathLabel As System.Windows.Forms.Label
    Friend WithEvents currentScenPathTextBox As System.Windows.Forms.TextBox
    Friend WithEvents stockScenPathLabel As System.Windows.Forms.Label
    Friend WithEvents stockScenPathTextBox As System.Windows.Forms.TextBox
    Friend WithEvents statusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents statusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents stockSignatureLabel As System.Windows.Forms.Label
    Friend WithEvents stockSignatureTextBox As System.Windows.Forms.TextBox
    Friend WithEvents currentSignatureLabel As System.Windows.Forms.Label
    Friend WithEvents currentSignatureTextBox As System.Windows.Forms.TextBox
End Class
