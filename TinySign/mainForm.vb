Imports System.IO

Public Class mainForm

    Dim mapStream As FileStream
    Dim mapInternalName As String
    Dim mapInformation As String()
    Dim mapScenarioPath As String
    Dim mapCurrentSig As String

    Private Sub mainForm_load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Setup the UI
        closeMapMenuItem.Enabled = False
        resignMapMenuItem.Enabled = False
        mapInfoMenuItem.Enabled = False
    End Sub

    Public Sub openMapMenuItem_click(sender As System.Object, e As System.EventArgs) Handles openMapMenuItem.Click

        'Open File Dialogue: http://msdn.microsoft.com/en-us/library/system.windows.forms.openfiledialog(v=vs.110).aspx
        'File Streams: http://msdn.microsoft.com/en-us/library/system.io.filestream.aspx
        mapStream = Nothing
        Dim openFileDialog1 As New OpenFileDialog()

        openFileDialog1.Filter = "Halo 2 map files (*.map)|*.map"
        openFileDialog1.FilterIndex = 1
        openFileDialog1.RestoreDirectory = True

        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Try
                mapStream = New FileStream(openFileDialog1.FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite)
                'Read the .map file

                If (mapStream IsNot Nothing) Then

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'Check to see if the file is a valid Halo 2 .map file'
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'Pass the file stream to the verifyMapFile function
                    Dim tempHandler As New mapHandler()
                    Dim validityResult As String = tempHandler.verifyMapFile(mapStream)
                    If validityResult = "valid" Then
                        'Do nothing
                    Else
                        'Close the file stream and inform the user
                        mapStream.Close()
                        mapStream = Nothing
                        validityResult = Nothing
                        mapInformation = Nothing
                        MsgBox("The file you are attempting to open is not a valid Halo 2 .map file." & vbNewLine & vbNewLine & "File unloaded.", vbExclamation, "Invalid File")
                        toolStripStatusLabel.Text = "//Invalid file. File unloaded."
                        toolStripStatusLabel.ToolTipText = "//Invalid file. File unloaded."
                        Exit Sub
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''
                    'Gather initial information about the map'
                    ''''''''''''''''''''''''''''''''''''''''''
                    Dim map As New mapHandler()
                    mapInternalName = map.readInternalName(mapStream)
                    mapInformation = map.queryMapDB(mapInternalName)
                    mapScenarioPath = map.readScenarioPath(mapStream)
                    mapCurrentSig = map.readCurrentSigString(mapStream)

                    '''''''''''''''
                    'Update the UI'
                    '''''''''''''''
                    'Display what the current signature is and what it should be
                    'Finding strings in an array: http://msdn.microsoft.com/en-us/library/vstudio/eefw3xsy(v=vs.100).aspx
                    'Check if the map is recognized
                    If mapInformation Is Nothing Then
                        currentSigTextBox.Text = mapCurrentSig
                        currentSigLabel.ForeColor = Color.Red
                        applySigLabel.ForeColor = Color.Red
                    Else
                        Dim queryResults As String() = map.queryMapDB(mapInformation(0))
                        Dim applySig As String = queryResults(3)

                        currentSigTextBox.Text = mapCurrentSig

                        For Each Str As String In queryResults
                            If Str.Contains(mapCurrentSig) Then
                                'If the current signature matches
                                applySigTextBox.Text = mapCurrentSig
                                applySigLabel.ForeColor = Color.Green
                                currentSigLabel.ForeColor = Color.Green
                                Exit For
                            Else
                                'If the current signature does not match
                                applySigTextBox.Text = applySig
                                applySigLabel.ForeColor = Color.Red
                                currentSigLabel.ForeColor = Color.Red
                            End If
                        Next
                    End If

                    'Display the map image
                    If mapInformation Is Nothing Then
                        'Leave icon box alone
                    Else
                        Dim mapNameToString As String = "_" & mapInformation(0).ToString
                        Dim mapImage As Image = My.Resources.ResourceManager.GetObject(mapNameToString)
                        mapIconBox.Image = mapImage
                    End If

                    'Update toolstrip status
                    Dim mapFilePath As String = openFileDialog1.FileName
                    If mapFilePath.Length > 45 Then
                        Dim mapFilePathShortened As String = Microsoft.VisualBasic.Right(mapFilePath, 45)
                        toolStripStatusLabel.Text = "..." & mapFilePathShortened
                        toolStripStatusLabel.ToolTipText = "..." & mapFilePathShortened
                    Else
                        toolStripStatusLabel.Text = mapFilePath
                        toolStripStatusLabel.ToolTipText = mapFilePath
                    End If

                    'Enable / disable button operation
                    openMapMenuItem.Enabled = False
                    closeMapMenuItem.Enabled = True
                    resignMapMenuItem.Enabled = True
                    mapInfoMenuItem.Enabled = True

                    'Check if the map name is recognized
                    If mapInformation Is Nothing Then
                        applySigTextBox.Enabled = True
                        applySigTextBox.ReadOnly = False
                        System.Media.SystemSounds.Beep.Play()
                        MsgBox("The map you have loaded is not recognized." & vbNewLine & vbNewLine & "Please enter the correct map signature manually.", MsgBoxStyle.Information, "Unknown Map")
                    Else
                        'Do nothing
                    End If

                End If
            Catch Ex As Exception
                MessageBox.Show("Cannot read file from disk. Original error: " & Ex.Message)
            End Try
        End If

    End Sub

    Public Sub closeMapMenuItem_click(sender As System.Object, e As System.EventArgs) Handles closeMapMenuItem.Click

        'Clean up global resources
        mapStream.Close()
        mapStream = Nothing
        mapInformation = Nothing
        mapInternalName = Nothing
        mapInformation = Nothing
        mapScenarioPath = Nothing
        mapCurrentSig = Nothing

        'Clean up the UI
        mapIconBox.Image = My.Resources.Unknown_Map
        currentSigTextBox.Text = ""
        currentSigLabel.ForeColor = Color.Black
        applySigTextBox.Text = ""
        applySigLabel.ForeColor = Color.Black
        applySigTextBox.ReadOnly = True
        applySigTextBox.Enabled = False
        openMapMenuItem.Enabled = True
        resignMapMenuItem.Enabled = False
        mapInfoMenuItem.Enabled = False
        closeMapMenuItem.Enabled = False
        'Tool Strip formatting: http://stackoverflow.com/questions/16189893/cut-status-strip-label-to-width-of-form
        toolStripStatusLabel.Text = "//Map unloaded."
        toolStripStatusLabel.ToolTipText = "//Map unloaded."

    End Sub

    Public Sub mapInfoForm_open(sender As Object, e As EventArgs) Handles mapInfoMenuItem.Click, mapIconBox.Click

        If mapStream IsNot Nothing Then
            'Check if the MapInfo form is already open
            If Application.OpenForms().OfType(Of mapInfoForm).Any Then
                mapInfoForm.Activate()
            Else
                'If it is not open, pass the data from mapInformation to the form
                mapInfoForm.updateValues(mapInformation, mapInternalName, mapScenarioPath, mapCurrentSig)
                mapInfoForm.Show()
            End If
        End If

    End Sub

    'Where it resigns AKA Where it all goes wrong
    Private Sub resignMapMenuItem_click(sender As System.Object, e As System.EventArgs) Handles resignMapMenuItem.Click

        If Uri.IsHexDigit(applySigTextBox.Text) And applySigTextBox.Text.Length = 8 Then
            'Do nothing
        Else
            System.Media.SystemSounds.Exclamation.Play()
            MsgBox("Custom map signatures must be eight characters long and consist of valid hexadecimal digits." _
                   & vbNewLine & vbNewLine & "Please re-enter a valid map signature.", vbExclamation, "Invalid Signature")
            Exit Sub
        End If

        Dim tempHandler As New mapHandler
        Dim applySigString As String = applySigTextBox.Text.ToString
        Dim discardedInt As Integer = 0
        Dim signatureBytes As Byte() = New Byte(3) {}
        Dim binWriter0 As New BinaryWriter(mapStream)
        Dim binWriter1 As New BinaryWriter(mapStream)
        Dim array0 As Byte() = New Byte(3) {}
        Dim array1 As Byte() = New Byte(3) {}

        '[Pass 1]: 
        'S1) Prepare a signature for the footer of the map. This
        ' signature is based off of the map's correct signature and is
        ' then reversed.
        'S2) Write the signature to the last 4 bytes of the .map file.
        'S3) Create and write a signature to the map header (@720). This
        ' signature is based on the results of XORing through the map's 
        ' header starting @2048.
        signatureBytes = tempHandler.prepareFooterSig(applySigString, discardedInt)
        array0 = tempHandler.reverseSigBytes(signatureBytes)
        binWriter0.BaseStream.Seek(mapStream.Length - 4, SeekOrigin.Begin)
        binWriter0.Write(array0)
        tempHandler.writeHeaderSig(mapStream)

        '[Pass 2]:
        array1 = tempHandler.readCurrentSigBytes(mapStream)
        binWriter1.BaseStream.Seek(mapStream.Length - 4, SeekOrigin.Begin)
        binWriter1.Write(tempHandler.reverseSigBytes(array1))
        tempHandler.writeHeaderSig(mapStream)

        'Update the UI
        mapCurrentSig = tempHandler.readCurrentSigString(mapStream)
        currentSigTextBox.Text = mapCurrentSig
        applySigLabel.ForeColor = Color.Green
        currentSigLabel.ForeColor = Color.Green
        System.Media.SystemSounds.Asterisk.Play()

    End Sub

    Private Sub aboutMenuItem_click(sender As Object, e As EventArgs) Handles aboutMenuItem.Click
        aboutBoxForm.Show()
    End Sub

End Class
