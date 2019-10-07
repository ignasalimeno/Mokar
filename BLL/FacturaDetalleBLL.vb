Imports BE
Imports MPP

Public Class FacturaDetalleBLL

#Region "Singleton"
    Private Sub New()
    End Sub

    Private Shared Instancia As FacturaDetalleBLL
    Public Shared Function ObtenerInstancia() As FacturaDetalleBLL
        If Instancia Is Nothing Then
            Instancia = New FacturaDetalleBLL
        End If
        Return Instancia
    End Function
#End Region

    'Crear
    Public Sub CrearFactura(Factura As FacturaDetalleBE)
        FacturaDetalleMPP.ObtenerInstancia.CrearFactura(Factura)
    End Sub

    'Listar Todo
    Public Function ListarFacturas() As List(Of FacturaDetalleBE)
        Return FacturaDetalleMPP.ObtenerInstancia.ListarFacturas()
    End Function
End Class
