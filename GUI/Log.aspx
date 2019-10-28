<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="Log.aspx.vb" Inherits="GUI.Log" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="portfolio" class="section-bg">
        <div class="container" style="max-width: inherit">
            <div class="row">
                <div class="col-12">
                    <h1>Bitácora</h1>
                </div>

            </div>

            <div class="card-body">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>

                        <div class="card card-body">
                            <div class="row">
                                <div class="col-9">
                                    <asp:GridView ID="GvBitacora" CssClass="table table-bordered" runat="server"
                                        AutoGenerateColumns="False" AllowPaging="True" PageSize="20" DataKeyNames="idLog">
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                        <Columns>
                                            <%--<asp:CommandField SelectText="--&gt;" ShowSelectButton="True" />--%>
                                            <asp:BoundField DataField="idLog" HeaderText="Cod" />
                                            <asp:BoundField DataField="usuarioMail" HeaderText="Usuario" />
                                            <asp:BoundField DataField="fecha" HeaderText="Fecha" />
                                            <asp:BoundField DataField="TipoDescr" HeaderText="Evento" />
                                            <asp:BoundField DataField="criticidad" HeaderText="Criticidad" />
                                        </Columns>
                                        <SelectedRowStyle BackColor="Gray" Font-Bold="True" ForeColor="Black" />

                                    </asp:GridView>
                                </div>
                                <div class="col-3">
                                    <div class="row">
                                        <h3>Buscar</h3>
                                    </div>
                                    <div class="row">
                                        <asp:TextBox class="form-control" ID="txtBusquedaSimple" runat="server"></asp:TextBox>
                                    </div>
                                    <hr />
                                    <div class="row">
                                        <div class="col-3">
                                            Usuario
                                        </div>
                                        <div class="col-9">
                                            <asp:TextBox class="form-control" ID="txtUsuario" runat="server" Width="315px"></asp:TextBox>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-3">
                                            Fecha Desde
                                        </div>
                                        <div class="col-9">
                                            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>

                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TextBox2" Format="dd/MM/yyyy" />
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-3">
                                            Fecha Hasta
                                        </div>
                                        <div class="col-9">
                                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="TextBox1" Format="dd/MM/yyyy" />
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-3">
                                            Tipo
                                        </div>
                                        <div class="col-9">
                                            <asp:DropDownList ID="DDL_Tipo" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-3">
                                            Criticidad
                                        </div>
                                        <div class="col-3">
                                            <asp:DropDownList ID="DDL_Criticidad" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <asp:Button CssClass="myBtn" ID="Button1" runat="server" Text="Buscar" Width="312px" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </section>
</asp:Content>
