Imports BE
Imports BLL

Public Class Usuarios_AsignarRoles
    Inherits System.Web.UI.Page


    Dim mensaje As String
    Dim usuario_logueado As UsuarioBE

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Cargar_Usuarios()
        End If
    End Sub


    Public Sub Cargar_Usuarios()
        DDL_Usuarios.Items.Clear()

        DDL_Usuarios.AppendDataBoundItems = True
        DDL_Usuarios.Items.Add("Seleccione Usuario")
        DDL_Usuarios.DataSource = Nothing
        DDL_Usuarios.DataSource = UsuarioBLL.ObtenerInstancia.ListarObjetos
        DDL_Usuarios.DataTextField = "mail"
        DDL_Usuarios.DataValueField = "idUsuario"
        DDL_Usuarios.DataBind()


        LB_RolesActuales.Items.Clear()
        LB_RolesDisponibles.Items.Clear()
    End Sub

    Private Sub DDL_Usuarios_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDL_Usuarios.SelectedIndexChanged
        Dim oUsuarioSeleccionado As New UsuarioBE

        Try
            If DDL_Usuarios.SelectedIndex > 0 Then
                oUsuarioSeleccionado.idUsuario = DDL_Usuarios.SelectedValue
                oUsuarioSeleccionado = UsuarioBLL.ObtenerInstancia.ListarObjeto(oUsuarioSeleccionado)
            End If
            Me.Actualizar_Roles_Actuales(oUsuarioSeleccionado.roles)
            Me.Actualizar_Roles_Disponibles(oUsuarioSeleccionado)
        Catch ex As Exception
            mensaje = "Mokar notifica: " & ex.Message
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & mensaje & "')", True)
        End Try
    End Sub


    Public Sub Actualizar_Roles_Disponibles(oUsuario As UsuarioBE)
        LB_RolesDisponibles.DataSource = Nothing
        LB_RolesDisponibles.DataSource = RolBLL.ObtenerInstancia.Listar_Roles_Disponibles(oUsuario)
        LB_RolesDisponibles.DataTextField = "descr"
        LB_RolesDisponibles.DataValueField = "idRol"
        LB_RolesDisponibles.DataBind()
        LB_RolesDisponibles.ClearSelection()

    End Sub

    Public Sub Actualizar_Roles_Actuales(oRoles As List(Of RolBE))
        LB_RolesActuales.DataSource = Nothing
        LB_RolesActuales.DataSource = oRoles
        LB_RolesActuales.DataTextField = "descr"
        LB_RolesActuales.DataValueField = "idRol"
        LB_RolesActuales.DataBind()
        LB_RolesActuales.ClearSelection()

    End Sub

    Private Sub btn_Agregar_Click(sender As Object, e As ImageClickEventArgs) Handles btn_Agregar.Click
        If LB_RolesDisponibles.SelectedItem IsNot Nothing Then
            LB_RolesActuales.Items.Add(New ListItem(LB_RolesDisponibles.SelectedItem.Text, LB_RolesDisponibles.SelectedItem.Value))
            LB_RolesDisponibles.Items.Remove(LB_RolesDisponibles.Items.FindByValue(LB_RolesDisponibles.SelectedItem.Value))
            btn_Guardar.Visible = True
        Else
        End If
    End Sub

    Private Sub btn_Quitar_Click(sender As Object, e As ImageClickEventArgs) Handles btn_Quitar.Click
        Dim User As New UsuarioBE
        User = GestorSesion.ObtenerSesionActual.UsuarioActivo

        Dim UsuarioRol As New UsuarioBE
        UsuarioRol = UsuarioBLL.ObtenerInstancia.ListarObjeto(User)
        If UsuarioRol.roles.Contains(New RolBE() With {.descr = "Administrador"}) Then
            mensaje = "No se puede eliminar el permiso de Aministrador desde el Front end, consulte al BDA"
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & mensaje & "')", True)

        ElseIf LB_RolesActuales.SelectedItem IsNot Nothing Then
            LB_RolesDisponibles.Items.Add(New ListItem(LB_RolesActuales.SelectedItem.Text, LB_RolesActuales.SelectedItem.Value))
            LB_RolesActuales.Items.Remove(LB_RolesActuales.Items.FindByValue(LB_RolesActuales.SelectedItem.Value))
            btn_Guardar.Visible = True
        End If
    End Sub

    Private Sub btn_Guardar_Click(sender As Object, e As EventArgs) Handles btn_Guardar.Click
        Try
            Dim nombre_usuario As String = DDL_Usuarios.Items(DDL_Usuarios.SelectedIndex).Text
            Dim id_usuario As Integer = DDL_Usuarios.Items(DDL_Usuarios.SelectedIndex).Value

            Dim lista_roles_actuales As New List(Of RolBE)

            For Each item As ListItem In LB_RolesActuales.Items
                lista_roles_actuales.Add(New RolBE With {.idRol = item.Value})
            Next

            UsuarioBLL.ObtenerInstancia.Agregar_Usuario_Rol(id_usuario, lista_roles_actuales)

            Dim UsuarioRol As New UsuarioBE
            UsuarioRol.idUsuario = id_usuario
            UsuarioRol = UsuarioBLL.ObtenerInstancia.ListarObjeto(UsuarioRol)

            Dim lista_permisos_disponibles As New List(Of RolBE)
            For Each item As ListItem In LB_RolesDisponibles.Items
                lista_permisos_disponibles.Add(New RolBE With {.idRol = item.Value})
            Next

            If UsuarioRol.roles.Contains(New RolBE() With {.descr = "Administrador"}) And lista_permisos_disponibles.Contains(New RolBE() With {.descr = "Administrador"}) Then
                mensaje = "No se puede eliminar el permiso de Aministrador desde el Front end, consulte al BDA"
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & mensaje & "')", True)
                Exit Sub

            Else
                UsuarioBLL.ObtenerInstancia.Quitar_Usuario_Rol(id_usuario, lista_permisos_disponibles)
                mensaje = "Se actualizaron los roles"
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & mensaje & "')", True)
            End If

            btn_Guardar.Visible = False
            Cargar_Usuarios()
            usuario_logueado = Session("usuario")
            Response.Redirect("Usuarios_AsignarRoles.aspx", False)

        Catch ex As Exception
            mensaje = "Mokar notifica: " & ex.Message
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & mensaje & "')", True)
        End Try
    End Sub

End Class