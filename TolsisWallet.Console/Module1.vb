Imports System
Imports TolsisWallet.Business.Business.Abstract
Imports TolsisWallet.Business.Business.DependencyResolvers.Ninject
Imports TolsisWallet.Entity.Entities.Concrete

Module Module1

    Private ReadOnly _authService As IAuthService


    Sub Main(args As String())
        'Try
        Dim memberService = InstanceFactory.GetInstance(Of IAuthService)()
            Dim _UserForLoginDto As New UserForLoginDto
        _UserForLoginDto.Email = "asdas"
        _UserForLoginDto.Password = "asdasdasd"
        Dim userToLogin = memberService.Login(_UserForLoginDto)

        If userToLogin.Success = True Then
            MsgBox("kullanıcı giriş yaptı")
        Else
            MsgBox("kullanıcı bulunamadı")
        End If

        'Catch ex As Exception
        '    MsgBox(Err.Description)
        'End Try

    End Sub

End Module
