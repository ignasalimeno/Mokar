Imports BE
Imports BLL

Public Class Rol
    Inherits System.Web.UI.Page

    Private oObjBE As New BE.RolBE
    Private oObjBLL As New BLL.RolBLL

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (Page.IsPostBack) Then
            CargarGrilla()
        End If
    End Sub

    Private Sub CargarGrilla()
        Me.GvObjetos.DataSource = oObjBLL.ListarObjetos()
        Me.GvObjetos.DataBind()
    End Sub

    Private Sub Limpiar()
        Me.txtDescr.Text = ""
    End Sub

    Protected Sub GvObjetos_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles GvObjetos.SelectedIndexChanging
        Me.txtDescr.Text = Me.GvObjetos.Rows(e.NewSelectedIndex).Cells(2).Text
    End Sub

    Protected Sub BtnLimpiar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnLimpiar.Click
        Limpiar()
    End Sub

    Protected Sub BtnAlta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAlta.Click

        oObjBE.idRol = 1
        oObjBE.descr = Me.txtDescr.Text
        oObjBE.activo = 1

        oObjBLL.Alta(oObjBE)
        Limpiar()
        CargarGrilla()
    End Sub

    Protected Sub BtnModificar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnModificar.Click

        oObjBE.idRol = Me.GvObjetos.SelectedRow.Cells(1).Text

        If Me.txtDescr.Text <> "" Then
            oObjBE.descr = Me.txtDescr.Text

            oObjBLL.Modificacion(oObjBE)
            Limpiar()
            CargarGrilla()

        End If
    End Sub

    Protected Sub BtnBaja_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBaja.Click
        oObjBE.idRol = Me.GvObjetos.SelectedRow.Cells(1).Text
        oObjBLL.Baja(oObjBE)
        Limpiar()
        CargarGrilla()
    End Sub

End Class