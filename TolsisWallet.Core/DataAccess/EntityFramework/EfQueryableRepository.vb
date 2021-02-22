Imports System.Data.Entity
Imports System.Linq

Namespace Core.DataAccess.EntityFramework
    Public Class EfQueryableRepository(Of T As {Class, IEntity, New})
        Implements IQueryableRepository(Of T)
        Private _context As DbContext
        Private _entities As IDbSet(Of T)
        Public Sub New(ByVal context As DbContext)
            _context = context
        End Sub
        Protected Overridable ReadOnly Property Entities As IDbSet(Of T)
            Get
                Return If(_entities, Function()
                                         _entities = _context.[Set](Of T)()
                                         Return _entities
                                     End Function())
            End Get
        End Property
        Private ReadOnly Property Table As IQueryable(Of T) Implements IQueryableRepository(Of T).Table
            Get
                Return Entities
            End Get
        End Property
    End Class
End Namespace
