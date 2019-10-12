Imports BE
Imports BLL

Public Class MisFacturas1
    Inherits System.Web.UI.Page

    Dim FacturasObtenidas As New List(Of FacturaBE)
    Dim usuario As New UsuarioBE
    Dim mensaje As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None
        If Not (Page.IsPostBack) Then

            Cargar_Facturas()

        End If
    End Sub
    Public Sub Cargar_Facturas()
        usuario = GestorSesion.ObtenerSesionActual.UsuarioActivo

        FacturasObtenidas = FacturaBLL.ObtenerInstancia.ObtenerPorIDUser(usuario.idUsuario)

        DG_Facturas.DataSource = Nothing
        DG_Facturas.DataSource = FacturasObtenidas
        DG_Facturas.DataBind()

    End Sub

    Private Sub DG_Facturas_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles DG_Facturas.PageIndexChanging
        DG_Facturas.PageIndex = e.NewPageIndex
        Cargar_Facturas()
    End Sub

    Private Sub DG_Facturas_SelectedIndexChanging(sender As Object, e As GridViewSelectEventArgs) Handles DG_Facturas.SelectedIndexChanging
        Dim FacturaID As Integer
        FacturaID = DG_Facturas.Rows(e.NewSelectedIndex).Cells(2).Text
        Session("FacturaID") = FacturaID

        Response.Redirect("Factura_Descargar.aspx")
    End Sub

    Private Sub DG_Facturas_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles DG_Facturas.RowDeleting
        contenido.Visible = True
        Session("RowSelected") = DG_Facturas.Rows(e.RowIndex)

    End Sub

    Protected Sub btnConfirmar_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click
        If TB_Ingresar_Motivo.Text = "" Then
            mensaje = "Debe ingresar un motivo de cancelación"
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & mensaje & "')", True)
        End If

        Dim FacturaCancel As New PedidoCanceladoBE

        FacturaCancel.Fecha = DateTime.Now
        FacturaCancel.ID_Factura = CType(Session("RowSelected"), GridViewRow).Cells(2).Text
        FacturaCancel.Motivo = TB_Ingresar_Motivo.Text
        FacturaCancel.Usuario = CType(Session("RowSelected"), GridViewRow).Cells(6).Text

        If CType(Session("RowSelected"), GridViewRow).Cells(8).Text = "False" Then
            mensaje = "Se solicitó la cancelación de la factura: " & CType(Session("RowSelected"), GridViewRow).Cells(2).Text
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & mensaje & "')", True)
            PedidoCanceladoBLL.ObtenerInstancia.Nuevo(FacturaCancel)
        Else
            mensaje = "La factura Nro. " & CType(Session("RowSelected"), GridViewRow).Cells(2).Text & " ya se encuentra cancelada"
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & mensaje & "')", True)
        End If

        contenido.Visible = False

    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        contenido.Visible = False
    End Sub
End Class