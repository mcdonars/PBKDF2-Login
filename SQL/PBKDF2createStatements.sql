--Create database PBKDF2

USE [PBKDF2]
GO

CREATE TABLE Person(
UserID int IDENTITY (1,1) NOT NULL,
FirstName varchar(20) NOT NULL,
LastName varchar(30) NOT NULL,
Username varchar (20) NOT NULL,
PRIMARY KEY (UserID));

CREATE TABLE Pass(
UserID int FOREIGN KEY references Person(UserID) NOT NULL,
Username varchar(30) NOT NULL,
PasswordHash varchar(256) NOT NULL,
PRIMARY KEY (UserID));

GO
