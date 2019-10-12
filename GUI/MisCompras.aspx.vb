Imports BE
Imports BLL

Public Class MisOfertas
    Inherits System.Web.UI.Page

    Private ValidarTarjeta As Boolean = False
    Dim mensaje As String
    Dim LstCompras As New List(Of ServiciosBE)
    Dim Detalle As New FacturaDetalleBE
    Dim CompraOK As New CuentaCorrienteBE
    Dim Factura As New FacturaBE
    Dim Usuario As New UsuarioBE
    Dim NotaCreditoObtenida As New List(Of NotaCreditoBE)
    Dim CCObtenidas As New List(Of CuentaCorrienteBE)
    Dim numero As Double
    Dim dtPagos As New DataTable
    Dim listPagos As New List(Of BE.MedioPago)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not (Page.IsPostBack) Then

            Cargar_Grilla()
            Cargar_MdePago()
            Cargar_NC()
            Session("ListPagos") = Nothing

            DIV_MdePago.Visible = False
        End If
    End Sub

    Public Sub Cargar_Grilla()
        LstCompras = Session("MisCompras")
        TB_Nombre.Text = LstCompras.Item(0).nombre
        'TB_Precio.Text = "$ " + LstCompras.Item(0).Precio
        TB_Precio.Text = LstCompras.Item(0).precio
        TB_Region.Text = LstCompras.Item(0).descripcion
        Dim StgBase64 As String = Convert.ToBase64String(LstCompras.Item(0).imagenData)
        Image1.ImageUrl = "data:Image/png;base64," + StgBase64
    End Sub

    Public Sub Cargar_MdePago()
        DDL_MdePago.Items.Clear()
        DDL_MdePago.AppendDataBoundItems = True
        DDL_MdePago.Items.Add("Seleccione una categoria")
        DDL_MdePago.DataSource = Nothing
        DDL_MdePago.DataSource = GestorMdePagoBLL.ObtenerInstancia.ListarMdePago
        DDL_MdePago.DataTextField = "Descripcion"
        DDL_MdePago.DataValueField = "ID"
        DDL_MdePago.DataBind()

    End Sub

    Public Sub Cargar_NC()
        Usuario = GestorSesion.ObtenerSesionActual.UsuarioActivo
        Session("UsuarioActivo") = Usuario

        CCObtenidas = CuentaCorrienteBLL.ObtenerInstancia.ObtenerPorIDUser1(Usuario.idUsuario)

        DG_CC.DataSource = Nothing
        DG_CC.DataSource = CCObtenidas
        DG_CC.DataBind()

    End Sub


    Public Function Calculo(ByVal a As Integer, ByVal b As Integer) As Integer
        Dim rst As Integer
        rst = a * b
        Return rst
    End Function

    Public Function Calculo2(ByVal a As Integer, ByVal b As Integer) As Integer
        Dim rst As Integer
        rst = a - b
        Return rst
    End Function

    Private Sub TB_Pasajeros_TextChanged(sender As Object, e As EventArgs) Handles TB_Pasajeros.TextChanged
        totPagar.Text = "Total a pagar: $ " & Calculo((CInt(TB_Precio.Text)), (CInt(TB_Pasajeros.Text)))
        TB_Total.Text = Calculo((CInt(TB_Precio.Text)), (CInt(TB_Pasajeros.Text)))
    End Sub

    Private Sub DDL_MdePago_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDL_MdePago.SelectedIndexChanged
        Try
            If DDL_MdePago.SelectedItem.Text = "Tarjeta de credito" Then
                Panel_SeleccionDeTarjeta.Visible = True
                Panel_NC.Visible = False
                Limpiar_TB()
            Else
                If DDL_MdePago.SelectedItem.Text = "Nota de credito" Then
                    Panel_SeleccionDeTarjeta.Visible = False
                    Panel_NC.Visible = True
                Else
                    If DDL_MdePago.SelectedItem.Text = "Nota y Tarjeta de Credito" Then
                        Panel_SeleccionDeTarjeta.Visible = True
                        Panel_NC.Visible = True
                    End If
                End If
            End If
        Catch ex As Exception
            mensaje = "Easy Travel informa: " & ex.Message
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & mensaje & "')", True)
        End Try
    End Sub

    Private Sub Limpiar_TB()
        TB_NombreTitular.Text = ""
        TB_NroTarjeta.Text = ""
        TB_CodSeg.Text = ""
        TB_AñoVencimiento.Text = ""
        TB_MesVencimiento.Text = ""
    End Sub

    Private Sub btn_Visa_Click(sender As Object, e As ImageClickEventArgs) Handles btn_Visa.Click
        Panel_Tarjeta.Visible = True
        RE_Visa.Enabled = True
        Lbl_Tarjeta.Text = "VISA"
    End Sub
    Private Sub btn_Master_Click(sender As Object, e As ImageClickEventArgs) Handles btn_Master.Click
        Panel_Tarjeta.Visible = True
        RE_Master.Enabled = True
        Lbl_Tarjeta.Text = "MASTER"
    End Sub
    Private Sub btn_American_Click(sender As Object, e As ImageClickEventArgs) Handles btn_American.Click
        Panel_Tarjeta.Visible = True
        RE_American.Enabled = True
        Lbl_Tarjeta.Text = "AMERICAN"
    End Sub
    Private Sub btn_EnviarPago_Click(sender As Object, e As EventArgs) Handles btn_EnviarPago.Click
        Try
            Dim Tarjetas As New EstadoTarjetaBE
            Tarjetas.Numero = Criptografia.ObtenerInstancia.EncriptarTarjeta(TB_NroTarjeta.Text)

            'Desencripto
            Dim Numerodes As String
            Numerodes = Criptografia.ObtenerInstancia.DesencriptarTarjeta(Tarjetas.Numero)

            'Validar si la tarjeta esta inhibida
            Dim TarjetaAnalisis As New EstadoTarjetaBE
            TarjetaAnalisis = EstadosTarjetasBLL.ObtenerInstancia.ObtenerPorNumero(Tarjetas.Numero)

            If TarjetaAnalisis.Cancelada = "1" Then
                mensaje = "La tarjeta que intenta untilizar se encuentra bloqueada, consulte a su banco o vuelva a intentarlo con otra tarjeta"
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & mensaje & "')", True)

                btn_EnviarPago.Visible = False
                Panel_SeleccionDeTarjeta.Visible = False
                Panel_Tarjeta.Visible = False

                Response.Redirect("MisCompras.aspx")
            End If

            Tarjetas.Nombre = TB_NombreTitular.Text
            Tarjetas.CodSeguridad = TB_CodSeg.Text
            Tarjetas.MesVencimiento = TB_MesVencimiento.Text
            Tarjetas.AñoVencimiento = TB_AñoVencimiento.Text
            Tarjetas.Monto = txtMontoTC.Text

            If Lbl_Tarjeta.Text = "VISA" Then
                Tarjetas.ID_Tarjeta = "1"
            ElseIf Lbl_Tarjeta.Text = "MASTER" Then
                Tarjetas.ID_Tarjeta = "2"
            ElseIf Lbl_Tarjeta.Text = "AMERICAN" Then
                Tarjetas.ID_Tarjeta = "3"
            End If

            listPagos = Session("ListPagos")

            If listPagos Is Nothing Then
                listPagos = New List(Of MedioPago)
            End If
            listPagos.Add(Tarjetas)
            Session("ListPagos") = listPagos

            actualizarListaPagos()

            Panel_Tarjeta.Visible = False
            Panel_SeleccionDeTarjeta.Visible = False
            MediosDePago.Visible = True

        Catch ex As Exception

        End Try


    End Sub

    Sub actualizarListaPagos()
        Try
            Dim montoPendiente As Integer = totPagar.Text.Split("$ ")(1)

            listPagos = Session("ListPagos")

            Dim dtPagos As New DataTable
            dtPagos.Columns.Add(New DataColumn("medio"))
            dtPagos.Columns.Add(New DataColumn("monto"))
            For Each a As MedioPago In listPagos
                Dim drow As DataRow = dtPagos.NewRow()

                If a.GetType() Is GetType(BE.NotaCreditoBE) Then
                    drow(0) = "Nota de Credito"
                    drow(1) = CType(a, BE.NotaCreditoBE).Saldo
                    montoPendiente = montoPendiente - CType(a, BE.NotaCreditoBE).Saldo
                ElseIf a.GetType() Is GetType(BE.EstadoTarjetaBE) Then
                    drow(0) = "Tarjeta de Credito"
                    drow(1) = CType(a, BE.EstadoTarjetaBE).Monto
                    montoPendiente = montoPendiente - CType(a, BE.EstadoTarjetaBE).Monto
                End If
                dtPagos.Rows.Add(drow)
            Next

            DG_Pagos.DataSource = Nothing
            DG_Pagos.DataSource = dtPagos
            DG_Pagos.DataBind()

            totPendiente.Text = "Pendiente: $ " & montoPendiente
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DG_CC_SelectedIndexChanging(sender As Object, e As GridViewSelectEventArgs) Handles DG_CC.SelectedIndexChanging
        Try
            Dim IDNC As New NotaCreditoBE

            IDNC.ID = DG_CC.Rows(e.NewSelectedIndex).Cells(5).Text
            IDNC.Saldo = DG_CC.Rows(e.NewSelectedIndex).Cells(7).Text

            listPagos = Session("ListPagos")

            If listPagos Is Nothing Then
                listPagos = New List(Of MedioPago)
            Else
                Dim seleccionada As Boolean = False
                For Each a As MedioPago In listPagos
                    If CType(a, NotaCreditoBE).ID = IDNC.ID Then
                        seleccionada = True
                    End If
                Next
                If seleccionada Then
                    mensaje = "Ya selecciono la NC previamente"
                    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & mensaje & "')", True)
                    Exit Sub
                End If
            End If

            listPagos.Add(IDNC)
            Session("ListPagos") = listPagos

            actualizarListaPagos()

            Panel_NC.Visible = False
            MediosDePago.Visible = True

        Catch ex As Exception
            mensaje = "Easy Travel informa: " & ex.Message
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & mensaje & "')", True)
        End Try

    End Sub

    Private Sub btn_Confirmar_Click(sender As Object, e As EventArgs)
        Try
            Dim Saldo As New CuentaCorrienteBE
            'La Session ("Saldo") es el de mi NC
            Saldo.Credito = Session("Saldo")
            Saldo.ID = Session("ID_CC")


            If TB_Total.Text > Saldo.Credito Then
                'Entra cuando el saldo es mayor al de mi NC
                'Consumo la NC mandando el saldo en 0
                Saldo.Credito = Calculo2(TB_Total.Text, Saldo.Credito)
                Session("Resto") = Saldo.Credito
                'El la Session ("Resto") guardo el Nuevo total que es el TB_Total - la NC. 
                Saldo.Credito = 0
                CuentaCorrienteBLL.ObtenerInstancia.ActualizarSaldo(Saldo)
                'vuelvo a cargar las NC
                Cargar_NC()
                'Ojo, si aparece otra la debería pagar con otra NC sobre el saldo real.

                mensaje = "El saldo restante lo quiere abonoar con Tarjeta de crédito? seleccione el medio de pago"
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & mensaje & "')", True)

                Panel_NC.Visible = False
                DDL_MdePago.SelectedIndex = 0

            ElseIf TB_Total.Text = Saldo.Credito Then

                Facturar()

                Response.Redirect("FichaOpinion.aspx")
            ElseIf TB_Total.Text < Saldo.Credito Then
                'Mi NC es mayor a lo que tengo que pagar, significa que me queda vuelto y lo guardo.
                Saldo.Credito = Calculo2(Saldo.Credito, TB_Total.Text)
                Session("NewSaldo") = Saldo.Credito
                Saldo.Credito = 0
                CuentaCorrienteBLL.ObtenerInstancia.ActualizarSaldo(Saldo)

                'Este nuevo Saldo debería generar una nueva NC, por ahora queda como saldo a favor.

                Facturar()

                Dim NC As New NotaCreditoBE
                NC.ID_Cliente = Usuario.idUsuario
                NC.Fecha = DateTime.Now
                NC.Saldo = Session("NewSaldo")
                NC.Motivo = "Nota de credito adicional"
                NC.Estado = "0"
                'Como es nueva el estado es 0, si la cancelo pasa el estado a 1

                NotaCreditoBLL.ObtenerInstancia.CrearNotaCredito(NC)

                Dim RechazoCompraOK As New CuentaCorrienteBE

                RechazoCompraOK.ID_Cliente = Usuario.idUsuario
                RechazoCompraOK.ID_Factura = Session("IDNC")
                'Se genera una NC
                RechazoCompraOK.Motivo = "Nota de credito adicional por Saldo de una anterior, NC nro.:" & RechazoCompraOK.ID_Factura
                RechazoCompraOK.Debito = "0"
                'No hay debito en la compra
                RechazoCompraOK.Credito = Session("NewSaldo")
                RechazoCompraOK.Fecha = DateTime.Now
                Dim ID_NC As Integer = NotaCreditoBLL.ObtenerInstancia.ObtenerIDNC().ID
                RechazoCompraOK.ID_NotaCredito = ID_NC
                RechazoCompraOK.Saldo = Session("NewSaldo")

                CuentaCorrienteBLL.ObtenerInstancia.CrearCCxNC(RechazoCompraOK)

                Dim NewNC As New NotaCreditoCompletaBE
                NewNC.ID_Factura = Session("IDNC")
                NewNC.ID_Usuario = Usuario.idUsuario
                NewNC.NombrePais = TB_Nombre.Text & " - " & TB_Region.Text
                NewNC.PrecioUnitario = TB_Precio.Text
                NewNC.Total = Session("NewSaldo")
                NewNC.Usuario = Usuario.mail
                NewNC.Fecha = DateTime.Now
                NewNC.Descripcion = "Nota de credito adicional por Saldo de una anterior, NC nro.:" & RechazoCompraOK.ID_Factura
                NewNC.Cantidad = "1"
                NewNC.Apellido = ""
                NewNC.Nombre = Usuario.nombreRazonSocial
                NewNC.ID = ID_NC


                GestorPDF.ObtenerInstancia.ArmarPDF2(Response, Server.MapPath("Template_EasyTravel_NC.html"), NewNC, True)

                Response.Redirect("FichaOpinion.aspx")
            End If
        Catch ex As Exception
            mensaje = "Easy Travel informa: " & ex.Message
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & mensaje & "')", True)
        End Try

    End Sub

    Private Sub Facturar()
        Try
            LstCompras = Session("MisCompras")

            Usuario = Session("UsuarioActivo")

            Factura.ID_Usuario = Usuario.idUsuario
            Factura.Nombre = Usuario.nombreRazonSocial
            Factura.Apellido = ""
            Factura.Usuario = Usuario.mail
            Factura.Descripcion = LstCompras.Item(0).descripcion
            Factura.Fecha = DateTime.Now
            Factura.Total = TB_Total.Text
            Factura.Cancelada = "0"
            'No esta cancelada, si se cancela, cambia el estado a 1

            FacturaBLL.ObtenerInstancia.CrearFactura(Factura)

            Detalle.ID_Factura = Factura.ID
            Detalle.ID_Oferta = LstCompras.Item(0).idServicio
            Detalle.Cantidad = TB_Pasajeros.Text
            Detalle.PrecioUnitario = LstCompras.Item(0).precio

            FacturaDetalleBLL.ObtenerInstancia.CrearFactura(Detalle)

            CompraOK.ID_Cliente = Usuario.idUsuario
            CompraOK.ID_Factura = Factura.ID
            CompraOK.ID_NotaCredito = "0"
            'No se genera una nota de credito hasta que no devuelva algo
            CompraOK.Motivo = "Se realizo una compra"
            CompraOK.Debito = TB_Total.Text
            'No hay debito en la compra
            CompraOK.Credito = "0"
            CompraOK.Fecha = DateTime.Now

            CuentaCorrienteBLL.ObtenerInstancia.CrearCC(CompraOK)

            Dim ID_Factura As Integer = FacturaBLL.ObtenerInstancia.ObtenerIDFactura().ID

            Dim NewFactura As FacturaCompletaBE = FacturaBLL.ObtenerInstancia.ObtenerFacturaCompPorID(ID_Factura)
            GestorPDF.ObtenerInstancia.ArmarPDF(Response, Server.MapPath("Template_Mokar_Factura2.html"), NewFactura, True)

            mensaje = "Su compra fue registrada con exito"
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & mensaje & "')", True)
        Catch ex As Exception
            mensaje = "Easy Travel informa: " & ex.Message
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & mensaje & "')", True)
        End Try

    End Sub

    Private Sub btn_Continuar_Click(sender As Object, e As EventArgs) Handles btn_Continuar.Click
        MediosDePago.Visible = True
        TB_Pasajeros.Enabled = False
        btn_Continuar.Enabled = False
        totPendiente.Text = "Pendiente: $ " & totPagar.Text
    End Sub

    Protected Sub btnAgregarTC_Click(sender As Object, e As EventArgs)
        Try
            Panel_SeleccionDeTarjeta.Visible = True
            Panel_NC.Visible = False
            Limpiar_TB()
            MediosDePago.Visible = False
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnAgregarNC_Click(sender As Object, e As EventArgs) Handles btnAgregarNC.Click
        Try
            Panel_SeleccionDeTarjeta.Visible = False
            Panel_NC.Visible = True
            MediosDePago.Visible = False
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btn_Cancelar_Click(sender As Object, e As EventArgs) Handles btn_Cancelar.Click
        Panel_Tarjeta.Visible = False
        MediosDePago.Visible = True
    End Sub

    Protected Sub btn_CancelarNC_Click(sender As Object, e As EventArgs) Handles btn_CancelarNC.Click
        Panel_NC.Visible = False
        MediosDePago.Visible = True
    End Sub

    Protected Sub btnConfirmarPago_Click(sender As Object, e As EventArgs) Handles btnConfirmarPago.Click
        Try
            Dim montoPendiente As Integer = totPendiente.Text.Split("$ ")(1)

            If montoPendiente > 0 Then
                mensaje = "No cubre el total a pagar. Por favor, ingrese los medios de pago correspondientes"
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & mensaje & "')", True)

            ElseIf montoPendiente = 0 Then

                Facturar()

                Response.Redirect("FichaOpinion.aspx")

            ElseIf montoPendiente < 0 Then

                Session("NewSaldo") = montoPendiente * (-1)

                Facturar()

                Dim NC As New NotaCreditoBE
                NC.ID_Cliente = Usuario.idUsuario
                NC.Fecha = DateTime.Now
                NC.Saldo = Session("NewSaldo")
                NC.Motivo = "Nota de credito adicional"
                NC.Estado = "0"
                'Como es nueva el estado es 0, si la cancelo pasa el estado a 1

                NotaCreditoBLL.ObtenerInstancia.CrearNotaCredito(NC)

                Dim RechazoCompraOK As New CuentaCorrienteBE

                RechazoCompraOK.ID_Cliente = Usuario.idUsuario
                RechazoCompraOK.ID_Factura = Session("IDNC")
                'Se genera una NC
                RechazoCompraOK.Motivo = "Nota de credito adicional por Saldo de una anterior, NC nro.:" & RechazoCompraOK.ID_Factura
                RechazoCompraOK.Debito = "0"
                'No hay debito en la compra
                RechazoCompraOK.Credito = Session("NewSaldo")
                RechazoCompraOK.Fecha = DateTime.Now
                Dim ID_NC As Integer = NotaCreditoBLL.ObtenerInstancia.ObtenerIDNC().ID
                RechazoCompraOK.ID_NotaCredito = ID_NC
                RechazoCompraOK.Saldo = Session("NewSaldo")

                CuentaCorrienteBLL.ObtenerInstancia.CrearCCxNC(RechazoCompraOK)

                Dim NewNC As New NotaCreditoCompletaBE
                NewNC.ID_Factura = Session("IDNC")
                NewNC.ID_Usuario = Usuario.idUsuario
                NewNC.NombrePais = TB_Nombre.Text & " - " & TB_Region.Text
                NewNC.PrecioUnitario = TB_Precio.Text
                NewNC.Total = Session("NewSaldo")
                NewNC.Usuario = Usuario.mail
                NewNC.Fecha = DateTime.Now
                NewNC.Descripcion = "Nota de credito adicional por Saldo de una anterior, NC nro.:" & RechazoCompraOK.ID_Factura
                NewNC.Cantidad = "1"
                NewNC.Apellido = ""
                NewNC.Nombre = Usuario.nombreRazonSocial
                NewNC.ID = ID_NC


                GestorPDF.ObtenerInstancia.ArmarPDF2(Response, Server.MapPath("Template_Mokar_NC.html"), NewNC, True)

                Response.Redirect("FichaOpinion.aspx")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DG_Pagos_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles DG_Pagos.RowDeleting
        Try
            listPagos = Session("ListPagos")
            For a As Integer = 0 To listPagos.Count - 1
                If a = e.RowIndex Then
                    listPagos.RemoveAt(a)
                End If
            Next
            actualizarListaPagos()
        Catch ex As Exception

        End Try
    End Sub
End Class