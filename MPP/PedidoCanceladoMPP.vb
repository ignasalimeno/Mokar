Imports BE
Imports DAL
Imports System.Data
Imports System.Data.SqlClient

Public Class PedidoCanceladoMPP

#Region "Singleton"
    Private Sub New()
    End Sub

    Private Shared Instancia As PedidoCanceladoMPP
    Public Shared Function ObtenerInstancia() As PedidoCanceladoMPP
        If Instancia Is Nothing Then
            Instancia = New PedidoCanceladoMPP
        End If
        Return Instancia
    End Function

#End Region


    Public Function Crear(ByVal Elemento As PedidoCanceladoBE)
        Return Datos.ObtenerInstancia.EjecutarSP("PedidoCancel_Insert", Me.CrearParametros(Elemento))
        Throw New Exception("Easy Travel informa que ha ocurrido un error")
    End Function

    Private Function CrearParametros(ByVal Elemento As PedidoCanceladoBE) As List(Of SqlParameter)
        Dim params As New List(Of SqlParameter)
        With Datos.ObtenerInstancia()
            params.Add(.CrearParametro("@Fecha", Elemento.Fecha))
            params.Add(.CrearParametro("@ID_Factura", Elemento.ID_Factura))
            params.Add(.CrearParametro("@Motivo", Elemento.Motivo))
            params.Add(.CrearParametro("@Usuario", Elemento.Usuario))

        End With
        Return params
        Throw New Exception("Easy Travel informa que ha ocurrido un error")
    End Function

    Public Function Eliminar(ByVal id As PedidoCanceladoBE)
        Return Datos.ObtenerInstancia.EjecutarSP("PedidoCancel_Delete", Me.CrearParametros1(id))
        Throw New Exception("Easy Travel informa que ha ocurrido un error")
    End Function

    Private Function CrearParametros1(ByVal id As PedidoCanceladoBE) As List(Of SqlParameter)
        Dim params As New List(Of SqlParameter)
        With Datos.ObtenerInstancia()
            params.Add(.CrearParametro("@ID", id.ID_Factura))
        End With
        Return params
        Throw New Exception("Easy Travel informa que ha ocurrido un error")
    End Function

    Public Function Listar() As List(Of PedidoCanceladoBE)
        Dim Lista As New List(Of PedidoCanceladoBE)
        For Each row As DataRow In Datos.ObtenerInstancia.LeerBD("PedidoCancel_Select").Rows
            Dim oPedido As New PedidoCanceladoBE With {.ID = row("ID"), .ID_Factura = row("ID_Factura"), .Motivo = row("Motivo"),
                .Usuario = row("Usuario"), .Fecha = row("Fecha")}
            Lista.Add(oPedido)
        Next
        Return Lista

    End Function

End Class
