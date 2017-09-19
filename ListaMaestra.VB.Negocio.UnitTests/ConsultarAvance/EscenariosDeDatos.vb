Imports ListaMaestra.VB.Negocio.ConsultarAvance

Namespace ConsultarAvance
    ' ¿Cómo reducir la duplicación en las pruebas unitarias?
    ' Organizamos los escenarios de datos compartidos en una clase aparte

    Public Class EscenariosDeDatos
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