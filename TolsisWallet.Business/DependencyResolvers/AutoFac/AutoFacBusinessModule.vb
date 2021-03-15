Imports Autofac
Imports Autofac.Extras.DynamicProxy
Imports Castle.DynamicProxy
Imports FluentValidation
Imports TolsisWallet.Business.Business.Abstract
Imports TolsisWallet.Business.Business.Concrete
Imports TolsisWallet.Business.Business.Concrete.Managers
Imports TolsisWallet.Business.Business.ValidationRules.FluentValidation
Imports TolsisWallet.Core.Entities.Concrete
Imports TolsisWallet.Core.Utilities.Interceptors
Imports TolsisWallet.Core.Utilities.Security.Jwt
Imports TolsisWallet.DAL.DataAccess.Abstract
Imports TolsisWallet.DAL.DataAccess.Concrete.EntityFramework

Namespace Business.DependencyResolvers.AutoFac
    Public Class AutofacBusinessModule
        Inherits [Module]

        Protected Overrides Sub Load(ByVal builder As ContainerBuilder)

            builder.RegisterType(Of EfUserDal)().[As](Of IUserDal)().SingleInstance()
            builder.RegisterType(Of AuthManager)().[As](Of IAuthService)().SingleInstance()
            builder.RegisterType(Of UserManager)().[As](Of IUserService)().SingleInstance()
            builder.RegisterType(Of JwtHelper)().[As](Of ITokenHelper)().SingleInstance()
            builder.RegisterType(Of EfdbContext)().[As](Of EfdbContext)().SingleInstance()

            'builder.RegisterType(Of UserValidator)().[As](Of IValidator(Of User))().SingleInstance()

            Dim assembly = Reflection.Assembly.GetExecutingAssembly()
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors(New ProxyGenerationOptions() With {
            .Selector = New AspectInterceptorSelector()
        }).SingleInstance()

        End Sub

    End Class
End Namespace

