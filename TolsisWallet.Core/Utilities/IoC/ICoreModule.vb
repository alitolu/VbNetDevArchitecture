
Imports Microsoft.Extensions.DependencyInjection

Namespace Utilities.IoC
    Public Interface ICoreModule
        Sub Load(ByVal collection As IServiceCollection)

    End Interface

End Namespace
