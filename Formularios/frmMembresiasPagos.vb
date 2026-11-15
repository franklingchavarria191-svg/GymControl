Public Class frmMembresiasPagos


    Private Sub btnImprimirRecibo_Click(sender As Object, e As EventArgs) Handles btnImprimirRecibo.Click

        Dim entrada As String = InputBox(
        "Ingrese el ID del pago:",
        "R01 - Imprimir recibo")

        If String.IsNullOrWhiteSpace(entrada) Then Return

        Dim idPago As Integer

        If Not Integer.TryParse(entrada, idPago) OrElse idPago <= 0 Then
            MessageBox.Show("Ingrese un ID de pago válido.")
            Return
        End If

        Try
            Dim datos As DataTable = ReportesDAO.ReciboPago(idPago)

            If datos.Rows.Count = 0 Then
                MessageBox.Show("No se encontró el pago solicitado.")
                Return
            End If

            Dim impresor As New ImpresorRecibo(datos)
            impresor.MostrarVistaPrevia()

        Catch ex As Exception
            MessageBox.Show(
            "Error al mostrar el recibo: " & ex.Message,
            "Error",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error)
        End Try

    End Sub


    Private Sub btnAnularPago_Click(sender As Object, e As EventArgs) Handles btnAnularPago.Click

    End Sub

    Private Sub lblSocio_Click(sender As Object, e As EventArgs) Handles lblSocio.Click

    End Sub

    Private Sub btnConstancia_Click(sender As Object, e As EventArgs) Handles btnConstancia.Click

        Dim entrada As String = InputBox(
            "Ingrese el ID de la membresía:",
            "R02 - Constancia de membresía")

        If String.IsNullOrWhiteSpace(entrada) Then Return

        Dim idMembresia As Integer

        If Not Integer.TryParse(entrada, idMembresia) OrElse idMembresia <= 0 Then
            MessageBox.Show("Ingrese un ID de membresía válido.")
            Return
        End If

        Try
            Dim datos As DataTable =
                ReportesDAO.ConstanciaMembresia(idMembresia)

            If datos Is Nothing OrElse datos.Rows.Count = 0 Then
                MessageBox.Show("No se encontró la membresía solicitada.")
                Return
            End If

            Dim impresor As New ImpresorConstancia(datos)
            impresor.MostrarVistaPrevia()

        Catch ex As Exception
            MessageBox.Show(
                "Error al generar la constancia: " & ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)
        End Try

    End Sub

End Class