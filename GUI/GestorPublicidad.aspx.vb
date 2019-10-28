Public Class GestorPublicidad
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (Page.IsPostBack) Then
            cargarXML()
        End If
    End Sub

    Sub cargarXML()
        Try
            Dim dt As New DataTable
            dt.Columns.Add("id")
            dt.Columns.Add("url")
            dt.Columns.Add("imagenUrl")
            dt.Columns.Add("texto")

            Dim xmlDoc As XDocument = XDocument.Load(Server.MapPath("AdRotator.xml"))
            Dim Consulta = From publicidad In xmlDoc.Descendants("Ad")
                           Select New With {
                        .url = publicidad.Element("NavigateUrl").Value,
                        .imagenUrl = publicidad.Element("ImageUrl").Value,
                        .texto = publicidad.Element("AlternateText").Value
                     }

            Dim id As Integer = 0
            For Each a In Consulta

                Dim drow As DataRow = dt.NewRow
                drow(0) = id
                drow(1) = a.url
                drow(2) = a.imagenUrl
                drow(3) = a.texto

                dt.Rows.Add(drow)
                id += 1
            Next

            Session("dtXML") = dt
            GvObjeto.DataSource = dt
            GvObjeto.DataBind()

        Catch ex As Exception

        End Try
    End Sub

    Function guardarXML() As Boolean
        Try

            Dim xmlDoc As XDocument = XDocument.Load(Server.MapPath("AdRotator.xml"))

            Dim xmlElement As XElement = xmlDoc.Element("Advertisements")
            xmlElement.RemoveNodes()

            Dim dt As DataTable = Session("dtXML")

            For Each a As DataRow In dt.Rows
                xmlDoc.Element("Advertisements").Add(New XElement("Ad", New XElement("NavigateUrl", a(1)),
                                     New XElement("ImageUrl", a(2)),
                                      New XElement("height", "391"),
                                      New XElement("width", "73"),
                                      New XElement("Keyword", "Computers"),
                                                             New XElement("Impressions", "2"),
                                     New XElement("AlternateText", a(2))))

            Next

            xmlDoc.Save(Server.MapPath("AdRotator.xml"))
            cargarXML()


            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function


    Protected Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            Dim dt As DataTable = Session("dtXML")
            Dim drow As DataRow = dt.NewRow

            drow(1) = txtURL.Text
            drow(2) = txtImagen.Text
            drow(3) = txtTexto.Text
            dt.Rows.Add(drow)

            Session("dtXML") = dt

            guardarXML()


        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        txtTexto.Text = ""
        txtImagen.Text = ""
        txtURL.Text = ""
        panelNuevo.Visible = False
    End Sub

    Protected Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        panelNuevo.Visible = True
    End Sub

    Private Sub GvObjeto_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles GvObjeto.RowDeleting
        Try
            Dim dt As DataTable = Session("dtXML")

            dt.Rows(e.RowIndex).Delete()

            Session("dtXML") = dt

            guardarXML()

        Catch ex As Exception

        End Try
    End Sub
End Class