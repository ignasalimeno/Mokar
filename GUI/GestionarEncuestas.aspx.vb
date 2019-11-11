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
        Try
            Dim miEnc As EncuestaBE = EncuestaBLL.ObtenerInstancia.Cargar(New EncuestaBE With {.idEncuesta = Session("idEncuesta")})
            GV_Preguntas.DataSource = Nothing
            GV_Preguntas.DataSource = miEnc.Preguntas
            GV_Preguntas.DataBind()
            Panel1.Visible = True
        Catch ex As Exception

        End Try

    End Sub

    Sub cargarRespuestas()
        Try
            Dim miListRtas As List(Of EncuestaRespuestasBE) = EncuestaBLL.ObtenerInstancia.CargarRespuestas(New EncuestaPreguntaBE With {.idPregunta = Session("idPre")})

            Respuestas.DataSource = Nothing
            Respuestas.DataSource = miListRtas
            Respuestas.DataBind()


            Panel2.Visible = True
        Catch ex As Exception

        End Try

    End Sub

    Private Sub DG_Encuestas2_SelectedIndexChanging(sender As Object, e As GridViewSelectEventArgs) Handles DG_Encuestas2.SelectedIndexChanging
        Try

            contenido.Visible = True

            Session("idEncuesta") = DG_Encuestas2.Rows(e.NewSelectedIndex).Cells(1).Text
            Dim idEnc As Integer = DG_Encuestas2.Rows(e.NewSelectedIndex).Cells(1).Text
            TB_Titulo.Text = DG_Encuestas2.Rows(e.NewSelectedIndex).Cells(3).Text
            TB_Fecha.Text = Date.Parse(DG_Encuestas2.Rows(e.NewSelectedIndex).Cells(4).Text).ToString("dd-MM-yyyy")
            DDL_Tipo.SelectedValue = DG_Encuestas2.Rows(e.NewSelectedIndex).Cells(2).Text

            btnConfirmar.CommandName = "Modificar"
            cargarPreguntas()
            preguntas.Visible=True

        Catch ex As Exception

        End Try
    End Sub

    Private Sub GV_Preguntas_SelectedIndexChanging(sender As Object, e As GridViewSelectEventArgs) Handles GV_Preguntas.SelectedIndexChanging
        Try
            Session("idPre") = GV_Preguntas.Rows(e.NewSelectedIndex).Cells(1).Text
            txtPregunta.Text = GV_Preguntas.Rows(e.NewSelectedIndex).Cells(2).Text
            cargarRespuestas()
            PanelRespuestas.Visible = True
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
            If GV_Preguntas.Rows.Count > 0 And DDL_Tipo.SelectedValue = 1 Then
                Throw New Exception("No puede agregar más de una pregunta a la encuesta")
            Else

                If txtPregunta.Text <> "" Then
                    EncuestaBLL.ObtenerInstancia.AltaPregunta(Session("idEncuesta"), New EncuestaPreguntaBE With {.Pregunta = txtPregunta.Text})
                    cargarPreguntas()
                End If
            End If

        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & ex.Message & "')", True)
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
            If GV_Preguntas.Rows.Count <= 1 Then
                Dim mensaje As String = "No puede eliminar la única pregunta. Primero agregue otra"
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & mensaje & "')", True)
            Else
                EncuestaBLL.ObtenerInstancia.EliminarPregunta(Session("idEncuesta"), New EncuestaPreguntaBE With {.idPregunta = Session("idPre"), .Pregunta = txtPregunta.Text})
                cargarPreguntas()
            End If

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
            If Respuestas.Rows.Count <= 1 Then
                Dim mensaje As String = "No puede eliminar la única respuesta. Primero agregue otra"
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & mensaje & "')", True)
            Else
                EncuestaBLL.ObtenerInstancia.EliminarRta(Session("idPre"), New EncuestaRespuestasBE With {.idRespuesta = Session("idRta"), .Respuesta = txtRta.Text})
                cargarRespuestas()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnNuevaEncuesta_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click
        Try
            If Not RegularExpressionValidator1.IsValid Then
                Throw New Exception("Ingrese una fecha valida")
            End If
            If TB_Titulo.Text.Trim() = "" Or TB_Fecha.Text.Trim() = "" Then
                Throw New Exception("Debe ingresar todos los campos")
            End If
            If btnConfirmar.CommandName = "Alta" Then
                confirmarNuevaEncuesta()
            ElseIf btnConfirmar.CommandName = "Modificar" Then
                confirmarModificarEncuesta()
            End If
        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & ex.Message & "')", True)

        End Try
    End Sub

    Sub confirmarNuevaEncuesta()
        Try
            If RegularExpressionValidator1.IsValid Then
                If Date.Parse(TB_Fecha.Text) > Now Then
                    Dim miEnc As New EncuestaBE
                    miEnc.idEncuesta = 1
                    miEnc.idTipoEncuesta = DDL_Tipo.SelectedValue
                    miEnc.Titulo = TB_Titulo.Text
                    miEnc.FechaVencimiento = TB_Fecha.Text

                    Session("idEncuesta") = EncuestaBLL.ObtenerInstancia.Crear(miEnc)

                    cargarEncuestas()

                    PanelRespuestas.Visible = True
                    preguntas.Visible = True
                    Panel1.Visible = True
                    Panel2.Visible = True

                    DG_Encuestas2.Rows(DG_Encuestas2.Rows.Count - 1).RowState = DataControlRowState.Selected
                Else
                    Throw New Exception("La fecha seleccionada debe ser posterior al día de hoy")
                End If
            End If

        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & ex.Message & "')", True)
        End Try
    End Sub

    Sub confirmarModificarEncuesta()
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

    Private Sub btnEditarEncuesta_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Try
            contenido.Visible = False
            DG_Encuestas2.SelectedIndex = -1
            limpiar()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DG_Encuestas2_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles DG_Encuestas2.RowDeleting
        Try

            Dim miEnc As New EncuestaBE
            miEnc.idEncuesta = DG_Encuestas2.DataKeys(e.RowIndex).Value

            If EncuestaBLL.ObtenerInstancia.Eliminar(miEnc) Then
                cargarEncuestas()
            End If

            contenido.Visible = False

        Catch ex As Exception
            Dim mensaje As String = "Hubo un error. " & ex.Message
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & mensaje & "')", True)
        End Try
    End Sub

    Protected Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Try
            btnConfirmar.CommandName = "Alta"
            limpiar()
            contenido.Visible = True
            DG_Encuestas2.SelectedIndex = -1
        Catch ex As Exception

        End Try
    End Sub

    Sub limpiar()
        Try
            cargarTipos()
            TB_Fecha.Text = Now.Date
            TB_Titulo.Text = ""
            GV_Preguntas.DataSource = Nothing
            'GV_Preguntas.DataBind()
            Respuestas.DataSource = Nothing
            'Respuestas.DataBind()
            preguntas.Visible = False
            PanelRespuestas.Visible = False
            contenido.Visible = False
            Panel1.Visible = False
            Panel2.Visible = False
            txtPregunta.Text = ""
            txtRta.Text = ""

        Catch ex As Exception

        End Try
    End Sub
End Class