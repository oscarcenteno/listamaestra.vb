Imports ListaMaestra.VB.Negocio.ConsultarAvance

Namespace ConsultarAvance.CalculoDeLosPuntosEnElAlcance_Tests
    <TestClass()> Public Class CalculeTests
        Inherits EscenariosDeDatos

        <TestMethod()> Public Sub NoHayHistorias()
            Dim esperado As Integer = 0

            Dim historias As List(Of Historia) = GenereLaListaDeHistoriasVacia()
            Dim iteracion As Integer = 1
            Dim obtenido As Integer = CalculoDeLosPuntosEnElAlcance.Calcule(historias, iteracion)

            Assert.AreEqual(esperado, obtenido)
        End Sub

        <TestMethod()> Public Sub IteracionInicial()
            Dim esperado As Integer = 19

            Dim historias As List(Of Historia) = GenereLaListaDeHistorias()
            Dim iteracion As Integer = 1
            Dim obtenido As Integer = CalculoDeLosPuntosEnElAlcance.Calcule(historias, iteracion)

            Assert.AreEqual(esperado, obtenido)
        End Sub


        <TestMethod()> Public Sub IteracionConPredecesores()
            Dim esperado As Integer = 35

            Dim historias As List(Of Historia) = GenereLaListaDeHistorias()
            Dim iteracion As Integer = 3
            Dim obtenido As Integer = CalculoDeLosPuntosEnElAlcance.Calcule(historias, iteracion)

            Assert.AreEqual(esperado, obtenido)
        End Sub

        <TestMethod()> Public Sub IteracionDondeSeIgnoraHistoriasSinEstimaciónNumerica()
            Dim esperado As Integer = 35

            Dim historias As List(Of Historia) = GenereLaListaDeHistorias()
            Dim iteracion As Integer = 4
            Dim obtenido As Integer = CalculoDeLosPuntosEnElAlcance.Calcule(historias, iteracion)

            Assert.AreEqual(esperado, obtenido)
        End Sub

    End Class
End Namespace