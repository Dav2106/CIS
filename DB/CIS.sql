/*CREATE DATABASE*/
CREATE DATABASE CIS;
USE CIS;
/*CREATE DATABASE*/

/*CREATE TABLES*/
CREATE TABLE CategoriaProveedor(
id int primary key auto_increment not null,
nombre varchar(100) not null,
descripcion varchar(300) null,
fechaCreacion datetime not null,
creadoPor varchar(100) not null,
fechaActualizacion datetime not null,
actualizadoPor varchar(100) not null,
isActive int not null
);

CREATE TABLE CategoriaProducto(
id int primary key auto_increment not null,
nombre varchar(100) not null,
descripcion varchar(300) null,
fechaCreacion datetime not null,
creadoPor varchar(100) not null,
fechaActualizacion datetime not null,
actualizadoPor varchar(100) not null,
isActive int not null
);

CREATE TABLE Proveedor(
id int primary key auto_increment not null,
nombre varchar(100) not null,
descripcion varchar(300) null,
direccion varchar(1000) null,
telefono varchar(90) null,
mail varchar(1000) null,
idCateProve int not null,
fechaCreacion datetime not null,
creadoPor varchar(100) not null,
fechaActualizacion datetime not null,
actualizadoPor varchar(100) not null,
isActive int not null,
foreign key (idCateProve) references CategoriaProveedor (id)
);

CREATE TABLE Producto(
id int primary key auto_increment not null,
nombre varchar(100) not null,
descripcion varchar(300) null,
precio float not null,
stock int not null,
idProve int not null,
idCateProd int not null ,
fechaCreacion datetime not null,
creadoPor varchar(100) not null,
fechaActualizacion datetime not null,
actualizadoPor varchar(100) not null,
isActive int not null,
foreign key (idProve) references Proveedor (id),
foreign key (idCateProd) references CategoriaProducto (id)
);

CREATE TABLE DetalleFactura(
id int primary key auto_increment not null,
transaccion int not null,
idProducto int null,
cantidad int not null,
fechaCreacion datetime not null,
creadoPor varchar(100) not null,
fechaActualizacion datetime not null,
actualizadoPor varchar(100) not null,
foreign key (idProducto) references Producto (id)
);

CREATE TABLE Factura(
id int primary key auto_increment not null,
total float not null,
cliente varchar(100) null,
idDetaFact int not null,
tipoPago varchar(100) not null,
fechaCreacion datetime not null,
creadoPor varchar(100) not null,
fechaActualizacion datetime not null,
actualizadoPor varchar(100) not null,
foreign key (idDetaFact) references DetalleFactura (id)
);

CREATE TABLE Usuario(
id int primary key auto_increment not null,
nombre varchar(200) not null,
username varchar(100) not null,
password varchar(100) not null,
isAdmin int not null,
isActive int not null,
fechaCreacion datetime not null,
creadoPor varchar(100) not null,
fechaActualizacion datetime not null,
actualizadoPor varchar(100) not null
);
/*CREATE TABLES*/

/*CREATE PROCEDURES*/
/*----------------------------------------------Catregoria Proveedor---------------------------------------------------------*/
DELIMITER $$
CREATE PROCEDURE InsertCategoriaProveedor(
_nombre varchar(100), _descripcion varchar(300), _fechaCreacion datetime, _creadoPor varchar(100), _fechaActualizacion datetime, 
_actualizadoPor varchar(100), _isActive int
)
BEGIN
INSERT INTO CategoriaProveedor (nombre, descripcion, fechaCreacion, creadoPor, fechaActualizacion, actualizadoPor, isActive)
VALUES (_nombre, _descripcion, _fechaCreacion, _creadoPor, _fechaActualizacion, _actualizadoPor, _isActive);
END $$
DELIMITER 

DELIMITER $$
CREATE PROCEDURE UpdateCategoriaProveedor(
_id int, _nombre varchar(100), _descripcion varchar(300), _fechaActualizacion datetime, _actualizadoPor varchar(100), _isActive int
)
BEGIN
UPDATE CategoriaProveedor SET nombre = _nombre, 
							  descripcion = _descripcion, 
                              fechaActualizacion = _fechaActualizacion, 
                              actualizadoPor = _actualizadoPor,
                              isActive = _isActive
WHERE id = _id;
END $$
DELIMITER 

