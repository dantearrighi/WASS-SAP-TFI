CREATE VIEW ListaTramites AS
SELECT DISTINCT
t.Id, tt.Descripcion, p.DNI, p.NombreYapellido,  dt.Descripcion, dt.Fecha_Desde as 'Ultimo Movimiento'
FROM Tramite t
INNER JOIN Persona p
	ON t.Persona_Id = p.Id
INNER JOIN Tipo_Tramite tt
	ON t.Tipo_Tramite_Id = tt.Id
INNER JOIN Detalles_Tramite dt
	ON dt.Tramite_Id = t.Id
WHERE
(dt.Fecha_Desde IN (SELECT MAX(ddt.Fecha_Desde) AS 'Ultimo movimiento'
					FROM Detalles_Tramite ddt
					GROUP BY ddt.Tramite_Id))
					