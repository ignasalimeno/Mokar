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

    Protected Sub BtnAlta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAlta.Click
        Try
            If BtnAlta.CommandName = "Alta" Then
                oUsuBE.nombreRazonSocial = Me.TxtNombre.Text
                oUsuBE.tipoUsuario = Me.DDL_TipoUsuario.SelectedValue
                oUsuBE.mail = Me.TxtMail.Text

                oUsuBLL.Alta(oUsuBE)
                Limpiar()
                CargarGrillaUsuario()
            ElseIf BtnAlta.CommandName = "Modificar" Then
                oUsuBE.idUsuario = Session("idUser")

                If Me.TxtNombre.Text <> "" Then
                    oUsuBE.nombreRazonSocial = Me.TxtNombre.Text
                    oUsuBE.tipoUsuario = Me.DDL_TipoUsuario.SelectedValue
                    oUsuBE.mail = Me.TxtMail.Text

                    oUsuBLL.Modificacion(oUsuBE)
                    Limpiar()
                    CargarGrillaUsuario()

                End If
            End If
            Panel1.Visible = False
            Limpiar()
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub BtnModificar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnModificar.Click
        Limpiar()
        Panel1.Visible = False

    End Sub

    'Protected Sub BtnBaja_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBaja.Click
    '    'oUsuBE.idUsuario = Me.GvUsuario.SelectedRow.Cells(1).Text
    '    'oUsuBLL.Baja(oUsuBE)
    '    'Limpiar()
    '    'CargarGrillaUsuario()
    'End Sub

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

    Protected Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Try
            Limpiar()
            BtnAlta.CommandName = "Alta"
            Panel1.Visible = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GvUsuario_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GvUsuario.RowCommand
        Try
            Try
                If e.CommandName = "idme" Then
                    Panel1.Visible = True
                    BtnAlta.CommandName = "Modificar"
                    cargarDatosObjeto(e.CommandArgument)
                    Session("idUser") = e.CommandArgument
                End If
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Sub cargarDatosObjeto(idUsuario As Integer)
        Try
            Dim miUser As UsuarioBE = UsuarioBLL.ObtenerInstancia.ListarObjeto(New UsuarioBE With {.idUsuario = idUsuario})
            Me.TxtNombre.Text = miUser.nombreRazonSocial
            Me.DDL_TipoUsuario.DataValueField = miUser.tipoUsuario
            Me.TxtMail.Text = miUser.mail
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GvUsuario_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles GvUsuario.RowDeleting
        Try
            oUsuBE.idUsuario = GvUsuario.DataKeys(e.RowIndex).Value
            oUsuBLL.Baja(oUsuBE)
            Limpiar()
            CargarGrillaUsuario()
        Catch ex As Exception

        End Try
    End Sub
End Class