DELIMITER $$
CREATE PROCEDURE GetCategoriaProveedor(
_id int
)
BEGIN
SELECT id, nombre, descripcion, fechaCreacion, creadoPor, fechaActualizacion, actualizadoPor, isActive FROM CategoriaProveedor 
WHERE id = _id;
END $$
DELIMITER 

CREATE PROCEDURE GetCategoriasProveedor
BEGIN
SELECT id, nombre, descripcion, fechaCreacion, creadoPor, fechaActualizacion, actualizadoPor, isActive FROM CategoriaProveedor 
END $$
DELIMITER 
/*----------------------------------------------Catregoria Proveedor---------------------------------------------------------*/
/*----------------------------------------------Catregoria Producto---------------------------------------------------------*/
DELIMITER $$
CREATE PROCEDURE InsertCategoriaProducto(
_nombre varchar(100), _descripcion varchar(300), _fechaCreacion datetime, _creadoPor varchar(100), _fechaActualizacion datetime, 
_actualizadoPor varchar(100), _isActive int
)
BEGIN
INSERT INTO CategoriaProducto (nombre, descripcion, fechaCreacion, creadoPor, fechaActualizacion, actualizadoPor, isActive)
VALUES (_nombre, _descripcion, _fechaCreacion, _creadoPor, _fechaActualizacion, _actualizadoPor, _isActive);
END $$
DELIMITER 

DELIMITER $$
CREATE PROCEDURE UpdateCategoriaProducto(
_id int, _nombre varchar(100), _descripcion varchar(300), _fechaActualizacion datetime, _actualizadoPor varchar(100), _isActive int
)
BEGIN
UPDATE CategoriaProducto SET nombre = _nombre, 
							  descripcion = _descripcion, 
                              fechaActualizacion = _fechaActualizacion, 
                              actualizadoPor = _actualizadoPor,
                              isActive = _isActive
WHERE id = _id;
END $$
DELIMITER 

DELIMITER $$
CREATE PROCEDURE GetCategoriaProducto(
_id int
)
BEGIN
SELECT id, nombre, descripcion, fechaCreacion, creadoPor, fechaActualizacion, actualizadoPor, isActive FROM CategoriaProducto 
WHERE id = _id;
END $$
DELIMITER 

CREATE PROCEDURE GetCategoriasProducto
BEGIN
SELECT id, nombre, descripcion, fechaCreacion, creadoPor, fechaActualizacion, actualizadoPor, isActive FROM CategoriaProducto 
END $$
DELIMITER 
/*----------------------------------------------Catregoria Producto---------------------------------------------------------*/
/*----------------------------------------------------Proveedor------------------------------------------------------------*/
DELIMITER $$
CREATE PROCEDURE InsertProveedor(
_nombre varchar(100), _descripcion varchar(300), _direccion varchar(1000), _telefono varchar(90), _mail varchar(1000),_idCateProve int, 
_fechaCreacion datetime, _creadoPor varchar(100), _fechaActualizacion datetime, _actualizadoPor varchar(100), _isActive int
)
BEGIN
INSERT INTO Proveedor (nombre, descripcion, direccion, telefono, mail, idCateProve, fechaCreacion, creadoPor, fechaActualizacion, actualizadoPor, isActive)
VALUES (_nombre, _descripcion, _direccion, _telefono, _mail, _idCateProve, _fechaCreacion, _creadoPor, _fechaActualizacion, _actualizadoPor, _isActive);
END $$
DELIMITER 

DELIMITER $$
CREATE PROCEDURE UpdateProveedor(
_id int, _nombre varchar(100), _descripcion varchar(300), _direccion varchar(1000), _telefono varchar(90), _mail varchar(1000),_idCateProve int, 
_fechaActualizacion datetime, _actualizadoPor varchar(100), _isActive int)
BEGIN
UPDATE Proveedor SET nombre = _nombre, 
					 descripcion = _descripcion, 
                     direccion = _direccion,
                     telefono = _telefono,
                     mail = _mail,
                     fechaActualizacion = _fechaActualizacion, 
                     actualizadoPor = _actualizadoPor,
                     isActive = _isActive
WHERE id = _id;
END $$
DELIMITER 

