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
            file_Imagen.Attributes.Add("onchange", "return checkFileExtension(this);")
            CargarGrilla()
            cargarCategorias()
        End If
    End Sub

    Private Sub CargarGrilla()
        Try


            Dim lista As List(Of NewsletterBE) = oObjBLL.ListarObjetos()
            If Not lista Is Nothing Then
                Session("ListaNewsletter") = lista


                For Each a As NewsletterBE In lista
                    If a.descripcion.Length > 30 Then
                        a.descripcion = a.descripcion.Substring(0, 30) & "..."
                    End If
                Next

                Me.GvObjetos.DataSource = lista
                Me.GvObjetos.DataBind()
            End If

        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & "No se puede cargar las noticias, primero genere categorías" & "')", True)
        End Try
    End Sub

    Private Sub Limpiar()
        Me.txtDescr.Text = ""
        txtAutor.Text = ""
        txtFecha.Text = ""
        txtTitulo.Text = ""
    End Sub

    Protected Sub BtnAlta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAlta.Click
        Try
            If txtAutor.Text.Trim = "" Or txtDescr.Text.Trim = "" Or txtFecha.Text.Trim = "" Or txtTitulo.Text.Trim = "" Then
                Throw New Exception("Debe completar todos los campos")
            End If
            If BtnAlta.CommandName = "Alta" Then
                If file_Imagen.PostedFile.FileName = "" Then
                    Throw New Exception("Debe cargar una imagen")
                End If
                contenido.Visible = True

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

                contenido.Visible = False

            ElseIf BtnAlta.CommandName = "Modificar" Then

                oObjBE.idNewsletter = Session("idNew")

                If Me.txtDescr.Text <> "" Then
                    oObjBE.titulo = txtTitulo.Text
                    oObjBE.descripcion = txtDescr.Text
                    oObjBE.autor = txtAutor.Text
                    oObjBE.fechaCreacion = txtFecha.Text

                    If Not file_Imagen.PostedFile.FileName = "" Then
                        Dim postedFile As HttpPostedFile = file_Imagen.PostedFile
                        Dim filename As String = Path.GetFileName(postedFile.FileName)
                        Dim fileExtension As String = Path.GetExtension(filename)
                        'Dim fileSize As Int16 = postedFile.ContentLength

                        Try
                            Dim stream As Stream = postedFile.InputStream
                            Dim BinaryReader As New BinaryReader(stream)
                            Dim bytes As Byte() = BinaryReader.ReadBytes(Integer.Parse(stream.Length))

                            oObjBE.imagen = bytes
                        Catch ex As Exception
                            Throw New Exception("Error al querer cargar la imagen.")
                        End Try
                    Else
                        oObjBE.imagen = Nothing
                    End If


                    oObjBE.idCategoria = DDL_Categoria.SelectedValue
                    oObjBE.activo = 1

                    oObjBLL.Modificacion(oObjBE)
                    Limpiar()
                    CargarGrilla()
                End If

                contenido.Visible = False
            End If

        Catch ex As Exception
            mensaje = "Hubo un error. " & ex.Message
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & mensaje & "')", True)
        End Try
    End Sub

    Protected Sub BtnModificar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnModificar.Click
        Try
            Limpiar()
            contenido.Visible = False

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
            'HttpContext.Current.Response.Flush()
            'HttpContext.Current.Response.SuppressContent = True
            'HttpContext.Current.ApplicationInstance.CompleteRequest()
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & ex.Message & "')", True)

        End Try
    End Sub

    Private Sub GvObjetos_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GvObjetos.RowCommand
        Try

            If e.CommandName = "Select" Then
                descargarArchivo(e.CommandArgument)
            ElseIf e.CommandName = "idme" Then
                contenido.Visible = True
                BtnAlta.CommandName = "Modificar"
                cargarDatosObjeto(e.CommandArgument)
                Session("idNew") = e.CommandArgument
            ElseIf e.CommandName = "mail" Then
                Dim link As String = "http://" & Request.Url.Host & ":" & Request.Url.Port
                NewsletterBLL.ObtenerInstancia.enviarNoticia(New NewsletterBE With {.idNewsletter = e.CommandArgument}, link)
            End If
        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & ex.Message & "')", True)

        End Try
    End Sub

    Sub cargarDatosObjeto(idNewsletter As Integer)
        Try
            Dim a As NewsletterBE = NewsletterBLL.ObtenerInstancia.ListarObjeto(New NewsletterBE With {.idNewsletter = idNewsletter})

            txtAutor.Text = a.autor
            txtDescr.Text = a.descripcion
            txtTitulo.Text = a.titulo
            txtFecha.Text = a.fechaCreacion
        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & ex.Message & "')", True)

        End Try


    End Sub

    Sub cargarCategorias()
        Try
            DDL_Categoria.DataSource = Nothing
            DDL_Categoria.DataSource = CategoriaBLL.ObtenerInstancia.ListarObjetos
            DDL_Categoria.DataValueField = "idCategoria"
            DDL_Categoria.DataTextField = "descripcion"
            DDL_Categoria.DataBind()

        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & "No se puede cargar las categorias" & "')", True)
            Response.Redirect("Categorias.aspx")
        End Try
    End Sub

    Private Sub GvObjetos_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles GvObjetos.RowDeleting
        Try
            oObjBE.idNewsletter = GvObjetos.DataKeys(e.RowIndex).Value
            oObjBLL.Baja(oObjBE)
            Limpiar()
            CargarGrilla()
        Catch ex As Exception
            mensaje = "Hubo un error. " & ex.Message
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & mensaje & "')", True)
        End Try
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Try
            Limpiar()
            contenido.Visible = True
            BtnAlta.CommandName = "Alta"
        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & ex.Message & "')", True)

        End Try
    End Sub
End Class