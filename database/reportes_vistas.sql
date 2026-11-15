
USE GymControl;

CREATE OR REPLACE VIEW vw_ingresos_detalle AS
SELECT
    p.id_pago,
    p.id_membresia,
    p.fecha_pago AS fecha,
    p.fecha_pago,
    m.id_socio,
    CONCAT(s.nombres, ' ', s.apellidos) AS socio,
    s.cedula,
    tm.nombre AS plan,
    p.metodo_pago AS metodo,
    p.metodo_pago,
    p.monto,
    p.anulado,
    p.referencia,
    p.observacion,
    p.id_usuario_registro,
    u.nombre_usuario AS registro
FROM pagos p
INNER JOIN membresias m
    ON p.id_membresia = m.id_membresia
INNER JOIN socios s
    ON m.id_socio = s.id_socio
INNER JOIN tipos_membresia tm
    ON m.id_tipo = tm.id_tipo
LEFT JOIN usuarios u
    ON p.id_usuario_registro = u.id_usuario;

CREATE OR REPLACE VIEW vw_saldos_membresia AS
SELECT
    m.id_membresia,
    m.id_socio,
    CONCAT(s.nombres, ' ', s.apellidos) AS socio,
    s.cedula,
    s.telefono,
    tm.nombre AS plan,
    m.fecha_inicio AS inicio,
    m.fecha_vencimiento AS vence,
    m.fecha_inicio,
    m.fecha_vencimiento,
    m.precio_pactado,
    COALESCE(SUM(
        CASE
            WHEN p.anulado = 0 THEN p.monto
            ELSE 0
        END
    ), 0) AS pagado,
    m.precio_pactado - COALESCE(SUM(
        CASE
            WHEN p.anulado = 0 THEN p.monto
            ELSE 0
        END
    ), 0) AS saldo,
    m.estado
FROM membresias m
INNER JOIN socios s
    ON m.id_socio = s.id_socio
INNER JOIN tipos_membresia tm
    ON m.id_tipo = tm.id_tipo
LEFT JOIN pagos p
    ON m.id_membresia = p.id_membresia
GROUP BY
    m.id_membresia,
    m.id_socio,
    s.nombres,
    s.apellidos,
    s.cedula,
    s.telefono,
    tm.nombre,
    m.fecha_inicio,
    m.fecha_vencimiento,
    m.precio_pactado,
    m.estado;

CREATE OR REPLACE VIEW vw_estado_cuenta AS
SELECT
    s.id_socio,
    CONCAT(s.nombres, ' ', s.apellidos) AS socio,
    s.cedula,
    m.id_membresia,
    tm.nombre AS plan,
    m.fecha_inicio,
    m.fecha_vencimiento,
    m.precio_pactado,
    m.estado,
    p.id_pago,
    p.fecha_pago,
    p.monto,
    p.metodo_pago,
    p.anulado,
    p.referencia
FROM socios s
INNER JOIN membresias m
    ON s.id_socio = m.id_socio
INNER JOIN tipos_membresia tm
    ON m.id_tipo = tm.id_tipo
LEFT JOIN pagos p
    ON m.id_membresia = p.id_membresia;

CREATE OR REPLACE VIEW vw_horario_semanal AS
SELECT
    h.id_horario,
    h.dia_semana AS dia,
    CASE h.dia_semana
        WHEN 1 THEN 'Lunes'
        WHEN 2 THEN 'Martes'
        WHEN 3 THEN 'Miercoles'
        WHEN 4 THEN 'Jueves'
        WHEN 5 THEN 'Viernes'
        WHEN 6 THEN 'Sabado'
        WHEN 7 THEN 'Domingo'
        ELSE 'Sin definir'
    END AS nombre_dia,
    h.hora_inicio,
    h.hora_fin,
    TIME_TO_SEC(
        TIMEDIFF(h.hora_fin, h.hora_inicio)
    ) / 60 AS minutos,
    a.nombre AS actividad,
    CONCAT(i.nombres, ' ', i.apellidos) AS instructor,
    sa.nombre AS sala,
    h.activo,
    sa.capacidad AS capacidad_sala,
    a.cupo_maximo AS cupo_maximo
FROM horarios h
INNER JOIN actividades a
    ON h.id_actividad = a.id_actividad
INNER JOIN instructores i
    ON h.id_instructor = i.id_instructor
INNER JOIN salas sa
    ON h.id_sala = sa.id_sala;
