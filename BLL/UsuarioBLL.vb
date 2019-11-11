Imports System.Text.RegularExpressions
Imports BE
Imports BLL

Public Class UsuarioBLL
    Implements BLL.IABMC(Of BE.UsuarioBE)

    Sub New()

    End Sub


    Private Shared Instancia As UsuarioBLL
    Public Shared Function ObtenerInstancia() As UsuarioBLL
        If Instancia Is Nothing Then
            Instancia = New UsuarioBLL
        End If
        Return Instancia
    End Function

    Dim oMapper As New MPP.UsuarioMPP


    Public Function Alta(Objeto As UsuarioBE) As Boolean Implements IABMC(Of UsuarioBE).Alta
        Dim resultado As Boolean
        Objeto.contraseña = Criptografia.ObtenerInstancia.EncriptarHashMD5(Objeto.contraseña)
        resultado = oMapper.Alta(Objeto)

        Return resultado
    End Function

    Public Function Baja(Objeto As UsuarioBE) As Boolean Implements IABMC(Of UsuarioBE).Baja
        Dim resultado As Boolean

        resultado = oMapper.Baja(Objeto)

        Return resultado
    End Function

    Public Function Modificacion(Objeto As UsuarioBE) As Boolean Implements IABMC(Of UsuarioBE).Modificacion

        Dim resultado As Boolean

        resultado = oMapper.Modificacion(Objeto)

        Return resultado
    End Function

    Public Function ListarObjetos() As IEnumerable(Of UsuarioBE) Implements IABMC(Of UsuarioBE).ListarObjetos
        Dim listReturn As New List(Of BE.UsuarioBE)

        listReturn = oMapper.ListarObjetos()

        Return listReturn
    End Function

    Public Function ListarObjeto(Objeto As UsuarioBE) As UsuarioBE Implements IABMC(Of UsuarioBE).ListarObjeto
        Dim resultado As New UsuarioBE

        resultado = oMapper.ListarObjeto(Objeto)

        Return resultado
    End Function

    Public Function ListarObjetoPorMail(Objeto As UsuarioBE) As UsuarioBE
        Dim resultado As New UsuarioBE

        resultado = oMapper.ListarObjetoPorMail(Objeto)

        Return resultado
    End Function

    Public Function VerificarExisteUsuario(usuario As String) As Boolean
        Dim miUsuario As New UsuarioBE With {.mail = usuario}

        If oMapper.ListarObjetoPorMail(miUsuario) Is Nothing Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Sub AltaValidada(ByVal Usuario As UsuarioBE)
        Try
            oMapper.ModificarEstado(Usuario)
        Catch ex As Exception

        End Try
    End Sub

    Public Function ValidarUsuario(ByVal UserIngresado As UsuarioBE) As UsuarioBE
        Dim userBD As UsuarioBE = Nothing
        'userBD = Me.ObtenerPorNombre(UserIngresado.Usuario) ' para saltear la validación estando en desarrollo, no va en versión final.
        If Me.ValidarFormatoUser(UserIngresado) Then
            userBD = UsuarioBLL.ObtenerInstancia().ListarObjetoPorMail(UserIngresado)
            'valido si existe el usuario y la pass en mi bd
            If Not (userBD.mail = UserIngresado.mail AndAlso Me.ValidarContraseña(userBD.contraseña, UserIngresado.contraseña)) Then
                userBD = Nothing
            End If
        End If
        Return userBD
        Throw New Exception("El nombre de usuario debe ser una dirección de email válida y la Contraseña deben ser alfanumericos de 6 a 15 caracteres")
    End Function

    Private Function ValidarFormatoUser(ByVal _usuario As UsuarioBE) As Boolean
        Dim reg As New Regex("^[_a-z0-9-]+(.[_a-z0-9-]+)*@[a-z0-9-]+(.[a-z0-9-]+)*(.[a-z]{2,4})$")
        'Dim regPass As New Regex("^[A-Za-z0-9]{6,15}")
        Dim result As Boolean = False
        If Not (String.IsNullOrWhiteSpace(_usuario.mail) AndAlso String.IsNullOrWhiteSpace(_usuario.contraseña)) Then
            'result = IIf(reg.IsMatch(_usuario.mail) AndAlso regPass.IsMatch(_usuario.contraseña), True, False)
            result = IIf(reg.IsMatch(_usuario.mail), True, False)
        End If
        Return result
        Throw New Exception("Mokar informa que ha ocurrido un error")
    End Function

    Private Function ValidarContraseña(ByVal PassUserBD As String, ByVal PassUserIngresado As String) As Boolean
        'funcion para comparar la contraseña ingresada vs la de la BD, ambas encriptadas.
        Return IIf(Criptografia.ObtenerInstancia.CompararHashMD5(PassUserBD, Criptografia.ObtenerInstancia.EncriptarHashMD5(PassUserIngresado)), True, False)
        Throw New Exception("Mokar informa que ha ocurrido un error")
    End Function

    Public Sub ActualizarPass(ByVal Usuario As UsuarioBE)
        Try
            If Me.ValidarFormatoPass1(Usuario) Then
                Usuario.contraseña = Criptografia.ObtenerInstancia.EncriptarHashMD5(Usuario.contraseña)
                oMapper.ModificacionPass(Usuario)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Function ObtenerRolesYPermisosUsuario(_user As UsuarioBE) As UsuarioBE
        Try

            Dim newUser As UsuarioBE = oMapper.ObtenerRolesYPermisosUsuario(_user)

            If newUser Is Nothing Then
                _user.roles.Add(New RolBE With {.idRol = 99, .descr = "Default", .rolUsuario = False, .activo = True})
                Return _user
            Else
                Return newUser
            End If

        Catch ex As Exception
            Return _user
        End Try
    End Function

    Private Function ValidarFormatoPass1(ByVal _usuario As UsuarioBE) As Boolean
        Dim reg As New Regex("^[A-Za-z0-9]{6,15}")
        Dim result As Boolean = False
        If Not (String.IsNullOrWhiteSpace(_usuario.contraseña)) Then
            result = If(reg.IsMatch(_usuario.contraseña), True, False)
        End If
        Return result
        Throw New Exception("Mokar informa que ha ocurrido un error")
    End Function

    Public Function Agregar_Usuario_Rol(idUsuario As Integer, roles As List(Of RolBE)) As String
        Dim mensaje As String = oMapper.Agregar_Usuario_Rol(idUsuario, roles)
        Return mensaje
    End Function

    Public Function Quitar_Usuario_Rol(idUsuario As Integer, roles As List(Of RolBE)) As String
        Dim mensaje As String = oMapper.Quitar_Usuario_Rol(idUsuario, roles)
        Return mensaje
    End Function

    Function ValidarAcceso(user As UsuarioBE, ruta As String) As Boolean
        Try
            Dim tieneAcceso As Boolean = False
            Dim listPermisos As List(Of PermisosBE) = PermisosBLL.ObtenerInstancia.ListarTodosLosPermisos

            Dim rutaConPermiso As Boolean = False
            For Each a As PermisosBE In listPermisos
                If a.formulario.ToLower = ruta.ToLower Then
                    rutaConPermiso = True
                End If
            Next

            If user Is Nothing Then
                If rutaConPermiso = False Then
                    Return True
                Else
                    Return False
                End If
            End If

            user = ObtenerRolesYPermisosUsuario(user)
            If rutaConPermiso Then
                For Each a As RolBE In user.roles
                    For Each k As PermisosBE In a.listPermisos
                        If k.formulario = ruta Then
                            tieneAcceso = True
                        End If
                    Next
                Next
            Else
                tieneAcceso = True
            End If

            Return tieneAcceso
        Catch ex As Exception
            Return False
        End Try
    End Function

End Class
