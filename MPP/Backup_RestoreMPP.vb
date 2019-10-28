Imports System.Text
Imports DAL

Public Class Backup_RestoreMPP

#Region "Singleton"
    Private Sub New()
    End Sub

    Private Shared Instancia As Backup_RestoreMPP
    Public Shared Function ObtenerInstancia() As Backup_RestoreMPP
        If Instancia Is Nothing Then
            Instancia = New Backup_RestoreMPP
        End If
        Return Instancia
    End Function
#End Region

    Dim databaseName As String
    Dim fullpath As String

    Public Function Realizar_BackUp(fullpath As String, pathDataBase As String) As Boolean
        Try

            databaseName = pathDataBase
            'El Database debe declararse en la Web.Config

            Dim full As String
            Dim sCmd As New StringBuilder
            Dim res As Int32

            sCmd.Append("BACKUP DATABASE " & databaseName & " TO  DISK = N'" + fullpath + "' ")
            'sCmd.Append("WITH DESCRIPTION = N'" + backup.Descripcion + "', NOFORMAT, NOINIT, ")
            'sCmd.Append("NAME = N'" + backup.Descripcion + "', SKIP, NOREWIND, NOUNLOAD,  STATS = 10")
            full = sCmd.ToString
            res = Datos.ObtenerInstancia.Execute(sCmd.ToString)
            If res = 0 Then

                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function Realizar_Restore(nombre As String, pathDataBase As String, pathBackup As String) As Boolean
        Try

            Dim res As Int32

            databaseName = pathDataBase
            fullpath = pathBackup
            'El backup_path debe declararse en la Web.Config
            fullpath = fullpath & "/" & nombre
            Dim sCmd As New StringBuilder

            sCmd.Append("USE master ALTER DATABASE " & databaseName & " SET SINGLE_USER WITH ROLLBACK IMMEDIATE RESTORE DATABASE " & databaseName & " FROM DISK = '" & fullpath & "' WITH REPLACE")
            res = Datos.ObtenerInstancia.Execute(sCmd.ToString)

            If res = 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try


    End Function

    Public Function Realizar_Restore(pathDataBase As String, pathBackup As String) As Boolean
        Try

            Dim res As Int32

            databaseName = pathDataBase
            fullpath = pathBackup
            'El backup_path debe declararse en la Web.Config
            fullpath = fullpath
            Dim sCmd As New StringBuilder

            sCmd.Append("USE master ALTER DATABASE " & databaseName & " SET SINGLE_USER WITH ROLLBACK IMMEDIATE RESTORE DATABASE " & databaseName & " FROM DISK = '" & fullpath & "' WITH REPLACE ALTER DATABASE " & databaseName & " SET Multi_User ")

            res = Datos.ObtenerInstancia.Execute(sCmd.ToString)

            If res = 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try


    End Function

End Class
