Namespace CrossCuttingConcerns.Logging
    Public Class FileLogger
        Inherits LoggerServiceBase
        Public Sub New()
            MyBase.New("JsonFileLogger")
        End Sub
    End Class
End Namespace
