-- Задание 2 
-- Создать базу данных максимальной размерностью 100 МБ, предполагается что будет использоваться 
-- около 30 МБ. Введите все необходимые настройки. Журнал транзакций должен быть расположен на 
-- другом физическом диске (если есть). 
-- Задание 3 
-- Нормализируйте данную таблицу: 
-- ФИО Взвод Оружие Оружие выдал 
-- Петров В.А.,оф.205 222 АК-47 Буров О.С., майор 
-- Петров В.А.,оф.205 222 Глок20 Рыбаков Н.Г., майор 
-- Лодарев П.С.,оф.221 232 АК-74 Деребанов В.Я., подполковник 
-- Лодарев П.С.,оф.221 232 Глок20 Рыбаков Н.Г., майор 
-- Леонтьев К.В., оф.201 212 АК-47 Буров О.С., майор 
-- Леонтьев К.В., оф.201 212 Глок20 Рыбаков Н.Г., майор 
-- Духов Р.М. 200 АК-47 Буров О.С., майор

CREATE DATABASE Military 
ON							  
(
	NAME = 'MilitaryDB',			
	FILENAME = '/var/opt/mssql/test/MilitaryDB.mdf',		
	SIZE = 30MB,                    
	MAXSIZE = 100MB,			
	FILEGROWTH = 5MB				
)
LOG ON						  
( 
	NAME = 'LogMilitaryDB',				   
	FILENAME = '/var/opt/mssql/test/MilitaryDB.ldf',     
	SIZE = 3MB,                      
	MAXSIZE = 30MB,                   
	FILEGROWTH = 3MB                  
)               
COLLATE Cyrillic_General_CI_AS 

USE Military
GO

CREATE TABLE Soldier
(
	Id int PRIMARY KEY IDENTITY NOT NULL,
	Name VARCHAR(30) NOT NULL,
	[Officer] VARCHAR(25) NULL,
	Platoon INT NOT NULL
)
GO

CREATE TABLE WeaponProvider
(
	Id int PRIMARY KEY IDENTITY NOT NULL,
	Name VARCHAR(30) NOT NULL,
	[Rank] VARCHAR(25) NOT NULL
)
GO

CREATE TABLE Weapon
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Name VARCHAR (25)
)
GO

CREATE TABLE WeaponPact
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	SoldierID INT NOT NULL FOREIGN KEY REFERENCES Soldier(Id),
	WeaponProviderID INT NOT NULL FOREIGN KEY REFERENCES WeaponProvider(Id),
	WeaponID INT NOT NULL FOREIGN KEY REFERENCES Weapon(Id),
)
GO

INSERT INTO Soldier
VALUES
('Петров В.А.', 205, 222), 
('Лодарев П.С.' , 221, 232),
('Леонтьев К.В.', 201, 212),
('Духов Р.М', NULL, 200)
GO

INSERT INTO Weapon
VALUES
('АК-47'),
('Глок20'),
('АК-74')
GO

INSERT INTO WeaponProvider
VALUES
('Буров О.С.', 'майор'),
('Рыбаков Н.Г.', 'майор'),
('Деребанов В.Я.', 'подполковник')	
GO

INSERT INTO WeaponPact
VALUES
(1,1,1),
(1,2,2),
(2,3,3),
(2,2,2),
(3,1,1),
(3,2,2),
(4,1,1)
GO

SELECT * FROM Soldier
SELECT * FROM WeaponProvider
SELECT * FROM Weapon
SELECT * FROM WeaponPact 

SELECT S.Name, S.[Officer], S.Platoon,
W.Name, WP.Name, WP.[Rank]
FROM 
Soldier S INNER JOIN WeaponPact WPT ON S.Id = WPT.SoldierID
INNER JOIN WeaponProvider WP ON WP.Id = WPT.WeaponProviderID
INNER JOIN Weapon W ON W.ID = WPT.WeaponID
