Imports TolsisWallet.Business.Business.Abstract
Imports TolsisWallet.Business.Business.Constants
Imports TolsisWallet.Core.Utilities.Results
Imports TolsisWallet.Entity.Entities.Concrete
Imports TolsisWallet.Core.Entities.Concrete

Namespace Business.Concrete
    Public Class AuthManager
        Implements IAuthService

        Private ReadOnly _userService As IUserService
        Public Sub New(ByVal userService As IUserService)
            _userService = userService
        End Sub
        Private Function Login(userForLoginDto As UserForLoginDto) As IDataResult(Of User) Implements IAuthService.Login

            Dim users = _userService.GetByUserNameAndPassword(userForLoginDto.Email, userForLoginDto.Password)

            If users Is Nothing Then
                Return New ErrorDataResult(Of User)(Messages.UserNotFound)
            Else
                Return New SuccessDataResult(Of User)(users, Messages.SuccessfulLogin)
            End If

        End Function

    End Class
End Namespace
