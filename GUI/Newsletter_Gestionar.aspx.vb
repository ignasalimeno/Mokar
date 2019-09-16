Imports System.IO
Imports BE
Imports BLL

Public Class Newsletter_Gestionar
    Inherits System.Web.UI.Page

    Private oObjBE As New BE.NewsletterBE
    Private oObjBLL As New BLL.NewsletterBLL
    Dim mensaje As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (Page.IsPostBack) Then
            CargarGrilla()
            cargarCategorias()
        End If
    End Sub

    Private Sub CargarGrilla()
        Session("ListaNewsletter") = oObjBLL.ListarObjetos()
        Me.GvObjetos.DataSource = Session("ListaNewsletter")
        Me.GvObjetos.DataBind()
    End Sub

    Private Sub Limpiar()
        Me.txtDescr.Text = ""
    End Sub

    Protected Sub BtnLimpiar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnLimpiar.Click
        Limpiar()
    End Sub

    Protected Sub BtnAlta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAlta.Click
        Try
            oObjBE.idNewsletter = 1
            oObjBE.titulo = txtTitulo.Text
            oObjBE.descripcion = txtDescr.Text
            oObjBE.autor = txtAutor.Text
            oObjBE.fechaCreacion = txtFecha.Text

            Try
                Dim postedFile As HttpPostedFile = file_Imagen.PostedFile
                Dim filename As String = Path.GetFileName(postedFile.FileName)
                Dim fileExtension As String = Path.GetExtension(filename)
                'Dim fileSize As ULong = postedFile.ContentLength
                Dim stream As Stream = postedFile.InputStream
                Dim BinaryReader As New BinaryReader(stream)
                Dim bytes As Byte() = BinaryReader.ReadBytes(Integer.Parse(stream.Length))

                oObjBE.imagen = bytes
            Catch ex As Exception
                Throw New Exception("Error al querer cargar la imagen.")
            End Try

            oObjBE.idCategoria = DDL_Categoria.SelectedValue
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


            oObjBE.idNewsletter = Me.GvObjetos.SelectedRow.Cells(1).Text

            If Me.txtDescr.Text <> "" Then
                oObjBE.titulo = txtTitulo.Text
                oObjBE.descripcion = txtDescr.Text
                oObjBE.autor = txtAutor.Text
                oObjBE.fechaCreacion = txtFecha.Text

                Dim postedFile As HttpPostedFile = file_Imagen.PostedFile
                Dim filename As String = Path.GetFileName(postedFile.FileName)
                Dim fileExtension As String = Path.GetExtension(filename)
                Dim fileSize As Int16 = postedFile.ContentLength

                Try
                    Dim stream As Stream = postedFile.InputStream
                    Dim BinaryReader As New BinaryReader(stream)
                    Dim bytes As Byte() = BinaryReader.ReadBytes(Integer.Parse(stream.Length))

                    oObjBE.imagen = bytes
                Catch ex As Exception
                    Throw New Exception("Error al querer cargar la imagen.")
                End Try

                oObjBE.idCategoria = DDL_Categoria.SelectedValue
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

            oObjBE.idNewsletter = Me.GvObjetos.SelectedRow.Cells(1).Text
            oObjBLL.Baja(oObjBE)
            Limpiar()
            CargarGrilla()
        Catch ex As Exception
            mensaje = "Hubo un error. " & ex.Message
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & mensaje & "')", True)
        End Try

    End Sub

    Sub descargarArchivo(ruta As String)
        Try
            Dim FilePath As String = Server.MapPath("Newsletter/" & ruta)
            Dim TargetFile As New System.IO.FileInfo(FilePath)


            Response.Clear()

            Response.AddHeader("Content-Disposition", "attachment; filename=" + TargetFile.Name)
            Response.AddHeader("Content-Length", TargetFile.Length.ToString())
            Response.ContentType = "application/octet-stream"
            Response.WriteFile(TargetFile.FullName)
            Response.End()
        Catch ex As Exception
            'Throw New Exception
            HttpContext.Current.Response.Flush()
            HttpContext.Current.Response.SuppressContent = True
            HttpContext.Current.ApplicationInstance.CompleteRequest()
        End Try
    End Sub

    Private Sub GvObjetos_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GvObjetos.RowCommand
        Try
            If e.CommandName = "Select" Then
                descargarArchivo(e.CommandArgument)
            ElseIf e.CommandName = "idme" Then
                cargarDatosObjeto(e.CommandArgument)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Sub cargarDatosObjeto(idNewsletter As Integer)
        Dim miLista As List(Of NewsletterBE) = Session("ListaNewsletter")

        For Each a As NewsletterBE In miLista
            If a.idNewsletter = idNewsletter Then
                txtAutor.Text = a.autor
                txtDescr.Text = a.descripcion
                txtTitulo.Text = a.titulo
                txtFecha.Text = a.fechaCreacion
            End If
        Next
    End Sub

    Sub cargarCategorias()
        Try
            DDL_Categoria.DataSource = Nothing
            DDL_Categoria.DataSource = CategoriaBLL.ObtenerInstancia.ListarObjetos
            DDL_Categoria.DataValueField = "idCategoria"
            DDL_Categoria.DataTextField = "descripcion"
            DDL_Categoria.DataBind()

        Catch ex As Exception

        End Try
    End Sub

End Class