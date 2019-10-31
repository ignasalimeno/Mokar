Imports BE

Public Class MaterialEstudioMPP

    Private Shared Instancia As MaterialEstudioMPP

    Public Shared Function ObtenerInstancia() As MaterialEstudioMPP
        If Instancia Is Nothing Then
            Instancia = New MaterialEstudioMPP
        End If
        Return Instancia
    End Function

    Public Function Alta(Objeto As MaterialEstudioBE) As Boolean
        Dim oDatos As New DAL.Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean

        hdatos.Add("@tipoConsulta", 1)
        hdatos.Add("@idME", 1)
        hdatos.Add("@titulo", Objeto.titulo)
        hdatos.Add("@descripcion", Objeto.descripcion)
        hdatos.Add("@autor", Objeto.autor)
        hdatos.Add("@fechaCreacion", Objeto.fechaCreacion)
        hdatos.Add("@ruta", Objeto.ruta)
        hdatos.Add("@activo", "1")

        resultado = oDatos.Escribir("n_MaterialEstudio_ABMC", hdatos)

        Return resultado
    End Function

    Public Function Baja(Objeto As MaterialEstudioBE) As Boolean
        Dim oDatos As New DAL.Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean

        hdatos.Add("@tipoConsulta", 2)
        hdatos.Add("@idME", Objeto.idME)
        hdatos.Add("@titulo", DBNull.Value)
        hdatos.Add("@descripcion", DBNull.Value)
        hdatos.Add("@autor", DBNull.Value)
        hdatos.Add("@fechaCreacion", DBNull.Value)
        hdatos.Add("@ruta", DBNull.Value)
        hdatos.Add("@activo", "0")

        resultado = oDatos.Escribir("n_MaterialEstudio_ABMC", hdatos)

        Return resultado
    End Function

    Public Function Modificacion(Objeto As MaterialEstudioBE) As Boolean
        Dim oDatos As New DAL.Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean

        hdatos.Add("@tipoConsulta", 3)
        hdatos.Add("@idME", Objeto.idME)
        hdatos.Add("@titulo", Objeto.titulo)
        hdatos.Add("@descripcion", Objeto.descripcion)
        hdatos.Add("@autor", Objeto.autor)
        hdatos.Add("@fechaCreacion", Objeto.fechaCreacion)
        hdatos.Add("@ruta", IIf(Objeto.ruta = "", DBNull.Value, Objeto.ruta))
        hdatos.Add("@activo", Objeto.activo)


        resultado = oDatos.Escribir("n_MaterialEstudio_ABMC", hdatos)

        Return resultado
    End Function

    Public Function ListarObjetos() As IEnumerable(Of MaterialEstudioBE)
        Dim oDatos As New DAL.Datos
        Dim DS As New DataSet
        Dim list As New List(Of BE.MaterialEstudioBE)
        Dim dt As New DataTable
        Dim newObj As BE.MaterialEstudioBE

        Dim hdatos As New Hashtable
        hdatos.Add("@tipoConsulta", 4)
        hdatos.Add("@idME", DBNull.Value)
        hdatos.Add("@titulo", DBNull.Value)
        hdatos.Add("@descripcion", DBNull.Value)
        hdatos.Add("@autor", DBNull.Value)
        hdatos.Add("@fechaCreacion", DBNull.Value)
        hdatos.Add("@ruta", DBNull.Value)
        hdatos.Add("@activo", DBNull.Value)

        DS = oDatos.Leer("n_MaterialEstudio_ABMC", hdatos)

        If DS.Tables(0).Rows.Count > 0 Then

            For Each Item As DataRow In DS.Tables(0).Rows
                newObj = New BE.MaterialEstudioBE
                newObj.idME = Item("idME")
                newObj.titulo = Item("titulo")
                newObj.descripcion = Item("descripcion")
                newObj.autor = Item("autor")
                newObj.fechaCreacion = Item("fechaCreacion")
                newObj.ruta = Item("ruta")
                newObj.activo = Item("activo")

                list.Add(newObj)
            Next

            Return list

        Else
            Return Nothing
        End If
    End Function

    Public Function ListarObjeto(Objeto As MaterialEstudioBE) As MaterialEstudioBE
        Dim oDatos As New DAL.Datos
        Dim DS As New DataSet
        Dim dt As New DataTable
        Dim newObj As New BE.MaterialEstudioBE

        Dim hdatos As New Hashtable
        hdatos.Add("@tipoConsulta", 5)
        hdatos.Add("@idME", Objeto.idME)
        hdatos.Add("@titulo", DBNull.Value)
        hdatos.Add("@descripcion", DBNull.Value)
        hdatos.Add("@autor", DBNull.Value)
        hdatos.Add("@fechaCreacion", DBNull.Value)
        hdatos.Add("@ruta", DBNull.Value)
        hdatos.Add("@activo", DBNull.Value)

        DS = oDatos.Leer("n_MaterialEstudio_ABMC", hdatos)

        If DS.Tables(0).Rows.Count > 0 Then

            For Each Item As DataRow In DS.Tables(0).Rows

                newObj = New BE.MaterialEstudioBE
                newObj.idME = Item("idME")
                newObj.titulo = Item("titulo")
                newObj.descripcion = Item("descripcion")
                newObj.autor = Item("autor")
                newObj.fechaCreacion = Item("fechaCreacion")
                newObj.ruta = Item("ruta")
                newObj.activo = Item("activo")

            Next

            Return newObj

        Else
            Return Nothing
        End If
    End Function
End Class
