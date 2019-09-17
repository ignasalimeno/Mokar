<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="GestionarServicios.aspx.vb" Inherits="GUI.GestionarServicios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section id="portfolio" class="section-bg">
        <div class="container">
            <br />
            <br />
            <br />
            <h3>Servicios</h3>

            <asp:GridView ID="GvObjetos" runat="server" CellPadding="4" ForeColor="#333333"
                    GridLines="None" Height="106px" Width="100%" AutoGenerateColumns="False">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                        <asp:CommandField SelectText="--&gt;" ShowSelectButton="True" />
                        <asp:BoundField DataField="idServicio" HeaderText="Cod" />
                        <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="descripcion" HeaderText="Descripcion" />
                        <asp:BoundField DataField="precio" HeaderText="Precio" />
                        <asp:BoundField DataField="accesoPlataforma" HeaderText="Acceso a Plataforma" />
                        <asp:BoundField DataField="materialEstudio" HeaderText="Material de Estudio" />
                        <asp:BoundField DataField="reportes" HeaderText="Reportes" />
                        <asp:BoundField DataField="capacitaciones" HeaderText="Capacitaciones" />
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
                    <asp:TextBox class="form-control" ID="txtNombre" runat="server" Height="29px" Width="480px"></asp:TextBox>
                    <br />
               Descripcion
                    <asp:TextBox class="form-control" ID="txtDescr" runat="server" Height="29px" Width="480px"></asp:TextBox>
                    <br />

               Precio
                    <asp:TextBox class="form-control" ID="txtPrecio" runat="server" Height="29px" Width="480px"></asp:TextBox>
                    <br />

               Acceso a Plataforma
                    <br />

              <asp:DropDownList ID="dd_accesoPlataforma" runat="server">
                  <asp:ListItem>Si</asp:ListItem>
                  <asp:ListItem>No</asp:ListItem>
               </asp:DropDownList>
                    <br />
                    <br />
               Material de Estudio
                    <br />

                    <asp:DropDownList ID="dd_materiaEstudio" runat="server">
                  <asp:ListItem>Si</asp:ListItem>
                  <asp:ListItem>No</asp:ListItem>
               </asp:DropDownList>
                    <br />
                    <br />
               Reportes
                    <br />

                    <asp:DropDownList ID="dd_reportes" runat="server">
                  <asp:ListItem>Si</asp:ListItem>
                  <asp:ListItem>No</asp:ListItem>
               </asp:DropDownList>
                    <br />
                    <br />
              Capacitaciones
                    <br />

                    <asp:DropDownList ID="dd_capacitaciones" runat="server">
                  <asp:ListItem>Si</asp:ListItem>
                  <asp:ListItem>No</asp:ListItem>
               </asp:DropDownList>
                    <br />
                    <br />
            Imagen
            <br />
             <asp:FileUpload ID="file_Imagen" runat="server" />
            <br />
            <br />
            <br />

                    <asp:Button CssClass="myBtn" ID="BtnAlta" runat="server" Text="Alta" Width="227px" />
              <br /> <br />
                    <asp:Button CssClass="myBtn" ID="BtnModificar" runat="server" Text="Modificar" Width="227px"/>
                    <br />
              <br />
                    <asp:Button CssClass="myBtn" ID="BtnBaja" runat="server" Text="Baja" Width="227px"  />
                    <br />
              <br />
                    <asp:Button CssClass="myBtn" ID="BtnLimpiar" runat="server" Text="Limpiar" Width="227px"  />
              </div>

            

    </section>

</asp:Content>
