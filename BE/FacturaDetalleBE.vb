Public Class FacturaDetalleBE
    Private pID As Integer
    Public Property ID() As Integer
        Get
            Return pID
        End Get
        Set(ByVal value As Integer)
            pID = value
        End Set
    End Property

    Private pID_Factura As Integer
    Public Property ID_Factura() As Integer
        Get
            Return pID_Factura
        End Get
        Set(ByVal value As Integer)
            pID_Factura = value
        End Set
    End Property

    Private pID_Oferta As Integer
    Public Property ID_Oferta() As Integer
        Get
            Return pID_Oferta
        End Get
        Set(ByVal value As Integer)
            pID_Oferta = value
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

    Private pPrecioUnitario As Double
    Public Property PrecioUnitario() As Double
        Get
            Return pPrecioUnitario
        End Get
        Set(ByVal value As Double)
            pPrecioUnitario = value
        End Set
    End Property

    Private pCantidad As Integer
    Public Property Cantidad() As Integer
        Get
            Return pCantidad
        End Get
        Set(ByVal value As Integer)
            pCantidad = value
        End Set
    End Property

    Private pTotal As Double
    Public Property Total() As Double
        Get
            Return pTotal
        End Get
        Set(ByVal value As Double)
            pTotal = value
        End Set
    End Property

End Class
