Imports System.Linq.Expressions

Namespace Core.DataAccess
    Public Interface IEntityRepository(Of T As {Class, IEntity, New})
        Function GetList(ByVal Optional filter As Expression(Of Func(Of T, Boolean)) = Nothing) As List(Of T)
        Function [Get](ByVal filter As Expression(Of Func(Of T, Boolean))) As T
        Function Add(ByVal entity As T) As T
        Function Update(ByVal entity As T) As T
        Sub Delete(ByVal entity As T)

    End Interface

End Namespace
