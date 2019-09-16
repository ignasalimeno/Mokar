Public Class RolBE
    Property idRol As Integer
    Property descr As String
    Property activo As Boolean
    Property listPermisos As New List(Of PermisosBE)
    Property rolUsuario As Boolean
End Class
