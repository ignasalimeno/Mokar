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
        usuario = GestorSesion.ObtenerSesionActual.UsuarioActivo

        CCObtenidas = FacturaBLL.ObtenerInstancia.ListarPedidosActivos(usuario)

        DG_Pedidos.DataSource = Nothing
        DG_Pedidos.DataSource = CCObtenidas
        DG_Pedidos.DataBind()

    End Sub

    Private Sub DG_CC_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles DG_Pedidos.PageIndexChanging
        DG_Pedidos.PageIndex = e.NewPageIndex
        Cargar_CC()
    End Sub

    Private Sub DG_Pedidos_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles DG_Pedidos.RowCommand
        Try
            If e.CommandName = "Calificar" Then
                ModalEstrellas1.Mostrar(e.CommandArgument)
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class