Imports System
Imports System.Collections.Generic
Imports System.Text
Imports Castle.DynamicProxy

Namespace Utilities.Interceptors

    <AttributeUsage(AttributeTargets.Class Or AttributeTargets.Method, AllowMultiple:=True, Inherited:=True)>
    Public MustInherit Class MethodInterceptionBaseAttribute
        Inherits Attribute
        Implements IInterceptor

        Private _Priority As Integer

        Public Overridable Property Priority As Integer
            Get
                Return _Priority
            End Get
            Set
                _Priority = Value
            End Set
        End Property
        Public Overridable Sub Intercept(invocation As IInvocation) Implements IInterceptor.Intercept

        End Sub

    End Class

End Namespace

