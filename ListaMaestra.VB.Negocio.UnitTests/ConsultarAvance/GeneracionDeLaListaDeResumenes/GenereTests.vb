Imports ListaMaestra.VB.Negocio.ConsultarAvance

Namespace ConsultarAvance.GeneracionDeResumenDeUnaIteracion_Tests
    <TestClass()> Public Class GenereTests
        Inherits EscenariosDeDatos

        <TestMethod()> Public Sub NoHayIteraciones()
            Dim esperado As Integer = 0

            Dim historias As IEnumerable(Of Historia) = GenereLaListaDeHistorias()
            Dim iteraciones As IEnumerable(Of Integer) = {}
            Dim lista = GeneracionDeLaListaDeResumenes.Genere(historias, iteraciones)
            Dim obtenido = lista.Count

            Assert.AreEqual(esperado, obtenido)
        End Sub

        <TestMethod()> Public Sub HayUnaIteracion()
            Dim esperado As Integer = 1

            Dim historias As IEnumerable(Of Historia) = GenereLaListaDeHistorias()
            Dim iteraciones As IEnumerable(Of Integer) = {1}
            Dim lista = GeneracionDeLaListaDeResumenes.Genere(historias, iteraciones)
            Dim obtenido = lista.Count

            Assert.AreEqual(esperado, obtenido)
        End Sub

        <TestMethod()> Public Sub HayVariasIteraciones()
            Dim esperado As Integer = 4

            Dim historias As IEnumerable(Of Historia) = GenereLaListaDeHistorias()
            Dim iteraciones As IEnumerable(Of Integer) = {1, 2, 3, 4}
            Dim lista = GeneracionDeLaListaDeResumenes.Genere(historias, iteraciones)
            Dim obtenido = lista.Count

            Assert.AreEqual(esperado, obtenido)
        End Sub
    End Class
End Namespace