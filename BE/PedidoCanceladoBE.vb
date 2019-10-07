Public Class PedidoCanceladoBE
    Private pID As Integer
    Public Property ID() As Integer
        Get
            Return pID
        End Get
        Set(ByVal value As Integer)
            pID = value
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

    Private pUsuario As String
    Public Property Usuario() As String
        Get
            Return pUsuario
        End Get
        Set(ByVal value As String)
            pUsuario = value
        End Set
    End Property

    Private pFecha As Date
    Public Property Fecha() As Date
        Get
            Return pFecha
        End Get
        Set(ByVal value As Date)
            pFecha = value
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

End Class
