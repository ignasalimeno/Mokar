Public Class Chat2BE
    Private pID_Usuario As Integer
    Public Property ID_Usuario() As Integer
        Get
            Return pID_Usuario
        End Get
        Set(ByVal value As Integer)
            pID_Usuario = value
        End Set
    End Property

    Private pmail As String
    Public Property mail() As String
        Get
            Return pmail
        End Get
        Set(ByVal value As String)
            pmail = value
        End Set
    End Property

    Private pNoLeido As Integer
    Public Property NoLeido() As Integer
        Get
            Return pNoLeido
        End Get
        Set(ByVal value As Integer)
            pNoLeido = value
        End Set
    End Property

    Property idChat As Integer

End Class
