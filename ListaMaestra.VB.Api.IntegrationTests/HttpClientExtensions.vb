Imports System.Net.Http
Imports System.Net.Http.Formatting
Imports System.Net.Http.Headers
Imports System.Runtime.CompilerServices

Module HttpClientExtensions
    <Extension()>
    Public Function AcceptJson(client As HttpClient) As HttpClient
        client.DefaultRequestHeaders.Clear()
        client.DefaultRequestHeaders.Accept.Add(New MediaTypeWithQualityHeaderValue("application/json"))

        Return client
    End Function

    <Extension()>
    Public Async Function ReadAsJsonAsync(Of T)(content As HttpContent) As Task(Of T)
        ' I'm only accepting JSON from the server, and I don't want to add a dependency on
        ' System.Runtime.Serialization.Xml which is required when using the default formatters
        Return Await content.ReadAsAsync(Of T)(GetJsonFormatters())
    End Function

    Function GetJsonFormatters() As IEnumerable(Of MediaTypeFormatter)
        Return {New JsonMediaTypeFormatter()}
    End Function

End Module
