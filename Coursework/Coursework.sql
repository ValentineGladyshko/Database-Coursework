-- Create Database and Tables:

USE [master]
CREATE DATABASE [Coursework]
GO

USE [Coursework]
GO

CREATE TABLE [AlpinistBases] (
	[AlpinistBaseID] INT IDENTITY(1,1) NOT NULL,
    [Country] NVARCHAR(255) NOT NULL,
	[Address] NVARCHAR(255) NOT NULL,
    CONSTRAINT PK_AlpinistBaseID PRIMARY KEY CLUSTERED ([AlpinistBaseID]))
GO

CREATE TABLE [Alpinists] (
	[AlpinistID] INT IDENTITY(1,1) NOT NULL,
    [FirstName] NVARCHAR(255) NOT NULL,
    [LastName] NVARCHAR(255) NOT NULL,
    [Phone] NVARCHAR(255), 
    CONSTRAINT PK_AlpinistID PRIMARY KEY CLUSTERED ([AlpinistID]))
GO

CREATE TABLE [AlpinistsList] (
	[AlpinistsListID] INT IDENTITY(1,1) NOT NULL,
	[AlpinistID] INT NOT NULL,
	[AlpinistBaseID] INT NOT NULL,
    CONSTRAINT PK_AlpinistsListID PRIMARY KEY CLUSTERED ([AlpinistsListID]),
	CONSTRAINT FK_BaseAlpinistID FOREIGN KEY([AlpinistID]) REFERENCES[Alpinists]([AlpinistID]),
	CONSTRAINT FK_AlpinistBaseID FOREIGN KEY([AlpinistBaseID]) REFERENCES[AlpinistBases]([AlpinistBaseID]))
GO

CREATE TABLE [HouseTypes] (
	[HouseTypeID] INT IDENTITY(1,1) NOT NULL,
    [Name] NVARCHAR(255) NOT NULL,
	[Price] INT NOT NULL,
    CONSTRAINT PK_HouseTypeID PRIMARY KEY CLUSTERED ([HouseTypeID]))
GO

CREATE TABLE [Houses] (
	[HouseID] INT IDENTITY(1,1) NOT NULL,
    [Name] NVARCHAR(255) NOT NULL,
	[HouseTypeID] INT NOT NULL,
	[AlpinistBaseID] INT NOT NULL,
	CONSTRAINT PK_HouseID PRIMARY KEY CLUSTERED ([HouseID]),
	CONSTRAINT FK_HouseTypeID FOREIGN KEY([HouseTypeID]) REFERENCES[HouseTypes]([HouseTypeID]),
	CONSTRAINT FK_AlpinistBaseHouseID FOREIGN KEY([AlpinistBaseID]) REFERENCES[AlpinistBases]([AlpinistBaseID]))
GO

CREATE TABLE [FoodTypes] (
	[FoodTypeID] INT IDENTITY(1,1) NOT NULL,
    [Name] NVARCHAR(255) NOT NULL,
	[Price] INT NOT NULL,
    CONSTRAINT PK_FoodTypeID PRIMARY KEY CLUSTERED ([FoodTypeID]))
GO

CREATE TABLE [HouseOrders] (
	[HouseOrderID] INT IDENTITY(1,1) NOT NULL,
    [AlpinistID] INT NOT NULL,
	[HouseID] INT NOT NULL,
	[DateStart] DATE NOT NULL,
	[DateEnd] DATE NOT NULL,
    CONSTRAINT PK_HouseOrderID PRIMARY KEY CLUSTERED ([HouseOrderID]),
	CONSTRAINT FK_HouseAlpinist1ID FOREIGN KEY([AlpinistID]) REFERENCES[Alpinists]([AlpinistID]),
	CONSTRAINT FK_House1ID FOREIGN KEY([HouseID]) REFERENCES[Houses]([HouseID]))
GO

CREATE TABLE [FoodOrders] (
	[FoodOrderID] INT IDENTITY(1,1) NOT NULL,
    [AlpinistID] INT NOT NULL,
	[FoodTypeID] INT NOT NULL,
	[Date] DATE NOT NULL,
    CONSTRAINT PK_FoodOrderID PRIMARY KEY CLUSTERED ([FoodOrderID]),
	CONSTRAINT FK_FoodAlpinistID FOREIGN KEY([AlpinistID]) REFERENCES[Alpinists]([AlpinistID]),
	CONSTRAINT FK_FoodTypeID FOREIGN KEY([FoodTypeID]) REFERENCES[FoodTypes]([FoodTypeID]))
GO

CREATE TABLE [Routes] (
	[RouteID] INT IDENTITY(1,1) NOT NULL,
	[Name] NVARCHAR(255) NOT NULL,
	[AlpinistBaseID] INT NOT NULL
	CONSTRAINT PK_RouteID PRIMARY KEY CLUSTERED ([RouteID]),
	CONSTRAINT FK_AlpinistBaseRouteID FOREIGN KEY([AlpinistBaseID]) REFERENCES[AlpinistBases]([AlpinistBaseID]))
