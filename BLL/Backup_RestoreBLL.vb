Imports BE
Imports MPP
Imports System.Configuration

Public Class Backup_RestoreBLL
    Dim folder As String
    Dim fullpath As String
    Dim mensaje As String

#Region "Singleton"
    Private Sub New()
    End Sub

    Private Shared Instancia As Backup_RestoreBLL
    Public Shared Function ObtenerInstancia() As Backup_RestoreBLL
        If Instancia Is Nothing Then
            Instancia = New Backup_RestoreBLL
        End If
        Return Instancia
    End Function
#End Region

    Public Function Realizar_BackUp(oUsuario As UsuarioBE, pathBackup As String, pathDateBase As String) As Boolean
        Dim oBackUp As New Backup_RestoreBE
        Try
            oBackUp.Fecha = DateTime.Now
            oBackUp.Nombre = "Mokar" & oBackUp.Fecha.ToString("_MMddyyyy_HHmmss") & ".bak"
            oBackUp.Path = pathBackup
            oBackUp.Usuario = oUsuario.mail

            fullpath = oBackUp.Path '' & "/" & "Mokar" & DateTime.Now.ToString("_MMddyyyy_HHmmss") & ".bak"

            If Backup_RestoreMPP.ObtenerInstancia.Realizar_BackUp(fullpath, pathDateBase) Then

                oBackUp.Tamaño = Criptografia.ObtenerInstancia.getTamFile(fullpath)

                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
        End Try

    End Function


    Public Function Listar_BackUps_Disponibles(path As String) As List(Of Backup_RestoreBE)
        Dim lista_BackUpsFisicos As New List(Of Backup_RestoreBE)
        lista_BackUpsFisicos = Me.Listar_BackUps_Fisicos(path)
        lista_BackUpsFisicos = lista_BackUpsFisicos.OrderByDescending(Function(x) x.Fecha).ToList
        Return lista_BackUpsFisicos
    End Function

    Public Function Listar_BackUps_Fisicos(path As String) As List(Of Backup_RestoreBE)
        Return Criptografia.ObtenerInstancia.Listar_BackUps_Fisicos(path)
    End Function


    Public Function Realizar_Restore(nombre As String, usuario As String, pathDateBase As String, pathBackup As String) As Boolean
        Try
            Return Backup_RestoreMPP.ObtenerInstancia.Realizar_Restore(nombre, pathDateBase, pathBackup)
        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Public Function Realizar_Restore(pathDateBase As String, pathBackup As String) As Boolean
        Try
            If Backup_RestoreMPP.ObtenerInstancia.Realizar_Restore(pathDateBase, pathBackup) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try

    End Function

End Class
