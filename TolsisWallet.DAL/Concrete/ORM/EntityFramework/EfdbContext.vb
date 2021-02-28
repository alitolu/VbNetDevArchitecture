Imports System.Data.Entity
Imports TolsisWallet.DAL.DataAccess.Concrete.EntityFramework.Mappings
Imports TolsisWallet.Core.Core.Entities.Concrete
Imports System.Configuration
Namespace DataAccess.Concrete.EntityFramework

    Public Class EfdbContext
        Inherits DbContext
        Public Sub New()
            MyBase.New(ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString)
            Database.SetInitializer(Of EfdbContext)(New DropCreateDatabaseIfModelChanges(Of EfdbContext)())
        End Sub
        Public Property Users As DbSet(Of User)
        Protected Overrides Sub OnModelCreating(ByVal modelBuilder As DbModelBuilder)
            modelBuilder.Configurations.Add(New UserMap())
        End Sub
    End Class

End Namespace
