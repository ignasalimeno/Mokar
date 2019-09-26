<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="Encuesta.aspx.vb" Inherits="GUI.Encuesta" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="portfolio" class="section-bg">
        <div class="container">
            <br />
            <br />
            <br />
            <p class="lead">
                <asp:Label ID="lblPreguntaEncuesta" Text="" runat="server" />
            </p>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>

                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>

                            <asp:HiddenField ID="idPregunta" runat="server" Value='<%# Eval("idPregunta") %>' />
                            <h3 id="Pregunta"><%# Eval("Pregunta") %></h3>
                            <asp:RadioButtonList runat="server" ID="rbPreguntas" AutoPostBack="true">
                            </asp:RadioButtonList>

                          

                            <asp:Chart ID="chReportes" runat="server" CssClass="chart" Visible="false" BackColor="LightGray" Width="428px">
                                <Series>
                                    <asp:Series Name="Series1"></asp:Series>
                                </Series>
                                <ChartAreas>
                                    <asp:ChartArea Name="ChartArea1" AlignmentOrientation="Horizontal" Area3DStyle-Enable3D="true"
                                        Area3DStyle-WallWidth="2" Area3DStyle-Rotation="20"
                                        Area3DStyle-LightStyle="Simplistic" Area3DStyle-Inclination="40"
                                        BorderColor="White" ShadowColor="#CCCCCC">
                                    </asp:ChartArea>
                                </ChartAreas>
                            </asp:Chart>
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
    </section>
</asp:Content>
