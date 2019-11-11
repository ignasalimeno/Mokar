<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="GestionarServicios.aspx.vb" Inherits="GUI.GestionarServicios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
    function checkFileExtension(elem) {
        var filePath = elem.value;

        if (filePath.indexOf('.') == -1)
            return false;

        var validExtensions = new Array();
        var ext = filePath.substring(filePath.lastIndexOf('.') + 1).toLowerCase();

        validExtensions[0] = 'jpeg';
        validExtensions[1] = 'bmp';
        validExtensions[2] = 'png';
        

        for (var i = 0; i < validExtensions.length; i++) {
            if (ext == validExtensions[i])
                return true;
        }

        elem.value = "";
        alert('La extensión ' + ext.toUpperCase() + ' no está permitida!');
        return false;
    }
</script>

    <section id="portfolio" class="section-bg">
        <div class="container" style="max-width: inherit">
            <div class="row">
                <div class="col-12">
                    <h1>Gestionar Servicios</h1>
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
                                AutoGenerateColumns="False" AllowPaging="True" PageSize="20" DataKeyNames="idServicio">
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImgEditar" ImageUrl="~/img/edit.png" Text="Editar" runat="server" CommandName="idme" CommandArgument='<%# Eval("idServicio") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="idServicio" HeaderText="Cod" />
                                    <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                                    <asp:BoundField DataField="descripcion" HeaderText="Descripcion" />
                                    <asp:BoundField DataField="precio" HeaderText="Precio" />
                                    <asp:BoundField DataField="accesoPlataforma" HeaderText="Acceso a Plataforma" />
                                    <asp:BoundField DataField="materialEstudio" HeaderText="Material de Estudio" />
                                    <asp:BoundField DataField="reportes" HeaderText="Reportes" />
                                    <asp:BoundField DataField="capacitaciones" HeaderText="Capacitaciones" />
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
                                        <asp:TextBox class="form-control" ID="txtNombre" runat="server" Height="29px" Width="100%" MaxLength="40"></asp:TextBox>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-6">
                                        Descripcion
                                    </div>
                                    <div class="col-6">
                                        <asp:TextBox class="form-control" ID="txtDescr" runat="server" Height="29px" Width="100%" MaxLength="150"></asp:TextBox>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-6">
                                        Precio $ 
                                    </div>
                                    <div class="col-6">
                                        <asp:TextBox class="form-control" ID="txtPrecio" runat="server" Height="29px" Width="100%" MaxLength="15"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPrecio" ErrorMessage="Ingrese un precio válido (solo núermos y dos decimales)" ForeColor="Red" ValidationExpression="^[0-9]\d{0,9}(\,\d{1,2})?%?$" />
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-6">
                                        Acceso a Plataforma
                    <br />

                                        <asp:DropDownList ID="dd_accesoPlataforma" runat="server">
                                            <asp:ListItem>Si</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-6">
                                        Material de Estudio
                    <br />

                                        <asp:DropDownList ID="dd_materiaEstudio" runat="server">
                                            <asp:ListItem>Si</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-6">
                                        Reportes
                    <br />

                                        <asp:DropDownList ID="dd_reportes" runat="server">
                                            <asp:ListItem>Si</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-6">
                                        Capacitaciones
                    <br />

                                        <asp:DropDownList ID="dd_capacitaciones" runat="server">
                                            <asp:ListItem>Si</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    Imagen
                                </div>
                                <div class="row">
                                    <asp:FileUpload ID="file_Imagen" runat="server" />
                                    <br />
                                    <br />
                                    <br />
                                </div>

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
            <br />


        </div>
    </section>

</asp:Content>
