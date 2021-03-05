Namespace Core.Utilities.Results
    Public Class Result
        Implements IResult

        Public Sub New(ByVal success As Boolean, ByVal message As String)
            Me.New(success)
            Me.Message = message
        End Sub

        Public Sub New(ByVal success As Boolean)
            Me.Success = success
        End Sub

        Public ReadOnly Property Success As Boolean Implements IResult.Success
        Public ReadOnly Property Message As String Implements IResult.Message

    End Class

End Namespace

