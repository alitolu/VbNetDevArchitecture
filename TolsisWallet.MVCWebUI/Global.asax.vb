Imports System
Imports System.ServiceModel
Imports System.Web.Mvc
Imports System.Web.Optimization
Imports System.Web.Routing
Imports Autofac
Imports Autofac.Integration.Mvc
Imports TolsisWallet.Business.Business.DependencyResolvers.AutoFac
Imports TolsisWallet.Business.Business.DependencyResolvers.Dependencies

Public Class MvcApplication

    Inherits System.Web.HttpApplication

    Sub Application_Start()

        Dim builder = New ContainerBuilder()
        builder.RegisterControllers(GetType(MvcApplication).Assembly)
        builder.RegisterModelBinders(GetType(MvcApplication).Assembly)
        builder.RegisterModelBinderProvider()
        builder.RegisterModule(Of AutofacWebTypesModule)()
        builder.RegisterSource(New ViewRegistrationSource())
        builder.RegisterFilterProvider()
        builder.RegisterType(Of ViewDependency)().[As](Of IViewDependency)()
        builder.RegisterType(Of FilterDependency)().[As](Of IFilterDependency)()
        builder.RegisterModule(New AutofacBusinessModule)
        Dim container = builder.Build()
        DependencyResolver.SetResolver(New AutofacDependencyResolver(container))

        AreaRegistration.RegisterAllAreas()
        FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters)
        RouteConfig.RegisterRoutes(RouteTable.Routes)
        BundleConfig.RegisterBundles(BundleTable.Bundles)

        ''ControllerBuilder.Current.SetControllerFactory(New NinjectControllerFactory(New NinjectBusinessModule()))
        ''FluentValidationModelValidatorProvider.Configure()

    End Sub


End Class
