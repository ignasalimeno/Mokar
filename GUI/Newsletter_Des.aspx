<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="Newsletter_Des.aspx.vb" Inherits="GUI.Newsletter_Des" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <section id="portfolio" class="section-bg">
      <div class="container">
          <br />
          <br />
          <br />

                    
                <h3>¿No desea recibir más noticias?</h3>
               <br />
            <div>
                <asp:Label ID="Lbl_Titulo2" runat="server" Text="Ingrese su mail"></asp:Label>
                <asp:TextBox CssClass="form-control" ID="TB_Mail" runat="server" ></asp:TextBox>
            </div>
            <br />
       
                <asp:Button CssClass="btn btn-primary" ID="btn_Enviar" runat="server" Text="Enviar" />
                <asp:Label ID="Lbl_OK" runat="server" Visible ="false" ></asp:Label>
          </div>
                   </section>


</asp:Content>
