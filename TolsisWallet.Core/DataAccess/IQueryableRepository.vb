Imports System.Linq

Namespace Core.DataAccess
    Public Interface IQueryableRepository(Of T As {Class, IEntity, New})
        ReadOnly Property Table As IQueryable(Of T)

    End Interface
End Namespace
