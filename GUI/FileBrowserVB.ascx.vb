Imports System.IO

Public Class FileBrowser
    Inherits System.Web.UI.UserControl

    Public Property UserName() As String
        Get
            Return ViewState("UserName").ToString()
        End Get
        Set(ByVal value As String)
            ViewState("UserName") = value
        End Set
    End Property

    Public Property UserDomain() As String
        Get
            Return ViewState("UserDomain").ToString()
        End Get
        Set(ByVal value As String)
            ViewState("UserDomain") = value
        End Set
    End Property

    Public Property UserPassword() As String
        Get
            Return ViewState("UserPassword").ToString()
        End Get
        Set(ByVal value As String)
            ViewState("UserPassword") = value
        End Set
    End Property
    Public Property SelectedFile() As FileInfo
        Get
            Return ViewState("SelectedFile")
        End Get
        Private Set(ByVal value As FileInfo)
            ViewState("SelectedFile") = value
        End Set
    End Property

    Public Property CurrentFolder() As String
        Get
            Return ViewState("CurrentFolder").ToString()
        End Get
        Set(ByVal value As String)
            ViewState("CurrentFolder") = value
        End Set
    End Property

    Public Property RootFolder() As String
        Get
            Return ViewState("RootFolder").ToString()
        End Get
        Set(ByVal value As String)
            ViewState("RootFolder") = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

End Class