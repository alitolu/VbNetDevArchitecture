Imports TolsisWallet.Core.Core.DataAccess

Namespace Entities.Concrete
    Public Class UserForRegisterDto
        Implements IDto
        Public Property UserName As String
        Public Property PasswordSalt As String
        Public Property FirstName As String
        Public Property LastName As String
        Public Property Email As String
        Public Property MobilePhone As String
        Public Property Status As Int16
        Public Property SmsVerify As Int16
        Public Property EmailVerify As Int16

    End Class


End Namespace

