Imports TolsisWallet.Core.Core.DataAccess

Namespace Core.Entities.Concrete
    Public Class UserOperationClaim
        Implements IEntity
        Public Property Id As Integer
        Public Property UserId As Integer
        Public Property OperationClaimId As Integer
    End Class
End Namespace
