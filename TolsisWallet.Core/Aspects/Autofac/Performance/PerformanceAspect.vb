Imports System.Diagnostics
Imports Castle.DynamicProxy
Imports TolsisWallet.Core.Utilities.Interceptors
Imports TolsisWallet.Core.Utilities.IoC

Namespace Core.Aspects.Autofac.Performance
    Public Class PerformanceAspect
        Inherits MethodInterception

        Private _interval As Integer
        Private _stopwatch As Stopwatch

        Public Sub New(ByVal interval As Integer)
            _interval = interval
            _stopwatch = Activator.CreateInstance(Of Stopwatch)()
        End Sub

        Protected Overrides Sub OnBefore(ByVal invocation As IInvocation)
            _stopwatch.Start()
        End Sub

        Protected Overrides Sub OnAfter(ByVal invocation As IInvocation)
            If _stopwatch.Elapsed.TotalSeconds > _interval Then
                Debug.WriteLine($"Performance : {invocation.Method.DeclaringType.FullName}.{invocation.Method.Name}-->{_stopwatch.Elapsed.TotalSeconds}")
            End If

            _stopwatch.Reset()
        End Sub
    End Class
End Namespace
