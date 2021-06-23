CREATE DATABASE MyJoinsDB
ON
(
	NAME = 'MyJoinsDB',			
	FILENAME = '/var/opt/mssql/test/MyJoinsDB.mdf',		
	SIZE = 5MB,                    
	MAXSIZE = 20MB,			
	FILEGROWTH = 5MB				
)
LOG ON						  
( 
	NAME = 'LogMyJoinsDB',				   
	FILENAME = '/var/opt/mssql/test/MyJoinsDB.ldf',     
	SIZE = 3MB,                      
	MAXSIZE = 30MB,                   
	FILEGROWTH = 3MB                  
)               
COLLATE Cyrillic_General_CI_AS 

USE MyJoinsDB
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

SELECT * FROM Employee
SELECT * FROM [Position]
SELECT * FROM Profile

--1) Получите контактные данные сотрудников (номера телефонов, место жительства)
SELECT E.Name, E.Phone, P.Adress
FROM 
Employee E INNER JOIN Profile P ON E.Id = P.EmployeeID

--2) Получите информацию о дате рождения всех холостых сотрудников и их номера.
SELECT E.Name, P.DoB, E.Phone
FROM
Employee E INNER JOIN Profile P ON E.Id = P.EmployeeID
WHERE P.MaritalStatus = 'Холост'

-- 3) Получите информацию обо всех менеджерах компании: дату рождения и номер телефона.
SELECT E.Name, PN.Post, P.DoB, E.Phone
FROM
Employee E INNER JOIN Profile P ON E.Id = P.EmployeeID
INNER JOiN [Position] PN ON PN.EmployeeID = E.Id
WHERE PN.Post = 'менеджер'

-- Урок 6 
-- Сделайте выборку при помощи вложенных запросов для таких задач: 

-- 1) Требуется узнать контактные данные сотрудников (номера телефонов, место жительства). 
SELECT Name, Phone, Adress FROM Employee AS E, Profile AS P
WHERE E.Id IN
            (SELECT EmployeeID FROM Profile
            WHERE E.Id = P.Id);

-- 2) Требуется узнать информацию о дате рождения всех не женатых сотрудников и номера телефонов 
-- этих сотрудников. 
SELECT NAME, DoB, MaritalStatus, Phone FROM Employee AS E, Profile AS P
WHERE E.Id IN
			(SELECT EmployeeID From Profile
			WHERE E.Id = P.Id
			AND P.MaritalStatus = 'холост');

-- 3) Требуется узнать информацию о дате рождения всех сотрудников с должностью менеджер и номера 
-- телефонов этих сотрудников.
SELECT NAME, DoB, Post, Phone FROM Employee AS E, Profile AS P, [Position] AS PS
WHERE E.Id IN
			(SELECT EmployeeID From Profile
			WHERE E.Id = P.Id
			AND E.Id = PS.Id
			AND PS.Post = 'менеджер');