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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not (Page.IsPostBack) Then

            Cargar_Grilla()
            Cargar_MdePago()
            Cargar_NC()


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
            LstCompras = Session("MisCompras")
            Dim Tarjetas As New EstadoTarjetaBE
            Tarjetas.Numero = Criptografia.ObtenerInstancia.EncriptarTarjeta(TB_NroTarjeta.Text)

            'Desencripto
            Dim Numerodes As String
            Numerodes = Criptografia.ObtenerInstancia.DesencriptarTarjeta(Tarjetas.Numero)

            'Validar si la tarjeta esta inhibida
            Dim TarjetaAnalisis As New EstadoTarjetaBE
            TarjetaAnalisis = EstadosTarjetasBLL.ObtenerInstancia.ObtenerPorNumero(Tarjetas.Numero)

            If TarjetaAnalisis.Cancelada = "0" Then

                mensaje = "Su compra fue registrada con exito"
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & mensaje & "')", True)

            Else

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

            If Lbl_NewSaldo.Text = "" Then
                Tarjetas.Monto = TB_Total.Text
            Else
                Tarjetas.Monto = Lbl_NewSaldo.Text

            End If

            If Lbl_Tarjeta.Text = "VISA" Then
                Tarjetas.ID_Tarjeta = "1"
            ElseIf Lbl_Tarjeta.Text = "MASTER" Then
                Tarjetas.ID_Tarjeta = "2"
            ElseIf Lbl_Tarjeta.Text = "AMERICAN" Then
                Tarjetas.ID_Tarjeta = "3"
            End If

            EstadosTarjetasBLL.ObtenerInstancia.CrearTarjeta(Tarjetas)

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
            Factura.Seguimiento = "En curso"

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

            Response.Redirect("FichaOpinion.aspx")
        Catch ex As Exception
            mensaje = "Easy Travel informa: " & ex.Message
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & mensaje & "')", True)
        End Try

    End Sub

    Private Sub DG_CC_SelectedIndexChanging(sender As Object, e As GridViewSelectEventArgs) Handles DG_CC.SelectedIndexChanging
        Try
            Dim Credito As Double
            Dim resultado As Double
            Dim Numero As Integer
            Dim IDNC As New NotaCreditoBE

            Numero = DG_CC.Rows(e.NewSelectedIndex).Cells(1).Text
            Session("ID_CC") = Numero
            'Obtengo el numero de Cuenta Corriente

            resultado = Calculo((CInt(TB_Precio.Text)), (CInt(TB_Pasajeros.Text)))
            Credito = DG_CC.Rows(e.NewSelectedIndex).Cells(7).Text
            Session("Saldo") = Credito
            IDNC.ID = DG_CC.Rows(e.NewSelectedIndex).Cells(5).Text
            Session("IDNC") = IDNC.ID
            Lbl_NewSaldo.Text = resultado - Credito

        Catch ex As Exception
            mensaje = "Easy Travel informa: " & ex.Message
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & mensaje & "')", True)
        End Try

    End Sub

    Private Sub btn_Confirmar_Click(sender As Object, e As EventArgs) Handles btn_Confirmar.Click
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
            GestorPDF.ObtenerInstancia.ArmarPDF(Response, Server.MapPath("Template_EasyTravel_Factura2.html"), NewFactura, True)

            mensaje = "Su compra fue registrada con exito"
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & mensaje & "')", True)
        Catch ex As Exception
            mensaje = "Easy Travel informa: " & ex.Message
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & mensaje & "')", True)
        End Try

    End Sub

    Private Sub btn_Continuar_Click(sender As Object, e As EventArgs) Handles btn_Continuar.Click
        DIV_MdePago.Visible = True
        TB_Pasajeros.Enabled = False
    End Sub


End Class