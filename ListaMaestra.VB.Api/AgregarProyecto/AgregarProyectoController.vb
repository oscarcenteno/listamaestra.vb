Imports System.Net
Imports System.Net.Http
Imports System.Web.Http
Imports ListaMaestra.VB.Negocio.AgregarProyecto

Namespace AgregarProyecto
    Public Class AgregarProyectoController
        Inherits ApiController

        Private datos As DatosAbstractos

        Public Sub New(datos As DatosAbstractos)
            Me.datos = datos
        End Sub


        <Route("api/proyectos")>
        <HttpGet>
        Public Function ObtengaLosProyectos() As IHttpActionResult
            Return Ok({"1", "2"})
        End Function

        <Route("api/proyectos")>
        <HttpPost>
        Public Function AgregueUnProyecto(nuevoProyecto As NuevoProyecto) As IHttpActionResult
            Dim response As IHttpActionResult

            Try
                datos.NuevoProyecto = nuevoProyecto
                Dim proyectoCreado = CreacionDelProyecto.Ejecute(datos)

                response = Ok(proyectoCreado)
            Catch exception As ArgumentException
                response = BadRequest(exception.Message)
            End Try

            Return response
        End Function

        <Route("api/error")>
        <HttpGet>
        Public Function ObtengaError() As IHttpActionResult
            Return BadRequest("El nombre es requerido")
        End Function
    End Class
End Namespace