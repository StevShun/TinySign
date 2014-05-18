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
        Me.MapNameLabel = New System.Windows.Forms.Label()
        Me.InternalNameLabel = New System.Windows.Forms.Label()
        Me.MapNameBox = New System.Windows.Forms.TextBox()
        Me.InternalNameBox = New System.Windows.Forms.TextBox()
        Me.CurrentScenarioPathLabel = New System.Windows.Forms.Label()
        Me.ScenarioPathBox = New System.Windows.Forms.TextBox()
        Me.CorrectSignatureLabel = New System.Windows.Forms.Label()
        Me.CorrectSignatureBox = New System.Windows.Forms.TextBox()
        Me.CorrectScenarioPathLabel = New System.Windows.Forms.Label()
        Me.CorrectScenarioPathTextBox = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'MapNameLabel
        '
        Me.MapNameLabel.AutoSize = True
        Me.MapNameLabel.Location = New System.Drawing.Point(11, 9)
        Me.MapNameLabel.Name = "MapNameLabel"
        Me.MapNameLabel.Size = New System.Drawing.Size(62, 13)
        Me.MapNameLabel.TabIndex = 0
        Me.MapNameLabel.Text = "Map Name:"
        '
        'InternalNameLabel
        '
        Me.InternalNameLabel.AutoSize = True
        Me.InternalNameLabel.Location = New System.Drawing.Point(11, 48)
        Me.InternalNameLabel.Name = "InternalNameLabel"
        Me.InternalNameLabel.Size = New System.Drawing.Size(76, 13)
        Me.InternalNameLabel.TabIndex = 1
        Me.InternalNameLabel.Text = "Internal Name:"
        '
        'MapNameBox
        '
        Me.MapNameBox.Location = New System.Drawing.Point(15, 25)
        Me.MapNameBox.Name = "MapNameBox"
        Me.MapNameBox.ReadOnly = True
        Me.MapNameBox.Size = New System.Drawing.Size(240, 20)
        Me.MapNameBox.TabIndex = 2
        '
        'InternalNameBox
        '
        Me.InternalNameBox.Location = New System.Drawing.Point(15, 64)
        Me.InternalNameBox.Name = "InternalNameBox"
        Me.InternalNameBox.ReadOnly = True
        Me.InternalNameBox.Size = New System.Drawing.Size(240, 20)
        Me.InternalNameBox.TabIndex = 3
        '
        'CurrentScenarioPathLabel
        '
        Me.CurrentScenarioPathLabel.AutoSize = True
        Me.CurrentScenarioPathLabel.Location = New System.Drawing.Point(11, 87)
        Me.CurrentScenarioPathLabel.Name = "CurrentScenarioPathLabel"
        Me.CurrentScenarioPathLabel.Size = New System.Drawing.Size(114, 13)
        Me.CurrentScenarioPathLabel.TabIndex = 1
        Me.CurrentScenarioPathLabel.Text = "Current Scenario Path:"
        '
        'ScenarioPathBox
        '
        Me.ScenarioPathBox.Location = New System.Drawing.Point(15, 103)
        Me.ScenarioPathBox.Name = "ScenarioPathBox"
        Me.ScenarioPathBox.ReadOnly = True
        Me.ScenarioPathBox.Size = New System.Drawing.Size(240, 20)
        Me.ScenarioPathBox.TabIndex = 3
        '
        'CorrectSignatureLabel
        '
        Me.CorrectSignatureLabel.AutoSize = True
        Me.CorrectSignatureLabel.Location = New System.Drawing.Point(11, 165)
        Me.CorrectSignatureLabel.Name = "CorrectSignatureLabel"
        Me.CorrectSignatureLabel.Size = New System.Drawing.Size(92, 13)
        Me.CorrectSignatureLabel.TabIndex = 1
        Me.CorrectSignatureLabel.Text = "Correct Signature:"
        '
        'CorrectSignatureBox
        '
        Me.CorrectSignatureBox.Location = New System.Drawing.Point(14, 181)
        Me.CorrectSignatureBox.Name = "CorrectSignatureBox"
        Me.CorrectSignatureBox.ReadOnly = True
        Me.CorrectSignatureBox.Size = New System.Drawing.Size(240, 20)
        Me.CorrectSignatureBox.TabIndex = 3
        '
        'CorrectScenarioPathLabel
        '
        Me.CorrectScenarioPathLabel.AutoSize = True
        Me.CorrectScenarioPathLabel.Location = New System.Drawing.Point(11, 126)
        Me.CorrectScenarioPathLabel.Name = "CorrectScenarioPathLabel"
        Me.CorrectScenarioPathLabel.Size = New System.Drawing.Size(114, 13)
        Me.CorrectScenarioPathLabel.TabIndex = 1
        Me.CorrectScenarioPathLabel.Text = "Correct Scenario Path:"
        '
        'CorrectScenarioPathTextBox
        '
        Me.CorrectScenarioPathTextBox.Location = New System.Drawing.Point(14, 142)
        Me.CorrectScenarioPathTextBox.Name = "CorrectScenarioPathTextBox"
        Me.CorrectScenarioPathTextBox.ReadOnly = True
        Me.CorrectScenarioPathTextBox.Size = New System.Drawing.Size(240, 20)
        Me.CorrectScenarioPathTextBox.TabIndex = 3
        '
        'mapInfoForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(267, 213)
        Me.Controls.Add(Me.CorrectSignatureBox)
        Me.Controls.Add(Me.CorrectScenarioPathTextBox)
        Me.Controls.Add(Me.ScenarioPathBox)
        Me.Controls.Add(Me.InternalNameBox)
        Me.Controls.Add(Me.CorrectSignatureLabel)
        Me.Controls.Add(Me.MapNameBox)
        Me.Controls.Add(Me.CorrectScenarioPathLabel)
        Me.Controls.Add(Me.CurrentScenarioPathLabel)
        Me.Controls.Add(Me.InternalNameLabel)
        Me.Controls.Add(Me.MapNameLabel)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "mapInfoForm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Map Information"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MapNameLabel As System.Windows.Forms.Label
    Friend WithEvents InternalNameLabel As System.Windows.Forms.Label
    Friend WithEvents MapNameBox As System.Windows.Forms.TextBox
    Friend WithEvents InternalNameBox As System.Windows.Forms.TextBox
    Friend WithEvents CurrentScenarioPathLabel As System.Windows.Forms.Label
    Friend WithEvents ScenarioPathBox As System.Windows.Forms.TextBox
    Friend WithEvents CorrectSignatureLabel As System.Windows.Forms.Label
    Friend WithEvents CorrectSignatureBox As System.Windows.Forms.TextBox
    Friend WithEvents CorrectScenarioPathLabel As System.Windows.Forms.Label
    Friend WithEvents CorrectScenarioPathTextBox As System.Windows.Forms.TextBox
End Class
