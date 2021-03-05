Imports System.Data.Entity
Imports TolsisWallet.DAL.DataAccess.Concrete.EntityFramework.Mappings
Imports TolsisWallet.Core.Core.Entities.Concrete
Imports System.Configuration
Namespace DataAccess.Concrete.EntityFramework

    Public Class EfdbContext
        Inherits DbContext
        Public Sub New()
            Database.SetInitializer(Of EfdbContext)(Nothing)
        End Sub
        Public Property Users As DbSet(Of User)
        Public Property OperationClaims As DbSet(Of OperationClaim)
        Public Property UserOperationClaims As DbSet(Of UserOperationClaim)
        Protected Overrides Sub OnModelCreating(ByVal modelBuilder As DbModelBuilder)
            modelBuilder.Configurations.Add(New UserMap())
            modelBuilder.Configurations.Add(New UserOperationClaimsMap())
            modelBuilder.Configurations.Add(New OperationClaimsMap())
        End Sub

    End Class

End Namespace
