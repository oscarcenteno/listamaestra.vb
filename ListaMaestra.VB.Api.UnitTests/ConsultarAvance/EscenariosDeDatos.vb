Imports ListaMaestra.VB.Api.ConsultarAvance
Imports ListaMaestra.VB.Negocio.ConsultarAvance

Namespace ConsultarAvance
    ' ¿Cómo reducir la duplicación en las pruebas unitarias?
    ' Organizamos los escenarios de datos compartidos en una clase aparte

    Public Class EscenariosDeDatos
        Function ObtengaUnProyecto() As Proyecto
            Dim proyecto As New Proyecto With {
                .Nombre = "Excepcional"
            }

            proyecto.Historias = GenereLaListaDeHistorias()

            Dim iteraciones As New List(Of Iteracion) From {
                New Iteracion() With {.Id = 1, .Numero = 1},
                New Iteracion() With {.Id = 2, .Numero = 2},
                New Iteracion() With {.Id = 3, .Numero = 3},
                New Iteracion() With {.Id = 4, .Numero = 4}
            }
            proyecto.Iteraciones = iteraciones

            Return proyecto
        End Function

        Function GenereElAvanceEsperado() As ResumenDeAvance
            Dim avance As New ResumenDeAvance With {
            .NombreDelProyecto = "Excepcional"
        }

            Dim resumenes As New List(Of ResumenDeIteracion) From {
            New ResumenDeIteracion() With {.Iteracion = 1, .PuntosEnElAlcance = 19},
            New ResumenDeIteracion() With {.Iteracion = 2, .PuntosEnElAlcance = 25},
            New ResumenDeIteracion() With {.Iteracion = 3, .PuntosEnElAlcance = 35},
            New ResumenDeIteracion() With {.Iteracion = 4, .PuntosEnElAlcance = 35}
        }

            avance.ResumenDeIteraciones = resumenes

            Return avance
        End Function

        Function GenereLaListaDeHistoriasVacia() As IEnumerable(Of Historia)
            Return New List(Of Historia)
        End Function

        Function GenereLaListaDeHistorias() As IEnumerable(Of Historia)
            Dim historias As New List(Of Historia) From {
                New Historia(8, 1, 0),
                New Historia(1, 1, 0),
                New Historia(5, 2, 0),
                New Historia(2, 1, 2),
                New Historia(8, 1, 0),
                New Historia(3, 2, 3),
                New Historia(13, 3, 0),
                New Historia("?", 4, 0),
                New Historia("infinito", 4, 0)
            }

            Return historias
        End Function
    End Class
End Namespace