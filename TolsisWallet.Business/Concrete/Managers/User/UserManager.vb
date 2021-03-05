Imports TolsisWallet.Business.Business.Abstract
Imports TolsisWallet.DAL.DataAccess.Abstract
Imports TolsisWallet.Core.Core.Entities.Concrete

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
        Public Function Add(user As User) As User Implements IUserService.Add
            Return _userDal.Add(user)
        End Function
        Public Function Update(user As User) As User Implements IUserService.Update
            Return _userDal.Update(user)
        End Function
        Public Function GetByUserNameAndPassword(email As String, password As String) As User Implements IUserService.GetByUserNameAndPassword
            Return _userDal.Get(Function(u) u.Email = email And u.PasswordSalt = password)
        End Function
        Public Function GetClaims(user As User) As List(Of OperationClaim) Implements IUserService.GetClaims
            Return _userDal.GetClaims(user)
        End Function
    End Class

End Namespace

