<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="NewPass.aspx.vb" Inherits="GUI.NewPass" %>

<%@ Register Src="~/Mensajes(Modal).ascx" TagPrefix="uc1" TagName="MensajesModal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <uc1:MensajesModal runat="server" ID="MensajesModal" />
    <section id="portfolio" class="section-bg">
      <div class="container">
          <br />
          <br />
          <br />

            
            <h5 class="form-group2">Recupero de Contraseña</h5>
            <div>
                <label>Ingresar la Contraseña</label>
                <asp:TextBox CssClass="form-control" ID="TB_Pass" runat="server" TextMode="Password" Width="302px"></asp:TextBox>
            </div>
            <br />
            <div>
                <label>Ingresar nuevamente la Contraseña</label>
                <asp:TextBox CssClass="form-control" ID="TB_Pass2" runat="server" TextMode="Password" Width="302px"></asp:TextBox>
            </div>
            <br />
            <br />
                           <asp:Button CssClass="btn btn-primary" ID="btn_Enviar" runat="server" Text="Enviar" />
           
        </div>
    </section>
</asp:Content>
