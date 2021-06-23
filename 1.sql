
 
CREATE DATABASE MyFirstDB 
ON							  
(
	NAME = 'MyFirstDB',			
	FILENAME = '/var/opt/mssql/test/MyFirstDB.mdf',		
	SIZE = 5MB,                    
	MAXSIZE = 20MB,			
	FILEGROWTH = 5MB				
)
LOG ON						  
( 
	NAME = 'LogMyFirstDB',				   
	FILENAME = '/var/opt/mssql/test/MyFirstDB.ldf',     
	SIZE = 3MB,                      
	MAXSIZE = 30MB,                   
	FILEGROWTH = 3MB                  
)               
COLLATE Cyrillic_General_CI_AS 



CREATE DATABASE MyDB 
ON							  
(
	NAME = 'MyDB',				
	FILENAME = '/var/opt/mssql/test/MyDB.mdf',		
	SIZE = 10MB,                   
	MAXSIZE = 100MB,				
	FILEGROWTH = 10MB				
)
LOG ON						 
( 
	NAME = 'LogMyDB',				 
	FILENAME = '/var/opt/mssql/test/MyDB.ldf',       
	SIZE = 5MB,                       
	MAXSIZE = 50MB,                    
	FILEGROWTH = 5MB               
)               
COLLATE Cyrillic_General_CI_AS 

            


USE MyDB                
GO   



CREATE TABLE Worker
(
	WorkerId smallint IDENTITY NOT NULL,
	Name Varchar(20) NOT NULL,
	PhoneNumber char(10) NOT NULL
)
GO 

CREATE TABLE Salary
(
	SalaryId smallint IDENTITY NOT NULL,
	Salary Money NOT NULL,
	Post Varchar(20) NOT NULL
)
GO 

CREATE TABLE WorkerInfo
(
	InfoId smallint IDENTITY NOT NULL,
	MaritalStatus Varchar (20) NOT NULL, 
	BirthDate Date NULL,
	[Address] Varchar (30) NOT NULL
)
GO 
----------------------------------------------------------------------------------