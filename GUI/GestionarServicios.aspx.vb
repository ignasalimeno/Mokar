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
            file_Imagen.Attributes.Add("onchange", "return checkFileExtension(this);")
            CargarGrilla()
        End If
    End Sub

    Private Sub CargarGrilla()
        Try
            Session("ListaServicios") = oObjBLL.ListarObjetos()
            Me.GvObjetos.DataSource = Session("ListaServicios")
            Me.GvObjetos.DataBind()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Limpiar()
        Try
            Me.txtDescr.Text = ""
            Me.txtNombre.Text = ""
            txtPrecio.Text = ""
            dd_accesoPlataforma.SelectedIndex = 0
            dd_capacitaciones.SelectedIndex = 0
            dd_materiaEstudio.SelectedIndex = 0
            dd_reportes.SelectedIndex = 0
            Panel1.Visible = False
        Catch ex As Exception

        End Try


    End Sub

    Protected Sub GvObjetos_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles GvObjetos.SelectedIndexChanging
        Try
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
        Catch ex As Exception

        End Try


    End Sub


    Protected Sub BtnAlta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAlta.Click
        Try
            If txtDescr.Text.Trim = "" Or txtNombre.Text.Trim() = "" Or txtPrecio.Text = "" Or RegularExpressionValidator1.IsValid = False Then
                Throw New Exception("Debe completar todos los campos")
            End If

            If BtnAlta.CommandName = "Alta" Then
                If file_Imagen.FileName = "" Then
                    Throw New Exception("Debe cargar una imagen")
                End If

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
                ''Dim fileSize As Int16 = postedFile.ContentLength

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

            ElseIf BtnAlta.CommandName = "Modificar" Then

                oObjBE.idServicio = Session("idSer")

                If Me.txtDescr.Text <> "" Then
                    oObjBE.nombre = txtNombre.Text
                    oObjBE.descripcion = txtDescr.Text
                    oObjBE.precio = txtPrecio.Text
                    oObjBE.accesoPlataforma = dd_accesoPlataforma.Text
                    oObjBE.materialEstudio = dd_materiaEstudio.Text
                    oObjBE.reportes = dd_reportes.Text
                    oObjBE.capacitaciones = dd_capacitaciones.Text
                    If file_Imagen.FileName <> "" Then


                        Dim postedFile As HttpPostedFile = file_Imagen.PostedFile
                        Dim filename As String = Path.GetFileName(postedFile.FileName)
                        Dim fileExtension As String = Path.GetExtension(filename)
                        ''Dim fileSize As Integer = postedFile.ContentLength

                        Try
                            Dim stream As Stream = postedFile.InputStream
                            Dim BinaryReader As New BinaryReader(stream)
                            Dim bytes As Byte() = BinaryReader.ReadBytes(Integer.Parse(stream.Length))

                            oObjBE.imagenData = bytes
                        Catch ex As Exception
                            Throw New Exception("Error al querer cargar la imagen.")
                        End Try
                    Else
                        oObjBE.imagenData = Nothing
                    End If

                    oObjBE.activo = 1

                    oObjBLL.Modificacion(oObjBE)
                    Limpiar()
                    CargarGrilla()
                End If

            End If

        Catch ex As Exception
            mensaje = "Hubo un error. " & ex.Message
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & mensaje & "')", True)
        End Try
    End Sub

    Protected Sub BtnModificar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnModificar.Click
        Try

            Limpiar()
        Catch ex As Exception
            mensaje = "Hubo un error. " & ex.Message
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & mensaje & "')", True)
        End Try
    End Sub

    Private Sub GvObjetos_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles GvObjetos.RowDeleting
        Try
            If GvObjetos.Rows.Count = 1 Then
                Throw New Exception("Antes de eliminar el único servicio, tiene que crear nuevos.")
            End If
            oObjBE.idServicio = GvObjetos.DataKeys(e.RowIndex).Value
            oObjBLL.Baja(oObjBE)
            Limpiar()
            CargarGrilla()
        Catch ex As Exception
            mensaje = "Hubo un error. " & ex.Message
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & mensaje & "')", True)
        End Try
    End Sub

    Protected Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Try
            Limpiar()
            Panel1.Visible = True
            BtnAlta.CommandName = "Alta"
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GvObjetos_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GvObjetos.RowCommand
        Try
            Panel1.Visible = True
            BtnAlta.CommandName = "Modificar"

            Dim a As ServiciosBE = ServiciosBLL.ObtenerInstancia.ListarObjeto(New ServiciosBE() With {.idServicio = e.CommandArgument})

            txtNombre.Text = a.nombre
            txtDescr.Text = a.descripcion
            txtPrecio.Text = a.precio
            dd_accesoPlataforma.Text = a.accesoPlataforma
            dd_materiaEstudio.Text = a.materialEstudio
            dd_reportes.Text = a.reportes
            dd_capacitaciones.Text = a.capacitaciones

            Session("idSer") = e.CommandArgument

        Catch ex As Exception

        End Try
    End Sub
End Class