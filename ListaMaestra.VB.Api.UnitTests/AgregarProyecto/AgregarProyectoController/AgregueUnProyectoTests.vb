Imports NSubstitute
Imports ListaMaestra.VB.Negocio.AgregarProyecto
Imports ListaMaestra.VB.Api.AgregarProyecto
Imports System.Web.Http.Results

Namespace AgregarProyecto.AgregarProyectoController_Tests

    <TestClass()> Public Class AgregueUnProyectoTests
        Private datos As DatosAbstractos
        Private controller As AgregarProyectoController
        Private nuevoProyecto As NuevoProyecto

        <TestInitialize>
        Public Sub Inicialice()
            InicialiceElController()
            CreeUnnuevoProyectoValido()
        End Sub

        Private Sub InicialiceElController()
            datos = Substitute.For(Of DatosAbstractos)
            controller = New AgregarProyectoController(datos)
        End Sub

        Private Sub CreeUnnuevoProyectoValido()
            nuevoProyecto = New NuevoProyecto With {
                .Nombre = "Excepcional",
                .FechaDeInicio = New Date(2018, 10, 26)
            }
        End Sub

        <TestMethod()>
        Public Sub SiEsValidoEnviaAGuardar()
            Dim proyectoCreado = AgregueYObtengaElProyectoCreado()

            datos.Received().Guarde(proyectoCreado)
        End Sub

        Private Function AgregueYObtengaElProyectoCreado() As NuevoProyecto
            Dim response As OkNegotiatedContentResult(Of NuevoProyecto) = controller.AgregueUnProyecto(nuevoProyecto)

            Return response.Content
        End Function

        <TestMethod()>
        Public Sub SiEsValidoRetornaElProyectoCreado()
            Dim proyectoCreado = AgregueYObtengaElProyectoCreado()

            Assert.AreEqual(nuevoProyecto, proyectoCreado)
        End Sub

        <TestMethod()>
        Public Sub SiNoEsValidoRetornaBadRequestYUnErrorDeValidacion()
            AsigneUnNombreInvalido()
            Dim errorDeValidacion As String = IntenteAgregarYObtengaUnErrorDeValidacion()

            Assert.IsNotNull(errorDeValidacion)
        End Sub

        Private Sub AsigneUnNombreInvalido()
            nuevoProyecto.Nombre = ""
        End Sub

        Private Function IntenteAgregarYObtengaUnErrorDeValidacion() As String
            Dim response As BadRequestErrorMessageResult = controller.AgregueUnProyecto(nuevoProyecto)

            Return response.Message
        End Function

        <TestMethod()>
        Public Sub SiNoEsValidoNoEnviaAGuardar()
            AsigneUnNombreInvalido()
            Dim errorDeValidacion As String = IntenteAgregarYObtengaUnErrorDeValidacion()

            datos.DidNotReceive().Guarde(nuevoProyecto)
        End Sub
    End Class
End Namespace