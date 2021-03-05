Namespace Core.Utilities.Results
    Public Class DataResult(Of T)
        Inherits Result
        Implements IDataResult(Of T)
        Public Sub New(ByVal data As T, ByVal success As Boolean, ByVal message As String)
            MyBase.New(success, message)
            Me.Data = data
        End Sub
        Public Sub New(ByVal data As T, ByVal success As Boolean)
            MyBase.New(success)
            Me.Data = data
        End Sub
        Public ReadOnly Property Data As T Implements IDataResult(Of T).Data
    End Class
End Namespace

