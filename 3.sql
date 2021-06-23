/* Задание 2 
Создайте базу данных максимальной размерностью 100 МБ, предполагается что будет использоваться 
около 30 МБ. Введите все необходимые настройки. Журнал транзакций должен быть расположен на 
другом физическом диске (если такой имеется). 
Задание 3 
Спроектируйте базу данных для оптового склада, у которого есть поставщики товаров, персонал, 
постоянные заказчики. Поля таблиц продумать самостоятельно. */

CREATE DATABASE Base3
ON
(
	NAME = 'Base3',				
	FILENAME = '/var/opt/mssql/test/Base3.mdf',		
	SIZE = 30MB,                   
	MAXSIZE = 100MB,				
	FILEGROWTH = 10MB				
)
LOG ON						 
( 
	NAME = 'LogBase3',				 
	FILENAME = '/var/opt/mssql/test/Base3.ldf',       
	SIZE = 5MB,                       
	MAXSIZE = 50MB,                    
	FILEGROWTH = 5MB               
)
COLLATE Cyrillic_General_CI_AS 

USE Base3
GO

CREATE TABLE Supplier
(
	Id INT PRIMARY KEY IDENTITY,
	Name Varchar(30) NOT NULL,
    LastName Varchar(30) NULL,
	Phone decimal(10) NOT NULL,
)
GO

CREATE TABLE Product
(
	Id INT PRIMARY KEY IDENTITY,
	Name Varchar(30) NOT NULL,
	ProductNumber char(10) NOT NULL,
    Cost Money NOT NULL,
    Count decimal(6,1) NULL,
	FkSupplierId INT FOREIGN KEY REFERENCES Supplier(Id)
)
GO

CREATE TABLE Employee
(
    Id INT PRIMARY KEY IDENTITY,
    Name Varchar(30) NOT NULL,
    LastName Varchar(30) NOT NULL,
    Position VARCHAR(20) NOT NULL,
    Salary Money NOT NULL,
)
GO

CREATE TABLE Customer
(
    Id INT PRIMARY KEY IDENTITY,
    Name VARCHAR(30) NOT NULL,
    LastName VARCHar(30) NULL
)
GO

CREATE TABLE CustomerOrder
(
    Id INT PRIMARY KEY IDENTITY,
    CustomerId INT REFERENCES Customer (Id),
    FkProductId INT FOREIGN KEY REFERENCES Product(Id),
    ModifiedOn smalldatetime default GETDATE(),
    CreatedOn datetime default CURRENT_TIMESTAMP,
)
GO



-- Поставщики
INSERT INTO Supplier
(Name, LastName, Phone)
VALUES
('John', 'Doe', '069007805'),
('Max', 'Smith', '069007805'),
('Will', '', '069007805')
GO

-- Продукты
INSERT INTO Product
(Name, ProductNumber, Cost, Count, FkSupplierId)
VALUES
('Корона',   'AK-53818 ', '$5',  '50',  '1'),
('Милка',    'AM-51122 ', '$6.1', '50',  '2'),
('Аленка',   'AA-52211 ', '$2.5', '20',  '3'),
('Snickers', 'BS-32118',  '$2.8', '50',  '2'),
('Snickers', 'BSL-3818',  '$5',  '100', '2'),
('Bounty',   'BB-38218 ', '$3',  '100', '1'),
('Mars ',    'BM-3618 ',  '$2.5', '50',  '2'),
('Свиточ',   'AS-54181 ', '$5',  '100', '2'),
('Свиточ',   'AS-54182 ', '$5',  '100', '1');
GO

-- Работники
INSERT INTO Employee
(Name, LastName, Position, Salary)
VALUES
('James',   'McAlistor', 'Loader', '$2500'),
('Ellen',   'Ray', 'Logical', '$3500')
GO

-- Заказчики
INSERT INTO Customer
(Name, LastName)
VALUES
('Dean',   'Colson'),
('May',   'Kim')
GO
