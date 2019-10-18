<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="GestionarEncuestas.aspx.vb" Inherits="GUI.GestionarEncuestas" ValidateRequest="false" Debug="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="portfolio" class="section-bg">
        <div class="container">
            <br />
            <br />
            <br />
            <h3>Gestionar Ecuestas y Fichas de opinión</h3>

            <!-- Comienzo Grilla -->
            <div class="card-body">
                <div class="card card-body">
                    <div class="row">
                        <asp:Button ID="btnAgregar" CssClass="btn btn-primary" runat="server" Text="Agregar" />
                    </div>
                    <br />
                    <div class="row">
                        <div class="mr-0">
                            <asp:GridView ID="DG_Encuestas2" CssClass="table table-bordered" DataKeyNames="idEncuesta" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="20">
                                <Columns>
                                    <%--                            <asp:CommandField ShowEditButton="True" ButtonType="button" HeaderText="Editar" ControlStyle-CssClass="btn alert-info" EditText="Editar" />--%>
                                    <asp:CommandField ShowSelectButton="True" ButtonType="button" HeaderText="Editar" ControlStyle-CssClass="btn alert-danger" DeleteText="Borrar" />
                                    <asp:BoundField DataField="idEncuesta" HeaderText="Número" InsertVisible="false" />
                                    <asp:BoundField DataField="idTipoEncuesta" HeaderText="Tipo" />
                                    <asp:BoundField DataField="Titulo" HeaderText="Titulo" />
                                    <asp:BoundField DataField="FechaVencimiento" HeaderText="Fecha Vencimiento" />

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

            
            <!-- Comienzo detalle -->
            <div class="row" id="contenido" runat="server" visible="false">

                <div class="card-body">
                    <div class="card card-body">
                        <div class="mr-0">


                            <%--Primera fila--%>
                            <div class="form-row">
                                <div class="form-group col-md-4">
                                    <label>Tipo de Encuesta</label>
                                    <asp:DropDownList CssClass="form-control" ID="DDL_Tipo" runat="server" required="required"></asp:DropDownList>
                                </div>

                                <div class="form-group col-md-4">
                                    <label>Ingresar el Titulo:</label>
                                    <asp:TextBox CssClass="form-control" ID="TB_Titulo" runat="server" required="required"></asp:TextBox>
                                </div>

                                <div class="form-group col-md-4">
                                    <label>Ingresar Fecha de vencimiento:</label>
                                    <asp:TextBox CssClass="form-control" ID="TB_Fecha" runat="server" required="required"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="TB_Fecha" Format="dd/MM/yyyy" />

                                </div>

                            </div>


                            <%--Segunda fila--%>
                            <div class="form-row">
                                <div class="form-group col-md-4" id="preguntas" runat="server" visible="false"> 
                                    <h4>Preguntas</h4>
                                    <asp:GridView ID="GV_Preguntas" CssClass="table table-bordered" DataKeyNames="idPregunta" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="20">
                                        <Columns>
                                            <asp:CommandField ShowSelectButton="True" ButtonType="Link" HeaderText="Rtas" SelectText="-->" />
                                            <asp:BoundField DataField="idPregunta" HeaderText="Número" />
                                            <asp:BoundField DataField="Pregunta" HeaderText="Pregunta" />
                                        </Columns>
                                        <SelectedRowStyle BackColor="Gray" Font-Bold="True" ForeColor="Black" />
                                    </asp:GridView>

                                </div>

                                <div class="form-group col-md-4" id="PanelRespuestas" runat="server" visible="false">
                                    <h4>Respuestas</h4>
                                    <asp:GridView ID="Respuestas" CssClass="table table-bordered" DataKeyNames="idRespuesta" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="20">
                                        <Columns>
                                            <asp:CommandField ShowSelectButton="True" ButtonType="Link" HeaderText="Rtas" SelectText="-->" />
                                            <asp:BoundField DataField="idRespuesta" HeaderText="Número" />
                                            <asp:BoundField DataField="Respuesta" HeaderText="Respuesta" />
                                        </Columns>
                                        <SelectedRowStyle BackColor="Gray" Font-Bold="True" ForeColor="Black" />
                                    </asp:GridView>

                                </div>

                                <div class="form-group col-md-4">
                                    <asp:Button ID="btnConfirmar" CssClass="btn btn-primary" runat="server" Text="Confirmar" />
                                    <br />
                                    <asp:Button ID="btnCancelar" CssClass="btn btn-primary" runat="server" Text="Cancelar" />
                                </div>
                            </div>


                            <%--Cuarta fila--%>
                            <div class="form-row">
                                <div class="form-group col-md-4">

                                    <asp:Panel ID="Panel1" runat="server" Visible="false">
                                        <asp:TextBox ID="txtPregunta" runat="server"></asp:TextBox>
                                        <asp:ImageButton ID="btnAddPregunta" runat="server" ImageUrl="~/img/select.png" />
                                        <asp:ImageButton ID="btnGuardarPre" runat="server" ImageUrl="~/img/edit.png" />
                                        <asp:ImageButton ID="btnBorrarPre" runat="server" ImageUrl="~/img/delete.png" />


                                    </asp:Panel>

                                </div>

                                <div class="form-group col-md-4">

                                    <asp:Panel ID="Panel2" runat="server" Visible="false">
                                        <asp:TextBox ID="txtRta" runat="server"></asp:TextBox>
                                        <asp:ImageButton ID="btnAddRta" runat="server" ImageUrl="~/img/select.png" />
                                        <asp:ImageButton ID="btnEditRta" runat="server" ImageUrl="~/img/edit.png" />
                                        <asp:ImageButton ID="btnBorrarRta" runat="server" ImageUrl="~/img/delete.png" />


                                    </asp:Panel>

                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>

        </div>
    </section>
</asp:Content>
