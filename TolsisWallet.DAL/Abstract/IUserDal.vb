Imports System.Collections.Generic
Imports TolsisWallet.Core.Core.DataAccess
Imports TolsisWallet.Core.Core.Entities.Concrete

Namespace DataAccess.Abstract
    Public Interface IUserDal
        Inherits IEntityRepository(Of User)
    End Interface

End Namespace
