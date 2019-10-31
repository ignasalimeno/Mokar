<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="Reporte_Respuestas.aspx.vb" Inherits="GUI.Reporte_Respuestas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section id="portfolio" class="section-bg">
         <div class="container" style="max-width: inherit">
            <div class="row">
                <div class="col-12">
                    <h1>Tiempo y porcentaje de respuestas</h1>
                </div>

            </div>
           
            <!-- Comienzo Grilla -->
            <div class="card-body">
                <div class="card card-body">

<div class="row">
    <div class="col-6">
                    <div id="Div_ReporteTiempo" runat="server" visible="false">
                                <br />
                                <h6>Cantidad de consultas realizadas por Usuarios: 
                                    <label id="lbl_Preguntas" runat="server" text=""></label>
                                </h6>
                                <hr />
                                <br />
                                <h6>Cantidad de respuestas realizadas por la plataforma: 
                                    <label id="lbl_Respuestas" runat="server" text=""></label>
                                </h6>
                                <hr />
                                <br />
                                <h6>Porcentaje de efectividad: 
                                    <label id="lbl_Porcentaje" runat="server" text=""></label>
                                </h6>
                                <hr />
                                <br />
                                 <h6>Tiempo Promedio de Respuesta: 
                                    <label id="lbl_TiempoPromedio" runat="server" text=""></label>
                                </h6>
                                <hr />
                                <br />

                            </div>
        </div>
      <div class="col-6">

                     <asp:Chart ID="chReportes" runat="server" CssClass="chart" Visible="true" BackColor="LightGray" Width="428px">
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
          </div>
    </div>
                </div>
            </div>

        </div>
    </section>
</asp:Content>
