Imports System.Data.Entity.ModelConfiguration
Imports TolsisWallet.Entity.Entities.Concrete

Namespace DataAccess.Concrete.EntityFramework.Mappings
    Public Class UserMap
        Inherits EntityTypeConfiguration(Of User)
        Public Sub New()
            ToTable("Users", "dbo")
            HasKey(Function(x) x.User_Id)
            [Property](Function(x) x.Guid).HasColumnName("Guid")
            [Property](Function(x) x.Email).HasColumnName("Email")
            [Property](Function(x) x.Password).HasColumnName("Password")
            [Property](Function(x) x.Name).HasColumnName("Name")
            [Property](Function(x) x.Last_Name).HasColumnName("Last_Name")
            [Property](Function(x) x.Phone).HasColumnName("Phone")
            [Property](Function(x) x.Email_Verify).HasColumnName("Email_Verify")
            [Property](Function(x) x.Phone_Verify).HasColumnName("Phone_Verify")
            [Property](Function(x) x.Record_Date).HasColumnName("Record_Date")
            [Property](Function(x) x.Update_Date).HasColumnName("Update_Date")
        End Sub

    End Class
End Namespace
