Imports BE
Imports MPP

Public Class PedidoCanceladoBLL

#Region "Singleton"
    Private Sub New()
    End Sub

    Private Shared Instancia As PedidoCanceladoBLL
    Public Shared Function ObtenerInstancia() As PedidoCanceladoBLL
        If Instancia Is Nothing Then
            Instancia = New PedidoCanceladoBLL
        End If
        Return Instancia
    End Function

#End Region

    Public Sub Nuevo(ByRef Elemento As PedidoCanceladoBE)
        PedidoCanceladoMPP.ObtenerInstancia.Crear(Elemento)
    End Sub

    Public Function Eliminar(ByVal id As PedidoCanceladoBE)
        Return PedidoCanceladoMPP.ObtenerInstancia.Eliminar(id)
    End Function

    Public Function Listar() As List(Of PedidoCanceladoBE)
        Return PedidoCanceladoMPP.ObtenerInstancia.Listar()
    End Function

End Class
