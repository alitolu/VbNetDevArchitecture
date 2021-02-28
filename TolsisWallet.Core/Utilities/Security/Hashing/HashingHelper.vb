Imports System.Text
Imports System.Runtime.InteropServices
Imports System.Security

Namespace Core.Utilities.Security.Hashing
    Public Class HashingHelper
        Public Shared Sub CreatePasswordHash(ByVal password As String, <Out> ByRef passwordHash As Byte(), <Out> ByRef passwordSalt As Byte())
            Using hmac = New Cryptography.HMACSHA512()
                passwordSalt = hmac.Key
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password))
            End Using
        End Sub
        Public Shared Function VerifyPasswordHash(ByVal password As String, ByVal passwordHash As Byte(), ByVal passwordSalt As Byte()) As Boolean
            Using hmac = New Cryptography.HMACSHA512(passwordSalt)
                Dim computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password))
                For i As Integer = 0 To computedHash.Length - 1
                    If computedHash(i) <> passwordHash(i) Then
                        Return False
                    End If
                Next
            End Using
            Return True
        End Function

    End Class
End Namespace
