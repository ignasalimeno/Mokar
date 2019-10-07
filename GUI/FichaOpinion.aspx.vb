Imports BE
Imports BLL

Public Class FichaOpinion
    Inherits System.Web.UI.Page

    Shared oEncuesta As EncuestaBE
    Dim mensaje As String
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

            listaEncuestas = listaEncuestas.FindAll(Function(x) x.FechaVencimiento > Now.ToShortDateString AndAlso x.idTipoEncuesta = "2").ToList
            Dim random As New Random
            Dim r = random.Next(listaEncuestas.Count)
            oEncuesta = New EncuestaBE
            oEncuesta = listaEncuestas.Item(r)
            'lblPreguntaEncuesta.Text = oEncuesta.Titulo
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

            Next

            'btnVotar.CommandArgument = oEncuesta.idEncuesta

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnVotar_Click(sender As Object, e As EventArgs)
        Try
            mensaje = "Gracias por dejar tu opinion"
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & mensaje & "')", True)

            For a As Integer = 0 To Repeater1.Items.Count - 1
                Dim rb As RadioButtonList = Repeater1.Items(a).FindControl("rbPreguntas")
                If EncuestaBLL.ObtenerInstancia.Votar(rb.SelectedValue) Then

                End If
            Next

            Response.Redirect("Index.aspx")

        Catch ex As Exception

        End Try
    End Sub


End Class