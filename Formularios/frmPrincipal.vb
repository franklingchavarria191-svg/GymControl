
Imports MySqlConnector
Imports System.Data
Imports System.Globalization
Imports System.Drawing

Public Class frmPrincipal

    Private menuReportes As ToolStripItem

    Private Sub frmPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "GymControl - Panel de Control"
        ConfigurarPaneles()
        ConfigurarAccesoReportes()
        AplicarPermisos()
        ActualizarDashboard()
        ActualizarBarraEstado()
    End Sub

    Private Sub ConfigurarAccesoReportes()
        For Each elemento As ToolStripItem In MenuStrip2.Items
            If elemento.Text.Replace("&", "").Trim().Equals(
                "Reportes", StringComparison.OrdinalIgnoreCase) Then

                menuReportes = elemento
                AddHandler elemento.Click, AddressOf AbrirCentroReportes
                Exit For
            End If
        Next
    End Sub

    Private Sub AbrirCentroReportes(sender As Object, e As EventArgs)
        If SesionActual.IdRol <> 1 Then
            MessageBox.Show(
                "No tiene permisos para acceder a los reportes.",
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)
            Return
        End If

        Using ventana As New frmCentroReportes()
            ventana.ShowDialog(Me)
        End Using

        ActualizarDashboard()
    End Sub

    Private Sub ConfigurarPaneles()
        ConfigurarTarjeta(pnlIndicadores, "Socios activos", "0")
        ConfigurarTarjeta(Panel2, "Membresías por vencer", "0")
        ConfigurarTarjeta(Panel3, "Ingresos del mes", "C$ 0.00")
        ConfigurarTarjeta(Panel1, "Clases programadas hoy", "0")
    End Sub

    Private Sub ConfigurarTarjeta(
        panel As Panel,
        titulo As String,
        valor As String
    )
        panel.Controls.Clear()

        Dim lblTitulo As New Label()
        lblTitulo.Text = titulo
        lblTitulo.AutoSize = False
        lblTitulo.TextAlign = ContentAlignment.MiddleCenter
        lblTitulo.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
        lblTitulo.Location = New Point(5, 5)
        lblTitulo.Size = New Size(
            Math.Max(1, panel.Width - 10), 30)

        Dim lblValor As New Label()
        lblValor.Text = valor
        lblValor.AutoSize = False
        lblValor.TextAlign = ContentAlignment.MiddleCenter
        lblValor.Font = New Font("Segoe UI", 24.0F, FontStyle.Bold)
        lblValor.Location = New Point(5, 40)
        lblValor.Size = New Size(
            Math.Max(1, panel.Width - 10),
            Math.Max(1, panel.Height - 45))

        panel.Controls.Add(lblTitulo)
        panel.Controls.Add(lblValor)
    End Sub

    Private Sub ActualizarDashboard()
        CargarSociosActivos()
        CargarMembresiasPorVencer()
        CargarIngresosMes()
        CargarClasesHoy()
    End Sub

    Private Sub CargarSociosActivos()
        Try
            Using cn As MySqlConnection = ConexionBD.ObtenerConexion()
                cn.Open()

                Dim consulta As String =
                    "SELECT COUNT(*) FROM socios WHERE activo = 1"

                Using cmd As New MySqlCommand(consulta, cn)
                    Dim cantidad As Integer =
                        Convert.ToInt32(cmd.ExecuteScalar())

                    ActualizarValorTarjeta(
                        pnlIndicadores, cantidad.ToString())
                End Using
            End Using
        Catch ex As Exception
            ActualizarValorTarjeta(pnlIndicadores, "0")
        End Try
    End Sub

    Private Sub CargarMembresiasPorVencer()
        Try
            Using cn As MySqlConnection = ConexionBD.ObtenerConexion()
                cn.Open()

                Dim consulta As String =
                    "SELECT " &
                    "m.id_membresia, " &
                    "s.nombres, " &
                    "s.apellidos, " &
                    "tm.nombre AS tipo_membresia, " &
                    "m.fecha_vencimiento, " &
                    "m.estado " &
                    "FROM membresias m " &
                    "INNER JOIN socios s " &
                    "ON m.id_socio = s.id_socio " &
                    "INNER JOIN tipos_membresia tm " &
                    "ON m.id_tipo = tm.id_tipo " &
                    "WHERE m.estado <> 'Cancelada' " &
                    "AND m.fecha_vencimiento <= " &
                    "DATE_ADD(CURDATE(), INTERVAL 7 DAY) " &
                    "ORDER BY m.fecha_vencimiento ASC"

                Dim tabla As New DataTable()

                Using cmd As New MySqlCommand(consulta, cn)
                    Using adaptador As New MySqlDataAdapter(cmd)
                        adaptador.Fill(tabla)
                    End Using
                End Using

                dgvPorVencer.DataSource = tabla
                ConfigurarGridMembresias()

                ActualizarValorTarjeta(
                    Panel2, tabla.Rows.Count.ToString())
            End Using
        Catch ex As Exception
            dgvPorVencer.DataSource = Nothing
            ActualizarValorTarjeta(Panel2, "0")
        End Try
    End Sub

    Private Sub ConfigurarGridMembresias()
        If dgvPorVencer.Columns.Count = 0 Then Return

        If dgvPorVencer.Columns.Contains("id_membresia") Then
            dgvPorVencer.Columns("id_membresia").HeaderText = "ID"
        End If

        If dgvPorVencer.Columns.Contains("nombres") Then
            dgvPorVencer.Columns("nombres").HeaderText = "Nombres"
        End If

        If dgvPorVencer.Columns.Contains("apellidos") Then
            dgvPorVencer.Columns("apellidos").HeaderText = "Apellidos"
        End If

        If dgvPorVencer.Columns.Contains("tipo_membresia") Then
            dgvPorVencer.Columns("tipo_membresia").HeaderText = "Membresía"
        End If

        If dgvPorVencer.Columns.Contains("fecha_vencimiento") Then
            dgvPorVencer.Columns("fecha_vencimiento").HeaderText =
                "Fecha vencimiento"
        End If

        If dgvPorVencer.Columns.Contains("estado") Then
            dgvPorVencer.Columns("estado").HeaderText = "Estado"
        End If

        dgvPorVencer.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.Fill
    End Sub

    Private Sub CargarIngresosMes()
        Try
            Using cn As MySqlConnection = ConexionBD.ObtenerConexion()
                cn.Open()

                Dim consulta As String =
                    "SELECT COALESCE(SUM(monto), 0) " &
                    "FROM pagos " &
                    "WHERE anulado = 0 " &
                    "AND YEAR(fecha_pago) = YEAR(CURDATE()) " &
                    "AND MONTH(fecha_pago) = MONTH(CURDATE())"

                Using cmd As New MySqlCommand(consulta, cn)
                    Dim resultado As Object = cmd.ExecuteScalar()
                    Dim ingresos As Decimal = 0D

                    If resultado IsNot Nothing AndAlso
                       Not IsDBNull(resultado) Then

                        ingresos = Convert.ToDecimal(resultado)
                    End If

                    ActualizarValorTarjeta(
                        Panel3, "C$ " & ingresos.ToString("N2"))
                End Using
            End Using
        Catch ex As Exception
            ActualizarValorTarjeta(Panel3, "C$ 0.00")
        End Try
    End Sub

    Private Sub CargarClasesHoy()
        Try
            Using cn As MySqlConnection = ConexionBD.ObtenerConexion()
                cn.Open()

                Dim diaSemana As Integer =
                    Convert.ToInt32(DateTime.Now.DayOfWeek)

                Dim diaBD As Integer

                If diaSemana = 0 Then
                    diaBD = 7
                Else
                    diaBD = diaSemana
                End If

                Dim consulta As String =
                    "SELECT " &
                    "h.id_horario, " &
                    "a.nombre AS actividad, " &
                    "CONCAT(i.nombres, ' ', i.apellidos) AS instructor, " &
                    "s.nombre AS sala, " &
                    "h.hora_inicio, " &
                    "h.hora_fin " &
                    "FROM horarios h " &
                    "INNER JOIN actividades a " &
                    "ON h.id_actividad = a.id_actividad " &
                    "INNER JOIN instructores i " &
                    "ON h.id_instructor = i.id_instructor " &
                    "INNER JOIN salas s " &
                    "ON h.id_sala = s.id_sala " &
                    "WHERE h.dia_semana = @dia " &
                    "AND h.activo = 1 " &
                    "AND a.activo = 1 " &
                    "AND i.activo = 1 " &
                    "AND s.activo = 1 " &
                    "ORDER BY h.hora_inicio"

                Dim tabla As New DataTable()

                Using cmd As New MySqlCommand(consulta, cn)
                    cmd.Parameters.AddWithValue("@dia", diaBD)

                    Using adaptador As New MySqlDataAdapter(cmd)
                        adaptador.Fill(tabla)
                    End Using
                End Using

                dgvClasesHoy.DataSource = tabla
                ConfigurarGridClases()

                ActualizarValorTarjeta(
                    Panel1, tabla.Rows.Count.ToString())
            End Using
        Catch ex As Exception
            dgvClasesHoy.DataSource = Nothing
            ActualizarValorTarjeta(Panel1, "0")
        End Try
    End Sub

    Private Sub ConfigurarGridClases()
        If dgvClasesHoy.Columns.Count = 0 Then Return

        If dgvClasesHoy.Columns.Contains("id_horario") Then
            dgvClasesHoy.Columns("id_horario").HeaderText = "ID"
        End If

        If dgvClasesHoy.Columns.Contains("actividad") Then
            dgvClasesHoy.Columns("actividad").HeaderText = "Actividad"
        End If

        If dgvClasesHoy.Columns.Contains("instructor") Then
            dgvClasesHoy.Columns("instructor").HeaderText = "Instructor"
        End If

        If dgvClasesHoy.Columns.Contains("sala") Then
            dgvClasesHoy.Columns("sala").HeaderText = "Sala"
        End If

        If dgvClasesHoy.Columns.Contains("hora_inicio") Then
            dgvClasesHoy.Columns("hora_inicio").HeaderText = "Inicio"
        End If

        If dgvClasesHoy.Columns.Contains("hora_fin") Then
            dgvClasesHoy.Columns("hora_fin").HeaderText = "Fin"
        End If

        dgvClasesHoy.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.Fill
    End Sub

    Private Sub ActualizarValorTarjeta(
        panel As Panel,
        valor As String
    )
        For Each control As Control In panel.Controls
            If TypeOf control Is Label Then
                Dim etiqueta As Label = DirectCast(control, Label)

                If etiqueta.Font.Size >= 20 Then
                    etiqueta.Text = valor
                    Return
                End If
            End If
        Next
    End Sub

    Private Sub ActualizarBarraEstado()
        ToolStripStatusLabel1.Text =
            "Usuario: " & SesionActual.NombreUsuario

        Select Case SesionActual.IdRol
            Case 1
                ToolStripStatusLabel2.Text = "Rol: Administrador"
            Case 2
                ToolStripStatusLabel2.Text = "Rol: Recepcionista"
            Case 3
                ToolStripStatusLabel2.Text = "Rol: Instructor"
            Case 4
                ToolStripStatusLabel2.Text = "Rol: Socio"
            Case Else
                ToolStripStatusLabel2.Text = "Rol: Desconocido"
        End Select

        ToolStripStatusLabel3.Text =
            "Conectado a GymControl localhost:3307"

        ToolStripStatusLabel4.Text =
            DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
    End Sub

    Private Sub AplicarPermisos()
        Dim esAdministrador As Boolean = SesionActual.IdRol = 1
        Dim esRecepcionista As Boolean = SesionActual.IdRol = 2
        Dim esInstructor As Boolean = SesionActual.IdRol = 3
        Dim esSocio As Boolean = SesionActual.IdRol = 4

        Button2.Visible = esAdministrador OrElse esRecepcionista

        Button3.Visible =
            esAdministrador OrElse esRecepcionista OrElse esSocio

        Button4.Visible =
            esAdministrador OrElse esRecepcionista OrElse esSocio

        Button5.Visible =
            esAdministrador OrElse esRecepcionista OrElse esInstructor

        Button6.Visible =
            esAdministrador OrElse esRecepcionista OrElse esInstructor

        Button7.Visible =
            esAdministrador OrElse esRecepcionista OrElse
            esInstructor OrElse esSocio

        Button8.Visible = esAdministrador
        Button9.Visible = esAdministrador

        mnuSocios.Visible =
            esAdministrador OrElse esRecepcionista

        mnuMembresias.Visible =
            esAdministrador OrElse esRecepcionista OrElse esSocio

        mnuPagos.Visible =
            esAdministrador OrElse esRecepcionista OrElse esSocio

        InstruccionesToolStripMenuItem.Visible =
            esAdministrador OrElse esRecepcionista OrElse esInstructor

        HorariosToolStripMenuItem.Visible =
            esAdministrador OrElse esRecepcionista OrElse
            esInstructor OrElse esSocio

        SeguridadToolStripMenuItem.Visible = esAdministrador

        btnReportes.Visible = esAdministrador

        If menuReportes IsNot Nothing Then
            menuReportes.Visible = esAdministrador
        End If
    End Sub

    Private Sub Button1_Click(
        sender As Object,
        e As EventArgs
    ) Handles Button1.Click

        ActualizarDashboard()
        ActualizarBarraEstado()
    End Sub

    Private Sub Button2_Click(
        sender As Object,
        e As EventArgs
    ) Handles Button2.Click

        Dim formulario As New frmSocios()
        formulario.ShowDialog()
        ActualizarDashboard()
    End Sub

    Private Sub Button11_Click(
        sender As Object,
        e As EventArgs
    ) Handles Button11.Click

        Dim formulario As New frmSocios()
        formulario.ShowDialog()
        ActualizarDashboard()
    End Sub

    Private Sub Button10_Click(
        sender As Object,
        e As EventArgs
    ) Handles Button10.Click

        Dim respuesta As DialogResult =
            MessageBox.Show(
                "¿Desea cerrar la sesión?",
                "GymControl",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question)

        If respuesta <> DialogResult.Yes Then Return

        SesionActual.IdUsuario = 0
        SesionActual.NombreUsuario = ""
        SesionActual.IdRol = 0
        SesionActual.IdSocio = Nothing
        SesionActual.IdInstructor = Nothing

        Dim login As New frmLogin()
        login.Show()
        Me.Close()
    End Sub

    Private Sub mnuSocios_Click(
        sender As Object,
        e As EventArgs
    ) Handles mnuSocios.Click

        If SesionActual.IdRol <> 1 AndAlso
           SesionActual.IdRol <> 2 Then

            MessageBox.Show(
                "No tiene permisos para acceder a socios.",
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)
            Return
        End If

        Dim formulario As New frmSocios()
        formulario.ShowDialog()
        ActualizarDashboard()
    End Sub

    Private Sub Button3_Click(
        sender As Object,
        e As EventArgs
    ) Handles Button3.Click

        Dim ventana As New frmMembresia()
        ventana.ShowDialog()
        ActualizarDashboard()
    End Sub

    Private Sub mnuMembresias_Click(
        sender As Object,
        e As EventArgs
    ) Handles mnuMembresias.Click

        Dim ventana As New frmMembresia()
        ventana.ShowDialog()
        ActualizarDashboard()
    End Sub

    Private Sub Button4_Click(
        sender As Object,
        e As EventArgs
    ) Handles Button4.Click

        Dim ventana As New Metodo_de_pagos()
        ventana.ShowDialog()
        ActualizarDashboard()
    End Sub

    Private Sub mnuPagos_Click(
        sender As Object,
        e As EventArgs
    ) Handles mnuPagos.Click

        Dim ventana As New Metodo_de_pagos()
        ventana.ShowDialog()
        ActualizarDashboard()
    End Sub

    Private Sub Button5_Click(
        sender As Object,
        e As EventArgs
    ) Handles Button5.Click

        MessageBox.Show(
            "El módulo de Instructores está pendiente de implementación.",
            "GymControl",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information)
    End Sub

    Private Sub InstruccionesToolStripMenuItem_Click(
        sender As Object,
        e As EventArgs
    ) Handles InstruccionesToolStripMenuItem.Click

        MessageBox.Show(
            "El módulo de Instructores está pendiente de implementación.",
            "GymControl",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information)
    End Sub

    Private Sub Button6_Click(
        sender As Object,
        e As EventArgs
    ) Handles Button6.Click

        MessageBox.Show(
            "El módulo de Actividades y Salas está pendiente de implementación.",
            "GymControl",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information)
    End Sub

    Private Sub Button7_Click(
        sender As Object,
        e As EventArgs
    ) Handles Button7.Click

        Dim ventana As New frmHorarios()
        ventana.ShowDialog()
        ActualizarDashboard()
    End Sub

    Private Sub HorariosToolStripMenuItem_Click(
        sender As Object,
        e As EventArgs
    ) Handles HorariosToolStripMenuItem.Click

        Dim ventana As New frmHorarios()
        ventana.ShowDialog()
        ActualizarDashboard()
    End Sub

    Private Sub Button8_Click(
        sender As Object,
        e As EventArgs
    ) Handles Button8.Click

        MessageBox.Show(
            "El módulo de Usuarios y Roles está pendiente de implementación.",
            "GymControl",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information)
    End Sub

    Private Sub Button9_Click(
        sender As Object,
        e As EventArgs
    ) Handles Button9.Click

        MessageBox.Show(
            "El módulo de Bitácora de Accesos está pendiente de implementación.",
            "GymControl",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information)
    End Sub

    Private Sub Button12_Click(
        sender As Object,
        e As EventArgs
    ) Handles Button12.Click

        Dim ventana As New Metodo_de_pagos()
        ventana.ShowDialog()
        ActualizarDashboard()
    End Sub

    Private Sub Button13_Click(
        sender As Object,
        e As EventArgs
    ) Handles Button13.Click

        Dim ventana As New frmMembresia()
        ventana.ShowDialog()
        ActualizarDashboard()
    End Sub

    Private Sub Button14_Click(
        sender As Object,
        e As EventArgs
    ) Handles Button14.Click

        Dim ventana As New frmHorarios()
        ventana.ShowDialog()
        ActualizarDashboard()
    End Sub

    Private Sub AyudaToolStripMenuItem_Click(
        sender As Object,
        e As EventArgs
    ) Handles AyudaToolStripMenuItem.Click

        MessageBox.Show(
            "GymControl - Sistema de gestión de gimnasio.",
            "Ayuda",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information)
    End Sub
    Private Sub Button15_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnReportes.Click

        AbrirCentroReportes(sender, e)
    End Sub
End Class
