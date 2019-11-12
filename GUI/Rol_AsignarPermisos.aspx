<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="Rol_AsignarPermisos.aspx.vb" Inherits="GUI.Rol_Permisos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section id="portfolio" class="section-bg">
        <div class="container">
            <br />
            <br />
            <br />
            <h3>Roles: Asignar permisos</h3>
            
           
                <div class="row">
                    <div class="col-sm-3">
                        <asp:DropDownList ID="DDL_Roles" runat="server" CssClass="form-control" AutoPostBack="True"></asp:DropDownList>
                    </div>
                </div>
               <br /><br />
    
                <div class="row">
                    <div class="col-sm-3">
                        <p class="text-center">Permisos Actuales</p>
                        <asp:UpdatePanel ID="UpdatePanelPermisosActuales" runat="server">
                            <ContentTemplate>
                                <asp:ListBox ID="LB_PermisosActuales" runat="server" CssClass=" form-control" Rows="10" Width="280px"></asp:ListBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="col-sm-1">
                        <br />
                        <asp:UpdatePanel ID="UpdatePanelBotones" runat="server">
                            <ContentTemplate>
                                <asp:ImageButton ID="btn_Agregar" runat="server" src="img/flechaizq.png" CssClass="my-3" popupbuttonid="tag_btnAdd" />
                                <br />
                                <asp:ImageButton ID="btn_Quitar" runat="server" src="img/flechader.png" CssClass="my-3" popupbuttonid="tag_btnQuit" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="col-sm-3">
                        <p class="text-center">Permisos Disponibles</p>
                        <asp:UpdatePanel ID="UpdatePanelPermisosDisponibles" runat="server">
                            <ContentTemplate>
                                <asp:ListBox ID="LB_PermisosDisponibles" runat="server" CssClass="form-control" Rows="10" Width="280px"></asp:ListBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-2">
                        <br />
                        <asp:UpdatePanel ID="UpdatePanelAceptarCancelar" runat="server">
                            <ContentTemplate>
                                <asp:Button ID="btn_Guardar" runat="server" CssClass="btn btn-primary" Text="Guardar"></asp:Button>
                                <br />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
        
        </div>
    </section>
</asp:Content>
