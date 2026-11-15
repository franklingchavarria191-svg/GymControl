
Imports MySqlConnector
Imports System.IO
Imports System.Text.Json

Public Module ConexionBD

    Private Class ConfiguracionConexion
        Public Property Servidor As String
        Public Property Puerto As Integer
        Public Property BaseDatos As String
        Public Property UsuarioPrincipal As String
        Public Property ContrasenaPrincipal As String
        Public Property UsuarioReportes As String
        Public Property ContrasenaReportes As String
    End Class

    Private Function LeerConfiguracion() As ConfiguracionConexion
        Dim ruta As String = Path.Combine(AppContext.BaseDirectory, "conexion.local.json")

        If Not File.Exists(ruta) Then
            Throw New FileNotFoundException("No se encontró conexion.local.json en la carpeta de ejecución.", ruta)
        End If

        Dim contenido As String = File.ReadAllText(ruta)
        Dim configuracion = JsonSerializer.Deserialize(Of ConfiguracionConexion)(contenido)

        If configuracion Is Nothing Then
            Throw New InvalidDataException("El archivo de configuración está vacío o no es válido.")
        End If

        Return configuracion
    End Function

    Private Function CrearCadena(usuario As String, contrasena As String, config As ConfiguracionConexion) As String
        Dim builder As New MySqlConnectionStringBuilder()

        builder.Server = config.Servidor
        builder.Port = CUInt(config.Puerto)
        builder.Database = config.BaseDatos
        builder.UserID = usuario
        builder.Password = contrasena

        Return builder.ConnectionString
    End Function

    Public Function ObtenerConexion() As MySqlConnection
        Dim config = LeerConfiguracion()
        Return New MySqlConnection(CrearCadena(config.UsuarioPrincipal, config.ContrasenaPrincipal, config))
    End Function

    Public Function ObtenerConexionReportes() As MySqlConnection
        Dim config = LeerConfiguracion()
        Return New MySqlConnection(CrearCadena(config.UsuarioReportes, config.ContrasenaReportes, config))
    End Function

    Public Function ProbarConexion(ByRef mensaje As String) As Boolean
        Try
            Using cn As MySqlConnection = ObtenerConexion()
                cn.Open()
                mensaje = "Conexión exitosa con MariaDB."
                Return True
            End Using
        Catch ex As Exception
            mensaje = "Error: " & ex.Message
            Return False
        End Try
    End Function

    Public Function ProbarConexionReportes(ByRef mensaje As String) As Boolean
        Try
            Using cn As MySqlConnection = ObtenerConexionReportes()
                cn.Open()
                mensaje = "Conexión de reportes exitosa con MariaDB."
                Return True
            End Using
        Catch ex As Exception
            mensaje = "Error: " & ex.Message
            Return False
        End Try
    End Function

End Module
