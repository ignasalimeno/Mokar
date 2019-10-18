Imports BE
Imports MPP


Public Class ServiciosBLL
    Implements IABMC(Of ServiciosBE)

    Private Shared Instancia As ServiciosBLL
    Public Shared Function ObtenerInstancia() As ServiciosBLL
        If Instancia Is Nothing Then
            Instancia = New ServiciosBLL
        End If
        Return Instancia
    End Function

    Public Function Alta(Objeto As ServiciosBE) As Boolean Implements IABMC(Of ServiciosBE).Alta
        Try
            Return ServiciosMPP.ObtenerInstancia.Alta(Objeto)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Baja(Objeto As ServiciosBE) As Boolean Implements IABMC(Of ServiciosBE).Baja
        Try
            Return ServiciosMPP.ObtenerInstancia.Baja(Objeto)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Modificacion(Objeto As ServiciosBE) As Boolean Implements IABMC(Of ServiciosBE).Modificacion
        Try
            Return ServiciosMPP.ObtenerInstancia.Modificacion(Objeto)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function ListarObjetos() As IEnumerable(Of ServiciosBE) Implements IABMC(Of ServiciosBE).ListarObjetos
        Try
            Return ServiciosMPP.ObtenerInstancia.ListarObjetos()
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function ListarObjeto(Objeto As ServiciosBE) As ServiciosBE Implements IABMC(Of ServiciosBE).ListarObjeto
        Try
            Return ServiciosMPP.ObtenerInstancia.ListarObjeto(Objeto)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function ListarObjetos(Objeto As ServiciosBE) As IEnumerable(Of ServiciosBE)
        Try
            Return ServiciosMPP.ObtenerInstancia.ListarObjetos(Objeto)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function ListarComentarios(objeto As ServiciosBE) As IEnumerable(Of ServiciosComentariosBE)
        Try
            Dim lista As IEnumerable(Of ServiciosComentariosBE) = ServiciosMPP.ObtenerInstancia.ListarComentarios(objeto)

            If GestorSesion.ObtenerSesionActual.UsuarioActivo IsNot Nothing Then

                For Each a As ServiciosComentariosBE In lista
                    If (a.tieneRespuesta Or GestorSesion.ObtenerSesionActual.UsuarioActivo.tipoUsuario = 2) Then
                        a.permiteRespuestas = False
                    Else
                        a.permiteRespuestas = True
                    End If
                Next
            End If

            Return lista
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function AgregarComentario(Comentario As ServiciosComentariosBE) As Boolean
        Try
            Return ServiciosMPP.ObtenerInstancia.AgregarComentario(Comentario)

            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function AgregarRespuesta(Comentario As ServiciosComentariosBE) As Boolean
        Try
            Return ServiciosMPP.ObtenerInstancia.AgregarRespuesta(Comentario)

            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function AgregarVoto(idServicio As Integer, voto As Integer) As Boolean
        Try
            Return ServiciosMPP.ObtenerInstancia.AgregarVoto(idServicio, voto)
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function ListarObjetosAvanzada(nombre As String, descripcion As String, precio As String, accesoPlataforma As String, materialEstudio As String, reportes As String, capacitaciones As String) As IEnumerable(Of ServiciosBE)
        Try
            Return ServiciosMPP.ObtenerInstancia.ListarObjetosAvanzada(nombre, descripcion, precio, accesoPlataforma, materialEstudio, reportes, capacitaciones)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function ListarObjetosSimple(campo As String) As IEnumerable(Of ServiciosBE)
        Try
            Return ServiciosMPP.ObtenerInstancia.ListarObjetosSimple(campo)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

End Class
