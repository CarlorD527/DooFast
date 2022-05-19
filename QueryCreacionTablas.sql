CREATE TABLE Empleado ( 
  idEmpleado           INT NOT NULL IDENTITY(1,1),
  nombre			VARCHAR(40),
  usuario              VARCHAR(40),
  contraseña           VARCHAR(100),
  tipoEmpleado         VARCHAR(40),
  salario              MONEY,
  visible              BIT DEFAULT 1,
CONSTRAINT PK_9 PRIMARY KEY (idEmpleado)
) 
GO

GO
CREATE TABLE PedidoPersona ( 
  idPedido           INT NOT NULL IDENTITY(1,1),
  idMesa             INT,
  idProducto         INT,
  cantidad           INT NOT NULL,
  fecha              DATE,
  estado             VARCHAR(40),
CONSTRAINT PK_1 PRIMARY KEY (idPedido)
) 
GO
CREATE TABLE Producto ( 
  idProducto             INT NOT NULL IDENTITY(1,1),
  nombreProducto         VARCHAR(128),
  tipoProducto           VARCHAR(128),
  precio                 MONEY,
  imagen                 VARCHAR(40),
  costo                  MONEY,
CONSTRAINT PK_11 PRIMARY KEY (idProducto)
) 
GO

CREATE TABLE Mesa ( 
  idMesa          INT NOT NULL IDENTITY(1,1),
  estado          VARCHAR(40),
  nroMesa         INT,
CONSTRAINT PK_6 PRIMARY KEY (idMesa)
) 
GO
CREATE TABLE HistorialPedidos ( 
  idHistorialPedido         INT NOT NULL IDENTITY(1,1),
  idPedido                  INT,
CONSTRAINT PK_8 PRIMARY KEY (idHistorialPedido)
) 
GO


ALTER TABLE HistorialPedidos
    ADD CONSTRAINT FK_HISTORIAL_TIENE_PEDIDOS
        FOREIGN KEY (idPedido)
            REFERENCES PedidoPersona (idPedido)
 GO
 
                                   

ALTER TABLE PedidoPersona
    ADD CONSTRAINT FK_PEDIDO_TIENE_PRODUCTO
        FOREIGN KEY (idProducto)
            REFERENCES Producto (idProducto)
 GO
 
ALTER TABLE PedidoPersona
    ADD CONSTRAINT FK_MESA_TIENE_PEDIDO
        FOREIGN KEY (idMesa)
            REFERENCES Mesa (idMesa)
 GO
 
             

                                 