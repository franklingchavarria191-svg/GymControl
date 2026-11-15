
Imports System.Data
Imports System.Drawing
Imports System.Drawing.Printing
Imports MySqlConnector
Imports QuestPDF.Fluent

Public Class frmCentroReportes

    Private reporteSeleccionado As String = ""
    Private datosRecibo As DataTable
    Private datosConstancia As DataTable

    Private WithEvents documentoRecibo As New PrintDocument()
    Private WithEvents documentoConstancia As New PrintDocument()

    Private cboRegistro As ComboBox
    Private dtpDesde As DateTimePicker
    Private dtpHasta As DateTimePicker
    Private cboMetodo As ComboBox
    Private nudAnio As NumericUpDown

    Private ReadOnly nombres As New Dictionary(Of String, String) From {
        {"R01", "Recibo de pago"},
        {"R02", "Constancia de membresía"},
        {"R03", "Listado de vencimientos"},
        {"R04", "Ingresos por período"},
        {"R05", "Estado de cuenta del socio"},
        {"R06", "Horario semanal"},
        {"R07", "Cartera de saldos pendientes"},
        {"R08", "Informe gerencial"},
        {"R09", "Libro anual de ingresos"}
    }

    Private Sub frmCentroReportes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If SesionActual.IdRol <> 1 Then
            MessageBox.Show("Solo el administrador puede acceder a los reportes.",
                            "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            BeginInvoke(New MethodInvoker(Sub() Me.Close()))
            Return
        End If

        tslUsuario.Text = SesionActual.NombreUsuario
        PrepararControles()
        CargarArbol()

        btnVistaPrevia.Enabled = False
        btnImprimir.Enabled = False
        btnExportarPdf.Enabled = False
        btnExportarExcel.Enabled = False

        documentoRecibo.DocumentName = "GymControl - Recibo de pago"
        documentoConstancia.DocumentName = "GymControl - Constancia"
    End Sub

    Private Sub PrepararControles()
        pnlParamFechas.Controls.Clear()
        pnlParamSocio.Controls.Clear()
        pnlParamDias.Controls.Clear()
        pnlParamInstructor.Controls.Clear()

        Dim lblDesde As New Label With {
            .Text = "Desde:",
            .Location = New Point(15, 20),
            .AutoSize = True
        }

        dtpDesde = New DateTimePicker With {
            .Name = "dtpDesde",
            .Format = DateTimePickerFormat.Short,
            .Location = New Point(105, 15),
            .Width = 170,
            .Value = New Date(Date.Today.Year, Date.Today.Month, 1)
        }

        Dim lblHasta As New Label With {
            .Text = "Hasta:",
            .Location = New Point(15, 70),
            .AutoSize = True
        }

        dtpHasta = New DateTimePicker With {
            .Name = "dtpHasta",
            .Format = DateTimePickerFormat.Short,
            .Location = New Point(105, 65),
            .Width = 170,
            .Value = Date.Today
        }

        Dim lblMetodo As New Label With {
            .Text = "Método:",
            .Location = New Point(15, 120),
            .AutoSize = True
        }

        cboMetodo = New ComboBox With {
            .Name = "cboMetodo",
            .Location = New Point(105, 115),
            .Width = 220,
            .DropDownStyle = ComboBoxStyle.DropDownList
        }

        cboMetodo.Items.Add("Todos")
        cboMetodo.SelectedIndex = 0

        pnlParamFechas.Controls.AddRange(New Control() {
            lblDesde, dtpDesde, lblHasta, dtpHasta, lblMetodo, cboMetodo
        })

        Dim lblSeleccion As New Label With {
            .Name = "lblSeleccion",
            .Text = "Seleccione un registro:",
            .Location = New Point(15, 20),
            .AutoSize = True
        }

        cboRegistro = New ComboBox With {
            .Name = "cboRegistro",
            .Location = New Point(15, 55),
            .Width = 625,
            .DropDownStyle = ComboBoxStyle.DropDownList
        }

        pnlParamSocio.Controls.Add(lblSeleccion)
        pnlParamSocio.Controls.Add(cboRegistro)

        Dim lblDias As New Label With {
            .Text = "Este reporte permite consultar vencimientos y aplicar filtros.",
            .Location = New Point(15, 20),
            .Size = New Size(630, 50)
        }

        pnlParamDias.Controls.Add(lblDias)

        Dim lblInfo As New Label With {
            .Text = "Este reporte no requiere parámetros adicionales.",
            .Location = New Point(15, 20),
            .Size = New Size(630, 50)
        }

        pnlParamInstructor.Controls.Add(lblInfo)

        Dim lblAnio As New Label With {
            .Name = "lblAnio",
            .Text = "Año del libro de ingresos:",
            .Location = New Point(15, 80),
            .AutoSize = True
        }

        nudAnio = New NumericUpDown With {
            .Name = "nudAnio",
            .Minimum = 2000,
            .Maximum = 9998,
            .Value = Date.Today.Year,
            .Location = New Point(230, 75),
            .Width = 110
        }

        pnlParamInstructor.Controls.Add(lblAnio)
        pnlParamInstructor.Controls.Add(nudAnio)
        lblAnio.Visible = False
        nudAnio.Visible = False
    End Sub

    Private Sub CargarArbol()
        tvReportes.Nodes.Clear()

        Dim impresion As New TreeNode("Impresión directa")
        Dim visor As New TreeNode("Reportes en visor")
        Dim archivos As New TreeNode("Archivos y exportaciones")

        AgregarNodo(impresion, "R01")
        AgregarNodo(impresion, "R02")
        AgregarNodo(impresion, "R03")

        AgregarNodo(visor, "R04")
        AgregarNodo(visor, "R05")
        AgregarNodo(visor, "R06")

        AgregarNodo(archivos, "R07")
        AgregarNodo(archivos, "R08")
        AgregarNodo(archivos, "R09")

        tvReportes.Nodes.Add(impresion)
        tvReportes.Nodes.Add(visor)
        tvReportes.Nodes.Add(archivos)

        tvReportes.ExpandAll()
    End Sub

    Private Sub AgregarNodo(padre As TreeNode, codigo As String)
        Dim nodo As New TreeNode(codigo & " - " & nombres(codigo))
        nodo.Name = codigo
        nodo.Tag = codigo
        padre.Nodes.Add(nodo)
    End Sub

    Private Sub tvReportes_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles tvReportes.AfterSelect
        If e.Node Is Nothing OrElse e.Node.Tag Is Nothing Then Return

        reporteSeleccionado = e.Node.Tag.ToString()
        lblNombreReporte.Text = reporteSeleccionado & " - " & nombres(reporteSeleccionado)
        lblDescripcion.Text = ObtenerDescripcion(reporteSeleccionado)

        pnlParamFechas.Visible = False
        pnlParamSocio.Visible = False
        pnlParamDias.Visible = False
        pnlParamInstructor.Visible = False
        pnlParamInstructor.Controls("lblAnio").Visible = False
        nudAnio.Visible = False

        btnVistaPrevia.Enabled = False
        btnImprimir.Enabled = False
        btnExportarPdf.Enabled = False
        btnExportarExcel.Enabled = False

        Select Case reporteSeleccionado
            Case "R01", "R02"
                pnlParamSocio.Visible = True
                CargarRegistros()
                btnVistaPrevia.Enabled = True
                btnImprimir.Enabled = True

            Case "R03"
                pnlParamDias.Visible = True
                btnVistaPrevia.Enabled = True

            Case "R04", "R05", "R06"
                If reporteSeleccionado = "R04" Then
                    pnlParamFechas.Visible = True
                Else
                    pnlParamInstructor.Visible = True
                End If
                btnVistaPrevia.Enabled = True

            Case "R07"
                pnlParamInstructor.Visible = True
                btnExportarExcel.Enabled = True

            Case "R08"
                pnlParamFechas.Visible = True
                btnExportarPdf.Enabled = True

            Case "R09"
                pnlParamInstructor.Visible = True
                pnlParamInstructor.Controls("lblAnio").Visible = True
                nudAnio.Visible = True
                btnExportarExcel.Enabled = True
        End Select

        tslEstado.Text = "Reporte seleccionado: " & reporteSeleccionado
    End Sub

    Private Function ObtenerDescripcion(codigo As String) As String
        Select Case codigo
            Case "R01"
                Return "Seleccione un pago registrado para generar su recibo."
            Case "R02"
                Return "Seleccione una membresía para generar la constancia."
            Case "R03"
                Return "Consulte las membresías vencidas o próximas a vencer."
            Case "R04"
                Return "Consulte los ingresos registrados durante un período."
            Case "R05"
                Return "Consulte el estado de cuenta de un socio."
            Case "R06"
                Return "Consulte el horario semanal de actividades."
            Case "R07"
                Return "Exporte a Excel los saldos pendientes."
            Case "R08"
                Return "Genere un informe gerencial en formato PDF."
            Case "R09"
                Return "Exporte el libro anual de ingresos a Excel."
        End Select
        Return ""
    End Function

    Private Sub CargarRegistros()
        cboRegistro.DataSource = Nothing

        Try
            Dim sql As String

            If reporteSeleccionado = "R01" Then
                sql = "SELECT id_pago AS id, " &
                      "CONCAT('Pago #', id_pago, ' - ', socio, " &
                      "' - C$ ', monto, ' - ', " &
                      "DATE_FORMAT(fecha_pago, '%d/%m/%Y')) AS descripcion " &
                      "FROM vw_ingresos_detalle " &
                      "WHERE anulado = 0 " &
                      "ORDER BY fecha_pago DESC, id_pago DESC"
            Else
                sql = "SELECT id_membresia AS id, " &
                      "CONCAT('Membresía #', id_membresia, " &
                      "' - ', socio, ' - ', plan) AS descripcion " &
                      "FROM vw_saldos_membresia " &
                      "ORDER BY id_membresia DESC"
            End If

            Dim tabla As New DataTable()

            Using cn As MySqlConnection = ConexionBD.ObtenerConexionReportes()
                cn.Open()
                Using cmd As New MySqlCommand(sql, cn)
                    Using lector = cmd.ExecuteReader()
                        tabla.Load(lector)
                    End Using
                End Using
            End Using

            cboRegistro.DisplayMember = "descripcion"
            cboRegistro.ValueMember = "id"
            cboRegistro.DataSource = tabla

            If tabla.Rows.Count = 0 Then
                tslEstado.Text = "No hay registros disponibles"
            End If

        Catch ex As Exception
            MessageBox.Show("Error al cargar registros: " & ex.Message,
                            "GymControl", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function ObtenerIdSeleccionado() As Integer
        If cboRegistro.SelectedValue Is Nothing OrElse
           TypeOf cboRegistro.SelectedValue Is DataRowView Then
            Return 0
        End If

        Return Convert.ToInt32(cboRegistro.SelectedValue)
    End Function

    Private Function PrepararDocumento() As PrintDocument
        Dim id As Integer = ObtenerIdSeleccionado()

        If id <= 0 Then
            MessageBox.Show("Seleccione un registro válido.")
            Return Nothing
        End If

        If reporteSeleccionado = "R01" Then
            datosRecibo = ReportesDAO.ReciboPago(id)

            If datosRecibo.Rows.Count = 0 Then
                MessageBox.Show("No se encontró el pago seleccionado.")
                Return Nothing
            End If

            Return documentoRecibo

        ElseIf reporteSeleccionado = "R02" Then
            datosConstancia = ReportesDAO.ConstanciaMembresia(id)

            If datosConstancia.Rows.Count = 0 Then
                MessageBox.Show("No se encontró la membresía seleccionada.")
                Return Nothing
            End If

            Return documentoConstancia
        End If

        Return Nothing
    End Function

    Private Sub btnVistaPrevia_Click(sender As Object, e As EventArgs) Handles btnVistaPrevia.Click
        Try
            Select Case reporteSeleccionado
                Case "R01", "R02"
                    Dim documento As PrintDocument = PrepararDocumento()
                    If documento Is Nothing Then Return

                    Using vista As New PrintPreviewDialog()
                        vista.Document = documento
                        vista.WindowState = FormWindowState.Maximized
                        vista.ShowDialog(Me)
                    End Using

                Case "R03"
                    Using ventana As New frmListadoVencimientos()
                        ventana.ShowDialog(Me)
                    End Using

                Case "R04", "R05", "R06"
                    Using ventana As New frmVisorReportes()
                        ventana.CodigoReporte = reporteSeleccionado
                        ventana.ShowDialog(Me)
                    End Using
            End Select

        Catch ex As Exception
            MessageBox.Show("Error al abrir la vista previa: " & ex.Message,
                            "GymControl", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Try
            Dim documento As PrintDocument = PrepararDocumento()
            If documento Is Nothing Then Return

            Using dialogo As New PrintDialog()
                dialogo.Document = documento
                dialogo.UseEXDialog = True

                If dialogo.ShowDialog(Me) = DialogResult.OK Then
                    documento.Print()
                End If
            End Using

        Catch ex As Exception
            MessageBox.Show("Error al imprimir: " & ex.Message,
                            "GymControl", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub documentoRecibo_PrintPage(sender As Object, e As PrintPageEventArgs) Handles documentoRecibo.PrintPage
        If datosRecibo Is Nothing OrElse datosRecibo.Rows.Count = 0 Then
            e.HasMorePages = False
            Return
        End If

        Dim pago As DataRow = datosRecibo.Rows(0)

        Using titulo As New Font("Segoe UI", 17, FontStyle.Bold),
              texto As New Font("Segoe UI", 11)

            Dim x As Single = e.MarginBounds.Left
            Dim y As Single = e.MarginBounds.Top

            e.Graphics.DrawString("GYMCONTROL", titulo, Brushes.Black, x, y)
            y += 55
            e.Graphics.DrawString("RECIBO DE PAGO", titulo, Brushes.Black, x, y)
            y += 70

            Dim campos As String() = {
                "N.º de pago: " & pago("id_pago").ToString(),
                "Socio: " & pago("socio").ToString(),
                "Cédula: " & pago("cedula").ToString(),
                "Membresía: " & pago("id_membresia").ToString(),
                "Fecha: " & Convert.ToDateTime(pago("fecha_pago")).ToString("dd/MM/yyyy"),
                "Monto: C$ " & Convert.ToDecimal(pago("monto")).ToString("N2"),
                "Método: " & pago("metodo_pago").ToString(),
                "Referencia: " & pago("referencia").ToString(),
                "Observación: " & pago("observacion").ToString()
            }

            For Each campo As String In campos
                e.Graphics.DrawString(campo, texto, Brushes.Black,
                                      New RectangleF(x, y, e.MarginBounds.Width, 45))
                y += 45
            Next
        End Using

        e.HasMorePages = False
    End Sub

    Private Sub documentoConstancia_PrintPage(sender As Object, e As PrintPageEventArgs) Handles documentoConstancia.PrintPage
        If datosConstancia Is Nothing OrElse datosConstancia.Rows.Count = 0 Then
            e.HasMorePages = False
            Return
        End If

        Dim fila As DataRow = datosConstancia.Rows(0)

        Using titulo As New Font("Segoe UI", 18, FontStyle.Bold),
              texto As New Font("Segoe UI", 11),
              subtitulo As New Font("Segoe UI", 14, FontStyle.Bold)

            Dim area As Rectangle = e.MarginBounds
            Dim y As Single = area.Top

            Using centrado As New StringFormat With {
                .Alignment = StringAlignment.Center
            }

                e.Graphics.DrawString("GYMCONTROL", titulo, Brushes.Black,
                                      New RectangleF(area.Left, y, area.Width, 40), centrado)
                y += 70

                e.Graphics.DrawString("CONSTANCIA DE MEMBRESÍA", subtitulo, Brushes.Black,
                                      New RectangleF(area.Left, y, area.Width, 40), centrado)
                y += 85

                Dim parrafo As String =
                    "Por medio de la presente se hace constar que " &
                    fila("socio").ToString() &
                    ", con cédula " & fila("cedula").ToString() &
                    ", posee una membresía registrada en GymControl."

                e.Graphics.DrawString(parrafo, texto, Brushes.Black,
                                      New RectangleF(area.Left, y, area.Width, 110))
                y += 135

                Dim detalles As String() = {
                    "N.º de membresía: " & fila("id_membresia").ToString(),
                    "Tipo: " & fila("tipo_membresia").ToString(),
                    "Inicio: " & Convert.ToDateTime(fila("fecha_inicio")).ToString("dd/MM/yyyy"),
                    "Vencimiento: " & Convert.ToDateTime(fila("fecha_vencimiento")).ToString("dd/MM/yyyy"),
                    "Estado: " & fila("estado").ToString(),
                    "Vigencia: " & fila("vigencia").ToString()
                }

                For Each detalle As String In detalles
                    e.Graphics.DrawString(detalle, texto, Brushes.Black, area.Left, y)
                    y += 37
                Next

                y += 45
                e.Graphics.DrawString("Emitida el " & Date.Today.ToString("dd/MM/yyyy"),
                                      texto, Brushes.Black, area.Left, y)
                y += 90

                e.Graphics.DrawLine(Pens.Black, area.Left + 150, y, area.Right - 150, y)
                y += 12

                e.Graphics.DrawString("Firma autorizada", texto, Brushes.Black,
                                      New RectangleF(area.Left, y, area.Width, 35), centrado)
            End Using
        End Using

        e.HasMorePages = False
    End Sub

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        Select Case reporteSeleccionado
            Case "R07"
                ExportarSaldosPendientesExcel()
            Case "R09"
                ExportarLibroIngresosExcel()
        End Select
    End Sub

    Private Sub ExportarSaldosPendientesExcel()
        Try
            Dim datos As DataTable = ReportesDAO.SaldosPendientes()

            If datos.Rows.Count = 0 Then
                MessageBox.Show("No hay saldos pendientes.")
                Return
            End If

            Using guardar As New SaveFileDialog()
                guardar.Title = "Guardar saldos pendientes"
                guardar.Filter = "Excel (*.xlsx)|*.xlsx"
                guardar.FileName = "R07_SaldosPendientes.xlsx"

                If guardar.ShowDialog(Me) <> DialogResult.OK Then Return

                Using libro As New ClosedXML.Excel.XLWorkbook()
                    Dim hoja = libro.Worksheets.Add("Saldos pendientes")

                    hoja.Cell(1, 1).Value =
                        "GYMCONTROL - CARTERA DE SALDOS PENDIENTES"

                    hoja.Range(1, 1, 1, 12).Merge()
                    hoja.Cell(1, 1).Style.Font.Bold = True
                    hoja.Cell(1, 1).Style.Font.FontSize = 16

                    hoja.Cell(3, 1).InsertTable(datos, "TablaSaldos", True)

                    hoja.Columns().AdjustToContents()
                    libro.SaveAs(guardar.FileName)
                End Using
            End Using

            MessageBox.Show("Excel generado correctamente.")

        Catch ex As Exception
            MessageBox.Show("Error al exportar Excel: " & ex.Message,
                            "GymControl", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ExportarLibroIngresosExcel()
        Try
            Dim anio As Integer = Decimal.ToInt32(nudAnio.Value)
            Dim datos As DataTable = ReportesDAO.LibroIngresos(anio)

            If datos.Rows.Count = 0 Then
                MessageBox.Show("No hay ingresos registrados para el año " & anio.ToString() & ".")
                Return
            End If

            Using guardar As New SaveFileDialog()
                guardar.Title = "Guardar libro anual de ingresos"
                guardar.Filter = "Excel (*.xlsx)|*.xlsx"
                guardar.FileName = "R09_LibroIngresos_" & anio.ToString() & ".xlsx"

                If guardar.ShowDialog(Me) <> DialogResult.OK Then Return

                Using libro As New ClosedXML.Excel.XLWorkbook()
                    Dim hoja = libro.Worksheets.Add("Ingresos " & anio.ToString())
                    Dim ultimaColumna As Integer = datos.Columns.Count

                    hoja.Cell(1, 1).Value = "GYMCONTROL - LIBRO ANUAL DE INGRESOS"
                    hoja.Range(1, 1, 1, ultimaColumna).Merge()
                    hoja.Cell(1, 1).Style.Font.Bold = True
                    hoja.Cell(1, 1).Style.Font.FontSize = 16

                    hoja.Cell(2, 1).Value = "Año: " & anio.ToString()
                    hoja.Cell(3, 1).Value =
                        "Fecha de emisión: " & Date.Today.ToString("dd/MM/yyyy")

                    hoja.Cell(5, 1).InsertTable(datos, "TablaIngresosAnuales", True)

                    Dim filaTotal As Integer = 6 + datos.Rows.Count
                    Dim columnaMonto As Integer = datos.Columns("monto").Ordinal + 1
                    Dim total As Decimal = 0D

                    For Each fila As DataRow In datos.Rows
                        If Not IsDBNull(fila("monto")) Then
                            total += Convert.ToDecimal(fila("monto"))
                        End If
                    Next

                    hoja.Cell(filaTotal, columnaMonto - 1).Value = "TOTAL ANUAL:"
                    hoja.Cell(filaTotal, columnaMonto).Value = total
                    hoja.Cell(filaTotal, columnaMonto - 1).Style.Font.Bold = True
                    hoja.Cell(filaTotal, columnaMonto).Style.Font.Bold = True
                    hoja.Column(columnaMonto).Style.NumberFormat.Format = "#,##0.00"

                    hoja.Columns().AdjustToContents()
                    libro.SaveAs(guardar.FileName)
                End Using
            End Using

            MessageBox.Show("Libro anual de ingresos exportado correctamente.")

        Catch ex As Exception
            MessageBox.Show("Error al exportar el libro anual: " & ex.Message,
                            "GymControl", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnExportarPdf_Click(sender As Object, e As EventArgs) Handles btnExportarPdf.Click
        If reporteSeleccionado = "R08" Then
            ExportarInformeGerencialPDF()
        End If
    End Sub

    Private Sub ExportarInformeGerencialPDF()
        Try
            If dtpDesde.Value.Date > dtpHasta.Value.Date Then
                MessageBox.Show("La fecha inicial no puede superar la final.")
                Return
            End If

            QuestPDF.Settings.License =
                QuestPDF.Infrastructure.LicenseType.Community

            Dim datos As DataTable =
                ReportesDAO.InformeGerencial(dtpDesde.Value.Date, dtpHasta.Value.Date)

            If datos.Rows.Count = 0 Then
                MessageBox.Show("No hay datos para el informe.")
                Return
            End If

            Dim fila As DataRow = datos.Rows(0)

            Using guardar As New SaveFileDialog()
                guardar.Title = "Guardar informe gerencial"
                guardar.Filter = "PDF (*.pdf)|*.pdf"
                guardar.FileName = "R08_InformeGerencial.pdf"

                If guardar.ShowDialog(Me) <> DialogResult.OK Then Return

                Dim documento = QuestPDF.Fluent.Document.Create(
                    Sub(contenedor)
                        contenedor.Page(
                            Sub(pagina)
                                pagina.Size(QuestPDF.Helpers.PageSizes.A4)
                                pagina.Margin(40)

                                pagina.Header().Text(
                                    "GYMCONTROL - INFORME GERENCIAL").FontSize(18).Bold()

                                pagina.Content().Column(
                                    Sub(columna)
                                        columna.Spacing(12)

                                        columna.Item().Text(
                                            "Período: " &
                                            dtpDesde.Value.ToString("dd/MM/yyyy") &
                                            " al " &
                                            dtpHasta.Value.ToString("dd/MM/yyyy"))

                                        columna.Item().Text(
                                            "Socios activos: " &
                                            fila("socios_activos").ToString())

                                        columna.Item().Text(
                                            "Nuevas membresías: " &
                                            fila("nuevas_membresias").ToString())

                                        columna.Item().Text(
                                            "Cantidad de pagos: " &
                                            fila("cantidad_pagos").ToString())

                                        columna.Item().Text(
                                            "Ingresos del período: C$ " &
                                            Convert.ToDecimal(
                                                fila("ingresos_mes")).ToString("N2"))

                                        columna.Item().Text(
                                            "Saldo pendiente actual: C$ " &
                                            Convert.ToDecimal(
                                                fila("saldo_pendiente_actual")).ToString("N2"))
                                    End Sub)

                                pagina.Footer().AlignCenter().Text(
                                    "GymControl - Reporte gerencial")
                            End Sub)
                    End Sub)

                documento.GeneratePdf(guardar.FileName)
            End Using

            MessageBox.Show("PDF generado correctamente.")

        Catch ex As Exception
            MessageBox.Show("Error al generar PDF: " & ex.Message,
                            "GymControl", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

End Class
