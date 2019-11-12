Imports BE
Imports BLL

Public Class Rol_Permisos
    Inherits System.Web.UI.Page

    Dim mensaje As String
    Dim usuario_logueado As UsuarioBE

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Cargar_Roles()
            usuario_logueado = Session("usuario")
        End If
    End Sub

    Public Sub Cargar_Roles()
        Try
            DDL_Roles.Items.Clear()
            DDL_Roles.AppendDataBoundItems = True
            DDL_Roles.Items.Add("Seleccione Rol")
            DDL_Roles.DataSource = Nothing
            DDL_Roles.DataSource = RolBLL.ObtenerInstancia.Listar_Roles
            DDL_Roles.DataTextField = "descr"
            DDL_Roles.DataValueField = "idRol"
            DDL_Roles.DataBind()

            LB_PermisosActuales.Items.Clear()
            LB_PermisosDisponibles.Items.Clear()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DDL_Roles_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDL_Roles.SelectedIndexChanged
        Dim oRolSeleccionado As New RolBE
        Try
            oRolSeleccionado.idRol = DDL_Roles.SelectedItem.Value
            If DDL_Roles.SelectedIndex > 0 Then
                oRolSeleccionado = RolBLL.ObtenerInstancia.ListarObjeto(oRolSeleccionado)
            Else

            End If
            Me.Actualizar_Permisos_Actuales(oRolSeleccionado)
            Me.Actualizar_Permisos_Disponibles(oRolSeleccionado)

        Catch ex As Exception

        End Try
    End Sub

    Public Sub Actualizar_Permisos_Actuales(oRolSeleccionado As RolBE)
        Try
            LB_PermisosActuales.DataSource = Nothing
            Dim listPermisos As List(Of PermisosBE) = oRolSeleccionado.listPermisos
            If Not listPermisos Is Nothing Then
                LB_PermisosActuales.DataSource = listPermisos
                LB_PermisosActuales.DataTextField = "descr"
                LB_PermisosActuales.DataValueField = "idPermiso"
            Else
                LB_PermisosActuales.Items.Clear()
            End If
            LB_PermisosActuales.DataBind()
            LB_PermisosActuales.ClearSelection()
        Catch ex As Exception

        End Try


    End Sub

    Protected Sub Actualizar_Permisos_Disponibles(oRol As RolBE)
        Try
            LB_PermisosDisponibles.DataSource = Nothing
            Dim lstPermisos As List(Of PermisosBE) = PermisosBLL.ObtenerInstancia.Listar_Permisos_Disponibles(oRol)

            If Not lstPermisos Is Nothing Then
                LB_PermisosDisponibles.DataSource = lstPermisos
                LB_PermisosDisponibles.DataTextField = "descr"
                LB_PermisosDisponibles.DataValueField = "idPermiso"
            End If

            LB_PermisosDisponibles.DataBind()
            LB_PermisosActuales.ClearSelection()
        Catch ex As Exception

        End Try


    End Sub

    Private Sub btn_Guardar_Click(sender As Object, e As EventArgs) Handles btn_Guardar.Click
        Try
            If DDL_Roles.SelectedIndex = 0 Then
                Throw New Exception("Seleccione un rol")
            End If
            usuario_logueado = GestorSesion.ObtenerSesionActual.UsuarioActivo

            Dim id_rol As Integer = DDL_Roles.Items(DDL_Roles.SelectedIndex).Value
            Dim nombre_rol As String = DDL_Roles.Items(DDL_Roles.SelectedIndex).Text

            Dim lista_permisos_actuales As New List(Of PermisosBE)

            For Each item As ListItem In LB_PermisosActuales.Items
                lista_permisos_actuales.Add(New PermisosBE With {.idPermiso = item.Value})
            Next

            RolBLL.ObtenerInstancia.Agregar_Rol_Permiso(id_rol, lista_permisos_actuales)


            Dim lista_permisos_disponibles As New List(Of PermisosBE)

            For Each item As ListItem In LB_PermisosDisponibles.Items
                lista_permisos_disponibles.Add(New PermisosBE With {.idPermiso = item.Value})
            Next

            RolBLL.ObtenerInstancia.Eliminar_Rol_Permiso(id_rol, lista_permisos_disponibles)

            mensaje = "Los permisos se agregaron con exito"
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & mensaje & "')", True)

            'Dim bitacora As New LogBE With {.FechaHora = DateTime.Now,
            '                                        .ID_Evento = "9",
            '                                        .Usuario = GestorSesionActual.ObtenerSesionActual.pUsuarioActivo,
            '                                        .Observaciones = "El usuario modificó un rol",
            '                                        .criticidad = "2"}
            'GestorBitacora.ObtenerInstancia.Agregar(bitacora)

            Verificar_Rol_Modificado_Usuario_Actual1(id_rol, usuario_logueado)

            Cargar_Roles()

            Response.Redirect("Rol_AsignarPermisos.aspx", False)
        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & ex.Message & "')", True)

        End Try


    End Sub

    Public Sub Verificar_Rol_Modificado_Usuario_Actual1(id_rol As Integer, usuario As UsuarioBE)
        For Each oRol In usuario.roles
            If oRol.idRol = id_rol Then

                mensaje = "Se modificó un rol propio. Debe volver a ingresar"
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & mensaje & "')", True)

                GestorSesion.ObtenerSesionActual.CerrarSesion()
                Session.Clear()
                Response.Redirect("Index.aspx")
                Exit For
            End If
        Next
    End Sub

    Private Sub btn_Agregar_Click(sender As Object, e As ImageClickEventArgs) Handles btn_Agregar.Click
        Try
            If LB_PermisosDisponibles.SelectedItem IsNot Nothing Then
                LB_PermisosActuales.Items.Add(New ListItem(LB_PermisosDisponibles.SelectedItem.Text, LB_PermisosDisponibles.SelectedItem.Value))
                LB_PermisosDisponibles.Items.Remove(LB_PermisosDisponibles.Items.FindByValue(LB_PermisosDisponibles.SelectedItem.Value))
            Else

            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btn_Quitar_Click(sender As Object, e As ImageClickEventArgs) Handles btn_Quitar.Click
        Try
            If LB_PermisosActuales.SelectedItem IsNot Nothing Then
                LB_PermisosDisponibles.Items.Add(New ListItem(LB_PermisosActuales.SelectedItem.Text, LB_PermisosActuales.SelectedItem.Value))
                LB_PermisosActuales.Items.Remove(LB_PermisosActuales.Items.FindByValue(LB_PermisosActuales.SelectedItem.Value))
            Else

            End If
        Catch ex As Exception

        End Try

    End Sub

End Class