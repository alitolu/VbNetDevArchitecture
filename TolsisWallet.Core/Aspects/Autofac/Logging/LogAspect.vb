Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Castle.DynamicProxy
Imports TolsisWallet.Core.CrossCuttingConcerns.Logging
Imports TolsisWallet.Core.Utilities.Interceptors
Imports TolsisWallet.Core.Utilities.Messages

Namespace Aspects.Autofac.Logging
    Public Class LogAspect
        Inherits MethodInterception

        Private _loggerServiceBase As LoggerServiceBase

        Public Sub New(ByVal loggerService As System.Type)
            If loggerService.BaseType IsNot GetType(LoggerServiceBase) Then
                Throw New System.Exception(AspectMessages.WrongLoggerType)
            End If

            Me._loggerServiceBase = CType(System.Activator.CreateInstance(loggerService), LoggerServiceBase)
        End Sub

        Protected Overrides Sub OnBefore(ByVal invocation As IInvocation)
            Me._loggerServiceBase.Info(Me.GetLogDetail(invocation))
        End Sub

        Private Function GetLogDetail(ByVal invocation As IInvocation) As LogDetail
            Dim logParameters = New System.Collections.Generic.List(Of LogParameter)()

            For i As Integer = 0 To invocation.Arguments.Length - 1
                logParameters.Add(New LogParameter With {
                    .Name = invocation.GetConcreteMethod().GetParameters()(CInt((i))).Name,
                    .Value = invocation.Arguments(i),
                    .Type = invocation.Arguments(CInt((i))).[GetType]().Name
                })
            Next

            Dim logDetail = New LogDetail With {
                .MethodName = invocation.Method.Name,
                .LogParameters = logParameters
            }
            Return logDetail
        End Function
    End Class
End Namespace
