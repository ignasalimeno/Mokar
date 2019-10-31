Imports BE
Imports BLL

Public Class Categorias
    Inherits System.Web.UI.Page
    Private oObjBE As New BE.CategoriaBE
    Private oObjBLL As New BLL.CategoriaBLL

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (Page.IsPostBack) Then
            CargarGrilla()
        End If
    End Sub

    Private Sub CargarGrilla()
        GvObjetos.DataSource = ""
        Me.GvObjetos.DataSource = oObjBLL.ListarObjetos()
        Me.GvObjetos.DataBind()
    End Sub

    Private Sub Limpiar()
        Me.txtDescr.Text = ""
        Panel1.Visible = False
    End Sub

    Sub cargardatosObjeto(idCategoria As Integer)
        Me.txtDescr.Text = CategoriaBLL.ObtenerInstancia.ListarObjeto(New CategoriaBE() With {.idCategoria = idCategoria}).descripcion
    End Sub

    Protected Sub BtnAlta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAlta.Click
        Try
            If BtnAlta.CommandName = "Alta" Then
                oObjBE.idCategoria = 1
                oObjBE.descripcion = Me.txtDescr.Text

                oObjBLL.Alta(oObjBE)
                Limpiar()
                CargarGrilla()
            Else
                oObjBE.idCategoria = Session("idCat")

                If Me.txtDescr.Text <> "" Then
                    oObjBE.descripcion = Me.txtDescr.Text

                    oObjBLL.Modificacion(oObjBE)
                    Limpiar()
                    CargarGrilla()

                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub BtnModificar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnModificar.Click
        Limpiar()

    End Sub

    Private Sub GvObjetos_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles GvObjetos.RowDeleting
        Try
            oObjBE.idCategoria = GvObjetos.DataKeys(e.RowIndex).Value
            oObjBLL.Baja(oObjBE)
            Limpiar()
            CargarGrilla()
        Catch ex As Exception
            Dim mensaje As String = "Hubo un error. " & ex.Message
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & mensaje & "')", True)
        End Try
    End Sub

    Private Sub GvObjetos_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GvObjetos.RowCommand
        Try

            If e.CommandName = "idme" Then
                Panel1.Visible = True
                BtnAlta.CommandName = "Modificar"
                cargarDatosObjeto(e.CommandArgument)
                Session("idCat") = e.CommandArgument
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Try
            Limpiar()
            Panel1.Visible = True
            BtnAlta.CommandName = "Alta"
        Catch ex As Exception

        End Try
    End Sub
End Class