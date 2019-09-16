Imports BE
Imports MPP

Public Class LogTipoBLL
    Implements IABMC(Of LogTipoBE)

    Private Shared Instancia As LogTipoBLL
    Public Shared Function ObtenerInstancia() As LogTipoBLL
        If Instancia Is Nothing Then
            Instancia = New LogTipoBLL
        End If
        Return Instancia
    End Function

    Public Function Alta(Objeto As LogTipoBE) As Boolean Implements IABMC(Of LogTipoBE).Alta
        Try
            Return LogTipoMPP.ObtenerInstancia.Alta(Objeto)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Baja(Objeto As LogTipoBE) As Boolean Implements IABMC(Of LogTipoBE).Baja
        Try
            Return LogTipoMPP.ObtenerInstancia.Baja(Objeto)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Modificacion(Objeto As LogTipoBE) As Boolean Implements IABMC(Of LogTipoBE).Modificacion
        Try
            Return LogTipoMPP.ObtenerInstancia.Modificacion(Objeto)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function ListarObjetos() As IEnumerable(Of LogTipoBE) Implements IABMC(Of LogTipoBE).ListarObjetos
        Try
            Return LogTipoMPP.ObtenerInstancia.ListarObjetos()
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function ListarObjeto(Objeto As LogTipoBE) As LogTipoBE Implements IABMC(Of LogTipoBE).ListarObjeto
        Try
            Return LogTipoMPP.ObtenerInstancia.ListarObjeto(Objeto)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
