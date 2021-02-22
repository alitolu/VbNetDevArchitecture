Imports System.Collections.Generic
Imports System.Linq.Expressions
Imports TolsisWallet.Core.Core.DataAccess
Imports TolsisWallet.Core.Core.DataAccess.EntityFramework
Imports TolsisWallet.DAL.DataAccess.Abstract
Imports TolsisWallet.Entity.Entities.Concrete

Namespace DataAccess.Concrete.EntityFramework
    Public Class EfUserDal
        Inherits EfEntityRepositoryBase(Of User, EfdbContext)
        Implements IUserDal

        Public Sub Delete(entity As Core.Core.Entities.Concrete.User) Implements IEntityRepository(Of Core.Core.Entities.Concrete.User).Delete
            Throw New NotImplementedException()
        End Sub

        Public Function GetList(Optional filter As Expression(Of Func(Of Core.Core.Entities.Concrete.User, Boolean)) = Nothing) As List(Of Core.Core.Entities.Concrete.User) Implements IEntityRepository(Of Core.Core.Entities.Concrete.User).GetList
            Throw New NotImplementedException()
        End Function

        Public Function [Get](filter As Expression(Of Func(Of Core.Core.Entities.Concrete.User, Boolean))) As Core.Core.Entities.Concrete.User Implements IEntityRepository(Of Core.Core.Entities.Concrete.User).Get
            Throw New NotImplementedException()
        End Function

        Public Function Add(entity As Core.Core.Entities.Concrete.User) As Core.Core.Entities.Concrete.User Implements IEntityRepository(Of Core.Core.Entities.Concrete.User).Add
            Throw New NotImplementedException()
        End Function

        Public Function Update(entity As Core.Core.Entities.Concrete.User) As Core.Core.Entities.Concrete.User Implements IEntityRepository(Of Core.Core.Entities.Concrete.User).Update
            Throw New NotImplementedException()
        End Function

    End Class
End Namespace
