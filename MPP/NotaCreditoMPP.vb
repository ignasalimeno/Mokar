Imports BE
Imports DAL
Imports System.Data
Imports System.Data.SqlClient

Public Class NotaCreditoMPP

#Region "Singleton"
    Private Sub New()
    End Sub
    Private Shared Instancia As NotaCreditoMPP
    Public Shared Function ObtenerInstancia() As NotaCreditoMPP
        If Instancia Is Nothing Then
            Instancia = New NotaCreditoMPP
        End If
        Return Instancia
    End Function
#End Region

    Public Function CrearNotaCredito(ByVal NC As NotaCreditoBE)
        Try
            Return Datos.ObtenerInstancia.EjecutarSP("NotaCredito_Insert", Me.CrearParametros(NC))

        Catch ex As Exception
            Throw New Exception("Easy Travel informa que ha ocurrido un error")

        End Try
    End Function

    Private Function CrearParametros(ByVal NC As NotaCreditoBE) As List(Of SqlParameter)
        Try
            Dim params As New List(Of SqlParameter)
            With Datos.ObtenerInstancia()
                params.Add(.CrearParametro("@ID_Cliente", NC.ID_Cliente))
                params.Add(.CrearParametro("@Fecha", NC.Fecha))
                params.Add(.CrearParametro("@Saldo", NC.Saldo))
                params.Add(.CrearParametro("@Motivo", NC.Motivo))
                params.Add(.CrearParametro("@Estado", NC.Estado))

            End With
            Return params
        Catch ex As Exception
            Throw New Exception("Easy Travel informa que ha ocurrido un error")

        End Try

    End Function

    Public Function ListarNotasCredito() As List(Of NotaCreditoBE)
        Try
            Dim ListaNotasCredito As New List(Of NotaCreditoBE)
            For Each row As DataRow In Datos.ObtenerInstancia.LeerBD("NotaCredito_Select").Rows
                Dim oNota As New NotaCreditoBE With {.ID = row("ID_NotaCredito"), .ID_Cliente = row("ID_Cliente"), .Fecha = row("Fecha"),
                    .Saldo = row("Saldo"), .Motivo = row("Motivo"), .Estado = row("Estado")}
                ListaNotasCredito.Add(oNota)
            Next
            Return ListaNotasCredito
        Catch ex As Exception
            Throw New Exception
        End Try

    End Function

    Public Function ModificarNC(ByVal NC As NotaCreditoBE) As Integer
        Try
            Dim i As Integer = Datos.ObtenerInstancia.EjecutarSP("NotaCredito_Update", Me.CrearParametros(NC))
            Return i
        Catch ex As Exception
            Throw New Exception("Mokar informa que hubo un error")

        End Try

    End Function

    Public Function ObtenerNCxID(ByVal id As Integer) As NotaCreditoBE
        Try
            Dim oNCresultado As New NotaCreditoBE
            Dim pars(0) As SqlParameter
            pars(0) = Datos.ObtenerInstancia.CrearParametro("@ID_NotaCredito", id)

            Dim dt As DataTable = Datos.ObtenerInstancia.LeerBD_1("NotaCredito_ObtenerNCxID", pars)
            For Each row As DataRow In dt.Rows
                Dim oNC As New NotaCreditoBE With {.ID = row("ID_NotaCredito"), .ID_Cliente = row("ID_Cliente"), .Fecha = row("Fecha"),
                    .Saldo = row("Saldo"), .Motivo = row("Motivo"), .Estado = row("Estado")}

                oNCresultado = oNC
                Exit For
            Next
            Return oNCresultado

        Catch ex As Exception
            Throw New Exception
        End Try

    End Function

    Public Function ObtenerNCxIDUser(id As Integer) As List(Of NotaCreditoBE)
        Try
            Dim ListaNC As New List(Of NotaCreditoBE)
            Dim pars(0) As SqlParameter
            pars(0) = Datos.ObtenerInstancia.CrearParametro("@ID_Cliente", id)

            Dim dt As DataTable = Datos.ObtenerInstancia.LeerBD_1("NotaCredito_ObtenerNCxIDUser", pars)
            For Each row As DataRow In dt.Rows
                Dim oNC As New NotaCreditoBE With {.ID = row("ID_NotaCredito"), .ID_Cliente = row("ID_Cliente"), .Fecha = row("Fecha"),
                    .Saldo = row("Saldo"), .Motivo = row("Motivo")}
                ListaNC.Add(oNC)
            Next
            Return ListaNC
        Catch ex As Exception
            Throw New Exception
        End Try

    End Function

    Public Function EliminarNC(ByVal id As NotaCreditoBE)
        Try
            Return Datos.ObtenerInstancia.EjecutarSP("NotaCredito_Delete", Me.CrearParametros1(id))
        Catch ex As Exception
            Throw New Exception("Mokar informa que ha ocurrido un error")

        End Try
    End Function

    Private Function CrearParametros1(ByVal id As NotaCreditoBE) As List(Of SqlParameter)
        Try
            Dim params As New List(Of SqlParameter)
            With Datos.ObtenerInstancia()
                params.Add(.CrearParametro("@ID_NotaCredito", id.ID))
            End With
            Return params
        Catch ex As Exception
            Throw New Exception("Mokar informa que ha ocurrido un error")

        End Try

    End Function

    Public Function ObtenerIDNC() As NotaCreditoBE
        Try
            Dim row As DataRow = Datos.ObtenerInstancia.LeerBD("NotaCredito_ObtenerLastID").Rows(0)
            Dim oNC As New NotaCreditoBE With {.ID = row("ID_NotaCredito")}
            Return oNC

        Catch ex As Exception
            Throw New Exception
        End Try

    End Function

    Public Function ObtenerNCCompletaxID(ByVal id As Integer) As NotaCreditoCompletaBE
        Try
            Dim NCCompleta As New NotaCreditoCompletaBE
            Dim pars(0) As SqlParameter
            pars(0) = Datos.ObtenerInstancia.CrearParametro("@ID_NotaCredito", id)

            Dim dt As DataTable = Datos.ObtenerInstancia.LeerBD_1("NotaCredito_CompletaObtenerxID", pars)
            For Each row As DataRow In dt.Rows
                Dim NC As New NotaCreditoCompletaBE With {.ID = row("ID_NotaCredito"), .ID_Factura = row("ID_Factura"), .ID_Usuario = row("ID_Usuario"), .Nombre = row("Nombre"),
                    .Apellido = row("Apellido"), .Usuario = row("Usuario"), .Fecha = row("Fecha"), .Total = row("Total"), .Cantidad = row("Cantidad"),
                    .Descripcion = row("Descripcion"), .ID_FacturaDetalle = row("ID_FacturaDetalle"), .NombrePais = row("Descr"), .PrecioUnitario = row("Precio")}

                NCCompleta = NC
                Exit For
            Next
            Return NCCompleta
        Catch ex As Exception
            Throw New Exception
        End Try
    End Function


End Class
