<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="Usuarios_AsignarRoles.aspx.vb" Inherits="GUI.Usuarios_AsignarRoles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section id="portfolio" class="section-bg">
         <div class="container" style="max-width: inherit">
            <div class="row">
                <div class="col-12">
                    <h1>Usuarios - Asignar roles</h1>
                </div>

            </div>

            <div class="row">
                <div class="col-sm-3">
                    <asp:Label ID="Label1" runat="server" Text="Seleccione el usuario:    "></asp:Label>
                    <asp:DropDownList ID="DDL_Usuarios" runat="server" CssClass="form-control" AutoPostBack="True"></asp:DropDownList>
                </div>
            </div>
            <br /><br />
        <div class="row">
            <div class="col-sm-3">
                <p class="text-center">Roles Actuales</p>
                <asp:UpdatePanel ID="UpdatePanelRolesActuales" runat="server">
                    <ContentTemplate>
                        <asp:ListBox ID="LB_RolesActuales" runat="server" CssClass=" form-control" Rows="10" Width="280px"></asp:ListBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="col-sm-1">
                <br />
                <asp:UpdatePanel ID="UpdatePanelBotones" runat="server">
                    <ContentTemplate>
                        <asp:ImageButton ID="btn_Agregar" runat="server" CssClass="my-3" src="img/flechaizq.png" popupbuttonid="btn_Agregar" />
                        <br />
                        <asp:ImageButton ID="btn_Quitar" runat="server" CssClass="my-3" src="img/flechader.png" popupbuttonid="btn_Quitar" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="col-sm-3">
                <p class="text-center">Roles disponibles</p>
                <asp:UpdatePanel ID="UpdatePanelRolesDisponibles" runat="server">
                    <ContentTemplate>
                        <asp:ListBox ID="LB_RolesDisponibles" runat="server" CssClass="form-control" Rows="10" Width="280px"></asp:ListBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-2">
                <br />
                <asp:UpdatePanel ID="UpdatePanelAceptarCancelar" runat="server">
                    <ContentTemplate>
                        <asp:Button class="myBtn" ID="btn_Guardar" runat="server" CssClass="form-control" Text="Guardar"></asp:Button>
                        <br />
                        <asp:Button class="myBtn" ID="btn_Cancelar" runat="server" CssClass="form-control" Text="Cancelar"></asp:Button>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        </div>

    </section>
</asp:Content>
