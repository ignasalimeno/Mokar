Public Class UsuarioBE
    Property idUsuario As Integer
    Property mail As String
    Property nombreRazonSocial As String
    Property tipoUsuario As Integer
    Property contraseña As String
    Property activo As Boolean
    Property roles As New List(Of RolBE)
    Property tipoUsuarioDescr As String
End Class
