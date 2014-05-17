Imports System.IO

Public Class mapHandler

    Public Sub arrayToString(array As Byte())
        Dim charArray(20) As Char

        'put the byte array into a char array
        Dim index As Integer = 0
        Do Until index >= 19
            If array(index) = 0 Then Exit Do
            charArray(index) = Convert.ToChar(array(index))
            index += 1
        Loop

        'make char array into a string
        Dim mapName As New String(charArray)
        MsgBox(mapName)

    End Sub


End Class