<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="MisCompras.aspx.vb" Inherits="GUI.MisOfertas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        //Expiración de la TC
        function ValidarExp() {
            var mes = document.getElementById("TB_MesVencimiento").value;
            var anio = document.getElementById("TB_AñoVencimiento").value;
            var img = document.getElementById("imgTCExp");
            img.style.visibility = "hidden";
            if (mes.length === 2 && anio.length === 2) {
                var expDate = mes + anio;
                //console.log(expDate);
                var hoy = new Date();
                var hoy_mm = hoy.getMonth() + 1;
                var hoy_yy = hoy.getFullYear() % 100;
                if (hoy_mm < 10) {
                    hoy_mm = '0' + hoy_mm
                }
                var mm = expDate.substring(0, 2);
                console.log(mm);
                var yy = expDate.substring(2);
                console.log(yy);
                if (yy > hoy_yy || (yy == hoy_yy && mm >= hoy_mm)) {
                    //console.log("todo bien");
                    img.src = "Images/tick.png"
                    img.style.visibility = "visible";
                }
                else {
                    //console.log("todo mal");
                    img.src = "Images/cross.png"
                    img.style.visibility = "visible";
                    result = false;
                }
            } else {
                img.src = "Images/cross.png"
                img.style.visibility = "visible";
                return false;
            }
        }
    </script>

    <section id="portfolio" class="section-bg">
        <div class="container">
            <br />
            <br />
            <br />
            <h3>Mis Ofertas</h3>

            <div class="row">
                <div class="card-body">
                    <div class="card card-body">
                        <div class="mr-0">
                            <div class="row">
                                <div class="form-inline">
                                    <div class="col-3">
                                        <asp:Image ID="Image1" runat="server" Width="100px" Height="80px" ImageUrl='<%#"data:Image/png;base64," + Convert.ToBase64String(Eval("ImagenData")) %>' />
                                    </div>
                                    <div class="col-3">
                                        <asp:TextBox ID="TB_Nombre" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                    </div>
                                    <div class="col-3">
                                        <asp:TextBox ID="TB_Region" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                    </div>
                                    <div class="col-3">
                                        <asp:TextBox ID="TB_Precio" runat="server" CssClass="form-control" Enabled="false" Type="money"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-3">
                                    <asp:Label ID="Lbl_Pasajeros" runat="server" Text="Ingresa la cantidad de usuarios:"></asp:Label>
                                    <asp:TextBox ID="TB_Pasajeros" runat="server" CssClass="form-control" Type="number"></asp:TextBox>

                                    <asp:RegularExpressionValidator ID="RE_TB_Pasajeros" runat="server" ErrorMessage="Ingrese un número mayor a cero" ControlToValidate="TB_Pasajeros"
                                        ValidationExpression="^[0-9]{1,2}" ForeColor="Red" Font-Bold="true"></asp:RegularExpressionValidator>
                                </div>
                                <div class="col-sm-3">
                                    <asp:Label ID="Lbl_Total" runat="server" Text="Total a Pagar:"></asp:Label>
                                    <asp:TextBox ID="TB_Total" runat="server" CssClass="form-control" Type="number" Enabled="false"></asp:TextBox>
                                </div>
                                <div class="col-sm-3">
                                    <asp:Button CssClass="btn  btn-primary" ID="btn_Continuar" runat="server" Text="Continuar" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <!-- PARTE NUEVA -->
            <div class="row" runat="server" id="MediosDePago" visible="false"> 
                <div class="card-body">
                    <div class="card card-body">
                        <div class="mr-0">
                            <div style="text-align: center">
                                <h3>Forma de pago</h3>
                                <asp:Panel runat="server" ID="Panel1" CssClass="ml-2">
                                    <div class="col-12">
                                        <div class="card-body">
                                            <div class="card card-body">
                                                <div class="row">
                                                    <div class="col-6">
                                                        <asp:Label ID="totPagar" runat="server" Text="Total a pagar: $ "></asp:Label>
                                                    </div>
                                                    <div class="col-6">
                                                        <asp:Label ID="totPendiente" runat="server" Text="Pendiente: $ "></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-3">
                                                    <asp:Button ID="btnAgregarTC" CssClass="btn btn-primary" runat="server" Text="Agregar TC" OnClick="btnAgregarTC_Click" />
                                                        </div>
                                                    <div class="col-3">
                                                    <asp:Button ID="btnAgregarNC" CssClass="btn btn-primary" runat="server" Text="Agregar NC" OnClick="btnAgregarNC_Click"/>
                                                        </div>
                                                    <div class="col-3"></div>
                                                    <div class="col-3">
                                                    <asp:Button ID="btnConfirmarPago" CssClass="btn btn-primary" runat="server" OnClientClick="return confirm('Está seguro de confirmar la acción?');" Text="Confirmar" />
                                                    </div>
                                                </div>
                                                <br />
                                                <div class="row">
                                                    <asp:GridView ID="DG_Pagos" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="20">
                                                        <Columns>
                                                            <asp:BoundField DataField="medio" HeaderText="Medio" />
                                                            <asp:BoundField DataField="monto" HeaderText="Monto" DataFormatString="{0:C}" />
                                                            <asp:TemplateField ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Delete" ImageUrl="~/img/delete.png" Text="Delete" OnClientClick="return confirm('Está seguro de realizar la acción?');" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </asp:Panel>
                            </div>
                        </div>
                    </div>
                </div>
            </div>





            <div class="row" runat="server" id="DIV_MdePago">
                <div class="col-sm-3">
                    <asp:Label ID="Lbl_MdePago" runat="server" Text="Selecciona un medio de pago:"></asp:Label>
                    <asp:DropDownList ID="DDL_MdePago" runat="server" CssClass="form-control" AutoPostBack="True" required="required"></asp:DropDownList>
                </div>
                <div class="col-sm-5">
                    Resto a abonar: $<asp:Label ID="Lbl_NewSaldo" runat="server"></asp:Label>
                    Seleccione medio de pago 
                </div>
            </div>

            <asp:Panel runat="server" ID="Panel_NC" CssClass="ml-2" Visible="false">
                <div class="col-12">
                    <div class="card-body">
                        <div class="card card-body">

                            <asp:GridView ID="DG_CC" CssClass="table table-bordered" DataKeyNames="ID" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="20">
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" ButtonType="Button" HeaderText="Seleccionar" ControlStyle-CssClass="btn btn-primary" ControlStyle-Width="100px" ControlStyle-Height="40px" />
                                    <asp:BoundField DataField="ID" HeaderText="Nro. CC" />
                                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                                    <asp:BoundField DataField="Motivo" HeaderText="Motivo" />
                                    <asp:BoundField DataField="ID_Factura" HeaderText="Nro. Factura" />
                                    <asp:BoundField DataField="ID_NotaCredito" HeaderText="Nro. Nota Credito" />
                                    <asp:BoundField DataField="Debito" HeaderText="Debito" DataFormatString="{0:C}" />
                                    <asp:BoundField DataField="Credito" HeaderText="Credito" DataFormatString="{0:C}" />
                                    <%-- <asp:BoundField DataField="Saldo" HeaderText="Saldo" DataFormatString="{0:C}" />--%>
                                </Columns>
                            </asp:GridView>


                            <div class="row">
                                <asp:Button CssClass="btn btn-success" Text="Cancelar" runat="server" ID="btn_CancelarNC" />
                            </div>
                        </div>
                    </div>
                </div>

            </asp:Panel>

            <br />
            <div class="row">
                <asp:Panel runat="server" ID="Panel_SeleccionDeTarjeta" CssClass="ml-2" Visible="false">
                    <div class="row ml-2">
                        <asp:Label ID="Lbl_SelecTarjeta" runat="server" Text="Selecciona una Tarjeta:"></asp:Label>
                    </div>
                    <div class="row">
                        <div class="ml-4">
                            <asp:ImageButton ID="btn_Visa" runat="server" src="img/Tarjeta_Visa.png" CssClass="my-3" popupbuttonid="btnvisa" Width="70px" Height="50px" BorderStyle="Groove" />
                        </div>
                        <div class="ml-2">
                            <asp:ImageButton ID="btn_Master" runat="server" src="img/Tarjeta_Master.png" CssClass="my-3" popupbuttonid="btnmaster" Width="70px" Height="50px" BorderStyle="Groove" />
                        </div>
                        <div class="ml-2">
                            <asp:ImageButton ID="btn_American" runat="server" src="img/Tarjeta_American.jpg" CssClass="my-3" popupbuttonid="btnamerican" Width="70px" Height="50px" BorderStyle="Groove" />
                        </div>
                    </div>
                </asp:Panel>
            </div>



            <asp:Panel ID="Panel_Tarjeta" runat="server" Visible="false">
                <div class="row">
                    <div class="card-body">
                        <div class="card card-body">
                            <div class="mr-0">
                                <div style="text-align: center">
                                    <h3>Gestion de pago</h3>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <!-- CREDIT CARD FORM STARTS HERE -->

                                        <div class="panel-heading display-table">
                                            <div class="row display-tr">
                                                <h3 class="panel-title display-td">Detalle de pago</h3>
                                                <div class="display-td">
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-8">
                                                <div class="form-group">
                                                    <label>Nombre del Titular</label>
                                                    <asp:TextBox ID="TB_NombreTitular" runat="server" CssClass="form-control" required="required" type="text" Width="600" MaxLength="100"></asp:TextBox>

                                                    <asp:RegularExpressionValidator ID="RE_TB_NombreTitular" runat="server" ErrorMessage="Ingrese el formato correcto" ControlToValidate="TB_NombreTitular"
                                                        ValidationExpression="^[a-zA-Z\s]{10,30}$" ForeColor="Red" Font-Bold="true" Enabled="false"></asp:RegularExpressionValidator>

                                                    <label>Ingrese el numero de su tarjeta </label>
                                                    <asp:Label ID="Lbl_Tarjeta" runat="server"></asp:Label>
                                                    <asp:TextBox ID="TB_NroTarjeta" runat="server" CssClass="form-control" required="required" Width="600" MaxLength="16"></asp:TextBox>

                                                    <asp:RegularExpressionValidator ID="RE_Visa" runat="server" ErrorMessage="Nro invalido para Visa" ControlToValidate="TB_NroTarjeta"
                                                        ValidationExpression="^4\d{3}-?\d{4}-?\d{4}-?\d{4}$" ForeColor="Red" Font-Bold="true" Enabled="false"></asp:RegularExpressionValidator>

                                                    <asp:RegularExpressionValidator ID="RE_Master" runat="server" ErrorMessage="Nro invalido para Master" ControlToValidate="TB_NroTarjeta"
                                                        ValidationExpression="^5[1-5]\d{2}-?\d{4}-?\d{4}-?\d{4}$" ForeColor="Red" Font-Bold="true" Enabled="false"></asp:RegularExpressionValidator>

                                                    <asp:RegularExpressionValidator ID="RE_American" runat="server" ErrorMessage="Nro invalido para American" ControlToValidate="TB_NroTarjeta"
                                                        ValidationExpression="^3[47][0-9]{13}$" ForeColor="Red" Font-Bold="true" Enabled="false"></asp:RegularExpressionValidator>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-8">
                                                <div class="form-group">

                                                    <label>Vencimiento:</label>

                                                    <div class="row">
                                                        <div class="form-inline"></div>
                                                        <div class="col">
                                                            <label>Ingrese el mes:</label>
                                                            <asp:TextBox ID="TB_MesVencimiento" runat="server" min="00" max="12" CssClass="form-control" required="required" Width="80px" Type="number"></asp:TextBox>
                                                            <%--                                                   <asp:RegularExpressionValidator ID="RE_TBMesVencimiento" runat="server" ErrorMessage="Ingrese un mes valido, mediante 2 digitos" ControlToValidate="TB_MesVencimiento"
                                                        ValidationExpression="^[1-12]{2}$" ForeColor="Red" Font-Bold="true"></asp:RegularExpressionValidator>--%>
                                                        </div>
                                                        <div class="col">
                                                            <label>Ingrese el año:</label>
                                                            <asp:TextBox ID="TB_AñoVencimiento" runat="server" min="19" max="99" step="1" CssClass="form-control" required="required" Width="80px" Type="number"></asp:TextBox>
                                                            <%--                                                    <asp:RegularExpressionValidator ID="RE_TBAñoVencimiento" runat="server" ErrorMessage="Ingrese un año válido, mediante 2 digitos" ControlToValidate="TB_AñoVencimiento"
                                                        ValidationExpression="[18-99]{2}$" ForeColor="Red" Font-Bold="true"></asp:RegularExpressionValidator>--%>
                                                        </div>
                                                    </div>
                                                </div>

                                                <label>Codigo de seguridad:</label>
                                                <asp:TextBox ID="TB_CodSeg" runat="server" CssClass="form-control" required="required" MaxLength="3"></asp:TextBox>

                                                <asp:RegularExpressionValidator ID="RE_TB_CodSeg" runat="server" ErrorMessage="Ingrese un número válido" ControlToValidate="TB_CodSeg"
                                                    ValidationExpression="^[0-9]{3}$" ForeColor="Red" Font-Bold="true"></asp:RegularExpressionValidator>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <asp:Label ID="Label1" runat="server" Text="Monto: $ "></asp:Label>
                                            <asp:TextBox ID="txtMontoTC" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-6">
                                    <asp:Button CssClass="btn btn-success" Text="Enviar" runat="server" ID="btn_EnviarPago" />
                                </div>
                                <div class="col-6">
                                    <asp:Button CssClass="btn btn-success" Text="Cancelar" runat="server" ID="btn_Cancelar" />
                                </div>
                            </div>

                        </div>

                        <!-- CREDIT CARD FORM ENDS HERE -->

                    </div>
                </div>

            </asp:Panel>


        </div>
    </section>


</asp:Content>
