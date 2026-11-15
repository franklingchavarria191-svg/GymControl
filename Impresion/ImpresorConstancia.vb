
Imports System.Data
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Windows.Forms

Public Class ImpresorConstancia

    Private ReadOnly datos As DataTable
    Private ReadOnly documento As PrintDocument

    Public Sub New(datosConstancia As DataTable)

        If datosConstancia Is Nothing OrElse datosConstancia.Rows.Count = 0 Then
            Throw New ArgumentException("No hay datos para generar la constancia.")
        End If

        datos = datosConstancia

        documento = New PrintDocument()
        documento.DocumentName = "GymControl - Constancia de membresía"

        ' Formato de hoja carta
        documento.DefaultPageSettings.PaperSize =
            New PaperSize("Carta", 850, 1100)

        documento.DefaultPageSettings.Margins =
            New Margins(70, 70, 70, 70)

        AddHandler documento.PrintPage, AddressOf ImprimirPagina

    End Sub

    Public Sub MostrarVistaPrevia()

        Using vista As New PrintPreviewDialog()
            vista.Document = documento
            vista.WindowState = FormWindowState.Maximized
            vista.ShowDialog()
        End Using

    End Sub

    Public Sub Imprimir()

        Using dialogo As New PrintDialog()
            dialogo.Document = documento

            If dialogo.ShowDialog() = DialogResult.OK Then
                documento.Print()
            End If
        End Using

    End Sub

    Private Sub ImprimirPagina(sender As Object, e As PrintPageEventArgs)

        Dim membresia As DataRow = datos.Rows(0)

        Using titulo As New Font("Arial", 18, FontStyle.Bold),
              subtitulo As New Font("Arial", 14, FontStyle.Bold),
              texto As New Font("Arial", 11)

            Dim area As Rectangle = e.MarginBounds
            Dim y As Single = area.Top

            Using centrado As New StringFormat() With {
                .Alignment = StringAlignment.Center
            }

                e.Graphics.DrawString(
                    "GYMCONTROL",
                    titulo,
                    Brushes.Black,
                    New RectangleF(area.Left, y, area.Width, 40),
                    centrado)

                y += 65

                e.Graphics.DrawString(
                    "CONSTANCIA DE MEMBRESÍA",
                    subtitulo,
                    Brushes.Black,
                    New RectangleF(area.Left, y, area.Width, 35),
                    centrado)

                y += 80

                Dim parrafo As String =
                    "Por medio de la presente se hace constar que " &
                    membresia("socio").ToString() &
                    ", con cédula " & membresia("cedula").ToString() &
                    ", posee una membresía registrada en GymControl."

                Using formato As New StringFormat()

                    formato.Trimming = StringTrimming.Word

                    e.Graphics.DrawString(
                        parrafo,
                        texto,
                        Brushes.Black,
                        New RectangleF(area.Left, y, area.Width, 110),
                        formato)

                End Using

                y += 135

                Dim detalles As String() = {
                    "N.º de membresía: " & membresia("id_membresia").ToString(),
                    "Tipo de membresía: " & membresia("tipo_membresia").ToString(),
                    "Fecha de inicio: " & membresia("fecha_inicio").ToString(),
                    "Fecha de vencimiento: " & membresia("fecha_vencimiento").ToString(),
                    "Estado: " & membresia("estado").ToString(),
                    "Vigencia: " & membresia("vigencia").ToString()
                }

                For Each detalle As String In detalles
                    e.Graphics.DrawString(
                        detalle,
                        texto,
                        Brushes.Black,
                        area.Left,
                        y)

                    y += 35
                Next

                y += 65

                e.Graphics.DrawString(
                    "Emitida el " & Date.Today.ToString("dd/MM/yyyy"),
                    texto,
                    Brushes.Black,
                    area.Left,
                    y)

                y += 100

                e.Graphics.DrawLine(
                    Pens.Black,
                    area.Left + 150,
                    y,
                    area.Right - 150,
                    y)

                y += 10

                e.Graphics.DrawString(
                    "Firma autorizada",
                    texto,
                    Brushes.Black,
                    New RectangleF(area.Left, y, area.Width, 30),
                    centrado)

            End Using

        End Using

        e.HasMorePages = False

    End Sub

End Class
