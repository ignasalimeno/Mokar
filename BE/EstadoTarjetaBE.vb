Public Class EstadoTarjetaBE
    Implements MedioPago

    Private pID As Integer
    Public Property ID() As Integer
        Get
            Return pID
        End Get
        Set(ByVal value As Integer)
            pID = value
        End Set
    End Property

    Private pID_Tarjeta As Integer
    Public Property ID_Tarjeta() As Integer
        Get
            Return pID_Tarjeta
        End Get
        Set(ByVal value As Integer)
            pID_Tarjeta = value
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

    Private pNumero As String
    Public Property Numero() As String
        Get
            Return pNumero
        End Get
        Set(ByVal value As String)
            pNumero = value
        End Set
    End Property

    Private pCodSeguridad As Integer
    Public Property CodSeguridad() As Integer
        Get
            Return pCodSeguridad
        End Get
        Set(ByVal value As Integer)
            pCodSeguridad = value
        End Set
    End Property

    Private pMesVencimiento As Integer
    Public Property MesVencimiento() As Integer
        Get
            Return pMesVencimiento
        End Get
        Set(ByVal value As Integer)
            pMesVencimiento = value
        End Set
    End Property

    Private pAñoVencimeinto As Integer
    Public Property AñoVencimiento() As Integer
        Get
            Return pAñoVencimeinto
        End Get
        Set(ByVal value As Integer)
            pAñoVencimeinto = value
        End Set
    End Property

    Private pCancelada As Boolean
    Public Property Cancelada() As Boolean
        Get
            Return pCancelada
        End Get
        Set(ByVal value As Boolean)
            pCancelada = value
        End Set
    End Property

    Private pMonto As Double
    Public Property Monto() As Double
        Get
            Return pMonto
        End Get
        Set(ByVal value As Double)
            pMonto = value
        End Set
    End Property
End Class
