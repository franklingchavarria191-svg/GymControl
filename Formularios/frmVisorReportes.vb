
Imports System.ComponentModel
Imports System.Data
Imports System.IO
Imports System.Drawing
Imports Microsoft.Reporting.WinForms

Public Class frmVisorReportes

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property CodigoReporte As String = "R04"

    Private visor As ReportViewer
    Private dtpDesde As DateTimePicker
    Private dtpHasta As DateTimePicker
    Private lblHasta As Label

    Private Function ObtenerRutaReporte() As String

        Dim archivo As String

        Select Case CodigoReporte
            Case "R04"
                archivo = "R04_IngresosPeriodo.rdlc"

            Case "R05"
                archivo = "R05_EstadoCuenta.rdlc"

            Case "R06"
                archivo = "R06_HorarioSemanal.rdlc"

            Case Else
                Throw New Exception("El código del reporte no es válido.")
        End Select

        Return Path.Combine(Application.StartupPath, "Reportes", archivo)

    End Function

    Private Sub frmVisorReportes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            ConfigurarVentana()
            ConfigurarParametros()
            ConfigurarVisor()

        Catch ex As Exception
            MessageBox.Show(
                "No se pudo iniciar el visor: " & ex.Message,
                "Centro de Reportes",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub ConfigurarVentana()

        Me.WindowState = FormWindowState.Maximized
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.BackColor = Color.White

        Select Case CodigoReporte
            Case "R04"
                Me.Text = "GymControl - Ingresos por período"

            Case "R05"
                Me.Text = "GymControl - Estado de cuenta"

            Case "R06"
                Me.Text = "GymControl - Horario semanal"
        End Select

        pnlParametros.Height = 85
        pnlParametros.BackColor = Color.FromArgb(240, 244, 249)

        btnGenerar.Text = "Generar reporte"
        btnGenerar.Size = New Size(150, 38)
        btnGenerar.BackColor = Color.FromArgb(25, 85, 160)
        btnGenerar.ForeColor = Color.White
        btnGenerar.FlatStyle = FlatStyle.Flat
        btnGenerar.FlatAppearance.BorderSize = 0

        lblCargando.Visible = False

    End Sub

    Private Sub ConfigurarParametros()

        lblSocio.Visible = False
        txtSocio.Visible = False
        lblDesde.Visible = False
        txtFecha.Visible = False

        dtpDesde = New DateTimePicker()
        dtpDesde.Name = "dtpDesde"
        dtpDesde.Format = DateTimePickerFormat.Short
        dtpDesde.Value = New Date(Date.Today.Year, Date.Today.Month, 1)
        dtpDesde.Size = New Size(135, 28)

        dtpHasta = New DateTimePicker()
        dtpHasta.Name = "dtpHasta"
        dtpHasta.Format = DateTimePickerFormat.Short
        dtpHasta.Value = Date.Today
        dtpHasta.Size = New Size(135, 28)

        lblHasta = New Label()
        lblHasta.Name = "lblHasta"
        lblHasta.Text = "Hasta:"
        lblHasta.AutoSize = True
        lblHasta.Font = New Font("Segoe UI", 10, FontStyle.Bold)

        pnlParametros.Controls.Add(dtpDesde)
        pnlParametros.Controls.Add(dtpHasta)
        pnlParametros.Controls.Add(lblHasta)

        Select Case CodigoReporte

            Case "R04"

                lblDesde.Visible = True
                lblDesde.Text = "Desde:"
                lblDesde.Location = New Point(20, 31)

                dtpDesde.Visible = True
                dtpDesde.Location = New Point(95, 27)

                lblHasta.Visible = True
                lblHasta.Location = New Point(255, 31)

                dtpHasta.Visible = True
                dtpHasta.Location = New Point(315, 27)

                btnGenerar.Location = New Point(480, 23)

            Case "R05"

                lblSocio.Visible = True
                lblSocio.Text = "ID del socio:"
                lblSocio.Location = New Point(20, 30)

                txtSocio.Visible = True
                txtSocio.Location = New Point(145, 28)
                txtSocio.Width = 140

                dtpDesde.Visible = False
                dtpHasta.Visible = False
                lblHasta.Visible = False

                btnGenerar.Location = New Point(315, 23)

            Case "R06"

                dtpDesde.Visible = False
                dtpHasta.Visible = False
                lblHasta.Visible = False

                btnGenerar.Location = New Point(25, 23)

        End Select

    End Sub

    Private Sub ConfigurarVisor()

        Dim ruta As String = ObtenerRutaReporte()

        If Not File.Exists(ruta) Then
            Throw New FileNotFoundException(
                "No se encontró el archivo del reporte: " & ruta)
        End If

        visor = New ReportViewer()

        visor.Name = "visorReportes"
        visor.Dock = DockStyle.Fill
        visor.ProcessingMode = ProcessingMode.Local
        visor.ShowPrintButton = True
        visor.ShowExportButton = True
        visor.ShowRefreshButton = True
        visor.LocalReport.ReportPath = ruta
        visor.LocalReport.DataSources.Clear()

        Dim contenedor As New Panel()

        contenedor.Name = "contenedorVisor"
        contenedor.Dock = DockStyle.Fill
        contenedor.Padding = New Padding(8)
        contenedor.BackColor = Color.White

        Me.Controls.Add(contenedor)
        contenedor.Controls.Add(visor)

        contenedor.BringToFront()
        pnlParametros.BringToFront()

    End Sub

    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click

        If visor Is Nothing Then
            MessageBox.Show(
                "El visor no está disponible.",
                "Aviso",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)
            Return
        End If

        Try
            btnGenerar.Enabled = False
            lblCargando.Text = "Generando..."
            lblCargando.Visible = True
            lblCargando.Refresh()

            Dim datos As DataTable = Nothing
            Dim nombreOrigen As String = ""

            Select Case CodigoReporte

                Case "R04"

                    Dim desde As Date = dtpDesde.Value.Date
                    Dim hasta As Date = dtpHasta.Value.Date

                    If desde > hasta Then
                        MessageBox.Show(
                            "La fecha inicial no puede ser posterior a la fecha final.",
                            "Fechas incorrectas",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning)
                        Return
                    End If

                    datos = ReportesDAO.IngresosPeriodo(desde, hasta)
                    nombreOrigen = "dsIngresosPeriodo"

                Case "R05"

                    Dim idSocio As Integer

                    If Not Integer.TryParse(txtSocio.Text.Trim(), idSocio) OrElse idSocio <= 0 Then
                        MessageBox.Show(
                            "Ingrese un ID de socio válido.",
                            "Dato incorrecto",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning)

                        txtSocio.Focus()
                        Return
                    End If

                    datos = ReportesDAO.EstadoCuenta(idSocio)
                    nombreOrigen = "dsEstadoCuenta"

                Case "R06"

                    datos = ReportesDAO.HorarioSemanal()
                    nombreOrigen = "dsHorarioSemanal"

                Case Else

                    MessageBox.Show("Reporte no reconocido.")
                    Return

            End Select

            If datos Is Nothing OrElse datos.Rows.Count = 0 Then

                visor.LocalReport.DataSources.Clear()
                visor.Clear()

                MessageBox.Show(
                    "No se encontraron datos para los parámetros seleccionados.",
                    "Sin resultados",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information)

                Return

            End If

            visor.Reset()
            visor.ProcessingMode = ProcessingMode.Local
            visor.LocalReport.ReportPath = ObtenerRutaReporte()
            visor.LocalReport.DataSources.Clear()

            visor.LocalReport.DataSources.Add(
                New ReportDataSource(nombreOrigen, datos))

            visor.RefreshReport()

        Catch ex As Exception

            MessageBox.Show(
                "Error al generar el reporte:" & Environment.NewLine & ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)

        Finally

            lblCargando.Visible = False
            btnGenerar.Enabled = True

        End Try

    End Sub

End Class
