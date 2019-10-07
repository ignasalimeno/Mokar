Imports BE
Imports MPP

Public Class NotaCreditoBLL

#Region "Singleton"
    Private Sub New()
    End Sub

    Private Shared Instancia As NotaCreditoBLL
    Public Shared Function ObtenerInstancia() As NotaCreditoBLL
        If Instancia Is Nothing Then
            Instancia = New NotaCreditoBLL
        End If
        Return Instancia
    End Function
#End Region

    'Crear
    Public Sub CrearNotaCredito(NC As NotaCreditoBE)
        NotaCreditoMPP.ObtenerInstancia.CrearNotaCredito(NC)
    End Sub

    'Listar Todo
    Public Function ListarNotaCredito() As List(Of NotaCreditoBE)
        Return NotaCreditoMPP.ObtenerInstancia.ListarNotasCredito()
    End Function

    'Obtener por ID
    Public Function ObtenerPorID(ByVal NC As Integer) As NotaCreditoBE
        Dim NCObtenida As NotaCreditoBE
        NCObtenida = NotaCreditoMPP.ObtenerInstancia.ObtenerNCxID(NC)
        Return NCObtenida
    End Function

    'Obtener por ID del usuario
    Public Function ObtenerPorIDUser(ByVal ID As Integer) As List(Of NotaCreditoBE)
        Return NotaCreditoMPP.ObtenerInstancia.ObtenerNCxIDUser(ID)
    End Function

    'Eliminar
    Public Function EliminarNotaCredito(ByVal id As NotaCreditoBE)
        Return NotaCreditoMPP.ObtenerInstancia.EliminarNC(id)
    End Function

    'Modificar
    Public Sub ModificarNCSeleccionada(ByVal NC As NotaCreditoBE)
        NotaCreditoMPP.ObtenerInstancia.ModificarNC(NC)
    End Sub

    'Para obtener el último ID de NC
    Public Function ObtenerIDNC() As NotaCreditoBE
        Return NotaCreditoMPP.ObtenerInstancia.ObtenerIDNC()
    End Function

    'Armo los parametros para la NC a PDF
    Public Function ObtenerNCPorID(ByVal NC As Integer) As NotaCreditoCompletaBE
        Dim NCObtenida As NotaCreditoCompletaBE
        NCObtenida = NotaCreditoMPP.ObtenerInstancia.ObtenerNCCompletaxID(NC)
        Return NCObtenida
    End Function

End Class
