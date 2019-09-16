Imports BE

Public Class CategoriaMPP
    Implements IABMC(Of CategoriaBE)

    Private Shared Instancia As CategoriaMPP
    Public Shared Function ObtenerInstancia() As CategoriaMPP
        If Instancia Is Nothing Then
            Instancia = New CategoriaMPP
        End If
        Return Instancia
    End Function

    Public Function Alta(Objeto As CategoriaBE) As Boolean Implements IABMC(Of CategoriaBE).Alta
        Dim oDatos As New DAL.Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean

        hdatos.Add("@tipoConsulta", 1)
        hdatos.Add("@idCategoria", 1)
        hdatos.Add("@descripcion", Objeto.descripcion)

        resultado = oDatos.Escribir("n_Categoria_ABMC", hdatos)

        Return resultado
    End Function

    Public Function Baja(Objeto As CategoriaBE) As Boolean Implements IABMC(Of CategoriaBE).Baja
        Dim oDatos As New DAL.Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean

        hdatos.Add("@tipoConsulta", 2)
        hdatos.Add("@idCategoria", Objeto.idCategoria)

        resultado = oDatos.Escribir("n_Categoria_ABMC", hdatos)

        Return resultado
    End Function

    Public Function Modificacion(Objeto As CategoriaBE) As Boolean Implements IABMC(Of CategoriaBE).Modificacion
        Dim oDatos As New DAL.Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean

        hdatos.Add("@tipoConsulta", 3)
        hdatos.Add("@idCategoria", Objeto.idCategoria)
        hdatos.Add("@descripcion", Objeto.descripcion)

        resultado = oDatos.Escribir("n_Categoria_ABMC", hdatos)

        Return resultado
    End Function

    Public Function ListarObjeto(Objeto As CategoriaBE) As CategoriaBE Implements IABMC(Of CategoriaBE).ListarObjeto
        Dim oDatos As New DAL.Datos
        Dim DS As New DataSet
        Dim dt As New DataTable
        Dim newObj As New BE.CategoriaBE

        Dim hdatos As New Hashtable
        hdatos.Add("@tipoConsulta", 5)
        hdatos.Add("@idCategoria", Objeto.idCategoria)
        hdatos.Add("@descripcion", DBNull.Value)

        DS = oDatos.Leer("n_Categoria_ABMC", hdatos)

        If DS.Tables(0).Rows.Count > 0 Then

            For Each Item As DataRow In DS.Tables(0).Rows
                newObj.idCategoria = Item("idCategoria")
                newObj.descripcion = Item("descripcion")
            Next

            Return newObj

        Else
            Return Nothing
        End If
    End Function

    Public Function ListarObjetos() As IEnumerable(Of CategoriaBE) Implements IABMC(Of CategoriaBE).ListarObjetos
        Dim oDatos As New DAL.Datos
        Dim DS As New DataSet
        Dim list As New List(Of BE.CategoriaBE)
        Dim dt As New DataTable
        Dim newObj As BE.CategoriaBE

        Dim hdatos As New Hashtable
        hdatos.Add("@tipoConsulta", 4)
        hdatos.Add("@idCategoria", DBNull.Value)
        hdatos.Add("@descripcion", DBNull.Value)

        DS = oDatos.Leer("n_Categoria_ABMC", hdatos)

        If DS.Tables(0).Rows.Count > 0 Then

            For Each Item As DataRow In DS.Tables(0).Rows
                newObj = New BE.CategoriaBE
                newObj.idCategoria = Item("idCategoria")
                newObj.descripcion = Item("descripcion")

                list.Add(newObj)
            Next

            Return list

        Else
            Return Nothing
        End If
    End Function
End Class
