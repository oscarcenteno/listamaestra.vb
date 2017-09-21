Imports Newtonsoft.Json

Public Class JsonAssert
    Public Shared Sub AreEqual(expected As Object, actual As Object)
        If ReferenceEquals(expected, actual) Then
            Exit Sub
        End If
        If (expected Is Nothing) OrElse (actual Is Nothing) Then
            Throw New AssertFailedException($"JsonAssert.AreEqual failed. Expected:<{expected}>. Actual:<{actual}>")
        End If

        Dim expectedType As Type = expected.[GetType]()
        Dim actualType As Type = actual.[GetType]()

        If expectedType <> actualType Then
            Throw New AssertFailedException($"JsonAssert.AreEqual failed. Expected type:<{expectedType}>. Actual type:<{actualType}>")
        End If

        Dim expectedJson = JsonConvert.SerializeObject(expected)
        Dim actualJson = JsonConvert.SerializeObject(actual)

        Dim areNotEqual As Boolean = Not String.Equals(expectedJson, actualJson)

        If areNotEqual Then
            Dim index As Integer = expectedJson.Zip(actualJson, Function(c1, c2) c1 = c2).TakeWhile(Function(b) b).Count() + 1

            Throw New AssertFailedException($"JsonAssert.AreEqual failed. Expected is different at character {index}. Expected:<{expectedJson}>. Actual:<{actualJson}>")
        End If
    End Sub
End Class
