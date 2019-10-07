<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="Chat.aspx.vb" Inherits="GUI.Chat" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section id="portfolio" class="section-bg">
        <div class="container">
            <br />
            <br />
            <br />
            <h3>CHAT</h3>

            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <div id="divChatControles" runat="server" class="container">
                <div class="row">
                    <div class="col-md-5">
                        <div id="divChatChat" runat="server">
                            <div class="panel panel-primary">
                                <div class="panel-heading text-center" id="accordion" >
                                    <span class="glyphicon glyphicon-comment"></span>Chat
								
                                </div>
                                <div class="panel-collapse" id="collapseOne">
                                    <div class="panel-body">
                                        <ul id="ulChatVentana" runat="server" class="chat">
                                        </ul>
                                    </div>
                                    <div class="panel-footer">
                                        <div class="input-group">
                                            <input id="txtChatMensaje" type="text" runat="server" class="form-control input-sm" />
                                            <span class="input-group-btn">
                                                <asp:Button class="btn btn-warning btn-sm" ID="btnChatEnviar" runat="server" Text="Enviar" />
                                            </span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div id="divChatCantidadNoLeidos" runat="server" class="scrolling-table-container">
                            <asp:GridView ID="DG_Chats" runat="server" CssClass="table table-striped table-bordered table-hover" AllowPaging="True" PageSize="10" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:BoundField DataField="ID_Usuario" HeaderText="Id Usuario" SortExpression="IdUsuario" Visible="False" />
                                    <asp:BoundField DataField="mail" HeaderText="Usuario">
                                        <HeaderStyle Wrap="False" />
                                        <ItemStyle Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="NoLeido" HeaderText="No Leido">
                                        <HeaderStyle Wrap="False" />
                                        <ItemStyle Wrap="False" />
                                    </asp:BoundField>
                                    <asp:CommandField ButtonType="Button" ShowSelectButton="True" ControlStyle-CssClass="btn alert-primary" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>

                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnChatEnviar" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>

            </div>
        </section>
</asp:Content>
