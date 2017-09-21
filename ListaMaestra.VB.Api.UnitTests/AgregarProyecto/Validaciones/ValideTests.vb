Imports ListaMaestra.VB.Api.AgregarProyecto

Namespace AgregarProyecto.Validaciones_Tests

    <TestClass()> Public Class ValideTests
        Private nuevoProyecto As NuevoProyecto

        <TestInitialize>
        Public Sub Inicialice()
            nuevoProyecto = New NuevoProyecto With {
                .Nombre = "Excepcional",
                .FechaDeInicio = New Date(2018, 10, 26)
            }
        End Sub

        <TestMethod()>
        Public Sub TodosLosDatosSonValidos()
            Validaciones.Valide(nuevoProyecto)
        End Sub

        <TestMethod()>
        <ExpectedException(GetType(ArgumentException))>
        Public Sub ElProyectoEsRequerido()
            nuevoProyecto = Nothing
            Validaciones.Valide(nuevoProyecto)
        End Sub

        <TestMethod()>
        <ExpectedException(GetType(ArgumentException))>
        Public Sub ElNombreEsRequerido()
            nuevoProyecto.Nombre = String.Empty
            Validaciones.Valide(nuevoProyecto)
        End Sub

        <TestMethod()>
        Public Sub ElNombreNoTieneTamañoMínimo()
            nuevoProyecto.Nombre = "A"
            Validaciones.Valide(nuevoProyecto)
        End Sub

        <TestMethod()>
        <ExpectedException(GetType(ArgumentException))>
        Public Sub ElNombreTieneUnTamañoMáximoDe200Caracteres()
            nuevoProyecto.Nombre = "123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901"
            Validaciones.Valide(nuevoProyecto)
        End Sub

        <TestMethod()>
        Public Sub UnNombreConElTamañoMáximoEsPermitido()
            nuevoProyecto.Nombre = "12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890"
            Validaciones.Valide(nuevoProyecto)
        End Sub

        <TestMethod()>
        <ExpectedException(GetType(ArgumentException))>
        Public Sub ElNombreNoPuedeContenerSolamenteEspaciosEnBlanco()
            nuevoProyecto.Nombre = "    "
            Validaciones.Valide(nuevoProyecto)
        End Sub

        <TestMethod()>
        <ExpectedException(GetType(ArgumentException))>
        Public Sub ElNombreSóloPuedeContenerLetrasYNúmeros()
            nuevoProyecto.Nombre = "alert(""Hola"");"
            Validaciones.Valide(nuevoProyecto)
        End Sub

        <TestMethod()>
        <ExpectedException(GetType(ArgumentException))>
        Public Sub LaFechaEsRequerida()
            nuevoProyecto.FechaDeInicio = Nothing
            Validaciones.Valide(nuevoProyecto)
        End Sub
    End Class
End Namespace