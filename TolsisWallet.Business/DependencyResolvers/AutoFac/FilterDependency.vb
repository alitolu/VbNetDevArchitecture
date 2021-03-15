Namespace Business.DependencyResolvers.Dependencies
    Public Class FilterDependency
        Implements IFilterDependency

        Public ReadOnly Property CurrentTicks As Long Implements IFilterDependency.CurrentTicks
            Get
                Return Date.UtcNow.Ticks
            End Get
        End Property
    End Class
End Namespace
