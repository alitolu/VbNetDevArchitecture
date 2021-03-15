Namespace CrossCuttingConcerns.Caching
    Public Interface ICacheManager
        Function [Get](Of T)(ByVal key As String) As T
        Function [Get](ByVal key As String) As Object
        Sub Add(ByVal key As String, ByVal data As Object, ByVal duration As Integer)
        Function IsAdd(ByVal key As String) As Boolean
        Sub Remove(ByVal key As String)
        Sub RemoveByPattern(ByVal pattern As String)

    End Interface
End Namespace
