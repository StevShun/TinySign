Public Class mapInfoForm

    ' Points to map inforamtion
    Private map As String()

    ' Gives map informaiton so we can use it here
    Public Sub updateValues(mapInfo As String())
        map = mapInfo
    End Sub

    ' Outputs map information to the window and opens window(I think?)
    Private Sub mapInfoForm_open(sender As Object, e As EventArgs) Handles Me.Activated
        MapNameBox.Text = map(1)
    End Sub

    'WTF is this!?
    Private Sub mainWindow_refocus(sender As Object, e As EventArgs) Handles Me.FormClosed
        mainForm.Activate()
    End Sub

End Class