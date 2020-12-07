CREATE PROCEDURE SP_VEHICULO_INSERTAR
@placa varchar(50), @marca varchar(10), @modelo varchar(50), @anioFabricacion varchar(50), @certificado varchar(50),
@pesoMaximo decimal(7,2), @volumenMaximo decimal(7,2)
AS
	INSERT INTO Vehiculo(Placa, Marca, Modelo, AnioFabricacion, Certificado, PesoMaximo, VolumenMaximo)
	VALUES (@placa, @marca, @modelo, @anioFabricacion, @certificado, @pesoMaximo, @volumenMaximo)
GO


CREATE PROCEDURE SP_LISTADO
AS
	select * from Vehiculo
GO


CREATE PROCEDURE SP_ACTUALIZAR_VEHICULO
@placa varchar(50), @marca varchar(10), @modelo varchar(50), @anioFabricacion varchar(50), @certificado varchar(50),
@pesoMaximo decimal(7,2), @volumenMaximo decimal(7,2), @id int
AS
	UPDATE Vehiculo
	SET Placa = @placa, Marca = @marca, Modelo = @modelo, AnioFabricacion = @anioFabricacion,
		Certificado = @certificado, PesoMaximo = @pesoMaximo, VolumenMaximo = @volumenMaximo
	WHERE VehiculoId = @id
GO


CREATE PROCEDURE SP_VEHICULO_ELIMINAR
@id int
AS
	DELETE FROM Vehiculo WHERE VehiculoId = @id
GO


CREATE PROCEDURE SP_VEHICULO_OBTENER
@id int
AS
	SELECT 
		VehiculoId, Placa, Marca, Modelo, AnioFabricacion, Certificado,
		PesoMaximo, VolumenMaximo
	FROM Vehiculo
	where VehiculoId = @id
GO


CREATE PROCEDURE  SP_LISTARVEHICULO_X_AÑOS
@AnioInicial varchar(50),
@AnioFinal varchar(50)
AS
	SELECT *
	  FROM Vehiculo v
	  WHERE AnioFabricacion >= @AnioInicial AND  AnioFabricacion <= @AnioFinal
GO
