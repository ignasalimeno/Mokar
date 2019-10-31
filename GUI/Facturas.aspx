<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="Facturas.aspx.vb" Inherits="GUI.MisFacturas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section id="portfolio" class="section-bg">
       <div class="container" style="max-width: inherit">
            <div class="row">
                <div class="card-body">
                    <div class="card card-body">
                        <div class="mr-0">
                            <div style="text-align: center">
                                <h3>Facturas</h3>
                            </div>
                            <br />
                            <asp:GridView ID="DG_Facturas" CssClass="table table-bordered" DataKeyNames="ID" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="20">
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" ButtonType="button" HeaderText="Descargar" ControlStyle-CssClass="btn alert-info" />
                                    <asp:CommandField ShowDeleteButton="True" ButtonType="button" HeaderText="Cancelar" DeleteText="Cancelar" ControlStyle-CssClass="btn alert-danger" />
                                    <asp:BoundField DataField="ID" HeaderText="Nro. Factura" />
                                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                    <asp:BoundField DataField="Apellido" HeaderText="Apellido" Visible="false" />
                                    <asp:BoundField DataField="Usuario" HeaderText="Usuario" />
                                    <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                                    <asp:BoundField DataField="Total" HeaderText="Total" DataFormatString="{0:C}" />
                                    <asp:BoundField DataField="Cancelada" HeaderText="Cancelada" />
                                    <asp:BoundField DataField="ID_Usuario" HeaderText="ID" Visible="false" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row" runat="server" id="contenido" visible="false">
                <div class="card-body">
                    <div class="card card-body">
                        <div class="mr-0">
                            <div style="text-align: center">
                                <h3>Ingresar el motivo de cancelacion</h3>
                            </div>
                            <br />
                            <label>Ingresar el motivo de cancelacion</label>
                            <asp:TextBox CssClass="form-control" ID="TB_Ingresar_Motivo" runat="server" Width="412px"></asp:TextBox>

                            <asp:RequiredFieldValidator ID="RFV_Cancelacion" runat="server" ErrorMessage="Este campo es requerido" ControlToValidate="TB_Ingresar_Motivo"
                                ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-6">
                        <asp:Button ID="btnConfirmar" CssClass="btn btn-primary" runat="server" OnClientClick="return confirm('Está seguro de realizar la acción?');" Text="Confirmar" Width="128px" />
<br /><br />
                        <asp:Button ID="btnCancelar" CssClass="btn btn-primary" runat="server" Text="Cancelar" Width="128px" />

                    </div>
                    </div>
                </div>
            </div>


            <div class="row">
                <div class="card-body">
                    <div class="card card-body">
                        <div class="mr-0">
                            <div style="text-align: center">
                                <h3>Facturas pendientes de Cancelación</h3>
                            </div>

                            <asp:GridView ID="DG_Pedido" CssClass="table table-bordered" DataKeyNames="ID" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="20">
                                <Columns>
                                    <asp:CommandField ShowDeleteButton="True" ButtonType="button" HeaderText="Cancelar" DeleteText="Cancelar" ControlStyle-CssClass="btn alert-danger" />
                                    <asp:BoundField DataField="ID" HeaderText="Nro. Cancelacion" />
                                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                                    <asp:BoundField DataField="Usuario" HeaderText="Usuario" />
                                    <asp:BoundField DataField="Motivo" HeaderText="Motivo" />
                                    <asp:BoundField DataField="ID_Factura" HeaderText="Nro. Factura" />

                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </section>
</asp:Content>
