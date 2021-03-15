Imports Castle.DynamicProxy
Imports TolsisWallet.Core.CrossCuttingConcerns.Caching
Imports TolsisWallet.Core.Utilities.Interceptors

Namespace Aspects.Autofac.Caching
    Public Class CacheRemoveAspect
        Inherits MethodInterception

        Private _pattern As String
        Private _cacheManager As ICacheManager

        Public Sub New(ByVal pattern As String)
            _pattern = pattern
            _cacheManager = Activator.CreateInstance(Of ICacheManager)()
        End Sub

        Protected Overrides Sub OnSuccess(ByVal invocation As IInvocation)
            _cacheManager.RemoveByPattern(_pattern)
        End Sub
    End Class
End Namespace
