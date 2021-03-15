Imports System.Text
Imports Microsoft.IdentityModel.Tokens

Namespace Utilities.Security.Encyption
    Public Class SecurityKeyHelper
        Public Shared Function CreateSecurityKey(ByVal securityKey As String) As SecurityKey
            Return New SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey))
        End Function

    End Class
End Namespace