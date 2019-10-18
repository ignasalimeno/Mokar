Imports BE
Imports BLL

Public Class Buscador
    Inherits System.Web.UI.Page
    Dim usuario_logueado As UsuarioBE

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim User As New UsuarioBE
            User = GestorSesion.ObtenerSesionActual.UsuarioActivo
            Session("usuario") = User

            If Session("usuario") IsNot Nothing Then
                CargarBusqueda_Logeado()
            Else
                CargarBusquedaPublico()
            End If
        End If
    End Sub

    Public Sub CargarBusqueda_Logeado()
        Dim lista As New List(Of BuscadorBE)
        Dim texto As String
        texto = Session("buscar")

        Dim User As New UsuarioBE
        User = GestorSesion.ObtenerSesionActual.UsuarioActivo
        Session("usuario") = User

        User = GestorSesion.ObtenerSesionActual.UsuarioActivo
        Session("IDUser") = User.idUsuario

        Dim UsuarioRol As New UsuarioBE
        UsuarioRol = UsuarioBLL.ObtenerInstancia.ListarObjeto(User)


        If UsuarioRol.roles.Contains(New RolBE() With {.descr = "Administrador"}) Then
            lista = BuscadorBLL.ObtenerInstancia.Buscar(texto, 1)
            'Busca en la categoria Backend con el numero 1
            rp_busqueda.DataSource = Nothing
            rp_busqueda.DataSource = lista
            rp_busqueda.DataBind()
        Else
            lista = BuscadorBLL.ObtenerInstancia.Buscar(texto, 2)
            'Busca en la categoria Backend con el numero 2
            rp_busqueda.DataSource = Nothing
            rp_busqueda.DataSource = lista
            rp_busqueda.DataBind()
        End If
    End Sub


    Public Sub CargarBusquedaPublico()
        Dim lista As New List(Of BuscadorBE)
        Dim texto As String
        texto = Session("buscar")
        lista = BuscadorBLL.ObtenerInstancia.Buscar(texto, 0)
        'Busca en la categoria Backend con el numero 0
        rp_busqueda.DataSource = Nothing
        rp_busqueda.DataSource = lista
        rp_busqueda.DataBind()

    End Sub


End Class