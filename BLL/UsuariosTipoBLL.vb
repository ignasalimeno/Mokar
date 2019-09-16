Imports BE
Imports MPP

Public Class UsuariosTipoBLL
    Implements IABMC(Of UsuariosTipoBE)

    Private Shared Instancia As UsuariosTipoBLL
    Public Shared Function ObtenerInstancia() As UsuariosTipoBLL
        If Instancia Is Nothing Then
            Instancia = New UsuariosTipoBLL
        End If
        Return Instancia
    End Function

    Public Function Alta(Objeto As UsuariosTipoBE) As Boolean Implements IABMC(Of UsuariosTipoBE).Alta
        Try
            Return UsuariosTipoMPP.ObtenerInstancia.Alta(Objeto)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Baja(Objeto As UsuariosTipoBE) As Boolean Implements IABMC(Of UsuariosTipoBE).Baja
        Try
            Return UsuariosTipoMPP.ObtenerInstancia.Baja(Objeto)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Modificacion(Objeto As UsuariosTipoBE) As Boolean Implements IABMC(Of UsuariosTipoBE).Modificacion
        Try
            Return UsuariosTipoMPP.ObtenerInstancia.Modificacion(Objeto)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function ListarObjetos() As IEnumerable(Of UsuariosTipoBE) Implements IABMC(Of UsuariosTipoBE).ListarObjetos
        Try
            Return UsuariosTipoMPP.ObtenerInstancia.ListarObjetos()
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function ListarObjeto(Objeto As UsuariosTipoBE) As UsuariosTipoBE Implements IABMC(Of UsuariosTipoBE).ListarObjeto
        Try
            Return UsuariosTipoMPP.ObtenerInstancia.ListarObjeto(Objeto)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
