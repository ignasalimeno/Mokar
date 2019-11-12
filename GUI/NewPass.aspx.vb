Imports BE
Imports BLL

Public Class NewPass
    Inherits System.Web.UI.Page

    Dim ID_Buscada As Integer
    Dim mensaje As String
    Dim UsuarioLoguedo As New UsuarioBE

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

        End If
    End Sub

    Private Sub btn_Enviar_Click(sender As Object, e As EventArgs) Handles btn_Enviar.Click
        Try
            If Request.QueryString("ID_Usuario") Is Nothing Then
                ID_Buscada = GestorSesion.ObtenerSesionActual.UsuarioActivo.idUsuario
            Else
                ID_Buscada = CInt(Criptografia.Desencriptar(Request.QueryString("ID_Usuario")))

            End If

            If TB_Pass.Text.Trim = "" Or TB_Pass2.Text.Trim = "" Then
                Throw New Exception("Ingrese los campos de contraseña")
            End If

            If TB_Pass.Text = TB_Pass2.Text Then
                Dim NewPass As New UsuarioBE With {.idUsuario = ID_Buscada, .contraseña = TB_Pass.Text}
                Dim UsuarioActual As UsuarioBE = UsuarioBLL.ObtenerInstancia.ListarObjeto(NewPass)
                UsuarioActual.contraseña = TB_Pass.Text
                UsuarioBLL.ObtenerInstancia.ActualizarPass(UsuarioActual)

                Dim ActiveURL = "http://" & Request.Url.Host & ":" & Request.Url.Port & "/" & "Usuarios_Registrar.aspx?ID_Usuario=" & Server.UrlEncode(Criptografia.Encriptar(UsuarioActual.idUsuario))
                EnviarCorreo.ObtenerInstancia.EnviarNotificacion(UsuarioActual.mail, "Cambio de Contraseña: Validar.", "Hola " + UsuarioActual.nombreRazonSocial + ", ha modificado su contraseña. <br /><br />" + vbCrLf + "Ingresá al siguiente link para activarlo: " + "<a href=" + ActiveURL + ">link</a>" + "<br /><br /> Si no te funciona el link, copia y pega esta dirección: " + ActiveURL, Server.MapPath("Template_Mokar.html"))

                mensaje = "Se ha enviado un mail para validar el cambio de contraseña"
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & mensaje & "')", True)

                cerrarSesion()
            Else
                mensaje = "Las contraseñas deben ser iguales"
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & mensaje & "')", True)

                TB_Pass.Text = ""
                TB_Pass2.Text = ""
            End If

        Catch ex As Exception
            mensaje = "Mokar informa: " & ex.Message
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & mensaje & "')", True)
        End Try
    End Sub

    Public Sub cerrarSesion()
        Try
            UsuarioLoguedo = Session("UsuarioLog")

            If UsuarioLoguedo IsNot Nothing Then
                Dim bitacora As New LogBE With {.fecha = DateTime.Now,
                                                    .idTipo = "2",
                                                    .usuarioMail = GestorSesion.ObtenerSesionActual.UsuarioActivo.mail,
                                                    .criticidad = "1"}
                LogBLL.ObtenerInstancia.Alta(bitacora)
            End If
        Catch ex As Exception
        Finally
            Session.Clear()
            Response.Redirect("Index.aspx")
        End Try

    End Sub
End Class