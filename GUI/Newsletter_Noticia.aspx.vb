Imports BE
Imports BLL

Public Class Neswletter_Noticia
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (Page.IsPostBack) Then
            cargarNoticia()
        End If
    End Sub

    Sub cargarNoticia()
        Try
            Dim id As Integer = Session("idNoticia")

            Dim miNoticia As New NewsletterBE
            miNoticia.idNewsletter = id
            miNoticia = NewsletterBLL.ObtenerInstancia.ListarObjeto(miNoticia)

            imgNews.ImageUrl = "data:Image/png;base64," + Convert.ToBase64String(miNoticia.imagen)
            lblTitulo.Text = miNoticia.titulo
            lblCat.InnerText = miNoticia.categoriaDescr
            lblAutor.Text = "by " & miNoticia.autor

            Dim listNoticia As New List(Of NewsletterBE)
            listNoticia.Add(miNoticia)

            Repeater1.DataSource = listNoticia
            Repeater1.DataBind()

            lblFecha.Text = miNoticia.fechaCreacion

        Catch ex As Exception

        End Try
    End Sub

End Class