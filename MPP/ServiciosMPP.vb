Imports BE
Imports MPP

Public Class ServiciosMPP
    Implements IABMC(Of ServiciosBE)

    Private Shared Instancia As ServiciosMPP
    Public Shared Function ObtenerInstancia() As ServiciosMPP
        If Instancia Is Nothing Then
            Instancia = New ServiciosMPP
        End If
        Return Instancia
    End Function

    Public Function Alta(Objeto As ServiciosBE) As Boolean Implements IABMC(Of ServiciosBE).Alta
        Dim oDatos As New DAL.Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean

        hdatos.Add("@tipoConsulta", 1)
        hdatos.Add("@idServicio", 1)
        hdatos.Add("@nombre", Objeto.nombre)
        hdatos.Add("@descripcion", Objeto.descripcion)
        hdatos.Add("@precio", Objeto.precio)
        hdatos.Add("@accesoPlataforma", Objeto.accesoPlataforma)
        hdatos.Add("@materialEstudio", Objeto.materialEstudio)
        hdatos.Add("@reportes", Objeto.reportes)
        hdatos.Add("@capacitaciones", Objeto.capacitaciones)
        hdatos.Add("@imagenData", Objeto.imagenData)
        hdatos.Add("@activo", "1")

        resultado = oDatos.Escribir("n_Servicios_ABMC", hdatos)

        Return resultado
    End Function

    Public Function Baja(Objeto As ServiciosBE) As Boolean Implements IABMC(Of ServiciosBE).Baja
        Dim oDatos As New DAL.Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean

        hdatos.Add("@tipoConsulta", 2)
        hdatos.Add("@idServicio", Objeto.idServicio)
        hdatos.Add("@nombre", DBNull.Value)
        hdatos.Add("@descripcion", DBNull.Value)
        hdatos.Add("@precio", DBNull.Value)
        hdatos.Add("@accesoPlataforma", DBNull.Value)
        hdatos.Add("@materialEstudio", DBNull.Value)
        hdatos.Add("@reportes", DBNull.Value)
        hdatos.Add("@capacitaciones", DBNull.Value)
        hdatos.Add("@imagenData", System.Data.SqlTypes.SqlBinary.Null)
        hdatos.Add("@activo", "0")

        resultado = oDatos.Escribir("n_Servicios_ABMC", hdatos)

        Return resultado
    End Function

    Public Function Modificacion(Objeto As ServiciosBE) As Boolean Implements IABMC(Of ServiciosBE).Modificacion
        Dim oDatos As New DAL.Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean

        hdatos.Add("@tipoConsulta", 3)
        hdatos.Add("@idServicio", Objeto.idServicio)
        hdatos.Add("@nombre", Objeto.nombre)
        hdatos.Add("@descripcion", Objeto.descripcion)
        hdatos.Add("@precio", Objeto.precio)
        hdatos.Add("@accesoPlataforma", Objeto.accesoPlataforma)
        hdatos.Add("@materialEstudio", Objeto.materialEstudio)
        hdatos.Add("@reportes", Objeto.reportes)
        hdatos.Add("@capacitaciones", Objeto.capacitaciones)
        hdatos.Add("@imagenData", Objeto.imagenData)
        hdatos.Add("@activo", Objeto.activo)

        resultado = oDatos.Escribir("n_Servicios_ABMC", hdatos)

        Return resultado
    End Function

    Public Function ListarObjetos() As IEnumerable(Of ServiciosBE) Implements IABMC(Of ServiciosBE).ListarObjetos
        Dim oDatos As New DAL.Datos
        Dim DS As New DataSet
        Dim list As New List(Of BE.ServiciosBE)
        Dim dt As New DataTable
        Dim newObj As BE.ServiciosBE

        Dim hdatos As New Hashtable
        hdatos.Add("@tipoConsulta", 4)
        hdatos.Add("@idServicio", DBNull.Value)
        hdatos.Add("@nombre", DBNull.Value)
        hdatos.Add("@descripcion", DBNull.Value)
        hdatos.Add("@precio", DBNull.Value)
        hdatos.Add("@accesoPlataforma", DBNull.Value)
        hdatos.Add("@materialEstudio", DBNull.Value)
        hdatos.Add("@reportes", DBNull.Value)
        hdatos.Add("@capacitaciones", DBNull.Value)
        hdatos.Add("@imagenData", SqlDbType.VarBinary)
        hdatos.Add("@activo", DBNull.Value)

        DS = oDatos.Leer("n_Servicios_ABMC", hdatos)

        If DS.Tables(0).Rows.Count > 0 Then

            For Each Item As DataRow In DS.Tables(0).Rows
                newObj = New BE.ServiciosBE
                newObj.idServicio = Item("idServicio")
                newObj.nombre = Item("nombre")
                newObj.descripcion = Item("descripcion")
                newObj.precio = Item("precio")
                newObj.accesoPlataforma = Item("accesoPlataforma")
                newObj.materialEstudio = Item("materialEstudio")
                newObj.reportes = Item("reportes")
                newObj.capacitaciones = Item("capacitaciones")
                newObj.imagenData = Item("imagenData")
                newObj.activo = Item("activo")

                list.Add(newObj)
            Next

            Return list

        Else
            Return Nothing
        End If
    End Function

    Public Function ListarObjeto(Objeto As ServiciosBE) As ServiciosBE Implements IABMC(Of ServiciosBE).ListarObjeto
        Dim oDatos As New DAL.Datos
        Dim DS As New DataSet
        Dim dt As New DataTable
        Dim newObj As New BE.ServiciosBE

        Dim hdatos As New Hashtable
        hdatos.Add("@tipoConsulta", 5)
        hdatos.Add("@idServicio", Objeto.idServicio)
        hdatos.Add("@nombre", DBNull.Value)
        hdatos.Add("@descripcion", DBNull.Value)
        hdatos.Add("@precio", DBNull.Value)
        hdatos.Add("@accesoPlataforma", DBNull.Value)
        hdatos.Add("@materialEstudio", DBNull.Value)
        hdatos.Add("@reportes", DBNull.Value)
        hdatos.Add("@capacitaciones", DBNull.Value)
        hdatos.Add("@imagenData", SqlDbType.VarBinary)
        hdatos.Add("@activo", DBNull.Value)

        DS = oDatos.Leer("n_Servicios_ABMC", hdatos)

        If DS.Tables(0).Rows.Count > 0 Then

            For Each Item As DataRow In DS.Tables(0).Rows

                newObj.idServicio = Item("idServicio")
                newObj.nombre = Item("nombre")
                newObj.descripcion = Item("descripcion")
                newObj.precio = Item("precio")
                newObj.accesoPlataforma = Item("accesoPlataforma")
                newObj.materialEstudio = Item("materialEstudio")
                newObj.reportes = Item("reportes")
                newObj.capacitaciones = Item("capacitaciones")
                newObj.imagenData = IIf(Item("imagenData") Is DBNull.Value, SqlDbType.VarBinary, Item("imagenData"))
                newObj.activo = Item("activo")

            Next

            Return newObj

        Else
            Return Nothing
        End If
    End Function

    Public Function ListarObjetos(Objeto As ServiciosBE) As IEnumerable(Of ServiciosBE)
        Dim oDatos As New DAL.Datos
        Dim DS As New DataSet
        Dim list As New List(Of BE.ServiciosBE)
        Dim dt As New DataTable
        Dim newObj As BE.ServiciosBE

        Dim hdatos As New Hashtable
        hdatos.Add("@tipoConsulta", 4)
        hdatos.Add("@idServicio", Objeto.idServicio)
        hdatos.Add("@nombre", DBNull.Value)
        hdatos.Add("@descripcion", DBNull.Value)
        hdatos.Add("@precio", DBNull.Value)
        hdatos.Add("@accesoPlataforma", DBNull.Value)
        hdatos.Add("@materialEstudio", DBNull.Value)
        hdatos.Add("@reportes", DBNull.Value)
        hdatos.Add("@capacitaciones", DBNull.Value)
        hdatos.Add("@imagenData", SqlDbType.VarBinary)
        hdatos.Add("@activo", DBNull.Value)

        DS = oDatos.Leer("n_Servicios_ABMC", hdatos)

        If DS.Tables(0).Rows.Count > 0 Then

            For Each Item As DataRow In DS.Tables(0).Rows
                newObj = New BE.ServiciosBE
                newObj.idServicio = Item("idServicio")
                newObj.nombre = Item("nombre")
                newObj.descripcion = Item("descripcion")
                newObj.precio = Item("precio")
                newObj.accesoPlataforma = Item("accesoPlataforma")
                newObj.materialEstudio = Item("materialEstudio")
                newObj.reportes = Item("reportes")
                newObj.capacitaciones = Item("capacitaciones")
                newObj.imagenData = IIf(Item("imagenData") Is DBNull.Value, SqlDbType.VarBinary, Item("imagenData"))
                newObj.activo = Item("activo")

                list.Add(newObj)
            Next

            Return list

        Else
            Return Nothing
        End If
    End Function

    Public Function ListarComentarios(Objeto As ServiciosBE) As IEnumerable(Of ServiciosComentariosBE)
        Try
            Dim listaComentarios As New List(Of ServiciosComentariosBE)

            Dim oDatos As New DAL.Datos
            Dim DS As New DataSet
            Dim dt As New DataTable


            Dim hdatos As New Hashtable
            hdatos.Add("@tipoConsulta", 5)
            hdatos.Add("@idComentario", DBNull.Value)
            hdatos.Add("@nombre", DBNull.Value)
            hdatos.Add("@detalle", DBNull.Value)
            hdatos.Add("@fechaHora", DBNull.Value)
            hdatos.Add("@idServicio", Objeto.idServicio)

            DS = oDatos.Leer("n_Servicios_Comentarios_ABMC", hdatos)

            If DS.Tables(0).Rows.Count > 0 Then

                For Each Item As DataRow In DS.Tables(0).Rows
                    Dim newObj As New BE.ServiciosComentariosBE

                    newObj.idServicio = Item("idServicio")
                    newObj.nombre = Item("nombre")
                    newObj.detalle = Item("detalle")
                    newObj.fechaHora = Item("fechaHora")
                    newObj.idComentario = Item("idComentario")

                    If Not Item("idComentarioRespuesta") Is DBNull.Value Then
                        newObj.tieneRespuesta = True
                        newObj.nombreRespuesta = Item("nombreRespuesta")
                        newObj.detalleRespuesta = Item("detalleRespuesta")
                        newObj.fechaHoraRespuesta = Item("fechaHoraRespuesta")
                    Else
                        newObj.tieneRespuesta = False

                    End If

                    listaComentarios.Add(newObj)
                Next

                Return listaComentarios

            Else
                Return Nothing
            End If

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function AgregarComentario(Comentario As ServiciosComentariosBE) As Boolean
        Try
            Dim oDatos As New DAL.Datos
            Dim hdatos As New Hashtable
            Dim resultado As Boolean

            hdatos.Add("@tipoConsulta", 1)
            hdatos.Add("@idComentario", 1)
            hdatos.Add("@nombre", Comentario.nombre)
            hdatos.Add("@detalle", Comentario.detalle)
            hdatos.Add("@fechaHora", Comentario.fechaHora)
            hdatos.Add("@idServicio", Comentario.idServicio)

            resultado = oDatos.Escribir("n_Servicios_Comentarios_ABMC", hdatos)

            Return resultado

            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function AgregarRespuesta(Comentario As ServiciosComentariosBE) As Boolean
        Try
            Dim oDatos As New DAL.Datos
            Dim hdatos As New Hashtable
            Dim resultado As Boolean

            hdatos.Add("@tipoConsulta", 1)
            hdatos.Add("@idComentarioRespuesta", 1)
            hdatos.Add("@nombre", Comentario.nombre)
            hdatos.Add("@detalle", Comentario.detalle)
            hdatos.Add("@fechaHora", Comentario.fechaHora)
            hdatos.Add("@idComentario", Comentario.idServicio)

            resultado = oDatos.Escribir("n_Servicios_ComentariosRespuesta_ABMC", hdatos)

            Return resultado

            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function AgregarVoto(idServicio As Integer, voto As Integer, usuario As UsuarioBE) As Boolean
        Dim oDatos As New DAL.Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean

        hdatos.Add("@idServicio", idServicio)
        hdatos.Add("@voto", voto)
        hdatos.Add("@usuario", usuario.mail)

        resultado = oDatos.Escribir("n_Servicios_Votar", hdatos)

        Return resultado
    End Function


    Public Function ListarObjetosAvanzada(nombre As String, descripcion As String, precio As String, accesoPlataforma As String, materialEstudio As String, reportes As String, capacitaciones As String) As IEnumerable(Of ServiciosBE)
        Try
            Dim oDatos As New DAL.Datos
            Dim DS As New DataSet
            Dim list As New List(Of BE.ServiciosBE)
            Dim dt As New DataTable
            Dim newObj As BE.ServiciosBE

            Dim hdatos As New Hashtable
            hdatos.Add("@nombre", IIf(nombre = Nothing, DBNull.Value, nombre))
            hdatos.Add("@descripcion", IIf(descripcion = Nothing, DBNull.Value, descripcion))
            hdatos.Add("@precio", IIf(precio = Nothing, DBNull.Value, precio))
            hdatos.Add("@accesoPlataforma", IIf(accesoPlataforma = "---", DBNull.Value, accesoPlataforma))
            hdatos.Add("@materialEstudio", IIf(materialEstudio = "---", DBNull.Value, materialEstudio))
            hdatos.Add("@reportes", IIf(reportes = "---", DBNull.Value, reportes))
            hdatos.Add("@capacitaciones", IIf(capacitaciones = "---", DBNull.Value, capacitaciones))

            DS = oDatos.Leer("n_Servicio_BuscarAvanzado", hdatos)

            If DS.Tables(0).Rows.Count > 0 Then

                For Each Item As DataRow In DS.Tables(0).Rows
                    newObj = New BE.ServiciosBE
                    newObj.idServicio = Item("idServicio")
                    newObj.nombre = Item("nombre")
                    newObj.descripcion = Item("descripcion")
                    newObj.precio = Item("precio")
                    newObj.accesoPlataforma = Item("accesoPlataforma")
                    newObj.materialEstudio = Item("materialEstudio")
                    newObj.reportes = Item("reportes")
                    newObj.capacitaciones = Item("capacitaciones")
                    newObj.imagenData = IIf(Item("imagenData") Is DBNull.Value, SqlDbType.VarBinary, Item("imagenData"))
                    newObj.activo = Item("activo")

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

    Public Function ListarObjetosSimple(campo As String) As IEnumerable(Of ServiciosBE)
        Try
            Dim oDatos As New DAL.Datos
            Dim DS As New DataSet
            Dim list As New List(Of BE.ServiciosBE)
            Dim dt As New DataTable
            Dim newObj As BE.ServiciosBE

            Dim hdatos As New Hashtable
            hdatos.Add("@campoBusqueda", IIf(campo = Nothing, DBNull.Value, campo))

            DS = oDatos.Leer("s_Servicios_BuscarSimple", hdatos)

            If DS.Tables(0).Rows.Count > 0 Then

                For Each Item As DataRow In DS.Tables(0).Rows
                    newObj = New BE.ServiciosBE
                    newObj.idServicio = Item("idServicio")
                    newObj.nombre = Item("nombre")
                    newObj.descripcion = Item("descripcion")
                    newObj.precio = Item("precio")
                    newObj.accesoPlataforma = Item("accesoPlataforma")
                    newObj.materialEstudio = Item("materialEstudio")
                    newObj.reportes = Item("reportes")
                    newObj.capacitaciones = Item("capacitaciones")
                    newObj.imagenData = IIf(Item("imagenData") Is DBNull.Value, SqlDbType.VarBinary, Item("imagenData"))
                    newObj.activo = Item("activo")

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

    Function PermiteVoto(idServicio As Integer, usuario As UsuarioBE) As Boolean
        Try
            Dim oDatos As New DAL.Datos
            Dim DS As New DataSet
            Dim dt As New DataTable

            Dim hdatos As New Hashtable
            hdatos.Add("@idServicio", idServicio)
            hdatos.Add("@usuario", usuario.mail)

            DS = oDatos.Leer("n_Servicios_ValidarVotar", hdatos)

            If DS.Tables(0).Rows.Count > 0 Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function ListarRanking() As IEnumerable(Of ServiciosBE)
        Try
            Dim oDatos As New DAL.Datos
            Dim DS As New DataSet
            Dim list As New List(Of BE.ServiciosBE)
            Dim dt As New DataTable
            Dim newObj As BE.ServiciosBE

            Dim hdatos As New Hashtable

            DS = oDatos.Leer("n_Servicios_Ranking", hdatos)

            If DS.Tables(0).Rows.Count > 0 Then

                For Each Item As DataRow In DS.Tables(0).Rows
                    newObj = New BE.ServiciosBE
                    newObj.idServicio = Item("idServicio")
                    newObj.nombre = Item("nombre")
                    newObj.precio = Item("Voto")

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
