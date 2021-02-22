Namespace Core.Utilities.Results
    Public Class DataResult(Of T)
        Inherits Result
        Implements IDataResult(Of T)
        Private ReadOnly Property Data As T Implements IDataResult(Of T).Data
            Get
                Throw New NotImplementedException()
            End Get
        End Property
    End Class

End Namespace

