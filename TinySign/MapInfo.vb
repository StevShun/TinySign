Public Class MapInfo
    Dim mapInfoFormString As String()

    Public Sub updateValues(mapInfo As String())
        Array.Copy(mapInfo, mapInfoFormString, 4)
    End Sub

    Private Sub mapInfoForm_open(sender As Object, e As EventArgs) Handles Me.Activated
        MapNameBox.Text = mapInfoFormString(1)
    End Sub

    Private Sub mainWindow_refocus(sender As Object, e As EventArgs) Handles Me.FormClosed
        MainWindow.Activate()
    End Sub

End Class