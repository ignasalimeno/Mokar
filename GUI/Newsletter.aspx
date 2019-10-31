<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="Newsletter.aspx.vb" Inherits="GUI.Newslatter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section id="portfolio" class="section-bg">
       <div class="container" style="max-width: inherit">
            <div class="row">
                <div class="col-12">
                    <h1>Noticias</h1>
                </div>

            </div>


            <div class="row">
                <div class="col-lg-12">
                    <ul id="portfolio-flters">
                        <li data-filter="*" class="filter-active">Todas</li>
                        <asp:Repeater ID="RP_Categorias" runat="server">
                            <ItemTemplate>
                                <li data-filter=".filter-<%# Eval("idCategoria") %>"><%# Eval("descripcion") %></li>
                            </ItemTemplate>
                        </asp:Repeater>

                    </ul>
                </div>
            </div>

            <div class="row portfolio-container">

                <asp:Repeater ID="RP_Noticias" runat="server">
                    <ItemTemplate>
                        <div class="col-lg-4 col-md-6 portfolio-item filter-<%# Eval("idCategoria") %>" data-wow-delay="0.2s">
                            <div class="portfolio-wrap" id="4">
                                <img src='<%#"data:Image/png;base64," + Convert.ToBase64String(Eval("imagen")) %>' class="img-fluid" alt="">
                                <h6><%# Eval("titulo") %></h6>
                                <a><%# Eval("fechaCreacion", "{0:MM/dd/yyyy}") %><br />
                                    by <%# Eval("autor") %></a>
                                <div class="portfolio-info">

                                    <div>
                                        <asp:Button ID="btnLink" CssClass="link-preview" runat="server" Text="Ver" CommandName="VerNoticia" CommandArgument='<%# Eval("idNewsletter")%>'  />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

            </div>

        </div>

    </section>

</asp:Content>
