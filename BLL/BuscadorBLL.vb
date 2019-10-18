Imports BE
Imports MPP

Public Class BuscadorBLL

#Region "Singleton"
    Private Sub New()
    End Sub

    Private Shared Instancia As BuscadorBLL
    Public Shared Function ObtenerInstancia() As BuscadorBLL
        If Instancia Is Nothing Then
            Instancia = New BuscadorBLL
        End If
        Return Instancia
    End Function

#End Region

    Public Function Buscar(texto As String, usuario As Integer) As List(Of BuscadorBE)
        Return BuscadorMPP.ObtenerInstancia.Buscar(texto, usuario)
    End Function

End Class
