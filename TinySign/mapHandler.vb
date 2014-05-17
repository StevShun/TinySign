Imports System.IO

Public Class mapHandler

    Public Sub arrayToString(array As Byte())
        Dim charArray(20) As Char

        Dim index As Integer = 0
        Do
            MsgBox(array(index))
            index += 1
        Loop

        'create charArray(20) to a string that we can use to match against the excel file... 
    End Sub


End Class
