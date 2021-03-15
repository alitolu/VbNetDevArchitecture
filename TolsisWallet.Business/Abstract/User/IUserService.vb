
Imports TolsisWallet.Core.Entities.Concrete

Namespace Business.Abstract
    Public Interface IUserService
        Function GetAll() As List(Of User)
        Function GetById(ByVal id As Integer) As User
        Function Add(ByVal user As User) As User
        Function Update(ByVal user As User) As User
        Function GetByUserNameAndPassword(ByVal email As String, ByVal password As String) As User

    End Interface

End Namespace
