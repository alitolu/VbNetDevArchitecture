Imports FluentValidation

Namespace CrossCuttingConcerns.Validation
    Public Class ValidatorTool
        Public Shared Sub FluentValidate(ByVal validator As IValidator, ByVal entity As Object)

            Dim context As New ValidationContext(Of Object)(entity)

            Dim result = validator.Validate(entity)

            If result.Errors.Count > 0 Then
                Throw New ValidationException(result.Errors)
            End If

        End Sub
    End Class
End Namespace
