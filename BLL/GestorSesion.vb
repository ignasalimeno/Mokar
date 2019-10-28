Imports BE

Public Class GestorSesion
#Region "Singleton"
    Private Sub New()
    End Sub
    'lo pongo private para que no se acceda desde otra clase y sirva el Singleton.
    Private Shared Instancia As GestorSesion
    Public Shared Function ObtenerSesionActual() As GestorSesion
        If Instancia Is Nothing Then
            Instancia = New GestorSesion
        End If
        Return Instancia
    End Function
#End Region

    Property UsuarioActivo As UsuarioBE

    Public Function IniciarSesion(ByVal usuario As UsuarioBE) As Boolean
        Dim r As Boolean = False
        Dim UsuarioEncontrado As UsuarioBE = UsuarioBLL.ObtenerInstancia().ValidarUsuario(usuario)
        'Valida formato y (User y Pass) y lo trae de la BD.
        If UsuarioEncontrado.activo = False Then
            r = False
        Else
            If UsuarioEncontrado IsNot Nothing Then
                Me.UsuarioActivo = UsuarioEncontrado
                UsuarioActivo = UsuarioBLL.ObtenerInstancia.ObtenerRolesYPermisosUsuario(UsuarioActivo)
                r = True
            Else
                r = False
            End If
        End If
        Return r
    End Function

    'Public Function IniciarSesion2(ByVal cliente As Cliente_BE) As Boolean
    '    Dim r As Boolean = False
    '    Dim ClienteEncontrado As Cliente_BE = GestorClientes.ObtenerInstancia().ValidarCliente(cliente)
    '    'Valida formato y (User y Pass) y lo trae de la BD.
    '    If ClienteEncontrado.Activo = False Then
    '        r = False
    '    Else
    '        If ClienteEncontrado IsNot Nothing Then
    '            ClienteActivo = ClienteEncontrado
    '            ClienteActivo.Roles = GestorClientes.ObtenerInstancia.Asignar_Roles_Y_Permisos2(ClienteActivo.ID)
    '            r = True
    '        End If
    '    End If
    '    Return r
    'End Function


    Public Sub CerrarSesion()
        UsuarioActivo = Nothing

    End Sub


    'Public Property ListaForm As New List(Of Evento_Bitacora_BE)
    'Public Sub Registrar(o)
    '    ListaForm.Add(o)
    'End Sub

    'Public Sub Remover(o)
    '    ListaForm.Remove(o)
    'End Sub

    Public Function ValidarAcceso(ByVal usuarioActivo As UsuarioBE, ByVal NombreContent As String) As Boolean
        Dim rst As Boolean = False
        'For Each perm As Permisos_BE In UsuarioBLL.ObtenerInstancia.ObtenerPermisosDeUsuario(usuarioActivo)
        'If perm.Formulario.Equals(NombreContent, StringComparison.OrdinalIgnoreCase) Then
        rst = True
        '    End If
        'Next
        Return rst
    End Function
End Class
