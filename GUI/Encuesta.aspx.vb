Imports System.Web.UI.DataVisualization.Charting
Imports BE
Imports BLL
Public Class Encuesta
    Inherits System.Web.UI.Page

    Shared oEncuesta As EncuestaBE

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            CargarEncuesta()



        End If
    End Sub

    Private Sub CargarEncuesta()
        Try
            Dim listaEncuestas As New List(Of EncuestaBE)

            listaEncuestas = EncuestaBLL.ObtenerInstancia.ListarTodas()
            'filtro las encuestas por fecha y tipo

            listaEncuestas = listaEncuestas.FindAll(Function(x) x.FechaVencimiento > Now.ToShortDateString AndAlso x.idTipoEncuesta = "1").ToList
            Dim random As New Random
            Dim r = random.Next(listaEncuestas.Count)
            oEncuesta = New EncuestaBE
            oEncuesta = listaEncuestas.Item(r)
            lblPreguntaEncuesta.Text = oEncuesta.Titulo
            Repeater1.DataSource = Nothing
            Repeater1.DataSource = oEncuesta.Preguntas
            Repeater1.DataBind()

            ''Cargo las respuestas
            For a As Integer = 0 To Repeater1.Items.Count - 1
                Dim rb As RadioButtonList = Repeater1.Items(a).FindControl("rbPreguntas")
                Dim idPreg As HiddenField = Repeater1.Items(a).FindControl("idPregunta")
                rb.DataSource = Nothing
                rb.DataSource = EncuestaBLL.ObtenerInstancia.CargarRespuestas(New EncuestaPreguntaBE With {.idPregunta = idPreg.Value})
                rb.DataTextField = "Respuesta"
                rb.DataValueField = "idRespuesta"
                rb.DataBind()

                Dim Reportes As Chart = Repeater1.Items(a).FindControl("chReportes")
                Reportes.ChartAreas("ChartArea1").AxisX.MajorGrid.Enabled = False
                Reportes.ChartAreas("ChartArea1").AxisY.MajorGrid.Enabled = False
            Next

            'btnVotar.CommandArgument = oEncuesta.idEncuesta

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnVotar_Click(sender As Object, e As EventArgs)
        Try
            For a As Integer = 0 To Repeater1.Items.Count - 1
                Dim rb As RadioButtonList = Repeater1.Items(a).FindControl("rbPreguntas")
                If EncuestaBLL.ObtenerInstancia.Votar(rb.SelectedValue) Then

                End If
            Next

            VerRestultadoEncuesta()

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



End Class