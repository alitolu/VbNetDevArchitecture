Imports System.Collections.Generic

Namespace CrossCuttingConcerns.Logging
    Public Class LogDetail
        Public Property MethodName As String
        Public Property LogParameters As List(Of LogParameter)
    End Class
End Namespace
