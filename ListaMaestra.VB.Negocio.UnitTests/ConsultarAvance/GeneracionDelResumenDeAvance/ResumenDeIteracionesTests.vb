Imports ListaMaestra.VB.Negocio.ConsultarAvance

Namespace ConsultarAvance.GeneracionDelResumenDeAvance_Tests
    <TestClass()> Public Class ResumenDeIteracionesTests
        Inherits EscenariosDeDatos

        <TestMethod()> Public Sub AsignaElResumenDeIteraciones()
            Dim esperado = 4

            Dim nombre = "Proyecto Excepcional"
            Dim historias = GenereLaListaDeHistorias()
            Dim iteraciones = {1, 2, 3, 4}
            Dim resumen = GeneracionDelResumenDeAvance.Genere(nombre, historias, iteraciones)
            Dim resumenDeIteraciones = resumen.ResumenDeIteraciones
            Dim obtenido = resumenDeIteraciones.Count

            Assert.AreEqual(esperado, obtenido)
        End Sub
    End Class
End Namespace