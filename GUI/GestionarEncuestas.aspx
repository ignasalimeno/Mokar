<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="GestionarEncuestas.aspx.vb" Inherits="GUI.GestionarEncuestas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="portfolio" class="section-bg">
        <div class="container">
            <br />
            <br />
            <br />
            <h3>Gestionar Ecuestas y Fichas de opinión</h3>

            <div class="row">
                <div class="card-body">
                    <div class="card card-body">
                        <div class="mr-0">
                            <asp:GridView ID="DG_Encuestas2" CssClass="table table-bordered" DataKeyNames="idEncuesta" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="20">
                                <Columns>
                                    <%--                            <asp:CommandField ShowEditButton="True" ButtonType="button" HeaderText="Editar" ControlStyle-CssClass="btn alert-info" EditText="Editar" />--%>
                                    <asp:CommandField ShowSelectButton="True" ButtonType="button" HeaderText="Editar" ControlStyle-CssClass="btn alert-danger" DeleteText="Borrar" />
                                    <asp:BoundField DataField="idEncuesta" HeaderText="Número" InsertVisible="false" />
                                    <asp:BoundField DataField="idTipoEncuesta" HeaderText="Tipo" />
                                    <asp:BoundField DataField="Titulo" HeaderText="Titulo" />
                                    <asp:BoundField DataField="FechaVencimiento" HeaderText="Fecha Vencimiento" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
            <br />
            <div class="row">
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
                                    <asp:TextBox CssClass="form-control" ID="TB_Fecha" runat="server" type="date" required="required"></asp:TextBox>
                                </div>

                            </div>


                            <%--Segunda fila--%>
                            <div class="form-row">
                                <div class="form-group col-md-4">
                                    <h4>Preguntas</h4>
                                    <asp:GridView ID="GV_Preguntas" CssClass="table table-bordered" DataKeyNames="idPregunta" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="20">
                                        <Columns>
                                            <asp:CommandField ShowSelectButton="True" ButtonType="Link" HeaderText="Rtas" SelectText ="-->" />
                                             <asp:BoundField DataField="idPregunta" HeaderText="Número" />
                                            <asp:BoundField DataField="Pregunta" HeaderText="Pregunta" />
                                        </Columns>
                                    </asp:GridView>
                                   
                                </div>

                                <div class="form-group col-md-4">
                                   <h4>Respuestas</h4>
                                    <asp:GridView ID="Respuestas" CssClass="table table-bordered" DataKeyNames="idRespuesta" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="20">
                                        <Columns>
                                            <asp:CommandField ShowSelectButton="True" ButtonType="Link" HeaderText="Rtas" SelectText ="-->" />
                                           <asp:BoundField DataField="idRespuesta" HeaderText="Número" />
                                            <asp:BoundField DataField="Respuesta" HeaderText="Respuesta" />
                                        </Columns>
                                    </asp:GridView>
                                
                                </div>

                                <div class="form-group col-md-4">
                                   <h4>Editar Encuesta</h4>
                                    <asp:Button ID="btnNuevaEncuesta" runat="server" Text="Nueva" />
                                    <asp:Button ID="btnEditarEncuesta" runat="server" Text="Modificar" />
                                    <asp:Button ID="btnEliminarEncuesta" runat="server" Text="Eliminar" />
                                
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
