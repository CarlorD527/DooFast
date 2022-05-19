USE [Doofast]
GO
-- AGREGAR EMPLEADO
CREATE PROCEDURE [dbo].[AgregarEmpleado]
@nombre varchar(255),
@tipoEmpleado varchar(50),
@usuario varchar(50),
@contraseña varchar(100),
@salario money
	AS
	BEGIN

	INSERT INTO Empleado(nombre,tipoEmpleado,usuario,contraseña,salario) 
	VALUES (@nombre,@tipoEmpleado,@usuario,@contraseña,@salario);
	END

-- GET EMPLEADOS
CREATE PROCEDURE [dbo].[ListarEmpleados]
AS
BEGIN 
	SELECT * FROM Empleado 
		WHERE visible = 1;
END