<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="Servicios.aspx.vb" Inherits="GUI.Servicios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript">
        var itemList = [];

        function AddToCompare(itemId) {

            var found = false;
            for (var i = itemList.length - 1; 0 < i + 1 && !found; --i) {

                if (itemList[i] == itemId) {
                    itemList.splice(i, 1);
                    //found = true;
                }
            }

            if (!found) {
                itemList.push(itemId);
            }

            //Asigno al hidden input la variable para poder levantarla desde el code behind
            document.getElementById('<%= hiddenItemCompare.ClientID %>').value = itemList;
        }

        var itemList2 = [];
        function AddToBuy(itemId) {
            
             var found = false;
            for (var i = itemList2.length - 1; 0 < i + 1 && !found; --i) {

                if (itemList2[i] == itemId) {
                    itemList2.splice(i, 1);
                    //found = true;
                }
            }

            if (!found) {
                itemList2.push(itemId);
            }

            //Asigno al hidden input la variable para poder levantarla desde el code behind
            document.getElementById('<%= hiddenItemBuy.ClientID %>').value = itemList2;

        }

    </script>



    <section id="portfolio" class="section-bg">
        <div class="container">
            <br />
            <br />
            <br />
            <h3>Servicios</h3>


            <div class="card-body">
                <div class="card card-body">
                    <div class="mr-0">
                        <div style="text-align: center">
                            <label for="btn_Comparar">
                                Seleccioná los servicios que queres comparar </label>

                            <asp:Button runat="server" ID="btn_Comparar" CssClass="btn btn-primary" Text="Comparar" />
                            <asp:HiddenField ID="hiddenItemCompare" runat="server" />

                            <asp:Button runat="server" ID="btn_FinCompra" CssClass="btn btn-primary" Text="Ver Pedido" Visible="false" />
                            <asp:HiddenField ID="hiddenItemBuy" runat="server" />

                        </div>
                    </div>
                </div>
            </div>
            <br />

            <%--        <asp:UpdatePanel runat="server">
            <ContentTemplate>--%>
            <div class="row ">
                <asp:Repeater ID="RP_Ofertas" runat="server">
                    <ItemTemplate>
                        <div class="col-4 ml-0 mt-2 mb-2">
                            <div class="card hvr-bounce-in" data-wow-duration="1.4s">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                <asp:Image ImageUrl='<%#"data:Image/png;base64," + Convert.ToBase64String(Eval("ImagenData")) %>' runat="server" />
                                <div class="card-body">
                                    <h2><asp:Label ID="lbl_Nombre" CssClass="card-title" Text='<%# Eval("nombre") %>' runat="server"></asp:Label></h2>
                                    
                                    <%--<asp:Label ID="lbl_Region" CssClass="card-subtitle text-muted mb-2" Text='<%# Eval("Region")%>' runat="server"></asp:Label>--%>
                                    <h3><p class="card-text"><%# Eval("descripcion") %></p></h3>
                                    
                                    <p class="card-text">Precio: $ <%# Eval("precio") %></p>
                                    <p class="card-text">Acceso a la Plataforma: <%# Eval("accesoPlataforma") %></p>
                                    <p class="card-text">Material de Estudio: <%# Eval("materialEstudio") %></p>
                                    <p class="card-text">Reportes:  <%# Eval("reportes") %></p>
                                    <p class="card-text">Capacitaciones:  <%# Eval("capacitaciones") %></p>
                                    <%--<p class="card-text"><%# Eval("Cliente") %></p>--%>

                                    <div class="row">
                                        <div class="col-6">
                                            <input id="btn_Comprar" type="image" src="img/carro2.png" title="comparar" value='<%# Eval("idServicio")%>'
                                                onclick="AddToBuy(this.value)" />
                                        </div>
                                        <div class="row">
                                            <div class="col-6">
                                                <asp:Button ID="btn_Detalle" CssClass="btn btn-primary" runat="server" Text="Detalle" CausesValidation="False"
                                                    CommandArgument='<%# Eval("idServicio")%>'
                                                    CommandName="Detalle"></asp:Button>

                                            </div>
                                        </div>

                                    </div>
                                    <div class="row">
                                        <div class="col-6">
                                            <label class="radio-inline">
                                                Comparar
                                        <input id="cb_comparar" class="form-check-input ml-1" type="checkbox" title="comparar" value='<%# Eval("idServicio")%>'
                                            onclick="AddToCompare(this.value)" />
                                            </label>
                                        </div>
                                        <div class="col">
                                        </div>

                                    </div>

                                </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

            </div>
           
        </div>
    </section>


</asp:Content>
