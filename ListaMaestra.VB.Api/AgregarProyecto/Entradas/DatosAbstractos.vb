Imports ListaMaestra.VB.Negocio.AgregarProyecto

Namespace AgregarProyecto
    Public MustInherit Class DatosAbstractos
        Public MustOverride Sub Guarde(NuevoProyecto As NuevoProyecto)
    End Class
End Namespace