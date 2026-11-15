Imports System.Data

Public Class frmLogin

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        lblMensaje.Text = ""
        lblMensaje.Visible = False

        txtContraseña.UseSystemPasswordChar = True

        Dim mensaje As String = ""

        If ConexionBD.ProbarConexion(mensaje) Then
            stsConexion.Text = "Conectado a MariaDB"
        Else
            stsConexion.Text = "Sin conexión"
        End If

        Me.AcceptButton = btnIngresar
        Me.CancelButton = btnSalir

    End Sub

    Private Sub chkMostrar_CheckedChanged(
        sender As Object,
        e As EventArgs
    ) Handles chkMostrar.CheckedChanged

        If chkMostrar.Checked Then
            txtContraseña.UseSystemPasswordChar = False
        Else
            txtContraseña.UseSystemPasswordChar = True
        End If

    End Sub

    Private Sub btnSalir_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnSalir.Click

        Application.Exit()

    End Sub

    Private Sub btnIngresar_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnIngresar.Click

        lblMensaje.Text = ""
        lblMensaje.Visible = False

        Dim nombreUsuario As String = txtUsuario.Text.Trim()
        Dim contrasena As String = txtContraseña.Text

        If nombreUsuario = "" OrElse contrasena = "" Then

            lblMensaje.Text = "Ingrese usuario y contraseña."
            lblMensaje.Visible = True
            Return

        End If

        Try

            Dim dao As New UsuarioDAO()

            Dim tabla As DataTable =
                dao.ObtenerUsuarioPorNombre(nombreUsuario)

            If tabla.Rows.Count = 0 Then

                lblMensaje.Text = "Usuario o contraseña incorrectos."
                lblMensaje.Visible = True
                Return

            End If

            Dim fila As DataRow = tabla.Rows(0)

            Dim idUsuario As Integer =
                Convert.ToInt32(fila("id_usuario"))

            Dim intentosFallidos As Integer =
                Convert.ToInt32(fila("intentos_fallidos"))

            If Not Convert.ToBoolean(fila("activo")) Then

                lblMensaje.Text =
                    "La cuenta está bloqueada o inactiva."

                lblMensaje.Visible = True
                Return

            End If

            If intentosFallidos >= 3 Then

                lblMensaje.Text =
                    "La cuenta está bloqueada por demasiados intentos."

                lblMensaje.Visible = True
                Return

            End If

            Dim sal As String =
                fila("sal").ToString()

            Dim hashGuardado As String =
                fila("contrasena_hash").ToString()

            If Not SeguridadPassword.Verificar(
                contrasena,
                sal,
                hashGuardado
            ) Then

                intentosFallidos += 1

                dao.RegistrarIntentoFallido(
                    idUsuario,
                    intentosFallidos
                )

                If intentosFallidos >= 3 Then

                    lblMensaje.Text =
                        "Cuenta bloqueada. Ha superado los 3 intentos."

                Else

                    Dim restantes As Integer =
                        3 - intentosFallidos

                    lblMensaje.Text =
                        "Usuario o contraseña incorrectos. " &
                        "Intentos restantes: " &
                        restantes.ToString()

                End If

                lblMensaje.Visible = True

                Return

            End If

            SesionActual.IdUsuario =
                idUsuario

            SesionActual.NombreUsuario =
                nombreUsuario

            SesionActual.IdRol =
                Convert.ToInt32(fila("id_rol"))

            If IsDBNull(fila("id_socio")) Then

                SesionActual.IdSocio = Nothing

            Else

                SesionActual.IdSocio =
                    Convert.ToInt32(fila("id_socio"))

            End If

            If IsDBNull(fila("id_instructor")) Then

                SesionActual.IdInstructor = Nothing

            Else

                SesionActual.IdInstructor =
                    Convert.ToInt32(fila("id_instructor"))

            End If

            dao.ReiniciarIntentos(idUsuario)

            MessageBox.Show(
                "Inicio de sesión correcto.",
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )

            If SesionActual.IdRol = 4 Then

                If Not SesionActual.IdSocio.HasValue Then

                    MessageBox.Show(
                        "Este usuario tiene rol de socio, pero no está asociado a ningún socio.",
                        "GymControl",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    )

                    Return

                End If

                Dim portal As New frmPortalSocio()

                portal.Show()

                Me.Hide()

            Else

                Dim principal As New frmPrincipal()

                principal.Show()

                Me.Hide()

            End If

        Catch ex As Exception

            MessageBox.Show(
                "Error al iniciar sesión: " & ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub

    Private Sub txtContraseña_TextChanged(
        sender As Object,
        e As EventArgs
    ) Handles txtContraseña.TextChanged

    End Sub

End Class