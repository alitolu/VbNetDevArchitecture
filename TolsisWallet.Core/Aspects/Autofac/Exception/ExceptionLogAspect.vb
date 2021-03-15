Imports System
Imports System.Collections.Generic
Imports System.Text
Imports Castle.DynamicProxy
Imports TolsisWallet.Core.CrossCuttingConcerns.Logging
Imports TolsisWallet.Core.Utilities.Interceptors
Imports TolsisWallet.Core.Utilities.Messages

Namespace Core.Aspects.Autofac.Exception
    Public Class ExceptionLogAspect
        Inherits MethodInterception

        Private _loggerServiceBase As LoggerServiceBase

        Public Sub New(ByVal loggerService As Type)
            If loggerService.BaseType IsNot GetType(LoggerServiceBase) Then
                Throw New System.Exception(AspectMessages.WrongLoggerType)
            End If
            _loggerServiceBase = CType(Activator.CreateInstance(loggerService), LoggerServiceBase)
        End Sub
        Protected Overrides Sub OnException(ByVal invocation As IInvocation, ByVal e As System.Exception)
            Dim logDetailWithException As LogDetailWithException = Me.GetLogDetail(invocation)
            logDetailWithException.ExceptionMessage = e.Message
            _loggerServiceBase.Error(logDetailWithException)
        End Sub
        Private Function GetLogDetail(ByVal invocation As IInvocation) As LogDetailWithException
            Dim logParameters = New List(Of LogParameter)()

            For i As Integer = 0 To invocation.Arguments.Length - 1
                logParameters.Add(New LogParameter With {
                .Name = invocation.GetConcreteMethod().GetParameters()(CInt(i)).Name,
                .Value = invocation.Arguments(i),
                .Type = invocation.Arguments(CInt(i)).[GetType]().Name
            })
            Next

            Dim logDetailWithException = New LogDetailWithException With {
            .MethodName = invocation.Method.Name,
            .LogParameters = logParameters
                }
            Return logDetailWithException
        End Function
    End Class

End Namespace