GO

CREATE TABLE [RouteStates] (
	[RouteStateID] INT IDENTITY(1,1) NOT NULL,
	[State] NVARCHAR(255) NOT NULL,
	[RouteID] INT NOT NULL,
	[DateStart] DATE NOT NULL,
	[DateEnd] DATE,
	CONSTRAINT PK_RouteStateID PRIMARY KEY CLUSTERED ([RouteStateID]),
	CONSTRAINT FK_StateRouteID FOREIGN KEY([RouteID]) REFERENCES[Routes]([RouteID]))
GO

CREATE TABLE [Walks] (
	[WalkID] INT IDENTITY(1,1) NOT NULL,
	[AlpinistID] INT NOT NULL,
	[RouteID] INT NOT NULL,
	[DateStart] DATE NOT NULL,
	[DateEnd] DATE NOT NULL,
	CONSTRAINT PK_WalkID PRIMARY KEY CLUSTERED ([WalkID]),
	CONSTRAINT FK_WalkAlpinistID FOREIGN KEY([AlpinistID]) REFERENCES[Alpinists]([AlpinistID]),
	CONSTRAINT FK_RouteID FOREIGN KEY([RouteID]) REFERENCES[Routes]([RouteID]))
GO

CREATE TRIGGER [MyTrigger1] ON [HouseOrders]
INSTEAD OF INSERT
AS
BEGIN
	INSERT INTO [HouseOrders] ([AlpinistID], [HouseID], [DateStart], [DateEnd])
	SELECT [I].[AlpinistID], [I].[HouseID], [DateStart], [DateEnd] FROM [inserted] AS [I]
	JOIN [AlpinistsList] AS [AL]
		ON [I].[AlpinistID] = [AL].[AlpinistID]
	JOIN [Houses] AS [H]
		ON [I].[HouseID] = [H].[HouseID]
	WHERE [H].[AlpinistBaseID] = [AL].[AlpinistBaseID];
END;
GO

CREATE TRIGGER [MyTrigger2] ON [Walks]
INSTEAD OF INSERT
AS
BEGIN
	INSERT INTO [Walks] ([AlpinistID], [RouteID], [DateStart], [DateEnd])
	SELECT [I].[AlpinistID], [I].[RouteID], [DateStart], [DateEnd] FROM [inserted] AS [I]
	JOIN [AlpinistsList] AS [AL]
		ON [I].[AlpinistID] = [AL].[AlpinistID]
	JOIN [Routes] AS [R]
		ON [I].[RouteID] = [R].[RouteID]
	WHERE [R].[AlpinistBaseID] = [AL].[AlpinistBaseID];
END;
GO

-- Add data to tables

INSERT INTO [AlpinistBases] ([Country], [Address])
VALUES
	('�����', '������'),
	('����', '������'),
	('����������', '������')    
GO

INSERT INTO [HouseTypes] ([Name], [Price])
VALUES 
	('�����', 100),
	('�������', 300)
GO

INSERT INTO [Houses] ([Name], [HouseTypeID], [AlpinistBaseID])
VALUES
	('�������1', 2, 1),
	('�����1', 1, 1),
	('�������2', 2, 2),
	('�����2', 1, 2),
	('�������3', 2, 3),
	('�����3', 1, 3),
	('�������4', 2, 1),
	('�����4', 1, 3),
	('�������5', 2, 2),
	('�����5', 1, 3)
GO

INSERT INTO [FoodTypes] ([Name], [Price])
VALUES
	('�������', 100),
	('���', 200),
	('������', 150)
GO

INSERT INTO [Routes] ([Name], [AlpinistBaseID])
VALUES 
	('�������� ���������� ������', 1),
	('����������� ����', 1),
	('���� �����', 1),
	('���� �������', 2),
	('�������� ����', 2),
	('���� ����� � �������� �����', 2),
	('���� ����-����', 3),
	('���� �����', 3),
	('ϳ� ���-�����', 3)
	
GO

INSERT INTO [RouteStates] ([State], [RouteID], [DateStart], [DateEnd])
VALUES 
	('��������', 1, '2015-01-08', '2016-09-23'),
	('�������', 1, '2016-09-23', null),
	('����������', 2, '2015-11-13', null),
	('�������', 3, '2015-04-09', null),
	('³������', 4, '2015-08-04', null),
	('�������', 5, '2015-09-15', null),
	('����������', 6, '2015-06-16', null),
	('�������', 7, '2015-07-27', null),
	('³������', 8, '2015-01-01', null),
	('�������', 9, '2015-10-10', null),
	('����������', 9, '2012-05-09', '2015-10-10'),
	('�������', 6, '2009-05-17', '2015-06-16'),
	('³������', 3, '2007-08-13', '2015-04-09')
GO

-------------------------------------------

-- Write 5 queries

-- ����� 1:
-- ������� ��� �������� �� ����������� �� 
-- ��������� ��� � ��� �� ��������
-- � ������� � 2010-09-23 �� 2017-09-28

