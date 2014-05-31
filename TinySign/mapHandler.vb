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

    'v1: Writes hash to map - Based on Darkmatter source
    Public Function rehashMap_v1(mapStream As FileStream)
        '
        'We must rehash each integer after 2048: http://codeescape.com/2009/05/optimized-c-halo-2-map-signing-algorithm/
        '
        Dim mapSize As Integer = mapStream.Length
        Dim newSize As Integer = mapSize - 2048
        Dim times As Integer = newSize / 4
        Dim result As Integer = 0
        Dim x As Integer
        Dim binary As New BinaryReader(mapStream)
        Dim writer As New BinaryWriter(mapStream)

        Dim mapData(newSize) As Byte
        mapStream.Position = 2048
        mapStream.Read(mapData, 0, newSize)

        binary.BaseStream.Seek(2048, SeekOrigin.Begin)
        Do While x < times
            x += 1
            result = result Xor binary.ReadInt32()
        Loop
        writer.BaseStream.Seek(720, SeekOrigin.Begin)
        writer.Write(result)
        'binary.Close()
        'FS.Close();
        'mapstuff.sig.Text=result.ToString("X");
        MsgBox(result)

        Return mapStream

    End Function

    'v2: Based on Entity source
    Public Function rehashMap_v2(mapStream As FileStream)
        '
        'We must rehash each integer after 2048: http://codeescape.com/2009/05/optimized-c-halo-2-map-signing-algorithm/
        'See this link for new example (Control+F "The Sign"): https://www.dropbox.com/s/2oylcf3bli29a2f/Map.cs
        '
        Dim result As Integer = 0
        Dim x As Integer = 0
        Dim binReader As New BinaryReader(mapStream)
        Dim binWriter As New BinaryWriter(mapStream)

        mapStream.Position = 2048

        binReader.BaseStream.Seek(2048, SeekOrigin.Begin)
        Const bufferSize As Integer = 16384
        Dim _buffer As Byte() = binReader.ReadBytes(bufferSize)
        Dim sizeCheck As Integer = _buffer.Length

        Do While sizeCheck = bufferSize
            If x < _buffer.Length Then
                result = result Xor BitConverter.ToInt32(_buffer, x)
                x += 4
            Else
                MsgBox("Leaving Do")
                Exit Do
            End If
        Loop

        binWriter.BaseStream.Seek(720, SeekOrigin.Begin)
        binWriter.Write(result)
        'binary.Close()
        'FS.Close();
        MsgBox(result)

        Return mapStream

    End Function

    'v3: Sean fixes my "erros" - Writes hash to map SH 5/29/14
    Public Function rehashMap(mapStream As FileStream)
        '
        'We must rehash each integer after 2048: http://codeescape.com/2009/05/optimized-c-halo-2-map-signing-algorithm/
        'See this link for new example (Control+F "The Sign"): https://www.dropbox.com/s/2oylcf3bli29a2f/Map.cs
        '
        Dim result As Integer = 0
        Dim x As Integer = 0
        Dim binReader As New BinaryReader(mapStream)
        Dim binWriter As New BinaryWriter(mapStream)

        mapStream.Position = 2048

        binReader.BaseStream.Seek(2048, SeekOrigin.Begin)
        Const bufferSize As Integer = 16384
        Dim _buffer As Byte() = binReader.ReadBytes(bufferSize)
        Dim sizeCheck As Integer = _buffer.Length

        Do While sizeCheck = bufferSize
            _buffer = binReader.ReadBytes(bufferSize)
            sizeCheck = _buffer.Length
            x = 0

            Do While x < _buffer.Length
                result = result Xor BitConverter.ToInt32(_buffer, x)
                x += 4
            Loop
        Loop

        While sizeCheck = bufferSize
            binWriter.BaseStream.Seek(mapStream.Length - 4, SeekOrigin.Begin)
            binWriter.Write(result)
        End While

        binWriter.BaseStream.Seek(mapStream.Length - 4, SeekOrigin.Begin)
        'binWriter.Write(result)
        'binary.Close()
        'FS.Close();
        MsgBox(result)

        Return mapStream

    End Function

    'Instigates voodoo magic by botting a forum post on the Interwebs whichs asks users to correct "erros" in my code
    Public Function wtfDoesThisDo(hexString As String, erros As Integer)

        'This only works with Warlock
        hexString = "E9BE57DA"
        erros = 0

        Dim text As String = ""
        Dim i As Integer = 0
        Do While i < hexString.Length()
            Dim c As Char = Convert.ToChar(hexString(i))
            If Uri.IsHexDigit(c) = True Then
                text = text + c
            Else
                erros = erros + 1
            End If
            i += 1
        Loop

        If text.Length Mod 2 <> 0 Then
            erros = erros + 1
            text = text.Substring(0, text.Length - 1)
        End If

        Dim num0 As Integer = text.Length / 2
        Dim array(num0) As Byte
        Dim num1 As Integer = 0
        Dim hex As String = ""
        Dim j As Integer = 0
        Do While j < array.Length
            hex = New String(Char({Convert.ToChar(num1), Convert.ToChar(num1 + 1)}))
            array(j) = Convert.ToByte(hex)
            j += 1
        Loop

        Return array

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

End Class