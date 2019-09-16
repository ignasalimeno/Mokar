Public Interface IABMC(Of T)

    Function Alta(Objeto As T) As Boolean
    Function Baja(Objeto As T) As Boolean
    Function Modificacion(Objeto As T) As Boolean
    Function ListarObjetos() As IEnumerable(Of T)
    Function ListarObjeto(Objeto As T) As T

End Interface
