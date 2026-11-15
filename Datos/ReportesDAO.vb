
Imports MySqlConnector
Imports System.Data

Public Class ReportesDAO

    Private Shared Function EjecutarConsulta(sql As String, ParamArray parametros() As MySqlParameter) As DataTable
        Dim tabla As New DataTable()

        Using cn As MySqlConnection = ConexionBD.ObtenerConexionReportes()
            cn.Open()

            Using cmd As New MySqlCommand(sql, cn)
                If parametros IsNot Nothing Then
                    cmd.Parameters.AddRange(parametros)
                End If

                Using lector As MySqlDataReader = cmd.ExecuteReader()
                    tabla.Load(lector)
                End Using
            End Using
        End Using

        Return tabla
    End Function

    Public Shared Function ReciboPago(idPago As Integer) As DataTable
        Dim sql As String =
            "SELECT id_pago, socio, cedula, id_membresia, " &
            "fecha_pago, monto, metodo_pago, referencia, observacion, anulado " &
            "FROM vw_ingresos_detalle " &
            "WHERE anulado = 0 AND id_pago = @idPago"

        Return EjecutarConsulta(sql, New MySqlParameter("@idPago", idPago))
    End Function

    Public Shared Function ConstanciaMembresia(idMembresia As Integer) As DataTable
        Dim sql As String =
            "SELECT id_membresia, id_socio, socio, cedula, " &
            "plan AS tipo_membresia, fecha_inicio, fecha_vencimiento, " &
            "precio_pactado, estado, " &
            "CASE WHEN estado = 'Activa' " &
            "AND fecha_inicio <= CURDATE() " &
            "AND fecha_vencimiento >= CURDATE() " &
            "THEN 'Vigente' ELSE 'No vigente' END AS vigencia " &
            "FROM vw_saldos_membresia " &
            "WHERE id_membresia = @idMembresia"

        Return EjecutarConsulta(sql, New MySqlParameter("@idMembresia", idMembresia))
    End Function

    Public Shared Function ListadoVencimientos(
        diasAdelante As Integer,
        Optional diasAtras As Integer = 0,
        Optional soloConSaldo As Boolean = False
    ) As DataTable

        If diasAdelante < 0 OrElse diasAtras < 0 Then
            Throw New ArgumentException("Los días no pueden ser negativos.")
        End If

        Dim sql As String =
            "SELECT id_membresia, socio, cedula, telefono, " &
            "plan AS tipo_membresia, fecha_inicio, fecha_vencimiento, " &
            "DATEDIFF(fecha_vencimiento, CURDATE()) AS dias_restantes, " &
            "GREATEST(saldo, 0) AS saldo_pendiente, " &
            "CASE WHEN fecha_vencimiento < CURDATE() THEN 'Vencida' " &
            "WHEN fecha_vencimiento = CURDATE() THEN 'Vence hoy' " &
            "ELSE 'Proxima a vencer' END AS situacion " &
            "FROM vw_saldos_membresia " &
            "WHERE estado IN ('Activa', 'Vencida') " &
            "AND fecha_vencimiento BETWEEN " &
            "DATE_SUB(CURDATE(), INTERVAL @diasAtras DAY) " &
            "AND DATE_ADD(CURDATE(), INTERVAL @diasAdelante DAY) "

        If soloConSaldo Then
            sql &= "AND saldo > 0 "
        End If

        sql &= "ORDER BY fecha_vencimiento"

        Return EjecutarConsulta(
            sql,
            New MySqlParameter("@diasAtras", diasAtras),
            New MySqlParameter("@diasAdelante", diasAdelante)
        )

    End Function

    Public Shared Function IngresosPeriodo(desde As Date, hasta As Date) As DataTable
        Dim sql As String =
            "SELECT DATE(fecha_pago) AS fecha, metodo_pago, " &
            "COUNT(*) AS cantidad_pagos, SUM(monto) AS total_ingresos " &
            "FROM vw_ingresos_detalle " &
            "WHERE anulado = 0 " &
            "AND fecha_pago >= @desde AND fecha_pago < @hasta " &
            "GROUP BY DATE(fecha_pago), metodo_pago " &
            "ORDER BY fecha, metodo_pago"

        Return EjecutarConsulta(sql,
            New MySqlParameter("@desde", desde.Date),
            New MySqlParameter("@hasta", hasta.Date.AddDays(1)))
    End Function

    Public Shared Function EstadoCuenta(idSocio As Integer) As DataTable
        Dim sql As String =
            "SELECT id_socio, socio, cedula, id_membresia, " &
            "plan AS tipo_membresia, fecha_inicio, fecha_vencimiento, " &
            "precio_pactado, " &
            "pagado AS total_pagado, " &
            "GREATEST(saldo, 0) AS saldo_pendiente, estado " &
            "FROM vw_saldos_membresia " &
            "WHERE id_socio = @idSocio " &
            "ORDER BY fecha_inicio DESC"

        Return EjecutarConsulta(sql, New MySqlParameter("@idSocio", idSocio))
    End Function

    Public Shared Function HorarioSemanal() As DataTable
        Dim sql As String =
            "SELECT id_horario, dia AS dia_semana, " &
            "nombre_dia AS dia, hora_inicio, hora_fin, " &
            "actividad, instructor, sala, " &
            "capacidad_sala, cupo_maximo, " &
            "activo AS horario_activo " &
            "FROM vw_horario_semanal " &
            "ORDER BY dia_semana, hora_inicio, sala"

        Return EjecutarConsulta(sql)
    End Function

    Public Shared Function SaldosPendientes() As DataTable
        Dim sql As String =
            "SELECT id_membresia, id_socio, socio, cedula, " &
            "telefono, plan AS tipo_membresia, fecha_vencimiento, " &
            "estado, precio_pactado, pagado AS total_pagado, " &
            "GREATEST(saldo, 0) AS saldo_pendiente, " &
            "GREATEST(DATEDIFF(CURDATE(), fecha_vencimiento), 0) AS dias_vencidos " &
            "FROM vw_saldos_membresia " &
            "WHERE saldo > 0 " &
            "ORDER BY saldo_pendiente DESC"

        Return EjecutarConsulta(sql)
    End Function

    Public Shared Function InformeGerencial(desde As Date, hasta As Date) As DataTable
        Dim sql As String =
            "SELECT " &
            "(SELECT COUNT(DISTINCT id_socio) " &
            "FROM vw_saldos_membresia " &
            "WHERE estado = 'Activa' " &
            "AND fecha_inicio <= CURDATE() " &
            "AND fecha_vencimiento >= CURDATE()) AS socios_activos, " &
            "(SELECT COUNT(*) FROM vw_saldos_membresia " &
            "WHERE fecha_inicio >= @desde " &
            "AND fecha_inicio < @fin) AS nuevas_membresias, " &
            "(SELECT COUNT(*) FROM vw_ingresos_detalle " &
            "WHERE anulado = 0 AND fecha_pago >= @desde " &
            "AND fecha_pago < @fin) AS cantidad_pagos, " &
            "(SELECT COALESCE(SUM(monto), 0) " &
            "FROM vw_ingresos_detalle " &
            "WHERE anulado = 0 AND fecha_pago >= @desde " &
            "AND fecha_pago < @fin) AS ingresos_mes, " &
            "(SELECT COALESCE(SUM(GREATEST(saldo, 0)), 0) " &
            "FROM vw_saldos_membresia) AS saldo_pendiente_actual"

        Return EjecutarConsulta(sql,
            New MySqlParameter("@desde", desde.Date),
            New MySqlParameter("@fin", hasta.Date.AddDays(1)))
    End Function

    Public Shared Function IngresosPorTipoMembresia(desde As Date, hasta As Date) As DataTable
        Dim sql As String =
            "SELECT plan AS tipo_membresia, " &
            "COUNT(*) AS cantidad_pagos, " &
            "COALESCE(SUM(monto), 0) AS total_ingresos " &
            "FROM vw_ingresos_detalle " &
            "WHERE anulado = 0 " &
            "AND fecha_pago >= @desde " &
            "AND fecha_pago < @fin " &
            "GROUP BY plan " &
            "ORDER BY total_ingresos DESC"

        Return EjecutarConsulta(sql,
            New MySqlParameter("@desde", desde.Date),
            New MySqlParameter("@fin", hasta.Date.AddDays(1)))
    End Function

    Public Shared Function Top10SaldosPendientes() As DataTable
        Dim sql As String =
            "SELECT id_membresia, socio, cedula, telefono, " &
            "plan AS tipo_membresia, fecha_vencimiento, " &
            "GREATEST(saldo, 0) AS saldo_pendiente " &
            "FROM vw_saldos_membresia " &
            "WHERE saldo > 0 " &
            "ORDER BY saldo_pendiente DESC " &
            "LIMIT 10"

        Return EjecutarConsulta(sql)
    End Function

    Public Shared Function HorasClasePorInstructor() As DataTable
        Dim sql As String =
            "SELECT instructor, " &
            "COUNT(*) AS cantidad_clases, " &
            "ROUND(COALESCE(SUM(minutos), 0) / 60, 2) AS horas_clase " &
            "FROM vw_horario_semanal " &
            "WHERE activo = 1 " &
            "GROUP BY instructor " &
            "ORDER BY horas_clase DESC"

        Return EjecutarConsulta(sql)
    End Function

    Public Shared Function LibroIngresos(anio As Integer) As DataTable
        Dim sql As String =
            "SELECT YEAR(fecha_pago) AS anio, " &
            "MONTH(fecha_pago) AS numero_mes, " &
            "MONTHNAME(fecha_pago) AS mes, " &
            "id_pago, fecha_pago, socio, id_membresia, " &
            "metodo_pago, referencia, monto " &
            "FROM vw_ingresos_detalle " &
            "WHERE anulado = 0 " &
            "AND fecha_pago >= @inicio " &
            "AND fecha_pago < @fin " &
            "ORDER BY fecha_pago, id_pago"

        Return EjecutarConsulta(sql,
            New MySqlParameter("@inicio", New Date(anio, 1, 1)),
            New MySqlParameter("@fin", New Date(anio + 1, 1, 1)))
    End Function

End Class