DELIMITER $$
CREATE PROCEDURE GetProveedor(
_id int
)
BEGIN
SELECT id, nombre, descripcion, direccion, telefono, mail, idCateProve, fechaCreacion, creadoPor, fechaActualizacion, actualizadoPor, isActive FROM Proveedor 
WHERE id = _id;
END $$
DELIMITER 

CREATE PROCEDURE GetProveedores
BEGIN
SELECT id, nombre, descripcion, direccion, telefono, mail, idCateProve, fechaCreacion, creadoPor, fechaActualizacion, actualizadoPor, isActive FROM Proveedor 
END $$
DELIMITER 
/*---------------------------------------------------------Proveedor------------------------------------------------------------*/
/*----------------------------------------------------Producto------------------------------------------------------------*/
DELIMITER $$
CREATE PROCEDURE InsertProducto(
_nombre varchar(100), _descripcion varchar(300), _precio float, _stock int, _idProve int,_idCateProd int, 
_fechaCreacion datetime, _creadoPor varchar(100), _fechaActualizacion datetime, _actualizadoPor varchar(100), _isActive int
)
BEGIN
INSERT INTO Producto (nombre, descripcion, precio, stock, idProve, idCateProd, fechaCreacion, creadoPor, fechaActualizacion, actualizadoPor, isActive)
VALUES (_nombre, _descripcion, _precio, _stock, _idProve, _idCateProd, _fechaCreacion, _creadoPor, _fechaActualizacion, _actualizadoPor, _isActive);
END $$
DELIMITER 

DELIMITER $$
CREATE PROCEDURE UpdateProducto(
_id int, _nombre varchar(100), _descripcion varchar(300), _precio float, _stock int, _idProve int,_idCateProd int, 
_fechaActualizacion datetime, _actualizadoPor varchar(100), _isActive int)
BEGIN
UPDATE Proveedor SET nombre = _nombre, 
					 descripcion = _descripcion, 
                     precio = _precio,
                     stock = _stock,
                     idProve = _idProve,
                     idCateProd = _idCateProd,
                     fechaActualizacion = _fechaActualizacion, 
                     actualizadoPor = _actualizadoPor,
                     isActive = _isActive
WHERE id = _id;
END $$
DELIMITER 

DELIMITER $$
CREATE PROCEDURE GetProducto(
_id int
)
BEGIN
SELECT id, nombre, descripcion, precio, stock, idProve, idCateProd, fechaCreacion, creadoPor, fechaActualizacion, actualizadoPor, isActive FROM Producto 
WHERE id = _id;
END $$
DELIMITER 

CREATE PROCEDURE GetProductos
BEGIN
SELECT id, nombre, descripcion, precio, stock, idProve, idCateProd, fechaCreacion, creadoPor, fechaActualizacion, actualizadoPor, isActive FROM Producto 
END $$
DELIMITER 
/*---------------------------------------------------------Producto------------------------------------------------------------*/
/*----------------------------------------------------Detalle Factura------------------------------------------------------------*/
DELIMITER $$
CREATE PROCEDURE InsertDetalleFactura(
_transaccion int, _idProducto int, _cantidad int, _fechaCreacion datetime, _creadoPor varchar(100), _fechaActualizacion datetime, 
_actualizadoPor varchar(100)
)
BEGIN
INSERT INTO DetalleFactura (transaccion, idProducto, cantidad, fechaCreacion, creadoPor, fechaActualizacion, actualizadoPor)
VALUES (_transaccion, _idProducto, _cantidad, _fechaCreacion, _creadoPor, _fechaActualizacion, _actualizadoPor);
END $$
DELIMITER 

DELIMITER $$
CREATE PROCEDURE UpdateDetalleFactura(
_id int, _transaccion int, _idProducto int, _cantidad int, _fechaActualizacion datetime, _actualizadoPor varchar(100))
BEGIN
UPDATE DetalleFactura SET transaccion = _transaccion, 
					 idProducto = _idProducto, 
                     cantidad = _cantidad,
                     fechaActualizacion = _fechaActualizacion, 
                     actualizadoPor = _actualizadoPor
WHERE id = _id;
END $$
DELIMITER 

DELIMITER $$
CREATE PROCEDURE GetDetalleFactura(
_id int
)
BEGIN
SELECT id, transaccion, idProducto, cantidad, fechaCreacion, creadoPor, fechaActualizacion, actualizadoPor FROM DetalleFactura
WHERE id = _id;
END $$
DELIMITER 

