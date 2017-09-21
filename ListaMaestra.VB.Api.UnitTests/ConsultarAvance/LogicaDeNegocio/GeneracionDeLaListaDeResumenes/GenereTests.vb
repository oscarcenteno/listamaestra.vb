Imports ListaMaestra.VB.Api.ConsultarAvance

Namespace ConsultarAvance.GeneracionDeResumenDeUnaIteracion_Tests
    <TestClass()> Public Class GenereTests
        Inherits EscenariosDeDatos

        <TestMethod()> Public Sub GeneraUnaListaVaciaSiNoHayIteraciones()
            Dim esperado As Integer = 0

            Dim historias As IEnumerable(Of Historia) = GenereLaListaDeHistorias()
            Dim iteraciones As IEnumerable(Of Integer) = {}
            Dim lista = GeneracionDeLaListaDeResumenes.Genere(historias, iteraciones)
            Dim obtenido = lista.Count

            Assert.AreEqual(esperado, obtenido)
        End Sub

        <TestMethod()> Public Sub GeneraUnaListaConUnResumenSiHayUnaIteracion()
            Dim esperado As Integer = 1

            Dim historias As IEnumerable(Of Historia) = GenereLaListaDeHistorias()
            Dim iteraciones As IEnumerable(Of Integer) = {1}
            Dim lista = GeneracionDeLaListaDeResumenes.Genere(historias, iteraciones)
            Dim obtenido = lista.Count

            Assert.AreEqual(esperado, obtenido)
        End Sub

        <TestMethod()> Public Sub GeneraUnaListaConUnResumenPorCadaIteracion()
            Dim esperado As Integer = 4

            Dim historias As IEnumerable(Of Historia) = GenereLaListaDeHistorias()
            Dim iteraciones As IEnumerable(Of Integer) = {1, 2, 3, 4}
            Dim lista = GeneracionDeLaListaDeResumenes.Genere(historias, iteraciones)
            Dim obtenido = lista.Count

            Assert.AreEqual(esperado, obtenido)
        End Sub

        <TestMethod()> Public Sub SiempreGeneraResumenesConContenido()
            Dim historias As IEnumerable(Of Historia) = GenereLaListaDeHistorias()
            Dim iteraciones As IEnumerable(Of Integer) = {1, 2, 3, 4}
            Dim lista = GeneracionDeLaListaDeResumenes.Genere(historias, iteraciones)

            CollectionAssert.AllItemsAreNotNull(lista)
        End Sub
    End Class
End Namespace