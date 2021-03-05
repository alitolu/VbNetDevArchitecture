Imports AutoMapper
Imports Ninject.Modules

Namespace Business.DependencyResolvers.Ninject
    Public Class AutoMapperModule
        Inherits NinjectModule

        Public Overrides Sub Load()
            Call Bind(Of IMapper)().ToConstant(CreateConfiguration().CreateMapper()).InSingletonScope()
        End Sub
        Private Function CreateConfiguration() As MapperConfiguration
            Dim config = New MapperConfiguration(Sub(cfg) cfg.AddProfiles(MyBase.GetType().Assembly))
            Return config
        End Function

    End Class
End Namespace
