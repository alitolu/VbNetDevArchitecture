Imports TolsisWallet.Core.Core.DataAccess
Namespace Entities.Concrete
    Public Class User
        Implements IEntity
        Public Property Guid As Guid
        Public Property User_Id As Integer
        Public Property Email As String
        Public Property Password As String
        Public Property Name As String
        Public Property Last_Name As String
        Public Property Phone As String
        Public Property Email_Verify As Boolean
        Public Property Phone_Verify As Boolean
        Public Property Record_Date As DateTime
        Public Property Update_Date As DateTime

    End Class

End Namespace