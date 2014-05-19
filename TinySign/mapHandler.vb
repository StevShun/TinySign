Imports System.IO
Imports System.Reflection

Public Class mapHandler

    'Converts byte array to a string
    Public Function readInternalName(array As Byte())
        Dim charArray(20) As Char

        'Put the byte array into a char array
        Dim index As Integer = 0
        Do Until index = 19
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

            Dim stringArrayContents As String = String.Join(",", stringArray)
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

        'adds hex values into a single string
        Dim temp As String
        Dim index = 0
        Do Until index = 4
            temp = Hex(mapSignatureBytes(index))

            'if the hex value is <= F then add a zero infront to preserve form
            If (temp.Length = 1) Then
                temp = "0" + temp
            End If
            mapCurrentSignatureString = mapCurrentSignatureString + temp
            index += 1
        Loop

        Return mapCurrentSignatureString

    End Function

End Class