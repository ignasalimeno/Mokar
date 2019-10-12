Public Class NotaCreditoBE
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

    Private pID_Cliente As Integer
    Public Property ID_Cliente() As Integer
        Get
            Return pID_Cliente
        End Get
        Set(ByVal value As Integer)
            pID_Cliente = value
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

    Private pSaldo As Double
    Public Property Saldo() As Double
        Get
            Return pSaldo
        End Get
        Set(ByVal value As Double)
            pSaldo = value
        End Set
    End Property

    Private pMotivo As String
    Public Property Motivo() As String
        Get
            Return pMotivo
        End Get
        Set(ByVal value As String)
            pMotivo = value
        End Set
    End Property

    Private pEstado As Boolean
    Public Property Estado() As Boolean
        Get
            Return pEstado
        End Get
        Set(ByVal value As Boolean)
            pEstado = value
        End Set
    End Property

End Class
