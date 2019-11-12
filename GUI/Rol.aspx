<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="Rol.aspx.vb" Inherits="GUI.Rol" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section id="portfolio" class="section-bg">
        <div class="container" style="max-width: inherit">
            <div class="row">
                <div class="col-12">
                    <h1>Roles</h1>
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
                                AutoGenerateColumns="False" AllowPaging="True" PageSize="20" DataKeyNames="idRol">
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImgEditar" ImageUrl="~/img/edit.png" Text="Editar" runat="server" CommandName="idme" CommandArgument='<%# Eval("idRol") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="idRol" HeaderText="Cod" />
                                    <asp:BoundField DataField="descr" HeaderText="Descripcion" />
                                    <asp:BoundField DataField="rolUsuario" HeaderText="Rol Usuario" />

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
                                    <div class="col-4">
                                        Descripcion
                                    </div>
                                    <div class="col-8">
                                        <asp:TextBox class="form-control" ID="txtDescr" runat="server" Height="29px" MaxLength="50"></asp:TextBox>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-4">
                                        Rol usuario
                                    </div>
                                    <div class="col-8">
                                        <asp:CheckBox ID="ck_RolUSuario" runat="server" />
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-6">
                                        <asp:Button CssClass="btn btn-primary" ID="BtnAlta" runat="server" Text="Confirmar" OnClientClick="return confirm('¿Confirma la acción?')" />
                                    </div>
                                    <div class="col-6">
                                        <asp:Button CssClass="btn btn-primary" ID="BtnModificar" runat="server" Text="Cancelar"  />
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
