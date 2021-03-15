Imports FluentValidation
Imports TolsisWallet.Business.Business.Abstract
Imports TolsisWallet.Business.Business.DependencyResolvers.Ninject
Imports TolsisWallet.Core.Entities.Concrete

Namespace Business.ValidationRules.FluentValidation
    Public Class UserValidator
        Inherits AbstractValidator(Of User)
        Public Sub New()
            RuleFor(Function(p) p.FirstName).NotEmpty()
            RuleFor(Function(p) p.FirstName).Length(2, 30)
        End Sub
        Private Function StartWithWithA(ByVal arg As String) As Boolean
            Return arg.StartsWith("A")
        End Function

    End Class

End Namespace
