Namespace Utilities.Results
    Public Class SuccessDataResult(Of T)
        Inherits DataResult(Of T)
        Public Sub New(ByVal data As T, ByVal message As String)
            MyBase.New(data, True, message)
        End Sub
        Public Sub New(ByVal data As T)
            MyBase.New(data, True)
        End Sub
        Public Sub New(ByVal message As String)
            MyBase.New(Nothing, True, message)
        End Sub
        Public Sub New()
            MyBase.New(Nothing, True)
        End Sub
    End Class
End Namespace
