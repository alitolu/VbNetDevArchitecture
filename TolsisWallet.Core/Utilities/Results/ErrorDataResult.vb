Namespace Core.Utilities.Results
    Public Class ErrorDataResult(Of T)
        Inherits DataResult(Of T)
        Public Sub New(ByVal data As T, ByVal message As String)
        End Sub
        Public Sub New(ByVal data As T)
        End Sub
        Public Sub New(ByVal message As String)
        End Sub

    End Class
End Namespace
