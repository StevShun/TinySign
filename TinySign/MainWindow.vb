Imports System.IO

Public Class MainWindow

    Private Sub MainWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub OpenMapToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles OpenMapToolStripMenuItem.Click

        'Open File Dialogue: http://msdn.microsoft.com/en-us/library/system.windows.forms.openfiledialog(v=vs.110).aspx
        'File Streams: http://msdn.microsoft.com/en-us/magazine/cc163710.aspx
        Dim mapStream As Stream = Nothing
        Dim openFileDialog1 As New OpenFileDialog()
        Dim desktopDirectory As String

        desktopDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
        openFileDialog1.InitialDirectory = desktopDirectory
        openFileDialog1.Filter = "Halo 2 map files (*.map)|*.map"
        openFileDialog1.FilterIndex = 1
        openFileDialog1.RestoreDirectory = True

        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Try
                mapStream = openFileDialog1.OpenFile()
                If (mapStream IsNot Nothing) Then
                    ' Insert code to read the stream here. 
                End If
            Catch Ex As Exception
                MessageBox.Show("Cannot read file from disk. Original error: " & Ex.Message)
            Finally
                ' Check this again, since we need to make sure we didn't throw an exception on open. 
                If (mapStream IsNot Nothing) Then
                    mapStream.Close()
                End If
            End Try
        End If

    End Sub

    Public Sub CloseMapToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CloseMapToolStripMenuItem.Click

    End Sub

    Private Sub ResignMapToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ResignMapToolStripMenuItem.Click

    End Sub

    Private Sub MapInfoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MapInfoToolStripMenuItem.Click
        MapInfo.Show()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        AboutBox.Show()
    End Sub

End Class
