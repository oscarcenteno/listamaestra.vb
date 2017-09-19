Imports ListaMaestra.VB.Negocio.ConsultarAvance

Namespace ConsultarAvance.GeneracionDeResumenDeUnaIteracion_Tests
    <TestClass()> Public Class IteracionTests
        Inherits EscenariosDeDatos

        <TestMethod()> Public Sub SeAsignaLaIteracion()
            Dim esperado As Integer = 1

            Dim historias As List(Of Historia) = GenereLaListaDeHistorias()
            Dim iteracion As Integer = 1
            Dim resumen = GeneracionDeResumenDeUnaIteracion.Genere(historias, iteracion)
            Dim obtenido = resumen.Iteracion

            Assert.AreEqual(esperado, obtenido)
        End Sub
    End Class
End Namespace