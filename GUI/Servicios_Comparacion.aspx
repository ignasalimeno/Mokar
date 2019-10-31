<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="Servicios_Comparacion.aspx.vb" Inherits="GUI.Servicios_Comparacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <script type="text/javascript">
        function AddIdComentario(itemId) {

            //Asigno al hidden input la variable para poder levantarla desde el code behind
            document.getElementById('<%= HiddenField1.ClientID %>').value = itemId;
    }
    </script>

    <!-- Modal Agregar Comentario-->
            <div class="modal fade" id="modalAddComentario" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="exampleModalLabel">Agregar comentario</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close" causesvalidation="false">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <%--Contenido del Modal--%>
                            <div class="Form-group">
                                <label>Ingrese su nombre</label>
                                <asp:TextBox CssClass="form-control" ID="txtNombre" runat="server" MaxLength="150" Width="100%"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RFV_Nombre" runat="server" ErrorMessage="Este campo es requerido" ControlToValidate="txtNombre"
                                    ForeColor="Red" Font-Bold="true" ValidationGroup="comentario"></asp:RequiredFieldValidator>
                            </div>
                            <br />
                            <div class="Form-group">
                                <label>Ingresar el comentario</label>
                                <asp:TextBox CssClass="form-control" ID="txtDetalle" runat="server" MaxLength="250" TextMode="MultiLine" Width="100%"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RFV_Detalle" runat="server" ErrorMessage="Este campo es requerido" ControlToValidate="txtDetalle"
                                    ForeColor="Red" Font-Bold="true" ValidationGroup="comentario"></asp:RequiredFieldValidator>
                            </div>
                            <br />
                            <br />
                            <div class="Form-group">
                                <asp:Button CssClass="btn btn-primary mb-2" ID="btn_AgregarComentarioModal" runat="server" Text="Agregar" ValidationGroup="comentario" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <%-- Fin Modal Agergar Comentario --%>

    <!-- Modal Agregar Comentario-->
            <div class="modal fade" id="modalAddRta" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="exampleModalLabelRta">Agregar respuesta</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close" causesvalidation="false">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <asp:HiddenField ID="HiddenField1" runat="server" />

                            <%--Contenido del Modal--%>
                            <div class="Form-group">
                                <label>Ingrese su nombre</label>
                                <asp:TextBox CssClass="form-control" ID="txtNombreRta" runat="server" MaxLength="150" Width="100%"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Este campo es requerido" ControlToValidate="txtNombreRta"
                                    ForeColor="Red" Font-Bold="true" ValidationGroup="respuesta"></asp:RequiredFieldValidator>
                            </div>
                            <br />
                            <div class="Form-group">
                                <label>Ingresar el comentario</label>
                                <asp:TextBox CssClass="form-control" ID="txtDetalleRta" runat="server" MaxLength="250" TextMode="MultiLine" Width="100%"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Este campo es requerido" ControlToValidate="txtDetalleRta"
                                    ForeColor="Red" Font-Bold="true" ValidationGroup="respuesta"></asp:RequiredFieldValidator>
                            </div>
                            <br />
                            <br />
                            <div class="Form-group">
                                <asp:Button CssClass="btn btn-primary mb-2" ID="btnAgregarRta_Modal" runat="server" Text="Agregar" ValidationGroup="respuesta" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <%-- Fin Modal Agergar Comentario --%>




    <section id="portfolio" class="section-bg">
         <div class="container" style="max-width: inherit">
            <div class="row">
                <div class="col-12">
                    <h1>Servicios</h1>
                </div>

            </div>
            <div class="card-body">
                <div class="card card-body">

                    <div style="text-align: center">
                        <label>Comparacion de Ofertas</label>
                        <asp:Button ID="btn_salir" runat="server" Text="Salir" CssClass="btn btn-info" />
                    </div>
                </div>
            </div>
            <br />

            <asp:GridView ID="GvServicios" runat="server" CellPadding="4" ForeColor="#333333"
                GridLines="Both" Height="106px" Width="100%" AutoGenerateColumns="False" ShowHeader="false">
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <Columns>
                    <asp:BoundField DataField="ColComparacion" HeaderText="">
                        <ItemStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="servicio1" HeaderText="" Visible="false">
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="servicio2" HeaderText="" Visible="false">
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="servicio3" HeaderText="" Visible="false">
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="servicio4" HeaderText="" Visible="false">
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                </Columns>
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="White" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#999999" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            </asp:GridView>
            <br />
            <br />
            
            <asp:Panel ID="panelComentarios" runat="server" Visible="false">
                <h4>Comentarios de usuarios:</h4>
                <asp:Repeater ID="RP_Comentarios" runat="server">
                    <ItemTemplate>
                        <div class="card">
                            <div class="card-body">
                                <div class="row">
                                    <div class="col-md-2">
                                        <img src="https://image.ibb.co/jw55Ex/def_face.jpg" class="img img-rounded img-fluid" />
                                        <p class="text-secondary text-center"><%# Eval("fechaHora") %></p>
                                    </div>
                                    <div class="col-md-10">
                                        <p>
                                            <a class="float-left"><strong><%# Eval("nombre") %></strong></a>
                                        </p>
                                        <div class="clearfix"></div>
                                        <p><%# Eval("detalle") %></p>
                                        <p>
                                             <button type="button" class="btn btn-info" data-toggle="modal" data-target="#modalAddRta" id="btnAgregarRta" runat="server" value='<%# Eval("idComentario") %>' visible = '<%# (Convert.ToBoolean(Eval("permiteRespuestas"))) %>' onclick="AddIdComentario(this.value)">Responder</button>
                                            <%--<a class="float-right btn btn-outline-primary ml-2"><i class="fa fa-reply"></i>Reply</a>--%>
                                        </p>
                                    </div>
                                </div>
                                <asp:Panel ID="panel_Respuesta" runat="server" Visible = '<%# (Convert.ToBoolean(Eval("tieneRespuesta"))) %>'>
                                <div class="card card-inner">
                                    <div class="card-body">
                                        <div class="row">
                                            <div class="col-md-2">
                                                <img src="https://image.ibb.co/jw55Ex/def_face.jpg" class="img img-rounded img-fluid" />
                                                <p class="text-secondary text-center"><%# Eval("fechaHoraRespuesta") %></p>
                                            </div>
                                            <div class="col-md-10">
                                                <p><a><strong><%# Eval("nombreRespuesta") %></strong></a></p>
                                                 <p><%# Eval("detalleRespuesta") %></p>
                                                                                            </div>
                                        </div>
                                    </div>
                                </div>
                                    </asp:Panel>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <br />
            
            <div>
                 <button type="button" class="btn btn-info" data-toggle="modal" data-target="#modalAddComentario" id="btnAgregarComentario1" runat="server">Agregar Comentario</button>
                </div>
                </asp:Panel>
        </div>
    </section>

</asp:Content>
