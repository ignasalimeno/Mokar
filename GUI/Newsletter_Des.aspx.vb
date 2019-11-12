Imports BLL

Public Class Newsletter_Des
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim mail As String = Criptografia.Desencriptar(Request.QueryString("Mail"))
            Session("MailDes") = mail
        End If
    End Sub

    Private Sub btn_Enviar_Click(sender As Object, e As EventArgs) Handles btn_Enviar.Click
        Try
            If validar() Then
                Response.Redirect("Index.aspx")
            End If
        Catch ex As Exception

        End Try

    End Sub

    Function validar() As Boolean
        Try
            If TB_Mail.Text = Session("MailDes") Then
                NewsletterBLL.ObtenerInstancia.Desuscribirse(New BE.UsuarioBE With {.mail = TB_Mail.Text})
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
End Class