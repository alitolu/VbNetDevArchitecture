Namespace Core.Utilities.Results
    Public Class Result
        Implements IResult

        Private ReadOnly Property Success As Boolean Implements IResult.Success
            Get
                Throw New NotImplementedException()
            End Get
        End Property

        Private ReadOnly Property Message As String Implements IResult.Message
            Get
                Throw New NotImplementedException()
            End Get
        End Property
    End Class
End Namespace

