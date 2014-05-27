Imports System.IO
Imports System.Reflection

Public Class mapHandler

    'Decimal positions for relevant map information:
    '408 = internal name, 444 = scenario path, 720 = signature addr

    'Given a file and a start location/end location, return a string of the contents
    Public Function byteReader(startByte As Integer, endByte As Integer, mapStream As FileStream)
        Dim dataLength As Integer = (endByte - startByte)
        mapStream.Position = startByte

        'Creates a string of Bytes
        Dim byteStream(dataLength) As Byte
        mapStream.Read(byteStream, 0, dataLength)

        'Return a string of Bytes
        Return byteStream

    End Function

    'Test the file's header to make sure it is a valid Halo 2 map file
    Public Function verifyMapFile(array As Byte())
        Dim charArray(4) As Char

        Dim index As Integer = 0
        Do Until index = 4
            If array(index) = 0 Then Exit Do
            charArray(index) = Convert.ToChar(array(index))
            index += 1
        Loop

        Dim mapHeaderArray As New String(charArray)
        Dim mapHeader As String = mapHeaderArray(0).ToString & mapHeaderArray(1).ToString & mapHeaderArray(2).ToString & mapHeaderArray(3).ToString

        If mapHeader = "toof" Then
            Return "Valid"
        Else
            Return "Invalid"
        End If

    End Function

    'Converts byte array to a string
    Public Function readInternalName(array As Byte())
        Dim charArray(35) As Char

        'Put the byte array into a char array
        Dim index As Integer = 0
        Do Until index = 35
            If array(index) = 0 Then Exit Do
            charArray(index) = Convert.ToChar(array(index))
            index += 1
        Loop

        'Process char array into a string
        Dim mapName As New String(charArray)
        'MsgBox("The map name is:" & " " & mapName)
        Return queryMapList(Trim(mapName))

    End Function

    'Compares map name from file to map list in Resources folder
    Public Function queryMapList(queryItem As String)
        Dim _textStreamReader As StreamReader
        Dim _assembly As [Assembly]
        Dim line As String
        Dim stringArray As String()

        Try
            'Embedded resources http://support.microsoft.com/kb/319291
            _assembly = [Assembly].GetExecutingAssembly()
            _textStreamReader = New StreamReader(_assembly.GetManifestResourceStream("TinySign.mapList.txt"))

            'Reads in line and checks to see if map name matches
            Dim index = 0
            line = _textStreamReader.ReadLine()
            stringArray = Split(line, ",")

            'String compare http://msdn.microsoft.com/en-us/library/fbh501kz(v=vs.110).aspx
            While (String.Compare(queryItem, stringArray(0)) <> 0)
                line = _textStreamReader.ReadLine()
                stringArray = Split(line, ",")
                index += 1
            End While

            'Dim stringArrayContents As String = String.Join(",", stringArray)
            'MsgBox("This is the first stringArrayContents from mapQuery:" & " " & stringArrayContents)
            Return stringArray

        Catch ex As Exception
            MessageBox.Show("Resource wasn't found!", "Error")
        End Try
        Return "Something Bad Happened, lol."

    End Function

    '@Return hex value in a string of the maps signature
    Public Function readCurrentSig(mapStream As FileStream)
        Dim mapSignatureBytes(4) As Byte
        mapStream.Position() = 720
        mapStream.Read(mapSignatureBytes, 0, 4)
        Dim mapCurrentSignatureString As String = ""

        'Adds hex values into a single string
        Dim temp As String
        Dim index = 0
        Do Until index = 4
            temp = Hex(mapSignatureBytes(index))

            'If the hex value is <= F then add a zero infront to preserve form
            If (temp.Length = 1) Then
                temp = "0" + temp
            End If
            mapCurrentSignatureString = mapCurrentSignatureString + temp
            index += 1
        Loop

        Return mapCurrentSignatureString
    End Function

    Public Function readCurrentScenPath(mapStream As FileStream)

    End Function

    'Prepare new signature by converting string to bytes
    Public Function byteConverter(sigToApply As String)
        Dim byteStream(4) As Byte
        Dim hexStream(4) As String
        Dim tempString As String = ""
        Dim index As Integer = 0
        Dim count As Integer = 0

        'Fills an array with hex values
        Do While index < 8
            tempString = tempString + sigToApply.Chars(index)
            If ((index Mod 2) = 1) Then
                hexStream(count) = CLng("&H" & tempString)
                tempString = ""
                count += 1
            End If
            index += 1
        Loop

        index = 0
        Do While index < 4
            byteStream(index) = hexStream(index)
            index += 1
        Loop

        'Return a string of Bytes
        Return byteStream

    End Function

    Public Function rehashMap(mapStream As FileStream)

        '
        'We must rehash each integer after 2048. I'll explain later: http://codeescape.com/2009/05/optimized-c-halo-2-map-signing-algorithm/
        '

        Dim mapSize As Integer = mapStream.Length
        Dim newSize As Integer = mapSize - 2048
        Dim times As Integer = newSize / 4
        Dim result As Integer = 0
        Dim x As Integer

        Dim mapData(newSize) As Byte
        mapStream.Position = 2048
        mapStream.Read(mapData, 0, newSize)

        Do While x = 0
            If x < times Then
                x += 1
                'WIP
            End If
        Loop

        Return "lolcats" 'think this is supposed to be result

    End Function

End Class