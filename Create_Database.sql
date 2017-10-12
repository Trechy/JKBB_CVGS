/*
DROP TABLE [dbo].[Employee]
DROP TABLE [dbo].[Event]
DROP TABLE [dbo].[Game]
DROP TABLE [dbo].[Member]
*/

CREATE TABLE [dbo].[Employee]
(
	[EmployeeID] INT NOT NULL IDENTITY , 
    [Email] VARCHAR(50) NOT NULL UNIQUE, 
    [Password] NCHAR(25) NOT NULL, 
    [FirstName] VARCHAR(25) NOT NULL, 
    [LastName] VARCHAR(25) NOT NULL,
	PRIMARY KEY ([EmployeeID])
)
GO
INSERT INTO [dbo].[Employee]
	([Email],[Password],[FirstName],[LastName])
VALUES
	('employee@test.com','password','testFirstName','testLastName');
GO
SELECT * FROM [dbo].[Employee];
GO


CREATE TABLE [dbo].[Event] (
    [EventID]     INT           NOT NULL IDENTITY,
    [EventName]   VARCHAR (25)  NOT NULL,
    [EventDate]   DATETIME      NOT NULL,
    [Description] VARCHAR (MAX) NOT NULL,
    PRIMARY KEY ([EventID])
);
GO
INSERT INTO [dbo].[Event]
	([EventName], [EventDate], [Description])
VALUES
	('testEvent', convert(datetime,'20171006 10:34:09 PM'), 'This is a test event');
GO
SELECT * FROM [dbo].[Event];
GO


CREATE TABLE [dbo].[Game] (
    [GameID]       INT            NOT NULL IDENTITY,
    [Title]        VARCHAR (25)   NOT NULL,
    [Developer]    VARCHAR (25)   NOT NULL,
    [Publisher]    VARCHAR (25)   NOT NULL,
    [ReleasedDate] DATE           NOT NULL,
    [BasePrice]    DECIMAL (5, 2) NOT NULL,
    [Discount]     FLOAT (53)     NOT NULL,
    PRIMARY KEY ([GameID])
);
GO
INSERT INTO [dbo].[Game]
	([Title],[Developer],[Publisher],[ReleasedDate],[BasePrice],[Discount])
VALUES
	('testGame', 'testDeveloper', 'testPublisher', convert(datetime,'20171006 10:34:09 PM'), 100.00, 0.10);
GO
SELECT * FROM [dbo].[Game];
GO

CREATE TABLE [dbo].[Member] (
    [MemberID]    INT          NOT NULL IDENTITY,
	[UserName] NCHAR (25) NOT NULL,
    [Email] VARCHAR(50) NOT NULL UNIQUE, 
    [Password] NCHAR(25) NOT NULL, 
    [FirstName] VARCHAR(25) NOT NULL, 
    [LastName] VARCHAR(25) NOT NULL,
    [Gender]      VARCHAR (1),
    [DateOfBirth] DATE,
    [Address]     VARCHAR (50),
    [City]        VARCHAR (25),
    [Province]    VARCHAR (25),
    [PostalCode]  VARCHAR (6),
    [phoneNumber] VARCHAR (10),
    PRIMARY KEY ([MemberID])
);
GO
INSERT INTO [dbo].[Member]
	([UserName],[Email],[Password],[FirstName],[LastName],[Gender],[DateOfBirth],[Address],[City],[Province],[PostalCode],[phoneNumber])
VALUES
	('testUser','user@test.com', 'password', 'testFirstName','testLastName','F', convert(date,'19971006'), '11 hello street', 'Kitchener', 'ON', 'N1N2N3','5191234567');
GO
SELECT * FROM [dbo].[Member];
GO
