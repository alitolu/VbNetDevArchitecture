Imports System.Web.Mvc
Imports Ninject
Imports TolsisWallet.Business.Business.Abstract
Imports TolsisWallet.Business.Business.DependencyResolvers.Ninject
Imports TolsisWallet.Entity.Entities.Concrete

Namespace Controllers
    Public Class AccountController
        Inherits Controller

        Function Login() As ActionResult
            Return View()
        End Function

        'Private ReadOnly _authService As IAuthService

        '<Inject()>
        'Public Sub New(authService As IAuthService)
        '    _authService = authService
        'End Sub

        <HttpPost()>
        Public Function Login(ByVal userForLoginDto As UserForLoginDto) As ActionResult

            Dim msg As String = ""

            Try

                Dim _authService = InstanceFactory.GetInstance(Of IAuthService)()

                Dim userToLogin = _authService.Login(userForLoginDto)

                If Not userToLogin.Success = True Then
                    msg = "error"
                Else
                    msg = "ok"
                End If

                Dim result = _authService.CreateAccessToken(userToLogin.Data)

                'If result.Success Then
                '    msg = "ok"
                'End If

            Catch ex As Exception
                msg = ex.Message
            End Try

            Return Json(New With {
                   .msg = msg
               }, JsonRequestBehavior.AllowGet)

        End Function
    End Class
End Namespace