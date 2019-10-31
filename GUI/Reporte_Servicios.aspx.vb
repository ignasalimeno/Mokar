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
            DDL_Servicios.Items.Add(New ListItem("---", 99))
            DDL_Servicios.Items.Add(New ListItem("Canceladas", 1))
            DDL_Servicios.Items.Add(New ListItem("Activas", 0))
            DDL_Servicios.DataBind()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click
        Try
            Dim listReporte As New List(Of ReporteServiciosBE)
            If DDL_Servicios.Text = "99" Then
                listReporte = ReportesBLL.ObtenerInstancia.ObtenerReporteServicios(TextBox1.Text, TextBox2.Text)
            Else
                listReporte = ReportesBLL.ObtenerInstancia.ObtenerReporteServicios(DDL_Servicios.SelectedValue, TextBox1.Text, TextBox2.Text)
            End If

            grilla.Visible = True
            DG_Servicios.DataSource = listReporte
            DG_Servicios.DataBind()

            Dim Serie1 = chReportes.Series("Series1")
            Serie1.Points.Clear()
            For Each item In listReporte
                Serie1.Points.AddXY(item.Nombre, item.Total)
            Next
            chReportes.Series("Series1").ChartType = DataVisualization.Charting.SeriesChartType.Pie
            Dim ChartArea = chReportes.ChartAreas("ChartArea1")
            ChartArea.AxisX.Title = "Servicios"
            ChartArea.AxisY.Title = "Facturacion"

            chReportes.Visible = True
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnVerTodos_Click(sender As Object, e As EventArgs) Handles btnVerTodos.Click
        Try
            Dim listReporte As List(Of ReporteServiciosBE) = ReportesBLL.ObtenerInstancia.ObtenerReporteServicios()

            grilla.Visible = True
            DG_Servicios.DataSource = listReporte
            DG_Servicios.DataBind()

            Dim Serie1 = chReportes.Series("Series1")
            Serie1.Points.Clear()
            For Each item In listReporte
                Serie1.Points.AddXY(item.Nombre, item.Total)
            Next
            chReportes.Series("Series1").ChartType = DataVisualization.Charting.SeriesChartType.Pie
            Dim ChartArea = chReportes.ChartAreas("ChartArea1")
            ChartArea.AxisX.Title = "Servicios"
            ChartArea.AxisY.Title = "Facturacion"

            chReportes.Visible = True
        Catch ex As Exception

        End Try
    End Sub
End Class