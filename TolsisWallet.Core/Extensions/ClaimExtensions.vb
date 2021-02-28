Imports System.Collections.Generic
Imports System.IdentityModel.Tokens.Jwt
Imports System.Linq
Imports System.Security.Claims
Imports System.Runtime.CompilerServices

Namespace Core.Extensions
    Public Module ClaimExtensions
        <Extension()>
        Public Sub AddEmail(ByVal claims As ICollection(Of Claim), ByVal email As String)
            claims.Add(New Claim(JwtRegisteredClaimNames.Email, email))
        End Sub
        <Extension()>
        Public Sub AddName(ByVal claims As ICollection(Of Claim), ByVal name As String)
            claims.Add(New Claim(ClaimTypes.Name, name))
        End Sub
        <Extension()>
        Public Sub AddNameIdentifier(ByVal claims As ICollection(Of Claim), ByVal nameIdentifier As String)
            claims.Add(New Claim(ClaimTypes.NameIdentifier, nameIdentifier))
        End Sub
        <Extension()>
        Public Sub AddRoles(ByVal claims As ICollection(Of Claim), ByVal roles As String())
            Enumerable.ToList(roles).ForEach(Sub(role) claims.Add(New Claim(ClaimTypes.Role, role)))
        End Sub

    End Module
End Namespace
