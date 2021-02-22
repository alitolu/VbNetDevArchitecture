Imports System.Data.Entity
Imports TolsisWallet.DAL.DataAccess.Concrete.EntityFramework.Mappings
Imports TolsisWallet.Entity
Imports TolsisWallet.Entity.Entities.Concrete

Namespace DataAccess.Concrete.EntityFramework

    Public Class EfdbContext

        Inherits DbContext
        Public Sub New()
            Database.SetInitializer(Of EfdbContext)(Nothing)
        End Sub
        Public Property Users As DbSet(Of User)
        Protected Overrides Sub OnModelCreating(ByVal modelBuilder As DbModelBuilder)
            modelBuilder.Configurations.Add(New UserMap())
        End Sub

    End Class


End Namespace
