Imports BE
Imports MPP

Public Class NewsletterBLL
    Private Shared Instancia As NewsletterBLL
    Public Shared Function ObtenerInstancia() As NewsletterBLL
        If Instancia Is Nothing Then
            Instancia = New NewsletterBLL
        End If
        Return Instancia
    End Function

    Public Function Alta(Objeto As NewsletterBE) As Boolean
        Try
            Return NewsletterMPP.ObtenerInstancia.Alta(Objeto)

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Baja(Objeto As NewsletterBE) As Boolean
        Try
            Return NewsletterMPP.ObtenerInstancia.Baja(Objeto)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Modificacion(Objeto As NewsletterBE) As Boolean
        Try
            Return NewsletterMPP.ObtenerInstancia.Modificacion(Objeto)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function ListarObjetos() As IEnumerable(Of NewsletterBE)
        Try
            Return NewsletterMPP.ObtenerInstancia.ListarObjetos()
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function ListarObjeto(Objeto As NewsletterBE) As NewsletterBE
        Try
            Return NewsletterMPP.ObtenerInstancia.ListarObjeto(Objeto)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Suscribirse(usuario As UsuarioBE, listCat As List(Of CategoriaBE)) As Boolean
        Try
            Return NewsletterMPP.ObtenerInstancia.Suscribirse(usuario, listCat)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Desuscribirse(usuario As UsuarioBE) As Boolean
        Try
            Return NewsletterMPP.ObtenerInstancia.Desuscribirse(usuario)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function enviarNoticia(miNoticia As NewsletterBE, link As String) As Boolean
        Try
            Dim id As Integer = miNoticia.idNewsletter

            miNoticia = NewsletterMPP.ObtenerInstancia.ListarObjeto(miNoticia)

            Dim listUsuarios As List(Of UsuarioBE) = NewsletterMPP.ObtenerInstancia.ListarUsuarioCategoria(miNoticia)

            For Each a As UsuarioBE In listUsuarios
                Dim linkDes = link & "/" & "Newsletter_Des.aspx?Mail=" + System.Web.HttpUtility.UrlEncode(Criptografia.Encriptar(a.mail))
                Dim linkNew = link & "/" & "Newsletter_Noticia.aspx?idNoticia=" + System.Web.HttpUtility.UrlEncode(Criptografia.Encriptar(id))

                linkNew = "<a href=" + linkNew + ">click aqui</a>"
                linkDes = "<a href=" + linkDes + ">click aqui</a>"

                EnviarCorreo.ObtenerInstancia.EnviarNewsletter(a.mail, "Nueva Noticia - Mokar.", "<h3>" & miNoticia.titulo & "</h3><br /> " & miNoticia.fechaCreacion & " by " & miNoticia.autor & "<br />" & miNoticia.descripcion, "Template_Noticia.html", linkNew, linkDes)
            Next

            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function


End Class
