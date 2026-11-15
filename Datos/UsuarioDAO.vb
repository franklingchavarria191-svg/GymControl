Imports MySqlConnector
Imports System.Data

Public Class UsuarioDAO

    Public Function ObtenerUsuarios() As DataTable

        Dim tabla As New DataTable()

        Using cn As MySqlConnection = ConexionBD.ObtenerConexion()

            cn.Open()

            Dim consulta As String = "SELECT * FROM usuarios"

            Using cmd As New MySqlCommand(consulta, cn)

                Using adaptador As New MySqlDataAdapter(cmd)
                    adaptador.Fill(tabla)
                End Using

            End Using

        End Using

        Return tabla

    End Function


    Public Function ObtenerUsuarioPorNombre(nombreUsuario As String) As DataTable

        Dim tabla As New DataTable()

        Using cn As MySqlConnection = ConexionBD.ObtenerConexion()

            cn.Open()

            Dim consulta As String =
                "SELECT id_usuario, contrasena_hash, sal, id_rol, activo, " &
                "intentos_fallidos, id_socio, id_instructor " &
                "FROM usuarios " &
                "WHERE nombre_usuario = @usuario"

            Using cmd As New MySqlCommand(consulta, cn)

                cmd.Parameters.AddWithValue("@usuario", nombreUsuario)

                Using adaptador As New MySqlDataAdapter(cmd)
                    adaptador.Fill(tabla)
                End Using

            End Using

        End Using

        Return tabla

    End Function


    Public Sub RegistrarIntentoFallido(idUsuario As Integer, intentos As Integer)

        Using cn As MySqlConnection = ConexionBD.ObtenerConexion()

            cn.Open()

            Dim consulta As String =
                "UPDATE usuarios " &
                "SET intentos_fallidos = @intentos, " &
                "activo = CASE WHEN @intentos >= 3 THEN 0 ELSE activo END " &
                "WHERE id_usuario = @idUsuario"

            Using cmd As New MySqlCommand(consulta, cn)

                cmd.Parameters.AddWithValue("@intentos", intentos)
                cmd.Parameters.AddWithValue("@idUsuario", idUsuario)

                cmd.ExecuteNonQuery()

            End Using

        End Using

    End Sub


    Public Sub ReiniciarIntentos(idUsuario As Integer)

        Using cn As MySqlConnection = ConexionBD.ObtenerConexion()

            cn.Open()

            Dim consulta As String =
                "UPDATE usuarios " &
                "SET intentos_fallidos = 0 " &
                "WHERE id_usuario = @idUsuario"

            Using cmd As New MySqlCommand(consulta, cn)

                cmd.Parameters.AddWithValue("@idUsuario", idUsuario)

                cmd.ExecuteNonQuery()

            End Using
        End Using
    End Sub
End Class