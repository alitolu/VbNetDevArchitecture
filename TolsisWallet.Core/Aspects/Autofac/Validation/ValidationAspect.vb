Imports Castle.DynamicProxy
Imports FluentValidation
Imports TolsisWallet.Core.CrossCuttingConcerns.Validation
Imports TolsisWallet.Core.Utilities.Interceptors
Imports TolsisWallet.Core.Utilities.Messages

Public Class ValidationAspect
    Inherits MethodInterception
    Private _validatorType As Type
    Public Sub New(ByVal validatorType As Type)

        If Not GetType(IValidator).IsAssignableFrom(validatorType) Then
            Throw New Exception(AspectMessages.WrongValidationType)
        End If

        _validatorType = validatorType
    End Sub
    Protected Overrides Sub OnBefore(ByVal invocation As IInvocation)

        Dim validator = CType(Activator.CreateInstance(_validatorType), IValidator)

        Dim entityType = _validatorType.BaseType.GetGenericArguments()(0)
        Dim entities = invocation.Arguments.Where(Function(t) t.[GetType]() Is entityType)

        For Each Entityy In entities
            ValidatorTool.FluentValidate(validator, Entityy)
        Next

    End Sub

End Class
