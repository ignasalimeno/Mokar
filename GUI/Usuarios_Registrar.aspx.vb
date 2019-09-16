Imports BE
Imports BLL

Public Class WebForm1
    Inherits System.Web.UI.Page

    Dim UsuarioNuevo As New UsuarioBE
    Dim UsuarioObtenido As New UsuarioBE
    Dim mensaje As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim id = CInt(Criptografia.Desencriptar(Request.QueryString("ID_Usuario")))
            UsuarioNuevo.idUsuario = id
            UsuarioObtenido = UsuarioBLL.ObtenerInstancia.ListarObjeto(UsuarioNuevo)
            Session("UsuarioObtenido") = UsuarioObtenido.contraseña
            Session("UsuarioAlta") = UsuarioObtenido.idUsuario
        End If
    End Sub

    Private Sub btn_Enviar_Click(sender As Object, e As EventArgs) Handles btn_Enviar.Click
        ValidarPass()
    End Sub

    Private Sub ValidarPass()
        Dim Pass As String
        UsuarioObtenido.contraseña = Session("UsuarioObtenido")
        UsuarioObtenido.idUsuario = Session("UsuarioAlta")

        UsuarioNuevo.idUsuario = Session("UsuarioAlta")
        UsuarioObtenido = UsuarioBLL.ObtenerInstancia.ListarObjeto(UsuarioNuevo)

        Pass = Criptografia.ObtenerInstancia.EncriptarHashMD5(TB_Pass.Text)
        If UsuarioObtenido.contraseña = Pass Then

            UsuarioBLL.ObtenerInstancia.AltaValidada(UsuarioObtenido)
            btn_Enviar.Visible = False
            TB_Pass.Visible = False
            Lbl_Titulo2.Visible = False
            Lbl_OK.Visible = True
            Lbl_OK.Text = "Su contraseña fue validada, Bienvenido !!"
        Else
            mensaje = "Las contraseñas no son iguales"
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & mensaje & "')", True)
        End If
    End Sub

End Class