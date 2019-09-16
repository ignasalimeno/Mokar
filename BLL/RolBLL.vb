Imports BE
Imports MPP

Public Class RolBLL
    Implements BLL.IABMC(Of RolBE)

    Dim oMapper As New RolMPP


    Private Shared Instancia As RolBLL
    Public Shared Function ObtenerInstancia() As RolBLL
        If Instancia Is Nothing Then
            Instancia = New RolBLL
        End If
        Return Instancia
    End Function

    Public Function Alta(Objeto As RolBE) As Boolean Implements IABMC(Of RolBE).Alta
        Dim resultado As Boolean
        resultado = oMapper.Alta(Objeto)
        Return resultado
    End Function

    Public Function Baja(Objeto As RolBE) As Boolean Implements IABMC(Of RolBE).Baja
        Dim resultado As Boolean

        resultado = oMapper.Baja(Objeto)

        Return resultado
    End Function

    Public Function Modificacion(Objeto As RolBE) As Boolean Implements IABMC(Of RolBE).Modificacion
        Dim resultado As Boolean

        resultado = oMapper.Modificacion(Objeto)

        Return resultado
    End Function

    Public Function ListarObjetos() As IEnumerable(Of RolBE) Implements IABMC(Of RolBE).ListarObjetos
        Try
            Return oMapper.ListarObjetos()
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function ListarObjeto(Objeto As RolBE) As RolBE Implements IABMC(Of RolBE).ListarObjeto
        Dim resultado As New RolBE

        resultado = oMapper.ListarObjeto(Objeto)

        Return resultado
    End Function

    Public Function Listar_Roles_Disponibles(oUsuario As UsuarioBE) As List(Of RolBE)
        Dim lista_Roles_Actuales = oUsuario.roles
        Dim lista_Roles As New List(Of RolBE)
        lista_Roles = ListarObjetos()

        Dim resultado = (From RolMaestro In lista_Roles
                         Where Not (From RolActual In lista_Roles_Actuales
                                    Select RolActual.idRol).Contains(RolMaestro.idRol)
                         Select RolMaestro).ToList

        'Return lista_Roles
        Return resultado
    End Function

    Public Function Listar_Roles() As List(Of RolBE)
        Return RolMPP.ObtenerInstancia.ListarObjetos
    End Function

    Public Function Agregar_Rol_Permiso(idRol As Integer, permisos As List(Of PermisosBE)) As String
        Dim mensaje As String = oMapper.Agregar_Rol_Permiso(idRol, permisos)
        Return mensaje
    End Function

    Public Function Eliminar_Rol_Permiso(idRol As Integer, permisos As List(Of PermisosBE)) As String
        Dim mensaje As String = oMapper.Eliminar_Rol_Permiso(idRol, permisos)
        Return mensaje
    End Function

    Public Function ObtenerRolesUsuario() As IEnumerable(Of RolBE)
        Try
            Return oMapper.ObtenerRolesUsuario()
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

End Class
