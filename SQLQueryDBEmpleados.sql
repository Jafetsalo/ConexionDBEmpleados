Create database DBEmpleados
go
use DBEmpleados
go

Create table Empleados (
IDEmpleado int identity(111,111),
Apellido varchar(50) Not Null,
Nombre varchar(50) Not Null,
Direccion varchar(100) Not Null,
Email varchar(50) Not Null,
Constraint PK_1 Primary Key (IDEmpleado)
)

INSERT INTO Empleados VALUES
('Vélez', 'Jaime','Cra 1 #1-1','vj@gmail.com'),
('Roldan', 'Eliecer','Cra 2 #1-1','re@gmail.com'),
('Perez', 'Diego','Cra 3 #1-1','pd@gmail.com'),
('Ochoa', 'Leo','Cra 5 #1-1','ol@gmail.com'),
('Roa', 'Ana','Cra 6 #1-1','ra@gmail.com');

Select * from Empleados