CREATE PROCEDURE GetDetallesFactura
BEGIN
SELECT SELECT id, transaccion, idProducto, cantidad, fechaCreacion, creadoPor, fechaActualizacion, actualizadoPor FROM DetalleFactura
END $$
DELIMITER 
/*---------------------------------------------------------Detalle Factura------------------------------------------------------------*/
/*-------------------------------------------------------------Factura---------------------------------------------------------------*/
DELIMITER $$
CREATE PROCEDURE InsertFactura(
_total float, _cliente varchar(100), _idDetaFact int, _tipoPago varchar(100), _fechaCreacion datetime, _creadoPor varchar(100), 
_fechaActualizacion datetime, _actualizadoPor varchar(100)
)
BEGIN
INSERT INTO Factura (total, cliente, idDetaFact, tipoPago, fechaCreacion, creadoPor, fechaActualizacion, actualizadoPor)
VALUES (_total, _cliente, _idDetaFact, _tipoPago, _fechaCreacion, _creadoPor, _fechaActualizacion, _actualizadoPor);
END $$
DELIMITER 

DELIMITER $$
CREATE PROCEDURE UpdateFactura(
_id int, _total float, _cliente varchar(100), _idDetaFact int, _tipoPago varchar(100), _fechaActualizacion datetime, _actualizadoPor varchar(100))
BEGIN
UPDATE Factura SET total = _total, 
					 cliente = _cliente, 
                     idDetaFact = _idDetaFact,
                     tipoPago = _tipoPago,
                     fechaActualizacion = _fechaActualizacion, 
                     actualizadoPor = _actualizadoPor
WHERE id = _id;
END $$
DELIMITER 

DELIMITER $$
CREATE PROCEDURE GetFactura(
_id int
)
BEGIN
SELECT id, total, cliente, idDetaFact, tipoPago, fechaCreacion, creadoPor, fechaActualizacion, actualizadoPor FROM Factura
WHERE id = _id;
END $$
DELIMITER 

CREATE PROCEDURE GetFacturas
BEGIN
SELECT id, total, cliente, idDetaFact, tipoPago, fechaCreacion, creadoPor, fechaActualizacion, actualizadoPor FROM Factura
END $$
DELIMITER 
/*-------------------------------------------------------------Factura----------------------------------------------------------------*/
/*-------------------------------------------------------------Usuarios---------------------------------------------------------------*/
DELIMITER $$
CREATE PROCEDURE InsertUsuario(
_nombre varchar(200), _username varchar(100), _password varchar(100), _isAdmin int, _isActive int, _fechaCreacion datetime, _creadoPor varchar(100), 
_fechaActualizacion datetime, _actualizadoPor varchar(100)
)
BEGIN
INSERT INTO Usuario (nombre, username, password, isAdmin, isActive, fechaCreacion, creadoPor, fechaActualizacion, actualizadoPor)
VALUES (_nombre, _username, _password, _isAdmin, _isActive, _fechaCreacion, _creadoPor, _fechaActualizacion, _actualizadoPor);
END $$
DELIMITER 

DELIMITER $$
CREATE PROCEDURE UpdateUsuario(
_id int, _nombre varchar(200), _username varchar(100), _password varchar(100), _isAdmin int, _isActive int, 
_fechaActualizacion datetime, _actualizadoPor varchar(100)
)
BEGIN
UPDATE Usuario SET nombre = _nombre, 
					 username = _username, 
                     password = _password,
                     isAdmin = _isAdmin,
                     isActive = _isActive,
                     fechaActualizacion = _fechaActualizacion, 
                     actualizadoPor = _actualizadoPor
WHERE id = _id;
END $$
DELIMITER 

DELIMITER $$
CREATE PROCEDURE GetUsuario(
_id int
)
BEGIN
SELECT id, nombre, username, password, isAdmin, isActive, fechaCreacion, creadoPor, fechaActualizacion, actualizadoPor FROM Usuario
WHERE id = _id;
END $$
DELIMITER 

CREATE PROCEDURE GetFacturas
BEGIN
SELECT id, nombre, username, password, isAdmin, isActive, fechaCreacion, creadoPor, fechaActualizacion, actualizadoPor FROM Usuario
END $$
DELIMITER 
/*-------------------------------------------------------------Usuarios----------------------------------------------------------------*/
/*CREATE PROCEDURES*/
