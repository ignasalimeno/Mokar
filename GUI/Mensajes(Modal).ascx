<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Mensajes(Modal).ascx.vb" Inherits="GUI.Mensajes_Modal_" %>

<!-- Modal -->
<div class="modal fade" id="Mensaje_Modal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="ModalLabel" ><img class="imagen" width="40" src="img/mokar1.png" /> Mensaje de Mokar</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">     
          <p runat="server" id="L_Mensaje"></p>
      </div>
    </div>
  </div>
</div>