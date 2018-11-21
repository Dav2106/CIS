CREATE DATABASE CIS;
USE CIS;

CREATE TABLE CategoriaProveedor(
id int primary key auto_increment not null,
nombre varchar(100) not null,
descripcion varchar(300) null,
fechaCreacion datetime not null,
creadoPor varchar(100) not null,
fechaActualizacion datetime not null,
actualizadoPor varchar(100) not null
);

CREATE TABLE CategoriaProducto(
id int primary key auto_increment not null,
nombre varchar(100) not null,
descripcion varchar(300) null,
fechaCreacion datetime not null,
creadoPor varchar(100) not null,
fechaActualizacion datetime not null,
actualizadoPor varchar(100) not null
);

CREATE TABLE Proveedor(
id int primary key auto_increment not null,
nombre varchar(100) not null,
descripcion varchar(300) null,
idCateProve int not null,
fechaCreacion datetime not null,
creadoPor varchar(100) not null,
fechaActualizacion datetime not null,
actualizadoPor varchar(100) not null,
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
foreign key (idProve) references Proveedor (id),
foreign key (idCateProd) references CategoriaProducto (id)
);

CREATE TABLE DetalleFactura(
id int primary key auto_increment not null,
transaccion int not null,
idProducto int null,
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
fechaCreacion datetime not null,
creadoPor varchar(100) not null,
fechaActualizacion datetime not null,
actualizadoPor varchar(100) not null,
foreign key (idDetaFact) references DetalleFactura (id)
);

CREATE TABLE Usuarios(
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