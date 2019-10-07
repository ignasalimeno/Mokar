Imports BE
Imports MPP
Imports System.IO

Public Class FacturaBLL

#Region "Singleton"
    Private Sub New()
    End Sub

    Private Shared Instancia As FacturaBLL
    Public Shared Function ObtenerInstancia() As FacturaBLL
        If Instancia Is Nothing Then
            Instancia = New FacturaBLL
        End If
        Return Instancia
    End Function
#End Region

    'Crear
    Public Sub CrearFactura(Factura As FacturaBE)
        FacturaMPP.ObtenerInstancia.CrearFactura(Factura)
    End Sub

    'Listar Todo
    Public Function ListarFacturas() As List(Of FacturaBE)
        Return FacturaMPP.ObtenerInstancia.ListarFacturas()
    End Function

    'Modificar
    Public Sub ModificarFacturaSeleccionada(ByVal Factura As FacturaBE)
        FacturaMPP.ObtenerInstancia.ModificarFactura(Factura)
    End Sub

    'Obtener por ID
    Public Function ObtenerPorID(ByVal Factura As Integer) As FacturaBE
        Dim FacturaObtenida As FacturaBE
        FacturaObtenida = FacturaMPP.ObtenerInstancia.ObtenerFacturaxID(Factura)
        Return FacturaObtenida
    End Function

    Public Function ObtenerFacturaCompPorID(ByVal Factura As Integer) As FacturaCompletaBE
        Dim FacturaObtenida As FacturaCompletaBE
        FacturaObtenida = FacturaMPP.ObtenerInstancia.ObtenerFacturaCompletaxID(Factura)
        Return FacturaObtenida
    End Function

    'Eliminar
    Public Function EliminarFactura(ByVal id As FacturaBE)
        Return FacturaMPP.ObtenerInstancia.Factura_Eliminar(id)
    End Function

    'Para obtener el último ID de Factura
    Public Function ObtenerIDFactura() As FacturaBE
        Return FacturaMPP.ObtenerInstancia.ObtenerIDFactura()
    End Function

    'Obtener por ID del usuario
    Public Function ObtenerPorIDUser(ByVal ID As Integer) As List(Of FacturaBE)
        Return FacturaMPP.ObtenerInstancia.ObtenerFacturasxIDUser(ID)
    End Function

    'Obtener por ID del usuario Completo
    Public Function ObtenerPorIDUser1(ByVal Factura As FacturaBE) As List(Of FacturaBE)
        Return FacturaMPP.ObtenerInstancia.ObtenerFacturasxIDUser1(Factura)
    End Function


    'Cambiar el estado de la factura
    Public Sub Entregado(Factura As FacturaBE)
        FacturaMPP.ObtenerInstancia.CambiarEstado(Factura)
    End Sub

End Class
