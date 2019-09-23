Imports BE
Imports MPP

Public Class NewsletterBLL
    Implements IABMC(Of NewsletterBE)

    Private Shared Instancia As NewsletterBLL
    Public Shared Function ObtenerInstancia() As NewsletterBLL
        If Instancia Is Nothing Then
            Instancia = New NewsletterBLL
        End If
        Return Instancia
    End Function

    Public Function Alta(Objeto As NewsletterBE) As Boolean Implements IABMC(Of NewsletterBE).Alta
        Try
            Return NewsletterMPP.ObtenerInstancia.Alta(Objeto)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Baja(Objeto As NewsletterBE) As Boolean Implements IABMC(Of NewsletterBE).Baja
        Try
            Return NewsletterMPP.ObtenerInstancia.Baja(Objeto)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Modificacion(Objeto As NewsletterBE) As Boolean Implements IABMC(Of NewsletterBE).Modificacion
        Try
            Return NewsletterMPP.ObtenerInstancia.Modificacion(Objeto)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function ListarObjetos() As IEnumerable(Of NewsletterBE) Implements IABMC(Of NewsletterBE).ListarObjetos
        Try
            Return NewsletterMPP.ObtenerInstancia.ListarObjetos()
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function ListarObjeto(Objeto As NewsletterBE) As NewsletterBE Implements IABMC(Of NewsletterBE).ListarObjeto
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

End Class
