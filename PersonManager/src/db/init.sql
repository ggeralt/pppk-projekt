CREATE DATABASE NewPeopleManager
GO
USE NewPeopleManager
GO
CREATE TABLE Job
(
	IDJob int CONSTRAINT PK_Job PRIMARY KEY IDENTITY,
	Name nvarchar(20) NOT NULL
)
GO
CREATE TABLE Person
(
	IDPerson int CONSTRAINT PK_Person PRIMARY KEY IDENTITY,
	FirstName nvarchar(20) NOT NULL,
	LastName nvarchar(20) NOT NULL,
	Age int NOT NULL,
	Email nvarchar(30) NOT NULL,
	Picture varbinary(max) NULL,
	JobID int CONSTRAINT FK_Person_Job FOREIGN KEY REFERENCES Job(IDJob) NULL
)