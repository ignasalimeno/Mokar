Imports BE
Imports BLL

Public Class Chat
    Inherits System.Web.UI.Page
    Dim mensajeMokar As String
    Dim ChatBE As New ChatBE
    Dim Respuesta As Boolean = True


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then

                Dim User As New UsuarioBE
                User = GestorSesion.ObtenerSesionActual.UsuarioActivo
                Session("IDUser") = User.idUsuario


                ''Validar si es interno o externo
                If User.tipoUsuario = 1 Then
                    Session("UsuarioBackend") = User
                ElseIf User.tipoUsuario = 2 Then
                    Session("UsuarioFinal") = User
                End If

                Session("Fila") = Nothing
                If Session("UsuarioFinal") IsNot Nothing Then
                    divChatChat.Visible = True
                    Respuesta = False
                    ChatBE.ID_Usuario = DirectCast(Session("UsuarioFinal"), UsuarioBE).idUsuario
                    ChatBE.Respuesta = True
                    ChatBLL.ObtenerInstancia.LeerMensaje(ChatBE)
                    divChatCantidadNoLeidos.Visible = False
                    CargarLista()
                    CargarChat()
                Else
                    divChatChat.Visible = False
                    Respuesta = True
                    divChatCantidadNoLeidos.Visible = True
                    Session("ChatsTotales") = ChatBLL.ObtenerInstancia.ListarCantidadDeMensajes
                    DG_Chats.DataSource = DirectCast(Session("ChatsTotales"), List(Of Chat2BE))
                    DG_Chats.DataBind()

                    'CargarChat()

                End If
            End If

        Catch ex As Exception
            mensajeMokar = "Mokar informa:" & ex.Message
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & mensajeMokar & "')", True)
        End Try
    End Sub

    Sub BindData()
        CargarLista()
    End Sub

    Private Sub CargarLista()
        If Session("UsuarioFinal") IsNot Nothing Then
            Session("Chat") = ChatBLL.ObtenerInstancia.ObtenerMensajexUser(Session("IDUser"))
        Else
            Session("Chat") = ChatBLL.ObtenerInstancia.ObtenerMensajexUser(Session("IDUsuarioSeleccionado"))
        End If
    End Sub

    Private Sub CargarChat()
        Try
            Dim Iterador As Integer = 0
            Dim Chat As String = ""
            ulChatVentana.InnerHtml = ""

            For Each Mensaje In TryCast(Session("Chat"), List(Of ChatBE))
                If (Session("UsuarioFinal") Is Nothing And Mensaje.Respuesta = True) Or (Session("UsuarioFinal") IsNot Nothing And Mensaje.Respuesta = False) Then
                    Chat += "<li class=""left clearfix"">" &
                                "<div class=""chat-body clearfix"">" &
                                    "<div class=""header"">" &
                                        "<small class=""pull-right text-muted"">" &
                                            "<span class=""glyphicon glyphicon-time""></span>" & Mensaje.FechaHora & "</small>" &
                                    "</div>" &
                                    "</br><div class=""pull-right""><p>" & Mensaje.Mensaje & "</p></div>" &
                                "</div>" &
                            "</li>"
                Else
                    Chat += "<li class=""right clearfix"">" &
                                "<div class=""chat-body clearfix"">" &
                                    "<div class=""header"">" &
                                        "<small class=""pull-left text-muted"">" &
                                            "<span class=""glyphicon glyphicon-time""></span>" & Mensaje.FechaHora & "</small>" &
                                    "</div>" &
                                    "</br><div class=""pull-left""><p>" & Mensaje.Mensaje & "</p></div>" &
                                "</div>" &
                            "</li>"
                End If
            Next
            ulChatVentana.InnerHtml = Chat
        Catch ex As Exception
            mensajeMokar = "Mokar informa: " & ex.Message
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & mensajeMokar & "')", True)
        End Try
    End Sub


    Private Sub DG_Chats_SelectedIndexChanging(sender As Object, e As GridViewSelectEventArgs) Handles DG_Chats.SelectedIndexChanging
        Try

            If Not Session("Fila") Is Nothing Then
                DG_Chats.Rows(Session("Fila")).Style.Remove("background-color")
            End If
            Session("IDUsuarioSeleccionado") = DirectCast(Session("ChatsTotales"), List(Of Chat2BE))(DG_Chats.Rows(e.NewSelectedIndex).DataItemIndex).ID_Usuario
            Session("Fila") = e.NewSelectedIndex
            DG_Chats.Rows(Session("Fila")).Style.Add("background-color", "#449d44")
            ChatBE.ID_Usuario = Session("IDUsuarioSeleccionado")
            ChatBE.Respuesta = False

            Session("horaPregunta") = ChatBLL.ObtenerInstancia.LeerHoraMensaje(DirectCast(Session("ChatsTotales"), List(Of Chat2BE))(DG_Chats.Rows(e.NewSelectedIndex).DataItemIndex).idChat)

            ChatBLL.ObtenerInstancia.LeerMensaje(ChatBE)

            divChatChat.Visible = True
            CargarLista()
            CargarChat()
        Catch ex As Exception
            mensajeMokar = "Mokar: " & ex.Message
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & mensajeMokar & "')", True)
        End Try
    End Sub

    Private Sub btnChatEnviar_ServerClick(sender As Object, e As EventArgs) Handles btnChatEnviar.Click

        Try
            If Session("UsuarioFinal") Is Nothing Then
                ChatBE.ID_Usuario = Session("IDUsuarioSeleccionado")
                ChatBE.Mensaje = txtChatMensaje.Value
                ChatBE.FechaHora = Now
                ChatBE.Respuesta = True
                ChatBE.TiempoRta = DateDiff(DateInterval.Second, Session("horaPregunta"), Now)
                ChatBLL.ObtenerInstancia.NuevoMensaje(ChatBE)
            Else
                ChatBE.ID_Usuario = GestorSesion.ObtenerSesionActual.UsuarioActivo.idUsuario
                ChatBE.Mensaje = txtChatMensaje.Value
                ChatBE.FechaHora = DateTime.Now
                ChatBE.Respuesta = False
                ChatBE.TiempoRta = DateDiff(DateInterval.Second, Now, Session("horaPregunta"))
                ChatBLL.ObtenerInstancia.NuevoMensaje(ChatBE)
            End If
            CargarLista()
            CargarChat()
            txtChatMensaje.Value = ""
        Catch ex As Exception
            mensajeMokar = "Mokar: " & ex.Message
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & mensajeMokar & "')", True)
        End Try
    End Sub



End Class