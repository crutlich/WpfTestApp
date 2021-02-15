CREATE DATABASE SoftTradePlusDB  
ON							  
(
	NAME = 'SoftTradePlusDB',				
	FILENAME = 'D:\SoftTradePlusDB.mdf',		
	SIZE = 10MB,                    
	MAXSIZE = 100MB,				
	FILEGROWTH = 10MB				
)
LOG ON						  
( 
	NAME = 'LogSoftTradePlusDB',				   
	FILENAME = 'D:\SoftTradePlusDB.ldf',        
	SIZE = 5MB,                        
	MAXSIZE = 50MB,                    
	FILEGROWTH = 5MB                   
)               
COLLATE Cyrillic_General_CI_AS

USE SoftTradePlusDB

CREATE TABLE Manager
(
	Id_manager INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Name_manag NVARCHAR(20) NOT NULL

)
GO

CREATE TABLE Client_status
(
	Id_status INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Status_cl NVARCHAR(20) NOT NULL
)
GO

CREATE TABLE Product
(
	Id_prod INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Name_prod NVARCHAR(20) NOT NULL,
	Price NUMERIC(10,2) NOT NULL CHECK(Price >= 0),
	Type_prod NVARCHAR(30) NOT NULL,
	TimeLimit NVARCHAR(10) NULL

)

CREATE TABLE Client
(
	Id_cl INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Type_cl NVARCHAR(30) NOT NULL,
	Name_cl NVARCHAR(30) NOT NULL,
	Status_cl INT NOT NULL
		FOREIGN KEY REFERENCES Client_status(Id_status),
	Manager INT NOT NULL
		FOREIGN KEY REFERENCES Manager(Id_manager)
)

CREATE TABLE ClientsProducts
(
	Id_clpr INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Client INT NOT NULL
		FOREIGN KEY REFERENCES Client(Id_cl),
	Product INT NOT NULL
		FOREIGN KEY REFERENCES Product(Id_prod)
)