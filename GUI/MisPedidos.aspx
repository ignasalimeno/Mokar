<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="MisPedidos.aspx.vb" Inherits="GUI.MisPedidos" %>
<%@ Register src="ModalEstrellas.ascx" tagname="ModalEstrellas" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="portfolio" class="section-bg">
    <div class="container" style="max-width: inherit">
            <div class="row">
                <div class="col-12">
                    <h1>Mis suscripciones activas</h1>
                </div>

            </div>

            <uc1:ModalEstrellas ID="ModalEstrellas1" runat="server" />
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
                    <asp:GridView ID="DG_Pedidos" CssClass="table table-bordered" DataKeyNames="idServicio" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="10">
                        <Columns>
                            <%--<asp:CommandField ShowSelectButton="True" ButtonType="Button" HeaderText="Seleccionar" CssClass="btn btn-primary" ControlStyle-Width="100px" ControlStyle-Height="40px" />--%>
                            <asp:BoundField DataField="idServicio" HeaderText="Servicio" />
                            <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="cantUsuarios" HeaderText="Cant. Usuarios" />
                            <asp:BoundField DataField="fechaAlta" HeaderText="Fecha de Alta" />
                            <asp:BoundField DataField="diasRestantes" HeaderText="Días Restantes" />
                            <asp:TemplateField >
                                                <ItemTemplate>
                                                    <asp:Button CssClass="btn btn-primary" Text="Calificar" runat="server" CommandName="Calificar" CommandArgument='<%# Eval("idServicio") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                           
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
