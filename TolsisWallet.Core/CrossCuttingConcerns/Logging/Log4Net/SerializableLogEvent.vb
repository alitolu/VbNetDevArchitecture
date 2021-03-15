Imports System
Imports log4net.Core

Namespace CrossCuttingConcerns.Logging
    <Serializable>
    Public Class SerializableLogEvent
        Private _loggingEvent As LoggingEvent

        Public Sub New(ByVal loggingEvent As LoggingEvent)
            _loggingEvent = loggingEvent
        End Sub

        Public ReadOnly Property Message As Object
            Get
                Return _loggingEvent.MessageObject
            End Get
        End Property
    End Class
End Namespace
