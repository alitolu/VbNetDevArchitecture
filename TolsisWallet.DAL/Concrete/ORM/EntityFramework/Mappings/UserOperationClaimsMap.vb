Imports System.Data.Entity.ModelConfiguration
Imports TolsisWallet.Core.Core.Entities.Concrete

Namespace DataAccess.Concrete.EntityFramework.Mappings
    Public Class UserOperationClaimsMap
        Inherits EntityTypeConfiguration(Of UserOperationClaim)
        Public Sub New()
            ToTable("UserRoles", "dbo")
            HasKey(Function(x) x.Id)
            [Property](Function(x) x.Id).HasColumnName("Id")
            [Property](Function(x) x.UserId).HasColumnName("UserId")
            [Property](Function(x) x.OperationClaimId).HasColumnName("RoleId")
        End Sub

    End Class
End Namespace
