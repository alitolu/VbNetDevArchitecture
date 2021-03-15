Imports System

Namespace Business.DependencyResolvers.Dependencies

    Public Class ViewDependency
        Implements IViewDependency
        Private _InstanceId As System.Guid
        Public Sub New()
            InstanceId = Guid.NewGuid()
        End Sub
        Public Property InstanceId As Guid Implements IViewDependency.InstanceId
            Get
                Return _InstanceId
            End Get
            Private Set(ByVal value As Guid)
                _InstanceId = value
            End Set
        End Property
    End Class
End Namespace
