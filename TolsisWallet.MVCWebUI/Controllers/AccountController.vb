

Imports TolsisWallet.Business.Business.Abstract
Imports TolsisWallet.Business.Business.DependencyResolvers.Ninject
Imports TolsisWallet.Business.Business.ValidationRules.FluentValidation
Imports TolsisWallet.Core
Imports TolsisWallet.Core.Entities.Concrete
Imports TolsisWallet.Entity.Entities.Concrete

Namespace Controllers
    Public Class AccountController
        Inherits Controller

        Private _authService As IAuthService
        Private _usermanager As IUserService
        Public Sub New(ByVal authService As IAuthService, ByVal usermanager As IUserService)
            _authService = authService
            _usermanager = usermanager
        End Sub
        Function Login() As ActionResult
            Return View()
        End Function
        Function Register() As ActionResult
            Return View()
        End Function
        <HttpPost()>
        Public Function Login(ByVal userForLoginDto As UserForLoginDto) As ActionResult

            Dim msg As String = ""

            Try

                Dim user = _authService.Login(userForLoginDto)

                If Not user.Success = True Then
                    msg = "error"
                Else
                    msg = "ok"
                End If

            Catch ex As Exception
                msg = ex.Message
            End Try

            Return Json(New With {
                   .msg = msg
               }, JsonRequestBehavior.AllowGet)

        End Function

        <HttpPost()>
        Public Function Register(ByVal user As User) As ActionResult

            Dim msg As String = ""

            Try

                Dim _user = _usermanager.Add(user)
                msg = _user.Id

            Catch ex As Exception
                msg = Err.Description
            End Try

            Return Json(New With {
                   .msg = msg
               }, JsonRequestBehavior.AllowGet)

        End Function

    End Class
End Namespace