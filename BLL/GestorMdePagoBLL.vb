Imports MPP
Imports BE

Public Class GestorMdePagoBLL

#Region "Singleton"
    Private Sub New()
    End Sub

    Private Shared Instancia As GestorMdePagoBLL
    Public Shared Function ObtenerInstancia() As GestorMdePagoBLL
        If Instancia Is Nothing Then
            Instancia = New GestorMdePagoBLL
        End If
        Return Instancia
    End Function

#End Region

    Public Function ListarMdePago() As List(Of MediodePagoBE)
        Return MedioPagoMPP.ObtenerInstancia.ListarMdePago()
    End Function
End Class
