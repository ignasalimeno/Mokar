Imports BE
Imports DAL


Public Class MedioPagoMPP

#Region "Singleton"
    Private Sub New()
    End Sub

    Private Shared Instancia As MedioPagoMPP
    Public Shared Function ObtenerInstancia() As MedioPagoMPP
        If Instancia Is Nothing Then
            Instancia = New MedioPagoMPP
        End If
        Return Instancia
    End Function

#End Region

    Public Function ListarMdePago() As List(Of MediodePagoBE)
        Dim ListaNews As New List(Of MediodePagoBE)
        For Each row As DataRow In Datos.ObtenerInstancia.LeerBD("Medio_Pago_Select").Rows
            Dim oPago As New MediodePagoBE With {.ID = row("ID_MedPago"), .Descripcion = row("Descripcion")}
            ListaNews.Add(oPago)
        Next
        Return ListaNews
        Throw New Exception("Easy Travel informa que ha ocurrido un error")
    End Function

End Class
