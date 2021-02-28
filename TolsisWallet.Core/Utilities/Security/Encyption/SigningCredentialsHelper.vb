Imports Microsoft.IdentityModel.Tokens

Namespace Core.Utilities.Security.Encyption
    Public Class SigningCredentialsHelper
        Public Shared Function CreateSigningCredentials(ByVal securityKey As SecurityKey) As SigningCredentials
            Return New SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature)
        End Function
    End Class
End Namespace