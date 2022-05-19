USE [Doofast]
GO

CREATE PROCEDURE [dbo].[AgregarEmpleado]
@nombre varchar(255),
@tipoEmpleado varchar(50)
	AS
	BEGIN

	INSERT INTO Empleado(nombre,tipoEmpleado) VALUES (@nombre,@tipoEmpleado);
	END
CREATE PROCEDURE [dbo].[ListarEmpleados]
AS
BEGIN 
	SELECT * FROM Empleado 
		WHERE visible = 1;
END
