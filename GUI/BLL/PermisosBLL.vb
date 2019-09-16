Imports MPP
Imports BE

Public Class PermisosBLL

    Private Shared Instancia As PermisosBLL
    Public Shared Function ObtenerInstancia() As PermisosBLL
        If Instancia Is Nothing Then
            Instancia = New PermisosBLL
        End If
        Return Instancia
    End Function

    Public Function Listar_Permisos_Segun_Rol(Rol As RolBE) As List(Of PermisosBE)
        Return PermisoMPP.ObtenerInstancia.ListarPermisosxRol(Rol)
    End Function

    Public Function Listar_Permisos_Disponibles(oRol As RolBE) As List(Of PermisosBE)
        Try
            Dim lista_Permisos_Actuales = oRol.listPermisos
            Dim lista_Permisos As New List(Of PermisosBE)
            lista_Permisos = PermisoMPP.ObtenerInstancia.ListarObjetos

            Dim resultado As New List(Of PermisosBE)
            Try
                resultado = (From permMaestro In lista_Permisos
                             Where Not (From permActual In lista_Permisos_Actuales
                                        Select permActual.idPermiso).Contains(permMaestro.idPermiso)
                             Select permMaestro).ToList
            Catch ex As Exception
                resultado = lista_Permisos
            End Try

            Return resultado
        Catch ex As Exception
            Return Nothing
        End Try

    End Function

End Class
