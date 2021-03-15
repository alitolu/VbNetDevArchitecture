Imports System.Security.Principal

Namespace Utilities.Security.Web
    Public Class Identity
        Implements IIdentity
        Public Property Name As String Implements IIdentity.Name
        Public Property AuthenticationType As String Implements IIdentity.AuthenticationType
        Public Property IsAuthenticated As Boolean Implements IIdentity.IsAuthenticated
        Public Property Id As Guid
        Public Property FirstName As String
        Public Property LastName As String
        Public Property Email As String
        Public Property Roles As String()

    End Class
End Namespace
