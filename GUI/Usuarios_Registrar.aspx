<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="Usuarios_Registrar.aspx.vb" Inherits="GUI.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <section id="portfolio" class="section-bg">
       <div class="container" style="max-width: inherit">
            <div class="row">
                <div class="col-12">
                    <h1>Active su usuario</h1>
                </div>

            </div>
               <br />
            <div>
                <asp:Label ID="Lbl_Titulo2" runat="server" Text="Ingresar la Contraseña registrada"></asp:Label>
                <asp:TextBox CssClass="form-control" ID="TB_Pass" runat="server" TextMode="Password"></asp:TextBox>
            </div>
            <br />
       
                <asp:Button CssClass="btn btn-primary" ID="btn_Enviar" runat="server" Text="Enviar" />
                <asp:Label ID="Lbl_OK" runat="server" Visible ="false" ></asp:Label>
          </div>
                   </section>
</asp:Content>
