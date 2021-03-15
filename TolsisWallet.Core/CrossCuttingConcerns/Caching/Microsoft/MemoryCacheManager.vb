Imports System
Imports System.Collections.Generic
Imports System.Runtime.Caching
Imports System.Text.RegularExpressions
Imports TolsisWallet.Core.CrossCuttingConcerns.Caching

Namespace CrossCuttingConcerns.Caching.Microsoft
    Public Class MemoryCacheManager
        Implements ICacheManager

        Protected ReadOnly Property Cache As ObjectCache
            Get
                Return MemoryCache.Default
            End Get
        End Property

        Public Function [Get](Of T)(ByVal key As String) As T Implements ICacheManager.Get
            Return CType(Me.Cache(key), T)
        End Function

        Public Sub Add(key As String, data As Object, duration As Integer) Implements ICacheManager.Add
            Dim cacheTime As Integer = 60
            If data Is Nothing Then
                Return
            End If

            Dim policy = New CacheItemPolicy With {
            .AbsoluteExpiration = Date.Now + TimeSpan.FromMinutes(cacheTime)
        }
            Cache.Add(New CacheItem(key, data), policy)
        End Sub

        Public Function IsAdd(ByVal key As String) As Boolean Implements ICacheManager.IsAdd
            Return Cache.Contains(key)
        End Function

        Public Sub Remove(ByVal key As String) Implements ICacheManager.Remove
            Cache.Remove(key)
        End Sub

        Public Sub RemoveByPattern(ByVal pattern As String) Implements ICacheManager.RemoveByPattern
            Dim regex = New Regex(pattern, RegexOptions.Singleline Or RegexOptions.Compiled Or RegexOptions.IgnoreCase)
            Dim keysToRemove = Cache.Where(Function(d) regex.IsMatch(d.Key)).[Select](Function(d) d.Key).ToList()

            For Each key In keysToRemove
                Remove(key)
            Next
        End Sub

        Public Sub Clear()
            For Each item In Cache
                Remove(item.Key)
            Next
        End Sub
        Public Function [Get](key As String) As Object Implements ICacheManager.Get
            Return Cache.Get(key)
        End Function
    End Class
End Namespace
