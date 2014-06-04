Imports System.IO

Public Class mainForm

    Dim validityResult As String
    Dim mapStream As FileStream
    Dim mapInformation As String()

    Private Sub mainForm_load(sender As Object, e As EventArgs) Handles MyBase.Load
        closeMapMenuItem.Enabled = False
        resignMapMenuItem.Enabled = False
        mapInfoMenuItem.Enabled = False
    End Sub

    'TODO: Fix the crazy stuff going on in this sub
    Public Sub openMapMenuItem_click(sender As System.Object, e As System.EventArgs) Handles openMapMenuItem.Click

        'Open File Dialogue: http://msdn.microsoft.com/en-us/library/system.windows.forms.openfiledialog(v=vs.110).aspx
        'File Streams: http://msdn.microsoft.com/en-us/library/system.io.filestream.aspx
        Dim openFileDialog1 As New OpenFileDialog()

        openFileDialog1.Filter = "Halo 2 map files (*.map)|*.map"
        openFileDialog1.FilterIndex = 1
        openFileDialog1.RestoreDirectory = True

        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Try
                mapStream = New FileStream(openFileDialog1.FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite)
                'Read the .map file

                If (mapStream IsNot Nothing) Then

                    '
                    'Check to see if the file is a valid Halo 2 .map file
                    '
                    'First, check the length of the file in bytes
                    If mapStream.Length < 10000000 Then
                        mapStream.Close()
                        System.Media.SystemSounds.Exclamation.Play()
                        MsgBox("The file you are attempting to open is not a valid Halo 2 .map file. File unloaded.")
                        toolStripStatusLabel.Text = "//Invalid file. File unloaded."
                        toolStripStatusLabel.ToolTipText = "//Invalid file. File unloaded."
                        Exit Sub
                    Else
                        'Pass header to the inspector for verification
                        Dim tempHandler As New mapHandler()
                        Dim headerLocation(4) As Byte
                        mapStream.Position = 2044
                        mapStream.Read(headerLocation, 0, 4)
                        validityResult = tempHandler.verifyMapFile(headerLocation)
                        If validityResult = "Valid" Then
                            'Do nothing
                        Else
                            mapStream.Close()
                            System.Media.SystemSounds.Exclamation.Play()
                            MsgBox("The file you are attempting to open is not a valid Halo 2 .map file. File unloaded.")
                            toolStripStatusLabel.Text = "//Invalid file. File unloaded."
                            toolStripStatusLabel.ToolTipText = "//Invalid file. File unloaded."
                            Exit Sub
                        End If
                    End If

                    'Identify and read the bytes for the map's internal name
                    Dim nameLocation(35) As Byte
                    mapStream.Position = 408
                    mapStream.Read(nameLocation, 0, 35)

                    'Create a pointer variable that enables us to read from our map "database"
                    Dim map As New mapHandler()
                    mapInformation = map.readInternalName(nameLocation)

                    If mapInformation Is Nothing Then
                        mapStream.Close()
                        MsgBox("The map you have loaded is not recognized. Please enter the correct map signature manually.")
                        applySigTextBox.Enabled = True
                        applySigTextBox.ReadOnly = False
                        Exit Sub
                    Else
                        'Do nothing
                    End If

                    '
                    'Update the UI
                    '
                    'Display what the current signature is and what it should be
                    'Finding strings in an array: http://msdn.microsoft.com/en-us/library/vstudio/eefw3xsy(v=vs.100).aspx
                    Dim queryResults As String() = map.queryMapDB(mapInformation(0))
                    Dim currentSig As String = map.readCurrentSigString(mapStream)
                    Dim actualSig As String = queryResults(3)

                    currentSigTextBox.Text = currentSig

                    For Each Str As String In queryResults
                        If Str.Contains(currentSig) Then
                            'If the current signature matches
                            applySigTextBox.Text = currentSig
                            applySigLabel.ForeColor = Color.Green
                            currentSigLabel.ForeColor = Color.Green
                        Else
                            'If the current signature does not match
                            applySigTextBox.Text = actualSig
                            applySigLabel.ForeColor = Color.Red
                            currentSigLabel.ForeColor = Color.Red
                        End If
                    Next

                    'Display the map image
                    Dim mapNameToString As String = "_" & mapInformation(0).ToString
                    Dim mapImage As Image = My.Resources.ResourceManager.GetObject(mapNameToString)
                    mapIconBox.Image = mapImage

                    'Update toolstrip status
                    Dim mapPath As String = openFileDialog1.FileName
                    If mapPath.Length > 45 Then
                        Dim mapPathShortened As String = Microsoft.VisualBasic.Right(mapPath, 45)
                        toolStripStatusLabel.Text = "..." & mapPathShortened
                        toolStripStatusLabel.ToolTipText = "..." & mapPathShortened
                    Else
                        toolStripStatusLabel.Text = mapPath
                        toolStripStatusLabel.ToolTipText = mapPath
                    End If

                    'Enable / disable button operation
                    openMapMenuItem.Enabled = False
                    closeMapMenuItem.Enabled = True
                    resignMapMenuItem.Enabled = True
                    mapInfoMenuItem.Enabled = True

                End If
            Catch Ex As Exception
                MessageBox.Show("Cannot read file from disk. Original error: " & Ex.Message)
            End Try
        End If

    End Sub

    Public Sub closeMapMenuItem_click(sender As System.Object, e As System.EventArgs) Handles closeMapMenuItem.Click

        'Clean up resources
        mapStream.Close()
        mapInformation = Nothing

        '
        'Clean up the UI
        '
        mapIconBox.Image = My.Resources.Unknown_Map
        currentSigTextBox.Text = ""
        currentSigLabel.ForeColor = Color.Black
        applySigTextBox.Text = ""
        applySigLabel.ForeColor = Color.Black
        openMapMenuItem.Enabled = True
        resignMapMenuItem.Enabled = False
        mapInfoMenuItem.Enabled = False
        closeMapMenuItem.Enabled = False
        'Tool Strip formatting: http://stackoverflow.com/questions/16189893/cut-status-strip-label-to-width-of-form
        toolStripStatusLabel.Text = "//Map unloaded."
        toolStripStatusLabel.ToolTipText = "//Map unloaded."

    End Sub

    Public Sub mapInfoMenuItem_click(sender As Object, e As EventArgs) Handles mapInfoMenuItem.Click

        'Check if the MapInfo form is already open
        If Application.OpenForms().OfType(Of mapInfoForm).Any Then
            MsgBox("The Map Information window is already open.")
        Else
            'If it is not open, pass the data from mapInformation to the form
            Dim passMe As New mapInfoForm
            passMe.updateValues(mapInformation)
            passMe.Show()
        End If

    End Sub

    'Where it resigns AKA Where it all goes wrong
    Private Sub resignMapMenuItem_click(sender As System.Object, e As System.EventArgs) Handles resignMapMenuItem.Click

        Dim tempHandler As New mapHandler
        Dim sigString As String = applySigTextBox.Text.ToString
        Dim discardedInt As Integer = 0
        Dim signatureBytes As Byte() = New Byte(3) {}
        Dim binWriter0 As New BinaryWriter(mapStream)
        Dim binWriter1 As New BinaryWriter(mapStream)
        Dim array0 As Byte() = New Byte(3) {}
        Dim array1 As Byte() = New Byte(3) {}

        'Pass 1: 
        '1) Prepare a signature for the footer of the map. This
        ' signature is based off of the map's correct signature and is
        ' then reversed.
        '2) Write the signature 
        signatureBytes = tempHandler.prepareFooterSig(sigString, discardedInt)
        array0 = tempHandler.reverseSigBytes(signatureBytes)
        binWriter0.BaseStream.Seek(mapStream.Length - 4, SeekOrigin.Begin)
        binWriter0.Write(array0)
        tempHandler.writeHeaderSig(mapStream)

        'Pass 2
        array1 = tempHandler.readCurrentSigBytes(mapStream)
        binWriter1.BaseStream.Seek(mapStream.Length - 4, SeekOrigin.Begin)
        binWriter1.Write(tempHandler.reverseSigBytes(array1))
        tempHandler.writeHeaderSig(mapStream)

        'Update the UI
        Dim currentSig As String = tempHandler.readCurrentSigString(mapStream)
        currentSigTextBox.Text = currentSig
        applySigLabel.ForeColor = Color.Green
        currentSigLabel.ForeColor = Color.Green
        System.Media.SystemSounds.Asterisk.Play()

    End Sub

    Private Sub aboutMenuItem_click(sender As Object, e As EventArgs) Handles aboutMenuItem.Click
        aboutBoxForm.Show()
    End Sub

    Private Sub mapIconBox_click(sender As System.Object, e As System.EventArgs) Handles mapIconBox.Click

        If mapStream IsNot Nothing Then
            'Check if the MapInfo form is already open
            If Application.OpenForms().OfType(Of mapInfoForm).Any Then
                MsgBox("The Map Information window is already open.")
            Else
                'If it is not open, pass the data from mapInformation to the form
                Dim passMe As New mapInfoForm
                passMe.updateValues(mapInformation)
                passMe.Show()
            End If
        End If

    End Sub

End Class
