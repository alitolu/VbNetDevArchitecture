Imports Ninject.Modules
Imports FluentValidation
Imports TolsisWallet.Business.Business.ValidationRules.FluentValidation
Imports TolsisWallet.Core.Entities.Concrete

Namespace Business.DependencyResolvers.Ninject
    Public Class ValidationModule
        Inherits NinjectModule
        Public Overrides Sub Load()
            Kernel.Bind(Of IValidator(Of User))().[To](Of UserValidator)().InSingletonScope()
        End Sub
    End Class

End Namespace
