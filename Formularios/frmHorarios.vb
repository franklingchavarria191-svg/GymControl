Imports MySqlConnector

Public Class frmHorarios

    Private idHorarioSeleccionado As Integer = 0

    Private Sub frmHorarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConfigurarDia()
        ConfigurarHoras()
        CargarInstructores()
        CargarActividades()
        CargarSalas()
        CargarFiltros()
        ConfigurarSemana()
        CargarHorarios()
        Limpiar()
    End Sub

    Private Sub ConfigurarDia()
        cboDia.Items.Clear()
        cboDia.Items.Add("Lunes")
        cboDia.Items.Add("Martes")
        cboDia.Items.Add("Miércoles")
        cboDia.Items.Add("Jueves")
        cboDia.Items.Add("Viernes")
        cboDia.Items.Add("Sábado")
        cboDia.Items.Add("Domingo")
        cboDia.SelectedIndex = 0
    End Sub

    Private Sub ConfigurarHoras()
        dtpHoraInicio.Format = DateTimePickerFormat.Custom
        dtpHoraInicio.CustomFormat = "hh:mm tt"
        dtpHoraInicio.ShowUpDown = True

        dtpHoraFin.Format = DateTimePickerFormat.Custom
        dtpHoraFin.CustomFormat = "hh:mm tt"
        dtpHoraFin.ShowUpDown = True
    End Sub

    Private Sub CargarInstructores()
        Try
            Using cn As MySqlConnection = ConexionBD.ObtenerConexion()

                Dim sql As String =
                    "SELECT id_instructor, CONCAT(nombres, ' ', apellidos) AS nombre " &
                    "FROM instructores " &
                    "WHERE activo = 1 " &
                    "ORDER BY nombres, apellidos"

                Using cmd As New MySqlCommand(sql, cn)

                    cn.Open()

                    Dim dt As New DataTable()

                    Using da As New MySqlDataAdapter(cmd)
                        da.Fill(dt)
                    End Using

                    cboInstructor.DataSource = dt
                    cboInstructor.DisplayMember = "nombre"
                    cboInstructor.ValueMember = "id_instructor"
                    cboInstructor.SelectedIndex = -1

                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error al cargar instructores: " & ex.Message)
        End Try
    End Sub

    Private Sub CargarActividades()
        Try
            Using cn As MySqlConnection = ConexionBD.ObtenerConexion()

                Dim sql As String =
                    "SELECT id_actividad, nombre " &
                    "FROM actividades " &
                    "WHERE activo = 1 " &
                    "ORDER BY nombre"

                Using cmd As New MySqlCommand(sql, cn)

                    cn.Open()

                    Dim dt As New DataTable()

                    Using da As New MySqlDataAdapter(cmd)
                        da.Fill(dt)
                    End Using

                    cboActividad.DataSource = dt
                    cboActividad.DisplayMember = "nombre"
                    cboActividad.ValueMember = "id_actividad"
                    cboActividad.SelectedIndex = -1

                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error al cargar actividades: " & ex.Message)
        End Try
    End Sub

    Private Sub CargarSalas()
        Try
            Using cn As MySqlConnection = ConexionBD.ObtenerConexion()

                Dim sql As String =
                    "SELECT id_sala, nombre " &
                    "FROM salas " &
                    "WHERE activo = 1 " &
                    "ORDER BY nombre"

                Using cmd As New MySqlCommand(sql, cn)

                    cn.Open()

                    Dim dt As New DataTable()

                    Using da As New MySqlDataAdapter(cmd)
                        da.Fill(dt)
                    End Using

                    cboSala.DataSource = dt
                    cboSala.DisplayMember = "nombre"
                    cboSala.ValueMember = "id_sala"
                    cboSala.SelectedIndex = -1

                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error al cargar salas: " & ex.Message)
        End Try
    End Sub

    Private Sub CargarFiltros()
        Try
            Using cn As MySqlConnection = ConexionBD.ObtenerConexion()

                Dim sql As String =
                    "SELECT id_instructor, CONCAT(nombres, ' ', apellidos) AS nombre " &
                    "FROM instructores " &
                    "WHERE activo = 1 " &
                    "ORDER BY nombres, apellidos"

                Using cmd As New MySqlCommand(sql, cn)

                    cn.Open()

                    Dim dt As New DataTable()

                    Using da As New MySqlDataAdapter(cmd)
                        da.Fill(dt)
                    End Using

                    Dim fila As DataRow = dt.NewRow()
                    fila("id_instructor") = 0
                    fila("nombre") = "Todos"
                    dt.Rows.InsertAt(fila, 0)

                    cboFiltroInstructor.DataSource = dt
                    cboFiltroInstructor.DisplayMember = "nombre"
                    cboFiltroInstructor.ValueMember = "id_instructor"
                    cboFiltroInstructor.SelectedIndex = 0

                End Using
            End Using

            Using cn As MySqlConnection = ConexionBD.ObtenerConexion()

                Dim sql As String =
                    "SELECT id_sala, nombre " &
                    "FROM salas " &
                    "WHERE activo = 1 " &
                    "ORDER BY nombre"

                Using cmd As New MySqlCommand(sql, cn)

                    cn.Open()

                    Dim dt As New DataTable()

                    Using da As New MySqlDataAdapter(cmd)
                        da.Fill(dt)
                    End Using

                    Dim fila As DataRow = dt.NewRow()
                    fila("id_sala") = 0
                    fila("nombre") = "Todas"
                    dt.Rows.InsertAt(fila, 0)

                    cboFiltroSala.DataSource = dt
                    cboFiltroSala.DisplayMember = "nombre"
                    cboFiltroSala.ValueMember = "id_sala"
                    cboFiltroSala.SelectedIndex = 0

                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error al cargar filtros: " & ex.Message)
        End Try
    End Sub

    Private Sub ConfigurarSemana()
        dgvSemana.Columns.Clear()
        dgvSemana.Rows.Clear()

        dgvSemana.AllowUserToAddRows = False
        dgvSemana.AllowUserToDeleteRows = False
        dgvSemana.ReadOnly = True
        dgvSemana.MultiSelect = False
        dgvSemana.SelectionMode = DataGridViewSelectionMode.CellSelect
        dgvSemana.RowHeadersVisible = False
        dgvSemana.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        dgvSemana.Columns.Add("Hora", "Hora")
        dgvSemana.Columns.Add("Lunes", "Lunes")
        dgvSemana.Columns.Add("Martes", "Martes")
        dgvSemana.Columns.Add("Miercoles", "Miércoles")
        dgvSemana.Columns.Add("Jueves", "Jueves")
        dgvSemana.Columns.Add("Viernes", "Viernes")
        dgvSemana.Columns.Add("Sabado", "Sábado")

        For hora As Integer = 6 To 19
            dgvSemana.Rows.Add(
                hora.ToString("00") & ":00",
                "",
                "",
                "",
                "",
                "",
                ""
            )
        Next

        dgvSemana.Columns("Hora").FillWeight = 45

        For Each fila As DataGridViewRow In dgvSemana.Rows
            fila.Height = 55
        Next
    End Sub

    Private Sub CargarHorarios()
        ConfigurarSemana()

        Try
            Using cn As MySqlConnection = ConexionBD.ObtenerConexion()

                Dim sql As String =
                    "SELECT h.id_horario, h.dia_semana, h.hora_inicio, h.hora_fin, " &
                    "a.nombre AS actividad, " &
                    "CONCAT(i.nombres, ' ', i.apellidos) AS instructor, " &
                    "s.nombre AS sala " &
                    "FROM horarios h " &
                    "INNER JOIN instructores i ON h.id_instructor = i.id_instructor " &
                    "INNER JOIN actividades a ON h.id_actividad = a.id_actividad " &
                    "INNER JOIN salas s ON h.id_sala = s.id_sala " &
                    "WHERE h.activo = 1 "

                If cboFiltroInstructor.SelectedValue IsNot Nothing AndAlso
                   Convert.ToInt32(cboFiltroInstructor.SelectedValue) <> 0 Then

                    sql &= "AND h.id_instructor = @instructor "
                End If

                If cboFiltroSala.SelectedValue IsNot Nothing AndAlso
                   Convert.ToInt32(cboFiltroSala.SelectedValue) <> 0 Then

                    sql &= "AND h.id_sala = @sala "
                End If

                sql &= "ORDER BY h.dia_semana, h.hora_inicio"

                Using cmd As New MySqlCommand(sql, cn)

                    If cboFiltroInstructor.SelectedValue IsNot Nothing AndAlso
                       Convert.ToInt32(cboFiltroInstructor.SelectedValue) <> 0 Then

                        cmd.Parameters.AddWithValue(
                            "@instructor",
                            cboFiltroInstructor.SelectedValue
                        )
                    End If

                    If cboFiltroSala.SelectedValue IsNot Nothing AndAlso
                       Convert.ToInt32(cboFiltroSala.SelectedValue) <> 0 Then

                        cmd.Parameters.AddWithValue(
                            "@sala",
                            cboFiltroSala.SelectedValue
                        )
                    End If

                    cn.Open()

                    Using dr As MySqlDataReader = cmd.ExecuteReader()

                        While dr.Read()

                            Dim dia As Integer =
                                Convert.ToInt32(dr("dia_semana"))

                            Dim horaInicio As TimeSpan =
                                CType(dr("hora_inicio"), TimeSpan)

                            If dia >= 1 AndAlso dia <= 6 Then

                                Dim fila As Integer =
                                    horaInicio.Hours - 6

                                If fila >= 0 AndAlso
                                   fila < dgvSemana.Rows.Count Then

                                    Dim texto As String =
                                        dr("actividad").ToString() &
                                        Environment.NewLine &
                                        dr("instructor").ToString() &
                                        Environment.NewLine &
                                        dr("sala").ToString()

                                    dgvSemana.Rows(fila).Cells(dia).Value = texto

                                    dgvSemana.Rows(fila).Cells(dia).Tag =
                                        Convert.ToInt32(dr("id_horario"))

                                    dgvSemana.Rows(fila).Cells(dia).Style.WrapMode =
                                        DataGridViewTriState.True

                                End If
                            End If

                        End While

                    End Using
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error al cargar horarios: " & ex.Message)
        End Try
    End Sub

    Private Function HayChoque() As Boolean

        If cboInstructor.SelectedValue Is Nothing OrElse
           cboSala.SelectedValue Is Nothing OrElse
           cboDia.SelectedIndex = -1 Then

            Return False
        End If

        Try
            Using cn As MySqlConnection = ConexionBD.ObtenerConexion()

                Dim sql As String =
                    "SELECT COUNT(*) " &
                    "FROM horarios " &
                    "WHERE activo = 1 " &
                    "AND dia_semana = @dia " &
                    "AND id_horario <> @id " &
                    "AND (id_sala = @sala OR id_instructor = @instructor) " &
                    "AND @inicio < hora_fin " &
                    "AND @fin > hora_inicio"

                Using cmd As New MySqlCommand(sql, cn)

                    cmd.Parameters.AddWithValue(
                        "@dia",
                        cboDia.SelectedIndex + 1
                    )

                    cmd.Parameters.AddWithValue(
                        "@id",
                        idHorarioSeleccionado
                    )

                    cmd.Parameters.AddWithValue(
                        "@sala",
                        cboSala.SelectedValue
                    )

                    cmd.Parameters.AddWithValue(
                        "@instructor",
                        cboInstructor.SelectedValue
                    )

                    cmd.Parameters.AddWithValue(
                        "@inicio",
                        dtpHoraInicio.Value.TimeOfDay
                    )

                    cmd.Parameters.AddWithValue(
                        "@fin",
                        dtpHoraFin.Value.TimeOfDay
                    )

                    cn.Open()

                    Dim cantidad As Integer =
                        Convert.ToInt32(cmd.ExecuteScalar())

                    Return cantidad > 0

                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show(
                "Error al comprobar el horario: " & ex.Message
            )

            Return True
        End Try
    End Function

    Private Function ValidarDatos() As Boolean

        If cboInstructor.SelectedIndex = -1 Then
            MessageBox.Show("Seleccione un instructor.")
            cboInstructor.Focus()
            Return False
        End If

        If cboActividad.SelectedIndex = -1 Then
            MessageBox.Show("Seleccione una actividad.")
            cboActividad.Focus()
            Return False
        End If

        If cboSala.SelectedIndex = -1 Then
            MessageBox.Show("Seleccione una sala.")
            cboSala.Focus()
            Return False
        End If

        If cboDia.SelectedIndex = -1 Then
            MessageBox.Show("Seleccione un día.")
            cboDia.Focus()
            Return False
        End If

        If dtpHoraFin.Value.TimeOfDay <=
           dtpHoraInicio.Value.TimeOfDay Then

            MessageBox.Show(
                "La hora final debe ser mayor que la hora de inicio."
            )

            Return False
        End If

        If HayChoque() Then

            lblChoque.Text =
                "Choque de horarios detectado" &
                Environment.NewLine &
                "La sala o el instructor ya están ocupados en ese horario. No se puede guardar."

            lblChoque.Visible = True

            Return False
        End If

        lblChoque.Visible = False

        Return True
    End Function

    Private Sub btnGuardar_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnGuardar.Click

        If Not ValidarDatos() Then
            Return
        End If

        Try
            Using cn As MySqlConnection = ConexionBD.ObtenerConexion()

                Dim sql As String

                If idHorarioSeleccionado = 0 Then

                    sql =
                        "INSERT INTO horarios " &
                        "(id_instructor, id_actividad, id_sala, dia_semana, hora_inicio, hora_fin, activo) " &
                        "VALUES (@instructor, @actividad, @sala, @dia, @inicio, @fin, @activo)"

                Else

                    sql =
                        "UPDATE horarios SET " &
                        "id_instructor = @instructor, " &
                        "id_actividad = @actividad, " &
                        "id_sala = @sala, " &
                        "dia_semana = @dia, " &
                        "hora_inicio = @inicio, " &
                        "hora_fin = @fin, " &
                        "activo = @activo " &
                        "WHERE id_horario = @id"

                End If

                Using cmd As New MySqlCommand(sql, cn)

                    cmd.Parameters.AddWithValue(
                        "@instructor",
                        cboInstructor.SelectedValue
                    )

                    cmd.Parameters.AddWithValue(
                        "@actividad",
                        cboActividad.SelectedValue
                    )

                    cmd.Parameters.AddWithValue(
                        "@sala",
                        cboSala.SelectedValue
                    )

                    cmd.Parameters.AddWithValue(
                        "@dia",
                        cboDia.SelectedIndex + 1
                    )

                    cmd.Parameters.AddWithValue(
                        "@inicio",
                        dtpHoraInicio.Value.TimeOfDay
                    )

                    cmd.Parameters.AddWithValue(
                        "@fin",
                        dtpHoraFin.Value.TimeOfDay
                    )

                    cmd.Parameters.AddWithValue(
                        "@activo",
                        If(chkActivo.Checked, 1, 0)
                    )

                    If idHorarioSeleccionado <> 0 Then
                        cmd.Parameters.AddWithValue(
                            "@id",
                            idHorarioSeleccionado
                        )
                    End If

                    cn.Open()

                    cmd.ExecuteNonQuery()

                End Using
            End Using

            MessageBox.Show(
                "Horario guardado correctamente."
            )

            Limpiar()
            CargarHorarios()

        Catch ex As Exception
            MessageBox.Show(
                "Error al guardar el horario: " & ex.Message
            )
        End Try

    End Sub

    Private Sub btnNuevo_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnNuevo.Click

        Limpiar()

    End Sub

    Private Sub btnEliminar_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnEliminar.Click

        If idHorarioSeleccionado = 0 Then

            MessageBox.Show(
                "Seleccione un horario."
            )

            Return
        End If

        If MessageBox.Show(
            "¿Desea eliminar este horario?",
            "Confirmar",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        ) <> DialogResult.Yes Then

            Return
        End If

        Try
            Using cn As MySqlConnection = ConexionBD.ObtenerConexion()

                Dim sql As String =
                    "UPDATE horarios " &
                    "SET activo = 0 " &
                    "WHERE id_horario = @id"

                Using cmd As New MySqlCommand(sql, cn)

                    cmd.Parameters.AddWithValue(
                        "@id",
                        idHorarioSeleccionado
                    )

                    cn.Open()

                    cmd.ExecuteNonQuery()

                End Using
            End Using

            MessageBox.Show(
                "Horario eliminado correctamente."
            )

            Limpiar()
            CargarHorarios()

        Catch ex As Exception

            MessageBox.Show(
                "Error al eliminar el horario: " & ex.Message
            )

        End Try

    End Sub

    Private Sub dgvSemana_CellClick(
        sender As Object,
        e As DataGridViewCellEventArgs
    ) Handles dgvSemana.CellClick

        If e.RowIndex < 0 OrElse e.ColumnIndex <= 0 Then
            Return
        End If

        Dim celda As DataGridViewCell =
            dgvSemana.Rows(e.RowIndex).Cells(e.ColumnIndex)

        If celda.Tag Is Nothing Then
            Return
        End If

        idHorarioSeleccionado =
            Convert.ToInt32(celda.Tag)

        CargarDetalleHorario(
            idHorarioSeleccionado
        )

    End Sub

    Private Sub CargarDetalleHorario(id As Integer)

        Try
            Using cn As MySqlConnection = ConexionBD.ObtenerConexion()

                Dim sql As String =
                    "SELECT id_instructor, id_actividad, id_sala, " &
                    "dia_semana, hora_inicio, hora_fin, activo " &
                    "FROM horarios " &
                    "WHERE id_horario = @id"

                Using cmd As New MySqlCommand(sql, cn)

                    cmd.Parameters.AddWithValue(
                        "@id",
                        id
                    )

                    cn.Open()

                    Using dr As MySqlDataReader =
                        cmd.ExecuteReader()

                        If dr.Read() Then

                            cboInstructor.SelectedValue =
                                Convert.ToInt32(
                                    dr("id_instructor")
                                )

                            cboActividad.SelectedValue =
                                Convert.ToInt32(
                                    dr("id_actividad")
                                )

                            cboSala.SelectedValue =
                                Convert.ToInt32(
                                    dr("id_sala")
                                )

                            cboDia.SelectedIndex =
                                Convert.ToInt32(
                                    dr("dia_semana")
                                ) - 1

                            Dim inicio As TimeSpan =
                                CType(
                                    dr("hora_inicio"),
                                    TimeSpan
                                )

                            Dim fin As TimeSpan =
                                CType(
                                    dr("hora_fin"),
                                    TimeSpan
                                )

                            dtpHoraInicio.Value =
                                Date.Today.Add(inicio)

                            dtpHoraFin.Value =
                                Date.Today.Add(fin)

                            chkActivo.Checked =
                                Convert.ToBoolean(
                                    dr("activo")
                                )

                            lblChoque.Visible = False

                        End If

                    End Using
                End Using
            End Using

        Catch ex As Exception

            MessageBox.Show(
                "Error al cargar el horario: " & ex.Message
            )
        End Try
    End Sub
    Private Sub Limpiar()

        idHorarioSeleccionado = 0

        cboInstructor.SelectedIndex = -1
        cboActividad.SelectedIndex = -1
        cboSala.SelectedIndex = -1
        cboDia.SelectedIndex = 0

        dtpHoraInicio.Value =
            Date.Today.AddHours(6)

        dtpHoraFin.Value =
            Date.Today.AddHours(7)

        chkActivo.Checked = True

        lblChoque.Visible = False

    End Sub

    Private Sub btnFiltrar_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnFiltrar.Click

        CargarHorarios()
    End Sub
End Class