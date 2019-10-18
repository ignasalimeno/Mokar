Imports System.Data.SqlClient
Imports BE
Imports DAL

Public Class BuscadorMPP

#Region "Singleton"
    Private Sub New()
    End Sub

    Private Shared Instancia As BuscadorMPP
    Public Shared Function ObtenerInstancia() As BuscadorMPP
        If Instancia Is Nothing Then
            Instancia = New BuscadorMPP
        End If
        Return Instancia
    End Function

#End Region

    Public Function Buscar(texto As String, usuario As Integer) As List(Of BuscadorBE)
        Try
            Dim pars(0 To 1) As SqlParameter
            pars(0) = Datos.ObtenerInstancia.CrearParametro("@palabra_buscar", texto)
            pars(1) = Datos.ObtenerInstancia.CrearParametro("@usuario", usuario)
            Dim lista As New List(Of BuscadorBE)
            Dim dt As DataTable = Datos.ObtenerInstancia.LeerBD_1("Buscar", pars)
            For Each r As DataRow In dt.Rows
                Dim oMenu As New BuscadorBE With {
                .Id = r.Item("ID_PantallasBusqueda"),
                .Icnono = r.Item("Descripcion"),
                .URL = r("Formulario"),
                .Menu = r("Pantalla")}

                lista.Add(oMenu)
            Next
            Return lista
        Catch ex As Exception
            Return Nothing
        End Try

    End Function
End Class
