Imports System.IO
Imports log4net.Core
Imports log4net.Layout
Imports Newtonsoft.Json

Namespace CrossCuttingConcerns.Logging
    Public Class JsonLayout
        Inherits LayoutSkeleton

        Public Overrides Sub ActivateOptions()
        End Sub

        Public Overrides Sub Format(ByVal writer As TextWriter, ByVal loggingEvent As LoggingEvent)
            Dim logEvent = New SerializableLogEvent(loggingEvent)
            Dim json = JsonConvert.SerializeObject(logEvent, Formatting.Indented)
            writer.WriteLine(json)
        End Sub
    End Class
End Namespace
