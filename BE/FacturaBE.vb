Public Class FacturaBE
    Private pID As Integer
    Public Property ID() As Integer
        Get
            Return pID
        End Get
        Set(ByVal value As Integer)
            pID = value
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

    'Private pNombreOferta As String
    'Public Property NombreOferta() As String
    '    Get
    '        Return pNombreOferta
    '    End Get
    '    Set(ByVal value As String)
    '        pNombreOferta = value
    '    End Set
    'End Property

    Private pDescripcion As String
    Public Property Descripcion() As String
        Get
            Return pDescripcion
        End Get
        Set(ByVal value As String)
            pDescripcion = value
        End Set
    End Property

    'Private pPrecioUnitario As Double
    'Public Property PrecioUnitario() As Double
    '    Get
    '        Return pPrecioUnitario
    '    End Get
    '    Set(ByVal value As Double)
    '        pPrecioUnitario = value
    '    End Set
    'End Property

    'Private pCantidad As Integer
    'Public Property Cantidad() As Integer
    '    Get
    '        Return pCantidad
    '    End Get
    '    Set(ByVal value As Integer)
    '        pCantidad = value
    '    End Set
    'End Property

    Private pTotal As Double
    Public Property Total() As Double
        Get
            Return pTotal
        End Get
        Set(ByVal value As Double)
            pTotal = value
        End Set
    End Property

    'Private pSubtotal As Double
    'Public Property Subtotal() As Double
    '    Get
    '        Return pSubtotal
    '    End Get
    '    Set(ByVal value As Double)
    '        pSubtotal = value
    '    End Set
    'End Property

    'Private pIVA As Integer
    'Public Property IVA() As Integer
    '    Get
    '        Return pIVA
    '    End Get
    '    Set(ByVal value As Integer)
    '        pIVA = value
    '    End Set
    'End Property

    'Private pTotalFinal As Double
    'Public Property TotalFinal() As Double
    '    Get
    '        Return pTotalFinal
    '    End Get
    '    Set(ByVal value As Double)
    '        pTotalFinal = value
    '    End Set
    'End Property

    'Private pPath As String
    'Public Property Path() As String
    '    Get
    '        Return pPath
    '    End Get
    '    Set(ByVal value As String)
    '        pPath = value
    '    End Set
    'End Property

    Private pCancelada As Boolean
    Public Property Cancelada() As Boolean
        Get
            Return pCancelada
        End Get
        Set(ByVal value As Boolean)
            pCancelada = value
        End Set
    End Property

    Private pSeguimiento As String
    Public Property Seguimiento() As String
        Get
            Return pSeguimiento
        End Get
        Set(ByVal value As String)
            pSeguimiento = value
        End Set
    End Property

End Class
