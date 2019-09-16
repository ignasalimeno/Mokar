<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="MaterialEstudio_Descargar.aspx.vb" Inherits="GUI.MaterialEstudio_Descargar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <script type="text/javascript">
        function AddIdComentario(itemId) {

            //Asigno al hidden input la variable para poder levantarla desde el code behind
            document.getElementById('<%= RP_Material.ClientID %>').value = itemId;
        }
    </script>


    <section id="portfolio" class="section-bg">
        <div class="container">

            <br />
            <br />
            <br />
            <h3>Material de Estudio</h3>
            <div class="row">
                <asp:Repeater ID="RP_Material" runat="server">
                    <ItemTemplate>

                        <div class="col-md-10 blogShort">   
                            <h1><%# Eval("titulo") %></h1>
                            <em>por <%# Eval("autor") %> </em>
                            <br />
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
            </div>
        </div>
    </section>
</asp:Content>