SELECT DISTINCT
	[FirstName],
	[LastName],
	[Country],
	[HT].[Name],
	[DateStart],
	[DateEnd]
FROM [Alpinists] AS [A]
JOIN [AlpinistsList] AS [AL]
	ON [A].[AlpinistID] = [AL].[AlpinistID]
JOIN [AlpinistBases] AS [AB]
	ON [AL].[AlpinistBaseID] = [AB].[AlpinistBaseID]
JOIN [HouseOrders] AS [HO]
	ON [A].[AlpinistID] = [HO].[AlpinistID]
JOIN [Houses] AS [H]
	ON [HO].[HouseID] = [H].[HouseID]
JOIN [HouseTypes] AS [HT]
	ON [H].[HouseTypeID] = [HT].[HouseTypeID]
WHERE [Country] = '����' AND [HT].[Name] = '�����' 
	AND [DateStart] BETWEEN '2010.09.23' AND '2017.09.28'

-- ����� 2:
-- ���� ������� �������� ����� ���
-- ������ �� ���������� � 2010-09-23 �� 2017-09-28

SELECT DISTINCT
	[FirstName],
	[LastName],
	[Profit]
FROM [Alpinists] AS [A]
JOIN (
	SELECT
		[A].[AlpinistID] AS [AlpinistID],
		SUM([Price]) OVER (PARTITION BY [A].[AlpinistID]) AS [Profit]
	FROM [Alpinists] AS [A]
	JOIN [FoodOrders] AS [FO]
		ON [A].[AlpinistID] = [FO].[AlpinistID]
	JOIN [FoodTypes] AS [FT]
		ON [FO].[FoodTypeID] = [FT].[FoodTypeID]
		WHERE [Date] BETWEEN '2010-09-23' AND '2017-09-28'
	)
AS [S]
	ON [S].[AlpinistID] = [A].[AlpinistID]
WHERE [Profit] = 
	(SELECT TOP(1)
		SUM([Price]) OVER (PARTITION BY [A].[AlpinistID]) AS [Profit]
	FROM [Alpinists] AS [A]
	JOIN [FoodOrders] AS [FO]
		ON [A].[AlpinistID] = [FO].[AlpinistID]
	JOIN [FoodTypes] AS [FT]
		ON [FO].[FoodTypeID] = [FT].[FoodTypeID]
		WHERE [Date] BETWEEN '2010-09-23' AND '2017-09-28'
	ORDER BY [Profit] DESC)

-- ����� 3:
-- ������� ��� �������� �� ������
-- �� ������ "�������� ���������� ������" ����� 2017-09-23 

SELECT DISTINCT
	[FirstName],
	[LastName],
	[DateStart],
	[DateEnd],
	[R].[Name]
FROM [Alpinists] AS [A]
JOIN [Walks] AS [W]
	ON [A].[AlpinistID] = [W].[AlpinistID]
JOIN [Routes] AS [R]
	ON [W].[RouteID] = [R].[RouteID]
WHERE [DateStart] > '2017-09-23' AND [R].[Name] = '�������� ���������� ������'

-- ����� 4:
-- ��������� �������������� ������(�������� ������� ��������)

SELECT
	[Name],
	[AlpinistsCount]
FROM [Routes] AS [R]
JOIN (
	SELECT DISTINCT
		[R].[RouteID] AS [RouteID],
		COUNT([A].[AlpinistID]) OVER (PARTITION BY [R].[RouteID]) AS [AlpinistsCount]
	FROM [Alpinists] AS [A]
	JOIN [Walks] AS [W]
		ON [A].[AlpinistID] = [W].[AlpinistID]
	JOIN [Routes] AS [R]
		ON [W].[RouteID] = [R].[RouteID])
AS [AC]
	ON [AC].[RouteID] = [R].[RouteID]
WHERE [AlpinistsCount] = (
	SELECT TOP(1)
		COUNT([A].[AlpinistID]) OVER (PARTITION BY [R].[RouteID]) AS [AlpinistsCount]
	FROM [Alpinists] AS [A]
	JOIN [Walks] AS [W]
		ON [A].[AlpinistID] = [W].[AlpinistID]
	JOIN [Routes] AS [R]
		ON [W].[RouteID] = [R].[RouteID]
	ORDER BY [AlpinistsCount] DESC)

-- ����� 5:

-- ������� ��� ������� ���� ����� ������� �������� �� ��� ����������� 2017-09-23

SELECT DISTINCT
	[HT].[Name],
	COUNT([A].[AlpinistID]) OVER (PARTITION BY [HT].[HouseTypeID]) AS [AlpinistsCount]
FROM [Alpinists] AS [A]
JOIN [HouseOrders] AS [HO]
	ON [A].[AlpinistID] = [HO].[AlpinistID]
JOIN [Houses] AS [H]
	ON [HO].[HouseID] = [H].[HouseID]
JOIN [HouseTypes] AS [HT]
	ON [H].[HouseTypeID] = [HT].[HouseTypeID]
WHERE '2017-09-23' BETWEEN [DateStart] AND [DateEnd]