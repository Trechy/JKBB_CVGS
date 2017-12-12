/*
DROP TABLE [dbo].[[OwnGame]]
DROP TABLE [dbo].[Cart]
DROP TABLE [dbo].[Wishlist]
DROP TABLE [dbo].[Register]
DROP TABLE [dbo].[User]
DROP TABLE [dbo].[Event]
DROP TABLE [dbo].[Game]
*/

CREATE TABLE [dbo].[User]
(
    [Email] VARCHAR(50) NOT NULL, 
    [Password] VARCHAR(25) NOT NULL, 
	[Role]    VARCHAR(25) NOT NULL, 
    [FirstName] VARCHAR(25) NOT NULL, 
    [LastName] VARCHAR(25) NOT NULL,
	[Gender]      VARCHAR (1),
    [DateOfBirth] DATE,
    [Address]     VARCHAR (50),
    [City]        VARCHAR (25),
    [Province]    VARCHAR (25),
    [PostalCode]  VARCHAR (6),
    [PhoneNumber] VARCHAR (10),
	PRIMARY KEY ([Email])
)
GO
INSERT INTO [dbo].[User]
	([Email],[Password],[Role],[FirstName],[LastName],[Gender],[DateOfBirth],[Address],[City],[Province],[PostalCode],[PhoneNumber])
VALUES
	('member@test.com', 'password', 'Member','testFirstName','testLastName','F', convert(date,'19971006'), '11 hello street', 'Kitchener', 'ON', 'N1N2N3','5191234567'),
	('employee@test.com', 'password', 'Employee','testFirstName','testLastName','F', convert(date,'19971006'), '11 hello street', 'Kitchener', 'ON', 'N1N2N3','5191234567');;
GO
SELECT * FROM [dbo].[User];
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


CREATE TABLE [dbo].[Wishlist] (
    [WishlistID]		INT         NOT NULL IDENTITY,
    [Email] VARCHAR(50)			NOT NULL,
    [GameID]			INT			NOT NULL,
    [AddDate]			DATETIME        NOT NULL,
    PRIMARY KEY ([WishlistID]),
	FOREIGN KEY ([Email]) REFERENCES [dbo].[User]([Email]),
	FOREIGN KEY ([GameID]) REFERENCES [dbo].[Game]([GameID])
);
GO
INSERT INTO [dbo].[Wishlist]
	([Email],[GameID],[AddDate])
VALUES
	('member@test.com', 1, convert(datetime,'20171006 10:34:09 PM'));
GO
SELECT * FROM [dbo].[Wishlist];
GO

CREATE TABLE [dbo].[Register] (
    [Email] VARCHAR(50)			NOT NULL,
    [EventID]			INT			NOT NULL,
	FOREIGN KEY ([Email]) REFERENCES [dbo].[User]([Email]),
	FOREIGN KEY ([EventID]) REFERENCES [dbo].[Event]([EventID])
);
GO
INSERT INTO [dbo].[Register]
	([Email],[EventID])
VALUES
	('member@test.com', 1);
GO
SELECT * FROM [dbo].[Register];
GO


CREATE TABLE [dbo].[Cart] (
    [CartID]		INT         NOT NULL IDENTITY,
    [Email] VARCHAR(50)		NOT NULL,
    [GameID]			INT			NOT NULL,
    [Quantity]			INT        NOT NULL,
    PRIMARY KEY ([CartID]),
	FOREIGN KEY ([Email]) REFERENCES [dbo].[User]([Email]),
	FOREIGN KEY ([GameID]) REFERENCES [dbo].[Game]([GameID])
);
GO
INSERT INTO [dbo].[Cart]
	([Email],[GameID],[Quantity])
VALUES
	('member@test.com', 1, 2);
GO
SELECT * FROM [dbo].[Cart];
GO

CREATE TABLE [dbo].[OwnGame] (
    [OwnGameID]		INT         NOT NULL IDENTITY,
    [Email] VARCHAR(50)		NOT NULL,
    [GameID]			INT			NOT NULL,
    PRIMARY KEY ([OwnGameID]),
	FOREIGN KEY ([Email]) REFERENCES [dbo].[User]([Email]),
	FOREIGN KEY ([GameID]) REFERENCES [dbo].[Game]([GameID])
);
GO
INSERT INTO [dbo].[OwnGame]
	([Email],[GameID])
VALUES
	('member@test.com', 1);
GO
SELECT * FROM [dbo].[OwnGame];
GO