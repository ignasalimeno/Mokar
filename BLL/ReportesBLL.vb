Imports BE
Imports MPP

Public Class ReportesBLL

#Region "Singleton"
    Private Sub New()
    End Sub

    Private Shared Instancia As ReportesBLL
    Public Shared Function ObtenerInstancia() As ReportesBLL
        If Instancia Is Nothing Then
            Instancia = New ReportesBLL
        End If
        Return Instancia
    End Function

#End Region

    Function ObtenerReporteEncuestas() As IEnumerable(Of ReporteEncuestaBE)
        Try
            Return ReportesMPP.ObtenerInstancia.ObtenerReporteEncuestas()
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Function ObtenerReporteFichaOpinion() As IEnumerable(Of ReporteEncuestaBE)
        Try
            Return ReportesMPP.ObtenerInstancia.ObtenerReporteFichaOpinion()
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Function ListarCantPreguntas() As Integer
        Try
            Return ReportesMPP.ObtenerInstancia.ListarCantPreguntas
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Function ListarCantRespuestas() As Integer
        Try
            Return ReportesMPP.ObtenerInstancia.ListarCantRespuestas
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Function ListarTiempoPromedio() As Integer
        Try
            Return ReportesMPP.ObtenerInstancia.ListarTiempoPromedio
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Function ObtenerReporteServicios(idServicio As Integer) As IEnumerable(Of ReporteServiciosBE)
        Try
            Return ReportesMPP.ObtenerInstancia.ObtenerReporteServicios(idServicio)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Function ObtenerReporteServicios() As IEnumerable(Of ReporteServiciosBE)
        Try
            Return ReportesMPP.ObtenerInstancia.ObtenerReporteServicios()
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
