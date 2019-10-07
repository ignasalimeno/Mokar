<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="FichaOpinion.aspx.vb" Inherits="GUI.FichaOpinion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="portfolio" class="section-bg">
        <div class="container">
            <br />
            <br />
            <br />
            <div class="jumbotron2 col-12">
                <h3>Muchas gracias por tu compra</h3>
                <h4 class="display-6">
                    <asp:Label ID="lblEncuestaDelDia" Text="Ayudanos a mejorar realizando esta breve Ficha de Opinion: " runat="server" />
                </h4>
         
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>

                        <asp:Repeater ID="Repeater1" runat="server">
                            <ItemTemplate>

                                <asp:HiddenField ID="idPregunta" runat="server" Value='<%# Eval("idPregunta") %>' />
                                <h3 id="Pregunta"><%# Eval("Pregunta") %></h3>
                                <asp:RadioButtonList runat="server" ID="rbPreguntas" AutoPostBack="true">
                                </asp:RadioButtonList>
                               
                                <hr class="my-1" />
                            </ItemTemplate>
                        </asp:Repeater>
                        <asp:Button ID="btnVotar" Text="Votar" CssClass="btn btn-warning" runat="server" OnClick="btnVotar_Click" />


                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnVotar" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </section>
</asp:Content>
