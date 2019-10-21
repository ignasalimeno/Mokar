Imports BE
Imports BLL

Public Class Reporte_Servicios
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            cargarServicios()

        End If
    End Sub

    Sub cargarServicios()
        Try
            DDL_Servicios.DataSource = ServiciosBLL.ObtenerInstancia.ListarObjetos()
            DDL_Servicios.DataValueField = "idServicio"
            DDL_Servicios.DataTextField = "Nombre"
            DDL_Servicios.DataBind()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click
        Try
            grilla.Visible = True
            DG_Servicios.DataSource = ReportesBLL.ObtenerInstancia.ObtenerReporteServicios(DDL_Servicios.SelectedValue)
            DG_Servicios.DataBind()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnVerTodos_Click(sender As Object, e As EventArgs) Handles btnVerTodos.Click
        Try
            grilla.Visible = True
            DG_Servicios.DataSource = ReportesBLL.ObtenerInstancia.ObtenerReporteServicios()
            DG_Servicios.DataBind()
        Catch ex As Exception

        End Try
    End Sub
End Class