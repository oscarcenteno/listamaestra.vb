Namespace ConsultarAvance

    Public Class Historia
        Public Sub New(estimacion As String, introducidaEn As Integer, fueraDelAlcanceEn As Integer)
            Me.Estimacion = estimacion
            Me.IntroducidaEn = introducidaEn
            Me.FueraDelAlcanceEn = fueraDelAlcanceEn
        End Sub

        Public Property Estimacion As String
        Public Property IntroducidaEn As Integer
        Public Property FueraDelAlcanceEn As Integer
    End Class

End Namespace