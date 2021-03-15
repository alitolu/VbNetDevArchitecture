Imports System
Imports System.Web.Mvc
Imports FluentValidation.Mvc
Imports TolsisWallet.Business.Business.Abstract
Imports TolsisWallet.Business.Business.DependencyResolvers.Ninject
Imports TolsisWallet.Business.Business.ValidationRules.FluentValidation
Imports TolsisWallet.Core
Imports TolsisWallet.Core.CrossCuttingConcerns.Validation
Imports TolsisWallet.Core.Entities.Concrete


Module Module1

    <ValidationAspect(GetType(UserValidator))>
    Sub Main(args As String())

        Dim msg As String = ""

        Dim _User As New User

        Try

            Dim _usermanager = InstanceFactory.GetInstance(Of IUserService)()

            _User.FirstName = ""
            _User.LastName = ""
            _User.Email = ""
            _User.PasswordSalt = ""

            Dim _userAdd = _usermanager.Add(_User)
            msg = _userAdd.Id

        Catch ex As Exception
            msg = ex.Message
        End Try

        MsgBox(msg)

    End Sub

End Module
