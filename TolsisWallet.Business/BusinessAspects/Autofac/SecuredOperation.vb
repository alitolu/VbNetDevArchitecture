
Imports Castle.DynamicProxy
Imports Microsoft.AspNetCore.Http
Imports TolsisWallet.Business.Business.Constants
Imports TolsisWallet.Core.Utilities.Interceptors

Namespace BusinessAspects.Autofac
    Public Class SecuredOperation
        Inherits MethodInterception

        Private _roles As String()
        Private _httpContextAccessor As IHttpContextAccessor

        'Public Sub New(ByVal roles As String)
        '    _roles = roles.Split(","c)
        '    _httpContextAccessor = ServiceTool.ServiceProvider.GetService(Of IHttpContextAccessor)()
        'End Sub

        'Protected Overrides Sub OnBefore(ByVal invocation As IInvocation)
        '    Dim roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles()

        '    For Each role In _roles

        '        If roleClaims.Contains(role) Then
        '            Return
        '        End If
        '    Next

        '    Throw New Exception(Messages.AuthorizationDenied)
        'End Sub

    End Class
End Namespace
