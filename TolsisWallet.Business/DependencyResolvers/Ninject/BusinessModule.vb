
Imports Ninject.Modules
Imports TolsisWallet.Business.Business.Abstract
Imports TolsisWallet.Business.Business.Concrete.Managers
Imports TolsisWallet.Core.Core.DataAccess
Imports TolsisWallet.Core.Core.DataAccess.EntityFramework
Imports TolsisWallet.DAL.DataAccess.Abstract
Imports TolsisWallet.DAL.DataAccess.Concrete.EntityFramework

Namespace Business.DependencyResolvers.Ninject
    Public Class BusinessModule
        Inherits NinjectModule
        Public Overrides Sub Load()
            Bind(Of IUserService)().[To](Of UserManager)()
            Bind(Of IUserDal)().[To](Of EfUserDal)()
            Bind(CType(GetType(IQueryableRepository(Of)), Type)).[To](GetType(EfQueryableRepository(Of)))
            Bind(Of EfdbContext)().[To](Of EfdbContext)()
        End Sub
    End Class
End Namespace
