Imports BE
Imports BLL

Public Class Factura_Descargar
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (Page.IsPostBack) Then

            Dim ID_Factura As Integer = Session("FacturaID")
            Dim NewFactura As FacturaCompletaBE = FacturaBLL.ObtenerInstancia.ObtenerFacturaCompPorID(ID_Factura)
            GestorPDF.ObtenerInstancia.ArmarPDF(Response, Server.MapPath("Template_Mokar_Factura2.html"), NewFactura)

        End If
    End Sub

End Class