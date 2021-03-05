Imports TolsisWallet.Core.Core.DataAccess

Namespace Core.Entities.Concrete
    Public Class User
        Implements IEntity
        Public Property Id As Integer
        Public Property FirstName As String
        Public Property LastName As String
        Public Property Email As String
        Public Property PasswordSalt As String

        'Public Property PasswordHash As Byte()
        'Public Property Status As Boolean

    End Class

End Namespace
