Imports System.Web.Mvc
Imports System.Web
Imports EliteHome.EliteHomes.Models
Imports System.Data.SqlClient

Namespace Controllers
    Public Class PropiedadesController
        Inherits Controller

        Public Function ObtenerPropiedades() As List(Of Propiedad)
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
                            .imagen = reader("Imagen") ' Agregar el campo Imagen
                        })
                    End While
                End Using
            End Using
            Return propiedades
        End Function

        Public Sub AgregarPropiedad(propiedad As Propiedad)
            Dim connectionString As String = System.Configuration.ConfigurationManager.ConnectionStrings("EliteHomesDB").ConnectionString

            Using connection As New SqlConnection(connectionString)
                connection.Open()
                Dim query As String = "INSERT INTO Propiedades (Descripcion, Precio, Ubicacion, Estado, Imagen) VALUES (@Descripcion, @Precio, @Ubicacion, @Estado, @Imagen)"
                Dim command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Descripcion", propiedad.Descripcion)
                command.Parameters.AddWithValue("@Precio", propiedad.Precio)
                command.Parameters.AddWithValue("@Ubicacion", propiedad.Ubicacion)
                command.Parameters.AddWithValue("@Estado", propiedad.Estado)
                command.Parameters.AddWithValue("@Imagen", propiedad.imagen)

                command.ExecuteNonQuery()
            End Using
        End Sub

        Public Sub EditarPropiedad(propiedad As Propiedad)
            Dim connectionString As String = System.Configuration.ConfigurationManager.ConnectionStrings("EliteHomesDB").ConnectionString

            Using connection As New SqlConnection(connectionString)
                connection.Open()
                Dim query As String = "UPDATE Propiedades SET Descripcion = @Descripcion, Precio = @Precio, Ubicacion = @Ubicacion, Estado = @Estado, Imagen = @Imagen WHERE Id = @Id"
                Dim command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Descripcion", propiedad.Descripcion)
                command.Parameters.AddWithValue("@Precio", propiedad.Precio)
                command.Parameters.AddWithValue("@Ubicacion", propiedad.Ubicacion)
                command.Parameters.AddWithValue("@Estado", propiedad.Estado)
                command.Parameters.AddWithValue("@Imagen", propiedad.imagen)
                command.Parameters.AddWithValue("@Id", propiedad.Id)

                command.ExecuteNonQuery()
            End Using
        End Sub

    End Class
End Namespace