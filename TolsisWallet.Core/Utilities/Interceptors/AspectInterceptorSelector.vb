Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Reflection
Imports System.Text
Imports Castle.DynamicProxy
Imports TolsisWallet.Core.Core.Aspects.Autofac.Exception
Imports TolsisWallet.Core.CrossCuttingConcerns.Logging

Namespace Utilities.Interceptors
    Public Class AspectInterceptorSelector
        Implements IInterceptorSelector
        Private Function SelectInterceptors(type As Type, method As MethodInfo, interceptors() As IInterceptor) As IInterceptor() Implements IInterceptorSelector.SelectInterceptors
            Dim classAttributes = type.GetCustomAttributes(Of MethodInterceptionBaseAttribute)(True).ToList()
            Dim methodAttributes = type.GetMethod(method.Name).GetCustomAttributes(Of MethodInterceptionBaseAttribute)(True)
            classAttributes.AddRange(methodAttributes)
            Return classAttributes.OrderBy(Function(p) p.Priority).ToArray()
        End Function
    End Class
End Namespace

