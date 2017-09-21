Imports ListaMaestra.VB.Api.ConsultarAvance

Namespace ConsultarAvance.GeneracionDeResumenDeUnaIteracion_Tests
    <TestClass()> Public Class PuntosEnElAlcanceTests
        Inherits EscenariosDeDatos

        <TestMethod()> Public Sub SeAsignaLosPuntosEnElAlcance()
            Dim esperado As Integer = 19

            Dim historias As List(Of Historia) = GenereLaListaDeHistorias()
            Dim iteracion As Integer = 1
            Dim resumen = GeneracionDeResumenDeUnaIteracion.Genere(historias, iteracion)
            Dim obtenido = resumen.PuntosEnElAlcance

            Assert.AreEqual(esperado, obtenido)
        End Sub
    End Class
End Namespace