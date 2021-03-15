Imports System.Web.Optimization
Imports TolsisWallet.Business.Business.DependencyResolvers.Ninject
Imports TolsisWallet.Core.CrossCuttingConcerns.Validation
Imports TolsisWallet.Core.Utilities.Mvc.Infrastructure
'Imports FluentValidation.Mvc
Public Class MvcApplication
    Inherits System.Web.HttpApplication

    Sub Application_Start()

        AreaRegistration.RegisterAllAreas()
        FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters)
        RouteConfig.RegisterRoutes(RouteTable.Routes)
        BundleConfig.RegisterBundles(BundleTable.Bundles)

        ControllerBuilder.Current.SetControllerFactory(New NinjectControllerFactory(New BusinessModule()))
        'FluentValidationModelValidatorProvider.Configure(Sub(provider) provider.ValidatorFactory = New NinjectValidationFactory(New ValidationModule()))

    End Sub
End Class
