Public Class CuentaCorrienteBE
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

    Private pID_Factura As Integer
    Public Property ID_Factura() As Integer
        Get
            Return pID_Factura
        End Get
        Set(ByVal value As Integer)
            pID_Factura = value
        End Set
    End Property

    Private pID_NotaCredito As Integer
    Public Property ID_NotaCredito() As Integer
        Get
            Return pID_NotaCredito
        End Get
        Set(ByVal value As Integer)
            pID_NotaCredito = value
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

    Private pDebito As Integer
    Public Property Debito() As Integer
        Get
            Return pDebito
        End Get
        Set(ByVal value As Integer)
            pDebito = value
        End Set
    End Property

    Private pCredito As Integer
    Public Property Credito() As Integer
        Get
            Return pCredito
        End Get
        Set(ByVal value As Integer)
            pCredito = value
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

    Private pFecha As DateTime
    Public Property Fecha() As DateTime
        Get
            Return pFecha
        End Get
        Set(ByVal value As DateTime)
            pFecha = value
        End Set
    End Property

End Class
