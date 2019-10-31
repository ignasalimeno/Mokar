Imports BE
Imports BLL

Public Class Reporte_Respuestas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (Page.IsPostBack) Then
            cargarReportes()
        End If
    End Sub


    Sub cargarReportes()
        Try
            Dim Preguntas As Integer
            Dim Respuestas As Integer
            Dim TiempoPromedio As Integer

            Dim Resultado As Double

            Div_ReporteTiempo.Visible = True

            Preguntas = ReportesBLL.ObtenerInstancia.ListarCantPreguntas
            Respuestas = ReportesBLL.ObtenerInstancia.ListarCantPreguntas
            TiempoPromedio = ReportesBLL.ObtenerInstancia.ListarTiempoPromedio

            lbl_Respuestas.InnerText = Respuestas
            lbl_Preguntas.InnerText = Preguntas

            Resultado = Math.Truncate((Respuestas / Preguntas) * 100)
            lbl_Porcentaje.InnerText = Resultado & "%"

            lbl_TiempoPromedio.InnerText = TiempoPromedio & " segundos"

            Dim Serie1 = chReportes.Series("Series1")
            Serie1.Points.Clear()

            Serie1.Points.AddXY("Preguntas", Preguntas)
            Serie1.Points.AddXY("Respuestas", Respuestas)

            chReportes.Series("Series1").ChartType = DataVisualization.Charting.SeriesChartType.StackedColumn
            Dim ChartArea = chReportes.ChartAreas("ChartArea1")
            ChartArea.AxisY.Title = "Cantidad"

        Catch ex As Exception

        End Try
    End Sub
End Class