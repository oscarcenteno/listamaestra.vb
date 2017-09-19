Namespace ConsultarAvance
    Public Class GeneracionDeLaListaDeResumenes
        Public Shared Function Genere(historias As IEnumerable(Of Historia), iteraciones As IEnumerable(Of Integer)) As IEnumerable(Of ResumenDeIteracion)
            Dim lista As New List(Of ResumenDeIteracion)

            For Each iteracion In iteraciones
                Dim resumen = GeneracionDeResumenDeUnaIteracion.Genere(historias, iteracion)
                lista.Add(resumen)
            Next

            Return lista
        End Function
    End Class
End Namespace