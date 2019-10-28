Imports System.IO
Imports BE
Imports BLL

Public Class Backup_Restore
    Inherits System.Web.UI.Page


    Dim usuario_logueado As UsuarioBE
    Dim mensaje As String
    Dim mensajeEasy As String
    Dim fileName As String
    Dim localPath As String
    Dim serverPath As String
    Dim fileExtension As String
    Dim b As New Backup_RestoreBE


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Cargar_Grilla()
        End If
    End Sub

    Private Sub btn_RealizarBackUp_Click(sender As Object, e As EventArgs) Handles btn_RealizarBackUp.Click
        Try
            usuario_logueado = GestorSesion.ObtenerSesionActual.UsuarioActivo

            Dim pathBackup As String = ConfigurationManager.AppSettings("BACKUP_PATH") & "/" & "Mokar" & DateTime.Now.ToString("_MMddyyyy_HHmmss") & ".bak"
            Dim pathDataBase As String = ConfigurationManager.AppSettings("DATABASE")

            mensaje = Backup_RestoreBLL.ObtenerInstancia.Realizar_BackUp(usuario_logueado, pathBackup, pathDataBase)
            UpdateMensaje(mensaje)

            descargarArchivo(pathBackup)
        Catch ex As Exception
            mensajeEasy = "Easy Travel informa: " & ex.Message
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & mensaje & "')", True)
        End Try
    End Sub

    Sub descargarArchivo(ruta As String)
        Try
            Dim FilePath As String = ruta
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

    Public Sub Cargar_Grilla()
        Dim lista As New List(Of Backup_RestoreBE)
        Dim pathBackup As String = ConfigurationManager.AppSettings("BACKUP_PATH")
        lista = Backup_RestoreBLL.ObtenerInstancia.Listar_BackUps_Disponibles(pathBackup)

        DG_BackUp.DataSource = Nothing
        DG_BackUp.DataSource = lista
        DG_BackUp.DataBind()

        Session.Add("lista_bk", lista)

    End Sub


    Protected Sub UpdateMensaje(mensaje As String)
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & mensaje & "')", True)
    End Sub

    Private Sub tag_gvBackUp_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles DG_BackUp.PageIndexChanging
        DG_BackUp.PageIndex = e.NewPageIndex
        DG_BackUp.DataSource = Session("lista_bk")
        DG_BackUp.DataBind()
    End Sub

    Private Sub DG_BackUp_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DG_BackUp.SelectedIndexChanged
        Dim backup As New Backup_RestoreBE
        Dim row As GridViewRow
        row = DG_BackUp.SelectedRow
    End Sub

    Private Sub DG_BackUp_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles DG_BackUp.RowCommand
        Try
            usuario_logueado = GestorSesion.ObtenerSesionActual.UsuarioActivo
            If e.CommandName = "Restore" Then
                Dim nombre As String
                nombre = Convert.ToString(e.CommandArgument)

                Dim pathBackup As String = ConfigurationManager.AppSettings("BACKUP_PATH")
                Dim pathDataBase As String = ConfigurationManager.AppSettings("DATABASE")

                mensaje = Backup_RestoreBLL.ObtenerInstancia.Realizar_Restore(nombre, usuario_logueado.mail, pathDataBase, pathBackup)
                UpdateMensaje(mensaje)
            End If
        Catch ex As Exception
            mensajeEasy = "Easy Travel informa: " & ex.Message
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & mensaje & "')", True)
        End Try
    End Sub

    Private Sub DG_BackUp_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs) Handles DG_BackUp.RowDataBound
        Try
            'Anadir javascript de confirmacion para cada linkbutton
            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim ib As ImageButton = e.Row.FindControl("btn_Restaurar")
                ib.Attributes.Add("onclick", "javascript:return confirm('¿Está seguro de que desea restaurar el BackUp: " & DataBinder.Eval(e.Row.DataItem, "Nombre") & "?')")
                b = DirectCast(e.Row.DataItem, Backup_RestoreBE)
            End If
        Catch ex As Exception
            mensajeEasy = "Easy Travel informa: " & ex.Message
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & mensaje & "')", True)
        End Try
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim pathDataBase As String = ConfigurationManager.AppSettings("DATABASE")

            Dim pth As String = ConfigurationManager.AppSettings("BACKUP_PATH") & "/" & FileUpload1.FileName

            FileUpload1.PostedFile.SaveAs(pth)

            Dim pathBackup As String = ConfigurationManager.AppSettings("BACKUP_PATH")

            Backup_RestoreBLL.ObtenerInstancia.Realizar_Restore(pathDataBase, pth)

            GestorSesion.ObtenerSesionActual.CerrarSesion()
            Session.Clear()
            Response.Redirect("Index.aspx")

        Catch ex As Exception

        End Try
    End Sub


End Class