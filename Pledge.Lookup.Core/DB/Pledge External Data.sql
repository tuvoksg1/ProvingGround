CREATE DATABASE PledgeData;
GO

USE PledgeData
GO

IF NOT EXISTS (SELECT schema_name 
    FROM information_schema.schemata 
    WHERE schema_name = 'Core' )
BEGIN
    EXEC sp_executesql N'CREATE SCHEMA Core;';
END

CREATE TABLE [Core].[Lists](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[LastUpdated] [datetime] NOT NULL,
	[TableName] [nchar](300) NULL
) ON [PRIMARY]

GO

ALTER TABLE [Core].[Lists] ADD  CONSTRAINT [DF_ExternalDataList_LastUpdate]  DEFAULT (getutcdate()) FOR [LastUpdated]
GO

CREATE TABLE [Core].[Counties](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[LastUpdated] [datetime] NOT NULL
) ON [PRIMARY]

GO

ALTER TABLE [Core].[Counties] ADD  CONSTRAINT [DF_Dealers_LastUpdate]  DEFAULT (getutcdate()) FOR [LastUpdated]
GO

CREATE TABLE [Core].[Cities](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[LastUpdated] [datetime] NOT NULL
) ON [PRIMARY]

GO

ALTER TABLE [Core].[Cities] ADD  CONSTRAINT [DF_Cities_LastUpdate]  DEFAULT (getutcdate()) FOR [LastUpdated]
GO

CREATE TABLE [Core].[CarManufacturers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[LastUpdated] [datetime] NOT NULL
) ON [PRIMARY]

GO

ALTER TABLE [Core].[CarManufacturers] ADD  CONSTRAINT [DF_CarManufacturers_LastUpdate]  DEFAULT (getutcdate()) FOR [LastUpdated]
GO
------------------------------------------

CREATE PROCEDURE [Core].[ExternalListGet]
@listName nvarchar(128) = NULL

AS

BEGIN 
	DECLARE @TableName nvarchar(1000)
	SET @TableName = (SELECT TableName FROM [Core].[Lists] WHERE NAME = @listname)

	DECLARE @query NVARCHAR(MAX);
		SET @query = 'SELECT Name FROM '+ @TableName 		
	EXECUTE sp_executesql @query
END
GO

-----------------------------------------

CREATE PROCEDURE [Core].[ExternalListsGet]

AS

SELECT [Name] FROM [Core].[Lists]
GO
--------------------------------------------------------------
INSERT INTO [Core].[CarManufacturers] ([Name]) VALUES('Volvo')
INSERT INTO [Core].[CarManufacturers] ([Name]) VALUES('Ford')
INSERT INTO [Core].[CarManufacturers] ([Name]) VALUES('Fiat')
INSERT INTO [Core].[CarManufacturers] ([Name]) VALUES('Saab')
INSERT INTO [Core].[CarManufacturers] ([Name]) VALUES('Vauxhal')
INSERT INTO [Core].[CarManufacturers] ([Name]) VALUES('Mercedes')
GO

INSERT INTO [Core].[Cities] ([Name]) VALUES('Tokyo')
INSERT INTO [Core].[Cities] ([Name]) VALUES('Berlin')
INSERT INTO [Core].[Cities] ([Name]) VALUES('New York')
INSERT INTO [Core].[Cities] ([Name]) VALUES('Dubai')
INSERT INTO [Core].[Cities] ([Name]) VALUES('Rome')
INSERT INTO [Core].[Cities] ([Name]) VALUES('Paris')
INSERT INTO [Core].[Cities] ([Name]) VALUES('Barcelona')
GO

INSERT INTO [Core].[Counties] ([Name]) VALUES('Sussex')
INSERT INTO [Core].[Counties] ([Name]) VALUES('Berkshire')
INSERT INTO [Core].[Counties] ([Name]) VALUES('Buckinghamshire')
INSERT INTO [Core].[Counties] ([Name]) VALUES('Hertfordshire')
INSERT INTO [Core].[Counties] ([Name]) VALUES('Kent')
INSERT INTO [Core].[Counties] ([Name]) VALUES('Essex')
INSERT INTO [Core].[Counties] ([Name]) VALUES('Surrey')
GO


INSERT INTO [Core].[Lists] ([Name], [TableName]) VALUES ('Cities', 'Core.Cities')
INSERT INTO [Core].[Lists] ([Name], [TableName]) VALUES ('Counties', 'Core.Cities')
INSERT INTO [Core].[Lists] ([Name], [TableName]) VALUES ('Manufacturers', 'Core.CarManufacturers')
GO
