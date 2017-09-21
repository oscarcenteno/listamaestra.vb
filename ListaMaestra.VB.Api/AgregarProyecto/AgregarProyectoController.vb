Imports System.Web.Http

Namespace AgregarProyecto
    Public Class AgregarProyectoController
        Inherits ApiController

        Private datos As DatosAbstractos

        Public Sub New()
            datos = New DatosPersistentes()
        End Sub

        Public Sub New(datos As DatosAbstractos)
            Me.datos = datos
        End Sub

        ' Para probar este método debemos asegurar que:
        ' 1. Se ejecute las validaciones, de manera que se requiere de una prueba donde una validación falle
        ' 2. Se envíe a guardar, de manera que se requiere que una prueba verifique el llamado
        ' 3. Se retorne el proyecto creado
        <Route("api/proyectos")>
        <HttpPost>
        Public Function AgregueUnProyecto(nuevoProyecto As NuevoProyecto) As IHttpActionResult
            Dim response As IHttpActionResult

            Try
                Validaciones.Valide(nuevoProyecto)
                datos.Guarde(nuevoProyecto)

                response = Ok(nuevoProyecto)
            Catch exception As ArgumentException
                Dim mensaje = exception.Message
                response = BadRequest(mensaje)
            End Try

            Return response
        End Function
    End Class
End Namespace