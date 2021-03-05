Imports TolsisWallet.Core.Core.Entities.Concrete
Imports TolsisWallet.Core.Core.Utilities.Results
Imports TolsisWallet.Core.Core.Utilities.Security.Jwt
Imports TolsisWallet.Entity.Entities.Concrete

Namespace Business.Abstract
    Public Interface IAuthService
        'Function Register(ByVal userForRegisterDto As UserForRegisterDto, ByVal password As String) As IDataResult(Of Core.Core.Entities.Concrete.User)
        Function Login(ByVal userForLoginDto As UserForLoginDto) As IDataResult(Of User)

        'Function UserExists(ByVal email As String) As IResult

        Function CreateAccessToken(ByVal user As User) As IDataResult(Of AccessToken)

    End Interface


End Namespace
