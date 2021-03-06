﻿Imports System.IO
Imports System.Reflection
Imports System.Text

Public Class mapHandler

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    'This class provides the program with a toolbox to              '
    ' parse Halo 2 map files.                                       '
    'Decimal positions for relevant map information:                '
    ' 408 = internal name, 444 = scenario path, 720 = signature addr'
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    '@Return a value determining if file is a Halo 2 .map in a string.
    'Test the file's size and look for a Halo 2 map header to 
    ' make sure that the file is a valid Halo 2 map file.
    Public Function verifyMapFile(mapStream As FileStream)

        'Check the file's size (@ 9.5 MB). 
        'Maps are generally greater than 20 MB
        If mapStream.Length < 10000000 Then
            Return "invalid"
            Exit Function
        Else
            'Do nothing
        End If

        'Read the header found @ 2044
        Dim mapHeaderBytes(3) As Byte
        mapStream.Position = 2044
        mapStream.Read(mapHeaderBytes, 0, 4)

        Dim charArray(3) As Char
        Dim index As Integer = 0
        Do Until index = 4
            If mapHeaderBytes(index) = 0 Then Exit Do
            charArray(index) = Convert.ToChar(mapHeaderBytes(index))
            index += 1
        Loop
        Dim mapHeaderArray As New String(charArray)

        'Determine if the header is valid.
        'Halo 2 map file headers always begin with the string "toof".
        If mapHeaderArray = "toof" Then
            Return "valid"
        Else
            Return "invalid"
        End If

    End Function

    '@Return an array containing data relevant to the loaded map.
    'Compares passed items from loaded map to map database text file (MapDB).
    Public Function queryMapDB(queryItem As String)

        Dim _textStreamReader As StreamReader
        Dim _assembly As [Assembly]
        Dim line As String
        Dim queryResultArray As String()

        Try
            'Embedded resources http://support.microsoft.com/kb/319291
            _assembly = [Assembly].GetExecutingAssembly()
            _textStreamReader = New StreamReader(_assembly.GetManifestResourceStream("TinySign.mapDB.txt"))

            'Reads in line and checks to see if map name matches
            Dim index As Integer = 0
            line = _textStreamReader.ReadLine()
            queryResultArray = Split(line, ",")

            'String compare http://msdn.microsoft.com/en-us/library/fbh501kz(v=vs.110).aspx
            While (String.Compare(queryItem, queryResultArray(0)) <> 0)
                line = _textStreamReader.ReadLine()
                queryResultArray = Split(line, ",")
                If index = 43 Then
                    queryResultArray = Nothing
                    Exit While
                Else
                    'Do nothing
                End If
                index += 1
            End While

            'Dim stringArrayContents As String = String.Join(",", stringArray)
            'MsgBox("This is the first stringArrayContents from mapQuery:" & " " & stringArrayContents)

            If queryResultArray Is Nothing Then
                Return Nothing
            Else
                Return queryResultArray
            End If

        Catch ex As Exception
            MessageBox.Show("MapDB resource could not be accessed!", "Error")
        End Try
        Return "Something Bad Happened, lol."

    End Function

    '@Return the map's internal name in a string.
    Public Function readInternalName(mapStream As FileStream)

        Dim mapNameBytes(35) As Byte
        mapStream.Position = 408
        mapStream.Read(mapNameBytes, 0, 36)

        Dim charArray(35) As Char
        'Put the byte array into a char array
        Dim index As Integer = 0
        Do Until index = 36
            If mapNameBytes(index) = 0 Then Exit Do
            charArray(index) = Convert.ToChar(mapNameBytes(index))
            index += 1
        Loop
        Dim mapNameString As New String(charArray)

        'MsgBox("The map name is:" & " " & mapNameString & " grrw3")

        Return mapNameString

    End Function

    '@Return the map's current scenario path in a string.
    Public Function readScenarioPath(mapStream As FileStream)

        Dim mapScenarioBytes(63) As Byte
        mapStream.Position = 444
        mapStream.Read(mapScenarioBytes, 0, 64)

        Dim charArray(63) As Char

        'Put the byte array into a char array
        Dim index As Integer = 0
        Do Until index = 64
            If mapScenarioBytes(index) = 0 Then Exit Do
            charArray(index) = Convert.ToChar(mapScenarioBytes(index))
            index += 1
        Loop
        Dim mapScenarioPathString As New String(charArray)

        Return mapScenarioPathString

    End Function

    '@Return hex value in a string of the map's signature.
    Public Function readCurrentSigString(mapStream As FileStream)

        Dim mapSignatureBytes(3) As Byte
        mapStream.Position() = 720
        mapStream.Read(mapSignatureBytes, 0, 4)
        Dim mapCurrentSignatureString As String = ""

        Dim reverseSig As Byte() = reverseSigBytes(mapSignatureBytes)

        'Adds hex values into a single string
        Dim temp As String
        Dim index = 0
        Do Until index = 4
            temp = Hex(reverseSig(index))

            'If the hex value is <= F then add a zero infront to preserve form
            If (temp.Length = 1) Then
                temp = "0" + temp
            End If
            mapCurrentSignatureString = mapCurrentSignatureString + temp
            index += 1
        Loop

        Return mapCurrentSignatureString

    End Function

    '@Return the map's current signature in bytes.
    Public Function readCurrentSigBytes(mapStream As FileStream)

        Dim sigByteArray As Byte() = New Byte(3) {}
        Dim binReader As New BinaryReader(mapStream)

        mapStream.Seek(720, 0)
        binReader.Read(sigByteArray, 0, 4)

        Return reverseSigBytes(sigByteArray)

    End Function

    '@Return reversed four bytes containing the map's signature.
    'Based on code from Coolspot31's map resigner.
    Public Function reverseSigBytes(signature() As Byte)

        Dim reverseSigBytesArray As Byte() = New Byte(3) {}
        Dim index As Integer = 0

        Do While index < 4
            reverseSigBytesArray(index) = signature(3 - index)
            index += 1
        Loop

        Return reverseSigBytesArray

    End Function

    'XORs through the map header starting @ 2048 and write the result to @ 720.
    'v4: Based on Entity source code.
    '(I gave up and used this to translate it from C#: http://converter.telerik.com/)
    Public Function genHeaderSig(mapStream As FileStream)

        Dim binReader As New BinaryReader(mapStream)

        binReader.BaseStream.Seek(2048, SeekOrigin.Begin)
        Const bufferSize As Integer = 16384
        Dim sizeCheck As Integer
        Dim xorResult As Integer = 0

        Do
            Dim buffer As Byte() = binReader.ReadBytes(bufferSize)
            sizeCheck = buffer.Length
            For x As Integer = 0 To buffer.Length - 1 Step 4
                xorResult = xorResult Xor BitConverter.ToInt32(buffer, x)
            Next
        Loop While sizeCheck = bufferSize

        Return xorResult

    End Function

    '@Return signature to be written to map file footer in an array of bytes.
    'Instigates voodoo magic by botting a forum post on the Interwebs whichs asks users to correct "erros" in my code.
    'Based on code from Coolspot31's map resigner.
    Public Function genFooterSig(sigString As String, discardedInt As Integer)

        discardedInt = 0

        Dim sigStringText As String = ""
        Dim hexIndex As Integer = 0
        Do While hexIndex < sigString.Length()
            Dim c As Char = Char.Parse(sigString(hexIndex))
            If Uri.IsHexDigit(c) = True Then
                sigStringText = sigStringText + c
            Else
                discardedInt = discardedInt + 1
            End If
            hexIndex += 1
        Loop

        'MsgBox("Text is " & text & " Text length is: " & text.Length)

        If sigStringText.Length Mod 2 <> 0 Then
            discardedInt = discardedInt + 1
            sigStringText = sigStringText.Substring(0, sigStringText.Length - 1)
        End If

        'MsgBox("Text is now " & text & " Text length is: " & text.Length)

        Dim arrayLength As Integer = sigStringText.Length / 2
        Dim signatureByteArray As Byte() = New Byte(arrayLength - 1) {}
        Dim charPosition As Integer = 0
        Dim hexString As String
        Dim arrayIndex As Integer = 0

        Do While arrayIndex < signatureByteArray.Length
            hexString = New String(New Char() {Char.Parse(sigStringText(charPosition)), Char.Parse(sigStringText(charPosition + 1))})
            signatureByteArray(arrayIndex) = Byte.Parse(hexString, 515)
            charPosition = charPosition + 2
            arrayIndex += 1
        Loop

        'MsgBox("arrayLength is: " & array.Length)

        Return signatureByteArray

    End Function

    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    'See below for erros (AKA, old code).'''''''''''''''''''''''''''''''''''''''''''
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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

    'Now unused - Determines whether is a char is a hex digit or not
    Public Function isHexDigit(c As Char)

        'Constants and literals: http://msdn.microsoft.com/en-us/library/dzy06xhf.aspx
        Dim num0 As Integer = Convert.ToInt32("A"c)
        Dim num1 As Integer = Convert.ToInt32("0"c)
        c = Char.ToUpper(c)
        Dim num2 As Integer = Convert.ToInt32(c)

        'VB.net operators: http://www.tutorialspoint.com/vb.net/vb.net_operators.htm
        Return (num2 >= num0 AndAlso num2 < num0 + 6) OrElse (num2 >= num1 AndAlso num2 < num1 + 10)

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