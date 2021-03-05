Imports System.Data.Entity.ModelConfiguration
Imports TolsisWallet.Core.Core.Entities.Concrete

Namespace DataAccess.Concrete.EntityFramework.Mappings
    Public Class OperationClaimsMap
        Inherits EntityTypeConfiguration(Of OperationClaim)
        Public Sub New()
            ToTable("Roles", "dbo")
            HasKey(Function(x) x.Id)
            [Property](Function(x) x.Id).HasColumnName("Id")
            [Property](Function(x) x.Name).HasColumnName("Name")
        End Sub
    End Class
End Namespace
