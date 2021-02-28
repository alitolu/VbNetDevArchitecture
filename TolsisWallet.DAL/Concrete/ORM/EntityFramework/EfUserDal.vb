Imports System.Linq.Expressions
Imports TolsisWallet.Core.Core.DataAccess
Imports TolsisWallet.Core.Core.DataAccess.EntityFramework
Imports TolsisWallet.Core.Core.Entities.Concrete
Imports TolsisWallet.DAL.DataAccess.Abstract

Namespace DataAccess.Concrete.EntityFramework
    Public Class EfUserDal
        Inherits EfEntityRepositoryBase(Of User, EfdbContext)
        Implements IUserDal
        Public Function GetClaims(user As User) As List(Of OperationClaim) Implements IUserDal.GetClaims
            Throw New NotImplementedException()
        End Function

    End Class

End Namespace
