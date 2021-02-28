Imports System.Collections.Generic
Imports TolsisWallet.Core.Core.DataAccess
Imports TolsisWallet.Core.Core.Entities.Concrete

Namespace DataAccess.Abstract
    Public Interface IUserDal
        Inherits IEntityRepository(Of User)
        Function GetClaims(ByVal user As User) As List(Of OperationClaim)

    End Interface

End Namespace
