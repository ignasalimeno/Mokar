Public Class ModalEstrellas
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Public Sub Mostrar(Texto As Integer)
        Try
            Session("idServicioVoto") = Texto
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "openModal", "window.onload = function() { $('#MensajeEstrellas').modal('show'); }", True)
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub img1_Click(sender As Object, e As ImageClickEventArgs) Handles img1.Click
        img1.ImageUrl = "~/img/completa.png"
        img2.ImageUrl = "~/img/vacia.png"
        img3.ImageUrl = "~/img/vacia.png"
        img4.ImageUrl = "~/img/vacia.png"
        img5.ImageUrl = "~/img/vacia.png"
        Session("votacion") = 1
    End Sub

    Private Sub img2_Click(sender As Object, e As ImageClickEventArgs) Handles img2.Click
        img1.ImageUrl = "~/img/completa.png"
        img2.ImageUrl = "~/img/completa.png"
        img3.ImageUrl = "~/img/vacia.png"
        img4.ImageUrl = "~/img/vacia.png"
        img5.ImageUrl = "~/img/vacia.png"
        Session("votacion") = 2
    End Sub

    Private Sub img3_Click(sender As Object, e As ImageClickEventArgs) Handles img3.Click
        img1.ImageUrl = "~/img/completa.png"
        img2.ImageUrl = "~/img/completa.png"
        img3.ImageUrl = "~/img/completa.png"
        img4.ImageUrl = "~/img/vacia.png"
        img5.ImageUrl = "~/img/vacia.png"
        Session("votacion") = 3
    End Sub

    Private Sub img4_Click(sender As Object, e As ImageClickEventArgs) Handles img4.Click
        img1.ImageUrl = "~/img/completa.png"
        img2.ImageUrl = "~/img/completa.png"
        img3.ImageUrl = "~/img/completa.png"
        img4.ImageUrl = "~/img/completa.png"
        img5.ImageUrl = "~/img/vacia.png"
        Session("votacion") = 4
    End Sub

    Private Sub img5_Click(sender As Object, e As ImageClickEventArgs) Handles img5.Click
        img1.ImageUrl = "~/img/completa.png"
        img2.ImageUrl = "~/img/completa.png"
        img3.ImageUrl = "~/img/completa.png"
        img4.ImageUrl = "~/img/completa.png"
        img5.ImageUrl = "~/img/completa.png"
        Session("votacion") = 5
    End Sub

    Private Sub btnVotar_Click(sender As Object, e As EventArgs) Handles btnVotar.Click

        BLL.ServiciosBLL.ObtenerInstancia.AgregarVoto(Session("idServicioVoto"), Session("votacion"), BLL.GestorSesion.ObtenerSesionActual.UsuarioActivo)


    End Sub
End Class