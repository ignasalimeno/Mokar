Imports BE
Imports BLL

Public Class MiCuentaCorriente
    Inherits System.Web.UI.Page

    Dim usuario As New UsuarioBE
    Dim CCObtenidas As New List(Of CuentaCorrienteBE)
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None
        If Not (Page.IsPostBack) Then

            Cargar_CC()

        End If
    End Sub

    Public Sub Cargar_CC()
        Try
            usuario = GestorSesion.ObtenerSesionActual.UsuarioActivo

            CCObtenidas = CuentaCorrienteBLL.ObtenerInstancia.ObtenerPorIDUser(usuario.idUsuario)

            DG_CC.DataSource = Nothing
            DG_CC.DataSource = CCObtenidas
            DG_CC.DataBind()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub DG_CC_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles DG_CC.PageIndexChanging
        Try
            DG_CC.PageIndex = e.NewPageIndex
            Cargar_CC()
        Catch ex As Exception

        End Try

    End Sub


End Class