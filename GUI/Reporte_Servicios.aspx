<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="Reporte_Servicios.aspx.vb" Inherits="GUI.Reporte_Servicios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section id="portfolio" class="section-bg">
        <div class="container">
            <br />
            <br />
            <br />
            <h3>Reporte de Facturación de Servicios</h3>

            <!-- Comienzo Grilla -->
            <div class="card-body">
                <div class="card card-body">

                    <div class=" row">
                        <div class="col-6">

                            <h4>Seleccione el servicio: 
                                    <asp:DropDownList ID="DDL_Servicios" runat="server"></asp:DropDownList>
                            </h4>
                        </div>
                        <div class="col-3">
                            <asp:Button ID="btnFiltrar" CssClass="btn btn-primary" runat="server" Text="Ver Reporte" />
                        </div>
                        <div class="col-3">
                            <asp:Button ID="btnVerTodos" CssClass="btn btn-primary" runat="server" Text="Ver Todos" />
                        </div>

                    </div>
                    <div class=" row" id="grilla" runat="server" visible="false">
                        <asp:GridView ID="DG_Servicios" CssClass="table table-bordered" DataKeyNames="idServicio" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="20">
                            <Columns>
                                <asp:BoundField DataField="idServicio" HeaderText="Número" InsertVisible="false" />
                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                <asp:BoundField DataField="Total" HeaderText="Total" />
                            </Columns>
                            <SelectedRowStyle BackColor="Gray" Font-Bold="True" ForeColor="Black" />
                        </asp:GridView>
                    </div>

                </div>
            </div>

        </div>
    </section>
</asp:Content>
