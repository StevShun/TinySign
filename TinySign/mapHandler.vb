Imports System.IO
Imports System.Reflection
Imports System.Text

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

            If String.Compare(queryItem, stringArray(0)) = 0 Then
                Return stringArray
            Else
                Return Nothing
            End If

            'Dim stringArrayContents As String = String.Join(",", stringArray)
            'MsgBox("This is the first stringArrayContents from mapQuery:" & " " & stringArrayContents)

        Catch ex As Exception
            MessageBox.Show("Resource wasn't found!", "Error")
        End Try
        Return "Something Bad Happened, lol."

    End Function

    '@Return hex value in a string of the map's signature
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

    Public Function readCurrentSig_v2(mapStream As FileStream)
        Dim array As Byte() = New Byte(3) {}
        Dim binReader As New BinaryReader(mapStream)

        mapStream.Seek(720, 0)
        binReader.Read(array, 0, 4)

        Return reverseSig(array)

    End Function

    Public Function readCurrentScenPath(array As Byte())
        Dim charArray(64) As Char

        'Put the byte array into a char array
        Dim index As Integer = 0
        Do Until index = 64
            If array(index) = 0 Then Exit Do
            charArray(index) = Convert.ToChar(array(index))
            index += 1
        Loop

        'Process char array into a string
        Dim mapScenarioPath As New String(charArray)
        'MsgBox("The map name is:" & " " & mapName)

        Return mapScenarioPath

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
    Public Function rehashMap_v3(mapStream As FileStream)
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
            binWriter.BaseStream.Seek(720, SeekOrigin.Begin)
            binWriter.Write(result)
        End While

        binWriter.BaseStream.Seek(720, SeekOrigin.Begin)
        'binWriter.Write(result)
        'binary.Close()
        'FS.Close();
        MsgBox(result)

        Return mapStream

    End Function

    'v4: I gave up and used this: http://converter.telerik.com/
    Public Function writeHeaderSig(mapStream As FileStream)

        Dim binReader As New BinaryReader(mapStream)
        Dim binWriter As New BinaryWriter(mapStream)

        Dim result As Integer = 0
        binReader.BaseStream.Seek(2048, SeekOrigin.Begin)
        Const bufferSize As Integer = 16384
        Dim sizeCheck As Integer
        Do
            Dim buffer As Byte() = binReader.ReadBytes(bufferSize)
            sizeCheck = buffer.Length
            For x As Integer = 0 To buffer.Length - 1 Step 4
                result = result Xor BitConverter.ToInt32(buffer, x)
            Next
        Loop While sizeCheck = bufferSize

        MsgBox(result)

        binWriter.BaseStream.Seek(720, SeekOrigin.Begin)
        binWriter.Write(result)

    End Function

    'Instigates voodoo magic by botting a forum post on the Interwebs whichs asks users to correct "erros" in my code
    Public Function prepareFooterSig(sigString As String, discardedInt As Integer)

        discardedInt = 0

        Dim text As String = ""
        Dim hexIndex As Integer = 0
        Do While hexIndex < sigString.Length()
            Dim c As Char = Char.Parse(sigString(hexIndex))
            If Uri.IsHexDigit(c) = True Then
                text = text + c
            Else
                discardedInt = discardedInt + 1
            End If
            hexIndex += 1
        Loop

        'MsgBox("Text is " & text & " Text length is: " & text.Length)

        If text.Length Mod 2 <> 0 Then
            discardedInt = discardedInt + 1
            text = text.Substring(0, text.Length - 1)
        End If

        'MsgBox("Text is now " & text & " Text length is: " & text.Length)

        Dim arrayLength As Integer = text.Length / 2
        'MsgBox("arrayLength is: " & arrayLength)
        'Dim array(arrayLength - 1) As Byte
        Dim array As Byte() = New Byte(arrayLength - 1) {}
        'MsgBox("Array is now this long: " & Array.Length)
        Dim charPosition As Integer = 0
        Dim hex As String
        Dim arrayIndex As Integer = 0
        Do While arrayIndex < array.Length
            hex = New String(New Char() {Char.Parse(text(charPosition)), Char.Parse(text(charPosition + 1))})
            array(arrayIndex) = Byte.Parse(hex, 515)
            charPosition = charPosition + 2
            'MsgBox("hex is: " & hex & " @ index position: " & arrayIndex & " array length is: " & array.Length)
            arrayIndex += 1
        Loop

        'MsgBox("arrayLength is: " & array.Length)

        Return array

    End Function

    'Now unused
    Public Function isHexDigit(c As Char)

        'Constants and literals: http://msdn.microsoft.com/en-us/library/dzy06xhf.aspx
        Dim num0 As Integer = Convert.ToInt32("A"c)
        Dim num1 As Integer = Convert.ToInt32("0"c)
        c = Char.ToUpper(c)
        Dim num2 As Integer = Convert.ToInt32(c)

        'VB.net operators: http://www.tutorialspoint.com/vb.net/vb.net_operators.htm
        Return (num2 >= num0 AndAlso num2 < num0 + 6) OrElse (num2 >= num1 AndAlso num2 < num1 + 10)

    End Function

    Public Function reverseSig(signature() As Byte)

        Dim reverseSigBytes As Byte() = New Byte(3) {}
        'MsgBox("Reverse sig is: " & reverseSig.Length)
        Dim index As Integer = 0
        Do While index < 4
            reverseSigBytes(index) = signature(3 - index)
            index += 1
        Loop

        'MsgBox("Reverse sig now: " & reverseSig.Length)

        Return reverseSigBytes

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