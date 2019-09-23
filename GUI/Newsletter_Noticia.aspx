<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="Newsletter_Noticia.aspx.vb" Inherits="GUI.Neswletter_Noticia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <section id="portfolio" class="section-bg">
        <div class="container">
            <br />
            <br />
            <br />
            <div class="row">
                    <div class="col-lg-9 col-md-12 col-sm-12 col-xs-12">
                        <div class="page-wrapper">
                            <div class="blog-title-area">
                                <a runat="server" id="lblCat" >Gardening</a>
                                <br />
                                <h2>
                                    <asp:Label ID="lblTitulo" runat="server" Text="Label"></asp:Label></h2>

                                <div class="blog-meta big-meta">
                                 
                                        <asp:Label ID="lblAutor" runat="server" Text="Label"></asp:Label>
                                    
                                        <asp:Label ID="lblFecha" runat="server" Text="Label"></asp:Label>
                                </div><!-- end meta -->
                            </div><!-- end title -->

                                 <br />
                            <div class="align-content-center">
                       

                                <!-- Imagen -->
                                <div class="single-post-media">
                                    <asp:Image ID="imgNews" runat="server" />
                                                  </div><!-- end media -->
                                <br /><br />
                                <div class="blog-content">  
                                    <div class="pp">
                                        <!-- texto descripción -->
                                        <asp:Repeater ID="Repeater1" runat="server">
                                            <ItemTemplate>
                                                <%# Eval("descripcion") %>
                                            </ItemTemplate>
                                        </asp:Repeater>

                                    </div><!-- end pp -->

                                    </div>
                                </div>
                            </div>
                        </div>

                </div><!-- end row -->


            </div>
         </section>
</asp:Content>
