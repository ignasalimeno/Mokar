Imports BE
Imports MPP

Public Class ChatBLL
#Region "Singleton"
    Private Sub New()
    End Sub

    Private Shared Instancia As ChatBLL
    Public Shared Function ObtenerInstancia() As ChatBLL
        If Instancia Is Nothing Then
            Instancia = New ChatBLL
        End If
        Return Instancia
    End Function

#End Region

    Dim ChatENT As ChatBE
    Dim ChatCantidadENT As Chat2BE

    Public Function ListarTodosLosMensajes() As List(Of ChatBE)
        Return ChatMPP.ObtenerInstancia.ListarTodosMensajes
    End Function

    Public Function ListarCantidadDeMensajes() As List(Of Chat2BE)
        Return ChatMPP.ObtenerInstancia.ListarCantidadDeMensajes
    End Function

    Public Function ListarMensajes(ByVal usuario As ChatBE) As ChatBE
        Return ChatMPP.ObtenerInstancia.ListarMensajes(usuario)
    End Function

    Public Sub NuevoMensaje(ByRef unChat As ChatBE)
        ChatMPP.ObtenerInstancia.NuevoMensaje(unChat)
    End Sub

    Public Sub LeerMensaje(ByRef Mensaje As Object)
        ChatMPP.LeerMensaje(Mensaje)
    End Sub

    Public Function NotificarNuevoMensaje(ByRef Mensaje As Object, Respuesta As Boolean) As Integer
        Dim Flag As Integer = 0
        Dim lector As IDataReader = ChatMPP.NotificarNuevoMensaje(Mensaje, Respuesta).CreateDataReader
        Do While lector.Read()
            Flag = lector(0)
        Loop
        Return Flag
    End Function

    'Obtener por ID del usuario
    Public Function ObtenerMensajexUser(ByVal ID As Integer) As List(Of ChatBE)
        Return ChatMPP.ObtenerInstancia.ObtenerMensajexUser(ID)
    End Function

    Public Function ListarRespuestasNoLeidas(ID As UsuarioBE) As Integer
        Try
            Return ChatMPP.ObtenerInstancia.ListarRespuestasNoLeidas(ID)
        Catch ex As Exception
            Return 0
        End Try
    End Function
End Class
