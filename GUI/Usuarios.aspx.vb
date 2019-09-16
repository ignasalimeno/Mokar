Imports BE
Imports BLL

Public Class Usuarios
    Inherits System.Web.UI.Page

    Private oUsuBE As New BE.UsuarioBE
    Private oUsuBLL As New BLL.UsuarioBLL

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (Page.IsPostBack) Then
            CargarGrillaUsuario()
            cargarDDL_TipoUsuario()
        End If
    End Sub


    Private Sub CargarGrillaUsuario()
        Session("ListaUsuarios") = oUsuBLL.ListarObjetos()
        Me.GvUsuario.DataSource = Session("ListaUsuarios")
        Me.GvUsuario.DataBind()
    End Sub

    Private Sub Limpiar()
        Me.TxtNombre.Text = ""
        Me.TxtMail.Text = ""
    End Sub

    Protected Sub GvUsuario_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles GvUsuario.SelectedIndexChanging
        Me.TxtNombre.Text = Me.GvUsuario.Rows(e.NewSelectedIndex).Cells(2).Text
        Me.DDL_TipoUsuario.DataValueField = Me.GvUsuario.Rows(e.NewSelectedIndex).Cells(3).Text
        Me.TxtMail.Text = Me.GvUsuario.Rows(e.NewSelectedIndex).Cells(5).Text

        Dim miLista As List(Of UsuarioBE) = Session("ListaUsuarios")

        For Each a As UsuarioBE In miLista
            If a.idUsuario = GvUsuario.Rows(e.NewSelectedIndex).Cells(1).Text Then
                TxtNombre.Text = a.nombreRazonSocial
                DDL_TipoUsuario.SelectedValue = a.tipoUsuario
                TxtMail.Text = a.mail
            End If
        Next
    End Sub

    Protected Sub BtnLimpiar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnLimpiar.Click
        Limpiar()
    End Sub

    Protected Sub BtnAlta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAlta.Click

        oUsuBE.nombreRazonSocial = Me.TxtNombre.Text
        oUsuBE.tipoUsuario = Me.DDL_TipoUsuario.DataValueField
        oUsuBE.mail = Me.TxtMail.Text

        oUsuBLL.Alta(oUsuBE)
        Limpiar()
        CargarGrillaUsuario()
    End Sub

    Protected Sub BtnModificar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnModificar.Click

        oUsuBE.idUsuario = Me.GvUsuario.SelectedRow.Cells(1).Text

        If Me.TxtNombre.Text <> "" Then
            oUsuBE.nombreRazonSocial = Me.TxtNombre.Text
            oUsuBE.tipoUsuario = Me.DDL_TipoUsuario.DataValueField
            oUsuBE.mail = Me.TxtMail.Text

            oUsuBLL.Modificacion(oUsuBE)
            Limpiar()
            CargarGrillaUsuario()

        End If
    End Sub

    Protected Sub BtnBaja_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBaja.Click
        oUsuBE.idUsuario = Me.GvUsuario.SelectedRow.Cells(1).Text
        oUsuBLL.Baja(oUsuBE)
        Limpiar()
        CargarGrillaUsuario()
    End Sub

    Protected Sub cargarDDL_TipoUsuario()
        Try
            DDL_TipoUsuario.DataSource = Nothing
            DDL_TipoUsuario.DataSource = UsuariosTipoBLL.ObtenerInstancia.ListarObjetos()
            DDL_TipoUsuario.DataValueField = "idTipoUsuario"
            DDL_TipoUsuario.DataTextField = "descr"
            DDL_TipoUsuario.DataBind()

        Catch ex As Exception

        End Try
    End Sub
End Class