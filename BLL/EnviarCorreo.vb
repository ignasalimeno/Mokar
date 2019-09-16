Imports System.IO
Imports System.Net.Mail

Public Class EnviarCorreo

#Region "Singleton"
    Private Sub New()
    End Sub

    Private Shared Instancia As EnviarCorreo
    Public Shared Function ObtenerInstancia() As EnviarCorreo
        If Instancia Is Nothing Then
            Instancia = New EnviarCorreo
        End If
        Return Instancia
    End Function
#End Region
    Public Function EnviarNotificacion(ByVal pDestino As String, pAsunto As String, pCuerpo As String, ByVal pPath As String) As Boolean
        Try
            Dim Smtp_Server As New SmtpClient
            Dim e_mail As New MailMessage()
            Smtp_Server.UseDefaultCredentials = False
            Smtp_Server.Credentials = New Net.NetworkCredential("mokar.argentina@gmail.com", "Ignacio1507")

            Smtp_Server.Port = 587
            Smtp_Server.EnableSsl = True
            Smtp_Server.Host = "smtp.gmail.com"
            e_mail = New MailMessage()
            e_mail.From = New MailAddress("mokar.argentina@gmail.com", "Mokar Argentina")
            e_mail.To.Add(pDestino)
            e_mail.Subject = pAsunto
            e_mail.IsBodyHtml = True

            Dim sr = New StreamReader(pPath)
            Dim Plantilla As String = sr.ReadToEnd
            sr.Dispose()

            e_mail.Body = Plantilla.Replace("Cuerpodelmail", pCuerpo)
            Smtp_Server.Send(e_mail)

        Catch ex As Exception

        End Try

        Return True
    End Function

    Public Function EnviarNewsletterCaribe(ByVal pDestino As String, pAsunto As String, pCuerpo As String, ByVal pDescripcion As String, ByVal pFecha As Date, ByVal pPath As String) As Boolean
        Try
            Dim Smtp_Server As New SmtpClient
            Dim e_mail As New MailMessage()
            Smtp_Server.UseDefaultCredentials = False
            Smtp_Server.Credentials = New Net.NetworkCredential("mokar.argentina@gmail.com", "Ignacio1507")

            Smtp_Server.Port = 587
            Smtp_Server.EnableSsl = True
            Smtp_Server.Host = "smtp.gmail.com"
            e_mail = New MailMessage()
            e_mail.From = New MailAddress("mokar.argentina@gmail.com")
            e_mail.To.Add(pDestino)
            e_mail.Subject = pAsunto
            e_mail.IsBodyHtml = True

            Dim sr = New StreamReader(pPath)
            Dim Plantilla As String = sr.ReadToEnd
            sr.Dispose()

            e_mail.Body = Plantilla.Replace("Cuerpo", pCuerpo).Replace("Descripcion", pDescripcion).Replace("Fecha", pFecha)
            Smtp_Server.Send(e_mail)

        Catch ex As Exception

        End Try

        Return True
    End Function

    Public Function EnviarNewsletterAmericaN(ByVal pDestino As String, pAsunto As String, pCuerpo As String, ByVal pDescripcion As String, ByVal pFecha As Date, ByVal pPath As String) As Boolean
        Try
            Dim Smtp_Server As New SmtpClient
            Dim e_mail As New MailMessage()
            Smtp_Server.UseDefaultCredentials = False
            Smtp_Server.Credentials = New Net.NetworkCredential("mokar.argentina@gmail.com", "Ignacio1507")

            Smtp_Server.Port = 587
            Smtp_Server.EnableSsl = True
            Smtp_Server.Host = "smtp.gmail.com"
            e_mail = New MailMessage()
            e_mail.From = New MailAddress("mokar.argentina@gmail.com")
            e_mail.To.Add(pDestino)
            e_mail.Subject = pAsunto
            e_mail.IsBodyHtml = True

            Dim sr = New StreamReader(pPath)
            Dim Plantilla As String = sr.ReadToEnd
            sr.Dispose()

            e_mail.Body = Plantilla.Replace("Cuerpo", pCuerpo).Replace("Descripcion", pDescripcion).Replace("Fecha", pFecha)
            Smtp_Server.Send(e_mail)

        Catch ex As Exception

        End Try

        Return True
    End Function

    Public Function EnviarNewsletterAmericaL(ByVal pDestino As String, pAsunto As String, pCuerpo As String, ByVal pDescripcion As String, ByVal pFecha As Date, ByVal pPath As String) As Boolean
        Try
            Dim Smtp_Server As New SmtpClient
            Dim e_mail As New MailMessage()
            Smtp_Server.UseDefaultCredentials = False
            Smtp_Server.Credentials = New Net.NetworkCredential("mokar.argentina@gmail.com", "Ignacio1507")

            Smtp_Server.Port = 587
            Smtp_Server.EnableSsl = True
            Smtp_Server.Host = "smtp.gmail.com"
            e_mail = New MailMessage()
            e_mail.From = New MailAddress("mokar.argentina@gmail.com")
            e_mail.To.Add(pDestino)
            e_mail.Subject = pAsunto
            e_mail.IsBodyHtml = True

            Dim sr = New StreamReader(pPath)
            Dim Plantilla As String = sr.ReadToEnd
            sr.Dispose()

            e_mail.Body = Plantilla.Replace("Cuerpo", pCuerpo).Replace("Descripcion", pDescripcion).Replace("Fecha", pFecha)
            Smtp_Server.Send(e_mail)

        Catch ex As Exception

        End Try

        Return True
    End Function

    'Public Function EnviarFactura(ByVal pDestino As String, pAsunto As String, pCuerpo As String, ByVal pPath As String, ByVal pBytes As Byte()) As Boolean
    Public Function EnviarFactura(ByVal pDestino As String, pAsunto As String, pCuerpo As String, ByVal pBytes As Byte()) As Boolean
        Try
            Dim Smtp_Server As New SmtpClient
            Dim e_mail As New MailMessage()
            Smtp_Server.UseDefaultCredentials = False
            Smtp_Server.Credentials = New Net.NetworkCredential("mokar.argentina@gmail.com", "Ignacio1507")

            Smtp_Server.Port = 587
            Smtp_Server.EnableSsl = True
            Smtp_Server.Host = "smtp.gmail.com"
            e_mail = New MailMessage()
            e_mail.From = New MailAddress("mokar.argentina@gmail.com")
            e_mail.To.Add(pDestino)
            e_mail.Subject = pAsunto
            e_mail.IsBodyHtml = True
            e_mail.Attachments.Add(New Attachment(New MemoryStream(pBytes), "Factura.pdf"))

            'Dim sr = New StreamReader(pPath)
            'Dim Plantilla As String = sr.ReadToEnd
            'sr.Dispose()

            'e_mail.Body = Plantilla.Replace("Cuerpo", pCuerpo)
            'Smtp_Server.Send(e_mail)

            e_mail.Body.Replace("Cuerpo", pCuerpo)
            Smtp_Server.Send(e_mail)


        Catch ex As Exception

        End Try

        Return True
    End Function

    Public Function EnviarNC(ByVal pDestino As String, pAsunto As String, pCuerpo As String, ByVal pBytes As Byte()) As Boolean
        Try
            Dim Smtp_Server As New SmtpClient
            Dim e_mail As New MailMessage()
            Smtp_Server.UseDefaultCredentials = False
            Smtp_Server.Credentials = New Net.NetworkCredential("mokar.argentina@gmail.com", "Ignacio1507")

            Smtp_Server.Port = 587
            Smtp_Server.EnableSsl = True
            Smtp_Server.Host = "smtp.gmail.com"
            e_mail = New MailMessage()
            e_mail.From = New MailAddress("mokar.argentina@gmail.com")
            e_mail.To.Add(pDestino)
            e_mail.Subject = pAsunto
            e_mail.IsBodyHtml = True
            e_mail.Attachments.Add(New Attachment(New MemoryStream(pBytes), "NotadeCreditoEasyTravel.pdf"))
            e_mail.Body.Replace("Cuerpo", pCuerpo)
            Smtp_Server.Send(e_mail)

        Catch ex As Exception

        End Try

        Return True
    End Function

End Class
