Imports BE
Imports MPP
Imports SelectPdf
Imports System.IO
Imports System.Data
Imports System.Net
Imports System.Web

Public Class GestorPDF

#Region "Singleton"
    Private Sub New()
    End Sub

    Private Shared Instancia As GestorPDF
    Public Shared Function ObtenerInstancia() As GestorPDF
        If Instancia Is Nothing Then
            Instancia = New GestorPDF
        End If
        Return Instancia
    End Function
#End Region


    Public Sub ArmarPDF(ByVal rsp As HttpResponse, urlPlantilla As String, docMostrabale As Object, Optional Enviarmail As Boolean = False)
        ' read parameters from the webpage
        Dim pdf_page_size As String = "A4"
        Dim pageSize As PdfPageSize = DirectCast([Enum].Parse(GetType(PdfPageSize), pdf_page_size, True), PdfPageSize)

        Dim pdf_orientation As String = "Portrait"
        Dim pdfOrientation As PdfPageOrientation = DirectCast([Enum].Parse(GetType(PdfPageOrientation), pdf_orientation, True), PdfPageOrientation)

        Dim webPageWidth As Integer = 1024

        Dim webPageHeight As Integer = 0

        ' instantiate a html to pdf converter object
        Dim converter As New HtmlToPdf()

        ' set converter options
        converter.Options.PdfPageSize = pageSize
        converter.Options.MarginTop = 15
        converter.Options.PdfPageOrientation = pdfOrientation
        converter.Options.WebPageWidth = webPageWidth
        converter.Options.WebPageHeight = webPageHeight

        Dim doc As New PdfDocument
        Dim tipoDoc As Type = docMostrabale.GetType

        If docMostrabale.GetType Is GetType(FacturaCompletaBE) Then

            Dim cuerpo As String = ArmarFactura(docMostrabale, urlPlantilla)
            doc = converter.ConvertHtmlString(cuerpo)

        End If
        converter.Options.MaxPageLoadTime = 120
        Try
            If Enviarmail Then
                ' save pdf document
                Dim memoryStream As New MemoryStream()
                doc.Save(memoryStream)
                Dim bytes As Byte() = memoryStream.ToArray()
                memoryStream.Close()
                doc.Close()

                Dim Usuario As New UsuarioBE
                Usuario = GestorSesion.ObtenerSesionActual.UsuarioActivo
                'GestorEnvioCorreo.ObtenerInstancia.EnviarFactura(Usuario.mail, "Easy Travel: Envio de Factura", "Gracias por elegirnos, le adjuntamos su factura", Server.MapPath("Template_EasyTravel.html"), bytes)
                EnviarCorreo.ObtenerInstancia.EnviarFactura(Usuario.mail, "Mokar: Envio de Factura", "Gracias por elegirnos, le adjuntamos su factura", bytes)
            Else

                doc.Save(rsp, False, "FacturaMokar.pdf")
                'si lo pongo en true lo muestra, no lo descarga

                doc.Close()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Function ArmarFactura(ByVal FacturaFull As FacturaCompletaBE, Plantilla As String) As String
        Dim Contenido As String = String.Empty
        Dim Reader As StreamReader = New StreamReader(Plantilla)
        Contenido = Reader.ReadToEnd

        With FacturaFull

            Contenido = Contenido.Replace("pNroFactura", FacturaFull.ID).Replace("pNombre", FacturaFull.Nombre).Replace("pApellido", FacturaFull.Apellido).Replace("pUsuario", FacturaFull.Usuario)
            Contenido = Contenido.Replace("pFecha", FacturaFull.Fecha).Replace("pNomOferta", FacturaFull.NombrePais).Replace("pDescripcion", FacturaFull.Descripcion).Replace("pPrecioUnitario", FacturaFull.PrecioUnitario)
            Contenido = Contenido.Replace("pCantidad", FacturaFull.Cantidad).Replace("pTotal", FacturaFull.Total)

            Return Contenido
        End With
    End Function

    Public Sub ArmarPDF2(ByVal rsp As HttpResponse, urlPlantilla As String, docMostrabale As Object, Optional Enviarmail As Boolean = False)
        ' read parameters from the webpage
        Dim pdf_page_size As String = "A4"
        Dim pageSize As PdfPageSize = DirectCast([Enum].Parse(GetType(PdfPageSize), pdf_page_size, True), PdfPageSize)

        Dim pdf_orientation As String = "Portrait"
        Dim pdfOrientation As PdfPageOrientation = DirectCast([Enum].Parse(GetType(PdfPageOrientation), pdf_orientation, True), PdfPageOrientation)

        Dim webPageWidth As Integer = 1024

        Dim webPageHeight As Integer = 0

        ' instantiate a html to pdf converter object
        Dim converter As New HtmlToPdf()

        ' set converter options
        converter.Options.PdfPageSize = pageSize
        converter.Options.MarginTop = 15
        converter.Options.PdfPageOrientation = pdfOrientation
        converter.Options.WebPageWidth = webPageWidth
        converter.Options.WebPageHeight = webPageHeight

        Dim doc As New PdfDocument
        Dim tipoDoc As Type = docMostrabale.GetType

        If docMostrabale.GetType Is GetType(NotaCreditoCompletaBE) Then

            Dim cuerpo As String = ArmarNC(docMostrabale, urlPlantilla)
            doc = converter.ConvertHtmlString(cuerpo)

        End If
        converter.Options.MaxPageLoadTime = 120
        Try
            If Enviarmail Then
                ' save pdf document
                Dim memoryStream As New MemoryStream()
                doc.Save(memoryStream)
                Dim bytes As Byte() = memoryStream.ToArray()
                memoryStream.Close()
                doc.Close()

                EnviarCorreo.ObtenerInstancia.EnviarNC(docMostrabale.usuario, "Mokar: Envio de Nota de Credito", "Gracias por elegirnos, le adjuntamos su Nota de credito", bytes)

            Else

                doc.Save(rsp, False, "NotaCredito.pdf")
                'si lo pongo en true lo muestra, no lo descarga

                doc.Close()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Function ArmarNC(ByVal NCFull As NotaCreditoCompletaBE, Plantilla As String) As String
        Dim Contenido As String = String.Empty
        Dim Reader As StreamReader = New StreamReader(Plantilla)
        Contenido = Reader.ReadToEnd

        With NCFull

            Contenido = Contenido.Replace("pNroFactura", NCFull.ID_Factura).Replace("pNombre", NCFull.Nombre).Replace("pApellido", NCFull.Apellido).Replace("pUsuario", NCFull.Usuario)
            Contenido = Contenido.Replace("pFecha", NCFull.Fecha).Replace("pNomOferta", NCFull.NombrePais).Replace("pDescripcion", NCFull.Descripcion).Replace("pPrecioUnitario", NCFull.PrecioUnitario)
            Contenido = Contenido.Replace("pCantidad", NCFull.Cantidad).Replace("pTotal", NCFull.Total).Replace("pNroNC", NCFull.ID)

            Return Contenido
        End With
    End Function

End Class
