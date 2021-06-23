-- Задание 2 
-- Создать базу данных с именем “MyFunkDB. 
-- Задание 3 
-- В данной базе данных создать 3 таблиц, 
-- В 1-й содержатся имена и номера телефонов сотрудников некой компании 
-- Во 2-й Ведомости об их зарплате, и должностях: главный директор, менеджер, рабочий. 
-- В 3-й семейном положении, дате рождения, где они проживают. 

CREATE DATABASE MyFunkDB
ON
(
	NAME = 'MyFunkDB',			
	FILENAME = '/var/opt/mssql/test/MyFunkDB.mdf',		
	SIZE = 5MB,                    
	MAXSIZE = 20MB,			
	FILEGROWTH = 5MB				
)
LOG ON						  
( 
	NAME = 'LogMyFunkDB',				   
	FILENAME = '/var/opt/mssql/test/MyFunkDB.ldf',     
	SIZE = 3MB,                      
	MAXSIZE = 30MB,                   
	FILEGROWTH = 3MB                  
)               
COLLATE Cyrillic_General_CI_AS 

USE MyFunkDB
GO

CREATE TABLE Employee
(
    Id INT PRIMARY KEY IDENTITY NOT NULL,
    Name VARCHAR(25) NOT NULL,
    Phone VARCHAR(15) NOT NULL,

)
GO

CREATE TABLE [Position]
(
    Id INT PRIMARY KEY IDENTITY NOT NULL,
    Post VARCHAR(25) NOT NULL,
    Salary MONEY NOT NULL,
    EmployeeID int NOT NULL FOREIGN KEY REFERENCES Employee(Id)
)

CREATE TABLE Profile
(
    Id INT PRIMARY Key IDENTITY NOT NULL,
    MaritalStatus VARCHAR(25) NULL,
    DoB DATE NOT NULL,
    Adress VARCHAR(45) NOT NULL,
    EmployeeID int NOT NULL FOREIGN KEY REFERENCES Employee(Id)
)

INSERT INTO Employee
VALUES
('Александр Порохов', '(0555)658598'),
('Валентина Петрова', '(0655)348598'),
('Алексей Ким', '(0655)231321'),
('Юрий Иванов', '(0655)545455'),
('Мария Бондоренко', '(0700)655845')
GO

INSERT INTO [Position]
VALUES
('главный директор','$1500', 1),
('менеджер','$500', 2),
('рабочий','$400', 3),
('менеджер','$500', 4),
('рабочий','$400', 5)
GO

INSERT INTO Profile
VALUES
('Холост', '08/25/93', 'Москва', 1),
('Замужем', '08/25/93', 'Прага', 2),
('Женат', '08/25/93', 'Киев', 3),
('Женат', '08/25/93', 'Москва', 4),
('Холост', '08/25/93', 'Минск', 5)
GO

-- Задание 4 
-- Создайте функции / процедуры для таких заданий: 



-- 1) Требуется узнать контактные данные сотрудников (номера телефонов, место жительства). 
CREATE PROC plEmployee
AS
SELECT  Name, Phone, Locations FROM 
Employees INNER JOIN InfoEmployees ON Employees.Id = Profile.EmployeeID -- Условие объединения при котором значения в сравниваемых ячейках должны совпадать. 
GO 

-- 2) Требуется узнать информацию о дате рождения всех не женатых сотрудников и номера 
-- телефонов этих сотрудников. 
CREATE PROC FreeEmployee
AS
SELECT E.Name, P.DoB, E.Phone
FROM
Employee E INNER JOIN Profile P ON E.Id = P.EmployeeID
WHERE P.MaritalStatus = 'Холост'
GO

-- 3) Требуется узнать информацию о дате рождения всех сотрудников с должностью менеджер и 
-- номера телефонов этих сотрудников.
CREATE PROC GetManagers
AS
SELECT E.Name, PN.Post, P.DoB, E.Phone
FROM
Employee E INNER JOIN Profile P ON E.Id = P.EmployeeID
INNER JOiN [Position] PN ON PN.EmployeeID = E.Id
WHERE PN.Post = 'менеджер'
GO
