Public Class MediodePagoBE

    Private pID As Int16
    Public Property ID() As Int16
        Get
            Return pID
        End Get
        Set(ByVal value As Int16)
            pID = value
        End Set
    End Property

    Private pDescripcion As String
    Public Property Descripcion() As String
        Get
            Return pDescripcion
        End Get
        Set(ByVal value As String)
            pDescripcion = value
        End Set
    End Property
End Class
