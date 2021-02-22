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

        Private _userService As IUserService
        Private _tokenHelper As ITokenHelper
        Public Sub New(ByVal userService As IUserService, ByVal tokenHelper As ITokenHelper)
            _userService = userService
            _tokenHelper = tokenHelper
        End Sub
        Private Function UserExists(email As String) As IResult Implements IAuthService.UserExists
            '    If _userService.GetByMail(email) IsNot Nothing Then
            '        Return New ErrorResult(Messages.UserAlreadyExists)
            '    End If
            '    Return New SuccessResult()
        End Function
        Private Function CreateAccessToken(user As Core.Core.Entities.Concrete.User) As IDataResult(Of AccessToken) Implements IAuthService.CreateAccessToken
            'Dim claims = _userService.GetClaims(Core.Core.Entities.Concrete.User)
            'Dim accessToken = _tokenHelper.CreateToken(Core.Core.Entities.Concrete.User, claims)
            'Return New SuccessDataResult(Of AccessToken)(accessToken, Messages.AccessTokenCreated)
        End Function
        Private Function Register(userForRegisterDto As UserForRegisterDto, password As String) As IDataResult(Of Core.Core.Entities.Concrete.User) Implements IAuthService.Register
            Dim passwordHash, passwordSalt As Byte()
            HashingHelper.CreatePasswordHash(password, passwordHash, passwordSalt)
            Dim user = New Core.Core.Entities.Concrete.User With {
                .Email = userForRegisterDto.Email,
                .FirstName = userForRegisterDto.FirstName,
                .LastName = userForRegisterDto.LastName,
                .PasswordHash = passwordHash,
                .PasswordSalt = passwordSalt,
                .Status = True
            }
            _userService.Add(user)
            Return New SuccessDataResult(Of Core.Core.Entities.Concrete.User)(user, Messages.UserRegistered)
        End Function
        Private Function Login(userForLoginDto As UserForLoginDto) As IDataResult(Of Core.Core.Entities.Concrete.User) Implements IAuthService.Login

            Dim userToCheck = _userService.GetByMail(userForLoginDto.Email)

            If userToCheck Is Nothing Then
                Return New ErrorDataResult(Of Core.Core.Entities.Concrete.User)(Messages.UserNotFound)
            End If

            If Not HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt) Then
                Return New ErrorDataResult(Of Core.Core.Entities.Concrete.User)(Messages.PasswordError)
            End If

            Return New SuccessDataResult(Of Core.Core.Entities.Concrete.User)(userToCheck, Messages.SuccessfulLogin)
        End Function

    End Class
End Namespace
