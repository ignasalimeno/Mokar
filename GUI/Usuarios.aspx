<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="Usuarios.aspx.vb" Inherits="GUI.Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section id="portfolio" class="section-bg">
        <div class="container" style="max-width: inherit">
            <div class="row">
                <div class="col-12">
                    <h1>Usuarios</h1>
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
                            <asp:GridView ID="GvUsuario" CssClass="table table-bordered" runat="server"
                                AutoGenerateColumns="False" AllowPaging="True" PageSize="20" DataKeyNames="idUsuario">
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImgEditar" ImageUrl="~/img/edit.png" Text="Editar" runat="server" CommandName="idme" CommandArgument='<%# Eval("idUsuario") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="idUsuario" HeaderText="Cod" />
                                    <asp:BoundField DataField="nombreRazonSocial" HeaderText="Nombre" />
                                    <asp:BoundField DataField="tipoUsuario" HeaderText="ID Tipo Usuario" Visible="False" />
                                    <asp:BoundField DataField="tipoUsuarioDescr" HeaderText="Tipo Usuario" />
                                    <asp:BoundField DataField="mail" HeaderText="Mail" />
                                    <asp:BoundField DataField="activo" HeaderText="Activo" Visible="False" />
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
                                <div class="row">
                                    <div class="col-6">
                                        Nombre
                                    </div>
                                    <div class="col-6">
                                        <asp:TextBox class="form-control" ID="TxtNombre" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-6">
                                        Tipo Usuario
                                    </div>
                                    <div class="col-6">
                                        <asp:DropDownList ID="DDL_TipoUsuario" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-6">
                                        Mail
                                    </div>
                                    <div class="col-6">
                                        <asp:TextBox class="form-control" ID="TxtMail" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <br />

                                <div class="row">
                                    <div class="col-6">
                                        <asp:Button CssClass="btn btn-primary" ID="BtnAlta" runat="server" Text="Aceptar" />
                                    </div>
                                    <div class="col-6">
                                        <asp:Button CssClass="btn btn-primary" ID="BtnModificar" runat="server" Text="Cancelar" />
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
