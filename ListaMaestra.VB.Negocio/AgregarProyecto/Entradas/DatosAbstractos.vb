Namespace AgregarProyecto
    Public MustInherit Class DatosAbstractos
        Public Property NuevoProyecto As NuevoProyecto

        Public MustOverride Sub Guarde(NuevoProyecto As NuevoProyecto)
    End Class
End Namespace