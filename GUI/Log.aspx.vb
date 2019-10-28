Imports BE
Imports BLL

Public Class Log
    Inherits System.Web.UI.Page
    Dim tipoBusqueda As Integer = 0
    Dim fechaDesdeSelected As Boolean = False
    Dim fechaHastaSelected As Boolean = False

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (Page.IsPostBack) Then
            CargarGrilla()
            cargarDDLs()
        End If
    End Sub

    Private Sub CargarGrilla()
        Try


            Select Case tipoBusqueda
                Case 0
                    Me.GvBitacora.DataSource = LogBLL.ObtenerInstancia.ListarTodos
                    Me.GvBitacora.DataBind()
                Case 1
                    Me.GvBitacora.DataSource = LogBLL.ObtenerInstancia.ListarBusquedaSimple(txtBusquedaSimple.Text)
                    Me.GvBitacora.DataBind()
                Case 2
                    Dim oLog As New LogBE
                    oLog.usuarioMail = IIf(txtUsuario.Text = "", Nothing, txtUsuario.Text)
                    oLog.idTipo = IIf(DDL_Tipo.SelectedValue = 0, Nothing, DDL_Tipo.SelectedValue)
                    oLog.criticidad = IIf(DDL_Criticidad.SelectedValue = "---", Nothing, DDL_Criticidad.SelectedValue)

                    Dim fechaDesde As Date = Date.Parse(TextBox2.Text)
                    Dim fechaHasta As Date = Date.Parse(TextBox1.Text)

                    Me.GvBitacora.DataSource = LogBLL.ObtenerInstancia.ListarBusquedaAvanzada(oLog, fechaDesde, fechaHasta)
                    Me.GvBitacora.DataBind()
            End Select

        Catch ex As Exception
            Me.GvBitacora.DataSource = LogBLL.ObtenerInstancia.ListarTodos
            Me.GvBitacora.DataBind()
        End Try
    End Sub

    Protected Sub GvBitacora_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GvBitacora.PageIndexChanging

        GvBitacora.PageIndex = e.NewPageIndex

        CargarGrilla()
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtBusquedaSimple.Text = "" Then
            tipoBusqueda = 2
            CargarGrilla()
        Else
            tipoBusqueda = 1
            CargarGrilla()
        End If
    End Sub

    Protected Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Protected Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
    End Sub

    Protected Sub cargarDDLs()
        Try
            DDL_Criticidad.DataSource = Nothing
            DDL_Criticidad.Items.Add("---")
            DDL_Criticidad.Items.Add("1")
            DDL_Criticidad.Items.Add("2")
            DDL_Criticidad.Items.Add("3")
            DDL_Criticidad.DataBind()

            DDL_Tipo.DataSource = Nothing
            Dim miLista As List(Of LogTipoBE) = LogTipoBLL.ObtenerInstancia.ListarObjetos
            miLista.Insert(0, New LogTipoBE() With {.idTipoRegistro = 0, .descr = "---"})
            DDL_Tipo.DataSource = miLista
            DDL_Tipo.DataValueField = "idTipoRegistro"
            DDL_Tipo.DataTextField = "descr"
            DDL_Tipo.DataBind()

        Catch ex As Exception

        End Try
    End Sub
End Class