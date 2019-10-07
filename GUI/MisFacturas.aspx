<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="MisFacturas.aspx.vb" Inherits="GUI.MisFacturas1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="portfolio" class="section-bg">
        <div class="container">
            <br />
            <br />
            <br />
            <h3>Mis Facturas</h3>
            
    <div class="row">
        <div class="card-body">
            <div class="card card-body">
                <div class="mr-0">
                    <div style="text-align: center">
                        <h3>Mis Facturas <img src="Images/EasyTravel.svg" width="60" height="40" /></h3>
                        <asp:Panel runat="server" ID="Panel_NC" CssClass="ml-2">
                            <div class="col-12">
                                <div class="card-body">
                                    <div class="card card-body">
                                        <asp:GridView ID="DG_Facturas" CssClass="table table-bordered" DataKeyNames="ID" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="20">
                                            <Columns>
                                                <asp:CommandField ShowSelectButton="True" ButtonType="button" HeaderText="Descargar" ControlStyle-CssClass="btn alert-info" SelectText="Descargar" />
                                                <asp:CommandField ShowDeleteButton="True"   ButtonType="button" HeaderText="Cancelar" ControlStyle-CssClass="btn alert-danger" DeleteText="Cancelar" />
                                                <asp:BoundField DataField="ID" HeaderText="Nro. Factura" />
                                                <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                                <asp:BoundField DataField="Apellido" HeaderText="Apellido" Visible="false" />
                                                <asp:BoundField DataField="Usuario" HeaderText="Usuario" />
                                                <asp:BoundField DataField="Total" HeaderText="Total" DataFormatString="{0:C}" />
                                                <asp:BoundField DataField="Cancelada" HeaderText="Cancelada" />
                                                <asp:BoundField DataField="ID_Usuario" HeaderText="ID" Visible="false" />
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
    </div>

        <div class="row">
        <div class="card-body">
            <div class="card card-body">
                <div class="mr-0">
                    <div style="text-align: center">
                        <h3>Ingresar el motivo de cancelacion</h3>
                    </div>
                    <br />
                    <label>Ingresar el motivo de cancelacion</label>
                    <asp:TextBox CssClass="form-control" ID="TB_Ingresar_Motivo" runat="server"></asp:TextBox>

                    <asp:RequiredFieldValidator ID="RFV_Cancelacion" runat="server" ErrorMessage="Este campo es requerido" ControlToValidate="TB_Ingresar_Motivo"
                        ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
                </div>

            </div>
        </div>
    </div>


            </div>
    </section>

</asp:Content>
