Imports System.Data.Entity.ModelConfiguration
Imports TolsisWallet.Core.Core.Entities.Concrete

Namespace DataAccess.Concrete.EntityFramework.Mappings
    Public Class UserMap
        Inherits EntityTypeConfiguration(Of User)
        Public Sub New()
            ToTable("Users", "dbo")
            HasKey(Function(x) x.Id)
            [Property](Function(x) x.Id).HasColumnName("Id")
            [Property](Function(x) x.Email).HasColumnName("Email")
            [Property](Function(x) x.PasswordSalt).HasColumnName("Password")
            [Property](Function(x) x.FirstName).HasColumnName("FirstName")
            [Property](Function(x) x.LastName).HasColumnName("LastName")
            '[Property](Function(x) x.Status).HasColumnName("Status")
        End Sub

    End Class
End Namespace
