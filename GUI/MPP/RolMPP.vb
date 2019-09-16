Imports BE

Public Class RolMPP
    Implements IABMC(Of RolBE)

    Private Shared Instancia As RolMPP
    Public Shared Function ObtenerInstancia() As RolMPP
        If Instancia Is Nothing Then
            Instancia = New RolMPP
        End If
        Return Instancia
    End Function


    Public Function Alta(Objeto As RolBE) As Boolean Implements IABMC(Of RolBE).Alta
        Dim oDatos As New DAL.Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean

        hdatos.Add("@tipoConsulta", 1)
        hdatos.Add("@idRol", 1)
        hdatos.Add("@descripcion", Objeto.descr)
        hdatos.Add("@activo", "1")
        hdatos.Add("@rolUsuario", Objeto.rolUsuario)

        resultado = oDatos.Escribir("s_Rol_ABMC", hdatos)

        Return resultado
    End Function

    Public Function Baja(Objeto As RolBE) As Boolean Implements IABMC(Of RolBE).Baja
        Dim oDatos As New DAL.Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean

        hdatos.Add("@tipoConsulta", 2)
        hdatos.Add("@idRol", Objeto.idRol)
        hdatos.Add("@descripcion", DBNull.Value)
        hdatos.Add("@activo", "0")
        hdatos.Add("@rolUsuario", DBNull.Value)

        resultado = oDatos.Escribir("s_Rol_ABMC", hdatos)

        Return resultado
    End Function

    Public Function Modificacion(Objeto As RolBE) As Boolean Implements IABMC(Of RolBE).Modificacion
        Dim oDatos As New DAL.Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean

        hdatos.Add("@tipoConsulta", 3)
        hdatos.Add("@idRol", Objeto.idRol)
        hdatos.Add("@descripcion", Objeto.descr)
        hdatos.Add("@activo", 1)
        hdatos.Add("@rolUsuario", Objeto.rolUsuario)

        resultado = oDatos.Escribir("s_Rol_ABMC", hdatos)

        Return resultado
    End Function

    Public Function ListarObjetos() As IEnumerable(Of RolBE) Implements IABMC(Of RolBE).ListarObjetos
        Dim oDatos As New DAL.Datos
        Dim DS As New DataSet
        Dim list As New List(Of BE.RolBE)
        Dim dt As New DataTable
        Dim newObj As BE.RolBE

        Dim hdatos As New Hashtable
        hdatos.Add("@tipoConsulta", 4)
        hdatos.Add("@idRol", DBNull.Value)
        hdatos.Add("@descripcion", DBNull.Value)
        hdatos.Add("@activo", DBNull.Value)
        hdatos.Add("@rolUsuario", DBNull.Value)

        DS = oDatos.Leer("s_Rol_ABMC", hdatos)

        If DS.Tables(0).Rows.Count > 0 Then

            For Each Item As DataRow In DS.Tables(0).Rows
                newObj = New BE.RolBE
                newObj.idRol = Item("idRol")
                newObj.descr = Item("descripcion")
                newObj.activo = Item("activo")
                newObj.rolUsuario = Item("rolUsuario")
                list.Add(newObj)
            Next

            Return list

        Else
            Return Nothing
        End If
    End Function

    Public Function ListarObjeto(Objeto As RolBE) As RolBE Implements IABMC(Of RolBE).ListarObjeto
        Dim oDatos As New DAL.Datos
        Dim hdatos As New Hashtable
        Dim DS As New DataSet
        Dim newObj As New BE.RolBE

        hdatos.Add("@tipoConsulta", 5)
        hdatos.Add("@idRol", Objeto.idRol)
        hdatos.Add("@descripcion", DBNull.Value)
        hdatos.Add("@activo", DBNull.Value)
        hdatos.Add("@rolUsuario", DBNull.Value)


        DS = oDatos.Leer("s_Rol_ABMC", hdatos)

        If DS.Tables(0).Rows.Count > 0 Then

            For Each Item As DataRow In DS.Tables(0).Rows
                newObj = New BE.RolBE
                newObj.idRol = Item("idRol")
                newObj.descr = Item("descripcion")
                newObj.activo = Item("activo")
                newObj.rolUsuario = Item("rolUsuario")
            Next

            newObj.listPermisos = PermisoMPP.ObtenerInstancia.ListarPermisosxRol(newObj)

            Return newObj
        Else
            Return Nothing
        End If
    End Function

    Public Function Agregar_Rol_Permiso(id_rol As Integer, lista_permisos As List(Of PermisosBE)) As String
        Dim oDatos As New DAL.Datos

        Dim resultado As Boolean
        Dim r As Integer = 0

        For Each oPermiso In lista_permisos
            Dim hdatos As New Hashtable
            hdatos.Add("@tipoConsulta", 1)
            hdatos.Add("@idRol", id_rol)
            hdatos.Add("@idPermiso", oPermiso.idPermiso)

            resultado = oDatos.Escribir("s_Rol_Permisos_ABMC", hdatos)

            r += 1
        Next

        Dim mensaje As String = "Se agregaron " & r.ToString & " roles al usuario."
        Return mensaje
    End Function

    Public Function Eliminar_Rol_Permiso(id_rol As Integer, lista_permisos As List(Of PermisosBE)) As String
        Dim oDatos As New DAL.Datos

        Dim resultado As Boolean
        Dim r As Integer = 0

        For Each oPermiso In lista_permisos
            Dim hdatos As New Hashtable
            hdatos.Add("@tipoConsulta", 2)
            hdatos.Add("@idRol", id_rol)
            hdatos.Add("@idPermiso", oPermiso.idPermiso)

            resultado = oDatos.Escribir("s_Rol_Permisos_ABMC", hdatos)

            r += 1
        Next

        Dim mensaje As String = "Se agregaron " & r.ToString & " roles al usuario."
        Return mensaje
    End Function

    Public Function ObtenerRolesUsuario() As List(Of RolBE)
        Try
            Dim oDatos As New DAL.Datos
            Dim DS As New DataSet
            Dim list As New List(Of BE.RolBE)
            Dim dt As New DataTable
            Dim newObj As BE.RolBE

            Dim hdatos As New Hashtable

            DS = oDatos.Leer("s_Rol_GetRolesUsuario", hdatos)

            If DS.Tables(0).Rows.Count > 0 Then

                For Each Item As DataRow In DS.Tables(0).Rows
                    newObj = New BE.RolBE
                    newObj.idRol = Item("idRol")
                    newObj.descr = Item("descripcion")
                    newObj.activo = Item("activo")
                    newObj.rolUsuario = Item("rolUsuario")
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
