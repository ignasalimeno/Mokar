Imports System.IO
Imports System.Net.Mail
Imports System.Security.Cryptography
Imports System.Text
Imports BE
Imports System.ComponentModel
Imports System.Web
Imports System.Configuration

Public Class Criptografia

#Region "Singleton"
    Private Sub New()
    End Sub

    Private Shared Instancia As Criptografia
    Public Shared Function ObtenerInstancia() As Criptografia
        If Instancia Is Nothing Then
            Instancia = New Criptografia
        End If
        Return Instancia
    End Function
#End Region

    Shared passPhrase As String = "yourPassPhrase"
    Shared saltValue As String = "mySaltValue"
    Shared hashAlgorithm As String = "SHA1"
    Shared passwordIterations As Integer = 2
    Shared initVector As String = "@1B2c3D4e5F6g7H8"
    Shared keySize As Integer = 256

    Public Function EncriptarHashMD5(ByVal value As String) As String
        'Message Digest Algorithm 5
        Dim str As String = ""
        Try
            Dim Ue As UnicodeEncoding = New UnicodeEncoding()
            Dim ByteSourceText As Byte() = Ue.GetBytes(value)
            Dim Md5 As MD5CryptoServiceProvider = New MD5CryptoServiceProvider()
            Dim ByteHash As Byte() = Md5.ComputeHash(ByteSourceText)
            Md5.Clear()
            str = Convert.ToBase64String(ByteHash)
        Catch ex As Exception
            Throw New Exception
        End Try
        Return str
    End Function

    Public Function CompararHashMD5(ByVal claveBD As String, ByVal hash As String) As Boolean
        'Return (hash.Equals(Me.GetHashMD5(value)))
        'value -> encriptado
        'hash -> encritado
        'value es el valor de la clave de la BD, ya viene encriptado
        'hash es el valor de la clave que entró por pantalla, encriptada
        Return hash.Equals(claveBD)
    End Function

    Public Sub VerificarDuplicado(ByVal path As Boolean)
    End Sub

    Public Sub Verificar(ByVal path As Boolean)
    End Sub

    Public Shared Function Encriptar(ByVal data As String) As String
        Try
            Dim initVectorBytes As Byte() = Encoding.ASCII.GetBytes(initVector)
            Dim saltValueBytes As Byte() = Encoding.ASCII.GetBytes(saltValue)
            Dim plainTextBytes As Byte() = Encoding.UTF8.GetBytes(data)
            Dim password As New PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations)
            Dim keyBytes As Byte() = password.GetBytes(keySize \ 8)
            Dim symmetricKey As New RijndaelManaged()
            symmetricKey.Mode = CipherMode.CBC
            Dim encryptor As ICryptoTransform = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes)
            Dim memoryStream As New MemoryStream()
            Dim cryptoStream As New CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write)
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length)
            cryptoStream.FlushFinalBlock()
            Dim cipherTextBytes As Byte() = memoryStream.ToArray()
            memoryStream.Close()
            cryptoStream.Close()
            Dim TextoEncriptado As String = Convert.ToBase64String(cipherTextBytes)
            Return TextoEncriptado
        Catch ex As Exception
            Throw New Exception
        End Try
    End Function

    Public Shared Function JavaScriptEscape(text As String) As String
        Return HttpUtility.JavaScriptStringEncode(text)
    End Function

    Public Shared Function Desencriptar(ByVal data As String) As String
        Try
            Dim cipherTextBytes As Byte() = Nothing
            Dim initVectorBytes As Byte() = Encoding.ASCII.GetBytes(initVector)
            Dim saltValueBytes As Byte() = Encoding.ASCII.GetBytes(saltValue)
            cipherTextBytes = Convert.FromBase64String(data)
            Dim password As New PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations)
            Dim keyBytes As Byte() = password.GetBytes(keySize \ 8)
            Dim symmetricKey As New RijndaelManaged()
            symmetricKey.Mode = CipherMode.CBC
            Dim decryptor As ICryptoTransform = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes)
            Dim memoryStream As MemoryStream = Nothing
            memoryStream = New MemoryStream(cipherTextBytes)
            Dim cryptoStream As New CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read)
            Dim plainTextBytes As Byte() = New Byte(cipherTextBytes.Length - 1) {}
            Dim decryptedByteCount As Integer = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length)
            memoryStream.Close()
            cryptoStream.Close()
            Dim plainText As String = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount)
            Return plainText

        Catch ex As Exception
            Throw New Exception
        End Try
    End Function

    Public Function getTamFile(ByVal path As String) As String
        Dim fi As New FileInfo(path)
        If fi.Exists Then
            If (fi.Length / 1024) > 1024 Then
                Return Math.Round(((fi.Length / 1024) / 1024), 2).ToString() & " Mb"
            Else
                Return Math.Round((fi.Length / 1024), 2).ToString() & " Kb"
            End If
        Else
            Return String.Empty
        End If
    End Function

    Public Function getNameFile(ByVal path As String) As String
        Dim fi As New FileInfo(path)
        If fi.Exists Then
            Return fi.Name
        Else
            Return String.Empty
        End If
    End Function

    Public Function Listar_BackUps_Fisicos(path1 As String) As List(Of Backup_RestoreBE)
        Dim lista As New List(Of Backup_RestoreBE)

        Dim path As String
        path = path1
        Dim dir As New DirectoryInfo(path)
        Dim fileList As FileInfo()
        fileList = dir.GetFiles("*.bak", SearchOption.AllDirectories)

        For Each backUpFile As FileInfo In fileList
            Dim oBackup As New Backup_RestoreBE With {
            .Nombre = backUpFile.Name,
            .Fecha = backUpFile.CreationTime,
            .Path = backUpFile.DirectoryName,
            .Tamaño = Math.Round(((backUpFile.Length / 1024) / 1024), 2).ToString() & " Mb",
            .Usuario = "Fichero Local"
            }
            lista.Add(oBackup)
        Next
        Return lista
    End Function

    Public Function EncriptarTarjeta(ByVal paramTexto As String) As String
        Dim CyphMode As CipherMode = CipherMode.ECB
        Dim Key As String = "INNOVALED"
        Try
            Dim Des As New TripleDESCryptoServiceProvider
            Dim InputbyteArray() As Byte = Encoding.Default.GetBytes(paramTexto)
            Dim hashMD5 As New MD5CryptoServiceProvider
            Des.Key = hashMD5.ComputeHash(Encoding.Default.GetBytes(Key))
            Des.Mode = CyphMode
            Dim ms As MemoryStream = New MemoryStream
            Dim cs As CryptoStream = New CryptoStream(ms, Des.CreateEncryptor(), CryptoStreamMode.Write)
            cs.Write(InputbyteArray, 0, InputbyteArray.Length)
            cs.FlushFinalBlock()
            Dim ret As StringBuilder = New StringBuilder
            Dim b() As Byte = ms.ToArray
            ms.Close()
            Dim I As Integer
            For I = 0 To UBound(b)
                ret.AppendFormat("{0:X2}", b(I))
            Next
            Return ret.ToString
        Catch ex As System.Security.Cryptography.CryptographicException
            Throw New Exception
        End Try
    End Function

    Public Function DesencriptarTarjeta(ByVal paramTexto As String) As String
        Dim CyphMode As CipherMode = CipherMode.ECB
        Dim Key As String = "INNOVALED"
        Try
            If paramTexto = String.Empty Then
                Return ""
            Else
                Dim Des As New TripleDESCryptoServiceProvider
                Dim InputbyteArray(CType(paramTexto.Length / 2 - 1, Integer)) As Byte
                Dim hashMD5 As New MD5CryptoServiceProvider
                Des.Key = hashMD5.ComputeHash(Encoding.Default.GetBytes(Key))
                Des.Mode = CyphMode
                Dim X As Integer
                For X = 0 To InputbyteArray.Length - 1
                    Dim IJ As Int32 = (Convert.ToInt32(paramTexto.Substring(X * 2, 2), 16))
                    Dim BT As New ByteConverter
                    InputbyteArray(X) = New Byte
                    InputbyteArray(X) = CType(BT.ConvertTo(IJ, GetType(Byte)), Byte)
                Next
                Dim ms As MemoryStream = New MemoryStream
                Dim cs As CryptoStream = New CryptoStream(ms, Des.CreateDecryptor(), CryptoStreamMode.Write)
                cs.Write(InputbyteArray, 0, InputbyteArray.Length)
                cs.FlushFinalBlock()
                Dim ret As StringBuilder = New StringBuilder
                Dim B() As Byte = ms.ToArray
                ms.Close()
                Dim I As Integer
                For I = 0 To UBound(B)
                    ret.Append(Chr(B(I)))
                Next
                Return ret.ToString
            End If
        Catch ex As System.Security.Cryptography.CryptographicException
            Throw New Exception
        End Try
    End Function

End Class
