Namespace ConsultarAvance
    Public Class GeneracionDeResumenDeUnaIteracion
        Public Shared Function Genere(historias As IEnumerable(Of Historia), iteracion As Integer) As ResumenDeIteracion
            Dim resumen As New ResumenDeIteracion With {
                .Iteracion = iteracion,
                .PuntosEnElAlcance = CalculoDeLosPuntosEnElAlcance.Calcule(historias, iteracion)
            }

            Return resumen
        End Function
    End Class
End Namespace