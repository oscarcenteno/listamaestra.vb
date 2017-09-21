Namespace ConsultarAvance
    Public Class GeneracionDelResumenDeAvance
        Public Shared Function Genere(nombre As String, historias As IEnumerable(Of Historia), iteraciones As IEnumerable(Of Integer)) As ResumenDeAvance
            Dim resumenDeAvance As New ResumenDeAvance With {
                .NombreDelProyecto = nombre,
                .ResumenDeIteraciones = GeneracionDeLaListaDeResumenes.Genere(historias, iteraciones)
            }

            Return resumenDeAvance
        End Function
    End Class
End Namespace