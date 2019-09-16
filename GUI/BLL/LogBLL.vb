Imports BE

Public Class LogBLL

    Sub New()

    End Sub


    Private Shared Instancia As LogBLL
    Public Shared Function ObtenerInstancia() As LogBLL
        If Instancia Is Nothing Then
            Instancia = New LogBLL
        End If
        Return Instancia
    End Function

    Dim oMapper As New MPP.LogMPP

    Public Function Alta(Objeto As LogBE) As Boolean
        Dim resultado As Boolean
        resultado = oMapper.Alta(Objeto)

        Return resultado
    End Function

    Public Function ListarTodos() As IEnumerable(Of LogBE)
        Try
            Dim listReturn As New List(Of BE.LogBE)

            listReturn = oMapper.ListarObjetos()

            Return listReturn
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function ListarTipos() As Hashtable
        Try
            Dim listReturn As New Hashtable

            listReturn = oMapper.ListarTipos()

            Return listReturn
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function ListarBusquedaSimple(campo As String) As IEnumerable(Of LogBE)
        Try
            Dim listReturn As New List(Of BE.LogBE)

            listReturn = oMapper.ListarObjetosSimple(campo)

            Return listReturn
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function ListarBusquedaAvanzada(oLog As LogBE, fechaDesde As Date, fechaHasta As Date) As IEnumerable(Of LogBE)
        Try
            Dim listReturn As New List(Of BE.LogBE)

            listReturn = oMapper.ListarObjetosAvanzada(oLog, fechaDesde, fechaHasta)

            Return listReturn
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
