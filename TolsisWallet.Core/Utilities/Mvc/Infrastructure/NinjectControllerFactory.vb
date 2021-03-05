Imports System
Imports System.Reflection
Imports System.Web.Mvc
Imports System.Web.Routing
Imports Ninject
Imports Ninject.Modules

Namespace Core.Utilities.Mvc.Infrastructure
    Public Class NinjectControllerFactory
        Inherits DefaultControllerFactory

        Private _Kernel As IKernel

        Public Property Kernel As IKernel
            Get
                Return _Kernel
            End Get
            Private Set(ByVal value As IKernel)
                _Kernel = value
            End Set
        End Property

        'Public Sub New(ByVal kernel As IKernel)
        '    Me.Kernel = kernel
        'End Sub

        Public Sub New(ParamArray modules As INinjectModule())
            _Kernel = New StandardKernel(modules)
        End Sub
        Protected Overrides Function GetControllerInstance(ByVal requestContext As System.Web.Routing.RequestContext, ByVal controllerType As Type) As IController
            Dim controller As IController = Nothing
            If controllerType IsNot Nothing Then controller = CType(Kernel.Get(controllerType), IController)
            Return controller
        End Function

        'Private _kernel As IKernel

        'Public Sub New(ParamArray modules As INinjectModule())
        '    _kernel = New StandardKernel(modules)
        'End Sub
        'Protected Overrides Function GetControllerInstance(ByVal requestContext As RequestContext, ByVal controllerType As Type) As IController
        '    Return If(controllerType Is Nothing, Nothing, CType(_kernel.Get(controllerType), IController))
        'End Function
    End Class

End Namespace

