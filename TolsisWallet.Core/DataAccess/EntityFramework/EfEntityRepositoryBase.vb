Imports System
Imports System.Collections.Generic
Imports System.Linq.Expressions
Imports System.Data.Entity

Namespace Core.DataAccess.EntityFramework
    Public Class EfEntityRepositoryBase(Of TEntity As {Class, IEntity, New}, TContext As {DbContext, New})
        Implements IEntityRepository(Of TEntity)
        Private Function GetList(Optional filter As Expression(Of Func(Of TEntity, Boolean)) = Nothing) As List(Of TEntity) Implements IEntityRepository(Of TEntity).GetList
            Using context = New TContext()
                Return If(filter Is Nothing, context.[Set](Of TEntity)().ToList(), context.[Set](Of TEntity)().Where(filter).ToList())
            End Using
        End Function
        Private Function [Get](filter As Expression(Of Func(Of TEntity, Boolean))) As TEntity Implements IEntityRepository(Of TEntity).Get
            Using context = New TContext()
                Return context.[Set](Of TEntity)().SingleOrDefault(filter)
            End Using
        End Function
        Private Function Add(entity As TEntity) As TEntity Implements IEntityRepository(Of TEntity).Add
            Using context = New TContext()
                Dim addedEntity = context.Entry(entity)
                addedEntity.State = EntityState.Added
                context.SaveChanges()
                Return entity
            End Using
        End Function
        Private Function Update(entity As TEntity) As TEntity Implements IEntityRepository(Of TEntity).Update
            Using context = New TContext()
                Dim updatedEntity = context.Entry(entity)
                updatedEntity.State = EntityState.Modified
                context.SaveChanges()
                Return entity
            End Using
        End Function
        Private Sub Delete(entity As TEntity) Implements IEntityRepository(Of TEntity).Delete
            Using context = New TContext()
                Dim deletedEntity = context.Entry(entity)
                deletedEntity.State = EntityState.Deleted
                context.SaveChanges()
            End Using
        End Sub
    End Class
End Namespace
