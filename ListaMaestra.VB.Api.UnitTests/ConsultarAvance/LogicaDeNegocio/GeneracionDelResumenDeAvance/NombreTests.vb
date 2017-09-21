Imports ListaMaestra.VB.Api.ConsultarAvance

Namespace ConsultarAvance.GeneracionDelResumenDeAvance_Tests
    <TestClass()> Public Class NombreTests
        Inherits EscenariosDeDatos

        <TestMethod()> Public Sub AsignaElNombre()
            Dim esperado = "Proyecto Excepcional"

            Dim nombre = "Proyecto Excepcional"
            Dim historias = GenereLaListaDeHistorias()
            Dim iteraciones = {1, 2, 3, 4}
            Dim resumen = GeneracionDelResumenDeAvance.Genere(nombre, historias, iteraciones)
            Dim obtenido = resumen.NombreDelProyecto

            Assert.AreEqual(esperado, obtenido)
        End Sub
    End Class
End Namespace