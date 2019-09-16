Imports BE
Imports MPP

Public Class CategoriaBLL
    Implements IABMC(Of CategoriaBE)

    Private Shared Instancia As CategoriaBLL
    Public Shared Function ObtenerInstancia() As CategoriaBLL
        If Instancia Is Nothing Then
            Instancia = New CategoriaBLL
        End If
        Return Instancia
    End Function

    Public Function Alta(Objeto As CategoriaBE) As Boolean Implements IABMC(Of CategoriaBE).Alta
        Try
            Return CategoriaMPP.ObtenerInstancia.Alta(Objeto)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Baja(Objeto As CategoriaBE) As Boolean Implements IABMC(Of CategoriaBE).Baja
        Try
            Return CategoriaMPP.ObtenerInstancia.Baja(Objeto)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Modificacion(Objeto As CategoriaBE) As Boolean Implements IABMC(Of CategoriaBE).Modificacion
        Try
            Return CategoriaMPP.ObtenerInstancia.Modificacion(Objeto)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function ListarObjetos() As IEnumerable(Of CategoriaBE) Implements IABMC(Of CategoriaBE).ListarObjetos
        Try
            Return CategoriaMPP.ObtenerInstancia.ListarObjetos()
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function ListarObjeto(Objeto As CategoriaBE) As CategoriaBE Implements IABMC(Of CategoriaBE).ListarObjeto
        Try
            Return CategoriaMPP.ObtenerInstancia.ListarObjeto(Objeto)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
