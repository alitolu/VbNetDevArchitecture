Imports FluentValidation
Imports TolsisWallet.Business.Business.Abstract
Imports TolsisWallet.Business.Business.DependencyResolvers.Ninject
Imports TolsisWallet.Core.Entities.Concrete

Namespace Business.ValidationRules.FluentValidation
    Public Class UserValidator
        Inherits AbstractValidator(Of User)
        Public Sub New()
            RuleFor(Function(p) p.Email).NotEmpty()
            RuleFor(Function(p) p.Email).EmailAddress()
            RuleFor(Function(p) p.FirstName).NotEmpty()
            RuleFor(Function(p) p.FirstName).Length(2, 30)
            RuleFor(Function(p) p.LastName).NotEmpty()
            RuleFor(Function(p) p.LastName).Length(2, 30)
            RuleFor(Function(p) p.MobilePhone).NotEmpty()
            'RuleFor(Function(p) p.MobilePhone).Matches("(?:(?:(\s*\(?([2-9]1[02-9]|[2-9][02-8]1|[2-9][02-8][02-9])\s*)|([2-9]1[02-9]|[2‌​-9][02-8]1|[2-9][02-8][02-9]))\)?\s*(?:[.-]\s*)?)([2-9]1[02-9]|[2-9][02-9]1|[2-9]‌​[02-9]{2})\s*(?:[.-]\s*)?([0-9]{4})")
            RuleFor(Function(p) p.PasswordSalt).NotEmpty()
            RuleFor(Function(p) p.PasswordSalt).Length(5, 30)
            RuleFor(Function(p) p.PasswordVerify).Equal(Function(p) p.PasswordSalt)
        End Sub
        Private Function StartWithWithA(ByVal arg As String) As Boolean
            Return arg.StartsWith("A")
        End Function

    End Class

End Namespace
