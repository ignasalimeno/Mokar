Imports BLL
Imports BE
Public Class MisFacturas
    Inherits System.Web.UI.Page

    Dim mensaje As String
    Dim RechazoCompraOK As New CuentaCorrienteBE
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Page.UnobtrusiveValidationMode = UI.UnobtrusiveValidationMode.None
        If Not (Page.IsPostBack) Then

            Cargar_Grilla()
            Cargar_Grilla2()

        End If
    End Sub

    Public Sub Cargar_Grilla()
        DG_Facturas.DataSource = Nothing
        DG_Facturas.DataSource = FacturaBLL.ObtenerInstancia.ListarFacturas
        DG_Facturas.DataBind()
    End Sub

    Public Sub Cargar_Grilla2()
        DG_Pedido.DataSource = Nothing
        DG_Pedido.DataSource = PedidoCanceladoBLL.ObtenerInstancia.Listar
        DG_Pedido.DataBind()
    End Sub

    Private Sub DG_Facturas_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles DG_Facturas.PageIndexChanging
        DG_Facturas.PageIndex = e.NewPageIndex
        Cargar_Grilla()
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

    Private Sub DG_Pedido_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles DG_Pedido.RowDeleting
        Dim FacturaBaja As New PedidoCanceladoBE
        FacturaBaja.ID_Factura = DG_Pedido.Rows(e.RowIndex).Cells(5).Text

        mensaje = "Se atendió reclamo"
        ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & mensaje & "')", True)

        PedidoCanceladoBLL.ObtenerInstancia.Eliminar(FacturaBaja)


        ''Generar NC
        Dim Factura As FacturaCompletaBE = FacturaBLL.ObtenerInstancia.ObtenerFacturaCompPorID(FacturaBaja.ID_Factura)
        If Factura.Cancelada = "True" Then
            mensaje = "La Factura ya estaba cancelada, por favor eliga otra"
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & mensaje & "')", True)

        Else

            FacturaBLL.ObtenerInstancia.EliminarFactura(New FacturaBE With {.ID = FacturaBaja.ID_Factura})
            Dim ID_Factura As Integer = DG_Pedido.Rows(e.RowIndex).Cells(5).Text
            Dim NewFactura As FacturaCompletaBE = FacturaBLL.ObtenerInstancia.ObtenerFacturaCompPorID(ID_Factura)


            mensaje = "La Factura fue cancelada con exito"
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & mensaje & "')", True)

            Dim NC As New NotaCreditoBE
            NC.ID_Cliente = NewFactura.ID_Usuario
            NC.Fecha = DateTime.Now
            NC.Saldo = NewFactura.Total
            NC.Motivo = TB_Ingresar_Motivo.Text
            NC.Estado = "0"
            'Como es nueva el estado es 0, si la cancelo pasa el estado a 1

            NotaCreditoBLL.ObtenerInstancia.CrearNotaCredito(NC)

            RechazoCompraOK.ID_Cliente = NewFactura.ID_Usuario
            RechazoCompraOK.ID_Factura = DG_Pedido.Rows(e.RowIndex).Cells(5).Text
            'Se genera una NC
            RechazoCompraOK.Motivo = "Usuario rechaza una compra"
            RechazoCompraOK.Debito = "0"
            'No hay debito en la compra
            RechazoCompraOK.Credito = NewFactura.Total
            RechazoCompraOK.Fecha = DateTime.Now
            Dim ID_NC As Integer = NotaCreditoBLL.ObtenerInstancia.ObtenerIDNC().ID
            RechazoCompraOK.ID_NotaCredito = ID_NC
            RechazoCompraOK.Saldo = NewFactura.Total

            CuentaCorrienteBLL.ObtenerInstancia.CrearCCxNC(RechazoCompraOK)

            Dim NewNC As NotaCreditoCompletaBE = NotaCreditoBLL.ObtenerInstancia.ObtenerNCPorID(ID_NC)
            GestorPDF.ObtenerInstancia.ArmarPDF2(Response, Server.MapPath("Template_Mokar_NC.html"), NewNC, True)

            TB_Ingresar_Motivo.Text = ""
        End If

        Cargar_Grilla()
        Cargar_Grilla2()

    End Sub

    Private Sub btnConfirmar_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click
        Try
            Dim FacturaBaja As New FacturaBE
            FacturaBaja.ID = CType(Session("RowSelected"), GridViewRow).Cells(2).Text

            If TB_Ingresar_Motivo.Text = "" Then

                mensaje = "Debe ingresar un motivo de cancelación"
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & mensaje & "')", True)
                Cargar_Grilla()

            Else

                Dim Estado As String
                Estado = CType(Session("RowSelected"), GridViewRow).Cells(9).Text

                If Estado = "True" Then
                    mensaje = "La Factura ya estaba cancelada, por favor eliga otra"
                    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & mensaje & "')", True)

                Else

                    FacturaBLL.ObtenerInstancia.EliminarFactura(FacturaBaja)
                    Dim ID_Factura As Integer = FacturaBaja.ID
                    Dim NewFactura As FacturaCompletaBE = FacturaBLL.ObtenerInstancia.ObtenerFacturaCompPorID(ID_Factura)


                    mensaje = "La Factura fue cancelada con exito"
                    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & mensaje & "')", True)

                    Dim NC As New NotaCreditoBE
                    NC.ID_Cliente = NewFactura.ID_Usuario
                    NC.Fecha = DateTime.Now
                    NC.Saldo = NewFactura.Total
                    NC.Motivo = TB_Ingresar_Motivo.Text
                    NC.Estado = "0"
                    'Como es nueva el estado es 0, si la cancelo pasa el estado a 1

                    NotaCreditoBLL.ObtenerInstancia.CrearNotaCredito(NC)

                    RechazoCompraOK.ID_Cliente = NewFactura.ID_Usuario
                    RechazoCompraOK.ID_Factura = FacturaBaja.ID
                    'Se genera una NC
                    RechazoCompraOK.Motivo = "Usuario rechaza una compra"
                    RechazoCompraOK.Debito = "0"
                    'No hay debito en la compra
                    RechazoCompraOK.Credito = NewFactura.Total
                    RechazoCompraOK.Fecha = DateTime.Now
                    Dim ID_NC As Integer = NotaCreditoBLL.ObtenerInstancia.ObtenerIDNC().ID
                    RechazoCompraOK.ID_NotaCredito = ID_NC
                    RechazoCompraOK.Saldo = NewFactura.Total

                    CuentaCorrienteBLL.ObtenerInstancia.CrearCCxNC(RechazoCompraOK)

                    Dim NewNC As NotaCreditoCompletaBE = NotaCreditoBLL.ObtenerInstancia.ObtenerNCPorID(ID_NC)
                    GestorPDF.ObtenerInstancia.ArmarPDF2(Response, Server.MapPath("Template_Mokar_NC.html"), NewNC, True)

                    Cargar_Grilla()

                    TB_Ingresar_Motivo.Text = ""
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        contenido.Visible = False
    End Sub
End Class