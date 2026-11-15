Imports MySqlConnector
Imports System.Data

Public Class frmPortalSocio

    Private idMembresiaActual As Integer = 0

    Private Sub frmPortalSocio_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Not SesionActual.IdSocio.HasValue Then
            MessageBox.Show(
                "El usuario actual no está asociado a un socio.",
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            Me.Close()
            Return
        End If

        ConfigurarTablas()
        CargarSocio()
        CargarMembresia()
        CargarPagos()
        CargarClases()
        CargarEstado()

    End Sub

    Private Sub ConfigurarTablas()

        dgvPagos.AllowUserToAddRows = False
        dgvPagos.AllowUserToDeleteRows = False
        dgvPagos.ReadOnly = True
        dgvPagos.MultiSelect = False
        dgvPagos.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvPagos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvPagos.RowHeadersVisible = False

        dgvClases.AllowUserToAddRows = False
        dgvClases.AllowUserToDeleteRows = False
        dgvClases.ReadOnly = True
        dgvClases.MultiSelect = False
        dgvClases.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvClases.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvClases.RowHeadersVisible = False

    End Sub

    Private Sub CargarSocio()

        Try

            Using cn As MySqlConnection = ConexionBD.ObtenerConexion()

                Dim sql As String =
                    "SELECT id_socio, nombres, apellidos " &
                    "FROM socios " &
                    "WHERE id_socio = @idSocio"

                Using cmd As New MySqlCommand(sql, cn)

                    cmd.Parameters.AddWithValue(
                        "@idSocio",
                        SesionActual.IdSocio.Value
                    )

                    cn.Open()

                    Using dr As MySqlDataReader = cmd.ExecuteReader()

                        If dr.Read() Then

                            Dim nombreCompleto As String =
                                dr("nombres").ToString() & " " &
                                dr("apellidos").ToString()

                            lblNombreSocio.Text =
                                "Hola, " & nombreCompleto

                            lblInfoSocio.Text =
                                "Socio N.º " &
                                dr("id_socio").ToString()

                        Else

                            MessageBox.Show(
                                "No se encontró la información del socio.",
                                "GymControl",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                            )

                        End If

                    End Using

                End Using

            End Using

        Catch ex As Exception

            MessageBox.Show(
                "Error al cargar los datos del socio: " & ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub

    Private Sub CargarMembresia()

        idMembresiaActual = 0

        lblTipoMembresia.Text = "-"
        lblInicio.Text = "-"
        lblVence.Text = "-"
        lblIncluyeClases.Text = "-"
        lblDiasRestantes.Text = "Días restantes: -"
        lblTotalMembresia.Text = "C$ 0.00"
        lblPagado.Text = "C$ 0.00"
        lblSaldoPendiente.Text = "C$ 0.00"

        prgMembresia.Minimum = 0
        prgMembresia.Maximum = 100
        prgMembresia.Value = 0

        Try

            Using cn As MySqlConnection = ConexionBD.ObtenerConexion()

                Dim sql As String =
                    "SELECT m.id_membresia, m.fecha_inicio, " &
                    "m.fecha_vencimiento, m.precio_pactado, m.estado, " &
                    "t.nombre AS tipo_membresia, " &
                    "t.duracion_dias, t.incluye_clases " &
                    "FROM membresias m " &
                    "INNER JOIN tipos_membresia t " &
                    "ON m.id_tipo = t.id_tipo " &
                    "WHERE m.id_socio = @idSocio " &
                    "ORDER BY " &
                    "CASE WHEN m.estado = 'Activa' THEN 0 ELSE 1 END, " &
                    "m.fecha_vencimiento DESC " &
                    "LIMIT 1"

                Using cmd As New MySqlCommand(sql, cn)

                    cmd.Parameters.AddWithValue(
                        "@idSocio",
                        SesionActual.IdSocio.Value
                    )

                    cn.Open()

                    Using dr As MySqlDataReader = cmd.ExecuteReader()

                        If dr.Read() Then

                            idMembresiaActual =
                                Convert.ToInt32(dr("id_membresia"))

                            Dim fechaInicio As Date =
                                Convert.ToDateTime(dr("fecha_inicio"))

                            Dim fechaVencimiento As Date =
                                Convert.ToDateTime(dr("fecha_vencimiento"))

                            Dim duracion As Integer =
                                Convert.ToInt32(dr("duracion_dias"))

                            Dim precio As Decimal =
                                Convert.ToDecimal(dr("precio_pactado"))

                            Dim incluyeClases As Boolean =
                                Convert.ToBoolean(dr("incluye_clases"))

                            Dim estado As String =
                                dr("estado").ToString()

                            lblTipoMembresia.Text =
                                dr("tipo_membresia").ToString()

                            lblInicio.Text =
                                fechaInicio.ToString("dd/MM/yyyy")

                            lblVence.Text =
                                fechaVencimiento.ToString("dd/MM/yyyy")

                            If incluyeClases Then
                                lblIncluyeClases.Text = "Sí"
                            Else
                                lblIncluyeClases.Text = "No"
                            End If

                            lblTotalMembresia.Text =
                                "C$ " & precio.ToString("N2")

                            Dim diasRestantes As Integer =
                                CInt(
                                    Math.Ceiling(
                                        (fechaVencimiento.Date -
                                         Date.Today).TotalDays
                                    )
                                )

                            If diasRestantes < 0 Then
                                diasRestantes = 0
                            End If

                            lblDiasRestantes.Text =
                                "Días restantes: " &
                                diasRestantes.ToString() &
                                " de " &
                                duracion.ToString()

                            Dim porcentaje As Integer = 0

                            If duracion > 0 Then

                                porcentaje =
                                    CInt(
                                        Math.Round(
                                            (diasRestantes / CDbl(duracion)) *
                                            100
                                        )
                                    )

                            End If

                            If porcentaje < 0 Then
                                porcentaje = 0
                            End If

                            If porcentaje > 100 Then
                                porcentaje = 100
                            End If

                            prgMembresia.Value = porcentaje

                            If estado.Equals(
                                "Activa",
                                StringComparison.OrdinalIgnoreCase
                            ) AndAlso fechaVencimiento.Date >= Date.Today Then

                                lblEstadoCuenta.Text = "ACTIVA"

                            Else

                                lblEstadoCuenta.Text = "VENCIDA"

                            End If

                        Else

                            lblEstadoCuenta.Text =
                                "SIN MEMBRESÍA"

                        End If

                    End Using

                End Using

            End Using

            CargarEstadoCuenta()

        Catch ex As Exception

            MessageBox.Show(
                "Error al cargar la membresía: " & ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub

    Private Sub CargarEstadoCuenta()

        If idMembresiaActual = 0 Then
            lblPagado.Text = "C$ 0.00"
            lblSaldoPendiente.Text = "C$ 0.00"
            Return
        End If

        Try

            Using cn As MySqlConnection = ConexionBD.ObtenerConexion()

                Dim sql As String =
                    "SELECT m.precio_pactado, " &
                    "COALESCE(SUM(CASE WHEN p.anulado = 0 " &
                    "THEN p.monto ELSE 0 END), 0) AS total_pagado " &
                    "FROM membresias m " &
                    "LEFT JOIN pagos p " &
                    "ON m.id_membresia = p.id_membresia " &
                    "WHERE m.id_membresia = @idMembresia " &
                    "GROUP BY m.id_membresia, m.precio_pactado"

                Using cmd As New MySqlCommand(sql, cn)

                    cmd.Parameters.AddWithValue(
                        "@idMembresia",
                        idMembresiaActual
                    )

                    cn.Open()

                    Using dr As MySqlDataReader = cmd.ExecuteReader()

                        If dr.Read() Then

                            Dim total As Decimal =
                                Convert.ToDecimal(
                                    dr("precio_pactado")
                                )

                            Dim pagado As Decimal =
                                Convert.ToDecimal(
                                    dr("total_pagado")
                                )

                            Dim saldo As Decimal =
                                total - pagado

                            If saldo < 0 Then
                                saldo = 0
                            End If

                            lblTotalMembresia.Text =
                                "C$ " & total.ToString("N2")

                            lblPagado.Text =
                                "C$ " & pagado.ToString("N2")

                            lblSaldoPendiente.Text =
                                "C$ " & saldo.ToString("N2")

                        End If

                    End Using

                End Using

            End Using

        Catch ex As Exception

            MessageBox.Show(
                "Error al cargar el estado de cuenta: " &
                ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub

    Private Sub CargarPagos()

        Try

            Using cn As MySqlConnection = ConexionBD.ObtenerConexion()

                Dim sql As String =
                    "SELECT p.fecha_pago AS Fecha, " &
                    "t.nombre AS Concepto, " &
                    "p.monto AS `Monto C$`, " &
                    "p.metodo_pago AS Metodo " &
                    "FROM pagos p " &
                    "INNER JOIN membresias m " &
                    "ON p.id_membresia = m.id_membresia " &
                    "INNER JOIN tipos_membresia t " &
                    "ON m.id_tipo = t.id_tipo " &
                    "WHERE m.id_socio = @idSocio " &
                    "AND p.anulado = 0 " &
                    "ORDER BY p.fecha_pago DESC"

                Using cmd As New MySqlCommand(sql, cn)

                    cmd.Parameters.AddWithValue(
                        "@idSocio",
                        SesionActual.IdSocio.Value
                    )

                    cn.Open()

                    Dim dt As New DataTable()

                    Using da As New MySqlDataAdapter(cmd)
                        da.Fill(dt)
                    End Using

                    dgvPagos.AutoGenerateColumns = True
                    dgvPagos.DataSource = dt

                    If dgvPagos.Columns.Contains("Fecha") Then
                        dgvPagos.Columns("Fecha").DefaultCellStyle.Format =
                            "dd/MM/yyyy"
                    End If

                    If dgvPagos.Columns.Contains("Monto C$") Then
                        dgvPagos.Columns("Monto C$").DefaultCellStyle.Format =
                            "N2"
                    End If

                End Using

            End Using

        Catch ex As Exception

            MessageBox.Show(
                "Error al cargar los pagos: " & ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub

    Private Sub CargarClases()

        Try

            Using cn As MySqlConnection = ConexionBD.ObtenerConexion()

                Dim sql As String =
                    "SELECT " &
                    "CASE h.dia_semana " &
                    "WHEN 1 THEN 'Lunes' " &
                    "WHEN 2 THEN 'Martes' " &
                    "WHEN 3 THEN 'Miércoles' " &
                    "WHEN 4 THEN 'Jueves' " &
                    "WHEN 5 THEN 'Viernes' " &
                    "WHEN 6 THEN 'Sábado' " &
                    "WHEN 7 THEN 'Domingo' " &
                    "END AS Dia, " &
                    "TIME_FORMAT(h.hora_inicio, '%h:%i %p') AS Hora, " &
                    "a.nombre AS Actividad, " &
                    "CONCAT(i.nombres, ' ', i.apellidos) AS Instructor, " &
                    "s.nombre AS Sala " &
                    "FROM horarios h " &
                    "INNER JOIN actividades a " &
                    "ON h.id_actividad = a.id_actividad " &
                    "INNER JOIN instructores i " &
                    "ON h.id_instructor = i.id_instructor " &
                    "INNER JOIN salas s " &
                    "ON h.id_sala = s.id_sala " &
                    "WHERE h.activo = 1 " &
                    "ORDER BY h.dia_semana, h.hora_inicio"

                Using cmd As New MySqlCommand(sql, cn)

                    cn.Open()

                    Dim dt As New DataTable()

                    Using da As New MySqlDataAdapter(cmd)
                        da.Fill(dt)
                    End Using

                    dgvClases.AutoGenerateColumns = True
                    dgvClases.DataSource = dt

                End Using

            End Using

        Catch ex As Exception

            MessageBox.Show(
                "Error al cargar las clases: " & ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub

    Private Sub CargarEstado()

        stsUsuario.Text =
            "Usuario: " & SesionActual.NombreUsuario

        stsRol.Text =
            "Rol: Socio"

        stsModo.Text =
            "Modo: solo lectura"

    End Sub

    Private Sub btnCerrarSesion_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnCerrarSesion.Click

        If MessageBox.Show(
            "¿Desea cerrar sesión?",
            "GymControl",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        ) <> DialogResult.Yes Then

            Return

        End If

        Dim login As New frmLogin()

        login.Show()
        Me.Close()
    End Sub

    Private Sub btnCambiarContrasena_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnCambiarContrasena.Click

        MessageBox.Show(
            "La opción para cambiar contraseña estará disponible próximamente.",
            "GymControl",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information
        )

    End Sub

    Private Sub lblEstadoMembresia_Click(sender As Object, e As EventArgs) Handles lblEstadoMembresia.Click

    End Sub
End Class