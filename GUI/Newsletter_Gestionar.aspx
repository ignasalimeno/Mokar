<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="Newsletter_Gestionar.aspx.vb" Inherits="GUI.Newsletter_Gestionar" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="portfolio" class="section-bg">
        <div class="container">
            <br />
            <br />
            <br />
            <h3 class="section-title">Gestionar Material de Estudio</h3>

            <asp:GridView ID="GvObjetos" runat="server" CellPadding="4" ForeColor="#333333"
                GridLines="None" Height="106px" Width="100%" AutoGenerateColumns="False">
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button CssClass="btn btn-link" Text="--&gt;" runat="server" CommandName="idme" CommandArgument='<%# Eval("idNewsletter") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="idNewsletter" HeaderText="Cod" />
                    <asp:BoundField DataField="titulo" HeaderText="Titulo" />
                    <asp:BoundField DataField="descripcion" HeaderText="Descripcion" />
                    <asp:BoundField DataField="autor" HeaderText="Autor" />
                    <asp:BoundField DataField="fechaCreacion" HeaderText="Fecha de Creacion" />
                    <asp:BoundField DataField="categoriaDescr" HeaderText="Categoria" />
                    <%--<asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button CssClass="btn btn-link" Text='<%# Eval("ruta") %>' runat="server" CommandName="Select" CommandArgument='<%# Eval("ruta") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                    <asp:BoundField DataField="activo" HeaderText="Activo" Visible="False" />

                </Columns>
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#999999" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            </asp:GridView>
            <br />

            Titulo
                    <asp:TextBox class="form-control" ID="txtTitulo" runat="server" Height="29px" Width="480px"></asp:TextBox>
            <br />
            Descripcion
                    
                    <asp:TextBox class="form-control" ID="txtDescr" runat="server" Height="29px" Width="480px" TextMode="MultiLine"></asp:TextBox>
            <br />
          <%--  <script type="text/javascript" src="https://tinymce.cachefly.net/4.0/tinymce.min.js"></script>
            <script type="text/javascript">
                tinymce.init({ selector: 'textarea', width: 300 });
            </script>--%>

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


            <asp:Button CssClass="myBtn" ID="BtnAlta" runat="server" Text="Alta" Width="227px" />
            <br />
            <br />
            <asp:Button CssClass="myBtn" ID="BtnModificar" runat="server" Text="Modificar" Width="227px" />
            <br />
            <br />
            <asp:Button CssClass="myBtn" ID="BtnBaja" runat="server" Text="Baja" Width="227px" />
            <br />
            <br />
            <asp:Button CssClass="myBtn" ID="BtnLimpiar" runat="server" Text="Limpiar" Width="227px" />
        </div>
    </section>

</asp:Content>
