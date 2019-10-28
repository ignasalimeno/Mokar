Public Class Backup_RestoreBE
    Private pID As Integer
    Public Property ID() As Integer
        Get
            Return pID
        End Get
        Set(ByVal value As Integer)
            pID = value
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

    Private Ppath As String
    Public Property Path() As String
        Get
            Return Ppath
        End Get
        Set(ByVal value As String)
            Ppath = value
        End Set
    End Property

    Private Pfecha As DateTime
    Public Property Fecha() As DateTime
        Get
            Return Pfecha
        End Get
        Set(ByVal value As DateTime)
            Pfecha = value
        End Set
    End Property

    Private pTamaño As String
    Public Property Tamaño() As String
        Get
            Return pTamaño
        End Get
        Set(ByVal value As String)
            pTamaño = value
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

End Class
