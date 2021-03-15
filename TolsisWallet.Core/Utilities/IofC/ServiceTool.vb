Imports Microsoft.Extensions.DependencyInjection
Imports System

Namespace Core.Utilities.IoC
    Public Module ServiceTool
        Private _ServiceProvider As System.IServiceProvider

        Public Property ServiceProvider As IServiceProvider
            Get
                Return _ServiceProvider
            End Get
            Private Set(ByVal value As IServiceProvider)
                _ServiceProvider = value
            End Set
        End Property

        'Public Function Create(ByVal service As IServiceCollection) As IServiceCollection
        '    ServiceProvider = service.BuildServiceProvider()
        '    Return service
        'End Function
    End Module
End Namespace
