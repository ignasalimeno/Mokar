Public Class Newslatter
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (Page.IsPostBack) Then
            cargarGrilla()
            cargarCategorias()
        End If
    End Sub

    Protected Sub cargarGrilla()
        Try
            RP_Noticias.DataSource = Nothing
            RP_Noticias.DataSource = BLL.NewsletterBLL.ObtenerInstancia.ListarObjetos
            RP_Noticias.DataBind()

        Catch ex As Exception

        End Try
    End Sub

    Sub cargarCategorias()
        Try
            RP_Categorias.DataSource = Nothing
            RP_Categorias.DataSource = BLL.CategoriaBLL.ObtenerInstancia.ListarObjetos
            RP_Categorias.DataBind()

        Catch ex As Exception

        End Try
    End Sub

End Class