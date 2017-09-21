Imports ListaMaestra.VB.Negocio.ConsultarAvance

Namespace ConsultarAvance
    Friend Class DatosPersistentes
        Inherits DatosAbstractos

        Public Overrides Function ObtengaProyecto(id As Integer) As Proyecto
            Dim nuevoProyecto As New Proyecto With {
                .Nombre = "Excepcional"
            }

            Dim historias As New List(Of Historia) From {
                New Historia(8, 1, 0),
                New Historia(1, 1, 0),
                New Historia(5, 2, 0),
                New Historia(2, 1, 0),
                New Historia(8, 1, 0),
                New Historia(3, 2, 0),
                New Historia(13, 3, 0),
                New Historia("?", 4, 0),
                New Historia("infinito", 4, 0)
            }
            nuevoProyecto.Historias = historias

            Dim iteraciones As New List(Of Iteracion) From {
                New Iteracion() With {.Id = 1, .Numero = 1},
                New Iteracion() With {.Id = 2, .Numero = 2},
                New Iteracion() With {.Id = 3, .Numero = 3},
                New Iteracion() With {.Id = 4, .Numero = 4}
            }
            nuevoProyecto.Iteraciones = iteraciones

            Return nuevoProyecto
        End Function
    End Class
End Namespace
