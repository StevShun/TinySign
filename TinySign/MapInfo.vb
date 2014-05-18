Public Class MapInfo

    Private Sub mainWindow_refocus(sender As Object, e As EventArgs) Handles Me.FormClosed
        MainWindow.Activate()
    End Sub
End Class