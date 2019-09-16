Imports BE
Imports bll
Imports MPP

Public Class UsuariosTipoMPP
    Implements IABMC(Of UsuariosTipoBE)

    Private Shared Instancia As UsuariosTipoMPP
    Public Shared Function ObtenerInstancia() As UsuariosTipoMPP
        If Instancia Is Nothing Then
            Instancia = New UsuariosTipoMPP
        End If
        Return Instancia
    End Function

    Public Function Alta(Objeto As UsuariosTipoBE) As Boolean Implements IABMC(Of UsuariosTipoBE).Alta
        Dim oDatos As New DAL.Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean

        hdatos.Add("@tipoConsulta", 1)
        hdatos.Add("@idTipoUsuario", 1)
        hdatos.Add("@descr", Objeto.descr)

        resultado = oDatos.Escribir("s_UsuariosTipo_ABMC", hdatos)

        Return resultado
    End Function

    Public Function Baja(Objeto As UsuariosTipoBE) As Boolean Implements IABMC(Of UsuariosTipoBE).Baja
        Dim oDatos As New DAL.Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean

        hdatos.Add("@tipoConsulta", 2)
        hdatos.Add("@idTipoUsuario", Objeto.idTipoUsuario)

        resultado = oDatos.Escribir("s_UsuariosTipo_ABMC", hdatos)

        Return resultado
    End Function

    Public Function Modificacion(Objeto As UsuariosTipoBE) As Boolean Implements IABMC(Of UsuariosTipoBE).Modificacion
        Dim oDatos As New DAL.Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean

        hdatos.Add("@tipoConsulta", 3)
        hdatos.Add("@idTipoUsuario", Objeto.idTipoUsuario)
        hdatos.Add("@descr", Objeto.descr)

        resultado = oDatos.Escribir("s_UsuariosTipo_ABMC", hdatos)

        Return resultado
    End Function

    Public Function ListarObjeto(Objeto As UsuariosTipoBE) As UsuariosTipoBE Implements IABMC(Of UsuariosTipoBE).ListarObjeto
        Dim oDatos As New DAL.Datos
        Dim DS As New DataSet
        Dim dt As New DataTable
        Dim newObj As New BE.UsuariosTipoBE

        Dim hdatos As New Hashtable
        hdatos.Add("@tipoConsulta", 5)
        hdatos.Add("@idTipoUsuario", Objeto.idTipoUsuario)
        hdatos.Add("@descr", DBNull.Value)

        DS = oDatos.Leer("s_UsuariosTipo_ABMC", hdatos)

        If DS.Tables(0).Rows.Count > 0 Then

            For Each Item As DataRow In DS.Tables(0).Rows
                newObj.idTipoUsuario = Item("idTipoUsuario")
                newObj.descr = Item("descr")
            Next

            Return newObj

        Else
            Return Nothing
        End If
    End Function

    Public Function ListarObjetos() As IEnumerable(Of UsuariosTipoBE) Implements IABMC(Of UsuariosTipoBE).ListarObjetos
        Dim oDatos As New DAL.Datos
        Dim DS As New DataSet
        Dim list As New List(Of BE.UsuariosTipoBE)
        Dim dt As New DataTable
        Dim newObj As BE.UsuariosTipoBE

        Dim hdatos As New Hashtable
        hdatos.Add("@tipoConsulta", 4)
        hdatos.Add("@idTipoUsuario", DBNull.Value)
        hdatos.Add("@descr", DBNull.Value)

        DS = oDatos.Leer("s_UsuariosTipo_ABMC", hdatos)

        If DS.Tables(0).Rows.Count > 0 Then

            For Each Item As DataRow In DS.Tables(0).Rows
                newObj = New BE.UsuariosTipoBE
                newObj.idTipoUsuario = Item("idTipoUsuario")
                newObj.descr = Item("descr")

                list.Add(newObj)
            Next

            Return list

        Else
            Return Nothing
        End If
    End Function
End Class
