<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="Reporte_Respuestas.aspx.vb" Inherits="GUI.Reporte_Respuestas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section id="portfolio" class="section-bg">
        <div class="container">
            <br />
            <br />
            <br />
            <h3>Tiempo y porcentaje de respuestas</h3>

            <!-- Comienzo Grilla -->
            <div class="card-body">
                <div class="card card-body">

                    <div id="Div_ReporteTiempo" runat="server" visible="false">
                                <br />
                                <h4>Cantidad de consultas realizadas por Usuarios: 
                                    <label id="lbl_Preguntas" runat="server" text=""></label>
                                </h4>
                                <hr />
                                <br />
                                <h4>Cantidad de respuestas realizadas por la plataforma: 
                                    <label id="lbl_Respuestas" runat="server" text=""></label>
                                </h4>
                                <hr />
                                <br />
                                <h4>Porcentaje de efectividad: 
                                    <label id="lbl_Porcentaje" runat="server" text=""></label>
                                </h4>
                                <hr />
                                <br />
                                 <h4>Tiempo Promedio de Respuesta: 
                                    <label id="lbl_TiempoPromedio" runat="server" text=""></label>
                                </h4>
                                <hr />
                                <br />

                            </div>
                </div>
            </div>

        </div>
    </section>
</asp:Content>
