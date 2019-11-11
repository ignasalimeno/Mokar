<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="GestorPublicidad.aspx.vb" Inherits="GUI.GestorPublicidad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="portfolio" class="section-bg">
        <div class="container" style="max-width: inherit">
            <div class="row">
                <div class="col-12">
                    <h1>Gestor publicidad</h1>
                </div>

            </div>

            <div class="card-body">
                <div class="card card-body">
                    <div class="row">
                        <div class="col-3">
                            <asp:Button ID="btnAgregar" CssClass="btn btn-primary" runat="server" Text="Agregar" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-12">
                            <asp:GridView ID="GvObjeto" CssClass="table table-bordered" runat="server"
                                AutoGenerateColumns="False" AllowPaging="True" PageSize="20">
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <Columns>
                                    <asp:BoundField DataField="url" HeaderText="URL" />
                                    <asp:BoundField DataField="imagenUrl" HeaderText="Imagen" />
                                    <asp:BoundField DataField="texto" HeaderText="Texto Alternativo" />
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Delete" ImageUrl="~/img/delete.png" Text="Delete" OnClientClick="return confirm('Está seguro de realizar la acción?');" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <SelectedRowStyle BackColor="Gray" Font-Bold="True" ForeColor="Black" />

                            </asp:GridView>
                        </div>
                        </div>
                        <div class="row">
                        <div class="col-6">
                            <asp:Panel ID="panelNuevo" runat="server" Visible="false">
                                <div class="row">
                                    <div class="col-3">
                                        <asp:Label ID="Label1" runat="server" Text="URL"></asp:Label>
                                    </div>
                                    <div class="col-9">
                                        <asp:TextBox ID="txtURL" runat="server" MaxLength="150"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-3">
                                        <asp:Label ID="Label2" runat="server" Text="Imagen"></asp:Label>
                                    </div>
                                    <div class="col-9">
                                        <asp:TextBox ID="txtImagen" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-3">
                                        <asp:Label ID="Label3" runat="server" Text="Texto"></asp:Label>
                                    </div>
                                    <div class="col-9">
                                        <asp:TextBox ID="txtTexto" runat="server" MaxLength="100"></asp:TextBox>
                                    </div>
                                </div>
                                <br />  
                                <div class="row">
                                    <div class="col-3">
                                        <asp:Button ID="btnAceptar" CssClass="btn btn-primary" runat="server" Text="Aceptar" OnClientClick="return confirm('Está seguro de realizar la acción?');" />
                                    </div>
                                    <div class="col-3">
                                        <asp:Button ID="btnCancelar" CssClass="btn btn-primary" runat="server" Text="Cancelar" />
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
