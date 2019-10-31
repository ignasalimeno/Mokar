Imports BE
Imports MPP

Public Class UsuarioMPP
    Implements IABMC(Of BE.UsuarioBE)

    Public Function Alta(Objeto As UsuarioBE) As Boolean Implements IABMC(Of UsuarioBE).Alta
        Dim oDatos As New DAL.Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean

        hdatos.Add("@tipoConsulta", 1)
        hdatos.Add("@idUsuario", 1)
        hdatos.Add("@nombre", Objeto.nombreRazonSocial)
        hdatos.Add("@tipo", Objeto.tipoUsuario)
        hdatos.Add("@mail", Objeto.mail)
        hdatos.Add("@contraseña", Objeto.contraseña)
        hdatos.Add("@activo", "0")

        resultado = oDatos.Escribir("s_Usuarios_ABMC", hdatos)

        Return resultado
    End Function

    Public Function Baja(Objeto As UsuarioBE) As Boolean Implements IABMC(Of UsuarioBE).Baja
        Dim oDatos As New DAL.Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean

        hdatos.Add("@tipoConsulta", 2)
        hdatos.Add("@IdUsuario", Objeto.idUsuario)

        hdatos.Add("@nombre", DBNull.Value)
        hdatos.Add("@tipo", DBNull.Value)
        hdatos.Add("@mail", DBNull.Value)
        hdatos.Add("@contraseña", DBNull.Value)
        hdatos.Add("@activo", DBNull.Value)


        resultado = oDatos.Escribir("s_Usuarios_ABMC", hdatos)

        Return resultado
    End Function

    Public Function Modificacion(Objeto As UsuarioBE) As Boolean Implements IABMC(Of UsuarioBE).Modificacion
        Dim oDatos As New DAL.Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean

        hdatos.Add("@tipoConsulta", 3)
        hdatos.Add("@idUsuario", Objeto.idUsuario)
        hdatos.Add("@nombre", Objeto.nombreRazonSocial)
        hdatos.Add("@tipo", Objeto.tipoUsuario)
        hdatos.Add("@mail", Objeto.mail)
        hdatos.Add("@contraseña", DBNull.Value)
        hdatos.Add("@activo", DBNull.Value)

        resultado = oDatos.Escribir("s_Usuarios_ABMC", hdatos)

        Return resultado
    End Function

    Public Function ModificacionPass(Objeto As UsuarioBE) As Boolean
        Dim oDatos As New DAL.Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean

        hdatos.Add("@tipoConsulta", 3)
        hdatos.Add("@idUsuario", Objeto.idUsuario)
        hdatos.Add("@nombre", Objeto.nombreRazonSocial)
        hdatos.Add("@tipo", Objeto.tipoUsuario)
        hdatos.Add("@mail", Objeto.mail)
        hdatos.Add("@contraseña", Objeto.contraseña)
        hdatos.Add("@activo", "0")

        resultado = oDatos.Escribir("s_Usuarios_ABMC", hdatos)

        Return resultado
    End Function

    Public Function ListarObjetos() As IEnumerable(Of UsuarioBE) Implements IABMC(Of UsuarioBE).ListarObjetos
        Dim oDatos As New DAL.Datos
        Dim DS As New DataSet
        Dim list As New List(Of BE.UsuarioBE)
        Dim dt As New DataTable
        Dim newObj As BE.UsuarioBE

        Dim hdatos As New Hashtable
        hdatos.Add("@tipoConsulta", 4)
        hdatos.Add("@IdUsuario", DBNull.Value)
        hdatos.Add("@nombre", DBNull.Value)
        hdatos.Add("@tipo", DBNull.Value)
        hdatos.Add("@mail", DBNull.Value)
        hdatos.Add("@contraseña", DBNull.Value)
        hdatos.Add("@activo", DBNull.Value)

        DS = oDatos.Leer("s_Usuarios_ABMC", hdatos)

        If DS.Tables(0).Rows.Count > 0 Then

            For Each Item As DataRow In DS.Tables(0).Rows
                newObj = New BE.UsuarioBE
                newObj.idUsuario = Item("IdUsuario")
                newObj.nombreRazonSocial = Item("nombreRazonSocial")
                newObj.tipoUsuario = Item("tipoUsuario")
                newObj.mail = Item("mail")
                newObj.activo = Item("activo")
                newObj.tipoUsuarioDescr = Item("tipoUsuarioDescr")
                list.Add(newObj)
            Next

            Return list

        Else
            Return Nothing
        End If
    End Function

    Public Function ListarObjeto(Objeto As UsuarioBE) As UsuarioBE Implements IABMC(Of UsuarioBE).ListarObjeto
        Dim oDatos As New DAL.Datos
        Dim hdatos As New Hashtable
        Dim DS As New DataSet
        Dim newObj As New BE.UsuarioBE

        hdatos.Add("@tipoConsulta", 5)
        hdatos.Add("@IdUsuario", Objeto.idUsuario)
        hdatos.Add("@nombre", DBNull.Value)
        hdatos.Add("@tipo", DBNull.Value)
        hdatos.Add("@mail", DBNull.Value)
        hdatos.Add("@contraseña", DBNull.Value)
        hdatos.Add("@activo", DBNull.Value)
        '   If DS.Tables(0).Rows.Count > 0 Then

        DS = oDatos.Leer("s_Usuarios_ABMC", hdatos)

        If DS.Tables(0).Rows.Count > 0 Then

            For Each Item As DataRow In DS.Tables(0).Rows
                newObj = New BE.UsuarioBE
                newObj.idUsuario = Item("IdUsuario")
                newObj.nombreRazonSocial = Item("nombreRazonSocial")
                newObj.tipoUsuario = Item("tipoUsuario")
                newObj.contraseña = Item("contraseña")
                newObj.mail = Item("mail")
                newObj.activo = Item("activo")
                newObj.tipoUsuarioDescr = Item("tipoUsuarioDescr")
            Next

            'newObj = ObtenerRolesYPermisosUsuario(newObj)
            Dim newObjRol As UsuarioBE = ObtenerRolesYPermisosUsuario(newObj)
            If newObjRol Is Nothing Then
                newObj.roles.Add(New RolBE With {.idRol = 99, .descr = "Default", .rolUsuario = False, .activo = True})
            Else
                newObj = newObjRol
            End If
            Return newObj
        Else
            Return Nothing
        End If
    End Function

    Public Function ListarObjetoPorMail(Objeto As UsuarioBE) As UsuarioBE
        Dim oDatos As New DAL.Datos
        Dim hdatos As New Hashtable
        Dim DS As New DataSet
        Dim newObj As New BE.UsuarioBE

        hdatos.Add("@tipoConsulta", 6)
        hdatos.Add("@IdUsuario", DBNull.Value)
        hdatos.Add("@nombre", DBNull.Value)
        hdatos.Add("@tipo", DBNull.Value)
        hdatos.Add("@mail", Objeto.mail)
        hdatos.Add("@contraseña", DBNull.Value)
        hdatos.Add("@activo", DBNull.Value)
        '   If DS.Tables(0).Rows.Count > 0 Then

        DS = oDatos.Leer("s_Usuarios_ABMC", hdatos)

        If DS.Tables(0).Rows.Count > 0 Then

            For Each Item As DataRow In DS.Tables(0).Rows
                newObj = New BE.UsuarioBE
                newObj.idUsuario = Item("IdUsuario")
                newObj.nombreRazonSocial = Item("nombreRazonSocial")
                newObj.tipoUsuario = Item("tipoUsuario")
                newObj.contraseña = Item("contraseña")
                newObj.mail = Item("mail")
                newObj.activo = Item("activo")
                newObj.tipoUsuarioDescr = Item("tipoUsuarioDescr")
            Next
            Return newObj
        Else
            Return Nothing
        End If
    End Function

    Public Function ObtenerUsuario2(ByVal _usuario As String) As UsuarioBE
        'listo todos los usuarios y selecciono por mail.
        Try
            Dim ls As List(Of UsuarioBE) = Me.ListarObjetos()
            Dim usuarioxmail As UsuarioBE = ls.Find(Function(x) x.mail = _usuario)
            Return usuarioxmail
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function ModificarEstado(ByVal Usuario As UsuarioBE) As Integer
        Dim oDatos As New DAL.Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean

        hdatos.Add("@tipoConsulta", 3)
        hdatos.Add("@IdUsuario", Usuario.idUsuario)
        hdatos.Add("@nombre", Usuario.nombreRazonSocial)
        hdatos.Add("@tipo", Usuario.tipoUsuario)
        hdatos.Add("@mail", Usuario.mail)
        hdatos.Add("@contraseña", Usuario.contraseña)
        hdatos.Add("@activo", "1")
        resultado = oDatos.Escribir("s_Usuarios_ABMC", hdatos)

        Return resultado
    End Function

    Public Function ObtenerRolesYPermisosUsuario(_User As UsuarioBE) As UsuarioBE
        Try
            Dim oDatos As New DAL.Datos
            Dim DS As New DataSet

            Dim dt As New DataTable
            Dim newObj As BE.RolBE

            Dim hdatos As New Hashtable
            hdatos.Add("@idUsuario", _User.idUsuario)

            DS = oDatos.Leer("s_Usuarios_GetRolxUsuario", hdatos)

            If DS.Tables(0).Rows.Count > 0 Then

                For Each Item As DataRow In DS.Tables(0).Rows
                    ''Creo el rol
                    newObj = New BE.RolBE
                    newObj.idRol = Item("idRol")
                    newObj.descr = Item("descripcion")
                    newObj.activo = Item("activo")


                    ''asigno los permisos del rol
                    Dim hdatos1 As New Hashtable
                    hdatos1.Add("@idRol", Item("idRol"))
                    Dim dtPermisos As DataSet
                    dtPermisos = oDatos.Leer("s_Rol_GetPermisosxRol", hdatos1)

                    If dtPermisos.Tables(0).Rows.Count > 0 Then
                        For Each a As DataRow In dtPermisos.Tables(0).Rows
                            Dim newPermiso As New BE.PermisosBE
                            newPermiso.idPermiso = a("idPermiso")
                            newPermiso.descr = a("descr")
                            newPermiso.formulario = a("formulario")

                            newObj.listPermisos.Add(newPermiso)
                        Next
                    End If

                    'Agrego los roles al usuario
                    _User.roles.Add(newObj)
                Next

                Return _User
            Else
                Return Nothing
            End If

        Catch ex As Exception
            Return _User
        End Try
    End Function

    Public Function Agregar_Usuario_Rol(idUsuario As Integer, lista_roles As List(Of RolBE))
        Dim oDatos As New DAL.Datos

        Dim resultado As Boolean
        Dim r As Integer = 0

        For Each oRol In lista_roles
            Dim hdatos As New Hashtable
            hdatos.Add("@tipoConsulta", 1)
            hdatos.Add("@idUsuario", idUsuario)
            hdatos.Add("@idRol", oRol.idRol)

            resultado = oDatos.Escribir("s_Usuario_Rol_ABMC", hdatos)

            r += 1
        Next

        Dim mensaje As String = "Se agregaron " & r.ToString & " roles al usuario."
        Return mensaje

    End Function

    Public Function Quitar_Usuario_Rol(idUsuario As Integer, lista_roles As List(Of RolBE))
        Dim oDatos As New DAL.Datos
        Dim resultado As Boolean
        Dim r As Integer = 0

        For Each oRol In lista_roles
            Dim hdatos As New Hashtable
            hdatos.Add("@tipoConsulta", 2)
            hdatos.Add("@idUsuario", idUsuario)
            hdatos.Add("@idRol", oRol.idRol)

            resultado = oDatos.Escribir("s_Usuario_Rol_ABMC", hdatos)

            r += 1
        Next

        Dim mensaje As String = "Se eliminaron " & r.ToString & " roles al usuario."
        Return mensaje

    End Function

End Class
