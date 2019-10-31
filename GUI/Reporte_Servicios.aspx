<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="Reporte_Servicios.aspx.vb" Inherits="GUI.Reporte_Servicios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section id="portfolio" class="section-bg">
         <div class="container" style="max-width: inherit">
            <div class="row">
                <div class="col-12">
                    <h1>Reporte de Facturación de Servicios</h1>
                </div>

            </div>


            <!-- Comienzo Grilla -->
            <div class="card-body">
                <div class="card card-body">

                    <div class=" row">
                        <div class="col-3">
                            Seleccione el estado: 
                                    <asp:DropDownList ID="DDL_Servicios" runat="server"></asp:DropDownList>
                        </div>
                        <div class="col-3">
                            Fecha desde: 
                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="TextBox1" Format="dd/MM/yyyy" />
                        </div>
                        <div class="col-3">
                            Fecha desde: 
                            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TextBox2" Format="dd/MM/yyyy" />

                        </div>
                        <div class="col-3">
                            <div class="row">
                            <asp:Button ID="btnFiltrar" CssClass="btn btn-primary" runat="server" Text="Ver Reporte" />
                                </div>
                            <br />
                            <div class="row">
                            <asp:Button ID="btnVerTodos" CssClass="btn btn-primary" runat="server" Text="Ver Todos" />
                        </div>
                        </div>
                        

                    </div>
                    <br />

                    <div class="row">
                        <div class="col-6" id="grilla" runat="server" visible="false">
                            <asp:GridView ID="DG_Servicios" CssClass="table table-bordered" DataKeyNames="idServicio" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="20">
                                <Columns>
                                    <asp:BoundField DataField="idServicio" HeaderText="Número" InsertVisible="false" />
                                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                    <asp:BoundField DataField="Total" HeaderText="Total" DataFormatString="{0:C}" />
                                </Columns>
                                <SelectedRowStyle BackColor="Gray" Font-Bold="True" ForeColor="Black" />
                            </asp:GridView>
                        </div>

                        <div class="col-6">
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
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </section>
</asp:Content>
