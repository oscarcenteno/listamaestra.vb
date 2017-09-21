Imports NSubstitute
Imports ListaMaestra.VB.Negocio.ConsultarAvance
Imports ListaMaestra.VB.Api.ConsultarAvance
Imports System.Web.Http.Results

Namespace ConsultarAvance.ConsultarAvanceController_Tests

    <TestClass()> Public Class ConsulteElAvanceTests
        Inherits EscenariosDeDatos

        Private datos As DatosAbstractos
        Private controller As ConsultarAvanceController

        <TestInitialize>
        Public Sub Inicialice()
            datos = Substitute.For(Of DatosAbstractos)
            controller = New ConsultarAvanceController(datos)
        End Sub

        <TestMethod()>
        Public Sub SiExisteRetornaElAvanceEsperado()
            Dim esperado = GenereElAvanceEsperado()

            Dim obtenido = GenereElAvanceDeUnProyectoExistente()

            JsonAssert.AreEqual(esperado, obtenido)
        End Sub

        Private Function GenereElAvanceDeUnProyectoExistente() As ResumenDeAvance
            Dim proyecto As Proyecto = ObtengaUnProyecto()
            datos.ObtengaProyecto(1).Returns(proyecto)
            Dim response As OkNegotiatedContentResult(Of ResumenDeAvance)
            response = controller.ConsulteElAvance(1)

            Return response.Content
        End Function

        <TestMethod()>
        Public Sub SiNoExisteRetornaNotFound()
            Dim esperado = GetType(NotFoundResult)

            Dim obtenido = ObtengaTipoDeResponseSiElProyectoNoExiste()

            Assert.AreEqual(esperado, obtenido)
        End Sub

        Private Function ObtengaTipoDeResponseSiElProyectoNoExiste() As Type
            Dim proyecto As Proyecto = Nothing
            datos.ObtengaProyecto(1).Returns(proyecto)
            Dim response = controller.ConsulteElAvance(1)

            Return response.GetType
        End Function
    End Class
End Namespace