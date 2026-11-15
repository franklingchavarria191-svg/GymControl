Imports System.Data
Imports System.Drawing
Imports System.Drawing.Printing
Public Class frmListadoVencimientos

    Private datosVencimientos As DataTable
    Private filaActual As Integer
    Private numeroPagina As Integer
    Private filtrosImpresion As String = ""
    Private Sub btnCargar_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnCargar.Click

        btnVistaPrevia.Enabled = False
        btnImprimir.Enabled = False
        btnConfigurarPágina.Enabled = False
        lblResumen.Text = ""
        dgvVencimientos.DataSource = Nothing
        datosVencimientos = Nothing

        Try
            Dim diasAdelante As Integer = CInt(nudDiasAdelante.Value)
            Dim diasAtras As Integer = CInt(nudDiasAtras.Value)
            Dim soloConSaldo As Boolean = chkSoloConSaldo.Checked

            datosVencimientos = ReportesDAO.ListadoVencimientos(
                diasAdelante,
                diasAtras,
                soloConSaldo)

            Dim hayDatos As Boolean =
                datosVencimientos IsNot Nothing AndAlso
                datosVencimientos.Rows.Count > 0

            dgvVencimientos.DataSource = datosVencimientos
            dgvVencimientos.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill
            dgvVencimientos.ReadOnly = True
            dgvVencimientos.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect
            dgvVencimientos.AllowUserToAddRows = False
            dgvVencimientos.RowHeadersVisible = False

            btnVistaPrevia.Enabled = hayDatos
            btnImprimir.Enabled = hayDatos
            btnConfigurarPágina.Enabled = hayDatos

            If Not hayDatos Then
                lblResumen.Text = "Sin registros"

                MessageBox.Show(
                    "No se encontraron vencimientos para el período seleccionado.",
                    "R03 - Vencimientos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information)

                Return
            End If

            filtrosImpresion =
                "Próximos " & diasAdelante.ToString() &
                " días | Vencidos hasta hace " & diasAtras.ToString() &
                " días | Solo con saldo: " &
                If(soloConSaldo, "Sí", "No")

            lblResumen.Text =
                "Total de registros: " &
                datosVencimientos.Rows.Count.ToString()

            MessageBox.Show(
                "Se cargaron " &
                datosVencimientos.Rows.Count.ToString() &
                " registros de vencimientos.",
                "R03 - Vencimientos",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)

        Catch ex As Exception
            datosVencimientos = Nothing
            dgvVencimientos.DataSource = Nothing
            lblResumen.Text = "Error al cargar"

            MessageBox.Show(
                "Error al cargar los vencimientos: " & ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub chkHorizontal_CheckedChanged(
        sender As Object,
        e As EventArgs
    ) Handles chkHorizontal.CheckedChanged

        pdListado.DefaultPageSettings.Landscape =
            chkHorizontal.Checked

    End Sub

    Private Sub pdListado_BeginPrint(
        sender As Object,
        e As PrintEventArgs
    ) Handles pdListado.BeginPrint

        filaActual = 0
        numeroPagina = 1

    End Sub

    Private Sub pdListado_PrintPage(
        sender As Object,
        e As PrintPageEventArgs
    ) Handles pdListado.PrintPage

        If datosVencimientos Is Nothing OrElse
            datosVencimientos.Rows.Count = 0 Then

            e.HasMorePages = False
            Return
        End If

        Dim g As Graphics = e.Graphics
        Dim area As Rectangle = e.MarginBounds
        Dim columnas As Integer = datosVencimientos.Columns.Count

        If columnas = 0 Then
            e.HasMorePages = False
            Return
        End If

        Using fuenteTitulo As New Font("Segoe UI", 15, FontStyle.Bold),
              fuenteSubtitulo As New Font("Segoe UI", 9),
              fuenteEncabezado As New Font("Segoe UI", 8, FontStyle.Bold),
              fuenteDatos As New Font("Segoe UI", 8),
              fondoEncabezado As New SolidBrush(Color.FromArgb(225, 233, 243)),
              formato As New StringFormat()

            formato.Alignment = StringAlignment.Near
            formato.LineAlignment = StringAlignment.Center
            formato.Trimming = StringTrimming.EllipsisCharacter
            formato.FormatFlags = StringFormatFlags.NoWrap

            Dim x As Single = area.Left
            Dim y As Single = area.Top
            Dim ancho As Single = area.Width
            Dim altoFila As Single = 30
            Dim altoEncabezado As Single = 36
            Dim anchoColumna As Single = ancho / columnas
            Dim limiteInferior As Single = area.Bottom - 35

            g.DrawString(
                "GYMCONTROL - LISTADO DE VENCIMIENTOS",
                fuenteTitulo,
                Brushes.Black,
                x,
                y)

            y += 40

            g.DrawString(
                filtrosImpresion,
                fuenteSubtitulo,
                Brushes.Black,
                New RectangleF(x, y, ancho, 35))

            y += 40

            g.DrawString(
                "Fecha de emisión: " &
                DateTime.Now.ToString("dd/MM/yyyy HH:mm"),
                fuenteSubtitulo,
                Brushes.Black,
                x,
                y)

            y += 30

            If y + altoEncabezado + altoFila > limiteInferior Then
                Throw New InvalidOperationException(
                    "El área imprimible es demasiado pequeña. Ajuste los márgenes o el tamaño del papel.")
            End If

            For i As Integer = 0 To columnas - 1

                Dim rect As New RectangleF(
                    x + i * anchoColumna,
                    y,
                    anchoColumna,
                    altoEncabezado)

                g.FillRectangle(fondoEncabezado, rect)
                g.DrawRectangle(
                    Pens.Gray,
                    rect.X,
                    rect.Y,
                    rect.Width,
                    rect.Height)

                Dim textoRect As New RectangleF(
                    rect.X + 3,
                    rect.Y,
                    Math.Max(1.0F, rect.Width - 6),
                    rect.Height)

                g.DrawString(
                    datosVencimientos.Columns(i).ColumnName,
                    fuenteEncabezado,
                    Brushes.Black,
                    textoRect,
                    formato)

            Next

            y += altoEncabezado

            While filaActual < datosVencimientos.Rows.Count

                If y + altoFila > limiteInferior Then
                    Exit While
                End If

                For i As Integer = 0 To columnas - 1

                    Dim rect As New RectangleF(
                        x + i * anchoColumna,
                        y,
                        anchoColumna,
                        altoFila)

                    If filaActual Mod 2 = 1 Then
                        g.FillRectangle(Brushes.WhiteSmoke, rect)
                    End If

                    g.DrawRectangle(
                        Pens.LightGray,
                        rect.X,
                        rect.Y,
                        rect.Width,
                        rect.Height)

                    Dim valor As String =
                        Convert.ToString(
                            datosVencimientos.Rows(filaActual)(i))

                    If Not IsDBNull(
                        datosVencimientos.Rows(filaActual)(i)) AndAlso
                        datosVencimientos.Columns(i).DataType =
                        GetType(DateTime) Then

                        valor = CDate(
                            datosVencimientos.Rows(filaActual)(i)
                        ).ToString("dd/MM/yyyy")
                    End If

                    Dim textoRect As New RectangleF(
                        rect.X + 3,
                        rect.Y,
                        Math.Max(1.0F, rect.Width - 6),
                        rect.Height)

                    g.DrawString(
                        valor,
                        fuenteDatos,
                        Brushes.Black,
                        textoRect,
                        formato)

                Next

                y += altoFila
                filaActual += 1

            End While

            g.DrawLine(
                Pens.Gray,
                x,
                area.Bottom - 28,
                area.Right,
                area.Bottom - 28)

            g.DrawString(
                "Página " & numeroPagina.ToString() &
                " | Total de registros: " &
                datosVencimientos.Rows.Count.ToString(),
                fuenteSubtitulo,
                Brushes.Black,
                x,
                area.Bottom - 23)

            e.HasMorePages =
                filaActual < datosVencimientos.Rows.Count

            If e.HasMorePages Then
                numeroPagina += 1
            End If

        End Using

    End Sub

    Private Sub btnVistaPrevia_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnVistaPrevia.Click

        If Not ValidarDatos() Then Return

        Try
            pdListado.DefaultPageSettings.Landscape =
                chkHorizontal.Checked

            ppdListado.Document = pdListado
            ppdListado.WindowState = FormWindowState.Maximized
            ppdListado.ShowDialog(Me)

        Catch ex As Exception
            MessageBox.Show(
                "Error al mostrar la vista previa: " & ex.Message,
                "R03 - Vencimientos",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnImprimir_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnImprimir.Click

        If Not ValidarDatos() Then Return

        Try
            pdListado.DefaultPageSettings.Landscape =
                chkHorizontal.Checked

            prdListado.Document = pdListado

            If prdListado.ShowDialog(Me) = DialogResult.OK Then
                pdListado.Print()
            End If

        Catch ex As Exception
            MessageBox.Show(
                "Error al imprimir el listado: " & ex.Message,
                "R03 - Vencimientos",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnConfigurarPágina_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnConfigurarPágina.Click

        If Not ValidarDatos() Then Return

        Try
            pdListado.DefaultPageSettings.Landscape =
                chkHorizontal.Checked

            psdListado.Document = pdListado

            If psdListado.ShowDialog(Me) = DialogResult.OK Then
                chkHorizontal.Checked =
                    pdListado.DefaultPageSettings.Landscape
            End If

        Catch ex As Exception
            MessageBox.Show(
                "Error al configurar la página: " & ex.Message,
                "R03 - Vencimientos",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)
        End Try

    End Sub
    Private Function ValidarDatos() As Boolean

        If datosVencimientos Is Nothing OrElse
            datosVencimientos.Rows.Count = 0 Then

            MessageBox.Show(
                "Primero debe cargar los vencimientos.",
                "R03 - Vencimientos",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

            Return False
        End If

        Return True

    End Function

End Class
