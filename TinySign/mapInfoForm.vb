Public Class mapInfoForm

    'Points to map inforamtion
    Private mapInformation As String()
    Private mapInternalName As String
    Private mapScenarioPath As String
    Private mapCurrentSig As String

    'Recieves map informaiton so that we can use it in this class
    Public Sub updateValues(passedMapDBArray As String(), passedInternalName As String, passedScenarioPath As String, passedCurrentSig As String)
        mapInformation = passedMapDBArray
        mapInternalName = passedInternalName
        mapScenarioPath = passedScenarioPath
        mapCurrentSig = passedCurrentSig
    End Sub

    'Outputs map information to the window on form activation
    Private Sub mapInfoForm_open(sender As Object, e As EventArgs) Handles Me.Activated
        mapNameTextBox.Text = mapInformation(1)
        internalNameTextBox.Text = mapInternalName
        stockScenPathTextBox.Text = mapInformation(2)
        currentScenPathTextBox.Text = mapScenarioPath
        stockSignatureTextBox.Text = mapInformation(3)
        currentSignatureTextBox.Text = mapCurrentSig
    End Sub

    Private Sub copyTextToClipboard(sender As Object, e As EventArgs) Handles mapNameTextBox.Click, internalNameTextBox.Click, stockScenPathTextBox.Click, currentScenPathTextBox.Click, stockSignatureTextBox.Click, currentSignatureTextBox.Click
        'Identify the current control selected by user
        Dim currentControl As TextBox = Me.ActiveControl

        If currentControl.Text = "" Then
            'Do nothing
        Else
            'Grab the text
            Clipboard.SetText(currentControl.Text)
            'Update UI
            currentControl.SelectAll()
            statusLabel.Text = "Copied " & "'" & currentControl.Text & "'" & " to clipboard."
        End If
    End Sub

    'Focus on mainForm when mapInfoForm is closed by user
    Private Sub mainForm_focus(sender As Object, e As EventArgs) Handles Me.FormClosed
        mainForm.Activate()
    End Sub

End Class