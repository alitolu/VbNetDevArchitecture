Imports System
Imports System.Collections.Generic
Imports System.Text
Imports TolsisWallet.Business.Business.Abstract
Imports TolsisWallet.Business.Business.Constants
Imports TolsisWallet.Core.Core.Utilities.Results
Imports TolsisWallet.Core.Core.Utilities.Security.Hashing
Imports TolsisWallet.Core.Core.Utilities.Security.Jwt
Imports TolsisWallet.Entity.Entities.Concrete
Imports TolsisWallet.Core.Core.Entities.Concrete

Namespace Business.Concrete
    Public Class AuthManager
        Implements IAuthService

        Private ReadOnly _userService As IUserService
        Private ReadOnly _tokenHelper As ITokenHelper
        Public Sub New(ByVal userService As IUserService)
            _userService = userService
            '_tokenHelper = tokenHelper
        End Sub
        Public Function CreateAccessToken(user As User) As IDataResult(Of AccessToken) Implements IAuthService.CreateAccessToken
            Dim claims = _userService.GetClaims(user)
            Dim accessToken = _tokenHelper.CreateToken(user, claims)
            Return New SuccessDataResult(Of AccessToken)(accessToken, Messages.AccessTokenCreated)
        End Function
        'Private Function Register(userForRegisterDto As UserForRegisterDto, password As String) As IDataResult(Of User) Implements IAuthService.Register
        '    Dim passwordHash, passwordSalt As Byte()
        '    HashingHelper.CreatePasswordHash(password, passwordHash, passwordSalt)
        '    Dim user = New Core.Core.Entities.Concrete.User With {
        '        .Email = userForRegisterDto.Email,
        '        .FirstName = userForRegisterDto.FirstName,
        '        .LastName = userForRegisterDto.LastName,
        '        .PasswordHash = passwordHash,
        '        .PasswordSalt = passwordSalt,
        '        .Status = True
        '    }
        '    _userService.Add(user)
        '    Return New SuccessDataResult(Of Core.Core.Entities.Concrete.User)(user, Messages.UserRegistered)
        'End Function
        Private Function Login(userForLoginDto As UserForLoginDto) As IDataResult(Of User) Implements IAuthService.Login

            Dim userToCheck = _userService.GetByUserNameAndPassword(userForLoginDto.Email, userForLoginDto.Password)

            If userToCheck Is Nothing Then
                Return New ErrorDataResult(Of User)(Messages.UserNotFound)
            Else
                Return New SuccessDataResult(Of User)(userToCheck, Messages.SuccessfulLogin)
            End If

            'If Not HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt) Then
            '    Return New ErrorDataResult(Of User)(Messages.PasswordError)
            'End If

        End Function

    End Class
End Namespace
