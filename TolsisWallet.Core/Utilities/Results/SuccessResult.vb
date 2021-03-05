Namespace Core.Utilities.Results
    Public Class SuccessResult
        Inherits Result
        Public Sub New(ByVal message As String)
            MyBase.New(True, message)
        End Sub
        Public Sub New()
            MyBase.New(True)
        End Sub
    End Class
End Namespace
