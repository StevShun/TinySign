﻿Imports System.IO
Imports System.Reflection

Public Class mapHandler

    'Converts byte array to a string
    Public Function findBytes(array As Byte())
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
        Return compareToName(Trim(mapName))

    End Function

    'Compares map name from file to excel map 
    Private Function compareToName(name As String)
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

            'string compare link http://msdn.microsoft.com/en-us/library/fbh501kz(v=vs.110).aspx
            While (String.Compare(name, stringArray(0)) <> 0)
                line = _textStreamReader.ReadLine()
                stringArray = Split(line, ",")
                index += 1
            End While

            Return stringArray

        Catch ex As Exception
            MessageBox.Show("Resource wasn't found!", "Error")
        End Try

    End Function


End Class