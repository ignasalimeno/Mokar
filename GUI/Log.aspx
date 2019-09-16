<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="Log.aspx.vb" Inherits="GUI.Log" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="portfolio" class="section-bg">
        <div class="container">

            <br />
            <br />
            <br />
            <h3>Bitácora</h3>

            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    Busqueda simple<asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/img/flechaAbajo.png" Height="31px" Width="31px" AlternateText="Búsqueda Avanzada" ImageAlign="Middle" />

                    &nbsp;
          <asp:Panel ID="panelSimple" runat="server" Visible="false">
              <asp:TextBox class="form-control" ID="txtBusquedaSimple" runat="server" Width="322px"></asp:TextBox>
              <br />
              <asp:Button CssClass="myBtn" ID="btnBuscar" runat="server" Text="Buscar" Width="286px" />

              <br />

              <br />
          </asp:Panel>
                    <br />



                    Busqueda Avanzada
            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/img/flechaAbajo.png" Height="31px" Width="31px" AlternateText="Búsqueda Avanzada" ImageAlign="Middle" />

                    &nbsp;
         
          <asp:Panel ID="panelAvanzada" runat="server" Visible="false" BorderColor="Black">
              Usuario
                    <asp:TextBox class="form-control" ID="txtUsuario" runat="server" Width="315px"></asp:TextBox>
              <br />
              Fecha Desde<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
              <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TextBox2" Format="dd/MM/yyyy" />

              <br />
              <br />
              Fecha Hasta
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
              <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="TextBox1" Format="dd/MM/yyyy" />

              <br /><br />
              Tipo
              <br />
              <asp:DropDownList ID="DDL_Tipo" runat="server"></asp:DropDownList>
              <br /><br />
              Criticidad
              <br />
                    <asp:DropDownList ID="DDL_Criticidad" runat="server"></asp:DropDownList>
              <br />
              <asp:Button CssClass="myBtn" ID="Button1" runat="server" Text="Buscar" Width="312px" />


          </asp:Panel>

                    <asp:GridView ID="GvBitacora" runat="server" CellPadding="4" ForeColor="#333333"
                        GridLines="None" Height="106px" Width="100%" AutoGenerateColumns="False" AllowPaging="true" PageSize="20">
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <Columns>
                            <%--<asp:CommandField SelectText="--&gt;" ShowSelectButton="True" />--%>
                            <asp:BoundField DataField="idLog" HeaderText="Cod" />
                            <asp:BoundField DataField="usuarioMail" HeaderText="Usuario" />
                            <asp:BoundField DataField="fecha" HeaderText="Fecha" />
                            <asp:BoundField DataField="TipoDescr" HeaderText="Evento" />
                            <asp:BoundField DataField="criticidad" HeaderText="Criticidad" />
                        </Columns>
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#999999" />
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </section>


</asp:Content>
