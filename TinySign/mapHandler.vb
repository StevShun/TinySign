Imports System.IO
Imports System.Reflection

Public Class mapHandler

    'Converts byte array to a string
    Public Sub findBytes(array As Byte())
        Dim charArray(20) As Char

        'put the byte array into a char array
        Dim index As Integer = 0
        Do Until index = 19
            If array(index) = 0 Then Exit Do
            charArray(index) = Convert.ToChar(array(index))
            index += 1
        Loop

        'make char array into a string
        Dim mapName As New String(charArray)
        compareToName(mapName)

    End Sub

    'Compares map name from file to excel map 
    Private Sub compareToName(name As String)
        Dim _textStreamReader As StreamReader
        Dim _assembly As [Assembly]
        Dim line As String

        Try
            'Embedded resources http://support.microsoft.com/kb/319291
            _assembly = [Assembly].GetExecutingAssembly()
            _textStreamReader = New StreamReader(_assembly.GetManifestResourceStream("TinySign.mapList.txt"))
            line = _textStreamReader.ReadLine()


        Catch ex As Exception
            MessageBox.Show("Resource wasn't found!", "Error")
        End Try

    End Sub


End Class