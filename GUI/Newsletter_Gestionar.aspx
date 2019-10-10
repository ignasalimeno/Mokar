<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="Newsletter_Gestionar.aspx.vb" Inherits="GUI.Newsletter_Gestionar" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="portfolio" class="section-bg">
        <div class="container">
            <br />
            <br />
            <br />
            <h3 class="section-title">Gestionar Material de Estudio</h3>

                    <!-- Comienzo Grilla -->
                    <div class="card-body">
                        <div class="card card-body">
                            <div class="row">
                                <asp:Button ID="btnAgregar" CssClass="btn btn-primary" runat="server" Text="Agregar" />
                            </div>
                            <br />
                            <div class="row">
                                <div class="mr-0">
                                    <asp:GridView ID="GvObjetos" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="20" DataKeyNames="idNewsletter">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ImgEditar" ImageUrl="~/img/edit.png" Text="Editar" runat="server" CommandName="idme" CommandArgument='<%# Eval("idNewsletter") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="idNewsletter" HeaderText="Cod" />
                                            <asp:BoundField DataField="titulo" HeaderText="Titulo" />
                                            <asp:BoundField DataField="descripcion" HeaderText="Descripcion" />
                                            <asp:BoundField DataField="autor" HeaderText="Autor" />
                                            <asp:BoundField DataField="fechaCreacion" HeaderText="Fecha de Creacion" />
                                            <asp:BoundField DataField="categoriaDescr" HeaderText="Categoria" />
                                            <asp:BoundField DataField="activo" HeaderText="Activo" Visible="False" />
                                            <asp:TemplateField HeaderText="Enviar Mail">
                                                <ItemTemplate>
                                                    <asp:Button CssClass="btn btn-primary" Text="Mail" runat="server" CommandName="mail" CommandArgument='<%# Eval("idNewsletter") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

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
                        </div>
                    </div>
                    <!-- Fin Grilla -->
                    <br />

                    <!-- Comienzo detalle -->
                    <div class="row" id="contenido" runat="server" visible="false">

                        <div class="card-body">
                            <div class="card card-body">
                                <div class="row">

                                    <div class="col-8">
                                        Titulo
                    <asp:TextBox class="form-control" ID="txtTitulo" runat="server" Height="29px" Width="480px"></asp:TextBox>
                                        <br />
                                        Descripcion
                    
                    <asp:TextBox class="form-control" ID="txtDescr" runat="server" Columns="70" Rows="25" TextMode="MultiLine"></asp:TextBox>
                                        <ajaxToolkit:HtmlEditorExtender ID="HtmlEditorExtender1" runat="server" TargetControlID="txtDescr"></ajaxToolkit:HtmlEditorExtender>
                                        <br />

                                        Autor
                    <asp:TextBox class="form-control" ID="txtAutor" runat="server" Height="29px" Width="480px"></asp:TextBox>
                                        <br />
                                        Fecha Creación
            <br />
                                        <asp:TextBox ID="txtFecha" runat="server"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="cal_FechaCreacion" runat="server" TargetControlID="txtFecha" Format="dd/MM/yyyy" />
                                        <br />
                                        <br />
                                        Imagen
            <br />
                                        <asp:FileUpload ID="file_Imagen" runat="server" />

                                        <br />
                                        Categoria
            <br />
                                        <asp:DropDownList ID="DDL_Categoria" runat="server"></asp:DropDownList>
                                        <br />
                                    </div>
                                    <div class="col-4">
                                        <asp:Button CssClass="myBtn" ID="BtnAlta" runat="server" Text="Confirmar" Width="227px" />
                                        <br />
                                        <br />
                                        <asp:Button CssClass="myBtn" ID="BtnModificar" runat="server" Text="Cancelar" Width="227px" />
                                        <br />
                                        <br />
                                        <br />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
            <!-- Fin detalle -->
                
        </div>
    </section>

</asp:Content>
