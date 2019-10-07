Imports System.Data.SqlClient
Imports BE
Imports DAL

Public Class ChatMPP
#Region "Singleton"
    Private Sub New()
    End Sub

    Private Shared Instancia As ChatMPP
    Public Shared Function ObtenerInstancia() As ChatMPP
        If Instancia Is Nothing Then
            Instancia = New ChatMPP
        End If
        Return Instancia
    End Function

#End Region

    Public Function ListarCantidadDeMensajes() As List(Of Chat2BE)
        Dim ListaMensajes As New List(Of Chat2BE)
        Dim hdatos As New Hashtable
        hdatos.Add("@tipoConsulta", 4)
        hdatos.Add("@idUsuario", DBNull.Value)
        hdatos.Add("@Mensaje", DBNull.Value)
        hdatos.Add("@FechaHora", DBNull.Value)
        hdatos.Add("@Respuesta", DBNull.Value)

        For Each row As DataRow In Datos.ObtenerInstancia.Leer("n_Chat_ABMC", hdatos).Tables(0).Rows
            Dim oChat As New Chat2BE With {.ID_Usuario = row("idUsuario"), .mail = row("mail"), .NoLeido = row("NoLeido")}
            ListaMensajes.Add(oChat)
        Next
        Return ListaMensajes
        Throw New Exception("Mokar informa que ha ocurrido un error")
    End Function
    Public Function ListarTodosMensajes() As List(Of ChatBE)
        Dim ListaMensajes As New List(Of ChatBE)
        Dim hdatos As New Hashtable
        hdatos.Add("@tipoConsulta", 5)
        hdatos.Add("@idUsuario", DBNull.Value)
        hdatos.Add("@Mensaje", DBNull.Value)
        hdatos.Add("@FechaHora", DBNull.Value)
        hdatos.Add("@Respuesta", DBNull.Value)

        For Each row As DataRow In Datos.ObtenerInstancia.Leer("n_Chat_ABMC", hdatos).Tables(0).Rows
            Dim oChat As New ChatBE With {.ID_Usuario = row("ID_Usuario"), .Mensaje = row("Mensaje"), .FechaHora = row("FechaHora"),
                .Leido = row("Leido"), .Respuesta = row("Respuesta")}
            ListaMensajes.Add(oChat)
        Next
        Return ListaMensajes
        Throw New Exception("Easy Travel informa que ha ocurrido un error")
    End Function

    Public Function ListarMensajes(ByVal ID As ChatBE) As ChatBE
        Dim hdatos As New Hashtable
        hdatos.Add("@tipoConsulta", 3)
        hdatos.Add("@idUsuario", ID.ID_Usuario)
        hdatos.Add("@Mensaje", DBNull.Value)
        hdatos.Add("@FechaHora", DBNull.Value)
        hdatos.Add("@Respuesta", DBNull.Value)

        Dim row As DataRow
        row = Datos.ObtenerInstancia.Leer("n_Chat_ABMC", hdatos).Tables(0).Rows(0)
        Dim oUser As New ChatBE With {.ID_Usuario = row("ID_Usuario"), .Mensaje = row("Mensaje"), .FechaHora = row("FechaHora"),
                .Leido = row("Leido"), .Respuesta = row("Respuesta")}
        Return oUser
        Throw New Exception("Easy travel informa que ha ocurrido un error")
    End Function

    Public Function NuevoMensaje(ByVal unChat As ChatBE) As Integer
        Dim hdatos As New Hashtable
        hdatos.Add("@tipoConsulta", 1)
        hdatos.Add("@idUsuario", unChat.ID_Usuario)
        hdatos.Add("@Mensaje", unChat.Mensaje)
        hdatos.Add("@FechaHora", unChat.FechaHora)
        hdatos.Add("@Respuesta", unChat.Respuesta)

        Return Datos.ObtenerInstancia.Escribir("n_Chat_ABMC", hdatos)
        Throw New Exception("Easy Travel informa que ha ocurrido un error")
    End Function

    Shared Sub LeerMensaje(ByRef Mensaje As Object)
        Dim Chat As New ChatBE
        Chat = DirectCast(Mensaje, ChatBE)

        Dim hdatos As New Hashtable
        hdatos.Add("@tipoConsulta", 2)
        hdatos.Add("@idUsuario", Chat.ID_Usuario)
        hdatos.Add("@Mensaje", DBNull.Value)
        hdatos.Add("@FechaHora", DBNull.Value)
        hdatos.Add("@Respuesta", Chat.Respuesta)


        Datos.ObtenerInstancia.Escribir("n_Chat_ABMC", hdatos)
    End Sub

    Shared Function NotificarNuevoMensaje(ByRef Mensaje As Object, Respuesta As Boolean) As DataSet
        Dim Usuario As New UsuarioBE
        Usuario = DirectCast(Mensaje, UsuarioBE)

        Dim hdatos As New Hashtable
        hdatos.Add("@tipoConsulta", 6)
        If Mensaje Is Nothing Then
            hdatos.Add("@idUsuario", DBNull.Value)
        Else
            hdatos.Add("@idUsuario", Usuario.idUsuario)

        End If
        hdatos.Add("@Mensaje", DBNull.Value)
        hdatos.Add("@FechaHora", DBNull.Value)
        hdatos.Add("@Respuesta", Respuesta)


        Return Datos.ObtenerInstancia.Leer("n_Chat_ABMC", hdatos)
    End Function

    Public Function ObtenerMensajexUser(id As Integer) As List(Of ChatBE)
        Dim ListaM As New List(Of ChatBE)

        Dim hdatos As New Hashtable
        hdatos.Add("@tipoConsulta", 7)
        hdatos.Add("@idUsuario", id)
        hdatos.Add("@Mensaje", DBNull.Value)
        hdatos.Add("@FechaHora", DBNull.Value)
        hdatos.Add("@Respuesta", DBNull.Value)


        Dim dt As DataTable = Datos.ObtenerInstancia.Leer("n_Chat_ABMC", hdatos).Tables(0)
        For Each row As DataRow In dt.Rows
            Dim oM As New ChatBE With {.Id = row("idChat"), .ID_Usuario = row("idUsuario"), .Mensaje = row("Mensaje"),
                .FechaHora = row("FechaHora"), .Leido = row("Leido"), .Respuesta = row("Respuesta")}
            ListaM.Add(oM)
        Next
        Return ListaM
    End Function

End Class
