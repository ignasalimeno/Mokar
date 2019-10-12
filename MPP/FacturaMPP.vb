Imports BE
Imports DAL
Imports System.Data
Imports System.Data.SqlClient

Public Class FacturaMPP

#Region "Singleton"
    Private Sub New()
    End Sub

    Private Shared Instancia As FacturaMPP
    Public Shared Function ObtenerInstancia() As FacturaMPP
        If Instancia Is Nothing Then
            Instancia = New FacturaMPP
        End If
        Return Instancia
    End Function
#End Region

    Public Function CrearFactura(ByVal factura As FacturaBE)
        Return Datos.ObtenerInstancia.EjecutarSP("Factura_Insert", Me.CrearParametros(factura))
        Throw New Exception("Mokar informa que ha ocurrido un error")
    End Function

    Private Function CrearParametros(ByVal factura As FacturaBE) As List(Of SqlParameter)
        Dim params As New List(Of SqlParameter)
        With Datos.ObtenerInstancia()
            params.Add(.CrearParametro("@ID_Usuario", factura.ID_Usuario))
            params.Add(.CrearParametro("@Nombre", factura.Nombre))
            params.Add(.CrearParametro("@Apellido", factura.Apellido))
            params.Add(.CrearParametro("@Usuario", factura.Usuario))
            params.Add(.CrearParametro("@Descripcion", factura.Descripcion))
            params.Add(.CrearParametro("@Fecha", factura.Fecha))
            params.Add(.CrearParametro("@Total", factura.Total))
            params.Add(.CrearParametro("@Cancelada", factura.Cancelada))
            params.Add(.CrearParametro("@Seguimiento", "En curso"))

        End With
        Return params
        Throw New Exception("Mokar informa que ha ocurrido un error")
    End Function

    Public Function ListarFacturas() As List(Of FacturaBE)
        Dim ListaFacturas As New List(Of FacturaBE)
        For Each row As DataRow In Datos.ObtenerInstancia.LeerBD("Factura_Select").Rows
            Dim oFactura As New FacturaBE With {.ID = row("ID_Factura"), .ID_Usuario = row("ID_Usuario"), .Nombre = row("Nombre"),
                .Apellido = row("Apellido"), .Usuario = row("Usuario"), .Descripcion = row("Descripcion"), .Fecha = row("Fecha"), .Total = row("Total"),
                .Cancelada = row("Cancelada"), .Seguimiento = row("Seguimiento")}
            ListaFacturas.Add(oFactura)
        Next
        Return ListaFacturas

    End Function

    Public Function ModificarFactura(ByVal Factura As FacturaBE) As Integer
        Dim i As Integer = Datos.ObtenerInstancia.EjecutarSP("Factura_Update", Me.CrearParametros(Factura))
        Return i
        Throw New Exception("Mokar informa que ha ocurrido un error")
    End Function

    Public Function ObtenerIDFactura() As FacturaBE
        Dim row As DataRow = Datos.ObtenerInstancia.LeerBD("Factura_ObtenerLastID").Rows(0)
        Dim oFactura As New FacturaBE With {.ID = row("ID_Factura")}
        Return oFactura
    End Function

    Public Function ObtenerFacturaxID(ByVal id As Integer) As FacturaBE
        Dim oFacturaresultado As New FacturaBE
        Dim pars(0) As SqlParameter
        pars(0) = Datos.ObtenerInstancia.CrearParametro("@ID_Factura", id)

        Dim dt As DataTable = Datos.ObtenerInstancia.LeerBD_1("Factura_ObtenerxID", pars)
        For Each row As DataRow In dt.Rows
            Dim oFactura As New FacturaBE With {.ID = row("ID_Factura"), .ID_Usuario = row("ID_Usuario"), .Nombre = row("Nombre"),
                .Apellido = row("Apellido"), .Usuario = row("Usuario"), .Descripcion = row("Descripcion").Fecha = row("Fecha"),
                .Total = row("Total"), .Cancelada = row("Cancelada"), .Seguimiento = row("Seguimiento")}

            oFacturaresultado = oFactura
            Exit For
        Next
        Return oFacturaresultado
        Return Nothing
    End Function


    Public Function Factura_Eliminar(ByVal id As FacturaBE)
        Return Datos.ObtenerInstancia.EjecutarSP("Factura_Delete", Me.CrearParametros1(id))
        Throw New Exception("Mokar informa que ha ocurrido un error")
    End Function

    Private Function CrearParametros1(ByVal id As FacturaBE) As List(Of SqlParameter)
        Dim params As New List(Of SqlParameter)
        With Datos.ObtenerInstancia()
            params.Add(.CrearParametro("@ID_Factura", id.ID))
        End With
        Return params
        Throw New Exception("Mokar informa que ha ocurrido un error")
    End Function

    Public Function ObtenerFacturaCompletaxID(ByVal id As Integer) As FacturaCompletaBE
        Dim FacturaCompleta As New FacturaCompletaBE
        Dim pars(0) As SqlParameter
        pars(0) = Datos.ObtenerInstancia.CrearParametro("@ID_Factura", id)

        Dim dt As DataTable = Datos.ObtenerInstancia.LeerBD_1("FacturaCompleta_ObtenerFCxID", pars)
        For Each row As DataRow In dt.Rows
            Dim Factura As New FacturaCompletaBE With {.ID = row("ID_Factura"), .ID_Usuario = row("ID_Usuario"), .Nombre = row("Nombre"),
                .Apellido = row("Apellido"), .Usuario = row("Usuario"), .Fecha = row("Fecha"), .Total = row("Total"), .Cantidad = row("Cantidad"),
                .Descripcion = row("Descripcion"), .ID_FacturaDetalle = row("ID_FacturaDetalle"), .NombrePais = row("Descr"), .PrecioUnitario = row("Precio"), .Cancelada = row("Cancelada")}

            FacturaCompleta = Factura
            Exit For
        Next
        Return FacturaCompleta
        Return Nothing
    End Function

    Public Function ObtenerFacturasxIDUser(id As Integer) As List(Of FacturaBE)
        Dim ListaFC As New List(Of FacturaBE)
        Dim pars(0) As SqlParameter
        pars(0) = Datos.ObtenerInstancia.CrearParametro("@ID_Cliente", id)

        Dim dt As DataTable = Datos.ObtenerInstancia.LeerBD_1("FacturaCompleta_ObtenerFCxIDUser", pars)
        For Each row As DataRow In dt.Rows
            Dim oFC As New FacturaBE With {.ID = row("ID_Factura"), .ID_Usuario = row("ID_Usuario"), .Nombre = row("Nombre"),
                .Apellido = row("Apellido"), .Usuario = row("Usuario"), .Fecha = row("Fecha"), .Total = row("Total"),
                .Cancelada = row("Cancelada")}
            ListaFC.Add(oFC)
        Next
        Return ListaFC
    End Function

    Public Function ObtenerFacturasxIDUser1(Factura As FacturaBE) As List(Of FacturaBE)
        Dim ListaFC As New List(Of FacturaBE)
        Dim pars(0) As SqlParameter
        pars(0) = Datos.ObtenerInstancia.CrearParametro("@ID_Cliente", Factura.ID_Usuario)

        Dim dt As DataTable = Datos.ObtenerInstancia.LeerBD_1("FacturaCompleta_ObtenerFCxIDUser1", pars)
        For Each row As DataRow In dt.Rows
            Dim oFC As New FacturaBE With {.ID = row("ID_Factura"), .ID_Usuario = row("ID_Usuario"), .Nombre = row("Nombre"),
                .Apellido = row("Apellido"), .Usuario = row("Usuario"), .Fecha = row("Fecha"), .Total = row("Total"),
                .Cancelada = row("Cancelada"), .Descripcion = row("Descripcion"), .Seguimiento = row("Seguimiento")}
            ListaFC.Add(oFC)
        Next
        Return ListaFC
    End Function

    Public Function CambiarEstado(ByVal Factura As FacturaBE) As Integer
        Dim i As Integer = Datos.ObtenerInstancia.EjecutarSP("Factura_CambiarEstado", Me.CrearParametros4(Factura))
        Return i
        Throw New Exception("Mokar informa que ha ocurrido un error")
    End Function

    Private Function CrearParametros4(ByVal factura As FacturaBE) As List(Of SqlParameter)
        Dim params As New List(Of SqlParameter)
        With Datos.ObtenerInstancia()
            params.Add(.CrearParametro("@ID_Factura", factura.ID))

        End With
        Return params
        Throw New Exception("Mokar informa que ha ocurrido un error")
    End Function

    Public Function ListarPedidosActivos(objeto As UsuarioBE) As IEnumerable(Of PedidosActivosBE)
        Dim oDatos As New DAL.Datos
        Dim DS As New DataSet
        Dim list As New List(Of BE.PedidosActivosBE)
        Dim dt As New DataTable
        Dim newObj As BE.PedidosActivosBE

        Dim hdatos As New Hashtable
        hdatos.Add("@idUsuario", objeto.idUsuario)

        DS = oDatos.Leer("Pedidos_Seguimiento", hdatos)

        If DS.Tables(0).Rows.Count > 0 Then

            For Each Item As DataRow In DS.Tables(0).Rows
                newObj = New BE.PedidosActivosBE
                newObj.idServicio = Item("idServicio")
                newObj.nombre = Item("nombre")
                newObj.cantUsuarios = Item("Cantidad")
                newObj.fechaAlta = Item("Fecha")
                newObj.diasRestantes = Item("CantDias")

                list.Add(newObj)
            Next

            Return list

        Else
            Return Nothing
        End If
    End Function
End Class
