Imports System.Data.SqlClient
Imports BE
Imports DAL


Public Class EstadoTarjetaMPP


#Region "Singleton"
    Private Sub New()
    End Sub

    Private Shared Instancia As EstadoTarjetaMPP
    Public Shared Function ObtenerInstancia() As EstadoTarjetaMPP
        If Instancia Is Nothing Then
            Instancia = New EstadoTarjetaMPP
        End If
        Return Instancia
    End Function
#End Region

    Public Function ListarTarjetas() As List(Of EstadoTarjetaBE)
        Dim ListarEstadoTarjetas As New List(Of EstadoTarjetaBE)
        For Each row As DataRow In Datos.ObtenerInstancia.LeerBD("EstadoTarjetas_Select").Rows
            Dim oEstados As New EstadoTarjetaBE With {.ID = row("ID_EstadoTarjeta"), .ID_Tarjeta = row("ID_Tarjeta"), .Nombre = row("Nombre"), .Numero = row("Numero"),
                .CodSeguridad = row("CodigoSeguridad"), .MesVencimiento = row("MesVencimiento"), .AñoVencimiento = row("AñoVencimiento")}
            ListarEstadoTarjetas.Add(oEstados)
        Next
        Return ListarEstadoTarjetas
    End Function

    Public Function ObtenerEstadoTarjeta(ByVal tarjeta As String) As EstadoTarjetaBE
        'listo todos las tarjetas y selecciono por nro.
        Dim ls As List(Of EstadoTarjetaBE) = ListarTarjetas()
        Dim tarjetaxnumero As EstadoTarjetaBE = ls.Find(Function(x) x.Numero = tarjeta)
        Return tarjetaxnumero
    End Function

    Public Function CrearTarjeta(ByVal tarjeta As EstadoTarjetaBE)
        Return Datos.ObtenerInstancia.EjecutarSP("EstadoTarjetas_Insert", Me.CrearParametros(tarjeta))
        Throw New Exception("Easy Travel informa que ha ocurrido un error")
    End Function

    Private Function CrearParametros(ByVal tarjeta As EstadoTarjetaBE) As List(Of SqlParameter)
        Dim params As New List(Of SqlParameter)
        With Datos.ObtenerInstancia()
            params.Add(.CrearParametro("@ID_Tarjeta", tarjeta.ID_Tarjeta))
            params.Add(.CrearParametro("@Nombre", tarjeta.Nombre))
            params.Add(.CrearParametro("@Numero", tarjeta.Numero))
            params.Add(.CrearParametro("@CodSeguridad", tarjeta.CodSeguridad))
            params.Add(.CrearParametro("@MesVencimiento", tarjeta.MesVencimiento))
            params.Add(.CrearParametro("@AñoVencimiento", tarjeta.AñoVencimiento))
            params.Add(.CrearParametro("@Cancelada", "0"))
            params.Add(.CrearParametro("@Monto", tarjeta.Monto))
        End With
        Return params
        Throw New Exception("Easy Travel informa que ha ocurrido un error")
    End Function

    Public Function ModificarTarjeta(ByVal tarjeta As EstadoTarjetaBE) As Integer
        Dim i As Integer = Datos.ObtenerInstancia.EjecutarSP("EstadoTarjetas_Update", Me.CrearParametros(tarjeta))
        Return i
        Throw New Exception("Easy Travel informa que ha ocurrido un error")
    End Function

    Public Function ObtenerTarjetaxID(ByVal id As Integer) As EstadoTarjetaBE
        Dim oresultado As New EstadoTarjetaBE
        Dim pars(0) As SqlParameter
        pars(0) = Datos.ObtenerInstancia.CrearParametro("@ID_EstadoTarjeta", id)

        Dim dt As DataTable = Datos.ObtenerInstancia.LeerBD_1("EstadoTarjetas_ObtenerxID", pars)
        For Each row As DataRow In dt.Rows
            Dim otarjeta As New EstadoTarjetaBE With {.ID = row("ID_EstadoTarjeta"), .ID_Tarjeta = row("ID_Tarjeta"), .Nombre = row("Nombre"), .Numero = row("Numero"),
                .CodSeguridad = row("CodigoSeguridad"), .MesVencimiento = row("MesVencimiento"), .AñoVencimiento = row("AñoVencimiento"), .Cancelada = row("Cancelada")}

            oresultado = otarjeta
            Exit For
        Next
        Return oresultado
        Return Nothing
    End Function

    Public Function ObtenerTarjetaxNumero(ByVal numero As String) As EstadoTarjetaBE
        Dim oresultado As New EstadoTarjetaBE
        Dim pars(0) As SqlParameter
        pars(0) = Datos.ObtenerInstancia.CrearParametro("@Numero", numero)

        Dim dt As DataTable = Datos.ObtenerInstancia.LeerBD_1("EstadoTarjetas_ObtenerxNumero", pars)
        For Each row As DataRow In dt.Rows
            Dim otarjeta As New EstadoTarjetaBE With {.ID = row("ID_EstadoTarjeta"), .ID_Tarjeta = row("ID_Tarjeta"), .Nombre = row("Nombre"), .Numero = row("Numero"),
                .CodSeguridad = row("CodigoSeguridad"), .MesVencimiento = row("MesVencimiento"), .AñoVencimiento = row("AñoVencimiento"), .Cancelada = row("Cancelada")}

            oresultado = otarjeta
            Exit For
        Next
        Return oresultado
        Return Nothing
    End Function

    Public Function Tarjeta_Eliminar(ByVal id As EstadoTarjetaBE)
        Return Datos.ObtenerInstancia.EjecutarSP("EstadoTarjetas_Delete", Me.CrearParametros1(id))
        Throw New Exception("Easy Travel informa que ha ocurrido un error")
    End Function

    Private Function CrearParametros1(ByVal id As EstadoTarjetaBE) As List(Of SqlParameter)
        Dim params As New List(Of SqlParameter)
        With Datos.ObtenerInstancia()
            params.Add(.CrearParametro("@ID_EstadoTarjeta", id.ID))
        End With
        Return params
        Throw New Exception("Easy Travel informa que ha ocurrido un error")
    End Function


End Class
