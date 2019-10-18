<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="Buscador.aspx.vb" Inherits="GUI.Buscador" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="portfolio" class="section-bg">
        <div class="container">
            <br />
            <br />
            <br />

            <div class="form-group">
                <div class="container">
                    <div class="card-body">
                        <div class="card card-body">
                            <div class="mr-0">
                                <div style="text-align: center">
                                    <h3>Resultados de tu búsqueda </h3>
                                    <hr />
                                </div>
                                <hr />
                                <br />
                                <asp:Repeater runat="server" ID="rp_busqueda">
                                    <ItemTemplate>
                                        <div class="card-body">
                                            <a class="card-title" href='<%# Eval("url") %>'><%# Eval("Menu") %></a>
                                            <p class="card-text"><%# Eval("Icnono") %></p>
                                        </div>
                                        <hr />
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </section>

</asp:Content>
