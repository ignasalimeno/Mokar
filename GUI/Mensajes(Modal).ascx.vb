Public Class Mensajes_Modal_
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Public Sub Mostrar(Texto As String)
        L_Mensaje.InnerText = Texto
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "openModal", "window.onload = function() { $('#Mensaje_Modal').modal('show'); }", True)
    End Sub


End Class