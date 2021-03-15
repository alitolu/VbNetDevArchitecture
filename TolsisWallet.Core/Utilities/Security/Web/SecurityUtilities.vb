Imports System.Web.Security

Namespace Utilities.Security.Web
    Public Class SecurityUtilities
        Public Function FormsAuthTicketToIdentity(ByVal ticket As FormsAuthenticationTicket) As Identity
            Dim identity = New Identity With {
                .Id = Me.SetId(ticket),
                .Name = Me.SetName(ticket),
                .Email = Me.SetEmail(ticket),
                .Roles = Me.SetRoles(ticket),
                .FirstName = Me.SetFirstName(ticket),
                .LastName = Me.SetLastName(ticket),
                .AuthenticationType = SetAuthType(),
                .IsAuthenticated = SetIsAuthenticated()
            }
            Return identity
        End Function
        Private Function SetIsAuthenticated() As Boolean
            Return True
        End Function
        Private Function SetAuthType() As String
            Return "Forms"
        End Function
        Private Function SetLastName(ByVal ticket As FormsAuthenticationTicket) As String
            Dim data As String() = ticket.UserData.Split("|"c)
            Return data(3)
        End Function
        Private Function SetFirstName(ByVal ticket As FormsAuthenticationTicket) As String
            Dim data As String() = ticket.UserData.Split("|"c)
            Return data(2)
        End Function
        Private Function SetRoles(ByVal ticket As FormsAuthenticationTicket) As String()
            Dim data As String() = ticket.UserData.Split("|"c)
            Dim roles As String() = data(1).Split(New Char() {","c}, StringSplitOptions.RemoveEmptyEntries)
            Return roles
        End Function
        Private Function SetEmail(ByVal ticket As FormsAuthenticationTicket) As String
            Dim data As String() = ticket.UserData.Split("|"c)
            Return data(0)
        End Function
        Private Function SetName(ByVal ticket As FormsAuthenticationTicket) As String
            Return ticket.Name
        End Function
        Private Function SetId(ByVal ticket As FormsAuthenticationTicket) As Guid
            Dim data As String() = ticket.UserData.Split("|"c)
            Return New Guid(data(4))
        End Function

    End Class


End Namespace
