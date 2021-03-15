Namespace Utilities.Results
    Public Class ErrorResult
        Inherits Result
        Public Sub New(ByVal message As String)
            MyBase.New(False, message)
        End Sub
        Public Sub New()
            MyBase.New(False)
        End Sub
    End Class
End Namespace
