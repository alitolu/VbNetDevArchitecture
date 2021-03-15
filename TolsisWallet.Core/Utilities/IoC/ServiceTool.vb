
Imports Microsoft.Extensions.DependencyInjection

Namespace Utilities.IoC
    Public Class ServiceTool

        Private _ServiceProvider As IServiceProvider

        Public Property ServiceProvider As IServiceProvider
            Get
                Return _ServiceProvider
            End Get
            Private Set(ByVal value As IServiceProvider)
                _ServiceProvider = value
            End Set
        End Property
        Public Function Create(ByVal services As IServiceCollection) As IServiceCollection
            'ServiceProvider = services.BuildServiceProvider()
            Return services
        End Function

    End Class
End Namespace
