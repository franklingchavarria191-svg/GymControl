
Imports System.Data
Imports System.Text

Public Class PruebaReportes

    Public Shared Function EjecutarPruebas() As String
        Dim mensajeConexion As String = ""

        If Not ConexionBD.ProbarConexionReportes(mensajeConexion) Then
            Return mensajeConexion
        End If

        Dim resultado As New StringBuilder()

        Probar("R01 - Recibo de pago", Function() ReportesDAO.ReciboPago(76), resultado)
        Probar("R02 - Constancia de membresía", Function() ReportesDAO.ConstanciaMembresia(1), resultado)
        Probar("R03 - Listado de vencimientos", Function() ReportesDAO.ListadoVencimientos(7), resultado)
        Probar("R04 - Ingresos por período", Function() ReportesDAO.IngresosPeriodo(New Date(2026, 10, 1), New Date(2026, 10, 31)), resultado)
        Probar("R05 - Estado de cuenta", Function() ReportesDAO.EstadoCuenta(1), resultado)
        Probar("R06 - Horario semanal", Function() ReportesDAO.HorarioSemanal(), resultado)
        Probar("R07 - Saldos pendientes", Function() ReportesDAO.SaldosPendientes(), resultado)
        Probar("R08 - Informe gerencial", Function() ReportesDAO.InformeGerencial(New Date(2026, 10, 1), New Date(2026, 10, 31)), resultado)
        Probar("R08 - Ingresos por tipo de membresía", Function() ReportesDAO.IngresosPorTipoMembresia(New Date(2026, 10, 1), New Date(2026, 10, 31)), resultado)
        Probar("R08 - Top 10 saldos pendientes", Function() ReportesDAO.Top10SaldosPendientes(), resultado)
        Probar("R08 - Horas por instructor", Function() ReportesDAO.HorasClasePorInstructor(), resultado)
        Probar("R09 - Libro de ingresos", Function() ReportesDAO.LibroIngresos(2026), resultado)

        Return resultado.ToString()
    End Function

    Private Shared Sub Probar(nombre As String, consulta As Func(Of DataTable), resultado As StringBuilder)
        Try
            Dim datos As DataTable = consulta()
            resultado.AppendLine(nombre & ": OK - " & datos.Rows.Count & " registros")
        Catch ex As Exception
            resultado.AppendLine(nombre & ": ERROR - " & ex.Message)
        End Try
    End Sub

End Class
