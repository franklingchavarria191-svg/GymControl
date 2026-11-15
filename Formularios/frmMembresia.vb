Imports MySqlConnector

Public Class frmMembresia

    Private idSocioActual As Integer = 0
    Private idMembresiaActual As Integer = 0
    Private idPagoActual As Integer = 0
    Private idUsuarioActual As Integer = 1

    Private Sub frmMembresia_Load(
        sender As Object,
        e As EventArgs
    ) Handles MyBase.Load

        PrepararPaneles()
        CargarTiposMembresia()

        txtFechaInicio.Text = DateTime.Now.ToString("yyyy-MM-dd")
        txtDuracion.Text = "30"
        txtPrecio.Text = "0.00"

        cmbEstado.Items.Clear()
        cmbEstado.Items.Add("Activa")
        cmbEstado.Items.Add("Suspendida")
        cmbEstado.Items.Add("Cancelada")
        cmbEstado.SelectedIndex = 0

        cmbMetodoPago.Items.Clear()
        cmbMetodoPago.Items.Add("Efectivo")
        cmbMetodoPago.Items.Add("Tarjeta")
        cmbMetodoPago.Items.Add("Transferencia")
        cmbMetodoPago.Items.Add("Depósito")
        cmbMetodoPago.SelectedIndex = 0

        CalcularFechaVencimiento()

    End Sub

    Private Sub PrepararPaneles()

        pnlTotal.Controls.Clear()
        pnlPago.Controls.Clear()
        pnlSaldo.Controls.Clear()

        Dim lblTituloTotal As New Label()
        lblTituloTotal.Name = "lblTituloTotal"
        lblTituloTotal.Dock = DockStyle.Top
        lblTituloTotal.Height = 30
        lblTituloTotal.Text = "TOTAL"
        lblTituloTotal.TextAlign = ContentAlignment.MiddleCenter
        lblTituloTotal.Font = New Font("Segoe UI", 10, FontStyle.Bold)

        Dim lblValorTotal As New Label()
        lblValorTotal.Name = "lblValorTotal"
        lblValorTotal.Dock = DockStyle.Fill
        lblValorTotal.Text = "C$0.00"
        lblValorTotal.TextAlign = ContentAlignment.MiddleCenter
        lblValorTotal.Font = New Font("Segoe UI", 16, FontStyle.Bold)

        Dim lblTituloPago As New Label()
        lblTituloPago.Name = "lblTituloPago"
        lblTituloPago.Dock = DockStyle.Top
        lblTituloPago.Height = 30
        lblTituloPago.Text = "PAGO"
        lblTituloPago.TextAlign = ContentAlignment.MiddleCenter
        lblTituloPago.Font = New Font("Segoe UI", 10, FontStyle.Bold)

        Dim lblValorPago As New Label()
        lblValorPago.Name = "lblValorPago"
        lblValorPago.Dock = DockStyle.Fill
        lblValorPago.Text = "C$0.00"
        lblValorPago.TextAlign = ContentAlignment.MiddleCenter
        lblValorPago.Font = New Font("Segoe UI", 16, FontStyle.Bold)

        Dim lblTituloSaldo As New Label()
        lblTituloSaldo.Name = "lblTituloSaldo"
        lblTituloSaldo.Dock = DockStyle.Top
        lblTituloSaldo.Height = 30
        lblTituloSaldo.Text = "SALDO"
        lblTituloSaldo.TextAlign = ContentAlignment.MiddleCenter
        lblTituloSaldo.Font = New Font("Segoe UI", 10, FontStyle.Bold)

        Dim lblValorSaldo As New Label()
        lblValorSaldo.Name = "lblValorSaldo"
        lblValorSaldo.Dock = DockStyle.Fill
        lblValorSaldo.Text = "C$0.00"
        lblValorSaldo.TextAlign = ContentAlignment.MiddleCenter
        lblValorSaldo.Font = New Font("Segoe UI", 16, FontStyle.Bold)

        pnlTotal.Controls.Add(lblValorTotal)
        pnlTotal.Controls.Add(lblTituloTotal)

        pnlPago.Controls.Add(lblValorPago)
        pnlPago.Controls.Add(lblTituloPago)

        pnlSaldo.Controls.Add(lblValorSaldo)
        pnlSaldo.Controls.Add(lblTituloSaldo)

    End Sub

    Private Sub CargarTiposMembresia()

        Try

            Using cn As MySqlConnection =
                ConexionBD.ObtenerConexion()

                cn.Open()

                Dim sql As String =
                    "SELECT id_tipo, nombre, descripcion, duracion_dias, precio, incluye_clases " &
                    "FROM tipos_membresia " &
                    "WHERE activo = 1 " &
                    "ORDER BY nombre"

                Using cmd As New MySqlCommand(sql, cn)

                    Using rd As MySqlDataReader =
                        cmd.ExecuteReader()

                        Dim lista As New List(Of TipoMembresia)

                        While rd.Read()

                            lista.Add(
                                New TipoMembresia With {
                                    .IdTipo = Convert.ToInt32(rd("id_tipo")),
                                    .Nombre = rd("nombre").ToString(),
                                    .Descripcion = rd("descripcion").ToString(),
                                    .DuracionDias = Convert.ToInt32(rd("duracion_dias")),
                                    .Precio = Convert.ToDecimal(rd("precio")),
                                    .IncluyeClases = Convert.ToBoolean(rd("incluye_clases"))
                                }
                            )

                        End While

                        cmbTipoMembresia.DataSource = lista
                        cmbTipoMembresia.DisplayMember = "Nombre"
                        cmbTipoMembresia.ValueMember = "IdTipo"

                    End Using

                End Using

            End Using

        Catch ex As Exception

            MessageBox.Show(
                "Error al cargar los tipos de membresía: " &
                ex.Message,
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub

    Private Sub cmbTipoMembresia_SelectedIndexChanged(
        sender As Object,
        e As EventArgs
    ) Handles cmbTipoMembresia.SelectedIndexChanged

        If cmbTipoMembresia.SelectedItem Is Nothing Then
            Return
        End If

        Dim tipo As TipoMembresia =
            TryCast(cmbTipoMembresia.SelectedItem, TipoMembresia)

        If tipo Is Nothing Then
            Return
        End If

        txtDuracion.Text = tipo.DuracionDias.ToString()
        txtPrecio.Text = tipo.Precio.ToString("0.00")

        CalcularFechaVencimiento()

    End Sub

    Private Sub txtFechaInicio_TextChanged(
        sender As Object,
        e As EventArgs
    ) Handles txtFechaInicio.TextChanged

        CalcularFechaVencimiento()

    End Sub

    Private Sub txtDuracion_TextChanged(
        sender As Object,
        e As EventArgs
    ) Handles txtDuracion.TextChanged

        CalcularFechaVencimiento()

    End Sub

    Private Sub CalcularFechaVencimiento()

        Dim fechaInicio As DateTime
        Dim duracion As Integer

        If Not DateTime.TryParse(
            txtFechaInicio.Text,
            fechaInicio
        ) Then
            Return
        End If

        If Not Integer.TryParse(
            txtDuracion.Text,
            duracion
        ) Then
            Return
        End If

        txtFechaVencimiento.Text =
            fechaInicio.AddDays(duracion).ToString("yyyy-MM-dd")

    End Sub

    Private Sub btnBuscarSocio_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnBuscarSocio.Click

        BuscarSocio()

    End Sub

    Private Sub BuscarSocio()

        Dim dato As String =
            txtSocios.Text.Trim()

        If dato = "" Then

            MessageBox.Show(
                "Escribí el ID, cédula, nombre o apellido del socio.",
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            Return

        End If

        Try

            Using cn As MySqlConnection =
                ConexionBD.ObtenerConexion()

                cn.Open()

                Dim sql As String =
                    "SELECT id_socio, cedula, nombres, apellidos, activo " &
                    "FROM socios " &
                    "WHERE activo = 1 " &
                    "ORDER BY id_socio"

                Using cmd As New MySqlCommand(
                    sql,
                    cn
                )

                    Using rd As MySqlDataReader =
                        cmd.ExecuteReader()

                        Dim encontrado As Boolean = False

                        While rd.Read()

                            Dim id As String =
                                rd("id_socio").ToString().Trim()

                            Dim cedula As String =
                                rd("cedula").ToString().Trim()

                            Dim nombres As String =
                                rd("nombres").ToString().Trim()

                            Dim apellidos As String =
                                rd("apellidos").ToString().Trim()

                            Dim nombreCompleto As String =
                                nombres & " " & apellidos

                            If String.Equals(
                                dato,
                                id,
                                StringComparison.OrdinalIgnoreCase
                            ) OrElse
                            String.Equals(
                                dato,
                                cedula,
                                StringComparison.OrdinalIgnoreCase
                            ) OrElse
                            nombres.IndexOf(
                                dato,
                                StringComparison.OrdinalIgnoreCase
                            ) >= 0 OrElse
                            apellidos.IndexOf(
                                dato,
                                StringComparison.OrdinalIgnoreCase
                            ) >= 0 OrElse
                            nombreCompleto.IndexOf(
                                dato,
                                StringComparison.OrdinalIgnoreCase
                            ) >= 0 Then

                                idSocioActual =
                                    Convert.ToInt32(
                                        rd("id_socio")
                                    )

                                txtSocios.Text =
                                    nombreCompleto

                                encontrado = True

                                Exit While

                            End If

                        End While

                        If Not encontrado Then

                            idSocioActual = 0
                            idMembresiaActual = 0

                            dgvMembresias.DataSource = Nothing
                            dgvPagos.DataSource = Nothing

                            LimpiarPaneles()

                            MessageBox.Show(
                                "No se encontró el socio." &
                                vbCrLf & vbCrLf &
                                "Buscaste: " & dato,
                                "GymControl",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                            )

                            Return

                        End If

                    End Using

                End Using

            End Using

            CargarMembresiasSocio()

        Catch ex As Exception

            MessageBox.Show(
                "Error al buscar el socio: " &
                ex.Message,
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub

    Private Sub CargarMembresiasSocio()

        If idSocioActual <= 0 Then
            Return
        End If

        Try

            Using cn As MySqlConnection =
                ConexionBD.ObtenerConexion()

                cn.Open()

                Dim sql As String =
                    "SELECT " &
                    "m.id_membresia AS ID, " &
                    "t.nombre AS Membresia, " &
                    "m.fecha_inicio AS Inicio, " &
                    "m.fecha_vencimiento AS Vencimiento, " &
                    "m.precio_pactado AS Precio, " &
                    "m.estado AS Estado " &
                    "FROM membresias m " &
                    "INNER JOIN tipos_membresia t " &
                    "ON m.id_tipo = t.id_tipo " &
                    "WHERE m.id_socio = @id_socio " &
                    "ORDER BY m.fecha_inicio DESC"

                Using cmd As New MySqlCommand(
                    sql,
                    cn
                )

                    cmd.Parameters.AddWithValue(
                        "@id_socio",
                        idSocioActual
                    )

                    Using da As New MySqlDataAdapter(cmd)

                        Dim dt As New DataTable()
                        da.Fill(dt)

                        dgvMembresias.DataSource = dt

                    End Using

                End Using

            End Using

            If dgvMembresias.Columns.Count > 0 Then

                dgvMembresias.Columns("ID").HeaderText =
                    "ID"

                dgvMembresias.Columns("Membresia").HeaderText =
                    "Membresía"

                dgvMembresias.Columns("Inicio").HeaderText =
                    "Fecha inicio"

                dgvMembresias.Columns("Vencimiento").HeaderText =
                    "Fecha vencimiento"

                dgvMembresias.Columns("Precio").HeaderText =
                    "Precio"

                dgvMembresias.Columns("Estado").HeaderText =
                    "Estado"

            End If

            If dgvMembresias.Rows.Count = 0 Then

                idMembresiaActual = 0

                dgvPagos.DataSource = Nothing

                LimpiarPaneles()

            End If

        Catch ex As Exception

            MessageBox.Show(
                "Error al cargar las membresías: " &
                ex.Message,
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub

    Private Sub dgvMembresias_CellClick(
        sender As Object,
        e As DataGridViewCellEventArgs
    ) Handles dgvMembresias.CellClick

        If e.RowIndex < 0 Then
            Return
        End If

        If dgvMembresias.Rows(e.RowIndex).Cells("ID").Value Is Nothing Then
            Return
        End If

        idMembresiaActual =
            Convert.ToInt32(
                dgvMembresias.Rows(e.RowIndex).Cells("ID").Value
            )

        CargarPagosMembresia()

    End Sub

    Private Sub CargarPagosMembresia()

        If idMembresiaActual <= 0 Then
            Return
        End If

        Try

            Using cn As MySqlConnection =
                ConexionBD.ObtenerConexion()

                cn.Open()

                Dim sql As String =
                    "SELECT " &
                    "id_pago AS ID, " &
                    "fecha_pago AS Fecha, " &
                    "monto AS Monto, " &
                    "metodo_pago AS Metodo, " &
                    "referencia AS Referencia, " &
                    "observacion AS Observacion, " &
                    "anulado AS Anulado " &
                    "FROM pagos " &
                    "WHERE id_membresia = @id_membresia " &
                    "ORDER BY fecha_pago DESC"

                Using cmd As New MySqlCommand(
                    sql,
                    cn
                )

                    cmd.Parameters.AddWithValue(
                        "@id_membresia",
                        idMembresiaActual
                    )

                    Using da As New MySqlDataAdapter(cmd)

                        Dim dt As New DataTable()
                        da.Fill(dt)

                        dgvPagos.DataSource = dt

                    End Using

                End Using

            End Using

            CalcularTotales()

        Catch ex As Exception

            MessageBox.Show(
                "Error al cargar los pagos: " &
                ex.Message,
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub

    Private Sub CalcularTotales()

        If idMembresiaActual <= 0 Then

            LimpiarPaneles()
            Return

        End If

        Try

            Using cn As MySqlConnection =
                ConexionBD.ObtenerConexion()

                cn.Open()

                Dim total As Decimal = 0D
                Dim pagado As Decimal = 0D

                Dim sqlTotal As String =
                    "SELECT precio_pactado " &
                    "FROM membresias " &
                    "WHERE id_membresia = @id"

                Using cmdTotal As New MySqlCommand(
                    sqlTotal,
                    cn
                )

                    cmdTotal.Parameters.AddWithValue(
                        "@id",
                        idMembresiaActual
                    )

                    Dim resultado =
                        cmdTotal.ExecuteScalar()

                    If resultado IsNot Nothing AndAlso
                       resultado IsNot DBNull.Value Then

                        total =
                            Convert.ToDecimal(resultado)

                    End If

                End Using

                Dim sqlPago As String =
                    "SELECT COALESCE(SUM(monto), 0) " &
                    "FROM pagos " &
                    "WHERE id_membresia = @id " &
                    "AND anulado = 0"

                Using cmdPago As New MySqlCommand(
                    sqlPago,
                    cn
                )

                    cmdPago.Parameters.AddWithValue(
                        "@id",
                        idMembresiaActual
                    )

                    pagado =
                        Convert.ToDecimal(
                            cmdPago.ExecuteScalar()
                        )

                End Using

                Dim saldo As Decimal =
                    total - pagado

                MostrarTotalPanel(
                    pnlTotal,
                    "C$" & total.ToString("0.00")
                )

                MostrarTotalPanel(
                    pnlPago,
                    "C$" & pagado.ToString("0.00")
                )

                MostrarTotalPanel(
                    pnlSaldo,
                    "C$" & saldo.ToString("0.00")
                )

            End Using

        Catch ex As Exception

            MessageBox.Show(
                "Error al calcular los totales: " &
                ex.Message,
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub

    Private Sub MostrarTotalPanel(
        panel As Panel,
        texto As String
    )

        If panel.Controls.Count = 0 Then
            Return
        End If

        Dim etiqueta As Label = Nothing

        For Each control As Control In panel.Controls

            If control.Name.StartsWith("lblValor") Then

                etiqueta =
                    TryCast(control, Label)

                Exit For

            End If

        Next

        If etiqueta IsNot Nothing Then
            etiqueta.Text = texto
        End If

    End Sub

    Private Sub LimpiarPaneles()

        MostrarTotalPanel(
            pnlTotal,
            "C$0.00"
        )

        MostrarTotalPanel(
            pnlPago,
            "C$0.00"
        )

        MostrarTotalPanel(
            pnlSaldo,
            "C$0.00"
        )

    End Sub

    Private Sub btnRegistrar_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnRegistrar.Click

        If idSocioActual <= 0 Then

            MessageBox.Show(
                "Primero buscá un socio.",
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            Return

        End If

        If cmbTipoMembresia.SelectedItem Is Nothing Then

            MessageBox.Show(
                "Seleccioná un tipo de membresía.",
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            Return

        End If

        Dim fechaInicio As DateTime
        Dim fechaVencimiento As DateTime
        Dim duracion As Integer
        Dim precio As Decimal

        If Not DateTime.TryParse(
            txtFechaInicio.Text,
            fechaInicio
        ) Then

            MessageBox.Show(
                "La fecha de inicio no es válida.",
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            Return

        End If

        If Not Integer.TryParse(
            txtDuracion.Text,
            duracion
        ) Then

            MessageBox.Show(
                "La duración no es válida.",
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            Return

        End If

        If Not DateTime.TryParse(
            txtFechaVencimiento.Text,
            fechaVencimiento
        ) Then

            MessageBox.Show(
                "La fecha de vencimiento no es válida.",
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            Return

        End If

        If Not Decimal.TryParse(
            txtPrecio.Text,
            precio
        ) Then

            MessageBox.Show(
                "El precio no es válido.",
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            Return

        End If

        Try

            Dim tipo As TipoMembresia =
                DirectCast(
                    cmbTipoMembresia.SelectedItem,
                    TipoMembresia
                )

            Using cn As MySqlConnection =
                ConexionBD.ObtenerConexion()

                cn.Open()

                Dim sql As String =
                    "INSERT INTO membresias " &
                    "(id_socio, id_tipo, fecha_inicio, fecha_vencimiento, precio_pactado, estado) " &
                    "VALUES " &
                    "(@socio, @tipo, @inicio, @vencimiento, @precio, @estado)"

                Using cmd As New MySqlCommand(
                    sql,
                    cn
                )

                    cmd.Parameters.AddWithValue(
                        "@socio",
                        idSocioActual
                    )

                    cmd.Parameters.AddWithValue(
                        "@tipo",
                        tipo.IdTipo
                    )

                    cmd.Parameters.AddWithValue(
                        "@inicio",
                        fechaInicio
                    )

                    cmd.Parameters.AddWithValue(
                        "@vencimiento",
                        fechaVencimiento
                    )

                    cmd.Parameters.AddWithValue(
                        "@precio",
                        precio
                    )

                    cmd.Parameters.AddWithValue(
                        "@estado",
                        cmbEstado.Text
                    )

                    cmd.ExecuteNonQuery()

                    idMembresiaActual =
                        Convert.ToInt32(
                            cmd.LastInsertedId
                        )

                End Using

            End Using

            MessageBox.Show(
                "Membresía registrada correctamente.",
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )

            CargarMembresiasSocio()

        Catch ex As Exception

            MessageBox.Show(
                "Error al registrar la membresía: " &
                ex.Message,
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub

    Private Sub btnRenovar_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnRenovar.Click

        If idMembresiaActual <= 0 Then

            MessageBox.Show(
                "Seleccioná una membresía primero.",
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            Return

        End If

        Try

            Dim fechaVencimiento As DateTime
            Dim duracion As Integer

            If Not DateTime.TryParse(
                txtFechaVencimiento.Text,
                fechaVencimiento
            ) Then

                MessageBox.Show(
                    "La fecha de vencimiento no es válida.",
                    "GymControl",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                )

                Return

            End If

            If Not Integer.TryParse(
                txtDuracion.Text,
                duracion
            ) Then

                MessageBox.Show(
                    "La duración no es válida.",
                    "GymControl",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                )

                Return

            End If

            Dim nuevaFecha As DateTime =
                fechaVencimiento.AddDays(duracion)

            Using cn As MySqlConnection =
                ConexionBD.ObtenerConexion()

                cn.Open()

                Dim sql As String =
                    "UPDATE membresias " &
                    "SET fecha_vencimiento = @fecha, estado = 'Activa' " &
                    "WHERE id_membresia = @id"

                Using cmd As New MySqlCommand(
                    sql,
                    cn
                )

                    cmd.Parameters.AddWithValue(
                        "@fecha",
                        nuevaFecha
                    )

                    cmd.Parameters.AddWithValue(
                        "@id",
                        idMembresiaActual
                    )

                    cmd.ExecuteNonQuery()

                End Using

            End Using

            txtFechaVencimiento.Text =
                nuevaFecha.ToString("yyyy-MM-dd")

            cmbEstado.Text = "Activa"

            MessageBox.Show(
                "Membresía renovada correctamente.",
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )

            CargarMembresiasSocio()

        Catch ex As Exception

            MessageBox.Show(
                "Error al renovar la membresía: " &
                ex.Message,
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub

    Private Sub btnSuspender_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnSuspender.Click

        CambiarEstadoMembresia("Suspendida")

    End Sub

    Private Sub btnCancelar_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnCancelar.Click

        CambiarEstadoMembresia("Cancelada")

    End Sub

    Private Sub CambiarEstadoMembresia(
        estado As String
    )

        If idMembresiaActual <= 0 Then

            MessageBox.Show(
                "Seleccioná una membresía primero.",
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            Return

        End If

        Try

            Using cn As MySqlConnection =
                ConexionBD.ObtenerConexion()

                cn.Open()

                Dim sql As String =
                    "UPDATE membresias " &
                    "SET estado = @estado " &
                    "WHERE id_membresia = @id"

                Using cmd As New MySqlCommand(
                    sql,
                    cn
                )

                    cmd.Parameters.AddWithValue(
                        "@estado",
                        estado
                    )

                    cmd.Parameters.AddWithValue(
                        "@id",
                        idMembresiaActual
                    )

                    cmd.ExecuteNonQuery()

                End Using

            End Using

            cmbEstado.Text = estado

            MessageBox.Show(
                "Membresía actualizada correctamente.",
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )

            CargarMembresiasSocio()

        Catch ex As Exception

            MessageBox.Show(
                "Error al actualizar la membresía: " &
                ex.Message,
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub

    Private Sub btnRegistrarPago_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnRegistrarPago.Click

        If idMembresiaActual <= 0 Then

            MessageBox.Show(
                "Seleccioná una membresía primero.",
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            Return

        End If

        Dim monto As Decimal

        If Not Decimal.TryParse(
            txtMonto.Text,
            monto
        ) OrElse monto <= 0 Then

            MessageBox.Show(
                "Ingresá un monto válido.",
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            Return

        End If

        Try

            Using cn As MySqlConnection =
                ConexionBD.ObtenerConexion()

                cn.Open()

                Dim sql As String =
                    "INSERT INTO pagos " &
                    "(id_membresia, id_usuario_registro, fecha_pago, monto, metodo_pago, referencia, observacion, anulado) " &
                    "VALUES " &
                    "(@membresia, @usuario, NOW(), @monto, @metodo, @referencia, @observacion, 0)"

                Using cmd As New MySqlCommand(
                    sql,
                    cn
                )

                    cmd.Parameters.AddWithValue(
                        "@membresia",
                        idMembresiaActual
                    )

                    cmd.Parameters.AddWithValue(
                        "@usuario",
                        idUsuarioActual
                    )

                    cmd.Parameters.AddWithValue(
                        "@monto",
                        monto
                    )

                    cmd.Parameters.AddWithValue(
                        "@metodo",
                        cmbMetodoPago.Text
                    )

                    cmd.Parameters.AddWithValue(
                        "@referencia",
                        txtReferencia.Text.Trim()
                    )

                    cmd.Parameters.AddWithValue(
                        "@observacion",
                        txtObservacion.Text.Trim()
                    )

                    cmd.ExecuteNonQuery()

                End Using

            End Using

            MessageBox.Show(
                "Pago registrado correctamente.",
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )

            txtMonto.Clear()
            txtReferencia.Clear()
            txtObservacion.Clear()

            CargarPagosMembresia()

        Catch ex As Exception

            MessageBox.Show(
                "Error al registrar el pago: " &
                ex.Message,
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub

    Private Sub dgvPagos_CellClick(
        sender As Object,
        e As DataGridViewCellEventArgs
    ) Handles dgvPagos.CellClick

        If e.RowIndex < 0 Then
            Return
        End If

        If dgvPagos.Rows(e.RowIndex).Cells("ID").Value Is Nothing Then
            Return
        End If

        idPagoActual =
            Convert.ToInt32(
                dgvPagos.Rows(e.RowIndex).Cells("ID").Value
            )

    End Sub

    Private Sub btnAnularPago_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnAnularPago.Click

        If idPagoActual <= 0 Then

            MessageBox.Show(
                "Seleccioná un pago primero.",
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            Return

        End If

        Try

            Using cn As MySqlConnection =
                ConexionBD.ObtenerConexion()

                cn.Open()

                Dim sql As String =
                    "UPDATE pagos " &
                    "SET anulado = 1 " &
                    "WHERE id_pago = @id"

                Using cmd As New MySqlCommand(
                    sql,
                    cn
                )

                    cmd.Parameters.AddWithValue(
                        "@id",
                        idPagoActual
                    )

                    cmd.ExecuteNonQuery()

                End Using

            End Using

            MessageBox.Show(
                "Pago anulado correctamente.",
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )

            idPagoActual = 0

            CargarPagosMembresia()

        Catch ex As Exception

            MessageBox.Show(
                "Error al anular el pago: " &
                ex.Message,
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub

    Private Sub btnImprimirRecibo_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnImprimirRecibo.Click

        If idPagoActual <= 0 Then

            MessageBox.Show(
                "Seleccioná un pago primero.",
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            Return

        End If

        Try

            Using cn As MySqlConnection =
                ConexionBD.ObtenerConexion()

                cn.Open()

                Dim sql As String =
                    "SELECT " &
                    "p.id_pago, " &
                    "p.fecha_pago, " &
                    "p.monto, " &
                    "p.metodo_pago, " &
                    "p.referencia, " &
                    "s.nombres, " &
                    "s.apellidos, " &
                    "t.nombre AS membresia " &
                    "FROM pagos p " &
                    "INNER JOIN membresias m " &
                    "ON p.id_membresia = m.id_membresia " &
                    "INNER JOIN socios s " &
                    "ON m.id_socio = s.id_socio " &
                    "INNER JOIN tipos_membresia t " &
                    "ON m.id_tipo = t.id_tipo " &
                    "WHERE p.id_pago = @id"

                Using cmd As New MySqlCommand(
                    sql,
                    cn
                )

                    cmd.Parameters.AddWithValue(
                        "@id",
                        idPagoActual
                    )

                    Using rd As MySqlDataReader =
                        cmd.ExecuteReader()

                        If rd.Read() Then

                            Dim recibo As String =
                                "GYMCONTROL" & vbCrLf &
                                "============================" & vbCrLf &
                                "RECIBO DE PAGO" & vbCrLf &
                                "============================" & vbCrLf &
                                "No. Pago: " &
                                rd("id_pago").ToString() & vbCrLf &
                                "Socio: " &
                                rd("nombres").ToString() &
                                " " &
                                rd("apellidos").ToString() & vbCrLf &
                                "Membresía: " &
                                rd("membresia").ToString() & vbCrLf &
                                "Fecha: " &
                                Convert.ToDateTime(
                                    rd("fecha_pago")
                                ).ToString(
                                    "dd/MM/yyyy HH:mm"
                                ) & vbCrLf &
                                "Monto: C$" &
                                Convert.ToDecimal(
                                    rd("monto")
                                ).ToString("0.00") & vbCrLf &
                                "Método: " &
                                rd("metodo_pago").ToString() & vbCrLf &
                                "Referencia: " &
                                rd("referencia").ToString() & vbCrLf &
                                "============================"

                            MessageBox.Show(
                                recibo,
                                "Recibo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                            )

                        Else

                            MessageBox.Show(
                                "No se encontró el pago.",
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
                "Error al generar el recibo: " &
                ex.Message,
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub

    Private Sub Label14_Click(sender As Object, e As EventArgs) Handles Label14.Click

    End Sub
End Class

Public Class TipoMembresia

    Public Property IdTipo As Integer
    Public Property Nombre As String
    Public Property Descripcion As String
    Public Property DuracionDias As Integer
    Public Property Precio As Decimal
    Public Property IncluyeClases As Boolean

    Public Overrides Function ToString() As String
        Return Nombre
    End Function

End Class