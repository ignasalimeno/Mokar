﻿Imports BE
Imports BLL

Public Class Servicios
    Inherits System.Web.UI.Page

    Dim mensaje As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (Page.IsPostBack) Then

            RefrescarRP_Ofertas()

            cargarDDL()

            If GestorSesion.ObtenerSesionActual.UsuarioActivo IsNot Nothing Then
                btn_FinCompra.Visible = True
            End If

        End If
    End Sub

    Private Sub RefrescarRP_Ofertas()
        RP_Ofertas.DataSource = Nothing
        RP_Ofertas.DataSource = ServiciosBLL.ObtenerInstancia.ListarObjetos
        RP_Ofertas.DataBind()

    End Sub

    Private Sub cargarDDL()
        Try
            ddl_Capacitaciones.Items.Add("---")
            ddl_Capacitaciones.Items.Add("Si")
            ddl_Capacitaciones.Items.Add("No")

            ddl_Material.Items.Add("---")
            ddl_Material.Items.Add("Si")
            ddl_Material.Items.Add("No")

            ddl_Pltaforma.Items.Add("---")
            ddl_Pltaforma.Items.Add("Si")
            ddl_Pltaforma.Items.Add("No")

            ddl_Reportes.Items.Add("---")
            ddl_Reportes.Items.Add("Si")
            ddl_Reportes.Items.Add("No")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RP_Ofertas_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles RP_Ofertas.ItemCommand
        Try
            'Para mostrar detalles
            If e.CommandName = "Detalle" Then
                'CommandArgument en este caso es el ID, si es mayor a -1 (cero o más) entra.
                If e.CommandArgument > -1 Then
                    Dim id As Integer
                    id = Convert.ToInt32(e.CommandArgument)
                    Session("OfertaId") = id
                    Dim listaDeOfertasComp As New List(Of ServiciosBE)
                    listaDeOfertasComp.Add(ServiciosBLL.ObtenerInstancia.ListarObjeto(New ServiciosBE() With {.idServicio = id}))
                    Session("Lista") = listaDeOfertasComp
                End If
            End If
            Response.Redirect("Servicios_Comparacion.aspx", False)
        Catch ex As Exception
            mensaje = "Mokar informa: " & ex.Message
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & mensaje & "')", True)
        End Try
    End Sub

    Private Sub btn_FinCompra_Click(sender As Object, e As EventArgs) Handles btn_FinCompra.Click
        Try
            If Not String.IsNullOrEmpty(hiddenItemBuy.Value) Then
                Dim str() As String = hiddenItemBuy.Value.Split(",")
                Dim listaDeCompras As New List(Of ServiciosBE)
                For index = 0 To str.Length - 1
                    listaDeCompras.Add(ServiciosBLL.ObtenerInstancia.ListarObjeto(New ServiciosBE() With {.idServicio = Convert.ToInt32(str(index))}))
                Next
                Session("MisCompras") = listaDeCompras
                Response.Redirect("MisCompras.aspx")
            End If
        Catch ex As Exception
            mensaje = "Mokar informa: " & ex.Message
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & mensaje & "')", True)
        End Try
    End Sub

    Private Sub btn_Comparar_Click(sender As Object, e As EventArgs) Handles btn_Comparar.Click
        Try

            If Not String.IsNullOrEmpty(hiddenItemCompare.Value) Then
                Dim str() As String = hiddenItemCompare.Value.Split(",")
                Dim listaDeOfertas As New List(Of ServiciosBE)
                For index = 0 To str.Length - 1
                    listaDeOfertas.Add(ServiciosBLL.ObtenerInstancia.ListarObjeto(New ServiciosBE() With {.idServicio = Convert.ToInt32(str(index))}))
                Next
                If listaDeOfertas.Count >= 2 And listaDeOfertas.Count <= 4 Then
                    Session("Lista") = listaDeOfertas
                    Response.Redirect("Servicios_Comparacion.aspx")
                Else
                    mensaje = "Mokar informa: Debe seleccionar entre 2 y 4 servicios"
                    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & mensaje & "')", True)

                End If
            End If

        Catch ex As Exception
            mensaje = "Mokar informa: " & ex.Message
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & mensaje & "')", True)
        End Try
    End Sub

    Protected Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Try
            If txtGeneral.Text = "" Then
                RP_Ofertas.DataSource = Nothing
                RP_Ofertas.DataSource = ServiciosBLL.ObtenerInstancia.ListarObjetosAvanzada(txtNombre.Text, txtDescr.Text, txtPrecio.Text, ddl_Pltaforma.Text, ddl_Material.Text, ddl_Reportes.Text, ddl_Capacitaciones.Text)
                RP_Ofertas.DataBind()
            Else
                RP_Ofertas.DataSource = Nothing
                RP_Ofertas.DataSource = ServiciosBLL.ObtenerInstancia.ListarObjetosSimple(txtGeneral.Text)
                RP_Ofertas.DataBind()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnVerTodos_Click(sender As Object, e As EventArgs) Handles btnVerTodos.Click
        Try
            RefrescarRP_Ofertas()
        Catch ex As Exception

        End Try
    End Sub
End Class