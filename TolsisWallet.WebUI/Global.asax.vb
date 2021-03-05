Imports System.Web.Optimization
Imports TolsisWallet.Business.Business.DependencyResolvers.Ninject
Imports TolsisWallet.Core.Core.Utilities.Mvc.Infrastructure

Public Class MvcApplication
    Inherits System.Web.HttpApplication

    Sub Application_Start()
        AreaRegistration.RegisterAllAreas()
        FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters)
        RouteConfig.RegisterRoutes(RouteTable.Routes)
        BundleConfig.RegisterBundles(BundleTable.Bundles)
        ControllerBuilder.Current.SetControllerFactory(New NinjectControllerFactory(New BusinessModule()))
    End Sub
End Class
