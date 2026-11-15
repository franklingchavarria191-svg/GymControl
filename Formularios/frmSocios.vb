Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms

Public Class frmSocios

    Private txtCedula As TextBox
    Private txtNombres As TextBox
    Private txtApellidos As TextBox
    Private dtpFechaNacimiento As DateTimePicker
    Private cboGenero As ComboBox
    Private txtTelefono As TextBox
    Private txtCorreo As TextBox
    Private txtDireccion As TextBox
    Private chkActivo As CheckBox

    Private socioSeleccionado As Integer = 0
    Private modoEdicion As Boolean = False
    Private eventosConectados As Boolean = False

    Private Sub frmSocios_Load(
        sender As Object,
        e As EventArgs
    ) Handles MyBase.Load

        Me.WindowState = FormWindowState.Maximized

        CrearCamposSocio()
        PrepararBusqueda()
        PrepararEstado()
        ConectarEventos()
        CargarSocios()

    End Sub

    Private Sub CrearCamposSocio()

        grpDatos.Controls.Clear()
        grpDatos.Text = "Datos del socio"

        Dim lblCedula As New Label()
        lblCedula.Text = "Cédula:"
        lblCedula.Location = New Point(20, 30)
        lblCedula.AutoSize = True

        txtCedula = New TextBox()
        txtCedula.Name = "txtCedula"
        txtCedula.Location = New Point(140, 27)
        txtCedula.Size = New Size(250, 23)

        Dim lblNombres As New Label()
        lblNombres.Text = "Nombres:"
        lblNombres.Location = New Point(20, 70)
        lblNombres.AutoSize = True

        txtNombres = New TextBox()
        txtNombres.Name = "txtNombres"
        txtNombres.Location = New Point(140, 67)
        txtNombres.Size = New Size(250, 23)

        Dim lblApellidos As New Label()
        lblApellidos.Text = "Apellidos:"
        lblApellidos.Location = New Point(20, 110)
        lblApellidos.AutoSize = True

        txtApellidos = New TextBox()
        txtApellidos.Name = "txtApellidos"
        txtApellidos.Location = New Point(140, 107)
        txtApellidos.Size = New Size(250, 23)

        Dim lblFecha As New Label()
        lblFecha.Text = "Fecha nacimiento:"
        lblFecha.Location = New Point(20, 150)
        lblFecha.AutoSize = True

        dtpFechaNacimiento = New DateTimePicker()
        dtpFechaNacimiento.Name = "dtpFechaNacimiento"
        dtpFechaNacimiento.Location = New Point(140, 147)
        dtpFechaNacimiento.Size = New Size(250, 23)
        dtpFechaNacimiento.Format = DateTimePickerFormat.Short

        Dim lblGenero As New Label()
        lblGenero.Text = "Género:"
        lblGenero.Location = New Point(20, 190)
        lblGenero.AutoSize = True

        cboGenero = New ComboBox()
        cboGenero.Name = "cboGenero"
        cboGenero.Location = New Point(140, 187)
        cboGenero.Size = New Size(250, 23)
        cboGenero.DropDownStyle = ComboBoxStyle.DropDownList
        cboGenero.Items.Add("Masculino")
        cboGenero.Items.Add("Femenino")

        Dim lblTelefono As New Label()
        lblTelefono.Text = "Teléfono:"
        lblTelefono.Location = New Point(20, 230)
        lblTelefono.AutoSize = True

        txtTelefono = New TextBox()
        txtTelefono.Name = "txtTelefono"
        txtTelefono.Location = New Point(140, 227)
        txtTelefono.Size = New Size(250, 23)

        Dim lblCorreo As New Label()
        lblCorreo.Text = "Correo:"
        lblCorreo.Location = New Point(20, 270)
        lblCorreo.AutoSize = True

        txtCorreo = New TextBox()
        txtCorreo.Name = "txtCorreo"
        txtCorreo.Location = New Point(140, 267)
        txtCorreo.Size = New Size(250, 23)

        Dim lblDireccion As New Label()
        lblDireccion.Text = "Dirección:"
        lblDireccion.Location = New Point(20, 310)
        lblDireccion.AutoSize = True

        txtDireccion = New TextBox()
        txtDireccion.Name = "txtDireccion"
        txtDireccion.Location = New Point(140, 307)
        txtDireccion.Size = New Size(250, 23)

        chkActivo = New CheckBox()
        chkActivo.Name = "chkActivo"
        chkActivo.Text = "Socio activo"
        chkActivo.Location = New Point(140, 347)
        chkActivo.AutoSize = True
        chkActivo.Checked = True

        grpDatos.Controls.Add(lblCedula)
        grpDatos.Controls.Add(txtCedula)

        grpDatos.Controls.Add(lblNombres)
        grpDatos.Controls.Add(txtNombres)

        grpDatos.Controls.Add(lblApellidos)
        grpDatos.Controls.Add(txtApellidos)

        grpDatos.Controls.Add(lblFecha)
        grpDatos.Controls.Add(dtpFechaNacimiento)

        grpDatos.Controls.Add(lblGenero)
        grpDatos.Controls.Add(cboGenero)

        grpDatos.Controls.Add(lblTelefono)
        grpDatos.Controls.Add(txtTelefono)

        grpDatos.Controls.Add(lblCorreo)
        grpDatos.Controls.Add(txtCorreo)

        grpDatos.Controls.Add(lblDireccion)
        grpDatos.Controls.Add(txtDireccion)

        grpDatos.Controls.Add(chkActivo)

        HabilitarCampos(False)

    End Sub

    Private Sub PrepararBusqueda()

        If cboEstado.Items.Count = 0 Then

            cboEstado.Items.Add("Todos")
            cboEstado.Items.Add("Activos")
            cboEstado.Items.Add("Inactivos")

        End If

        cboEstado.SelectedIndex = 0

    End Sub

    Private Sub PrepararEstado()

        modoEdicion = False
        socioSeleccionado = 0

        HabilitarCampos(False)

    End Sub

    Private Sub ConectarEventos()

        If eventosConectados Then
            Return
        End If

        eventosConectados = True

        Dim botonNuevo As Button =
            BuscarBotonPorTexto(Me, "Nuevo")

        Dim botonEditar As Button =
            BuscarBotonPorTexto(Me, "Editar")

        Dim botonGuardar As Button =
            BuscarBotonPorTexto(Me, "Guardar")

        Dim botonEliminar As Button =
            BuscarBotonPorTexto(Me, "Eliminar")

        Dim botonCancelar As Button =
            BuscarBotonPorTexto(Me, "Cancelar")

        Dim botonBuscar As Button =
            BuscarBotonPorTexto(Me, "Buscar")

        If botonNuevo IsNot Nothing Then
            AddHandler botonNuevo.Click,
                AddressOf btnNuevo_Click
        End If

        If botonEditar IsNot Nothing Then
            AddHandler botonEditar.Click,
                AddressOf btnEditar_Click
        End If

        If botonGuardar IsNot Nothing Then
            AddHandler botonGuardar.Click,
                AddressOf btnGuardar_Click
        End If

        If botonEliminar IsNot Nothing Then
            AddHandler botonEliminar.Click,
                AddressOf btnEliminar_Click
        End If

        If botonCancelar IsNot Nothing Then
            AddHandler botonCancelar.Click,
                AddressOf btnCancelar_Click
        End If

        If botonBuscar IsNot Nothing Then
            AddHandler botonBuscar.Click,
                AddressOf btnBuscar_Click
        End If

        AddHandler DataGridView1.SelectionChanged,
            AddressOf DataGridView1_SelectionChanged

    End Sub

    Private Sub CargarSocios()

        Try

            Dim dao As New SocioDAO()

            Dim tabla As DataTable =
                dao.ObtenerSocios()

            DataGridView1.DataSource = tabla

            ConfigurarGrid()

            socioSeleccionado = 0

        Catch ex As Exception

            MessageBox.Show(
                "Error al cargar los socios: " &
                ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub

    Private Sub ConfigurarGrid()

        If DataGridView1.Columns.Contains("id_socio") Then
            DataGridView1.Columns("id_socio").HeaderText = "ID"
        End If

        If DataGridView1.Columns.Contains("cedula") Then
            DataGridView1.Columns("cedula").HeaderText = "Cédula"
        End If

        If DataGridView1.Columns.Contains("nombres") Then
            DataGridView1.Columns("nombres").HeaderText = "Nombres"
        End If

        If DataGridView1.Columns.Contains("apellidos") Then
            DataGridView1.Columns("apellidos").HeaderText = "Apellidos"
        End If

        If DataGridView1.Columns.Contains("fecha_nacimiento") Then
            DataGridView1.Columns("fecha_nacimiento").HeaderText =
                "Fecha nacimiento"
        End If

        If DataGridView1.Columns.Contains("genero") Then
            DataGridView1.Columns("genero").HeaderText = "Género"
        End If

        If DataGridView1.Columns.Contains("telefono") Then
            DataGridView1.Columns("telefono").HeaderText = "Teléfono"
        End If

        If DataGridView1.Columns.Contains("correo") Then
            DataGridView1.Columns("correo").HeaderText = "Correo"
        End If

        If DataGridView1.Columns.Contains("direccion") Then
            DataGridView1.Columns("direccion").HeaderText = "Dirección"
        End If

        If DataGridView1.Columns.Contains("fecha_registro") Then
            DataGridView1.Columns("fecha_registro").HeaderText =
                "Fecha registro"
        End If

        If DataGridView1.Columns.Contains("activo") Then
            DataGridView1.Columns("activo").HeaderText = "Activo"
        End If

        DataGridView1.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.AllCells

    End Sub

    Private Sub btnNuevo_Click(
        sender As Object,
        e As EventArgs
    )

        LimpiarCampos()

        socioSeleccionado = 0
        modoEdicion = True

        HabilitarCampos(True)

        txtCedula.Focus()

    End Sub

    Private Sub btnEditar_Click(
        sender As Object,
        e As EventArgs
    )

        If DataGridView1.CurrentRow Is Nothing Then

            MessageBox.Show(
                "Seleccione un socio primero.",
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )

            Return

        End If

        If DataGridView1.CurrentRow.IsNewRow Then

            MessageBox.Show(
                "Seleccione un socio primero.",
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )

            Return

        End If

        If Not DataGridView1.Columns.Contains("id_socio") Then

            MessageBox.Show(
                "No se encontró el ID del socio.",
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

            Return

        End If

        Dim valorId =
            DataGridView1.CurrentRow.Cells("id_socio").Value

        If valorId Is Nothing OrElse IsDBNull(valorId) Then

            MessageBox.Show(
                "No se pudo obtener el ID del socio seleccionado.",
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            Return

        End If

        socioSeleccionado = Convert.ToInt32(valorId)

        modoEdicion = True

        HabilitarCampos(True)

        txtCedula.Focus()

    End Sub

    Private Sub btnGuardar_Click(
        sender As Object,
        e As EventArgs
    )

        If Not modoEdicion Then

            MessageBox.Show(
                "Presione Nuevo o Editar antes de guardar.",
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )

            Return

        End If

        If txtCedula.Text.Trim() = "" Then

            MessageBox.Show(
                "Ingrese la cédula.",
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            txtCedula.Focus()

            Return

        End If

        If txtNombres.Text.Trim() = "" Then

            MessageBox.Show(
                "Ingrese los nombres.",
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            txtNombres.Focus()

            Return

        End If

        If txtApellidos.Text.Trim() = "" Then

            MessageBox.Show(
                "Ingrese los apellidos.",
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            txtApellidos.Focus()

            Return

        End If

        Dim generoBD As String =
            ObtenerGeneroBD(cboGenero.Text)

        Try

            Dim dao As New SocioDAO()

            If socioSeleccionado = 0 Then

                dao.InsertarSocio(
                    txtCedula.Text.Trim(),
                    txtNombres.Text.Trim(),
                    txtApellidos.Text.Trim(),
                    dtpFechaNacimiento.Value.Date,
                    generoBD,
                    txtTelefono.Text.Trim(),
                    txtCorreo.Text.Trim(),
                    txtDireccion.Text.Trim(),
                    chkActivo.Checked
                )

                MessageBox.Show(
                    "Socio guardado correctamente.",
                    "GymControl",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                )

            Else

                dao.ActualizarSocio(
                    socioSeleccionado,
                    txtCedula.Text.Trim(),
                    txtNombres.Text.Trim(),
                    txtApellidos.Text.Trim(),
                    dtpFechaNacimiento.Value.Date,
                    generoBD,
                    txtTelefono.Text.Trim(),
                    txtCorreo.Text.Trim(),
                    txtDireccion.Text.Trim(),
                    chkActivo.Checked
                )

                MessageBox.Show(
                    "Socio actualizado correctamente.",
                    "GymControl",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                )

            End If

            modoEdicion = False
            socioSeleccionado = 0

            HabilitarCampos(False)
            LimpiarCampos()
            CargarSocios()

        Catch ex As Exception

            MessageBox.Show(
                "Error al guardar el socio: " &
                ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub

    Private Sub btnEliminar_Click(
        sender As Object,
        e As EventArgs
    )

        If DataGridView1.CurrentRow Is Nothing Then

            MessageBox.Show(
                "Seleccione un socio primero.",
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )

            Return

        End If

        If DataGridView1.CurrentRow.IsNewRow Then

            MessageBox.Show(
                "Seleccione un socio primero.",
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )

            Return

        End If

        If DataGridView1.Columns.Contains("id_socio") Then

            Dim valorId =
                DataGridView1.CurrentRow.Cells("id_socio").Value

            If valorId IsNot Nothing AndAlso
               Not IsDBNull(valorId) Then

                socioSeleccionado =
                    Convert.ToInt32(valorId)

            End If

        End If

        If socioSeleccionado = 0 Then

            MessageBox.Show(
                "No se pudo identificar el socio seleccionado.",
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            Return

        End If

        Dim respuesta As DialogResult =
            MessageBox.Show(
                "¿Está seguro de eliminar este socio?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            )

        If respuesta <> DialogResult.Yes Then
            Return
        End If

        Try

            Dim dao As New SocioDAO()

            dao.EliminarSocio(socioSeleccionado)

            MessageBox.Show(
                "Socio eliminado correctamente.",
                "GymControl",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )

            socioSeleccionado = 0

            LimpiarCampos()
            HabilitarCampos(False)
            CargarSocios()

        Catch ex As Exception

            MessageBox.Show(
                "Error al eliminar el socio: " &
                ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub

    Private Sub btnCancelar_Click(
        sender As Object,
        e As EventArgs
    )

        modoEdicion = False
        socioSeleccionado = 0

        LimpiarCampos()
        HabilitarCampos(False)

        DataGridView1.ClearSelection()

    End Sub

    Private Sub btnBuscar_Click(
        sender As Object,
        e As EventArgs
    )

        BuscarSocios()

    End Sub

    Private Sub BuscarSocios()

        Try

            Dim texto As String =
                txtBuscar.Text.Trim()

            Dim estado As String = "Todos"

            If cboEstado.SelectedItem IsNot Nothing Then
                estado = cboEstado.SelectedItem.ToString()
            End If

            Dim dao As New SocioDAO()

            Dim tabla As DataTable = dao.BuscarSocios(texto)

            DataGridView1.DataSource = tabla

            ConfigurarGrid()

            socioSeleccionado = 0

            LimpiarCampos()
            HabilitarCampos(False)

        Catch ex As Exception

            MessageBox.Show(
                "Error al buscar socios: " &
                ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub

    Private Sub DataGridView1_SelectionChanged(
        sender As Object,
        e As EventArgs
    )

        If modoEdicion Then
            Return
        End If

        If DataGridView1.CurrentRow Is Nothing Then
            Return
        End If

        If DataGridView1.CurrentRow.IsNewRow Then
            Return
        End If

        Try

            Dim fila As DataGridViewRow =
                DataGridView1.CurrentRow

            If Not DataGridView1.Columns.Contains("id_socio") Then
                Return
            End If

            Dim valorId =
                fila.Cells("id_socio").Value

            If valorId Is Nothing OrElse IsDBNull(valorId) Then
                Return
            End If

            socioSeleccionado =
                Convert.ToInt32(valorId)

            txtCedula.Text =
                ValorCelda(fila, "cedula")

            txtNombres.Text =
                ValorCelda(fila, "nombres")

            txtApellidos.Text =
                ValorCelda(fila, "apellidos")

            txtTelefono.Text =
                ValorCelda(fila, "telefono")

            txtCorreo.Text =
                ValorCelda(fila, "correo")

            txtDireccion.Text =
                ValorCelda(fila, "direccion")

            cboGenero.Text =
                ObtenerGeneroPantalla(
                    ValorCelda(fila, "genero")
                )

            If DataGridView1.Columns.Contains("fecha_nacimiento") Then

                Dim valorFecha =
                    fila.Cells("fecha_nacimiento").Value

                If valorFecha IsNot Nothing AndAlso
                   Not IsDBNull(valorFecha) Then

                    Dim fecha As Date

                    If Date.TryParse(
                        valorFecha.ToString(),
                        fecha
                    ) Then

                        dtpFechaNacimiento.Value = fecha

                    End If

                End If

            End If

            If DataGridView1.Columns.Contains("activo") Then

                Dim valorActivo =
                    fila.Cells("activo").Value

                If valorActivo IsNot Nothing AndAlso
                   Not IsDBNull(valorActivo) Then

                    chkActivo.Checked =
                        Convert.ToBoolean(valorActivo)

                End If

            End If

        Catch

        End Try

    End Sub

    Private Function ObtenerGeneroBD(
        genero As String
    ) As String

        If genero = "Masculino" Then
            Return "M"
        End If

        If genero = "Femenino" Then
            Return "F"
        End If

        Return ""

    End Function

    Private Function ObtenerGeneroPantalla(
        genero As String
    ) As String

        If genero.Trim().ToUpper() = "M" Then
            Return "Masculino"
        End If

        If genero.Trim().ToUpper() = "F" Then
            Return "Femenino"
        End If

        Return ""

    End Function

    Private Sub LimpiarCampos()

        txtCedula.Clear()
        txtNombres.Clear()
        txtApellidos.Clear()
        txtTelefono.Clear()
        txtCorreo.Clear()
        txtDireccion.Clear()

        dtpFechaNacimiento.Value = Date.Today

        cboGenero.SelectedIndex = -1

        chkActivo.Checked = True

    End Sub

    Private Sub HabilitarCampos(
        habilitar As Boolean
    )

        If txtCedula IsNot Nothing Then
            txtCedula.Enabled = habilitar
        End If

        If txtNombres IsNot Nothing Then
            txtNombres.Enabled = habilitar
        End If

        If txtApellidos IsNot Nothing Then
            txtApellidos.Enabled = habilitar
        End If

        If dtpFechaNacimiento IsNot Nothing Then
            dtpFechaNacimiento.Enabled = habilitar
        End If

        If cboGenero IsNot Nothing Then
            cboGenero.Enabled = habilitar
        End If

        If txtTelefono IsNot Nothing Then
            txtTelefono.Enabled = habilitar
        End If

        If txtCorreo IsNot Nothing Then
            txtCorreo.Enabled = habilitar
        End If

        If txtDireccion IsNot Nothing Then
            txtDireccion.Enabled = habilitar
        End If

        If chkActivo IsNot Nothing Then
            chkActivo.Enabled = habilitar
        End If

    End Sub

    Private Function ValorCelda(
        fila As DataGridViewRow,
        columna As String
    ) As String

        If Not DataGridView1.Columns.Contains(columna) Then
            Return ""
        End If

        Dim valor =
            fila.Cells(columna).Value

        If valor Is Nothing OrElse IsDBNull(valor) Then
            Return ""
        End If

        Return valor.ToString()

    End Function

    Private Function BuscarBotonPorTexto(
        contenedor As Control,
        texto As String
    ) As Button

        For Each control As Control In contenedor.Controls

            Dim boton As Button =
                TryCast(control, Button)

            If boton IsNot Nothing Then

                If String.Equals(
                    boton.Text.Trim(),
                    texto,
                    StringComparison.OrdinalIgnoreCase
                ) Then

                    Return boton

                End If

            End If

            If control.HasChildren Then

                Dim encontrado As Button =
                    BuscarBotonPorTexto(
                        control,
                        texto
                    )

                If encontrado IsNot Nothing Then
                    Return encontrado
                End If

            End If

        Next

        Return Nothing

    End Function

    Private Sub grpDatos_Enter(sender As Object, e As EventArgs) Handles grpDatos.Enter

    End Sub
End Class