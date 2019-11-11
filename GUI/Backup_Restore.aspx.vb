Imports System.IO
Imports BE
Imports BLL

Public Class Backup_Restore
    Inherits System.Web.UI.Page


    Dim usuario_logueado As UsuarioBE
    Dim mensaje As String
    Dim fileName As String
    Dim localPath As String
    Dim serverPath As String
    Dim fileExtension As String
    Dim b As New Backup_RestoreBE


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            FileUpload1.Attributes.Add("onchange", "return checkFileExtension(this);")
        End If
    End Sub

    Private Sub btn_RealizarBackUp_Click(sender As Object, e As EventArgs) Handles btn_RealizarBackUp.Click
        Try
            usuario_logueado = GestorSesion.ObtenerSesionActual.UsuarioActivo

            Dim pathBackup As String = ConfigurationManager.AppSettings("BACKUP_PATH") & "/" & "Mokar" & DateTime.Now.ToString("_MMddyyyy_HHmmss") & ".bak"
            Dim pathDataBase As String = ConfigurationManager.AppSettings("DATABASE")

            If Backup_RestoreBLL.ObtenerInstancia.Realizar_BackUp(usuario_logueado, pathBackup, pathDataBase) Then
                descargarArchivo(pathBackup)
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('Se hizo el backup correctamente!')", True)
            Else
                Throw New Exception
            End If
        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & "Hubo un error al generar el backup" & "')", True)
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


    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If FileUpload1.FileName = "" Then
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('Debe seleccionar un archivo!')", True)

            Else


                Dim pathDataBase As String = ConfigurationManager.AppSettings("DATABASE")

                Dim pth As String = ConfigurationManager.AppSettings("BACKUP_PATH") & "/" & FileUpload1.FileName

                FileUpload1.PostedFile.SaveAs(pth)

                Dim pathBackup As String = ConfigurationManager.AppSettings("BACKUP_PATH")

                If Backup_RestoreBLL.ObtenerInstancia.Realizar_Restore(pathDataBase, pth) Then
                    GestorSesion.ObtenerSesionActual.CerrarSesion()
                    Session.Clear()
                    Response.Redirect("Index.aspx")
                Else
                    Throw New Exception
                End If
            End If
        Catch ex As Exception
            mensaje = "No se pudo cargar el backup"
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & mensaje & "')", True)
        End Try
    End Sub


End Class