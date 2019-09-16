<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="Usuarios.aspx.vb" Inherits="GUI.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  <section id="portfolio" class="section-bg">
      <div class="container">
          <br />
          <br />
          <br />
                <h3>Usuarios</h3>

                <asp:GridView ID="GvUsuario" runat="server" CellPadding="4" ForeColor="#333333"
                    GridLines="None" Height="106px" Width="100%" AutoGenerateColumns="False">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                        <asp:CommandField SelectText="--&gt;" ShowSelectButton="True" />
                        <asp:BoundField DataField="idUsuario" HeaderText="Cod" />
                        <asp:BoundField DataField="nombreRazonSocial" HeaderText="Nombre" />
                        <asp:BoundField DataField="tipoUsuario" HeaderText="ID Tipo Usuario" Visible ="False" />
                        <asp:BoundField DataField="tipoUsuarioDescr" HeaderText="Tipo Usuario" />
                        <asp:BoundField DataField="mail" HeaderText="Mail" />
                        <asp:BoundField DataField="activo" HeaderText="Activo" Visible="False" />
                    </Columns>
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
                <br />
                    Nombre
                    <asp:TextBox class="form-control" ID="TxtNombre" runat="server" Width="452px"></asp:TextBox>
                    <br />
                    Tipo Usuario
          <br />
                    <asp:DropDownList ID="DDL_TipoUsuario" runat="server"></asp:DropDownList>
                    <br /><br />
                    Mail<asp:TextBox class="form-control" ID="TxtMail" runat="server"  Width="452px"></asp:TextBox>
                    <br />
         
                    <asp:Button CssClass="myBtn" ID="BtnAlta" runat="server" Text="Alta" Width="193px" />
              <br /> <br />
                    <asp:Button CssClass="myBtn" ID="BtnModificar" runat="server" Text="Modificar" Width="193px"/>
                    <br />
              <br />
                    <asp:Button CssClass="myBtn" ID="BtnBaja" runat="server" Text="Baja"  Width="193px"/>
                    <br />
              <br />
                    <asp:Button CssClass="myBtn" ID="BtnLimpiar" runat="server" Text="Limpiar"  Width="193px"/>
              
            </div>
        


    </section>

  
</asp:Content>
