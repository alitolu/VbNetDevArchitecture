Imports System
Imports System.Transactions
Imports Castle.DynamicProxy
Imports TolsisWallet.Core.Utilities.Interceptors


Namespace Aspects.Autofac.Transaction
    Public Class TransactionScopeAspect
        Inherits MethodInterception

        Public Overrides Sub Intercept(ByVal invocation As IInvocation)
            Using transactionScope As TransactionScope = New TransactionScope()

                Try
                    invocation.Proceed()
                    transactionScope.Complete()
                Catch e As Exception
                    transactionScope.Dispose()
                    Throw
                End Try
            End Using
        End Sub
    End Class
End Namespace
