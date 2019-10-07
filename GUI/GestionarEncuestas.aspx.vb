Imports BE
Imports BLL

Public Class GestionarEncuestas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            cargarTipos()
            cargarEncuestas()
        End If
    End Sub

    Sub cargarTipos()
        Try
            DDL_Tipo.Items.Add(New ListItem("Encuesta", 1))
            DDL_Tipo.Items.Add(New ListItem("Ficha de Opinion", 2))
        Catch ex As Exception

        End Try
    End Sub

    Sub cargarEncuestas()
        Try
            DG_Encuestas2.DataSource = ""
            Me.DG_Encuestas2.DataSource = EncuestaBLL.ObtenerInstancia.ListarTodas()
            Me.DG_Encuestas2.DataBind()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DG_Encuestas2_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles DG_Encuestas2.RowEditing

    End Sub
    Sub cargarPreguntas()
        Dim miEnc As EncuestaBE = EncuestaBLL.ObtenerInstancia.Cargar(New EncuestaBE With {.idEncuesta = Session("idEncuesta")})
        GV_Preguntas.DataSource = Nothing
        GV_Preguntas.DataSource = miEnc.Preguntas
        GV_Preguntas.DataBind()
        Panel1.Visible = True
    End Sub

    Sub cargarRespuestas()
        Dim miListRtas As List(Of EncuestaRespuestasBE) = EncuestaBLL.ObtenerInstancia.CargarRespuestas(New EncuestaPreguntaBE With {.idPregunta = Session("idPre")})

        Respuestas.DataSource = Nothing
        Respuestas.DataSource = miListRtas
        Respuestas.DataBind()


        Panel2.Visible = True
    End Sub

    Private Sub DG_Encuestas2_SelectedIndexChanging(sender As Object, e As GridViewSelectEventArgs) Handles DG_Encuestas2.SelectedIndexChanging
        Try
            Session("idEncuesta") = DG_Encuestas2.Rows(e.NewSelectedIndex).Cells(1).Text
            Dim idEnc As Integer = DG_Encuestas2.Rows(e.NewSelectedIndex).Cells(1).Text
            TB_Titulo.Text = DG_Encuestas2.Rows(e.NewSelectedIndex).Cells(3).Text
            TB_Fecha.Text = Date.Parse(DG_Encuestas2.Rows(e.NewSelectedIndex).Cells(4).Text).ToString("dd-MM-yyyy")

            cargarPreguntas()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub GV_Preguntas_SelectedIndexChanging(sender As Object, e As GridViewSelectEventArgs) Handles GV_Preguntas.SelectedIndexChanging
        Try
            Session("idPre") = GV_Preguntas.Rows(e.NewSelectedIndex).Cells(1).Text
            txtPregunta.Text = GV_Preguntas.Rows(e.NewSelectedIndex).Cells(2).Text
            cargarRespuestas()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Respuestas_SelectedIndexChanging(sender As Object, e As GridViewSelectEventArgs) Handles Respuestas.SelectedIndexChanging
        Try
            Session("idRta") = Respuestas.Rows(e.NewSelectedIndex).Cells(1).Text

            txtRta.Text = Respuestas.Rows(e.NewSelectedIndex).Cells(2).Text


        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnAddPregunta_Click(sender As Object, e As ImageClickEventArgs) Handles btnAddPregunta.Click
        Try
            If txtPregunta.Text <> "" Then
                EncuestaBLL.ObtenerInstancia.AltaPregunta(Session("idEncuesta"), New EncuestaPreguntaBE With {.Pregunta = txtPregunta.Text})
                cargarPreguntas()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnGuardarPre_Click(sender As Object, e As ImageClickEventArgs) Handles btnGuardarPre.Click
        Try
            If txtPregunta.Text <> "" Then
                EncuestaBLL.ObtenerInstancia.ModificarPregunta(Session("idEncuesta"), New EncuestaPreguntaBE With {.idPregunta = Session("idPre"), .Pregunta = txtPregunta.Text})
                cargarPreguntas()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnBorrarPre_Click(sender As Object, e As ImageClickEventArgs) Handles btnBorrarPre.Click
        Try
            EncuestaBLL.ObtenerInstancia.EliminarPregunta(Session("idEncuesta"), New EncuestaPreguntaBE With {.idPregunta = Session("idPre"), .Pregunta = txtPregunta.Text})
            cargarPreguntas()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnAddRta_Click(sender As Object, e As ImageClickEventArgs) Handles btnAddRta.Click
        Try
            If txtRta.Text <> "" Then
                EncuestaBLL.ObtenerInstancia.AltaRta(Session("idPre"), New EncuestaRespuestasBE With {.Respuesta = txtRta.Text})
                cargarRespuestas()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnEditRta_Click(sender As Object, e As ImageClickEventArgs) Handles btnEditRta.Click
        Try
            If txtRta.Text <> "" Then
                EncuestaBLL.ObtenerInstancia.ModificarRta(Session("idPre"), New EncuestaRespuestasBE With {.idRespuesta = Session("idRta"), .Respuesta = txtRta.Text})
                cargarRespuestas()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnBorrarRta_Click(sender As Object, e As ImageClickEventArgs) Handles btnBorrarRta.Click
        Try

            EncuestaBLL.ObtenerInstancia.EliminarRta(Session("idPre"), New EncuestaRespuestasBE With {.idRespuesta = Session("idRta"), .Respuesta = txtRta.Text})
            cargarRespuestas()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnNuevaEncuesta_Click(sender As Object, e As EventArgs) Handles btnNuevaEncuesta.Click
        Try
            If Date.Parse(TB_Fecha.Text) > Now Then
                Dim miEnc As New EncuestaBE
                miEnc.idEncuesta = 1
                miEnc.idTipoEncuesta = DDL_Tipo.SelectedValue
                miEnc.Titulo = TB_Titulo.Text
                miEnc.FechaVencimiento = TB_Fecha.Text

                Session("idEncuesta") = EncuestaBLL.ObtenerInstancia.Crear(miEnc)

                cargarEncuestas()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnEditarEncuesta_Click(sender As Object, e As EventArgs) Handles btnEditarEncuesta.Click
        Try
            If Session("idEncuesta") IsNot Nothing Then
                Dim miEnc As New EncuestaBE
                miEnc.idEncuesta = Session("idEncuesta")
                miEnc.idTipoEncuesta = DDL_Tipo.SelectedValue
                miEnc.Titulo = TB_Titulo.Text
                miEnc.FechaVencimiento = TB_Fecha.Text

                If EncuestaBLL.ObtenerInstancia.Editar(miEnc) Then
                    cargarEncuestas()
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnEliminarEncuesta_Click(sender As Object, e As EventArgs) Handles btnEliminarEncuesta.Click
        Try
            If Session("idEncuesta") IsNot Nothing Then
                Dim miEnc As New EncuestaBE
                miEnc.idEncuesta = Session("idEncuesta")

                If EncuestaBLL.ObtenerInstancia.Eliminar(miEnc) Then
                    cargarEncuestas()
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub
End Class