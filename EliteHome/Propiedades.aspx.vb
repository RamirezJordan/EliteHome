Imports EliteHome.Controllers
Imports EliteHome.EliteHomes.Models
Imports System.Data.SqlClient

Partial Class Propiedades

    Inherits System.Web.UI.Page
    ' Lista de propiedades a la vista
    Public Property PropiedadesList As List(Of Propiedad)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarPropiedades()
        End If
    End Sub
    Private Sub CargarPropiedades()
        Dim propiedades As New List(Of Propiedad)
        Dim connectionString As String = System.Configuration.ConfigurationManager.ConnectionStrings("EliteHomesDB").ConnectionString

        Using connection As New SqlConnection(connectionString)
            connection.Open()
            Dim query As String = "SELECT * FROM Propiedades"
            Dim command As New SqlCommand(query, connection)

            Using reader As SqlDataReader = command.ExecuteReader()
                While reader.Read()
                    propiedades.Add(New Propiedad With {
                        .Id = reader("Id"),
                        .Descripcion = reader("Descripcion"),
                        .Precio = reader("Precio"),
                        .Ubicacion = reader("Ubicacion"),
                        .Estado = reader("Estado"),
                        .Imagen = reader("Imagen")
                    })
                End While
            End Using
        End Using
        PropiedadesList = propiedades
    End Sub
End Class