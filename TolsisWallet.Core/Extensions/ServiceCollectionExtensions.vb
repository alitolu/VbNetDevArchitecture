Imports System.Runtime.CompilerServices
Imports Autofac
Imports Autofac.Extensions.DependencyInjection
Imports Microsoft.Extensions.DependencyInjection
Imports TolsisWallet.Core.Core.Utilities.IoC

Namespace Core.Extensions
    Public Module ServiceCollectionExtensions
        Private _container As IContainer

        ''' <summary>
        ''' Her katmanın çözümleme modülleri IServiceCollection'a ekleniyor.
        ''' </summary>
        ''' <paramname="service"></param>
        ''' <paramname="modules"></param>
        ''' <returns></returns>
        '<Extension()>
        'Public Function AddDependencyResolvers(ByVal service As IServiceCollection, ByVal modules As ICoreModule()) As IServiceCollection
        '    For Each [module] In modules
        '        [module].Load(service)
        '    Next
        '    Return ServiceTool.Create(service)
        'End Function

        ''' <summary>
        ''' Daha önce IServiceCollection tarafında yapılan çözümlemeleri dolduruyor.
        ''' </summary>
        ''' <paramname="services"></param>
        ''' <paramname="modules"></param>
        ''' <returns></returns>
        <Extension()>
        Public Function AddAutofacDependencyResolvers(ByVal services As IServiceCollection, ByVal modules As [Module]()) As IServiceCollection
            Dim builder = New ContainerBuilder()
            builder.Populate(services)

            For Each [module] In modules
                builder.RegisterModule([module])
            Next

            _container = builder.Build()
            Return services
        End Function

        <Extension()>
        Public Function CreateAutofacServiceProvider(ByVal services As IServiceCollection) As IServiceProvider
            Return New AutofacServiceProvider(_container)
        End Function
    End Module
End Namespace