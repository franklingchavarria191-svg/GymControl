
Imports System.Data
Imports System.Drawing
Imports System.Drawing.Printing

Public Class ImpresorRecibo

    Private ReadOnly datos As DataTable
    Private ReadOnly documento As PrintDocument

    Public Sub New(datosRecibo As DataTable)

        If datosRecibo Is Nothing OrElse datosRecibo.Rows.Count = 0 Then
            Throw New ArgumentException("No hay datos para imprimir el recibo.")
        End If

        datos = datosRecibo

        documento = New PrintDocument()
        documento.DocumentName = "GymControl - Recibo de pago"


        ' Ticket de 80 mm de ancho y 200 mm de largo.
        ' PaperSize utiliza centésimas de pulgada.
        Dim anchoTicket As Integer = CInt(Math.Round(80 / 25.4 * 100))
        Dim largoTicket As Integer = CInt(Math.Round(200 / 25.4 * 100))

        documento.DefaultPageSettings.PaperSize =
    New PaperSize("Ticket 80 mm", anchoTicket, largoTicket)

        documento.DefaultPageSettings.Margins =
    New Margins(5, 5, 5, 5)


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

        Dim pago As DataRow = datos.Rows(0)

        Using fuente As New Font("Arial", 8),
              fuenteTitulo As New Font("Arial", 11, FontStyle.Bold)

            Dim x As Single = e.MarginBounds.Left
            Dim y As Single = e.MarginBounds.Top
            Dim ancho As Single = e.MarginBounds.Width

            Dim formato As New StringFormat()
            formato.Alignment = StringAlignment.Center

            ' Encabezado centrado
            e.Graphics.DrawString(
                "GYMCONTROL",
                fuenteTitulo,
                Brushes.Black,
                New RectangleF(x, y, ancho, 22),
                formato)

            y += 25

            e.Graphics.DrawString(
                "RECIBO DE PAGO",
                fuente,
                Brushes.Black,
                New RectangleF(x, y, ancho, 18),
                formato)

            y += 25

            ' Información del pago
            Dim campos As String() = {
                "Pago N.º: " & pago("id_pago").ToString(),
                "Socio: " & pago("socio").ToString(),
                "Cédula: " & pago("cedula").ToString(),
                "Membresía: " & pago("id_membresia").ToString(),
                "Fecha: " & pago("fecha_pago").ToString(),
                "Monto: " & pago("monto").ToString(),
                "Método: " & pago("metodo_pago").ToString(),
                "Referencia: " & pago("referencia").ToString(),
                "Observación: " & pago("observacion").ToString()
            }

            For Each campo As String In campos

                Dim area As New RectangleF(x, y, ancho, 100)

                Dim medida As SizeF = e.Graphics.MeasureString(
                    campo,
                    fuente,
                    CInt(ancho))

                e.Graphics.DrawString(
                    campo,
                    fuente,
                    Brushes.Black,
                    area)

                y += medida.Height + 6

            Next

            y += 10

            e.Graphics.DrawString(
                "Gracias por su pago",
                fuente,
                Brushes.Black,
                New RectangleF(x, y, ancho, 20),
                formato)

        End Using

        e.HasMorePages = False

    End Sub


End Class
