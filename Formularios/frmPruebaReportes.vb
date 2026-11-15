
Public Class frmPruebaReportes

    Private Sub frmPruebaReportes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Pruebas de reportes - GymControl"
        Me.Size = New Size(850, 550)
        Me.StartPosition = FormStartPosition.CenterScreen

        Dim txtResultados As New TextBox With {
            .Multiline = True,
            .ReadOnly = True,
            .ScrollBars = ScrollBars.Both,
            .WordWrap = False,
            .Dock = DockStyle.Fill,
            .Font = New Font("Consolas", 11)
        }

        Me.Controls.Add(txtResultados)

        Try
            txtResultados.Text = PruebaReportes.EjecutarPruebas()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class
