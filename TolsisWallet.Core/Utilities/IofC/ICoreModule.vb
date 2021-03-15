Imports Microsoft.Extensions.DependencyInjection

Namespace Core.Utilities.IoC
    Public Interface ICoreModule
        Sub Load(ByVal service As IServiceCollection)
    End Interface
End Namespace
