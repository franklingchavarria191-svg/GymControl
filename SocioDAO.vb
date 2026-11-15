Imports MySqlConnector
Imports System.Data

Public Class SocioDAO

    Public Function ObtenerSocios() As DataTable

        Dim tabla As New DataTable()

        Using cn As MySqlConnection = ConexionBD.ObtenerConexion()

            cn.Open()

            Dim consulta As String =
                "SELECT " &
                "id_socio, " &
                "cedula, " &
                "nombres, " &
                "apellidos, " &
                "fecha_nacimiento, " &
                "genero, " &
                "telefono, " &
                "correo, " &
                "direccion, " &
                "activo " &
                "FROM socios " &
                "ORDER BY id_socio DESC"

            Using cmd As New MySqlCommand(consulta, cn)

                Using adaptador As New MySqlDataAdapter(cmd)

                    adaptador.Fill(tabla)

                End Using

            End Using

        End Using

        Return tabla

    End Function


    Public Function BuscarSocios(texto As String) As DataTable

        Dim tabla As New DataTable()

        Using cn As MySqlConnection = ConexionBD.ObtenerConexion()

            cn.Open()

            Dim consulta As String =
                "SELECT " &
                "id_socio, " &
                "cedula, " &
                "nombres, " &
                "apellidos, " &
                "fecha_nacimiento, " &
                "genero, " &
                "telefono, " &
                "correo, " &
                "direccion, " &
                "activo " &
                "FROM socios " &
                "WHERE cedula LIKE @texto " &
                "OR nombres LIKE @texto " &
                "OR apellidos LIKE @texto " &
                "OR telefono LIKE @texto " &
                "ORDER BY id_socio DESC"

            Using cmd As New MySqlCommand(consulta, cn)

                cmd.Parameters.AddWithValue(
                    "@texto",
                    "%" & texto & "%"
                )

                Using adaptador As New MySqlDataAdapter(cmd)

                    adaptador.Fill(tabla)

                End Using

            End Using

        End Using

        Return tabla

    End Function


    Public Sub InsertarSocio(
        cedula As String,
        nombres As String,
        apellidos As String,
        fechaNacimiento As Date,
        genero As String,
        telefono As String,
        correo As String,
        direccion As String,
        activo As Boolean
    )

        Using cn As MySqlConnection = ConexionBD.ObtenerConexion()

            cn.Open()

            Dim consulta As String =
                "INSERT INTO socios " &
                "(cedula, nombres, apellidos, fecha_nacimiento, genero, telefono, correo, direccion, activo) " &
                "VALUES " &
                "(@cedula, @nombres, @apellidos, @fecha_nacimiento, @genero, @telefono, @correo, @direccion, @activo)"

            Using cmd As New MySqlCommand(consulta, cn)

                cmd.Parameters.AddWithValue(
                    "@cedula",
                    cedula
                )

                cmd.Parameters.AddWithValue(
                    "@nombres",
                    nombres
                )

                cmd.Parameters.AddWithValue(
                    "@apellidos",
                    apellidos
                )

                cmd.Parameters.AddWithValue(
                    "@fecha_nacimiento",
                    fechaNacimiento
                )

                cmd.Parameters.AddWithValue(
                    "@genero",
                    genero
                )

                cmd.Parameters.AddWithValue(
                    "@telefono",
                    telefono
                )

                cmd.Parameters.AddWithValue(
                    "@correo",
                    correo
                )

                cmd.Parameters.AddWithValue(
                    "@direccion",
                    direccion
                )

                cmd.Parameters.AddWithValue(
                    "@activo",
                    activo
                )

                cmd.ExecuteNonQuery()

            End Using

        End Using

    End Sub


    Public Sub ActualizarSocio(
        idSocio As Integer,
        cedula As String,
        nombres As String,
        apellidos As String,
        fechaNacimiento As Date,
        genero As String,
        telefono As String,
        correo As String,
        direccion As String,
        activo As Boolean
    )

        Using cn As MySqlConnection = ConexionBD.ObtenerConexion()

            cn.Open()

            Dim consulta As String =
                "UPDATE socios SET " &
                "cedula = @cedula, " &
                "nombres = @nombres, " &
                "apellidos = @apellidos, " &
                "fecha_nacimiento = @fecha_nacimiento, " &
                "genero = @genero, " &
                "telefono = @telefono, " &
                "correo = @correo, " &
                "direccion = @direccion, " &
                "activo = @activo " &
                "WHERE id_socio = @id_socio"

            Using cmd As New MySqlCommand(consulta, cn)

                cmd.Parameters.AddWithValue(
                    "@id_socio",
                    idSocio
                )

                cmd.Parameters.AddWithValue(
                    "@cedula",
                    cedula
                )

                cmd.Parameters.AddWithValue(
                    "@nombres",
                    nombres
                )

                cmd.Parameters.AddWithValue(
                    "@apellidos",
                    apellidos
                )

                cmd.Parameters.AddWithValue(
                    "@fecha_nacimiento",
                    fechaNacimiento
                )

                cmd.Parameters.AddWithValue(
                    "@genero",
                    genero
                )

                cmd.Parameters.AddWithValue(
                    "@telefono",
                    telefono
                )

                cmd.Parameters.AddWithValue(
                    "@correo",
                    correo
                )

                cmd.Parameters.AddWithValue(
                    "@direccion",
                    direccion
                )

                cmd.Parameters.AddWithValue(
                    "@activo",
                    activo
                )

                cmd.ExecuteNonQuery()

            End Using

        End Using

    End Sub


    Public Sub EliminarSocio(idSocio As Integer)

        Using cn As MySqlConnection = ConexionBD.ObtenerConexion()

            cn.Open()

            Dim consulta As String =
                "DELETE FROM socios " &
                "WHERE id_socio = @id_socio"

            Using cmd As New MySqlCommand(consulta, cn)

                cmd.Parameters.AddWithValue(
                    "@id_socio",
                    idSocio
                )

                cmd.ExecuteNonQuery()

            End Using

        End Using

    End Sub

End Class