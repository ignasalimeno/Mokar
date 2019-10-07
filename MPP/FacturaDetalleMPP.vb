Imports BE
Imports DAL
Imports System.Data
Imports System.Data.SqlClient

Public Class FacturaDetalleMPP

#Region "Singleton"
    Private Sub New()
    End Sub

    Private Shared Instancia As FacturaDetalleMPP
    Public Shared Function ObtenerInstancia() As FacturaDetalleMPP
        If Instancia Is Nothing Then
            Instancia = New FacturaDetalleMPP
        End If
        Return Instancia
    End Function
#End Region

    Public Function CrearFactura(ByVal Factura As FacturaDetalleBE)
        Return Datos.ObtenerInstancia.EjecutarSP("FacturaDetalle_Insert", CrearParametros(Factura))
        Throw New Exception("Easy Travel informa que ha ocurrido un error")
    End Function

    Private Function CrearParametros(ByVal Factura As FacturaDetalleBE) As List(Of SqlParameter)
        Dim params As New List(Of SqlParameter)
        With Datos.ObtenerInstancia()
            'params.Add(.CrearParametro("@ID_Factura", Factura.ID_Factura))
            params.Add(.CrearParametro("@idServicio", Factura.ID_Oferta))
            params.Add(.CrearParametro("@Cantidad", Factura.Cantidad))
            params.Add(.CrearParametro("@Precio", Factura.PrecioUnitario))

        End With
        Return params
        Throw New Exception("Easy Travel informa que ha ocurrido un error")
    End Function



    Public Function ListarFacturas() As List(Of FacturaDetalleBE)
        Dim ListaFacturas As New List(Of FacturaDetalleBE)
        For Each row As DataRow In Datos.ObtenerInstancia.LeerBD("FacturaDetalle_Select").Rows
            Dim oFactura As New FacturaDetalleBE With {.ID = row("ID_FacturaDetalle"), .ID_Factura = row("ID_Factura"), .ID_Oferta = row("idServicio"),
                .Cantidad = row("Cantidad"), .PrecioUnitario = row("Precio")}
            ListaFacturas.Add(oFactura)
        Next
        Return ListaFacturas

    End Function
End Class
