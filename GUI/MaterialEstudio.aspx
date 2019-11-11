<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="MaterialEstudio.aspx.vb" Inherits="GUI.MaterialEstudio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <script type="text/javascript">
    function checkFileExtension(elem) {
        var filePath = elem.value;

        if (filePath.indexOf('.') == -1)
            return false;

        var validExtensions = new Array();
        var ext = filePath.substring(filePath.lastIndexOf('.') + 1).toLowerCase();

        validExtensions[0] = 'pdf';
        //validExtensions[1] = 'jpeg';
        //validExtensions[2] = 'bmp';
        //validExtensions[3] = 'png';
        //validExtensions[4] = 'gif';
        //validExtensions[5] = 'tif';
        //validExtensions[6] = 'tiff';
        //validExtensions[7] = 'txt';
        //validExtensions[8] = 'doc';
        //validExtensions[9] = 'xls';
        //validExtensions[10] = 'pdf';

        for (var i = 0; i < validExtensions.length; i++) {
            if (ext == validExtensions[i])
                return true;
        }

        elem.value = "";
        alert('La extensión ' + ext.toUpperCase() + ' no está permitida! Solo .pdf');
        return false;
    }
</script>

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
                        <div class="col-8">
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
                                    <asp:TemplateField ShowHeader="true">
                                        <HeaderTemplate>
                                            Archivo
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Button CssClass="btn btn-link" Text='...' runat="server" CommandName="Select" CommandArgument='<%# Eval("ruta") %>' />
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

                        <div class="col-4">
                            <asp:Panel ID="Panel1" runat="server" Visible="false">
                                <div class="row">
                                    <div class="col-6">
                                        Titulo
                                    </div>
                                    <div class="col-6">
                                        <asp:TextBox class="form-control" ID="txtTitulo" runat="server" Height="29px" Width="100%" MaxLength="50"></asp:TextBox>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-6">
                                        Descripcion
                                    </div>
                                    <div class="col-6">
                                        <asp:TextBox class="form-control" ID="txtDescr" runat="server" Height="29px" Width="100%" MaxLength="50"></asp:TextBox>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-6">
                                        Autor
                                    </div>
                                    <div class="col-6">
                                        <asp:TextBox class="form-control" ID="txtAutor" runat="server" Height="29px" Width="100%" MaxLength="50"></asp:TextBox>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-6">
                                        Fecha Creación
                                    </div>
                                    <div class="col-6">
                                        <asp:TextBox ID="txtFecha" runat="server" MaxLength="12" Width="100%"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="cal_FechaCreacion" runat="server" TargetControlID="txtFecha" Format="dd/MM/yyyy" />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtFecha" ErrorMessage="Ingrese una fecha valida" ForeColor="Red" ValidationExpression="^([0-2][0-9]|(3)[0-1])(\/)(((0)[0-9])|((1)[0-2]))(\/)\d{4}$" />

                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-6">
                                        Archivo
                                    </div>
                                    </div>
                                <div class="row">
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
