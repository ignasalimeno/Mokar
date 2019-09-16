Imports BE

Public Class ClienteBLL
    Implements IABMC(Of ClienteBE)

    Sub New()

    End Sub


    Private Shared Instancia As ClienteBLL
    Public Shared Function ObtenerInstancia() As ClienteBLL
        If Instancia Is Nothing Then
            Instancia = New ClienteBLL
        End If
        Return Instancia
    End Function

    Dim oMapper As New MPP.ClienteMPP

    Public Function Alta(Objeto As ClienteBE) As Boolean Implements IABMC(Of ClienteBE).Alta
        Dim resultado As Boolean
        resultado = oMapper.Alta(Objeto)

        Return resultado
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
