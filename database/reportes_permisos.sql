
USE GymControl;

GRANT SELECT ON GymControl.vw_ingresos_detalle
TO 'gym_reportes'@'localhost';

GRANT SELECT ON GymControl.vw_saldos_membresia
TO 'gym_reportes'@'localhost';

GRANT SELECT ON GymControl.vw_estado_cuenta
TO 'gym_reportes'@'localhost';

GRANT SELECT ON GymControl.vw_horario_semanal
TO 'gym_reportes'@'localhost';

SHOW GRANTS FOR 'gym_reportes'@'localhost';
