Imports System.Web.UI.DataVisualization.Charting
Imports BE
Imports BLL

Public Class Index
    Inherits System.Web.UI.Page

    Private miUserBE As New BE.UsuarioBE
    Private miUserBLL As New BLL.UsuarioBLL

    Shared oEncuesta As EncuestaBE

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (Page.IsPostBack) Then

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


            Pregunta.InnerText = oEncuesta.Preguntas(0).Pregunta
            idPregunta.Value = oEncuesta.Preguntas(0).idPregunta

            rbPreguntas.DataSource = Nothing
            rbPreguntas.DataSource = EncuestaBLL.ObtenerInstancia.CargarRespuestas(New EncuestaPreguntaBE With {.idPregunta = oEncuesta.Preguntas(0).idPregunta})
            rbPreguntas.DataTextField = "Respuesta"
            rbPreguntas.DataValueField = "idRespuesta"
            rbPreguntas.DataBind()

            Dim Reportes As Chart = chReportes
            Reportes.ChartAreas("ChartArea1").AxisX.MajorGrid.Enabled = False
            Reportes.ChartAreas("ChartArea1").AxisY.MajorGrid.Enabled = False


            'btnVotar.CommandArgument = oEncuesta.idEncuesta

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnVotar_Click(sender As Object, e As EventArgs) Handles btnVotar.Click
        Try

            If EncuestaBLL.ObtenerInstancia.Votar(rbPreguntas.SelectedValue) Then

            End If

            VerRestultadoEncuesta()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub VerRestultadoEncuesta()
        Try


            Dim idPreg As HiddenField = idPregunta

                Dim listRespuestas As List(Of EncuestaRespuestasBE) = EncuestaBLL.ObtenerInstancia.CargarRespuestas(New EncuestaPreguntaBE With {.idPregunta = idPreg.Value})

            Dim Reportes As Chart = chReportes

            Dim Serie1 = Reportes.Series("Series1")
                Serie1.Points.Clear()
                For Each item In listRespuestas
                    Serie1.Points.AddXY(item.Respuesta, item.Cantidad)
                Next
                Reportes.Series("Series1").ChartType = DataVisualization.Charting.SeriesChartType.Pie
                Dim ChartArea = Reportes.ChartAreas("ChartArea1")
                ChartArea.AxisX.Title = idPreg.Value
                ChartArea.AxisY.Title = "Cantidad de respuestas"

            chReportes.Visible = True
            rbPreguntas.Visible = False
            btnVotar.Visible = False



        Catch ex As Exception

        End Try
    End Sub
End Class