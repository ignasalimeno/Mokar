﻿Imports BE
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

    Public Function ObtenerReporteServicios(idServicio As Integer) As IEnumerable(Of ReporteServiciosBE)
        Dim oDatos As New DAL.Datos
        Dim DS As New DataSet
        Dim list As New List(Of BE.ReporteServiciosBE)
        Dim dt As New DataTable
        Dim newObj As BE.ReporteServiciosBE

        Dim hdatos As New Hashtable
        hdatos.Add("@idServicio", idServicio)

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
        hdatos.Add("@idServicio", DBNull.Value)

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
End Class