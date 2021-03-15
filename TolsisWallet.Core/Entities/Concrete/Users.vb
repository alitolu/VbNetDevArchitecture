Imports TolsisWallet.Core.Core.DataAccess

Namespace Entities.Concrete
    Public Class User
        Implements IEntity
        Public Property Id As Integer
        Public Property UserCode As String
        Public Property UserName As String
        Public Property PasswordSalt As String
        Public Property PasswordVerify As String
        Public Property FirstName As String
        Public Property LastName As String
        Public Property Email As String
        Public Property MobilePhone As String
        Public Property Status As Int16
        Public Property SmsVerify As Int16
        Public Property EmailVerify As Int16
        Public Property LastPasswordDate As DateTime
        Public Property WrongPassTry As Int16
        Public Property RecordDate As DateTime
        Public Property UpdateDate As DateTime

    End Class

End Namespace
