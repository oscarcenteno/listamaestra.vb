Namespace ConsultarAvance
    Public Class CalculoDeLosPuntosEnElAlcance

        Public Shared Function Calcule(historias As IEnumerable(Of Historia), iteracion As Integer) As Integer
            Dim historiasConEstimacion As IEnumerable(Of Historia)
            historiasConEstimacion = historias.Where(Function(historia) TieneEstimacionNumerica(historia))

            Dim historiasEnElAlcance As IEnumerable(Of Historia)
            historiasEnElAlcance = historiasConEstimacion.Where(Function(historia) historia.IntroducidaEn <= iteracion)
            Dim puntosEnElAlcance As Integer
            puntosEnElAlcance = historiasEnElAlcance.Sum(Function(historia) historia.Estimacion)

            Dim historiasFueraDelAlcance As IEnumerable(Of Historia)
            historiasFueraDelAlcance = historiasConEstimacion.Where(Function(historia) historia.FueraDelAlcanceEn <= iteracion And historia.FueraDelAlcanceEn > 0)
            Dim puntosFueraDelAlcance As Integer
            puntosFueraDelAlcance = historiasFueraDelAlcance.Sum(Function(historia) historia.Estimacion)

            Return puntosEnElAlcance - puntosFueraDelAlcance
        End Function

        Public Shared Function TieneEstimacionNumerica(historia As Historia)
            Dim texto As String = historia.Estimacion
            Dim numero As Integer

            Return Integer.TryParse(texto, numero)
        End Function
    End Class
End Namespace