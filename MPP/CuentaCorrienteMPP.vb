Imports BE
Imports DAL
Imports System.Data.SqlClient

Public Class CuentaCorrienteMPP

#Region "Singleton"
    Private Sub New()
    End Sub

    Private Shared Instancia As CuentaCorrienteMPP
    Public Shared Function ObtenerInstancia() As CuentaCorrienteMPP
        If Instancia Is Nothing Then
            Instancia = New CuentaCorrienteMPP
        End If
        Return Instancia
    End Function
#End Region

    Public Function CrearCC(ByVal cuenta As CuentaCorrienteBE)
        Return Datos.ObtenerInstancia.EjecutarSP("CuentaCorriente_Insert", Me.CrearParametros(cuenta))
        Throw New Exception("Easy Travel informa que ha ocurrido un error")
    End Function

    Private Function CrearParametros(ByVal cuenta As CuentaCorrienteBE) As List(Of SqlParameter)
        Dim params As New List(Of SqlParameter)
        With Datos.ObtenerInstancia()
            params.Add(.CrearParametro("@ID_Cliente", cuenta.ID_Cliente))
            'params.Add(.CrearParametro("@ID_Factura", cuenta.ID_Factura))
            params.Add(.CrearParametro("@ID_NotaCredito", cuenta.ID_NotaCredito))
            params.Add(.CrearParametro("@Motivo", cuenta.Motivo))
            params.Add(.CrearParametro("@Debito", cuenta.Debito))
            params.Add(.CrearParametro("@Credito", cuenta.Credito))
            params.Add(.CrearParametro("@Fecha", cuenta.Fecha))
            'params.Add(.CrearParametro("@Saldo", "0"))
        End With
        Return params
        Throw New Exception("Easy Travel informa que ha ocurrido un error")
    End Function

    Public Function CrearCCxNC(ByVal cuenta As CuentaCorrienteBE)
        Return Datos.ObtenerInstancia.EjecutarSP("CuentaCorriente_InsertxNC", Me.CrearParametros2(cuenta))
        Throw New Exception("Easy Travel informa que ha ocurrido un error")
    End Function

    Private Function CrearParametros2(ByVal cuenta As CuentaCorrienteBE) As List(Of SqlParameter)
        Dim params As New List(Of SqlParameter)
        With Datos.ObtenerInstancia()
            params.Add(.CrearParametro("@ID_Cliente", cuenta.ID_Cliente))
            params.Add(.CrearParametro("@ID_Factura", cuenta.ID_Factura))
            params.Add(.CrearParametro("@ID_NotaCredito", cuenta.ID_NotaCredito))
            params.Add(.CrearParametro("@Motivo", cuenta.Motivo))
            params.Add(.CrearParametro("@Debito", cuenta.Debito))
            params.Add(.CrearParametro("@Credito", cuenta.Credito))
            params.Add(.CrearParametro("@Fecha", cuenta.Fecha))
            'params.Add(.CrearParametro("@Saldo", cuenta.Saldo))
        End With
        Return params
        Throw New Exception("Easy Travel informa que ha ocurrido un error")
    End Function


    Public Function ListarCC() As List(Of CuentaCorrienteBE)
        Dim Listacuentas As New List(Of CuentaCorrienteBE)
        For Each row As DataRow In Datos.ObtenerInstancia.LeerBD("CuentaCorriente_Select").Rows
            Dim ocuenta As New CuentaCorrienteBE With {.ID = row("ID_CuentaCorriente"), .ID_Cliente = row("ID_Cliente"), .ID_Factura = row("ID_Factura"),
                .ID_NotaCredito = row("ID_NotaCredito"), .Motivo = row("Motivo"), .Debito = row("Debito"), .Credito = row("Credito"), .Fecha = row("Fecha")}
            Listacuentas.Add(ocuenta)
        Next
        Return Listacuentas

    End Function

    Public Function ModificarCC(ByVal cuenta As CuentaCorrienteBE) As Integer
        Dim i As Integer = Datos.ObtenerInstancia.EjecutarSP("CuentaCorriente_Update", Me.CrearParametros(cuenta))
        Return i
        Throw New Exception("Easy Travel informa que ha ocurrido un error")
    End Function


    Public Function ObtenerCCxID(ByVal id As Integer) As CuentaCorrienteBE
        Dim oCCresultado As New CuentaCorrienteBE
        Dim pars(0) As SqlParameter
        pars(0) = Datos.ObtenerInstancia.CrearParametro("@ID_Factura", id)

        Dim dt As DataTable = Datos.ObtenerInstancia.LeerBD_1("Factura_ObtenerxID", pars)
        For Each row As DataRow In dt.Rows
            Dim oCC As New CuentaCorrienteBE With {.ID = row("ID_CuentaCorriente"), .ID_Cliente = row("ID_Cliente"), .ID_Factura = row("ID_Factura"),
                .ID_NotaCredito = row("ID_NotaCredito"), .Motivo = row("Motivo"), .Debito = row("Debito"), .Credito = row("Credito"), .Fecha = row("Fecha")}

            oCCresultado = oCC
            Exit For
        Next
        Return oCCresultado
        Return Nothing
    End Function

    Public Function CC_Eliminar(ByVal id As CuentaCorrienteBE)
        Return Datos.ObtenerInstancia.EjecutarSP("CuentaCorriente_Delete", Me.CrearParametros1(id))
        Throw New Exception("Easy Travel informa que ha ocurrido un error")
    End Function

    Private Function CrearParametros1(ByVal id As CuentaCorrienteBE) As List(Of SqlParameter)
        Dim params As New List(Of SqlParameter)
        With Datos.ObtenerInstancia()
            params.Add(.CrearParametro("@ID_CuentaCorriente", id.ID))
        End With
        Return params
        Throw New Exception("Easy Travel informa que ha ocurrido un error")
    End Function

    Public Function ObtenerCCxIDUser(id As Integer) As List(Of CuentaCorrienteBE)
        Dim ListaCC As New List(Of CuentaCorrienteBE)
        Dim pars(0) As SqlParameter
        pars(0) = Datos.ObtenerInstancia.CrearParametro("@ID_Cliente", id)

        Dim dt As DataTable = Datos.ObtenerInstancia.LeerBD_1("CuentaCorriente_ObtenerCCxIDUser", pars)
        For Each row As DataRow In dt.Rows
            Dim oCC As New CuentaCorrienteBE With {.ID = row("ID_CuentaCorriente"), .ID_Cliente = row("ID_Cliente"), .ID_Factura = row("ID_Factura"),
                .ID_NotaCredito = row("ID_NotaCredito"), .Motivo = row("Motivo"), .Debito = row("Debito"), .Credito = row("Credito"), .Fecha = row("Fecha")}
            ListaCC.Add(oCC)
        Next
        Return ListaCC
    End Function

    Public Function ObtenerCCxIDUser1(id As Integer) As List(Of CuentaCorrienteBE)
        Dim ListaCC As New List(Of CuentaCorrienteBE)
        Dim pars(0) As SqlParameter
        pars(0) = Datos.ObtenerInstancia.CrearParametro("@ID_Cliente", id)

        Dim dt As DataTable = Datos.ObtenerInstancia.LeerBD_1("CuentaCorriente_ObtenerCCxIDUser1", pars)
        For Each row As DataRow In dt.Rows
            Dim oCC As New CuentaCorrienteBE With {.ID = row("ID_CuentaCorriente"), .ID_Cliente = row("ID_Cliente"), .ID_Factura = row("ID_Factura"),
                .ID_NotaCredito = row("ID_NotaCredito"), .Motivo = row("Motivo"), .Debito = row("Debito"), .Credito = row("Credito"), .Fecha = row("Fecha")}
            ListaCC.Add(oCC)
        Next
        Return ListaCC
    End Function

    Public Function ActualizarSaldo(ByVal Saldo As CuentaCorrienteBE)
        Return Datos.ObtenerInstancia.EjecutarSP("CuentaCorriente_InsertNewSaldo", Me.CrearParametros3(Saldo))
        Throw New Exception("Easy Travel informa que ha ocurrido un error")
    End Function

    Private Function CrearParametros3(ByVal Saldo As CuentaCorrienteBE) As List(Of SqlParameter)
        Dim params As New List(Of SqlParameter)
        With Datos.ObtenerInstancia()
            params.Add(.CrearParametro("@ID", Saldo.ID))
            params.Add(.CrearParametro("@Saldo", Saldo.Credito))
        End With
        Return params
        Throw New Exception("Easy Travel informa que ha ocurrido un error")
    End Function


End Class
