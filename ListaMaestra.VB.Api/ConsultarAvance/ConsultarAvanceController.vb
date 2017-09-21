Imports System.Web.Http

Namespace ConsultarAvance
    Public Class ConsultarAvanceController
        Inherits ApiController

        Private datos As DatosAbstractos

        Public Sub New()
            datos = New DatosPersistentes()
        End Sub

        Public Sub New(datos As DatosAbstractos)
            Me.datos = datos
        End Sub

        <Route("api/proyectos/{id:int}/avance")>
        <HttpGet>
        Public Function ConsulteElAvance(id As Integer) As IHttpActionResult
            Dim proyecto As Proyecto = datos.ObtengaProyecto(id)

            Dim response As IHttpActionResult
            If proyecto Is Nothing Then
                response = NotFound()
            Else
                Dim nombre = proyecto.Nombre
                Dim historias = proyecto.Historias
                Dim iteraciones = proyecto.Iteraciones.Select(Function(c) c.Numero)
                Dim avance = GeneracionDelResumenDeAvance.Genere(nombre, historias, iteraciones)
                response = Ok(avance)
            End If

            Return response
        End Function
    End Class
End Namespace