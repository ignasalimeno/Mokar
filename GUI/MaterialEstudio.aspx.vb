Imports BE
Imports BLL
Public Class MaterialEstudio
    Inherits System.Web.UI.Page

    Private oObjBE As New BE.MaterialEstudioBE
    Private oObjBLL As New BLL.MaterialEstudioBLL
    Dim mensaje As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (Page.IsPostBack) Then
            CargarGrilla()
        End If
    End Sub

    Private Sub CargarGrilla()
        Session("ListaME") = oObjBLL.ListarObjetos()
        Me.GvObjetos.DataSource = Session("ListaME")
        Me.GvObjetos.DataBind()
    End Sub

    Private Sub Limpiar()
        Me.txtDescr.Text = ""
    End Sub

    Protected Sub GvObjetos_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles GvObjetos.SelectedIndexChanging
        Dim miLista As List(Of MaterialEstudioBE) = Session("ListaME")

        For Each a As MaterialEstudioBE In miLista
            If a.idME = GvObjetos.Rows(e.NewSelectedIndex).Cells(1).Text Then
                txtAutor.Text = a.autor
                txtDescr.Text = a.descripcion
                txtTitulo.Text = a.titulo
                txtFecha.Text = a.fechaCreacion
            End If
        Next
    End Sub

    Protected Sub BtnLimpiar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnLimpiar.Click
        Limpiar()
    End Sub

    Protected Sub BtnAlta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAlta.Click
        Try
            oObjBE.idME = 1
            oObjBE.titulo = txtTitulo.Text
            oObjBE.descripcion = txtDescr.Text
            oObjBE.autor = txtAutor.Text
            oObjBE.fechaCreacion = txtFecha.Text
            oObjBE.ruta = fileArchivo.PostedFile.FileName
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


            oObjBE.idME = Me.GvObjetos.SelectedRow.Cells(1).Text

            If Me.txtDescr.Text <> "" Then
                oObjBE.titulo = txtTitulo.Text
                oObjBE.descripcion = txtDescr.Text
                oObjBE.autor = txtAutor.Text
                oObjBE.fechaCreacion = txtFecha.Text
                oObjBE.ruta = fileArchivo.PostedFile.FileName
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

            oObjBE.idME = Me.GvObjetos.SelectedRow.Cells(1).Text
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
            Dim FilePath As String = Server.MapPath("materialEstudio/" & ruta)
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

    Sub cargarDatosObjeto(idMe As Integer)
        Dim miLista As List(Of MaterialEstudioBE) = Session("ListaME")

        For Each a As MaterialEstudioBE In miLista
            If a.idME = idMe Then
                txtAutor.Text = a.autor
                txtDescr.Text = a.descripcion
                txtTitulo.Text = a.titulo
                txtFecha.Text = a.fechaCreacion
            End If
        Next
    End Sub
End Class