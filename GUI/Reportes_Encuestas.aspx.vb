Imports System.Web.UI.DataVisualization.Charting
Imports BE
Imports BLL

Public Class Reportes_Encuestas
    Inherits System.Web.UI.Page

    Dim oEncuesta As New EncuestaBE

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            cargarEncuestas()
            GenerarReporteEncuesta()
        End If

    End Sub

    Private Sub GenerarReporteEncuesta()
        Div_Encuestas.Visible = True
        Dim listReporte As New List(Of ReporteEncuestaBE)

        'Reporte_BE tiene una propiedad "Reporte" que es lista de Reporte_BE (Pregunta, CantRespuestas)
        listReporte = ReportesBLL.ObtenerInstancia.ObtenerReporteEncuestas()

        Dim Serie1 = Reporte_Encuesta.Series("Series1")
        Serie1.Points.Clear()
        For Each item In listReporte
            Serie1.Points.AddXY(item.idEncuesta, item.CantRespuestas)
        Next
        Reporte_Encuesta.Series("Series1").ChartType = DataVisualization.Charting.SeriesChartType.StackedColumn
        Dim ChartArea = Reporte_Encuesta.ChartAreas("ChartArea1")
        ChartArea.AxisX.Title = "Encuesta"
        ChartArea.AxisY.Title = "Cantidad de Respuestas"
    End Sub

    Private Sub GenerarReporteFichaOpinion()
        Div_Encuestas.Visible = True
        Dim listReporte As New List(Of ReporteEncuestaBE)

        'Reporte_BE tiene una propiedad "Reporte" que es lista de Reporte_BE (Pregunta, CantRespuestas)
        listReporte = ReportesBLL.ObtenerInstancia.ObtenerReporteFichaOpinion()

        Dim Serie1 = Reporte_Encuesta.Series("Series1")
        Serie1.Points.Clear()
        For Each item In listReporte
            Serie1.Points.AddXY(item.idEncuesta, item.CantRespuestas)
        Next
        Reporte_Encuesta.Series("Series1").ChartType = DataVisualization.Charting.SeriesChartType.StackedColumn
        Dim ChartArea = Reporte_Encuesta.ChartAreas("ChartArea1")
        ChartArea.AxisX.Title = "Ficha de Opinion"
        ChartArea.AxisY.Title = "Cantidad de Respuestas"
    End Sub

    Sub cargarEncuestas()
        Try
            DG_Encuestas2.DataSource = ""
            Me.DG_Encuestas2.DataSource = EncuestaBLL.ObtenerInstancia.ListarTodas()
            Me.DG_Encuestas2.DataBind()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnVerEncuestas_Click(sender As Object, e As EventArgs) Handles btnVerEncuestas.Click
        Reporte_Encuesta.Visible = True
        GenerarReporteEncuesta()
        Repeater1.Visible = False
        Repeater2.Visible = False
    End Sub

    Protected Sub btnVerFichaOpinion_Click(sender As Object, e As EventArgs) Handles btnVerFichaOpinion.Click
        Reporte_Encuesta.Visible = True
        GenerarReporteFichaOpinion()
        Repeater1.Visible = False
        Repeater2.Visible = False
        cargarEncuestas()
    End Sub

    Private Sub CargarEncuesta()
        Try
            Dim listaEncuestas As New List(Of EncuestaBE)

            listaEncuestas = EncuestaBLL.ObtenerInstancia.ListarTodas()
            'filtro las encuestas por fecha y tipo

            listaEncuestas = listaEncuestas.FindAll(Function(x) x.FechaVencimiento > Now.ToShortDateString AndAlso x.idEncuesta = Session("idEncuesta")).ToList

            oEncuesta = New EncuestaBE
            oEncuesta = listaEncuestas.Item(0)

            'lblPreguntaEncuesta.Text = oEncuesta.Titulo
            Repeater1.DataSource = Nothing
            Repeater1.DataSource = oEncuesta.Preguntas
            Repeater1.DataBind()



        Catch ex As Exception

        End Try
    End Sub

    Private Sub VerRestultadoEncuesta()
        Try

            For a As Integer = 0 To Repeater1.Items.Count - 1

                Dim idPreg As HiddenField = Repeater1.Items(a).FindControl("idPregunta")

                Dim listRespuestas As List(Of EncuestaRespuestasBE) = EncuestaBLL.ObtenerInstancia.CargarRespuestas(New EncuestaPreguntaBE With {.idPregunta = idPreg.Value})

                Dim Reportes As Chart = Repeater1.Items(a).FindControl("chReportes")

                Dim Serie1 = Reportes.Series("Series1")
                Serie1.Points.Clear()
                For Each item In listRespuestas
                    Serie1.Points.AddXY(item.Respuesta, item.Cantidad)
                Next
                Reportes.Series("Series1").ChartType = DataVisualization.Charting.SeriesChartType.Pie
                Dim ChartArea = Reportes.ChartAreas("ChartArea1")
                ChartArea.AxisX.Title = idPreg.Value
                ChartArea.AxisY.Title = "Cantidad de respuestas"

                Repeater1.Items(a).FindControl("chReportes").Visible = True
            Next


        Catch ex As Exception

        End Try
    End Sub

    Private Sub DG_Encuestas2_SelectedIndexChanging(sender As Object, e As GridViewSelectEventArgs) Handles DG_Encuestas2.SelectedIndexChanging
        Try
            Session("idEncuesta") = DG_Encuestas2.Rows(e.NewSelectedIndex).Cells(1).Text
            CargarEncuesta()
            VerRestultadoEncuesta()
            Repeater1.Visible = True
            Reporte_Encuesta.Visible = False
        Catch ex As Exception

        End Try

    End Sub

    Sub cargarEncuestasActivas()
        Try
            Repeater2.Visible = True

            Dim listaEncuestas As New List(Of EncuestaBE)

            listaEncuestas = EncuestaBLL.ObtenerInstancia.ListarTodas()
            'filtro las encuestas por fecha y tipo

            listaEncuestas = listaEncuestas.FindAll(Function(x) x.FechaVencimiento >= Now.ToShortDateString AndAlso x.idTipoEncuesta = "1").ToList

            oEncuesta = New EncuestaBE

            For Each item As EncuestaBE In listaEncuestas
                oEncuesta.Preguntas.Add(item.Preguntas(0))
            Next

            'lblPreguntaEncuesta.Text = oEncuesta.Titulo
            Repeater2.DataSource = Nothing
            Repeater2.DataSource = oEncuesta.Preguntas
            Repeater2.DataBind()

            For a As Integer = 0 To Repeater2.Items.Count - 1

                Dim idPreg As HiddenField = Repeater2.Items(a).FindControl("idPregunta")

                Dim listRespuestas As List(Of EncuestaRespuestasBE) = EncuestaBLL.ObtenerInstancia.CargarRespuestas(New EncuestaPreguntaBE With {.idPregunta = idPreg.Value})

                Dim Reportes As Chart = Repeater2.Items(a).FindControl("chActivas")

                Dim Serie1 = Reportes.Series("Series1")
                Serie1.Points.Clear()
                For Each item In listRespuestas
                    Serie1.Points.AddXY(item.Respuesta, item.Cantidad)
                Next
                Reportes.Series("Series1").ChartType = DataVisualization.Charting.SeriesChartType.Pie
                Dim ChartArea = Reportes.ChartAreas("ChartArea1")
                ChartArea.AxisX.Title = idPreg.Value
                ChartArea.AxisY.Title = "Cantidad de respuestas"

                Repeater2.Items(a).FindControl("chActivas").Visible = True
            Next

        Catch ex As Exception

        End Try
    End Sub

    Sub cargarEncuestasVencidass()
        Try
            Repeater2.Visible = True

            Dim listaEncuestas As New List(Of EncuestaBE)

            listaEncuestas = EncuestaBLL.ObtenerInstancia.ListarTodas()
            'filtro las encuestas por fecha y tipo

            listaEncuestas = listaEncuestas.FindAll(Function(x) x.FechaVencimiento < Now.ToShortDateString AndAlso x.idTipoEncuesta = "1").ToList

            oEncuesta = New EncuestaBE

            For Each item As EncuestaBE In listaEncuestas
                oEncuesta.Preguntas.Add(item.Preguntas(0))
            Next

            'lblPreguntaEncuesta.Text = oEncuesta.Titulo
            Repeater2.DataSource = Nothing
            Repeater2.DataSource = oEncuesta.Preguntas
            Repeater2.DataBind()

            For a As Integer = 0 To Repeater2.Items.Count - 1

                Dim idPreg As HiddenField = Repeater2.Items(a).FindControl("idPregunta")

                Dim listRespuestas As List(Of EncuestaRespuestasBE) = EncuestaBLL.ObtenerInstancia.CargarRespuestas(New EncuestaPreguntaBE With {.idPregunta = idPreg.Value})

                Dim Reportes As Chart = Repeater2.Items(a).FindControl("chActivas")

                Dim Serie1 = Reportes.Series("Series1")
                Serie1.Points.Clear()
                For Each item In listRespuestas
                    Serie1.Points.AddXY(item.Respuesta, item.Cantidad)
                Next
                Reportes.Series("Series1").ChartType = DataVisualization.Charting.SeriesChartType.Pie
                Dim ChartArea = Reportes.ChartAreas("ChartArea1")
                ChartArea.AxisX.Title = idPreg.Value
                ChartArea.AxisY.Title = "Cantidad de respuestas"

                Repeater2.Items(a).FindControl("chActivas").Visible = True
            Next

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnActivas_Click(sender As Object, e As EventArgs) Handles btnActivas.Click
        cargarEncuestasActivas()
        Reporte_Encuesta.Visible = False
    End Sub

    Protected Sub btnVencidas_Click(sender As Object, e As EventArgs) Handles btnVencidas.Click
        cargarEncuestasVencidass()
        Reporte_Encuesta.Visible = False
    End Sub
End Class