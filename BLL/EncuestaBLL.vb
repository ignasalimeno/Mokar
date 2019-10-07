Imports BE
Imports MPP

Public Class EncuestaBLL

#Region "Singleton"
    Private Sub New()
    End Sub

    Private Shared Instancia As EncuestaBLL
    Public Shared Function ObtenerInstancia() As EncuestaBLL
        If Instancia Is Nothing Then
            Instancia = New EncuestaBLL
        End If
        Return Instancia
    End Function
#End Region

    Public Function ListarTodas() As IEnumerable(Of EncuestaBE)
        Try
            Return EncuestaMPP.ObtenerInstancia.ListarTodas()
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Function Crear(objeto As EncuestaBE) As Integer
        Try
            Return EncuestaMPP.ObtenerInstancia.Crear(objeto)
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function Eliminar(objeto As EncuestaBE) As Boolean
        Try
            Return EncuestaMPP.ObtenerInstancia.Eliminar(objeto)
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function Cargar(objeto As EncuestaBE) As EncuestaBE
        Try
            Return EncuestaMPP.ObtenerInstancia.Cargar(objeto)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Function Editar(objeto As EncuestaBE) As Boolean
        Try
            Return EncuestaMPP.ObtenerInstancia.Editar(objeto)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Function Votar(respuesta As Integer) As Boolean
        Try
            Return EncuestaMPP.ObtenerInstancia.Votar(respuesta)
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function CargarRespuestas(objeto As EncuestaPreguntaBE) As IEnumerable(Of EncuestaRespuestasBE)
        Try
            Return EncuestaMPP.ObtenerInstancia.ListarRespuestasEncuesta(objeto.idPregunta)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Function AltaPregunta(idEncuesta As Integer, objeto As EncuestaPreguntaBE) As Boolean
        Try
            Return EncuestaMPP.ObtenerInstancia.AltaPregunta(idEncuesta, objeto)
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function EliminarPregunta(idEncuesta As Integer, objeto As EncuestaPreguntaBE) As Boolean
        Try
            Return EncuestaMPP.ObtenerInstancia.EliminarPregunta(idEncuesta, objeto)
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function ModificarPregunta(idEncuesta As Integer, objeto As EncuestaPreguntaBE) As Boolean
        Try
            Return EncuestaMPP.ObtenerInstancia.ModificarPregunta(idEncuesta, objeto)
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function AltaRta(idPregunta As Integer, objeto As EncuestaRespuestasBE) As Boolean
        Try
            Return EncuestaMPP.ObtenerInstancia.AltaRta(idPregunta, objeto)
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function EliminarRta(idPregunta As Integer, objeto As EncuestaRespuestasBE) As Boolean
        Try
            Return EncuestaMPP.ObtenerInstancia.EliminarRta(idPregunta, objeto)
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function ModificarRta(idPregunta As Integer, objeto As EncuestaRespuestasBE) As Boolean
        Try
            Return EncuestaMPP.ObtenerInstancia.ModificarRta(idPregunta, objeto)
        Catch ex As Exception
            Return False
        End Try
    End Function


End Class
