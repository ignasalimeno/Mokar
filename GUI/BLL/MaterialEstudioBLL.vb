Imports BE
Imports MPP

Public Class MaterialEstudioBLL
    Implements IABMC(Of MaterialEstudioBE)

    Private Shared Instancia As MaterialEstudioBLL
    Public Shared Function ObtenerInstancia() As MaterialEstudioBLL
        If Instancia Is Nothing Then
            Instancia = New MaterialEstudioBLL
        End If
        Return Instancia
    End Function

    Public Function Alta(Objeto As MaterialEstudioBE) As Boolean Implements IABMC(Of MaterialEstudioBE).Alta
        Try
            Return MaterialEstudioMPP.ObtenerInstancia.Alta(Objeto)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Baja(Objeto As MaterialEstudioBE) As Boolean Implements IABMC(Of MaterialEstudioBE).Baja
        Try
            Return MaterialEstudioMPP.ObtenerInstancia.Baja(Objeto)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Modificacion(Objeto As MaterialEstudioBE) As Boolean Implements IABMC(Of MaterialEstudioBE).Modificacion
        Try
            Return MaterialEstudioMPP.ObtenerInstancia.Modificacion(Objeto)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function ListarObjetos() As IEnumerable(Of MaterialEstudioBE) Implements IABMC(Of MaterialEstudioBE).ListarObjetos
        Try
            Return MaterialEstudioMPP.ObtenerInstancia.ListarObjetos()
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function ListarObjeto(Objeto As MaterialEstudioBE) As MaterialEstudioBE Implements IABMC(Of MaterialEstudioBE).ListarObjeto
        Try
            Return MaterialEstudioMPP.ObtenerInstancia.ListarObjeto(Objeto)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
