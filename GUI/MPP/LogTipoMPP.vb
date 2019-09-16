Imports BE

Public Class LogTipoMPP
    Implements IABMC(Of LogTipoBE)

    Private Shared Instancia As LogTipoMPP
    Public Shared Function ObtenerInstancia() As LogTipoMPP
        If Instancia Is Nothing Then
            Instancia = New LogTipoMPP
        End If
        Return Instancia
    End Function

    Public Function Alta(Objeto As LogTipoBE) As Boolean Implements IABMC(Of LogTipoBE).Alta
        Dim oDatos As New DAL.Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean

        hdatos.Add("@tipoConsulta", 1)
        hdatos.Add("@idTipoRegistro", 1)
        hdatos.Add("@descr", Objeto.descr)

        resultado = oDatos.Escribir("s_LogTipoRegistro_ABMC", hdatos)

        Return resultado
    End Function

    Public Function Baja(Objeto As LogTipoBE) As Boolean Implements IABMC(Of LogTipoBE).Baja
        Dim oDatos As New DAL.Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean

        hdatos.Add("@tipoConsulta", 2)
        hdatos.Add("@idTipoRegistro", Objeto.idTipoRegistro)

        resultado = oDatos.Escribir("s_LogTipoRegistro_ABMC", hdatos)

        Return resultado
    End Function

    Public Function Modificacion(Objeto As LogTipoBE) As Boolean Implements IABMC(Of LogTipoBE).Modificacion
        Dim oDatos As New DAL.Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean

        hdatos.Add("@tipoConsulta", 3)
        hdatos.Add("@idTipoRegistro", Objeto.idTipoRegistro)
        hdatos.Add("@descr", Objeto.descr)

        resultado = oDatos.Escribir("s_LogTipoRegistro_ABMC", hdatos)

        Return resultado
    End Function

    Public Function ListarObjeto(Objeto As LogTipoBE) As LogTipoBE Implements IABMC(Of LogTipoBE).ListarObjeto
        Dim oDatos As New DAL.Datos
        Dim DS As New DataSet
        Dim dt As New DataTable
        Dim newObj As New BE.LogTipoBE

        Dim hdatos As New Hashtable
        hdatos.Add("@tipoConsulta", 5)
        hdatos.Add("@idTipoRegistro", Objeto.idTipoRegistro)
        hdatos.Add("@descr", DBNull.Value)

        DS = oDatos.Leer("s_LogTipoRegistro_ABMC", hdatos)

        If DS.Tables(0).Rows.Count > 0 Then

            For Each Item As DataRow In DS.Tables(0).Rows
                newObj.idTipoRegistro = Item("idTipoRegistro")
                newObj.descr = Item("descr")
            Next

            Return newObj

        Else
            Return Nothing
        End If
    End Function

    Public Function ListarObjetos() As IEnumerable(Of LogTipoBE) Implements IABMC(Of LogTipoBE).ListarObjetos
        Dim oDatos As New DAL.Datos
        Dim DS As New DataSet
        Dim list As New List(Of BE.LogTipoBE)
        Dim dt As New DataTable
        Dim newObj As BE.LogTipoBE

        Dim hdatos As New Hashtable
        hdatos.Add("@tipoConsulta", 4)
        hdatos.Add("@idTipoRegistro", DBNull.Value)
        hdatos.Add("@descr", DBNull.Value)

        DS = oDatos.Leer("s_LogTipoRegistro_ABMC", hdatos)

        If DS.Tables(0).Rows.Count > 0 Then

            For Each Item As DataRow In DS.Tables(0).Rows
                newObj = New BE.LogTipoBE
                newObj.idTipoRegistro = Item("idTipoRegistro")
                newObj.descr = Item("descr")

                list.Add(newObj)
            Next

            Return list

        Else
            Return Nothing
        End If
    End Function
End Class
