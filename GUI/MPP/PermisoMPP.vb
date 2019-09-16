Imports BE
Imports MPP

Public Class PermisoMPP
    Implements IABMC(Of PermisosBE)

    Private Shared Instancia As PermisoMPP
    Public Shared Function ObtenerInstancia() As PermisoMPP
        If Instancia Is Nothing Then
            Instancia = New PermisoMPP
        End If
        Return Instancia
    End Function

    Public Function Alta(Objeto As PermisosBE) As Boolean Implements IABMC(Of PermisosBE).Alta
        Throw New NotImplementedException()
    End Function

    Public Function Baja(Objeto As PermisosBE) As Boolean Implements IABMC(Of PermisosBE).Baja
        Throw New NotImplementedException()
    End Function

    Public Function Modificacion(Objeto As PermisosBE) As Boolean Implements IABMC(Of PermisosBE).Modificacion
        Throw New NotImplementedException()
    End Function

    Public Function ListarObjetos() As IEnumerable(Of PermisosBE) Implements IABMC(Of PermisosBE).ListarObjetos
        Dim oDatos As New DAL.Datos
        Dim DS As New DataSet
        Dim list As New List(Of BE.PermisosBE)
        Dim dt As New DataTable
        Dim newObj As BE.PermisosBE

        Dim hdatos As New Hashtable
        hdatos.Add("@tipoConsulta", 4)
        hdatos.Add("@idPermiso", DBNull.Value)

        DS = oDatos.Leer("s_Permisos_ABMC", hdatos)

        If DS.Tables(0).Rows.Count > 0 Then

            For Each Item As DataRow In DS.Tables(0).Rows
                newObj = New BE.PermisosBE
                newObj.idPermiso = Item("idPermiso")
                newObj.descr = Item("descr")
                newObj.formulario = Item("formulario")
                list.Add(newObj)
            Next

            Return list

        Else
            Return Nothing
        End If
    End Function

    Public Function ListarObjeto(Objeto As PermisosBE) As PermisosBE Implements IABMC(Of PermisosBE).ListarObjeto
        Throw New NotImplementedException()
    End Function

    Public Function ListarPermisosxRol(oRol As RolBE) As IEnumerable(Of PermisosBE)
        Dim oDatos As New DAL.Datos
        Dim DS As New DataSet
        Dim list As New List(Of BE.PermisosBE)
        Dim dt As New DataTable
        Dim newObj As BE.PermisosBE

        Dim hdatos As New Hashtable
        hdatos.Add("@idRol", oRol.idRol)

        DS = oDatos.Leer("s_Rol_GetPermisosxRol", hdatos)

        If DS.Tables(0).Rows.Count > 0 Then

            For Each Item As DataRow In DS.Tables(0).Rows
                newObj = New BE.PermisosBE
                newObj.idPermiso = Item("idPermiso")
                newObj.descr = Item("descr")
                newObj.formulario = Item("formulario")
                list.Add(newObj)
            Next

            Return list

        Else
            Return Nothing
        End If
    End Function
End Class
