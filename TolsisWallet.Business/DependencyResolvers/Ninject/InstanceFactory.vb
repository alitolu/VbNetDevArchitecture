Imports System.Reflection
Imports Ninject

Namespace Business.DependencyResolvers.Ninject
    Public Class InstanceFactory
        Public Shared Function GetInstance(Of T)() As T
            Dim kernel As New StandardKernel(New NinjectBusinessModule())
            Return kernel.[Get](Of T)()
        End Function

    End Class
End Namespace
