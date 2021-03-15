Imports System.Data.Entity.ModelConfiguration
Imports TolsisWallet.Core.Entities.Concrete

Namespace DataAccess.Concrete.EntityFramework.Mappings
    Public Class UserMap
        Inherits EntityTypeConfiguration(Of User)
        Public Sub New()
            ToTable("Users", "dbo")
            HasKey(Function(x) x.Id)
            [Property](Function(x) x.Id).HasColumnName("Id")
            [Property](Function(x) x.UserCode).HasColumnName("UserCode")
            [Property](Function(x) x.UserName).HasColumnName("UserName")
            [Property](Function(x) x.PasswordSalt).HasColumnName("Password")
            [Property](Function(x) x.FirstName).HasColumnName("FirstName")
            [Property](Function(x) x.LastName).HasColumnName("LastName")
            [Property](Function(x) x.Email).HasColumnName("Email")
            [Property](Function(x) x.MobilePhone).HasColumnName("MobilePhone")
            [Property](Function(x) x.Status).HasColumnName("Status")
            [Property](Function(x) x.SmsVerify).HasColumnName("SmsVerify")
            [Property](Function(x) x.EmailVerify).HasColumnName("EmailVerify")
            [Property](Function(x) x.LastPasswordDate).HasColumnName("LastPasswordDate")
            [Property](Function(x) x.WrongPassTry).HasColumnName("WrongPassTry")
            [Property](Function(x) x.RecordDate).HasColumnName("RecordDate")
            [Property](Function(x) x.UpdateDate).HasColumnName("UpdateDate")
        End Sub

    End Class
End Namespace
