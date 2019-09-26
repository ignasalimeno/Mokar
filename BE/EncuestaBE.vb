Public Class EncuestaBE
    Property idEncuesta As Integer
    Property Titulo As String
    Property FechaVencimiento As Date
    Property idTipoEncuesta As Integer
    Property Preguntas As New List(Of EncuestaPreguntaBE)
End Class
