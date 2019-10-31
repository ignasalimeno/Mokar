<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="MaterialEstudio.aspx.vb" Inherits="GUI.MaterialEstudio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="portfolio" class="section-bg">
        <div class="container" style="max-width: inherit">
            <div class="row">
                <div class="col-12">
                    <h1>Material de Estudio</h1>
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
                                AutoGenerateColumns="False" AllowPaging="True" PageSize="20" DataKeyNames="idME">
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImgEditar" ImageUrl="~/img/edit.png" Text="Editar" runat="server" CommandName="idme" CommandArgument='<%# Eval("idME") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="idME" HeaderText="Cod" />
                                    <asp:BoundField DataField="titulo" HeaderText="Titulo" />
                                    <asp:BoundField DataField="descripcion" HeaderText="Descripcion" />
                                    <asp:BoundField DataField="autor" HeaderText="Autor" />
                                    <asp:BoundField DataField="fechaCreacion" HeaderText="Fecha de Creacion" />
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Button CssClass="btn btn-link" Text='<%# Eval("ruta") %>' runat="server" CommandName="Select" CommandArgument='<%# Eval("ruta") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Delete" ImageUrl="~/img/delete.png" Text="Delete" OnClientClick="return confirm('Está seguro de realizar la acción?');" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="activo" HeaderText="Activo" Visible="False" />

                                </Columns>
                                <SelectedRowStyle BackColor="Gray" Font-Bold="True" ForeColor="Black" />
                            </asp:GridView>

                        </div>

                        <div class="col-3">
                            <asp:Panel ID="Panel1" runat="server" Visible="false">
                                <div class="row">
                                    <div class="col-6">
                                        Titulo
                                    </div>
                                    <div class="col-6">
                                        <asp:TextBox class="form-control" ID="txtTitulo" runat="server" Height="29px" Width="180px"></asp:TextBox>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-6">
                                        Descripcion
                                    </div>
                                    <div class="col-6">
                                        <asp:TextBox class="form-control" ID="txtDescr" runat="server" Height="29px" Width="180px"></asp:TextBox>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-6">
                                        Autor
                                    </div>
                                    <div class="col-6">
                                        <asp:TextBox class="form-control" ID="txtAutor" runat="server" Height="29px" Width="180px"></asp:TextBox>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-6">
                                        Fecha Creación
                                    </div>
                                    <div class="col-6">
                                        <asp:TextBox ID="txtFecha" runat="server"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="cal_FechaCreacion" runat="server" TargetControlID="txtFecha" Format="dd/MM/yyyy" />
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-6">
                                        Archivo
                                    </div>
                                    <div class="col-6">
                                        <input type="file" id="fileArchivo" name="File1" runat="server" />
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
