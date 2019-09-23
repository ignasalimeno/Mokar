Imports System.IO
Imports System.Net
Imports BE
Imports BLL
Imports Newtonsoft.Json.Linq

Public Class Site1
    Inherits System.Web.UI.MasterPage

    Private ValidarUsuario As Boolean = False
    Dim UsuarioLoguedo As New UsuarioBE


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None

        If Not IsPostBack Then
            L_Logueado.Visible = False
            btn_Logout.Visible = False
            Panel1.Visible = False
            Me.RefrescarRol()
            Me.RefrescarPlanes()
            RefrescarCategorias()

            If Session("UsuarioLog") IsNot Nothing Then
                UsuarioLoguedo = Session("UsuarioLog")
                ' CargarMenuLateral(UsuarioLoguedo)
                Cargar_SubMenu(UsuarioLoguedo)
                'L_Logueado.InnerText = UsuarioLoguedo.nombreRazonSocial
                L_Logueado.Text = "Hola, " & UsuarioLoguedo.nombreRazonSocial
                btnLogin.Visible = False
                L_Logueado.Visible = True
                btn_Logout.Visible = True
                btnRegistrarse.Visible = False
                Panel1.Visible = True
            End If

        End If
    End Sub

    Private Sub btn_Ingresar_LOGIN_Click(sender As Object, e As EventArgs) Handles btn_Ingresar_LOGIN.Click
        Try
            Dim oUs As New UsuarioBE With {.mail = TB_LOGIN_Ingresar_Mail.Text, .contraseña = TB_LOGIN_Pass.Text}
            If GestorSesion.ObtenerSesionActual.IniciarSesion(oUs) Then
                Dim bitacora As New LogBE With {.fecha = DateTime.Now,
                                                .idTipo = "1",
                                                .usuarioMail = GestorSesion.ObtenerSesionActual.UsuarioActivo.mail,
                                                .criticidad = "1"}
                LogBLL.ObtenerInstancia.Alta(bitacora)

                Me.Limpiar()
                Dim UsuarioActivo = GestorSesion.ObtenerSesionActual.UsuarioActivo
                Session.Add("UsuarioLog", UsuarioActivo)
                Response.Redirect(Request.RawUrl)
            Else
                Dim oClie As New UsuarioBE With {.mail = TB_LOGIN_Ingresar_Mail.Text, .contraseña = TB_LOGIN_Pass.Text}
                'Prueba para meter un cliente
                If GestorSesion.ObtenerSesionActual.IniciarSesion(oClie) Then

                    Me.Limpiar()
                    Dim ClienteActivo = GestorSesion.ObtenerSesionActual.UsuarioActivo
                    Session.Add("ClienteLog", ClienteActivo)
                    Response.Redirect(Request.RawUrl)

                End If
            End If
        Catch ex As Exception
            MensajesModal.Mostrar("El usuario o la contraseña no son correctos")
        End Try

    End Sub

    Private Sub btn_Ingresar_REG_Click(sender As Object, e As EventArgs) Handles btn_Ingresar_REG.Click
        'ValidarUsuario = False
        Try
            If ck_Terminos.Checked Then
                If TB_Password.Text = TB_Password2.Text Then
                    If IsReCaptchaValid() Then

                        Dim UsuarioNuevo As New UsuarioBE With {.nombreRazonSocial = TB_Nombre.Text, .tipoUsuario = 2, .mail = TB_email.Text, .contraseña = TB_Password.Text, .activo = "0"}
                        If ValidarUsuario OrElse Not UsuarioBLL.ObtenerInstancia.VerificarExisteUsuario(UsuarioNuevo.mail) Then
                            If UsuarioBLL.ObtenerInstancia.Alta(UsuarioNuevo) = False Then
                                Throw New Exception
                            End If

                            Dim UsuarioCreado As New UsuarioBE
                            UsuarioCreado.mail = UsuarioNuevo.mail
                            UsuarioCreado = UsuarioBLL.ObtenerInstancia.ListarObjetoPorMail(UsuarioNuevo)

                            ''Creo el cliente
                            Dim ClienteNuevo As New ClienteBE With {.idUsuario = UsuarioCreado.idUsuario, .nombre = TB_Nombre.Text, .tipoCliente = DDL_Roles.SelectedIndex + 1, .direccion = txtDireccion.Text, .dni = tb_Dni.Text, .telefono = txtTel.Text}
                            If ClienteBLL.ObtenerInstancia.Alta(ClienteNuevo) = False Then
                                Throw New Exception
                            End If

                            ''Le asigno rol al nuevo usuario
                            Dim newListRoles As New List(Of RolBE)
                            Dim newRol As New RolBE With {.idRol = DDL_Planes.SelectedValue}
                            newRol = RolBLL.ObtenerInstancia.ListarObjeto(newRol)
                            newListRoles.Add(newRol)
                            UsuarioBLL.ObtenerInstancia.Agregar_Usuario_Rol(UsuarioCreado.idUsuario, newListRoles)


                            'Envio el mail
                            Dim ActiveURL = "http://" & Request.Url.Host & ":" & Request.Url.Port & "/" & "Usuarios_Registrar.aspx?ID_Usuario=" + Server.UrlEncode(Criptografia.Encriptar(UsuarioCreado.idUsuario))
                            EnviarCorreo.ObtenerInstancia.EnviarNotificacion(UsuarioNuevo.mail, "Bienvenido a Mokar.", "Hola " + UsuarioCreado.nombreRazonSocial + ", ya sos usuario. <br /><br />" + vbCrLf + "Ingresá al siguiente link para activarlo: " + "<a href=" + ActiveURL + ">link</a>" + "<br /><br /> Si no te funciona el link, copia y pega esta dirección: " + ActiveURL, Server.MapPath("Template_Mokar.html"))

                            MensajesModal.Mostrar("Se envió un correo para finalizar el alta")

                            Response.Redirect("Index.aspx", False)

                        Else
                            MensajesModal.Mostrar("El usuario ingresado ya existe")
                        End If

                    Else
                        MensajesModal.Mostrar("Completar el Captcha")
                    End If
                Else
                    MensajesModal.Mostrar("Las contraseñas ingresadas NO son iguales")
                End If
            Else
                MensajesModal.Mostrar("Debe aceptar las políticas y los términos y condiciones.")

            End If

        Catch ex As Exception
            MensajesModal.Mostrar(ex.Message)
        End Try
    End Sub

    Public Function IsReCaptchaValid() As Boolean
        Dim result = False
        Dim captchaResponse = Me.Request.Form("g-recaptcha-response")
        Dim secretKey = ConfigurationManager.AppSettings("reCAPTCHA")
        Dim apiUrl = "https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}"
        Dim requestUri = String.Format(apiUrl, secretKey, captchaResponse)
        Dim request = CType(WebRequest.Create(requestUri), HttpWebRequest)
        Using response As WebResponse = request.GetResponse()
            Using stream As StreamReader = New StreamReader(response.GetResponseStream())
                Dim jResponse As JObject = JObject.Parse(stream.ReadToEnd())
                Dim isSuccess = jResponse.Value(Of Boolean)("success")
                result = If((isSuccess), True, False)
            End Using
        End Using
        Return result
    End Function

    Public Sub Cargar_SubMenu(oUsuario As UsuarioBE)
        Dim lista_permisos_cargados As New List(Of PermisosBE)
        Dim i As Integer = 0

        For Each oRol As RolBE In oUsuario.roles
            ''Cargo roles padres
            For Each oPermiso As PermisosBE In oUsuario.roles(i).listPermisos
                If Not lista_permisos_cargados.Any(Function(x) x.idPermiso = oPermiso.idPermiso) Then

                    If oPermiso.descr.Contains("/") = False Then ''Valido que sea permiso "padre"
                        Dim oMenuItem As New MenuItem
                        oMenuItem.Text = oPermiso.descr.ToString
                        oMenuItem.Value = oPermiso.idPermiso
                        'oMenuItem.ImageUrl = oPermiso.Icono.ToString
                        If (oPermiso.formulario <> "") Then
                            oMenuItem.NavigateUrl = oPermiso.formulario.ToString
                        Else
                            oMenuItem.NavigateUrl = "javascript: void(0);"
                        End If
                        Lateral_menu.Items.Add(oMenuItem)
                        lista_permisos_cargados.Add(oPermiso)
                    End If

                End If
            Next

            ''Cargo roles hijos
            For Each oPermiso As PermisosBE In oUsuario.roles(i).listPermisos
                If oPermiso.descr.Contains("/") Then ''Valido que sea permiso "hijo"
                    Dim permisoCompuesto As String() = oPermiso.descr.Split("/")

                    For Each a As MenuItem In Lateral_menu.Items
                        If a.Text = permisoCompuesto(0) Then
                            a.ChildItems.Add(New MenuItem With {.Text = permisoCompuesto(1), .Value = oPermiso.idPermiso, .NavigateUrl = oPermiso.formulario})
                        End If
                    Next

                    lista_permisos_cargados.Add(oPermiso)
                End If


            Next
            Lateral_menu.ForeColor = Drawing.ColorTranslator.FromHtml("#7a8085")
            i = i + 1
        Next

    End Sub

    Private Sub Limpiar()
        Me.TB_LOGIN_Ingresar_Mail.Text = Nothing
        Me.TB_LOGIN_Pass.Text = Nothing
    End Sub

    Private Sub btn_Logout_Click(sender As Object, e As EventArgs) Handles btn_Logout.Click
        UsuarioLoguedo = Session("UsuarioLog")

        If UsuarioLoguedo IsNot Nothing Then
            Dim bitacora As New LogBE With {.fecha = DateTime.Now,
                                                .idTipo = "2",
                                                .usuarioMail = GestorSesion.ObtenerSesionActual.UsuarioActivo.mail,
                                                .criticidad = "1"}
            LogBLL.ObtenerInstancia.Alta(bitacora)

            GestorSesion.ObtenerSesionActual.CerrarSesion()

            Session.Clear()
            Response.Redirect("Index.aspx")
        Else
            Session.Clear()
            Response.Redirect("Index.aspx")
        End If
    End Sub

    Private Sub btn_Enviar_Click(sender As Object, e As EventArgs) Handles btn_Enviar.Click
        Dim mensaje As String = ""
        Try

            If TB_email1.Text = TB_email2.Text Then
                Dim UsuarioNuevo As New UsuarioBE

                UsuarioNuevo.mail = TB_email1.Text
                If UsuarioBLL.ObtenerInstancia.VerificarExisteUsuario(UsuarioNuevo.mail) Then
                    Dim UsuarioEncontrado = UsuarioBLL.ObtenerInstancia.ListarObjetoPorMail(UsuarioNuevo)

                    mensaje = "Se envió un email para validar la identidad"
                    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & mensaje & "')", True)

                    Dim ID_Encriptado = Server.UrlEncode(Criptografia.Encriptar(UsuarioEncontrado.idUsuario))
                    Dim OlvidoURL = "http://" & Request.Url.Host & ":" & Request.Url.Port & "/" & "NewPass.aspx?ID_Usuario=" & ID_Encriptado
                    EnviarCorreo.ObtenerInstancia.EnviarNotificacion(UsuarioNuevo.mail, "Recupero de Contraseña Mokar", "Hola " + UsuarioEncontrado.nombreRazonSocial + ", se solicitó un reingreso de contraseña. <br /><br />" + vbCrLf + "Ingresá al siguiente link para activarlo: " + "<a href=" + OlvidoURL + ">link</a>" + "<br /><br /> Si no te funciona el link, copia y pega esta dirección: " + OlvidoURL, Server.MapPath("Template_Mokar.html"))
                Else

                    mensaje = "El email ingresado no es correcto"
                    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & mensaje & "')", True)

                End If
            Else

                mensaje = "Los email ingresados no son iguales"
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & mensaje & "')", True)

            End If
        Catch ex As Exception

            mensaje = "Mokar: " & ex.Message
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & mensaje & "')", True)

            TB_email1.Text = ""
            TB_email2.Text = ""
        End Try
    End Sub

    Private Sub RefrescarRol()
        DDL_Roles.DataSource = Nothing
        'DDL_Roles.DataSource = GestorRol.ObtenerInstancia.Listar_Roles_Registro()
        DDL_Roles.Items.Add("Persona Física")
        DDL_Roles.Items.Add("Empresa")
        DDL_Roles.DataBind()
        DDL_Roles.ClearSelection()
    End Sub

    Protected Sub cambioTipoDeCliente(sender As Object, e As EventArgs)
        If DDL_Roles.SelectedIndex = 0 Then
            lblNombre.Text = "Ingresar Nombre y Apellido"
            lblDNI.Text = "Ingresar el DNI"
        Else
            lblNombre.Text = "Ingresar Razon Social"
            lblDNI.Text = "Ingresar el CUIT"
        End If
        'Dim message As String = ddlFruits.SelectedItem.Text & " - " & ddlFruits.SelectedItem.Value
        'ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('" & message & "');", True)
    End Sub

    Private Sub RefrescarPlanes()

        DDL_Planes.DataSource = Nothing
        DDL_Planes.DataSource = RolBLL.ObtenerInstancia.ObtenerRolesUsuario
        DDL_Planes.DataValueField = "idRol"
        DDL_Planes.DataTextField = "descr"
        DDL_Planes.DataBind()

    End Sub

    Private Sub RefrescarCategorias()
        Try
            checkCategorias.DataSource = Nothing
            checkCategorias.DataSource = BLL.CategoriaBLL.ObtenerInstancia.ListarObjetos
            checkCategorias.DataTextField = "descripcion"
            checkCategorias.DataValueField = "idCategoria"

            checkCategorias.DataBind()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSuscribirse_Click(sender As Object, e As EventArgs) Handles btnSuscribirse.Click
        Try
            If txtMailNL.Text = txtMailNLValidar.Text Then

                Dim miUser As New UsuarioBE With {.mail = txtMailNL.Text}
                Dim listCat As New List(Of CategoriaBE)

                For Each a As ListItem In checkCategorias.Items
                    If a.Selected Then
                        listCat.Add(New CategoriaBE With {.idCategoria = a.Value})
                    End If
                Next

                If listCat.Count > 0 Then
                    If NewsletterBLL.ObtenerInstancia.Suscribirse(miUser, listCat) Then
                        MensajesModal.Mostrar("Gracias por suscribirse a nuestro portal de noticias!")
                    Else
                        MensajesModal.Mostrar("El usuario y la categoría ya estan dados de alta en nuestro sistema")
                    End If
                Else
                    MensajesModal.Mostrar("Debe seleccionar al menos una categoría de noticias")
                End If
            Else
                MensajesModal.Mostrar("Los correos ingresados no son iguales")
            End If

        Catch ex As Exception

        End Try

    End Sub


End Class