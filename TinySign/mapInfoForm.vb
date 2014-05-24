Public Class mapInfoForm

    'Points to map inforamtion
    Private mapInformation As String()

    'Recieves map informaiton so that we can use it in this class
    Public Sub updateValues(passedInformation As String())
        mapInformation = passedInformation
    End Sub

    'Outputs map information to the window on form activation
    Private Sub mapInfoForm_open(sender As Object, e As EventArgs) Handles Me.Activated
        mapNameTextBox.Text = mapInformation(1)
        internalNameTextBox.Text = mapInformation(0)
        currentScenPathTextBox.Text = " "
        correctScenPathTextBox.Text = mapInformation(2)
        correctSigTextBox.Text = mapInformation(4)
    End Sub

    'Focus on mainForm when mapInfoForm is closed by user
    Private Sub mainForm_focus(sender As Object, e As EventArgs) Handles Me.FormClosed
        mainForm.Activate()
    End Sub

    Private Sub copyToClipboard_mapName(sender As Object, e As EventArgs) Handles mapNameTextBox.Click
        'Identify the current control selected by user
        Dim currentControl As TextBox = Me.ActiveControl

        'Grab the text
        Clipboard.SetText(currentControl.Text)

        'Update UI
        currentControl.SelectAll()
        statusLabel.Text = "Copied " & currentControl.Text & " to clipboard."
    End Sub

    Private Sub copyToClipboard_internalName(sender As Object, e As EventArgs) Handles internalNameTextBox.Click
        'Identify the current control selected by user
        Dim currentControl As TextBox = Me.ActiveControl

        'Grab the text
        Clipboard.SetText(currentControl.Text)

        'Update UI
        currentControl.SelectAll()
        statusLabel.Text = "Copied " & currentControl.Text & " to clipboard."
    End Sub

    Private Sub copyToClipboard_currentScenPath(sender As Object, e As EventArgs) Handles currentScenPathTextBox.Click
        'Identify the current control selected by user
        Dim currentControl As TextBox = Me.ActiveControl

        'Grab the text
        Clipboard.SetText(currentControl.Text)

        'Update UI
        currentControl.SelectAll()
        statusLabel.Text = "Copied " & currentControl.Text & " to clipboard."
    End Sub

    Private Sub copyToClipboard_correctScenPathTextBox(sender As Object, e As EventArgs) Handles correctScenPathTextBox.Click
        'Identify the current control selected by user
        Dim currentControl As TextBox = Me.ActiveControl

        'Grab the text
        Clipboard.SetText(currentControl.Text)

        'Update UI
        currentControl.SelectAll()
        statusLabel.Text = "Copied " & currentControl.Text & " to clipboard."
    End Sub

    Private Sub copyToClipboard_correctSigTextBox(sender As Object, e As EventArgs) Handles correctSigTextBox.Click
        'Identify the current control selected by user
        Dim currentControl As TextBox = Me.ActiveControl

        'Grab the text
        Clipboard.SetText(currentControl.Text)

        'Update UI
        currentControl.SelectAll()
        statusLabel.Text = "Copied " & currentControl.Text & " to clipboard."
    End Sub

End Class