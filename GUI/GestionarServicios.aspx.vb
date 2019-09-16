Imports System.IO
Imports BE
Imports BLL

Public Class GestionarServicios
    Inherits System.Web.UI.Page

    Private oObjBE As New BE.ServiciosBE
    Private oObjBLL As New BLL.ServiciosBLL
    Dim mensaje As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (Page.IsPostBack) Then
            CargarGrilla()
        End If
    End Sub

    Private Sub CargarGrilla()
        Session("ListaServicios") = oObjBLL.ListarObjetos()
        Me.GvObjetos.DataSource = Session("ListaServicios")
        Me.GvObjetos.DataBind()
    End Sub

    Private Sub Limpiar()
        Me.txtDescr.Text = ""
    End Sub

    Protected Sub GvObjetos_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles GvObjetos.SelectedIndexChanging
        Dim miLista As List(Of ServiciosBE) = Session("ListaServicios")

        For Each a As ServiciosBE In miLista
            If a.idServicio = GvObjetos.Rows(e.NewSelectedIndex).Cells(1).Text Then
                txtNombre.Text = a.nombre
                txtDescr.Text = a.descripcion
                txtPrecio.Text = a.precio
                dd_accesoPlataforma.Text = a.accesoPlataforma
                dd_materiaEstudio.Text = a.materialEstudio
                dd_reportes.Text = a.reportes
                dd_capacitaciones.Text = a.capacitaciones
            End If
        Next

    End Sub

    Protected Sub BtnLimpiar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnLimpiar.Click
        Limpiar()
    End Sub

    Protected Sub BtnAlta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAlta.Click
        Try
            oObjBE.idServicio = 1
            oObjBE.nombre = txtNombre.Text
            oObjBE.descripcion = txtDescr.Text
            oObjBE.precio = txtPrecio.Text
            oObjBE.accesoPlataforma = dd_accesoPlataforma.Text
            oObjBE.materialEstudio = dd_materiaEstudio.Text
            oObjBE.reportes = dd_reportes.Text
            oObjBE.capacitaciones = dd_capacitaciones.Text

            Dim postedFile As HttpPostedFile = file_Imagen.PostedFile
            Dim filename As String = Path.GetFileName(postedFile.FileName)
            Dim fileExtension As String = Path.GetExtension(filename)
            Dim fileSize As Int16 = postedFile.ContentLength

            Try
                Dim stream As Stream = postedFile.InputStream
                Dim BinaryReader As New BinaryReader(stream)
                Dim bytes As Byte() = BinaryReader.ReadBytes(Integer.Parse(stream.Length))

                oObjBE.imagenData = bytes
            Catch ex As Exception
                Throw New Exception("Error al querer cargar la imagen.")
            End Try


            oObjBE.activo = 1

            oObjBLL.Alta(oObjBE)
            Limpiar()
            CargarGrilla()
        Catch ex As Exception
            mensaje = "Hubo un error. " & ex.Message
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & mensaje & "')", True)
        End Try
    End Sub

    Protected Sub BtnModificar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnModificar.Click
        Try


            oObjBE.idServicio = Me.GvObjetos.SelectedRow.Cells(1).Text

            If Me.txtDescr.Text <> "" Then
                oObjBE.nombre = txtNombre.Text
                oObjBE.descripcion = txtDescr.Text
                oObjBE.precio = txtPrecio.Text
                oObjBE.accesoPlataforma = dd_accesoPlataforma.Text
                oObjBE.materialEstudio = dd_materiaEstudio.Text
                oObjBE.reportes = dd_reportes.Text
                oObjBE.capacitaciones = dd_capacitaciones.Text

                Dim postedFile As HttpPostedFile = file_Imagen.PostedFile
                Dim filename As String = Path.GetFileName(postedFile.FileName)
                Dim fileExtension As String = Path.GetExtension(filename)
                Dim fileSize As Integer = postedFile.ContentLength

                Try
                    Dim stream As Stream = postedFile.InputStream
                    Dim BinaryReader As New BinaryReader(stream)
                    Dim bytes As Byte() = BinaryReader.ReadBytes(Integer.Parse(stream.Length))

                    oObjBE.imagenData = bytes
                Catch ex As Exception
                    Throw New Exception("Error al querer cargar la imagen.")
                End Try

                oObjBE.activo = 1

                oObjBLL.Modificacion(oObjBE)
                Limpiar()
                CargarGrilla()

            End If
        Catch ex As Exception
            mensaje = "Hubo un error. " & ex.Message
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & mensaje & "')", True)
        End Try
    End Sub

    Protected Sub BtnBaja_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBaja.Click
        Try

            oObjBE.idServicio = Me.GvObjetos.SelectedRow.Cells(1).Text
            oObjBLL.Baja(oObjBE)
            Limpiar()
            CargarGrilla()
        Catch ex As Exception
            mensaje = "Hubo un error. " & ex.Message
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & mensaje & "')", True)
        End Try

    End Sub


End Class