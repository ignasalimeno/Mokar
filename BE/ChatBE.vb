Public Class ChatBE
    Private pId As Integer
    Public Property Id() As Integer
        Get
            Return pId
        End Get
        Set(ByVal value As Integer)
            pId = value
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

    Private pMensaje As String
    Public Property Mensaje() As String
        Get
            Return pMensaje
        End Get
        Set(ByVal value As String)
            pMensaje = value
        End Set
    End Property

    Private pFechaHora As DateTime
    Public Property FechaHora() As DateTime
        Get
            Return pFechaHora
        End Get
        Set(ByVal value As DateTime)
            pFechaHora = value
        End Set
    End Property

    Private pLeido As Boolean
    Public Property Leido() As Boolean
        Get
            Return pLeido
        End Get
        Set(ByVal value As Boolean)
            pLeido = value
        End Set
    End Property

    Private pRespuesta As Boolean
    Public Property Respuesta() As Boolean
        Get
            Return pRespuesta
        End Get
        Set(ByVal value As Boolean)
            pRespuesta = value
        End Set
    End Property
End Class
