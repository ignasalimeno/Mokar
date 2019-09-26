Imports BE
Imports DAL

Public Class EncuestaMPP

#Region "Singleton"
    Private Sub New()
    End Sub

    Private Shared Instancia As EncuestaMPP
    Public Shared Function ObtenerInstancia() As EncuestaMPP
        If Instancia Is Nothing Then
            Instancia = New EncuestaMPP
        End If
        Return Instancia
    End Function
#End Region

    Public Function ListarTipos() As List(Of EncuestaBE)
        Dim Lista As New List(Of EncuestaBE)
        Dim hdatos As New Hashtable
        For Each row As DataRow In Datos.ObtenerInstancia.Leer("[n_Encuesta_ABMC]", hdatos).Tables(0).Rows
            Dim x As New EncuestaBE With {.idEncuesta = row("idEncuesta"), .idTipoEncuesta = row("idTipoEncuesta")}
            Lista.Add(x)
        Next
        Return Lista
        Throw New Exception("Mokar informa que ha ocurrido un error")
    End Function

    Public Function ListarTodas() As List(Of EncuestaBE)
        Try
            Dim hdatos As New Hashtable
            Dim DS As New DataSet
            Dim oObj As New EncuestaBE
            Dim lista As New List(Of EncuestaBE)

            hdatos.Add("@tipoConsulta", 4)
            hdatos.Add("@idEncuesta", DBNull.Value)
            hdatos.Add("@Titulo", DBNull.Value)
            hdatos.Add("@FechaVencimiento", DBNull.Value)
            hdatos.Add("@idTipoEncuesta", DBNull.Value)

            DS = Datos.ObtenerInstancia.Leer("[n_Encuesta_ABMC]", hdatos)
            If DS.Tables(0).Rows.Count > 0 Then
                For Each Item As DataRow In DS.Tables(0).Rows
                    oObj = New EncuestaBE
                    With oObj
                        .idEncuesta = Item("idEncuesta")
                        .FechaVencimiento = Item("FechaVencimiento")
                        .Titulo = Item("Titulo")
                        .idTipoEncuesta = Item("idTipoEncuesta")
                    End With
                    oObj.Preguntas = ListarOpcionesEncuesta(oObj.idEncuesta).ToList
                    lista.Add(oObj)
                Next
                Return lista
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function ListarOpcionesEncuesta(id As Integer) As List(Of EncuestaPreguntaBE)
        Try

            Dim DS As New DataSet
            Dim hdatos As New Hashtable
            Dim lista As New List(Of EncuestaPreguntaBE)
            'Dim DT As New DataTable
            hdatos.Add("@tipoConsulta", 6)
            hdatos.Add("@idPregunta", DBNull.Value)
            hdatos.Add("@Pregunta", DBNull.Value)
            hdatos.Add("@idEncuesta", id)


            DS = Datos.ObtenerInstancia.Leer("[n_EncuestaPreguntas_ABMC]", hdatos)

            If DS.Tables(0).Rows.Count > 0 Then
                For Each Item As DataRow In DS.Tables(0).Rows
                    Dim opc As New EncuestaPreguntaBE
                    opc.idPregunta = Item("idPregunta")
                    opc.Pregunta = Item("Pregunta")
                    opc.Respuestas = ListarRespuestasEncuesta(opc.idPregunta)
                    lista.Add(opc)
                Next
                Return lista.ToList
            Else
                Return lista.ToList
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function ListarRespuestasEncuesta(id As Integer) As List(Of EncuestaRespuestasBE)
        Try

            Dim DS As New DataSet
            Dim hdatos As New Hashtable
            Dim lista As New List(Of EncuestaRespuestasBE)
            'Dim DT As New DataTable
            hdatos.Add("@tipoConsulta", 6)
            hdatos.Add("@idRespuesta", DBNull.Value)
            hdatos.Add("@Respuesta", DBNull.Value)
            hdatos.Add("@idPregunta", id)
            hdatos.Add("@Cantidad", DBNull.Value)

            DS = Datos.ObtenerInstancia.Leer("[n_EncuestaRespuestas_ABMC]", hdatos)

            If DS.Tables(0).Rows.Count > 0 Then
                For Each Item As DataRow In DS.Tables(0).Rows
                    Dim opc As New EncuestaRespuestasBE
                    opc.idRespuesta = Item("idRespuesta")
                    opc.Respuesta = Item("Respuesta")
                    If Not TypeOf Item("Cantidad") Is DBNull Then opc.Cantidad = Item("Cantidad") Else opc.Cantidad = 0
                    lista.Add(opc)
                Next
                Return lista.ToList
            Else
                Return lista.ToList
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Votar(respuesta As Integer) As Boolean
        Try
            Dim hdatos As New Hashtable
            hdatos.Add("@idRespuesta", respuesta)
            Datos.ObtenerInstancia.Escribir("[n_EncuestaRespuestas_Votar]", hdatos)

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function Crear(ByRef Objeto As EncuestaBE) As Boolean
        Try
            Dim oDatos As New DAL.Datos
            Dim hdatos As New Hashtable
            Dim resultado As Boolean

            hdatos.Add("@tipoConsulta", 1)
            hdatos.Add("@idEncuesta", 1)
            hdatos.Add("@Titulo", Objeto.Titulo)
            hdatos.Add("@FechaVencimiento", Objeto.FechaVencimiento)
            hdatos.Add("@idTipoEncuesta", Objeto.idTipoEncuesta)

            Dim DS As DataSet = oDatos.Leer("n_Encuesta_ABMC", hdatos)

            If DS.Tables(0).Rows.Count > 0 Then
                Dim idEnc As Integer = DS.Tables(0).Rows(0).Item(0)

                For Each a As EncuestaPreguntaBE In Objeto.Preguntas
                    CrearPregunta(a, idEnc)
                Next
            End If

            Return resultado
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function CrearPregunta(Objeto As EncuestaPreguntaBE, idEncuesta As Integer)
        Try
            Dim oDatos As New DAL.Datos
            Dim hdatos As New Hashtable
            Dim resultado As Boolean

            hdatos.Add("@tipoConsulta", 1)
            hdatos.Add("@idPregunta", Objeto.idPregunta)
            hdatos.Add("@Pregunta", Objeto.Pregunta)
            hdatos.Add("@idEncuesta", idEncuesta)

            Dim DS As DataSet = oDatos.Leer("n_EncuestaPreguntas_ABMC", hdatos)

            If DS.Tables(0).Rows.Count > 0 Then
                Dim idPre As Integer = DS.Tables(0).Rows(0).Item(0)

                For Each a As EncuestaRespuestasBE In Objeto.Respuestas
                    CrearRespuesta(a, idPre)
                Next
            End If

            Return resultado

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function CrearRespuesta(ByRef Objeto As EncuestaRespuestasBE, idPregunta As Integer)
        Try
            Dim oDatos As New DAL.Datos
            Dim hdatos As New Hashtable
            Dim resultado As Boolean

            hdatos.Add("@tipoConsulta", 1)
            hdatos.Add("@idRespuesta", Objeto.idRespuesta)
            hdatos.Add("@Respuesta", Objeto.Respuesta)
            hdatos.Add("@idPregunta", idPregunta)
            hdatos.Add("@Cantidad", Objeto.Cantidad)

            resultado = oDatos.Escribir("n_EncuestaRespuestas_ABMC", hdatos)

            Return resultado

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function VerResultadoEncuesta(objeto As EncuestaBE) As EncuestaBE
        Try
            'Dim hdatos As New Hashtable
            'Dim DS As New DataSet
            'Dim oObj As New EncuestaBE


            'oObj = Cargar(objeto)
            'hdatos.Add("@ID_Encuesta", Id)
            'DS = Acceso.ObtenerInstancia.Leer2("EncuestaRespuestas_ResultadoID", hdatos)

            'If DS.Tables(0).Rows.Count > 0 Then
            '    For Each Item As DataRow In DS.Tables(0).Rows
            '        Dim oOpcion As New EncuestaRespuesta With {.Id = Id, .Opcion = Item("Respuesta"), .Cantidad = Item("Cantidad"),
            '        .OpcionID = Item("ID_Respuesta")}
            '        oObj.Opciones.Add(oOpcion)
            '    Next
            '    Return oObj
            'Else
            '    Return Nothing
            'End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Cargar(objeto As EncuestaBE) As EncuestaBE
        Try
            Dim hdatos As New Hashtable
            Dim DS As New DataSet
            Dim oObj As New EncuestaBE
            Dim lista As New List(Of EncuestaBE)

            hdatos.Add("@tipoConsulta", 5)
            hdatos.Add("@idEncuesta", objeto.idEncuesta)
            hdatos.Add("@Titulo", DBNull.Value)
            hdatos.Add("@FechaVencimiento", DBNull.Value)
            hdatos.Add("@idTipoEncuesta", DBNull.Value)

            DS = Datos.ObtenerInstancia.Leer("[n_Encuesta_ABMC]", hdatos)

            If DS.Tables(0).Rows.Count > 0 Then
                For Each Item As DataRow In DS.Tables(0).Rows
                    oObj = New EncuestaBE
                    With oObj
                        .idEncuesta = Item("idEncuesta")
                        .Titulo = Item("Titulo")
                        .FechaVencimiento = Item("FechaVencimiento")
                        .idTipoEncuesta = Item("idTipoEncuesta")
                    End With
                    oObj.Preguntas = ListarOpcionesEncuesta(oObj.idEncuesta).ToList
                Next

                Return oObj
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Eliminar(ByVal objeto As EncuestaBE)
        Try
            Dim hdatos As New Hashtable
            hdatos.Add("@tipoConsulta", 2)
            hdatos.Add("@idEncuesta", objeto.idEncuesta)
            hdatos.Add("@Titulo", DBNull.Value)
            hdatos.Add("@FechaVencimiento", DBNull.Value)
            hdatos.Add("@idTipoEncuesta", DBNull.Value)

            Return Datos.ObtenerInstancia.Escribir("[n_Encuesta_ABMC]", hdatos)
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function AltaPregunta(idEncuesta As Integer, objeto As EncuestaPreguntaBE) As Boolean
        Try
            Dim oDatos As New DAL.Datos
            Dim hdatos As New Hashtable

            hdatos.Add("@tipoConsulta", 1)
            hdatos.Add("@idPregunta", 1)
            hdatos.Add("@Pregunta", objeto.Pregunta)
            hdatos.Add("@idEncuesta", idEncuesta)

            Return oDatos.Escribir("n_EncuestaPreguntas_ABMC", hdatos)

        Catch ex As Exception
            Return False
        End Try
    End Function

    Function EliminarPregunta(idEncuesta As Integer, objeto As EncuestaPreguntaBE) As Boolean
        Try
            Dim oDatos As New DAL.Datos
            Dim hdatos As New Hashtable

            hdatos.Add("@tipoConsulta", 2)
            hdatos.Add("@idPregunta", objeto.idPregunta)
            hdatos.Add("@Pregunta", DBNull.Value)
            hdatos.Add("@idEncuesta", DBNull.Value)

            Return oDatos.Escribir("n_EncuestaPreguntas_ABMC", hdatos)

        Catch ex As Exception
            Return False
        End Try
    End Function

    Function ModificarPregunta(idEncuesta As Integer, objeto As EncuestaPreguntaBE) As Boolean
        Try
            Dim oDatos As New DAL.Datos
            Dim hdatos As New Hashtable

            hdatos.Add("@tipoConsulta", 3)
            hdatos.Add("@idPregunta", objeto.idPregunta)
            hdatos.Add("@Pregunta", objeto.Pregunta)
            hdatos.Add("@idEncuesta", idEncuesta)

            Return oDatos.Escribir("n_EncuestaPreguntas_ABMC", hdatos)

        Catch ex As Exception
            Return False
        End Try
    End Function

    Function AltaRta(idPregunta As Integer, objeto As EncuestaRespuestasBE) As Boolean
        Try
            Dim oDatos As New DAL.Datos
            Dim hdatos As New Hashtable

            hdatos.Add("@tipoConsulta", 1)
            hdatos.Add("@idRespuesta", 1)
            hdatos.Add("@Respuesta", objeto.Respuesta)
            hdatos.Add("@idPregunta", idPregunta)
            hdatos.Add("@Cantidad", 0)

            Return oDatos.Escribir("n_EncuestaRespuestas_ABMC", hdatos)

        Catch ex As Exception
            Return False
        End Try
    End Function

    Function EliminarRta(idPregunta As Integer, objeto As EncuestaRespuestasBE) As Boolean
        Try
            Dim oDatos As New DAL.Datos
            Dim hdatos As New Hashtable

            hdatos.Add("@tipoConsulta", 2)
            hdatos.Add("@idRespuesta", objeto.idRespuesta)
            hdatos.Add("@Respuesta", DBNull.Value)
            hdatos.Add("@idPregunta", DBNull.Value)
            hdatos.Add("@Cantidad", DBNull.Value)

            Return oDatos.Escribir("n_EncuestaRespuestas_ABMC", hdatos)
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function ModificarRta(idPregunta As Integer, objeto As EncuestaRespuestasBE) As Boolean
        Try
            Dim oDatos As New DAL.Datos
            Dim hdatos As New Hashtable

            hdatos.Add("@tipoConsulta", 3)
            hdatos.Add("@idRespuesta", objeto.idRespuesta)
            hdatos.Add("@Respuesta", objeto.Respuesta)
            hdatos.Add("@idPregunta", idPregunta)
            hdatos.Add("@Cantidad", 0)

            Return oDatos.Escribir("n_EncuestaRespuestas_ABMC", hdatos)
        Catch ex As Exception
            Return False
        End Try
    End Function


End Class
