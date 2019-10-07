Imports System.Configuration
Imports System.Data.SqlClient

Public Class Datos


    Private Cnn As New SqlConnection(ConfigurationManager.ConnectionStrings("myConnectionString").ConnectionString)

    Private Tranx As SqlTransaction
    Private Cmd As SqlCommand
    Private cx As New SqlConnection(ConfigurationManager.ConnectionStrings("myConnectionString").ConnectionString)

#Region "Singleton"
    'Sub New()
    'End Sub
    'lo pongo private para que no se acceda desde otra clase y sirva el Singleton.
    Private Shared instancia As Datos
    Public Shared Function ObtenerInstancia() As Datos
        If instancia Is Nothing Then
            instancia = New Datos
        End If
        Return instancia
    End Function
#End Region

    Public Function Leer(ByVal consulta As String, ByVal hdatos As Hashtable) As DataSet

        Dim Ds As New DataSet
        Cmd = New SqlCommand

        Cmd.Connection = Cnn
        Cmd.CommandText = consulta
        Cmd.CommandType = CommandType.StoredProcedure

        If Not hdatos Is Nothing Then

            'si la hashtable no esta vacia, y tiene el dato q busco 
            For Each dato As String In hdatos.Keys
                'cargo los parametros que le estoy pasando con la Hash
                Cmd.Parameters.AddWithValue(dato, hdatos(dato))
            Next
        End If

        Dim Adaptador As New SqlDataAdapter(Cmd)
        Adaptador.Fill(Ds)
        Return Ds


    End Function

    Public Function Escribir(ByVal consulta As String, ByVal hdatos As Hashtable) As Boolean

        If Cnn.State = ConnectionState.Closed Then
            Cnn.Open()
        End If

        Try
            Tranx = Cnn.BeginTransaction
            Cmd = New SqlCommand
            Cmd.Connection = Cnn
            Cmd.CommandText = consulta
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Transaction = Tranx

            If Not hdatos Is Nothing Then

                For Each dato As String In hdatos.Keys
                    'cargo los parametros que le estoy pasando con la Hash
                    Cmd.Parameters.AddWithValue(dato, hdatos(dato))
                Next
            End If

            Dim respuesta As Integer = Cmd.ExecuteNonQuery
            Tranx.Commit()
            Return True

        Catch ex As Exception
            Tranx.Rollback()
            Return False
        Finally
            Cnn.Close()
        End Try

    End Function

    Public Function EjecutarSP(ByVal nomSP As String, params As List(Of SqlParameter)) As Integer
        Dim i As Integer = 0
        Dim cmd As New SqlCommand With {.CommandType = CommandType.StoredProcedure, .CommandText = nomSP, .Connection = Me.cx}
        For Each s As SqlParameter In params
            cmd.Parameters.Add(s)
        Next
        Me.AbrirCx()
        Try
            i = cmd.ExecuteNonQuery
        Catch ex As Exception
            MsgBox(ex.Message)
            i = -1
        End Try
        cx.Close()
        Return i
    End Function

    Public Overloads Function LeerBD(ByVal nomSP As String, Optional params As List(Of SqlParameter) = Nothing) As DataTable
        Dim DA As New SqlDataAdapter
        Dim DT As New DataTable
        Dim cmd As New SqlCommand With {.CommandType = CommandType.StoredProcedure, .CommandText = nomSP, .Connection = Me.cx}
        DA.SelectCommand = cmd
        If params IsNot Nothing Then
            cmd.Parameters.AddRange(params.ToArray)
        End If
        Me.AbrirCx()
        DA.Fill(DT)
        Me.CerrarCX()
        Return DT
    End Function

    'Prueba LeerBD_1 hay que borrarlo
    Public Overloads Function LeerBD_1(ByVal nomSP As String, Optional params() As SqlParameter = Nothing) As DataTable
        Dim DA As New SqlDataAdapter
        Dim DT As New DataTable
        Dim cmd As New SqlCommand With {.CommandType = CommandType.StoredProcedure, .CommandText = nomSP, .Connection = Me.cx}
        DA.SelectCommand = cmd
        If params IsNot Nothing Then
            cmd.Parameters.AddRange(params)
        End If
        Me.AbrirCx()
        DA.Fill(DT)
        Me.CerrarCX()
        Return DT
    End Function

    Public Overloads Function LeerBD(ByVal cmdText As String) As DataTable
        Dim da As New SqlDataAdapter
        Dim dt As New DataTable
        Dim cmd As New SqlCommand With {.CommandType = CommandType.Text, .CommandText = cmdText, .Connection = Me.cx}
        da.SelectCommand = cmd
        Me.AbrirCx()
        da.Fill(dt)
        Me.CerrarCX()
        Return dt
    End Function

    Public Sub EscribirBD(ByVal cmdText As String)
        Dim i As Integer = 0
        Dim cmd As New SqlCommand With {.CommandType = CommandType.Text, .CommandText = cmdText, .Connection = Me.cx}
        Try
            Me.AbrirCx()
            i = cmd.ExecuteNonQuery
        Catch ex As Exception
            'MsgBox("Se produjo el siguiente error al operar en la Base de Datos:  " & ex.Message, MsgBoxStyle.Critical, "Cotizador PaP")
            i = -1
        End Try
        Me.CerrarCX()
    End Sub

    Public Overloads Function CrearParametro(ByVal Campo As String, ByVal vNum As Integer) As SqlParameter
        Dim par As New SqlParameter With {.ParameterName = Campo, .Value = vNum, .DbType = DbType.Int32}
        Return par
    End Function

    Public Overloads Function CrearParametro(ByVal Campo As String, ByVal vText As String) As SqlParameter
        Dim par As New SqlParameter With {.ParameterName = Campo, .Value = vText, .DbType = DbType.String}
        Return par
    End Function

    Public Overloads Function CrearParametro(ByVal Campo As String, ByVal vFecha As DateTime) As SqlParameter
        Dim par As New SqlParameter With {.ParameterName = Campo, .Value = vFecha, .DbType = DbType.DateTime}
        Return par
    End Function

    Public Overloads Function CrearParametro(ByVal Campo As String, ByVal vValor As Boolean) As SqlParameter
        Dim par As New SqlParameter With {.ParameterName = Campo, .Value = vValor, .DbType = DbType.Boolean}
        Return par
    End Function

    Public Overloads Function CrearParametro(ByVal Campo As String, ByVal vValor As Double) As SqlParameter
        Dim par As New SqlParameter With {.ParameterName = Campo, .Value = vValor, .DbType = DbType.Double}
        Return par
    End Function

    Public Overloads Function CrearParametro(ByVal Campo As String, vValor As Byte()) As SqlParameter
        Dim par As New SqlParameter With {.ParameterName = Campo, .Value = vValor, .SqlDbType = SqlDbType.VarBinary}
        Return par
    End Function


    Public Function Escribir2(StoreName As String, Parametros() As SqlParameter) As Int32
        Dim Cmd As New SqlCommand
        Dim Tx As SqlTransaction
        Dim FilasA As Int32
        AbrirCx()
        Tx = cx.BeginTransaction
        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.CommandText = StoreName
        Cmd.Connection = cx
        If Parametros Is Nothing = False Then
            Cmd.Parameters.AddRange(Parametros)
        End If
        Try
            Cmd.Transaction = Tx
            FilasA = Cmd.ExecuteNonQuery
            If FilasA >= 1 Then
                Tx.Commit()
            End If
            Return FilasA
        Catch ex As Exception
            Tx.Rollback()
            Throw ex
            Return -1
        Finally
            CerrarCX()
        End Try
    End Function

    Public Function Execute(StoreName As String) As Int32
        Dim Cmd As New SqlCommand
        Dim FilasA As Int32
        AbrirCx()
        Cmd.CommandText = StoreName
        Cmd.Connection = cx

        Try
            FilasA = Cmd.ExecuteNonQuery()

            Return FilasA + 1
        Catch ex As Exception
            Return -1
        Finally
            CerrarCX()
        End Try

    End Function

    Private Sub AbrirCx()
        If Me.cx.State <> ConnectionState.Open Then
            cx.Open()
        End If
    End Sub

    Private Sub CerrarCX()
        cx.Close()
    End Sub

End Class
