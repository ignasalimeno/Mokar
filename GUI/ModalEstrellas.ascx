<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ModalEstrellas.ascx.vb" Inherits="GUI.ModalEstrellas" %>

<div class="modal fade" id="MensajeEstrellas" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="ModalLabel" ><img class="imagen" width="40" src="img/mokar1.png" />Califique el servicio</h5>
           <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
              </div>
      <div class="modal-body">     
          <asp:UpdatePanel runat="server">
              <ContentTemplate>
          <asp:ImageButton ID="img1" runat="server" ImageUrl="~/img/vacia.png" />       
          <asp:ImageButton ID="img2" runat="server" ImageUrl="~/img/vacia.png" />       
          <asp:ImageButton ID="img3" runat="server" ImageUrl="~/img/vacia.png" />       
          <asp:ImageButton ID="img4" runat="server" ImageUrl="~/img/vacia.png" />       
          <asp:ImageButton ID="img5" runat="server" ImageUrl="~/img/vacia.png" />       
                  </ContentTemplate>
             
              </asp:UpdatePanel>

          <asp:Button ID="btnVotar" CssClass="btn btn-primary" runat="server" Text="Votar" />
      </div>
    </div>
  </div>
</div>

