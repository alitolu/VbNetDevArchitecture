
Imports TolsisWallet.Core.DataAccess.EntityFramework
Imports TolsisWallet.Core.Entities.Concrete
Imports TolsisWallet.DAL.DataAccess.Abstract

Namespace DataAccess.Concrete.EntityFramework
    Public Class EfUserDal
        Inherits EfEntityRepositoryBase(Of User, EfdbContext)
        Implements IUserDal

    End Class

End Namespace
