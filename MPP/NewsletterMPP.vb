Imports BE

Public Class NewsletterMPP

    Private Shared Instancia As NewsletterMPP

    Public Shared Function ObtenerInstancia() As NewsletterMPP
        If Instancia Is Nothing Then
            Instancia = New NewsletterMPP
        End If
        Return Instancia
    End Function

    Public Function Alta(Objeto As NewsletterBE) As Boolean
        Dim oDatos As New DAL.Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean

        hdatos.Add("@tipoConsulta", 1)
        hdatos.Add("@idNewsletter", 1)
        hdatos.Add("@titulo", Objeto.titulo)
        hdatos.Add("@descripcion", Objeto.descripcion)
        hdatos.Add("@autor", Objeto.autor)
        hdatos.Add("@fechaCreacion", Objeto.fechaCreacion)
        hdatos.Add("@imagen", Objeto.imagen)
        hdatos.Add("@idCategoria", Objeto.idCategoria)
        hdatos.Add("@activo", "1")

        resultado = oDatos.Escribir("n_Newsletter_ABMC", hdatos)

        Return resultado
    End Function

    Public Function Baja(Objeto As NewsletterBE) As Boolean
        Dim oDatos As New DAL.Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean

        hdatos.Add("@tipoConsulta", 2)
        hdatos.Add("@idNewsletter", Objeto.idNewsletter)
        hdatos.Add("@titulo", DBNull.Value)
        hdatos.Add("@descripcion", DBNull.Value)
        hdatos.Add("@autor", DBNull.Value)
        hdatos.Add("@fechaCreacion", DBNull.Value)
        hdatos.Add("@imagen", System.Data.SqlTypes.SqlBinary.Null)
        hdatos.Add("@idCategoria", DBNull.Value)
        hdatos.Add("@activo", "0")

        resultado = oDatos.Escribir("n_Newsletter_ABMC", hdatos)

        Return resultado
    End Function

    Public Function Modificacion(Objeto As NewsletterBE) As Boolean
        Dim oDatos As New DAL.Datos
        Dim hdatos As New Hashtable
        Dim resultado As Boolean

        If Objeto.imagen Is Nothing Then
            hdatos.Add("@tipoConsulta", 6)
            hdatos.Add("@imagen", New Byte())
        Else
            hdatos.Add("@tipoConsulta", 3)
            hdatos.Add("@imagen", Objeto.imagen)
        End If

             hdatos.Add("@idNewsletter", Objeto.idNewsletter)
        hdatos.Add("@titulo", Objeto.titulo)
        hdatos.Add("@descripcion", Objeto.descripcion)
        hdatos.Add("@autor", Objeto.autor)
        hdatos.Add("@fechaCreacion", Objeto.fechaCreacion)
        hdatos.Add("@idCategoria", Objeto.idCategoria)
        hdatos.Add("@activo", Objeto.activo)

        resultado = oDatos.Escribir("n_Newsletter_ABMC", hdatos)

        Return resultado
    End Function

    Public Function ListarObjetos() As IEnumerable(Of NewsletterBE)
        Dim oDatos As New DAL.Datos
        Dim DS As New DataSet
        Dim list As New List(Of BE.NewsletterBE)
        Dim dt As New DataTable
        Dim newObj As BE.NewsletterBE

        Dim hdatos As New Hashtable
        hdatos.Add("@tipoConsulta", 4)
        hdatos.Add("@idNewsletter", DBNull.Value)
        hdatos.Add("@titulo", DBNull.Value)
        hdatos.Add("@descripcion", DBNull.Value)
        hdatos.Add("@autor", DBNull.Value)
        hdatos.Add("@fechaCreacion", DBNull.Value)
        hdatos.Add("@imagen", System.Data.SqlTypes.SqlBinary.Null)
        hdatos.Add("@idCategoria", DBNull.Value)
        hdatos.Add("@activo", DBNull.Value)

        DS = oDatos.Leer("n_Newsletter_ABMC", hdatos)

        If DS.Tables(0).Rows.Count > 0 Then

            For Each Item As DataRow In DS.Tables(0).Rows
                newObj = New BE.NewsletterBE
                newObj.idNewsletter = Item("idNewsletter")
                newObj.titulo = Item("titulo")
                newObj.descripcion = Item("descripcion")
                newObj.autor = Item("autor")
                newObj.fechaCreacion = Item("fechaCreacion")
                newObj.imagen = Item("imagen")
                newObj.idCategoria = Item("idCategoria")
                newObj.activo = Item("activo")
                newObj.categoriaDescr = Item("categoriaDescr")

                list.Add(newObj)
            Next

            Return list

        Else
            Return Nothing
        End If
    End Function

    Public Function ListarObjeto(Objeto As NewsletterBE) As NewsletterBE
        Dim oDatos As New DAL.Datos
        Dim DS As New DataSet
        Dim dt As New DataTable
        Dim newObj As New BE.NewsletterBE

        Dim hdatos As New Hashtable
        hdatos.Add("@tipoConsulta", 5)
        hdatos.Add("@idNewsletter", Objeto.idNewsletter)
        hdatos.Add("@titulo", DBNull.Value)
        hdatos.Add("@descripcion", DBNull.Value)
        hdatos.Add("@autor", DBNull.Value)
        hdatos.Add("@fechaCreacion", DBNull.Value)
        hdatos.Add("@imagen", System.Data.SqlTypes.SqlBinary.Null)
        hdatos.Add("@idCategoria", DBNull.Value)
        hdatos.Add("@activo", DBNull.Value)

        DS = oDatos.Leer("n_Newsletter_ABMC", hdatos)

        If DS.Tables(0).Rows.Count > 0 Then

            For Each Item As DataRow In DS.Tables(0).Rows

                newObj = New BE.NewsletterBE
                newObj.idNewsletter = Item("idNewsletter")
                newObj.titulo = Item("titulo")
                newObj.descripcion = Item("descripcion")
                newObj.autor = Item("autor")
                newObj.fechaCreacion = Item("fechaCreacion")
                newObj.imagen = Item("imagen")
                newObj.idCategoria = Item("idCategoria")
                newObj.activo = Item("activo")
                newObj.categoriaDescr = Item("categoriaDescr")

            Next

            Return newObj

        Else
            Return Nothing
        End If
    End Function

    Public Function Suscribirse(usuario As UsuarioBE, listCat As List(Of CategoriaBE)) As Boolean
        Try
            Dim oDatos As New DAL.Datos

            Dim resultado As Boolean = True

            For Each objeto As CategoriaBE In listCat
                Dim hdatos As New Hashtable
                hdatos.Add("@tipoConsulta", 1)
                hdatos.Add("@UsuarioMail", usuario.mail)
                hdatos.Add("@idCategoria", objeto.idCategoria)

                If oDatos.Escribir("n_Newsletter_Usuarios_ABMC", hdatos) = False Then
                    resultado = False
                End If
            Next

            Return resultado

        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function Desuscribirse(usuario As UsuarioBE) As Boolean
        Try
            Dim oDatos As New DAL.Datos

            Dim resultado As Boolean = True


            Dim hdatos As New Hashtable
                hdatos.Add("@tipoConsulta", 2)
                hdatos.Add("@UsuarioMail", usuario.mail)
                hdatos.Add("@idCategoria", DBNull.Value)

                If oDatos.Escribir("n_Newsletter_Usuarios_ABMC", hdatos) = False Then
                    resultado = False
                End If

            Return resultado

        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function ListarUsuarioCategoria(noticia As NewsletterBE) As IEnumerable(Of UsuarioBE)
        Dim oDatos As New DAL.Datos
        Dim DS As New DataSet
        Dim list As New List(Of BE.UsuarioBE)
        Dim dt As New DataTable
        Dim newObj As BE.UsuarioBE

        Dim hdatos As New Hashtable
        hdatos.Add("@tipoConsulta", 5)
        hdatos.Add("@UsuarioMail", DBNull.Value)
        hdatos.Add("@idCategoria", noticia.idCategoria)

        DS = oDatos.Leer("n_Newsletter_Usuarios_ABMC", hdatos)

        If DS.Tables(0).Rows.Count > 0 Then

            For Each Item As DataRow In DS.Tables(0).Rows
                newObj = New BE.UsuarioBE
                newObj.mail = Item("UsuarioMail")

                list.Add(newObj)
            Next

            Return list

        Else
            Return Nothing
        End If
    End Function

End Class
