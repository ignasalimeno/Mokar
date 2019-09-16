Imports BE
Imports BLL

Public Class Servicios_Comparacion
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            cargarGrilla()
            cargarComentarios()
        End If
    End Sub

    Private Sub btn_salir_Click(sender As Object, e As EventArgs) Handles btn_salir.Click
        Response.Redirect("Servicios.aspx")
    End Sub

    Private Sub cargarGrilla()
        Try

            Dim miLista As New List(Of ServiciosBE)
            miLista = Session("Lista")

            If miLista.Count = 1 Then
                Panel1.Visible = True
            End If


            Dim dt As New DataTable
            dt.Columns.Add("ColComparacion")
            dt.Columns.Add("servicio1")
            dt.Columns.Add("servicio2")
            dt.Columns.Add("servicio3")
            dt.Columns.Add("servicio4")

            Dim drow As DataRow = dt.NewRow()

            drow(0) = "Nombre"
            For a As Integer = 0 To miLista.Count - 1
                drow(a + 1) = miLista(a).nombre
            Next
            dt.Rows.Add(drow)

            drow = dt.NewRow()
            drow(0) = "Descripcion"
            For a As Integer = 0 To miLista.Count - 1
                drow(a + 1) = miLista(a).descripcion
            Next
            dt.Rows.Add(drow)

            drow = dt.NewRow()
            drow(0) = "Precio"
            For a As Integer = 0 To miLista.Count - 1
                drow(a + 1) = "$ " & miLista(a).precio
            Next
            dt.Rows.Add(drow)

            drow = dt.NewRow()
            drow(0) = "Acceso a la Plataforma"
            For a As Integer = 0 To miLista.Count - 1
                drow(a + 1) = miLista(a).accesoPlataforma
            Next
            dt.Rows.Add(drow)

            drow = dt.NewRow()
            drow(0) = "Material de Estudio"
            For a As Integer = 0 To miLista.Count - 1
                drow(a + 1) = miLista(a).materialEstudio
            Next
            dt.Rows.Add(drow)

            drow = dt.NewRow()
            drow(0) = "Reportes"
            For a As Integer = 0 To miLista.Count - 1
                drow(a + 1) = miLista(a).reportes
            Next
            dt.Rows.Add(drow)

            drow = dt.NewRow()
            drow(0) = "Capacitaciones"
            For a As Integer = 0 To miLista.Count - 1
                drow(a + 1) = miLista(a).capacitaciones
            Next
            dt.Rows.Add(drow)

            For a As Integer = 0 To miLista.Count - 1
                GvServicios.Columns(a + 1).Visible = True
            Next

            GvServicios.DataSource = Nothing
            GvServicios.DataSource = dt
            GvServicios.DataBind()



        Catch ex As Exception

        End Try
    End Sub

    Private Sub cargarComentarios()
        Try
            Dim miLista As New List(Of ServiciosBE)
            miLista = Session("Lista")

            If miLista.Count = 1 Then
                RP_Comentarios.DataSource = Nothing
                RP_Comentarios.DataSource = ServiciosBLL.ObtenerInstancia.ListarComentarios(miLista(0))
                RP_Comentarios.DataBind()
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub btn_AgregarComentarioModal_Click(sender As Object, e As EventArgs) Handles btn_AgregarComentarioModal.Click
        Try
            Dim miLista As New List(Of ServiciosBE)
            miLista = Session("Lista")
            Dim nuevoComentario As New ServiciosComentariosBE With {.nombre = txtNombre.Text, .detalle = txtDetalle.Text, .fechaHora = Now, .idServicio = miLista(0).idServicio}
            If ServiciosBLL.ObtenerInstancia.AgregarComentario(nuevoComentario) Then
                Response.Redirect("Servicios_Comparacion.aspx")
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnAgregarRta_Modal_Click(sender As Object, e As EventArgs) Handles btnAgregarRta_Modal.Click
        Try
            Dim idComentario As String = HiddenField1.Value
            Dim nuevoComentario As New ServiciosComentariosBE With {.nombre = txtNombreRta.Text & " de Mokar", .detalle = txtDetalleRta.Text, .fechaHora = Now, .idServicio = idComentario}
            If ServiciosBLL.ObtenerInstancia.AgregarRespuesta(nuevoComentario) Then
                Response.Redirect("Servicios_Comparacion.aspx", False)
            End If
        Catch ex As Exception
        End Try


    End Sub
End Class