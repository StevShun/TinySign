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
        correctScenPathLabel.Text = mapInformation(2)
    End Sub

    'Focus on mainForm when mapInfoForm is closed by user
    Private Sub mainForm_focus(sender As Object, e As EventArgs) Handles Me.FormClosed
        mainForm.Activate()
    End Sub

End Class