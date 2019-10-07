Imports BE
Imports MPP

Public Class EstadosTarjetasBLL

#Region "Singleton"
    Private Sub New()
    End Sub

    Private Shared Instancia As EstadosTarjetasBLL
    Public Shared Function ObtenerInstancia() As EstadosTarjetasBLL
        If Instancia Is Nothing Then
            Instancia = New EstadosTarjetasBLL
        End If
        Return Instancia
    End Function
#End Region

    'Listar Todas
    Public Function ListarTarjetas() As List(Of EstadoTarjetaBE)
        Return EstadoTarjetaMPP.ObtenerInstancia.ListarTarjetas()
    End Function

    Public Function VerificarExisteTarjeta(tarjeta As String) As Boolean
        Return IIf(EstadoTarjetaMPP.ObtenerInstancia.ObtenerEstadoTarjeta(tarjeta) IsNot Nothing, True, False)
    End Function

    'Crear
    Public Sub CrearTarjeta(tarjeta As EstadoTarjetaBE)
        EstadoTarjetaMPP.ObtenerInstancia.CrearTarjeta(tarjeta)
    End Sub

    'Modificar
    Public Sub ModificarTarjetaSeleccionada(ByVal Tarjeta As EstadoTarjetaBE)
        EstadoTarjetaMPP.ObtenerInstancia.ModificarTarjeta(Tarjeta)
    End Sub

    'Obtener por ID
    Public Function ObtenerPorID(ByVal Tarjeta As Integer) As EstadoTarjetaBE
        Dim TarjetaObtenida As EstadoTarjetaBE
        TarjetaObtenida = EstadoTarjetaMPP.ObtenerInstancia.ObtenerTarjetaxID(Tarjeta)
        Return TarjetaObtenida
    End Function

    'Obtener por Nombre
    Public Function ObtenerPorNumero(ByVal Tarjeta As String) As EstadoTarjetaBE
        Dim TarjetaObtenida As EstadoTarjetaBE
        TarjetaObtenida = EstadoTarjetaMPP.ObtenerInstancia.ObtenerTarjetaxNumero(Tarjeta)
        Return TarjetaObtenida
    End Function

    'Eliminar
    Public Function EliminarTarjeta(ByVal id As EstadoTarjetaBE)
        Return EstadoTarjetaMPP.ObtenerInstancia.Tarjeta_Eliminar(id)
    End Function

End Class
