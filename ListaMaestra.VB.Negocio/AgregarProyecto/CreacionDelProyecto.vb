Namespace AgregarProyecto
    Public Class CreacionDelProyecto

        ' Para probar este método debemos asegurar que:
        ' 1. Se ejecute las validaciones, de manera que se requiere de una prueba donde una validación falle y lance una excepción
        ' 2. Se envíe a guardar, de manera que se requiere que una prueba verifique el llamado
        ' 3. Se retorne el NuevoProyecto creado
        Public Shared Function Ejecute(datos As DatosAbstractos) As NuevoProyecto
            Dim nuevoProyecto = datos.NuevoProyecto
            Validaciones.Valide(nuevoProyecto)

            datos.Guarde(nuevoProyecto)

            Return nuevoProyecto
        End Function
    End Class
End Namespace