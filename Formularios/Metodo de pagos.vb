Imports MySqlConnector
Imports System.Data

Public Class Metodo_de_pagos

    Private Sub Metodo_de_pagos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConfigurarFormulario()
        CargarSocios("")
        CargarMetodosPago()
        CargarEstados()
        CargarPagos()
        LimpiarInformacion()
    End Sub

    Private Sub ConfigurarFormulario()
        cboSocio.DropDownStyle = ComboBoxStyle.DropDownList
        cboMembresia.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
        cboEstado.DropDownStyle = ComboBoxStyle.DropDownList

        nudMonto.DecimalPlaces = 2
        nudMonto.Minimum = 0
        nudMonto.Maximum = 1000000

        DGVpAGOS.ReadOnly = True
        DGVpAGOS.AllowUserToAddRows = False
        DGVpAGOS.AllowUserToDeleteRows = False
        DGVpAGOS.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DGVpAGOS.MultiSelect = False

        DateTimePicker1.Value = New DateTime(
            DateTime.Now.Year,
            DateTime.Now.Month,
            1
        )

        DateTimePicker2.Value = DateTime.Now
    End Sub

    Private Sub CargarMetodosPago()
        ComboBox1.Items.Clear()
        ComboBox1.Items.Add("Efectivo")
        ComboBox1.Items.Add("Tarjeta")
        ComboBox1.Items.Add("Transferencia")

        If ComboBox1.Items.Count > 0 Then
            ComboBox1.SelectedIndex = 0
        End If
    End Sub

    Private Sub CargarEstados()
        cboEstado.Items.Clear()
        cboEstado.Items.Add("Todos")
        cboEstado.Items.Add("Valido")
        cboEstado.Items.Add("Anulado")
        cboEstado.SelectedIndex = 0
    End Sub

    Private Sub CargarSocios(filtro As String)
        Try
            Using cn As MySqlConnection = ConexionBD.ObtenerConexion()
                cn.Open()

                Dim sql As String =
                    "SELECT " &
                    "id_socio, " &
                    "CONCAT(nombres, ' ', apellidos) AS nombre_completo " &
                    "FROM socios " &
                    "WHERE activo = 1 "

                If filtro.Trim() <> "" Then
                    sql &= "AND (" &
                           "nombres LIKE @filtro OR " &
                           "apellidos LIKE @filtro OR " &
                           "cedula LIKE @filtro OR " &
                           "CONCAT(nombres, ' ', apellidos) LIKE @filtro" &
                           ") "
                End If

                sql &= "ORDER BY nombres, apellidos"

                Using cmd As New MySqlCommand(sql, cn)

                    If filtro.Trim() <> "" Then
                        cmd.Parameters.AddWithValue(
                            "@filtro",
                            "%" & filtro.Trim() & "%"
                        )
                    End If

                    Dim tabla As New DataTable()

                    Using da As New MySqlDataAdapter(cmd)
                        da.Fill(tabla)
                    End Using

                    cboSocio.DataSource = Nothing
                    cboSocio.DataSource = tabla
                    cboSocio.DisplayMember = "nombre_completo"
                    cboSocio.ValueMember = "id_socio"

                    If tabla.Rows.Count > 0 Then
                        cboSocio.SelectedIndex = 0
                    Else
                        cboSocio.SelectedIndex = -1
                        cboMembresia.DataSource = Nothing
                        LimpiarInformacion()
                    End If

                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show(
                "Error al cargar socios: " & ex.Message,
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )
        End Try
    End Sub

    Private Sub CargarMembresias(idSocio As Integer)
        Try
            Using cn As MySqlConnection = ConexionBD.ObtenerConexion()
                cn.Open()

                Dim sql As String =
                    "SELECT " &
                    "m.id_membresia, " &
                    "m.id_socio, " &
                    "m.id_tipo, " &
                    "m.fecha_inicio, " &
                    "m.fecha_vencimiento, " &
                    "m.precio_pactado, " &
                    "m.estado, " &
                    "tm.nombre AS tipo, " &
                    "CONCAT(" &
                    "tm.nombre, ' - ', " &
                    "DATE_FORMAT(m.fecha_inicio, '%d/%m/%Y'), " &
                    "' a ', " &
                    "DATE_FORMAT(m.fecha_vencimiento, '%d/%m/%Y')" &
                    ") AS descripcion " &
                    "FROM membresias m " &
                    "INNER JOIN tipos_membresia tm " &
                    "ON m.id_tipo = tm.id_tipo " &
                    "WHERE m.id_socio = @idSocio " &
                    "ORDER BY m.fecha_inicio DESC"

                Using cmd As New MySqlCommand(sql, cn)

                    cmd.Parameters.AddWithValue(
                        "@idSocio",
                        idSocio
                    )

                    Dim tabla As New DataTable()

                    Using da As New MySqlDataAdapter(cmd)
                        da.Fill(tabla)
                    End Using

                    cboMembresia.DataSource = Nothing
                    cboMembresia.DataSource = tabla
                    cboMembresia.DisplayMember = "descripcion"
                    cboMembresia.ValueMember = "id_membresia"

                    If tabla.Rows.Count > 0 Then
                        cboMembresia.SelectedIndex = 0
                    Else
                        cboMembresia.SelectedIndex = -1
                        LimpiarInformacionMembresia()
                    End If

                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show(
                "Error al cargar membresías: " & ex.Message,
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )
        End Try
    End Sub

    Private Sub MostrarInformacionMembresia()
        If cboSocio.SelectedIndex = -1 OrElse
           cboMembresia.SelectedIndex = -1 Then

            LimpiarInformacion()
            Return
        End If

        Try
            Dim idMembresia As Integer =
                Convert.ToInt32(cboMembresia.SelectedValue)

            Using cn As MySqlConnection = ConexionBD.ObtenerConexion()
                cn.Open()

                Dim sql As String =
                    "SELECT " &
                    "m.id_membresia, " &
                    "m.fecha_inicio, " &
                    "m.fecha_vencimiento, " &
                    "m.precio_pactado, " &
                    "tm.nombre AS tipo, " &
                    "CONCAT(s.nombres, ' ', s.apellidos) AS socio, " &
                    "COALESCE((" &
                    "SELECT SUM(p.monto) " &
                    "FROM pagos p " &
                    "WHERE p.id_membresia = m.id_membresia " &
                    "AND p.anulado = 0" &
                    "), 0) AS pagado " &
                    "FROM membresias m " &
                    "INNER JOIN socios s " &
                    "ON m.id_socio = s.id_socio " &
                    "INNER JOIN tipos_membresia tm " &
                    "ON m.id_tipo = tm.id_tipo " &
                    "WHERE m.id_membresia = @idMembresia"

                Using cmd As New MySqlCommand(sql, cn)

                    cmd.Parameters.AddWithValue(
                        "@idMembresia",
                        idMembresia
                    )

                    Using lector As MySqlDataReader =
                        cmd.ExecuteReader()

                        If lector.Read() Then

                            Dim precio As Decimal =
                                Convert.ToDecimal(
                                    lector("precio_pactado")
                                )

                            Dim pagado As Decimal =
                                Convert.ToDecimal(
                                    lector("pagado")
                                )

                            Dim saldo As Decimal =
                                precio - pagado

                            If saldo < 0 Then
                                saldo = 0
                            End If

                            iblSocio.Text =
                                "Socio: " &
                                lector("socio").ToString()

                            iblMembresia.Text =
                                "Membresía: #" &
                                lector("id_membresia").ToString()

                            iblTipoMembresia.Text =
                                "Tipo: " &
                                lector("tipo").ToString()

                            iblFechaInicio.Text =
                                "Fecha inicio: " &
                                Convert.ToDateTime(
                                    lector("fecha_inicio")
                                ).ToString("dd/MM/yyyy")

                            iblFechaVencimiento.Text =
                                "Fecha vencimiento: " &
                                Convert.ToDateTime(
                                    lector("fecha_vencimiento")
                                ).ToString("dd/MM/yyyy")

                            iblPrecioTotal.Text =
                                "Precio total: C$ " &
                                precio.ToString("N2")

                            Label8.Text =
                                "Monto pagado: C$ " &
                                pagado.ToString("N2")

                            Label9.Text =
                                "Saldo pendiente: C$ " &
                                saldo.ToString("N2")

                            nudMonto.Value =
                                Math.Min(
                                    nudMonto.Maximum,
                                    saldo
                                )

                        Else
                            LimpiarInformacion()
                        End If

                    End Using
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show(
                "Error al cargar información de la membresía: " &
                ex.Message,
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )
        End Try
    End Sub

    Private Function ObtenerSaldoPendiente(
        idMembresia As Integer
    ) As Decimal

        Using cn As MySqlConnection = ConexionBD.ObtenerConexion()
            cn.Open()

            Dim sql As String =
                "SELECT " &
                "GREATEST(" &
                "m.precio_pactado - COALESCE(SUM(" &
                "CASE WHEN p.anulado = 0 THEN p.monto ELSE 0 END" &
                "), 0), 0) AS saldo " &
                "FROM membresias m " &
                "LEFT JOIN pagos p " &
                "ON m.id_membresia = p.id_membresia " &
                "WHERE m.id_membresia = @idMembresia " &
                "GROUP BY m.id_membresia, m.precio_pactado"

            Using cmd As New MySqlCommand(sql, cn)

                cmd.Parameters.AddWithValue(
                    "@idMembresia",
                    idMembresia
                )

                Dim resultado As Object =
                    cmd.ExecuteScalar()

                If resultado Is Nothing OrElse
                   IsDBNull(resultado) Then
                    Return 0D
                End If

                Return Convert.ToDecimal(resultado)

            End Using
        End Using
    End Function

    Private Sub RegistrarPago()
        If cboSocio.SelectedIndex = -1 Then
            MessageBox.Show(
                "Seleccione un socio.",
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )
            Return
        End If

        If cboMembresia.SelectedIndex = -1 Then
            MessageBox.Show(
                "Seleccione una membresía.",
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )
            Return
        End If

        If nudMonto.Value <= 0 Then
            MessageBox.Show(
                "Ingrese un monto válido.",
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )
            Return
        End If

        If ComboBox1.SelectedIndex = -1 Then
            MessageBox.Show(
                "Seleccione un método de pago.",
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )
            Return
        End If

        Try
            Dim idMembresia As Integer =
                Convert.ToInt32(
                    cboMembresia.SelectedValue
                )

            Dim monto As Decimal =
                nudMonto.Value

            Dim saldo As Decimal =
                ObtenerSaldoPendiente(
                    idMembresia
                )

            If saldo <= 0 Then
                MessageBox.Show(
                    "Esta membresía no tiene saldo pendiente.",
                    "GymControl",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                )
                Return
            End If

            If monto > saldo Then
                MessageBox.Show(
                    "El monto no puede ser mayor al saldo pendiente de C$ " &
                    saldo.ToString("N2") & ".",
                    "GymControl",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                )
                Return
            End If

            Using cn As MySqlConnection =
                ConexionBD.ObtenerConexion()

                cn.Open()

                Dim sql As String =
                    "INSERT INTO pagos " &
                    "(" &
                    "id_membresia, " &
                    "id_usuario_registro, " &
                    "fecha_pago, " &
                    "monto, " &
                    "metodo_pago, " &
                    "referencia, " &
                    "observacion, " &
                    "anulado" &
                    ") " &
                    "VALUES " &
                    "(" &
                    "@idMembresia, " &
                    "@idUsuario, " &
                    "NOW(), " &
                    "@monto, " &
                    "@metodo, " &
                    "@referencia, " &
                    "@observacion, " &
                    "0" &
                    ")"

                Using cmd As New MySqlCommand(sql, cn)

                    cmd.Parameters.AddWithValue(
                        "@idMembresia",
                        idMembresia
                    )

                    cmd.Parameters.AddWithValue(
                        "@idUsuario",
                        SesionActual.IdUsuario
                    )

                    cmd.Parameters.AddWithValue(
                        "@monto",
                        monto
                    )

                    cmd.Parameters.AddWithValue(
                        "@metodo",
                        ComboBox1.SelectedItem.ToString()
                    )

                    If String.IsNullOrWhiteSpace(
                        TextBox1.Text
                    ) Then

                        cmd.Parameters.AddWithValue(
                            "@referencia",
                            DBNull.Value
                        )

                    Else

                        cmd.Parameters.AddWithValue(
                            "@referencia",
                            TextBox1.Text.Trim()
                        )

                    End If

                    If String.IsNullOrWhiteSpace(
                        TextBox2.Text
                    ) Then

                        cmd.Parameters.AddWithValue(
                            "@observacion",
                            DBNull.Value
                        )

                    Else

                        cmd.Parameters.AddWithValue(
                            "@observacion",
                            TextBox2.Text.Trim()
                        )

                    End If

                    cmd.ExecuteNonQuery()

                End Using
            End Using

            MessageBox.Show(
                "Pago registrado correctamente.",
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )

            MostrarInformacionMembresia()
            CargarPagos()

            TextBox1.Clear()
            TextBox2.Clear()

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

    Private Sub CargarPagos()
        Try
            Using cn As MySqlConnection =
                ConexionBD.ObtenerConexion()

                cn.Open()

                Dim sql As String =
                    "SELECT " &
                    "p.id_pago AS ID, " &
                    "p.fecha_pago AS `Fecha de pago`, " &
                    "CONCAT(s.nombres, ' ', s.apellidos) AS Socio, " &
                    "tm.nombre AS Membresia, " &
                    "p.monto AS Monto, " &
                    "p.metodo_pago AS Metodo, " &
                    "p.referencia AS Referencia, " &
                    "p.observacion AS Observacion, " &
                    "CASE " &
                    "WHEN p.anulado = 1 THEN 'Anulado' " &
                    "ELSE 'Valido' " &
                    "END AS Estado " &
                    "FROM pagos p " &
                    "INNER JOIN membresias m " &
                    "ON p.id_membresia = m.id_membresia " &
                    "INNER JOIN socios s " &
                    "ON m.id_socio = s.id_socio " &
                    "INNER JOIN tipos_membresia tm " &
                    "ON m.id_tipo = tm.id_tipo " &
                    "WHERE DATE(p.fecha_pago) " &
                    "BETWEEN @desde AND @hasta "

                If TextBox3.Text.Trim() <> "" Then
                    sql &=
                        "AND (" &
                        "CONCAT(s.nombres, ' ', s.apellidos) LIKE @buscar " &
                        "OR CAST(p.monto AS CHAR) LIKE @buscar " &
                        "OR p.referencia LIKE @buscar" &
                        ") "
                End If

                If cboEstado.SelectedItem IsNot Nothing Then

                    If cboEstado.SelectedItem.ToString() = "Valido" Then
                        sql &= "AND p.anulado = 0 "
                    ElseIf cboEstado.SelectedItem.ToString() = "Anulado" Then
                        sql &= "AND p.anulado = 1 "
                    End If

                End If

                sql &= "ORDER BY p.fecha_pago DESC"

                Using cmd As New MySqlCommand(sql, cn)

                    cmd.Parameters.AddWithValue(
                        "@desde",
                        DateTimePicker1.Value.Date
                    )

                    cmd.Parameters.AddWithValue(
                        "@hasta",
                        DateTimePicker2.Value.Date
                    )

                    If TextBox3.Text.Trim() <> "" Then
                        cmd.Parameters.AddWithValue(
                            "@buscar",
                            "%" & TextBox3.Text.Trim() & "%"
                        )
                    End If

                    Dim tabla As New DataTable()

                    Using da As New MySqlDataAdapter(cmd)
                        da.Fill(tabla)
                    End Using

                    DGVpAGOS.AutoGenerateColumns = True
                    DGVpAGOS.Columns.Clear()
                    DGVpAGOS.DataSource = tabla
                    DGVpAGOS.AutoSizeColumnsMode =
                        DataGridViewAutoSizeColumnsMode.Fill

                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show(
                "Error al cargar pagos: " &
                ex.Message,
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )
        End Try
    End Sub

    Private Sub AnularPago()
        If DGVpAGOS.CurrentRow Is Nothing Then
            MessageBox.Show(
                "Seleccione un pago.",
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )
            Return
        End If

        Dim idPago As Integer =
            Convert.ToInt32(
                DGVpAGOS.CurrentRow.Cells("ID").Value
            )

        Dim estado As String =
            DGVpAGOS.CurrentRow.Cells("Estado").Value.ToString()

        If estado = "Anulado" Then
            MessageBox.Show(
                "Este pago ya está anulado.",
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )
            Return
        End If

        Dim respuesta As DialogResult =
            MessageBox.Show(
                "¿Está seguro de anular este pago?",
                "GymControl",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            )

        If respuesta <> DialogResult.Yes Then
            Return
        End If

        Try
            Using cn As MySqlConnection =
                ConexionBD.ObtenerConexion()

                cn.Open()

                Dim sql As String =
                    "UPDATE pagos " &
                    "SET anulado = 1 " &
                    "WHERE id_pago = @idPago"

                Using cmd As New MySqlCommand(sql, cn)

                    cmd.Parameters.AddWithValue(
                        "@idPago",
                        idPago
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

            CargarPagos()
            MostrarInformacionMembresia()

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

    Private Sub LimpiarInformacion()
        iblSocio.Text = "Socio: -"
        LimpiarInformacionMembresia()
    End Sub

    Private Sub LimpiarInformacionMembresia()
        iblMembresia.Text = "Membresía: -"
        iblTipoMembresia.Text = "Tipo: -"
        iblFechaInicio.Text = "Fecha inicio: -"
        iblFechaVencimiento.Text = "Fecha vencimiento: -"
        iblPrecioTotal.Text = "Precio total: C$ 0.00"
        Label8.Text = "Monto pagado: C$ 0.00"
        Label9.Text = "Saldo pendiente: C$ 0.00"
        nudMonto.Value = 0
    End Sub

    Private Sub LimpiarFormulario()
        txtBuscarSocio.Clear()
        TextBox1.Clear()
        TextBox2.Clear()
        nudMonto.Value = 0

        If ComboBox1.Items.Count > 0 Then
            ComboBox1.SelectedIndex = 0
        End If

        CargarSocios("")
    End Sub

    Private Sub btnBuscarSocio_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnBuscarSocio.Click

        CargarSocios(
            txtBuscarSocio.Text.Trim()
        )

    End Sub

    Private Sub cboSocio_SelectedIndexChanged(
        sender As Object,
        e As EventArgs
    ) Handles cboSocio.SelectedIndexChanged

        If cboSocio.SelectedIndex = -1 Then
            Return
        End If

        If cboSocio.SelectedValue Is Nothing Then
            Return
        End If

        If TypeOf cboSocio.SelectedValue Is DataRowView Then
            Return
        End If

        Dim idSocio As Integer

        If Integer.TryParse(
            cboSocio.SelectedValue.ToString(),
            idSocio
        ) Then

            CargarMembresias(idSocio)

        End If

    End Sub

    Private Sub cboMembresia_SelectedIndexChanged(
        sender As Object,
        e As EventArgs
    ) Handles cboMembresia.SelectedIndexChanged

        If cboMembresia.SelectedIndex = -1 Then
            Return
        End If

        If cboMembresia.SelectedValue Is Nothing Then
            Return
        End If

        If TypeOf cboMembresia.SelectedValue Is DataRowView Then
            Return
        End If

        MostrarInformacionMembresia()

    End Sub

    Private Sub Button1_Click(
        sender As Object,
        e As EventArgs
    ) Handles Button1.Click

        RegistrarPago()

    End Sub

    Private Sub Button2_Click(
        sender As Object,
        e As EventArgs
    ) Handles Button2.Click

        LimpiarFormulario()

    End Sub

    Private Sub btnBuscarPago_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnBuscarPago.Click

        CargarPagos()

    End Sub

    Private Sub cboEstado_SelectedIndexChanged(
        sender As Object,
        e As EventArgs
    ) Handles cboEstado.SelectedIndexChanged

        If Me.IsHandleCreated Then
            CargarPagos()
        End If

    End Sub

    Private Sub DateTimePicker1_ValueChanged(
        sender As Object,
        e As EventArgs
    ) Handles DateTimePicker1.ValueChanged

        If Me.IsHandleCreated Then
            CargarPagos()
        End If

    End Sub

    Private Sub DateTimePicker2_ValueChanged(
        sender As Object,
        e As EventArgs
    ) Handles DateTimePicker2.ValueChanged

        If Me.IsHandleCreated Then
            CargarPagos()
        End If

    End Sub

    Private Sub btnAnularPago_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnAnularPago.Click

        AnularPago()

    End Sub

    Private Sub btnCerrar_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnCerrar.Click

        Me.Close()

    End Sub

End Class