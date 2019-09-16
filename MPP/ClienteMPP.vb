Imports BE

Public Class ClienteMPP
    Implements IABMC(Of ClienteBE)

    Public Function Alta(Objeto As ClienteBE) As Boolean Implements IABMC(Of ClienteBE).Alta
        Try
            Dim oDatos As New DAL.Datos
            Dim hdatos As New Hashtable
            Dim resultado As Boolean

            hdatos.Add("@tipoConsulta", 1)
            hdatos.Add("@idUsuario", Objeto.idUsuario)
            hdatos.Add("@tipoCliente", Objeto.tipoCliente)
            hdatos.Add("@nombreRazonSocial", Objeto.nombre)
            hdatos.Add("@dniCUIT", Objeto.dni)
            hdatos.Add("@direccion", Objeto.direccion)
            hdatos.Add("@telefono", Objeto.telefono)

            resultado = oDatos.Escribir("s_Cliente_ABMC", hdatos)

            Return resultado
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function Baja(Objeto As ClienteBE) As Boolean Implements IABMC(Of ClienteBE).Baja
        Throw New NotImplementedException()
    End Function

    Public Function Modificacion(Objeto As ClienteBE) As Boolean Implements IABMC(Of ClienteBE).Modificacion
        Throw New NotImplementedException()
    End Function

    Public Function ListarObjetos() As IEnumerable(Of ClienteBE) Implements IABMC(Of ClienteBE).ListarObjetos
        Throw New NotImplementedException()
    End Function

    Public Function ListarObjeto(Objeto As ClienteBE) As ClienteBE Implements IABMC(Of ClienteBE).ListarObjeto
        Throw New NotImplementedException()
    End Function
End Class
