<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="NewPass.aspx.vb" Inherits="GUI.NewPass" %>

<%@ Register Src="~/Mensajes(Modal).ascx" TagPrefix="uc1" TagName="MensajesModal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <uc1:MensajesModal runat="server" ID="MensajesModal" />
    <section id="portfolio" class="section-bg">
       <div class="container" style="max-width: inherit">
            <div class="row">
                <div class="col-12">
                    <h1>Recupero de Contraseña</h1>
                </div>
            </div>

           <div class="card-body">
            <div class="card card-body">
               
          <div class="row">
              <div class="col-12">
                    <label>Ingresar la Contraseña</label>
                <asp:TextBox CssClass="form-control" ID="TB_Pass" runat="server" TextMode="Password" Width="250px" MaxLength="20"></asp:TextBox>
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TB_Pass" ErrorMessage="La contraseña debe tener minimo 8 caracteres y al menos una mayúscula, una minúscula y un número" ForeColor="Red" ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$" />
              </div>

          </div>
           <div class="row">
              <div class="col-12">
                   <label>Ingresar nuevamente la Contraseña</label>
                <asp:TextBox CssClass="form-control" ID="TB_Pass2" runat="server" TextMode="Password" Width="250px" MaxLength="20"></asp:TextBox>
              </div>

          </div>
                <br />
           <div class="row" >
              <div class="col-12">
                  <asp:Button CssClass="btn btn-primary" ID="btn_Enviar" runat="server" Text="Enviar" />
              </div>

          </div>
           </div></div>
        </div>
    </section>
</asp:Content>
