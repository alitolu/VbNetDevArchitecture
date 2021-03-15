Imports TolsisWallet.Business.Business.Abstract
Imports TolsisWallet.DAL.DataAccess.Abstract
Imports TolsisWallet.Core.Entities.Concrete
Imports TolsisWallet.Core
Imports TolsisWallet.Business.Business.ValidationRules.FluentValidation
Imports TolsisWallet.Core.Aspects.Autofac.Caching
Imports System.Web.UI

Namespace Business.Concrete.Managers
    Public Class UserManager
        Implements IUserService

        Private ReadOnly _userDal As IUserDal
        Public Sub New(ByVal userDal As IUserDal)
            _userDal = userDal
        End Sub
        Public Function GetAll() As List(Of User) Implements IUserService.GetAll
            Throw New NotImplementedException()
        End Function
        Public Function GetById(id As Integer) As User Implements IUserService.GetById
            Throw New NotImplementedException()
        End Function

        '<LogAspect(GetType(FileLogger))>
        '<CacheAspect()>
        <ValidationAspect(GetType(UserValidator))>
        Public Function Add(user As User) As User Implements IUserService.Add
            Return _userDal.Add(user)
        End Function
        Public Function Update(user As User) As User Implements IUserService.Update
            Return _userDal.Update(user)
        End Function
        Public Function GetByUserNameAndPassword(email As String, password As String) As User Implements IUserService.GetByUserNameAndPassword
            Return _userDal.Get(Function(u) u.Email = email And u.PasswordSalt = password)
        End Function

    End Class

End Namespace

