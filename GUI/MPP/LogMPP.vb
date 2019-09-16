Imports BE

Public Class LogMPP


    Public Function Alta(Objeto As LogBE) As Boolean
        Dim oDatos As New DAL.Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean

        hdatos.Add("@tipoConsulta", 1)
        hdatos.Add("@idLog", 1)
        hdatos.Add("@usuarioMail", Objeto.usuarioMail)
        hdatos.Add("@idTipo", Objeto.idTipo)
        hdatos.Add("@criticidad", Objeto.criticidad)

        hdatos.Add("@fechaDesde", DBNull.Value)
        hdatos.Add("@fechaHasta", DBNull.Value)

        resultado = oDatos.Escribir("s_Log_ABMC", hdatos)

        Return resultado
    End Function

    Public Function ListarObjetos() As IEnumerable(Of LogBE)
        Dim oDatos As New DAL.Datos
        Dim DS As New DataSet
        Dim list As New List(Of BE.LogBE)
        Dim dt As New DataTable
        Dim newObj As BE.LogBE

        Dim hdatos As New Hashtable
        hdatos.Add("@tipoConsulta", 2)
        hdatos.Add("@idLog", DBNull.Value)
        hdatos.Add("@usuarioMail", DBNull.Value)
        hdatos.Add("@idTipo", DBNull.Value)
        hdatos.Add("@criticidad", DBNull.Value)
        hdatos.Add("@fechaDesde", DBNull.Value)
        hdatos.Add("@fechaHasta", DBNull.Value)

        DS = oDatos.Leer("s_Log_ABMC", hdatos)

        If DS.Tables(0).Rows.Count > 0 Then

            For Each Item As DataRow In DS.Tables(0).Rows
                newObj = New BE.LogBE
                newObj.idLog = Item("idLog")
                newObj.usuarioMail = Item("usuarioMail")
                newObj.fecha = Item("fecha")
                newObj.idTipo = Item("idTipo")
                newObj.TipoDescr = Item("descr")
                newObj.criticidad = Item("criticidad")

                list.Add(newObj)
            Next

            Return list

        Else
            Return Nothing
        End If
    End Function

    Public Function ListarTipos() As Hashtable
        Try
            Dim oDatos As New DAL.Datos
            Dim DS As New DataSet
            Dim dt As New DataTable
            Dim listaTipo As New Hashtable

            Dim hdatos As New Hashtable


            DS = oDatos.Leer("s_Log_GetTipos", hdatos)

            If DS.Tables(0).Rows.Count > 0 Then

                For Each Item As DataRow In DS.Tables(0).Rows
                    listaTipo.Add(Item(0), Item(1))
                Next

                Return listaTipo

            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function ListarObjetosSimple(campo As String) As IEnumerable(Of LogBE)
        Try
            Dim oDatos As New DAL.Datos
            Dim DS As New DataSet
            Dim list As New List(Of BE.LogBE)
            Dim dt As New DataTable
            Dim newObj As BE.LogBE

            Dim hdatos As New Hashtable
            hdatos.Add("@campoBusqueda", campo)

            DS = oDatos.Leer("s_Log_BuscarSimple", hdatos)

            If DS.Tables(0).Rows.Count > 0 Then

                For Each Item As DataRow In DS.Tables(0).Rows
                    newObj = New BE.LogBE
                    newObj.idLog = Item("idLog")
                    newObj.usuarioMail = Item("usuarioMail")
                    newObj.fecha = Item("fecha")
                    newObj.idTipo = Item("idTipo")
                    newObj.TipoDescr = Item("descr")
                    newObj.criticidad = Item("criticidad")

                    list.Add(newObj)
                Next

                Return list

            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function ListarObjetosAvanzada(oLog As LogBE, fechaDesde As Date, fechaHasta As Date) As IEnumerable(Of LogBE)
        Try
            Dim oDatos As New DAL.Datos
            Dim DS As New DataSet
            Dim list As New List(Of BE.LogBE)
            Dim dt As New DataTable
            Dim newObj As BE.LogBE

            Dim hdatos As New Hashtable
            hdatos.Add("@usuarioMail", IIf(oLog.usuarioMail = Nothing, DBNull.Value, oLog.usuarioMail))
            hdatos.Add("@fechaDesde", IIf(fechaDesde = Nothing, DBNull.Value, fechaDesde))
            hdatos.Add("@fechaHasta", IIf(fechaHasta = Nothing, DBNull.Value, fechaHasta))
            hdatos.Add("@idTipo", IIf(oLog.idTipo = Nothing, DBNull.Value, oLog.idTipo))
            hdatos.Add("@criticidad", IIf(oLog.criticidad = Nothing, DBNull.Value, oLog.criticidad))

            DS = oDatos.Leer("s_Log_BuscarAvanzado", hdatos)

            If DS.Tables(0).Rows.Count > 0 Then

                For Each Item As DataRow In DS.Tables(0).Rows
                    newObj = New BE.LogBE
                    newObj.idLog = Item("idLog")
                    newObj.usuarioMail = Item("usuarioMail")
                    newObj.fecha = Item("fecha")
                    newObj.idTipo = Item("idTipo")
                    newObj.TipoDescr = Item("descr")
                    newObj.criticidad = Item("criticidad")

                    list.Add(newObj)
                Next

                Return list

            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

End Class
