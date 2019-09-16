Public Class MaterialEstudio_Descargar
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (Page.IsPostBack) Then
            cargarGrilla()
        End If
    End Sub

    Protected Sub cargarGrilla()
        Try
            RP_Material.DataSource = Nothing
            RP_Material.DataSource = BLL.MaterialEstudioBLL.ObtenerInstancia.ListarObjetos
            RP_Material.DataBind()

        Catch ex As Exception

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
            Throw New Exception
        End Try
    End Sub

    Private Sub RP_Material_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles RP_Material.ItemCommand
        Try
            Select Case e.CommandName
                Case "descargar"
                    descargarArchivo(e.CommandArgument)
            End Select
        Catch ex As Exception

        End Try
    End Sub
End Class