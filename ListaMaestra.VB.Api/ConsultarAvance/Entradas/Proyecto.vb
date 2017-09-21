Imports ListaMaestra.VB.Negocio.ConsultarAvance

Namespace ConsultarAvance
    Public Class Proyecto
        Public Property Nombre As String
        Public Property Historias As IEnumerable(Of Historia)
        Public Property Iteraciones As IEnumerable(Of Iteracion)
    End Class
End Namespace