Imports NSubstitute
Imports ListaMaestra.VB.Negocio.AgregarProyecto

Namespace AgregarProyecto.CreacionDelProyecto_Tests

    <TestClass()> Public Class EjecuteTests
        Private nuevoProyecto As NuevoProyecto

        <TestInitialize>
        Public Sub Inicialice()
            nuevoProyecto = New NuevoProyecto With {
                .Nombre = "Excepcional",
                .FechaDeInicio = New Date(2018, 10, 26)
            }
        End Sub

        <TestMethod()>
        Public Sub SiEsValidoEnviaAGuardar()
            Dim datos As DatosAbstractos = Substitute.For(Of DatosAbstractos)
            datos.NuevoProyecto = nuevoProyecto

            Dim proyectoCreado = CreacionDelProyecto.Ejecute(datos)

            datos.Received().Guarde(nuevoProyecto)
        End Sub


        <TestMethod()>
        Public Sub SiEsValidoRetornaElProyectoCreado()
            Dim datos As DatosAbstractos = Substitute.For(Of DatosAbstractos)
            datos.NuevoProyecto = nuevoProyecto

            Dim proyectoCreado = CreacionDelProyecto.Ejecute(datos)

            Assert.AreEqual(Of NuevoProyecto)(nuevoProyecto, proyectoCreado)
        End Sub

        <TestMethod()>
        <ExpectedException(GetType(ArgumentException))>
        Public Sub SiNoEsValidoNoEnviaAGuardarYLanzaExcepcion()
            Dim datos As DatosAbstractos = Substitute.For(Of DatosAbstractos)
            nuevoProyecto.Nombre = ""
            datos.NuevoProyecto = nuevoProyecto

            Dim proyectoCreado = CreacionDelProyecto.Ejecute(datos)

            datos.DidNotReceive().Guarde(nuevoProyecto)
        End Sub

    End Class
End Namespace