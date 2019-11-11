<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="Categorias.aspx.vb" Inherits="GUI.Categorias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section id="portfolio" class="section-bg">
        <div class="container" style="max-width: inherit">
            <div class="row">
                <div class="col-12">
                    <h1>Categorías</h1>
                </div>

            </div>

            <div class="card-body">
                <div class="card card-body">

                    <div class="row">
                        <asp:Button ID="btnAgregar" CssClass="btn btn-primary" runat="server" Text="Agregar" />
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-9">
                            <asp:GridView ID="GvObjetos" CssClass="table table-bordered" runat="server"
                                AutoGenerateColumns="False" AllowPaging="True" PageSize="20" DataKeyNames="idCategoria">
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <Columns>
                                     <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ImgEditar" ImageUrl="~/img/edit.png" Text="Editar" runat="server" CommandName="idme" CommandArgument='<%# Eval("idCategoria") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                    <asp:BoundField DataField="idCategoria" HeaderText="Cod" />
                                    <asp:BoundField DataField="descripcion" HeaderText="Descripcion" />
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Delete" ImageUrl="~/img/delete.png" Text="Delete" OnClientClick="return confirm('Está seguro de realizar la acción?');" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <SelectedRowStyle BackColor="Gray" Font-Bold="True" ForeColor="Black" />
                            </asp:GridView>
                        </div>

                        <div class="col-3">
                            <asp:Panel ID="Panel1" runat="server" Visible="false">
                                Descripcion
                    <asp:TextBox class="form-control" ID="txtDescr" runat="server" Height="29px" MaxLength="200"></asp:TextBox>
                                <br />
                                <asp:Button CssClass="myBtn" ID="BtnAlta" runat="server" Text="Confirmar" Width="206px" />
                                <br />
                                <br />
                                <asp:Button CssClass="myBtn" ID="BtnModificar" runat="server" Text="Cancelar" Width="206px" />
                            </asp:Panel>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </section>
</asp:Content>
