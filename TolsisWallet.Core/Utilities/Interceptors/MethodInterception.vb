Imports System
Imports System.Collections.Generic
Imports System.Text
Imports Castle.DynamicProxy

Namespace Utilities.Interceptors
    Public MustInherit Class MethodInterception
        Inherits MethodInterceptionBaseAttribute
        Protected Overridable Sub OnBefore(ByVal invocation As IInvocation)
        End Sub
        Protected Overridable Sub OnAfter(ByVal invocation As IInvocation)
        End Sub
        Protected Overridable Sub OnException(ByVal invocation As IInvocation, ByVal e As Exception)
        End Sub
        Protected Overridable Sub OnSuccess(ByVal invocation As IInvocation)
        End Sub
        Public Overrides Sub Intercept(ByVal invocation As IInvocation)
            Dim isSuccess = True
            OnBefore(invocation)
            Try
                invocation.Proceed()
            Catch e As Exception
                isSuccess = False
                OnException(invocation, e)
                Throw
            Finally
                If isSuccess Then
                    OnSuccess(invocation)
                End If
            End Try
            OnAfter(invocation)
        End Sub
    End Class

End Namespace

