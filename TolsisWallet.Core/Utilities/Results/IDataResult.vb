Namespace Core.Utilities.Results
    Public Interface IDataResult(Of Out T)
        Inherits IResult
        ReadOnly Property Data As T
    End Interface

End Namespace
