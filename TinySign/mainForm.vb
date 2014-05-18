Imports System.IO

Public Class mainForm
    Dim mapInformation As String()

    Private Sub MainWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub OpenMapToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles openMapToolStripMenuItem.Click

        'Open File Dialogue: http://msdn.microsoft.com/en-us/library/system.windows.forms.openfiledialog(v=vs.110).aspx
        'File Streams: http://msdn.microsoft.com/en-us/library/system.io.filestream.aspx
        Dim mapStream As FileStream = Nothing
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
                'Read the .map file

                If (mapStream IsNot Nothing) Then
                    If mapStream.CanRead Then

                        'Gets the original bytes
                        'Decimal positions:
                        '408 = internal name, 444 = scenario path, 720 = signature addr
                        Dim nameLocation(20) As Byte
                        mapStream.Position = 408
                        mapStream.Read(nameLocation, 0, 20)

                        'Give me those bytes that need to be changed!!
                        Dim map As New mapHandler()
                        mapInformation = map.findInternalName(nameLocation)

                        'Displays current signature of map
                        currentSigTextBox.Text = map.getCurrentSig(mapStream)

                        'Displays image of map
                        Dim mapImage As Image = My.Resources.ResourceManager.GetObject(mapInformation(0))
                        mapIconBox.Image = mapImage

                        'mapStream write the bytes that we changed

                    End If
                    'Insert code to read the stream here. 
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

    'TODO actually close the map
    Public Sub CloseMapToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles closeMapToolStripMenuItem.Click
        mapIconBox.Image = My.Resources.Unknown_Map
        currentSigTextBox.Text = ""
        applySigTextBox.Text = ""
    End Sub

    Private Sub ResignMapToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles resignMapToolStripMenuItem.Click

    End Sub

    Private Sub MapInfoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mapInfoToolStripMenuItem.Click
        Dim mapInfoBox As New mapInfoForm
        mapInfoBox.updateValues(mapInformation)
        mapInfoForm.Show()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles aboutToolStripMenuItem.Click
        aboutBoxForm.Show()
    End Sub

End Class
