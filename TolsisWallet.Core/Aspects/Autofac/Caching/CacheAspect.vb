Imports System.Linq
Imports Castle.DynamicProxy
Imports TolsisWallet.Core.CrossCuttingConcerns.Caching
Imports TolsisWallet.Core.Utilities.Interceptors
Imports TolsisWallet.Core.Utilities.IoC

Namespace Aspects.Autofac.Caching
    Public Class CacheAspect
        Inherits MethodInterception

        Private _duration As Integer
        Private _cacheManager As ICacheManager

        Public Sub New(ByVal Optional duration As Integer = 60)
            _duration = duration
            _cacheManager = Activator.CreateInstance(Of ICacheManager)()
        End Sub

        Public Overrides Sub Intercept(ByVal invocation As IInvocation)
            Dim methodName = String.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}")
            Dim arguments = invocation.Arguments.ToList()
            Dim key = $"{methodName}({String.Join(",", arguments.[Select](Function(x) If(x?.ToString(), "<Null>")))})"

            If _cacheManager.IsAdd(key) Then
                invocation.ReturnValue = _cacheManager.[Get](key)
                Return
            End If

            invocation.Proceed()
            _cacheManager.Add(key, invocation.ReturnValue, _duration)
        End Sub
    End Class
End Namespace
