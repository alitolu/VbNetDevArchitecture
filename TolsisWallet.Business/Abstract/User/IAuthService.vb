Imports TolsisWallet.Core.Entities.Concrete
Imports TolsisWallet.Core.Utilities.Results
Imports TolsisWallet.Entity.Entities.Concrete

Namespace Business.Abstract
    Public Interface IAuthService
        Function Login(ByVal userForLoginDto As UserForLoginDto) As IDataResult(Of User)

    End Interface


End Namespace
