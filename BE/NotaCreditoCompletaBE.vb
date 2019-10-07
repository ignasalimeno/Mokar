Public Class NotaCreditoCompletaBE
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

    Private pID_Usuario As Integer
    Public Property ID_Usuario() As Integer
        Get
            Return pID_Usuario
        End Get
        Set(ByVal value As Integer)
            pID_Usuario = value
        End Set
    End Property

    Private pNombre As String
    Public Property Nombre() As String
        Get
            Return pNombre
        End Get
        Set(ByVal value As String)
            pNombre = value
        End Set
    End Property

    Private pApellido As String
    Public Property Apellido() As String
        Get
            Return pApellido
        End Get
        Set(ByVal value As String)
            pApellido = value
        End Set
    End Property

    Private pUsuario As String
    Public Property Usuario() As String
        Get
            Return pUsuario
        End Get
        Set(ByVal value As String)
            pUsuario = value
        End Set
    End Property

    Private pFecha As DateTime
    Public Property Fecha() As DateTime
        Get
            Return pFecha
        End Get
        Set(ByVal value As DateTime)
            pFecha = value
        End Set
    End Property

    Private pID_FacturaDetalle As Integer
    Public Property ID_FacturaDetalle() As Integer
        Get
            Return pID_FacturaDetalle
        End Get
        Set(ByVal value As Integer)
            pID_FacturaDetalle = value
        End Set
    End Property

    Private pID_Oferta As Integer
    Public Property NewProperty() As Integer
        Get
            Return pID_Oferta
        End Get
        Set(ByVal value As Integer)
            pID_Oferta = value
        End Set
    End Property


    Private pNombrePais As String
    Public Property NombrePais() As String
        Get
            Return pNombrePais
        End Get
        Set(ByVal value As String)
            pNombrePais = value
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
