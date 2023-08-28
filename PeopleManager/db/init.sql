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
GO

CREATE PROC GetJobs
AS
SELECT * FROM Job
GO

CREATE PROC GetPeople
AS
SELECT * FROM Person
GO

CREATE PROC GetJob
	@idJob int
AS
SELECT * FROM Job WHERE IDJob = @idJob
GO

CREATE PROC GetPerson
	@idPerson int
AS
SELECT * FROM Person WHERE IDPerson = @idPerson
GO

CREATE PROC DeleteJob
	@idJob int
AS
DELETE FROM Job WHERE IDJob = @idJob
GO

CREATE PROC DeletePerson
	@idPerson int
AS
DELETE FROM Person WHERE IDPerson = @idPerson
GO

CREATE PROC AddJob
	@name nvarchar(20),
	@idJob INT OUTPUT
AS 
BEGIN
INSERT INTO Job VALUES (@name)
	SET @idJob = SCOPE_IDENTITY()
END
GO

CREATE PROC AddPerson
	@firstname nvarchar(20),
	@lastname nvarchar(20),
	@age int,
	@email nvarchar(30),
	@picture varbinary(max),
	@jobID int,
	@idPerson INT OUTPUT
AS 
BEGIN
INSERT INTO Person VALUES (@firstname, @lastname, @age, @email, @picture, @jobID)
	SET @idPerson = SCOPE_IDENTITY()
END
GO

CREATE PROC UpdateJob
	@name nvarchar(20),
	@idJob int
AS
UPDATE Job SET 
		[Name] = @name
	WHERE 
		IDJob = @idJob
GO

CREATE PROC UpdatePerson
	@firstname nvarchar(20),
	@lastname nvarchar(20),
	@age int,
	@email nvarchar(30),
	@picture varbinary(max),
	@jobID int,
	@idPerson int
AS
UPDATE Person SET 
		FirstName = @firstname,
		LastName = @lastname,
		Age = @age,
		Email = @email,
		Picture = @picture,
		JobID = @jobID
	WHERE 
		IDPerson = @idPerson
GO