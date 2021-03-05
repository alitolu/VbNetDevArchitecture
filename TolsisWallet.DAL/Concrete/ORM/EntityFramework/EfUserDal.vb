Imports System.Linq.Expressions
Imports TolsisWallet.Core.Core.DataAccess
Imports TolsisWallet.Core.Core.DataAccess.EntityFramework
Imports TolsisWallet.Core.Core.Entities.Concrete
Imports TolsisWallet.DAL.DataAccess.Abstract

Namespace DataAccess.Concrete.EntityFramework
    Public Class EfUserDal
        Inherits EfEntityRepositoryBase(Of User, EfdbContext)
        Implements IUserDal
        Public Function GetClaims(ByVal user As User) As List(Of OperationClaim) Implements IUserDal.GetClaims
            Using context = New EfdbContext()
                Dim result = From operationClaim In context.OperationClaims Join userOperationClaim In context.UserOperationClaims On operationClaim.Id Equals userOperationClaim.OperationClaimId Where userOperationClaim.OperationClaimId = user.Id Select New OperationClaim With {
                    .Id = operationClaim.Id,
                    .Name = operationClaim.Name
                }
                Return result.ToList()
            End Using
        End Function
    End Class

End Namespace
