Imports System.IdentityModel.Tokens.Jwt
Imports System.Security.Claims
Imports Microsoft.Extensions.Configuration
Imports Microsoft.IdentityModel.Tokens
Imports TolsisWallet.Core.Core.Entities.Concrete
Imports TolsisWallet.Core.Core.Utilities.Security.Encyption
Imports TolsisWallet.Core.Core.Extensions

Namespace Core.Utilities.Security.Jwt
    Public Class JwtHelper
        Implements ITokenHelper
        Public ReadOnly Property Configuration As IConfiguration
        Private _tokenOptions As TokenOptions
        Private _accessTokenExpiration As System.DateTime
        Public Sub New(ByVal configuration As IConfiguration)
            configuration = configuration
            _tokenOptions = configuration.GetSection("TokenOptions")
        End Sub
        Public Function CreateJwtSecurityToken(ByVal tokenOptions As TokenOptions, ByVal user As User, ByVal signingCredentials As SigningCredentials, ByVal operationClaims As System.Collections.Generic.List(Of OperationClaim)) As JwtSecurityToken
            Dim jwt = New JwtSecurityToken(issuer:=tokenOptions.Issuer, audience:=tokenOptions.Audience, expires:=Me._accessTokenExpiration, notBefore:=System.DateTime.Now, claims:=Me.SetClaims(user, operationClaims), signingCredentials:=signingCredentials)
            Return jwt
        End Function
        Private Function SetClaims(ByVal user As User, ByVal operationClaims As List(Of OperationClaim)) As IEnumerable(Of Claim)
            Dim claims = New List(Of Claim)()
            claims.AddNameIdentifier(user.Id.ToString())
            claims.AddEmail(user.Email)
            claims.AddName($"{user.FirstName} {user.LastName}")
            claims.AddRoles(operationClaims.[Select](Function(c) c.Name).ToArray())
            Return claims
        End Function
        Public Function CreateToken(user As User, operationClaims As List(Of Entities.Concrete.OperationClaim)) As AccessToken Implements ITokenHelper.CreateToken
            _accessTokenExpiration = System.DateTime.Now.AddMinutes(Me._tokenOptions.AccessTokenExpiration)
            Dim securityKey = SecurityKeyHelper.CreateSecurityKey(Me._tokenOptions.SecurityKey)
            Dim signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey)
            Dim jwt = CreateJwtSecurityToken(Me._tokenOptions, user, signingCredentials, operationClaims)
            Dim jwtSecurityTokenHandler = New JwtSecurityTokenHandler()
            Dim token = jwtSecurityTokenHandler.WriteToken(jwt)
            Return New AccessToken With {
                .Token = token,
                .Expiration = Me._accessTokenExpiration
            }
        End Function
    End Class

End Namespace
