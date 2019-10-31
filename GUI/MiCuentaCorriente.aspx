<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="MiCuentaCorriente.aspx.vb" Inherits="GUI.MiCuentaCorriente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section id="portfolio" class="section-bg">
        <div class="container" style="max-width: inherit">
            <div class="row">
                <div class="col-12">
                    <h1>Mi cuenta corriente</h1>
                </div>

            </div>

            <div class="card-body">
            <div class="card card-body">
                <div class="mr-0">
                    <div style="text-align: center">
                        <asp:Panel runat="server" ID="Panel_NC" CssClass="ml-2">
                            <div class="col-12">
                                <div class="card-body">
                                    <div class="card card-body">
                    <%-- <asp:UpdatePanel ID="Panel_Facturas" runat="server">--%>
                    <%--<ContentTemplate>--%>
                    <asp:GridView ID="DG_CC" CssClass="table table-bordered" DataKeyNames="ID" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="10">
                        <Columns>
                            <%--<asp:CommandField ShowSelectButton="True" ButtonType="Button" HeaderText="Seleccionar" CssClass="btn btn-primary" ControlStyle-Width="100px" ControlStyle-Height="40px" />--%>
                            <asp:BoundField DataField="ID" HeaderText="Nro. CC" />
                            <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                            <asp:BoundField DataField="Motivo" HeaderText="Motivo" />
                            <asp:BoundField DataField="ID_Factura" HeaderText="Nro. Factura" />
                            <asp:BoundField DataField="ID_NotaCredito" HeaderText="Nro. Nota Credito" />
                            <asp:BoundField DataField="Debito" HeaderText="Debito" DataFormatString="{0:C}"  />
                            <asp:BoundField DataField="Credito" HeaderText="Credito" DataFormatString="{0:C}"  />
                            <%--<asp:BoundField DataField="Saldo" HeaderText="Saldo" DataFormatString="{0:C}"  />--%>
                        </Columns>
                    </asp:GridView>
                    <%--</ContentTemplate>--%>
                    <%--</asp:UpdatePanel>--%>
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>

                        </div> 
                    </div> 
                </div> 
            </div> 

        </div>
    </section>
</asp:Content>

