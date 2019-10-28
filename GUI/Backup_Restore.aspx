<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="Backup_Restore.aspx.vb" Inherits="GUI.Backup_Restore" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section id="portfolio" class="section-bg">
        <div class="container">
            <br />
            <br />
            <br />
            <h3>Backup / Restore</h3>

                  
            <div class="form-group">
                <div class="container">
                    <div class="card-body">
                        <div class="card card-body">
                            <div class="mr-0">
                                <div style="text-align: center">
                                    <h3>Backup</h3>
                                    <small>Gestionar un nuevo BackUp del estado actual de la Base de Datos</small>
                                </div>
                                <br />
                                <div style="text-align: center">
                                    <asp:Button ID="btn_RealizarBackUp" runat="server" CssClass="btn btn-primary" Text="Realizar BackUp" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="container">
                    <div class="card-body">
                        <div class="card card-body">
                            <div class="mr-0">
                                <div style="text-align: center">
                                    <h3>Restore</h3>
                                    <small>Seleccione el Backup que necesita Restaurar</small>

                                    <br />
                                    <asp:FileUpload ID="FileUpload1" runat="server" />

                                    <asp:Button ID="Button1" CssClass="btn btn-primary" runat="server" Text="Cargar" OnClientClick="return confirm('Está seguro de realizar la acción?');" />

                                </div>

                                <asp:UpdatePanel ID="UP_BackUp" runat="server" Visible="false">
                                    <ContentTemplate>
                                        <asp:GridView ID="DG_BackUp" CssClass="table table-bordered" runat="server" AutoGenerateColumns="False" AllowPaging="True">
                                            <Columns>
                                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                                                <asp:BoundField DataField="Path" HeaderText="Path" SortExpression="Path" />
                                                <asp:BoundField DataField="Fecha" HeaderText="Fecha" SortExpression="Fecha" />
                                                <asp:BoundField DataField="Tamaño" HeaderText="Tamaño" SortExpression="Tamaño" />
                                                <%--<asp:BoundField DataField="Usuario" HeaderText="Usuario" SortExpression="Usuario" />--%>
                                                <asp:TemplateField HeaderText="Restore" ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="btn_Restaurar" runat="server" ImageUrl="Images/base-de-datos.png" Width="40px" Height="30px"
                                                            CausesValidation="False"
                                                            CommandArgument='<%# Eval("nombre")%>'
                                                            CommandName="Restore" Text='<%# Eval("nombre") %>'></asp:ImageButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>

                </div>

            </div>
        </div>
    </section>
</asp:Content>
