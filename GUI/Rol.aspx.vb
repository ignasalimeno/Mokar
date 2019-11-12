Imports BE
Imports BLL

Public Class Rol
    Inherits System.Web.UI.Page

    Private oObjBE As New BE.RolBE
    Private oObjBLL As New BLL.RolBLL

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (Page.IsPostBack) Then
            CargarGrilla()
        End If
    End Sub

    Private Sub CargarGrilla()
        Try
            Me.GvObjetos.DataSource = oObjBLL.ListarObjetos()
            Me.GvObjetos.DataBind()
        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & ex.Message & "')", True)

        End Try

    End Sub

    Private Sub Limpiar()
        Try
            Me.txtDescr.Text = ""
            ck_RolUSuario.Checked = False
        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & ex.Message & "')", True)

        End Try

    End Sub

    Protected Sub BtnAlta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAlta.Click
        Try
            If txtDescr.Text.Trim = "" Then
                Throw New Exception("Ingrese un nombre para el rol")
            End If
            If BtnAlta.CommandName = "Alta" Then
                oObjBE.idRol = 1
                oObjBE.descr = Me.txtDescr.Text
                oObjBE.rolUsuario = ck_RolUSuario.Checked
                oObjBE.activo = 1

                oObjBLL.Alta(oObjBE)
                Limpiar()
                CargarGrilla()
            ElseIf BtnAlta.CommandName = "Modificar" Then
                If ck_RolUSuario.Checked = False Then

                    Dim cont As Integer = 0
                    For a As Integer = 0 To GvObjetos.Rows.Count - 1
                        If RolBLL.ObtenerInstancia.ListarObjeto(New RolBE With {.idRol = GvObjetos.Rows(a).Cells(1).Text}).rolUsuario Then
                            cont += 1
                        End If
                    Next
                    If cont <= 1 Then
                        Throw New Exception("No puede eliminar el único rol de usuario")
                    End If

                End If

                oObjBE.idRol = BtnAlta.CommandArgument

                If Me.txtDescr.Text <> "" Then
                    oObjBE.descr = Me.txtDescr.Text
                    oObjBE.rolUsuario = ck_RolUSuario.Checked
                    oObjBLL.Modificacion(oObjBE)
                    Limpiar()
                    CargarGrilla()

                End If
            End If
            Panel1.Visible = False
        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & ex.Message & "')", True)

        End Try

    End Sub

    Protected Sub BtnModificar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnModificar.Click
        Try
            Limpiar()
            Panel1.Visible = False
        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & ex.Message & "')", True)

        End Try
    End Sub

    Protected Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Try
            Panel1.Visible = True
            Limpiar()
            BtnAlta.CommandName = "Alta"
        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & ex.Message & "')", True)

        End Try
    End Sub

    Private Sub GvObjetos_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles GvObjetos.RowDeleting
        Try
            If GvObjetos.Rows.Count = 1 Then
                Throw New Exception("No puede eliminar el único rol existente")
            End If

            Dim cont As Integer = 0
            For a As Integer = 0 To GvObjetos.Rows.Count - 1
                If RolBLL.ObtenerInstancia.ListarObjeto(New RolBE With {.idRol = GvObjetos.Rows(a).Cells(1).Text}).rolUsuario Then
                    cont += 1
                End If
            Next
            If cont <= 1 Then
                Throw New Exception("No puede eliminar el único rol de usuario")
            End If

            Dim listRolesActivos As List(Of RolBE) = RolBLL.ObtenerInstancia.obtenerRolesActivos

            Dim rolActivo As Boolean = False

            For Each a As RolBE In listRolesActivos
                If a.idRol = GvObjetos.DataKeys(e.RowIndex).Value Then
                    rolActivo = True
                End If
            Next

            If rolActivo = True Then
                Dim mensaje As String = "No puede eliminar un rol que tiene asociado un usuario activo"
                ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & mensaje & "')", True)
            Else
                oObjBE.idRol = GvObjetos.DataKeys(e.RowIndex).Value
                oObjBLL.Baja(oObjBE)
                Limpiar()
                CargarGrilla()
            End If

        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & ex.Message & "')", True)

        End Try
    End Sub

    Private Sub GvObjetos_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GvObjetos.RowCommand
        Try
            If e.CommandName = "idme" Then
                Panel1.Visible = True
                BtnAlta.CommandName = "Modificar"

                Dim miRol As RolBE = RolBLL.ObtenerInstancia.ListarObjeto(New RolBE With {.idRol = e.CommandArgument})
                txtDescr.Text = miRol.descr
                ck_RolUSuario.Checked = miRol.rolUsuario

                BtnAlta.CommandArgument = e.CommandArgument
            End If
        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Me.Page, Me.GetType, "alert", "alert('" & ex.Message & "')", True)

        End Try
    End Sub
End Class