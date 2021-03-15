Imports Autofac
Imports Castle.DynamicProxy
Imports FluentValidation
Imports Ninject.Modules
Imports TolsisWallet.Business.Business.Abstract
Imports TolsisWallet.Business.Business.Concrete
Imports TolsisWallet.Business.Business.Concrete.Managers
Imports TolsisWallet.Business.Business.ValidationRules.FluentValidation
Imports TolsisWallet.Core.Core.DataAccess
Imports TolsisWallet.Core.DataAccess.EntityFramework
Imports TolsisWallet.Core.Utilities.Interceptors
Imports TolsisWallet.Core.Utilities.Security.Jwt
Imports TolsisWallet.DAL.DataAccess.Abstract
Imports TolsisWallet.DAL.DataAccess.Concrete.EntityFramework

Namespace Business.DependencyResolvers.Ninject
    Public Class NinjectBusinessModule
        Inherits NinjectModule
        Public Overrides Sub Load()
            Kernel.Bind(Of IUserDal).To(Of EfUserDal)().InSingletonScope()
            Kernel.Bind(Of IAuthService)().[To](Of AuthManager)().InSingletonScope()
            Kernel.Bind(Of IUserService).To(Of UserManager)().InSingletonScope()
            Kernel.Bind(Of ITokenHelper)().[To](Of JwtHelper)().InSingletonScope()
            Kernel.Bind(CType(GetType(IQueryableRepository(Of)), Type)).[To](GetType(EfQueryableRepository(Of)))
            Kernel.Bind(Of EfdbContext).To(Of EfdbContext)()
        End Sub
    End Class
End Namespace
