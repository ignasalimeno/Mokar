Imports BE
Imports MPP

Public Class CuentaCorrienteBLL

#Region "Singleton"
    Private Sub New()
    End Sub

    Private Shared Instancia As CuentaCorrienteBLL
    Public Shared Function ObtenerInstancia() As CuentaCorrienteBLL
        If Instancia Is Nothing Then
            Instancia = New CuentaCorrienteBLL
        End If
        Return Instancia
    End Function
#End Region

    'Crear
    Public Sub CrearCC(Cuenta As CuentaCorrienteBE)
        CuentaCorrienteMPP.ObtenerInstancia.CrearCC(Cuenta)
    End Sub

    'Crear CC pero originada por una NC
    Public Sub CrearCCxNC(Cuenta As CuentaCorrienteBE)
        CuentaCorrienteMPP.ObtenerInstancia.CrearCCxNC(Cuenta)
    End Sub


    'Listar Todo
    Public Function ListarCC() As List(Of CuentaCorrienteBE)
        Return CuentaCorrienteMPP.ObtenerInstancia.ListarCC()
    End Function

    'Modificar
    Public Sub ModificarCCSeleccionada(ByVal Cuenta As CuentaCorrienteBE)
        CuentaCorrienteMPP.ObtenerInstancia.ModificarCC(Cuenta)
    End Sub

    'Obtener por ID
    Public Function ObtenerPorID(ByVal Cuenta As Integer) As CuentaCorrienteBE
        Dim CCObtenida As CuentaCorrienteBE
        CCObtenida = CuentaCorrienteMPP.ObtenerInstancia.ObtenerCCxID(Cuenta)
        Return CCObtenida
    End Function

    'Eliminar
    Public Function EliminarCC(ByVal id As CuentaCorrienteBE)
        Return CuentaCorrienteMPP.ObtenerInstancia.CC_Eliminar(id)
    End Function

    'Obtener por ID del usuario
    Public Function ObtenerPorIDUser(ByVal ID As Integer) As List(Of CuentaCorrienteBE)
        Return CuentaCorrienteMPP.ObtenerInstancia.ObtenerCCxIDUser(ID)
    End Function

    'Obtener por ID del usuario, cuyo saldo NO sea cero
    Public Function ObtenerPorIDUser1(ByVal ID As Integer) As List(Of CuentaCorrienteBE)
        Return CuentaCorrienteMPP.ObtenerInstancia.ObtenerCCxIDUser1(ID)
    End Function

    'Obtener por ID del usuario y actualizar Saldo
    Public Sub ActualizarSaldo(ByVal Saldo As CuentaCorrienteBE)
        CuentaCorrienteMPP.ObtenerInstancia.ActualizarSaldo(Saldo)
    End Sub

End Class
