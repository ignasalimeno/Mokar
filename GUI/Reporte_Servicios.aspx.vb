Imports BE
Imports BLL

Public Class Reporte_Servicios
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'cargarServicios()
            cargarAños()

        End If
    End Sub

    Sub cargarAños()
        Try
            ddl_años.Items.Add(New ListItem("2017"))
            ddl_años.Items.Add(New ListItem("2018"))
            ddl_años.Items.Add(New ListItem("2019"))
            ddl_años.DataBind()

            ddl_añoDesde.Items.Add(New ListItem("2017"))
            ddl_añoDesde.Items.Add(New ListItem("2018"))
            ddl_añoDesde.Items.Add(New ListItem("2019"))
            ddl_añoDesde.DataBind()

            ddl_añoHasta.Items.Add(New ListItem("2017"))
            ddl_añoHasta.Items.Add(New ListItem("2018"))
            ddl_añoHasta.Items.Add(New ListItem("2019"))
            ddl_añoHasta.DataBind()

            ddl_mes.Items.Add(New ListItem("Enero", 1))
            ddl_mes.Items.Add(New ListItem("Febrero", 2))
            ddl_mes.Items.Add(New ListItem("Marzo", 3))
            ddl_mes.Items.Add(New ListItem("Abril", 4))
            ddl_mes.Items.Add(New ListItem("Mayo", 5))
            ddl_mes.Items.Add(New ListItem("Junio", 6))
            ddl_mes.Items.Add(New ListItem("Julio", 7))
            ddl_mes.Items.Add(New ListItem("Agosto", 8))
            ddl_mes.Items.Add(New ListItem("Septiembre", 9))
            ddl_mes.Items.Add(New ListItem("Octubre", 10))
            ddl_mes.Items.Add(New ListItem("Noviembre", 11))
            ddl_mes.Items.Add(New ListItem("Diciembre", 12))
            ddl_mes.DataBind()

        Catch ex As Exception

        End Try
    End Sub

    'Sub cargarServicios()
    '    Try
    '        DDL_Servicios.Items.Add(New ListItem("---", 99))
    '        DDL_Servicios.Items.Add(New ListItem("Canceladas", 1))
    '        DDL_Servicios.Items.Add(New ListItem("Activas", 0))
    '        DDL_Servicios.DataBind()
    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Protected Sub btnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click
    '    Try
    '        Dim listReporte As New List(Of ReporteServiciosBE)
    '        If DDL_Servicios.Text = "99" Then
    '            listReporte = ReportesBLL.ObtenerInstancia.ObtenerReporteServicios(TextBox1.Text, TextBox2.Text)
    '        Else
    '            listReporte = ReportesBLL.ObtenerInstancia.ObtenerReporteServicios(DDL_Servicios.SelectedValue, TextBox1.Text, TextBox2.Text)
    '        End If

    '        grilla.Visible = True
    '        DG_Servicios.DataSource = listReporte
    '        DG_Servicios.DataBind()

    '        Dim Serie1 = chReportes.Series("Series1")
    '        Serie1.Points.Clear()
    '        For Each item In listReporte
    '            Serie1.Points.AddXY(item.Nombre, item.Total)
    '        Next
    '        chReportes.Series("Series1").ChartType = DataVisualization.Charting.SeriesChartType.Pie
    '        Dim ChartArea = chReportes.ChartAreas("ChartArea1")
    '        ChartArea.AxisX.Title = "Servicios"
    '        ChartArea.AxisY.Title = "Facturacion"

    '        chReportes.Visible = True
    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Protected Sub btnVerTodos_Click(sender As Object, e As EventArgs) Handles btnVerTodos.Click
    '    Try
    '        Dim listReporte As List(Of ReporteServiciosBE) = ReportesBLL.ObtenerInstancia.ObtenerReporteServicios()

    '        grilla.Visible = True
    '        DG_Servicios.DataSource = listReporte
    '        DG_Servicios.DataBind()

    '        Dim Serie1 = chReportes.Series("Series1")
    '        Serie1.Points.Clear()
    '        For Each item In listReporte
    '            Serie1.Points.AddXY(item.Nombre, item.Total)
    '        Next
    '        chReportes.Series("Series1").ChartType = DataVisualization.Charting.SeriesChartType.Pie
    '        Dim ChartArea = chReportes.ChartAreas("ChartArea1")
    '        ChartArea.AxisX.Title = "Servicios"
    '        ChartArea.AxisY.Title = "Facturacion"

    '        chReportes.Visible = True
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Protected Sub btnAño_Click(sender As Object, e As EventArgs) Handles btnAño.Click
        Try
            Dim listReporte As List(Of ReporteServicios1BE) = ReportesBLL.ObtenerInstancia.ObtenerReporteServiciosAño(ddl_años.Text)

            Div1.Visible = True
            GridView1.DataSource = listReporte
            GridView1.DataBind()

            Dim Serie1 = Chart2.Series("Series2")
            Serie1.Points.Clear()
            For Each item In listReporte
                Serie1.Points.AddXY(item.rango, item.total)
            Next
            Chart2.Series("Series2").ChartType = DataVisualization.Charting.SeriesChartType.StackedColumn
            Dim ChartArea = Chart2.ChartAreas("ChartArea2")
            ChartArea.AxisX.Title = "Mes"
            ChartArea.AxisY.Title = "Facturacion"

            Chart2.Visible = True
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnAños_Click(sender As Object, e As EventArgs) Handles btnAños.Click
        Try
            Dim listReporte As List(Of ReporteServicios1BE) = ReportesBLL.ObtenerInstancia.ObtenerReporteServiciosAños(ddl_añoDesde.Text, ddl_añoHasta.Text)

            Div1.Visible = True
            GridView1.DataSource = listReporte
            GridView1.DataBind()

            Dim Serie1 = Chart2.Series("Series2")
            Serie1.Points.Clear()
            For Each item In listReporte
                Serie1.Points.AddXY(item.rango, item.total)
            Next
            Chart2.Series("Series2").ChartType = DataVisualization.Charting.SeriesChartType.StackedColumn
            Dim ChartArea = Chart2.ChartAreas("ChartArea2")
            ChartArea.AxisX.Title = "Años"
            ChartArea.AxisY.Title = "Facturacion"

            Chart2.Visible = True
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnMes_Click(sender As Object, e As EventArgs) Handles btnMes.Click
        Try
            Dim listReporte As List(Of ReporteServicios1BE) = ReportesBLL.ObtenerInstancia.ObtenerReporteServiciosMes(ddl_mes.SelectedValue)

            Div1.Visible = True
            GridView1.DataSource = listReporte
            GridView1.DataBind()

            Dim Serie1 = Chart2.Series("Series2")
            Serie1.Points.Clear()
            For Each item In listReporte
                Serie1.Points.AddXY(item.rango, item.total)
            Next
            Chart2.Series("Series2").ChartType = DataVisualization.Charting.SeriesChartType.StackedColumn
            Dim ChartArea = Chart2.ChartAreas("ChartArea2")
            ChartArea.AxisX.Title = "Dia"
            ChartArea.AxisY.Title = "Facturacion"

            Chart2.Visible = True
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnSemanal_Click(sender As Object, e As EventArgs) Handles btnSemanal.Click
        Try
            Dim listReporte As List(Of ReporteServicios1BE) = ReportesBLL.ObtenerInstancia.ObtenerReporteServiciosSemanal(ddl_años.SelectedValue)

            Div1.Visible = True
            GridView1.DataSource = listReporte
            GridView1.DataBind()

            Dim Serie1 = Chart2.Series("Series2")
            Serie1.Points.Clear()
            For Each item In listReporte
                Serie1.Points.AddXY(item.rango, item.total)
            Next
            Chart2.Series("Series2").ChartType = DataVisualization.Charting.SeriesChartType.StackedColumn
            Dim ChartArea = Chart2.ChartAreas("ChartArea2")
            ChartArea.AxisX.Title = "Num Semana"
            ChartArea.AxisY.Title = "Facturacion"

            Chart2.Visible = True
        Catch ex As Exception

        End Try
    End Sub
End Class