Imports BE
Imports DAL

Public Class ReportesMPP

#Region "Singleton"
    Private Sub New()
    End Sub

    Private Shared Instancia As ReportesMPP
    Public Shared Function ObtenerInstancia() As ReportesMPP
        If Instancia Is Nothing Then
            Instancia = New ReportesMPP
        End If
        Return Instancia
    End Function

#End Region

    Public Function ObtenerReporteEncuestas() As IEnumerable(Of ReporteEncuestaBE)
        Dim oDatos As New DAL.Datos
        Dim DS As New DataSet
        Dim list As New List(Of BE.ReporteEncuestaBE)
        Dim dt As New DataTable
        Dim newObj As BE.ReporteEncuestaBE

        Dim hdatos As New Hashtable

        DS = oDatos.Leer("n_Reporte_Encuestas", hdatos)

        If DS.Tables(0).Rows.Count > 0 Then

            For Each Item As DataRow In DS.Tables(0).Rows
                newObj = New BE.ReporteEncuestaBE
                newObj.idEncuesta = Item("idEncuesta")
                newObj.CantRespuestas = Item("CantRespuestas")
                list.Add(newObj)
            Next

            Return list

        Else
            Return Nothing
        End If
    End Function

    Public Function ObtenerReporteFichaOpinion() As IEnumerable(Of ReporteEncuestaBE)
        Dim oDatos As New DAL.Datos
        Dim DS As New DataSet
        Dim list As New List(Of BE.ReporteEncuestaBE)
        Dim dt As New DataTable
        Dim newObj As BE.ReporteEncuestaBE

        Dim hdatos As New Hashtable

        DS = oDatos.Leer("n_Reporte_FichaOpinion", hdatos)

        If DS.Tables(0).Rows.Count > 0 Then

            For Each Item As DataRow In DS.Tables(0).Rows
                newObj = New BE.ReporteEncuestaBE
                newObj.idEncuesta = Item("idEncuesta")
                newObj.CantRespuestas = Item("CantRespuestas")
                list.Add(newObj)
            Next

            Return list

        Else
            Return Nothing
        End If
    End Function

    Function ListarCantPreguntas() As Integer
        Try
            Dim DS As New DataSet
            Dim hdatos As New Hashtable
            hdatos.Add("@tipoConsulta", 2)

            DS = Datos.ObtenerInstancia.Leer("n_Reporte_Respuestas", hdatos)

            If DS.Tables(0).Rows.Count > 0 Then

                Return DS.Tables(0).Rows(0).Item(0)
            Else
                Return 0
            End If

        Catch ex As Exception
            Return 0
        End Try
    End Function

    Function ListarCantRespuestas() As Integer
        Try
            Dim DS As New DataSet
            Dim hdatos As New Hashtable
            hdatos.Add("@tipoConsulta", 3)

            DS = Datos.ObtenerInstancia.Leer("n_Reporte_Respuestas", hdatos)

            If DS.Tables(0).Rows.Count > 0 Then

                Return DS.Tables(0).Rows(0).Item(0)
            Else
                Return 0
            End If

        Catch ex As Exception
            Return 0
        End Try
    End Function

    Function ListarTiempoPromedio() As Integer
        Try
            Dim DS As New DataSet
            Dim hdatos As New Hashtable
            hdatos.Add("@tipoConsulta", 1)

            DS = Datos.ObtenerInstancia.Leer("n_Reporte_Respuestas", hdatos)

            If DS.Tables(0).Rows.Count > 0 Then

                Return DS.Tables(0).Rows(0).Item(0)
            Else
                Return 0
            End If

        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function ObtenerReporteServicios(idServicio As Integer, fechaDesde As Date, fechaHasta As Date) As IEnumerable(Of ReporteServiciosBE)
        Dim oDatos As New DAL.Datos
        Dim DS As New DataSet
        Dim list As New List(Of BE.ReporteServiciosBE)
        Dim dt As New DataTable
        Dim newObj As BE.ReporteServiciosBE

        Dim hdatos As New Hashtable
        hdatos.Add("@cancelada", idServicio)
        hdatos.Add("@fechaDesde", fechaDesde)
        hdatos.Add("@fechaHasta", fechaHasta)

        DS = oDatos.Leer("n_Reporte_Servicios", hdatos)

        If DS.Tables(0).Rows.Count > 0 Then

            For Each Item As DataRow In DS.Tables(0).Rows
                newObj = New BE.ReporteServiciosBE
                newObj.idServicio = Item("idServicio")
                newObj.Nombre = Item("Nombre")
                newObj.Total = Item("Total")

                list.Add(newObj)
            Next

            Return list

        Else
            Return Nothing
        End If
    End Function

    Public Function ObtenerReporteServicios(fechaDesde As Date, fechaHasta As Date) As IEnumerable(Of ReporteServiciosBE)
        Dim oDatos As New DAL.Datos
        Dim DS As New DataSet
        Dim list As New List(Of BE.ReporteServiciosBE)
        Dim dt As New DataTable
        Dim newObj As BE.ReporteServiciosBE

        Dim hdatos As New Hashtable
        hdatos.Add("@cancelada", DBNull.Value)
        hdatos.Add("@fechaDesde", fechaDesde)
        hdatos.Add("@fechaHasta", fechaHasta)

        DS = oDatos.Leer("n_Reporte_Servicios", hdatos)

        If DS.Tables(0).Rows.Count > 0 Then

            For Each Item As DataRow In DS.Tables(0).Rows
                newObj = New BE.ReporteServiciosBE
                newObj.idServicio = Item("idServicio")
                newObj.Nombre = Item("Nombre")
                newObj.Total = Item("Total")

                list.Add(newObj)
            Next

            Return list

        Else
            Return Nothing
        End If
    End Function

    Public Function ObtenerReporteServicios() As IEnumerable(Of ReporteServiciosBE)
        Dim oDatos As New DAL.Datos
        Dim DS As New DataSet
        Dim list As New List(Of BE.ReporteServiciosBE)
        Dim dt As New DataTable
        Dim newObj As BE.ReporteServiciosBE

        Dim hdatos As New Hashtable
        hdatos.Add("@cancelada", DBNull.Value)
        hdatos.Add("@fechaDesde", "1-1-2000")
        hdatos.Add("@fechaHasta", "31-12-2020")

        DS = oDatos.Leer("n_Reporte_Servicios", hdatos)

        If DS.Tables(0).Rows.Count > 0 Then

            For Each Item As DataRow In DS.Tables(0).Rows
                newObj = New BE.ReporteServiciosBE
                newObj.idServicio = Item("idServicio")
                newObj.Nombre = Item("Nombre")
                newObj.Total = Item("Total")

                list.Add(newObj)
            Next

            Return list

        Else
            Return Nothing
        End If
    End Function

    Public Function ObtenerReporteServiciosAños(añoDesde As Integer, añoHasta As Integer) As IEnumerable(Of ReporteServicios1BE)
        Dim oDatos As New DAL.Datos
        Dim DS As New DataSet
        Dim list As New List(Of BE.ReporteServicios1BE)
        Dim dt As New DataTable
        Dim newObj As BE.ReporteServicios1BE

        Dim hdatos As New Hashtable
        hdatos.Add("@añoDesde", añoDesde)
        hdatos.Add("@añoHasta", añoHasta)

        DS = oDatos.Leer("n_Reporte_Servicios_Años", hdatos)

        If DS.Tables(0).Rows.Count > 0 Then

            For Each Item As DataRow In DS.Tables(0).Rows
                newObj = New BE.ReporteServicios1BE
                newObj.rango = Item("rango")
                newObj.total = Item("total")

                list.Add(newObj)
            Next

            Return list

        Else
            Return Nothing
        End If
    End Function

    Public Function ObtenerReporteServiciosAño(año As Integer) As IEnumerable(Of ReporteServicios1BE)
        Dim oDatos As New DAL.Datos
        Dim DS As New DataSet
        Dim list As New List(Of BE.ReporteServicios1BE)
        Dim dt As New DataTable
        Dim newObj As BE.ReporteServicios1BE

        Dim hdatos As New Hashtable
        hdatos.Add("@año", año)

        DS = oDatos.Leer("n_Reporte_Servicios_Año", hdatos)

        If DS.Tables(0).Rows.Count > 0 Then

            For Each Item As DataRow In DS.Tables(0).Rows
                newObj = New BE.ReporteServicios1BE
                newObj.rango = Item("rango")
                newObj.total = Item("total")

                list.Add(newObj)
            Next

            Return list

        Else
            Return Nothing
        End If
    End Function

    Public Function ObtenerReporteServiciosMes(mes As Integer) As IEnumerable(Of ReporteServicios1BE)
        Dim oDatos As New DAL.Datos
        Dim DS As New DataSet
        Dim list As New List(Of BE.ReporteServicios1BE)
        Dim dt As New DataTable
        Dim newObj As BE.ReporteServicios1BE

        Dim hdatos As New Hashtable
        hdatos.Add("@mes", mes)

        DS = oDatos.Leer("n_Reporte_Servicios_Mes", hdatos)

        If DS.Tables(0).Rows.Count > 0 Then

            For Each Item As DataRow In DS.Tables(0).Rows
                newObj = New BE.ReporteServicios1BE
                newObj.rango = Item("rango")
                newObj.total = Item("total")

                list.Add(newObj)
            Next

            Return list

        Else
            Return Nothing
        End If
    End Function

    Public Function ObtenerReporteServiciosSemanal(año As Integer) As IEnumerable(Of ReporteServicios1BE)
        Dim oDatos As New DAL.Datos
        Dim DS As New DataSet
        Dim list As New List(Of BE.ReporteServicios1BE)
        Dim dt As New DataTable
        Dim newObj As BE.ReporteServicios1BE

        Dim hdatos As New Hashtable
        hdatos.Add("@año", año)

        DS = oDatos.Leer("n_Reporte_Servicios_Semanal", hdatos)

        If DS.Tables(0).Rows.Count > 0 Then

            For Each Item As DataRow In DS.Tables(0).Rows
                newObj = New BE.ReporteServicios1BE
                newObj.rango = Item("rango")
                newObj.total = Item("total")

                list.Add(newObj)
            Next

            Return list

        Else
            Return Nothing
        End If
    End Function
End Class
