Imports System.Collections.Generic
Imports System.Linq
Imports System.Security.Claims
Imports System.Runtime.CompilerServices

Namespace Core.Extensions
    Public Module ClaimsPrincipalExtensions
        <Extension()>
        Public Function Claims(ByVal claimsPrincipal As ClaimsPrincipal, ByVal claimType As String) As List(Of String)
            Dim result = claimsPrincipal?.FindAll(claimType)?.[Select](Function(x) x.Value).ToList()
            Return result
        End Function
        '<Extension()>
        'Public Function ClaimRoles(ByVal claimsPrincipal As ClaimsPrincipal) As String
        '    Return claimsPrincipal?.Claims(ClaimTypes.Role)
        'End Function
    End Module
End Namespace
