
Imports System.Text
Imports System.Web
Imports System.Web.Security

Namespace Utilities.Security.Web

    Public Class AuthenticationHelper
        Public Shared Sub CreateAuthCookie(ByVal id As Guid,
                                           ByVal userName As String,
                                           ByVal email As String,
                                           ByVal expiration As Date,
                                           ByVal roles As String(),
                                           ByVal rememberMe As Boolean,
                                           ByVal firstName As String,
                                           ByVal lastName As String)
            Dim authTicket = New FormsAuthenticationTicket(1, userName, Date.Now, expiration, rememberMe, CreateAuthTags(email, roles, firstName, lastName, id))
            Dim encTicket As String = FormsAuthentication.Encrypt(authTicket)
            HttpContext.Current.Response.Cookies.Add(New HttpCookie(FormsAuthentication.FormsCookieName, encTicket))
        End Sub
        Private Shared Function CreateAuthTags(ByVal email As String, ByVal roles As String(), ByVal firstName As String, ByVal lastName As String, ByVal id As Guid) As String
            Dim stringBuilder = New StringBuilder()
            stringBuilder.Append(email)
            stringBuilder.Append("|")

            For i As Integer = 0 To roles.Length - 1
                stringBuilder.Append(roles(i))

                If i < roles.Length - 1 Then
                    stringBuilder.Append(",")
                End If
            Next

            stringBuilder.Append("|")
            stringBuilder.Append(firstName)
            stringBuilder.Append("|")
            stringBuilder.Append(lastName)
            stringBuilder.Append("|")
            stringBuilder.Append(id)
            Return stringBuilder.ToString()
        End Function

    End Class

End Namespace
