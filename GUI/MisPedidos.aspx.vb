Imports BLL
Imports BE

Public Class MisPedidos
    Inherits System.Web.UI.Page

    Dim usuario As New UsuarioBE
    Dim CCObtenidas As New List(Of PedidosActivosBE)
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None
        If Not (Page.IsPostBack) Then

            Cargar_CC()

        End If
    End Sub

    Public Sub Cargar_CC()
        Try
            usuario = GestorSesion.ObtenerSesionActual.UsuarioActivo

            CCObtenidas = FacturaBLL.ObtenerInstancia.ListarPedidosActivos(usuario)

            DG_Pedidos.DataSource = Nothing
            DG_Pedidos.DataSource = CCObtenidas
            DG_Pedidos.DataBind()
        Catch ex As Exception

        End Try


    End Sub

    Private Sub DG_CC_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles DG_Pedidos.PageIndexChanging
        Try
            DG_Pedidos.PageIndex = e.NewPageIndex
            Cargar_CC()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub DG_Pedidos_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles DG_Pedidos.RowCommand
        Try
            If e.CommandName = "Calificar" Then

                If BLL.ServiciosBLL.ObtenerInstancia.PermiteVoto(e.CommandArgument, BLL.GestorSesion.ObtenerSesionActual.UsuarioActivo) Then
                    ModalEstrellas1.Mostrar(e.CommandArgument)
                Else
                    ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & "Este servicio ya ha sido valorado!" & "')", True)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class