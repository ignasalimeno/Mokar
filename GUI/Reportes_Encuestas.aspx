<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="Reportes_Encuestas.aspx.vb" Inherits="GUI.Reportes_Encuestas" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <section id="portfolio" class="section-bg">
        <div class="container">
            <br />
            <br />
            <br />
            <h3>Estadísticas - Encuestas / Ficha Opinion</h3>

            <div class="card-body">
                <div class="card card-body">
                    <div class="row">
                        <div class="col-8">
                            <div id="Div_Encuestas" runat="server">
                                <asp:Chart ID="Reporte_Encuesta" runat="server" CssClass="chart" Width="700px" Height="470px">
                                    <Series>
                                        <asp:Series Name="Series1">
                                        </asp:Series>
                                    </Series>
                                    <ChartAreas>
                                        <asp:ChartArea Name="ChartArea1" AlignmentOrientation="Horizontal" Area3DStyle-Enable3D="true"
                                            Area3DStyle-WallWidth="2" Area3DStyle-Rotation="20"
                                            Area3DStyle-LightStyle="Simplistic" Area3DStyle-Inclination="40"
                                            BorderColor="White" ShadowColor="#CCCCCC">
                                        </asp:ChartArea>
                                    </ChartAreas>
                                </asp:Chart>


                            </div>
                        </div>
                        <div class="col-2">
                            <asp:Button ID="btnVerEncuestas" CssClass="btn btn-primary" runat="server" Text="Encuestas" />
                        </div>
                        <div class="col-2">
                            <asp:Button ID="btnVerFichaOpinion" CssClass="btn btn-primary" runat="server" Text="Ficha Opinion" />
                        </div>
                    </div>
                </div>
            </div>

            <div class="card-body">
                <div class="card card-header">
                    Detalle de respuestas
                </div>
                <div class="card card-body">
                    <asp:GridView ID="DG_Encuestas2" CssClass="table table-bordered" DataKeyNames="idEncuesta" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="20">
                        <Columns>
                            <%--                            <asp:CommandField ShowEditButton="True" ButtonType="button" HeaderText="Editar" ControlStyle-CssClass="btn alert-info" EditText="Editar" />--%>
                            <asp:CommandField ShowSelectButton="True" ButtonType="button" HeaderText="Reporte" ControlStyle-CssClass="btn alert-danger" DeleteText="Borrar" />
                            <asp:BoundField DataField="idEncuesta" HeaderText="Número" InsertVisible="false" />
                            <asp:BoundField DataField="idTipoEncuesta" HeaderText="Tipo" />
                            <asp:BoundField DataField="Titulo" HeaderText="Titulo" />
                            <asp:BoundField DataField="FechaVencimiento" HeaderText="Fecha Vencimiento" />

                        </Columns>
                        <SelectedRowStyle BackColor="Gray" Font-Bold="True" ForeColor="Black" />
                    </asp:GridView>
                </div>
                <br />

                <!-- Detalle de encuestas -->
                 <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>

                    <asp:HiddenField ID="idPregunta" runat="server" Value='<%# Eval("idPregunta") %>' />
                    <h3 id="Pregunta"><%# Eval("Pregunta") %></h3>

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

            </div>



           
        </div>
    </section>
</asp:Content>
