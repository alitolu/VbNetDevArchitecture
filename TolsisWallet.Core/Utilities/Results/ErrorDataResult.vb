Namespace Utilities.Results
    Public Class ErrorDataResult(Of T)
        Inherits DataResult(Of T)
        Public Sub New(ByVal data As T, ByVal message As String)
            MyBase.New(data, False, message)
        End Sub
        Public Sub New(ByVal data As T)
            MyBase.New(data, False)
        End Sub
        Public Sub New(ByVal message As String)
            MyBase.New(Nothing, False, message)
        End Sub
    End Class

End Namespace
