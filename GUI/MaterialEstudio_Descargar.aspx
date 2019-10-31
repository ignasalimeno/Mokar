<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="MaterialEstudio_Descargar.aspx.vb" Inherits="GUI.MaterialEstudio_Descargar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <script type="text/javascript">
        function AddIdComentario(itemId) {

            //Asigno al hidden input la variable para poder levantarla desde el code behind
            document.getElementById('<%= RP_Material.ClientID %>').value = itemId;
        }
    </script>


    <section id="portfolio" class="section-bg">
      <div class="container" style="max-width: inherit">
            <div class="row">
                <div class="col-12">
                    <h1>Material de Estudio</h1>
                </div>

            </div>
            <div class="row">
                <div class="card-body"><div class="card card-body">
                <asp:Repeater ID="RP_Material" runat="server">
                    <ItemTemplate>
                       
                        <div class="col-md-10 blogShort">   
                            <h3><%# Eval("titulo") %></h3>
                            <em>por <%# Eval("autor") %> - </em>
                            
                            <em><%# Eval("fechaCreacion", "{0:MM/dd/yyyy}") %></em>
                            <br /><br />
                            <article>
                                <p>
                                    <%# Eval("descripcion") %>
                                </p>
                            </article>
                            <asp:Button ID="btnDescargar" CssClass="btn btn-info" runat="server" Text="Descargar" CommandName="descargar" CommandArgument='<%# Eval("ruta") %>' UseSubmitBehavior="false" />
                            <br /><br />
                        </div>
                          
                    </ItemTemplate>
                </asp:Repeater>
                    </div></div>
            </div>
        </div>
    </section>
</asp:Content>
