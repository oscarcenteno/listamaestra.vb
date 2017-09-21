Imports System.Net.Http
Imports ListaMaestra.VB.Api.ConsultarAvance

<TestClass()> Public Class UnitTest1

    <TestMethod()> Public Async Function TestMethod1Async() As Task
        Dim esperado = ObtengaAvanceEsperado()

        Dim basePath As String = "http://localhost:59670/"
        Dim apiPath As String = "api/proyectos/1/avance"
        Dim obtenido = Await GetApi(Of ResumenDeAvance)(basePath, apiPath)

        JsonAssert.AreEqual(esperado, obtenido)
    End Function

    Private Shared Async Function GetApi(Of T)(basePath As String, apiPath As String) As Task(Of T)
        Dim client As New HttpClient With {
            .BaseAddress = New Uri(basePath)
        }

        Dim response = Await client.GetAsync(apiPath)
        Dim content As T
        If response.IsSuccessStatusCode Then
            content = Await response.Content.ReadAsJsonAsync(Of T)()
        Else
            content = Nothing
        End If

        Return content
    End Function

    Public Function ObtengaAvanceEsperado() As ResumenDeAvance
        Dim avance As New ResumenDeAvance With {
            .NombreDelProyecto = "Excepcional"
        }

        Dim resumenes As New List(Of ResumenDeIteracion) From {
            New ResumenDeIteracion() With {.Iteracion = 1, .PuntosEnElAlcance = 19},
            New ResumenDeIteracion() With {.Iteracion = 2, .PuntosEnElAlcance = 27},
            New ResumenDeIteracion() With {.Iteracion = 3, .PuntosEnElAlcance = 40},
            New ResumenDeIteracion() With {.Iteracion = 4, .PuntosEnElAlcance = 40}
        }

        avance.ResumenDeIteraciones = resumenes

        Return avance
    End Function

End Class