USE [Coursework]
GO

-- Query 1.1 for first report (Бухгалтерський Облік)

-- Виводить всі замовлення за певний період

SELECT
	[FirstName],
	[LastName],
	[DateStart],
    [DateEnd],
	[HT].[Name],
	[Price]*(DateDiff(DD,[DateStart],[DateEnd])+1) AS [Price]
FROM [HouseOrders] AS [HO]
JOIN [Alpinists] AS [A]
	ON [A].[AlpinistID] = [HO].[AlpinistID]
JOIN [Houses] AS [H]
	ON [HO].[HouseID] = [H].[HouseID]
JOIN [HouseTypes] AS [HT]
	ON [H].[HouseTypeID] = [HT].[HouseTypeID]
WHERE ([DateStart] BETWEEN '2017-09-10' AND '2017-09-15') AND ([DateEnd] BETWEEN '2017-09-10' AND '2017-09-15')
UNION
SELECT 
	[FirstName],
	[LastName],
	[Date] AS [DateStart],
	NULL AS [DateEnd],
	[Name],
	[Price]
FROM [FoodOrders] AS [FO]
JOIN [Alpinists] AS [A]
	ON [A].[AlpinistID] = [FO].[AlpinistID]
JOIN [FoodTypes] AS [FT]
	ON [FO].[FoodTypeID] = [FT].[FoodTypeID]
WHERE ([Date] BETWEEN '2017-09-10' AND '2017-09-15')
ORDER BY [DateStart]

-- Query 1.2 for second report (Бухгалтерський Облік)

-- Виводить прибуток по альпіністам за певний період

SELECT 
	[FirstName],
	[LastName],
	SUM([Price]) AS [Profit]
FROM [Alpinists] AS [A]
JOIN 
(SELECT
	[A].[AlpinistID],
	[DateStart],
    [DateEnd],
	[Price]*(DateDiff(DD,[DateStart],[DateEnd])+1) AS [Price]
FROM [HouseOrders] AS [HO]
JOIN [Alpinists] AS [A]
	ON [A].[AlpinistID] = [HO].[AlpinistID]
JOIN [Houses] AS [H]
	ON [HO].[HouseID] = [H].[HouseID]
JOIN [HouseTypes] AS [HT]
	ON [H].[HouseTypeID] = [HT].[HouseTypeID]
WHERE ([DateStart] BETWEEN '2017-01-10' AND '2017-09-15') AND ([DateEnd] BETWEEN '2017-01-10' AND '2017-09-15')
UNION
SELECT 
	[A].[AlpinistID],
	[Date] AS [DateStart],
	NULL AS [DateEnd],
	[Price]
FROM [FoodOrders] AS [FO]
JOIN [Alpinists] AS [A]
	ON [A].[AlpinistID] = [FO].[AlpinistID]
JOIN [FoodTypes] AS [FT]
	ON [FO].[FoodTypeID] = [FT].[FoodTypeID]
WHERE ([Date] BETWEEN '2017-01-10' AND '2017-09-15') 
) AS [P]
ON [A].[AlpinistID] = [P].[AlpinistID]
GROUP BY [FirstName], [LastName]
ORDER BY [Profit] DESC

-- Query 1.3 for trird report (Бухгалтерський Облік)

-- Виводить загальний прибуток по типам послуг

SELECT 
	[Name],
	SUM([Price]) AS [Profit]
FROM [Alpinists] AS [A]
JOIN 
(SELECT
	[A].[AlpinistID],
	[DateStart],
    [DateEnd],
	[HT].[Name],
	[Price]*(DateDiff(DD,[DateStart],[DateEnd])+1) AS [Price]
FROM [HouseOrders] AS [HO]
JOIN [Alpinists] AS [A]
	ON [A].[AlpinistID] = [HO].[AlpinistID]
JOIN [Houses] AS [H]
	ON [HO].[HouseID] = [H].[HouseID]
JOIN [HouseTypes] AS [HT]
	ON [H].[HouseTypeID] = [HT].[HouseTypeID]
WHERE ([DateStart] BETWEEN '2017-11-01' AND '2017-11-30') AND ([DateEnd] BETWEEN '2017-11-01' AND '2017-11-30')
UNION 
SELECT 
	[A].[AlpinistID],
	[Date] AS [DateStart],
	NULL AS [DateEnd],
	[Name],
	[Price]
FROM [FoodOrders] AS [FO]
JOIN [Alpinists] AS [A]
	ON [A].[AlpinistID] = [FO].[AlpinistID]
JOIN [FoodTypes] AS [FT]
	ON [FO].[FoodTypeID] = [FT].[FoodTypeID]
WHERE ([Date] BETWEEN '2017-11-01' AND '2017-11-30') 
) AS [P]
ON [A].[AlpinistID] = [P].[AlpinistID]
GROUP BY [Name]
ORDER BY [Profit] DESC

-- Query for 2.1.1 statistics (статистика)

-- Сума прибутку по проживанню

SELECT
	SUM([Price]*(DateDiff(DD,[DateStart],[DateEnd])+1)) AS [Profit]
FROM [HouseOrders] AS [HO]
JOIN [Houses] AS [H]
	ON [HO].[HouseID] = [H].[HouseID]
JOIN [HouseTypes] AS [HT]
	ON [H].[HouseTypeID] = [HT].[HouseTypeID]
WHERE ([DateStart] BETWEEN
DATEADD(YEAR, -1, GETDATE()) AND GETDATE())
AND ([DateEnd] BETWEEN 
DATEADD(YEAR, -1, GETDATE()) AND GETDATE())

-- Query for 2.1.2 statistics (статистика)

-- Сума прибутку по харчуванню

SELECT 	
	SUM([Price]) AS [Profit]
FROM [FoodOrders] AS [FO]
JOIN [FoodTypes] AS [FT]
	ON [FO].[FoodTypeID] = [FT].[FoodTypeID]
WHERE ([Date] BETWEEN 
DATEADD(YEAR, -1, GETDATE()) AND GETDATE())

-- Query for 2.2.1 statistics (статистика)

-- загальний прибуток по типам послуг проживання

SELECT
	SUM([Price]*(DateDiff(DD,[DateStart],[DateEnd])+1)) AS [Profit]
FROM [HouseOrders] AS [HO]
JOIN [Houses] AS [H]
	ON [HO].[HouseID] = [H].[HouseID]
JOIN [HouseTypes] AS [HT]
	ON [H].[HouseTypeID] = [HT].[HouseTypeID]
WHERE ([DateStart] BETWEEN
DATEADD(YEAR, -1, GETDATE()) AND GETDATE())
AND ([DateEnd] BETWEEN 
DATEADD(YEAR, -1, GETDATE()) AND GETDATE()) AND ([HT].[Name] = 'House')

-- Query for 2.2.2 statistics (статистика)

-- прибуток за проживання по Альпіністським Базам

SELECT
	SUM([Price]*(DateDiff(DD,[DateStart],[DateEnd])+1)) AS [Profit]
FROM [HouseOrders] AS [HO]
JOIN [Houses] AS [H]
	ON [HO].[HouseID] = [H].[HouseID]
JOIN [AlpinistBases] AS [AB]
	ON [H].[AlpinistBaseID] = [AB].[AlpinistBaseID]
JOIN [HouseTypes] AS [HT]
	ON [H].[HouseTypeID] = [HT].[HouseTypeID]
WHERE ([DateStart] BETWEEN
DATEADD(YEAR, -1, GETDATE()) AND GETDATE())
AND ([DateEnd] BETWEEN 
DATEADD(YEAR, -1, GETDATE()) AND GETDATE()) AND ([AB].[Country] = 'Russia')

-- Query for 2.3.1 statistics (статистика)

-- прибуток по типам послуг харчування

SELECT 	
	[Name],
	SUM([Price]) AS [Profit]
FROM [FoodOrders] AS [FO]
JOIN [FoodTypes] AS [FT]
	ON [FO].[FoodTypeID] = [FT].[FoodTypeID]
WHERE ([Date] BETWEEN 
DATEADD(YEAR, -1, GETDATE()) AND GETDATE())
GROUP BY [Name]

-- Query for 2.3.2 statistics (статистика)

-- прибуток за харчування по Альпіністським Базам
SELECT 	
	SUM([Price]) AS [Profit]
FROM [FoodOrders] AS [FO]
JOIN [FoodTypes] AS [FT]
	ON [FO].[FoodTypeID] = [FT].[FoodTypeID]
JOIN [AlpinistsList] AS [AL]
	ON [FO].[AlpinistID] = [AL].[AlpinistID]
JOIN [AlpinistBases] AS [AB]
	ON [AL].[AlpinistBaseID] = [AB].[AlpinistBaseID]
WHERE ([Date] BETWEEN DATEADD(YEAR, -1, GETDATE()) AND GETDATE()) AND ([Country] = 'Russia')

-- Query for 2.4.1 statistics (статистика)

-- Прибуток по Альпіністським базам

SELECT 
	SUM([Price]) AS [Profit]
FROM [AlpinistBases] AS [AB]
JOIN [AlpinistsList] AS [AL]
	ON [AB].[AlpinistBaseID] = [AL].[AlpinistBaseID]
JOIN 
(SELECT
	[A].[AlpinistID],
	[DateStart],
    [DateEnd],
	[Price]*(DateDiff(DD,[DateStart],[DateEnd])+1) AS [Price]
FROM [HouseOrders] AS [HO]
JOIN [Alpinists] AS [A]
	ON [A].[AlpinistID] = [HO].[AlpinistID]
JOIN [Houses] AS [H]
	ON [HO].[HouseID] = [H].[HouseID]
JOIN [HouseTypes] AS [HT]
	ON [H].[HouseTypeID] = [HT].[HouseTypeID]
WHERE ([DateStart] BETWEEN '2017.08.23' AND '2017-12-24') AND ([DateEnd] BETWEEN '2017-08-23' AND '2017-12-24')
UNION
SELECT 
	[A].[AlpinistID],
	[Date] AS [DateStart],
	NULL AS [DateEnd],
	[Price]
FROM [FoodOrders] AS [FO]
JOIN [Alpinists] AS [A]
	ON [A].[AlpinistID] = [FO].[AlpinistID]
JOIN [FoodTypes] AS [FT]
	ON [FO].[FoodTypeID] = [FT].[FoodTypeID]
WHERE ([Date] BETWEEN '2017-08-23' AND '2017-12-24') 
) AS [P]
ON [AL].[AlpinistID] = [P].[AlpinistID]
WHERE ([Country] = 'Russia')

-- Query for 2.4.2 statistics (статистика)

-- Прибуток по Альпіністським Базам за харчування

SELECT 
	SUM([Price]) AS [Profit]
FROM [AlpinistBases] AS [AB]
JOIN [AlpinistsList] AS [AL]
	ON [AB].[AlpinistBaseID] = [AL].[AlpinistBaseID]
JOIN 
(SELECT
	[A].[AlpinistID],
	[DateStart],
    [DateEnd],
	[Price]*(DateDiff(DD,[DateStart],[DateEnd])+1) AS [Price],
	'HouseOrder' AS [Type]
FROM [HouseOrders] AS [HO]
JOIN [Alpinists] AS [A]
	ON [A].[AlpinistID] = [HO].[AlpinistID]
JOIN [Houses] AS [H]
	ON [HO].[HouseID] = [H].[HouseID]
JOIN [HouseTypes] AS [HT]
	ON [H].[HouseTypeID] = [HT].[HouseTypeID]
WHERE ([DateStart] BETWEEN '2017.08.23' AND '2017-12-24') AND ([DateEnd] BETWEEN '2017-08-23' AND '2017-12-24')
UNION
SELECT 
	[A].[AlpinistID],
	[Date] AS [DateStart],
	NULL AS [DateEnd],
	[Price],
	'FoodOrder' AS [Type]
FROM [FoodOrders] AS [FO]
JOIN [Alpinists] AS [A]
	ON [A].[AlpinistID] = [FO].[AlpinistID]
JOIN [FoodTypes] AS [FT]
	ON [FO].[FoodTypeID] = [FT].[FoodTypeID]
WHERE ([Date] BETWEEN '2017-08-23' AND '2017-12-24') 
) AS [P]
ON [AL].[AlpinistID] = [P].[AlpinistID]
WHERE ([Country] = 'Russia') AND ([Type] = 'FoodOrder')

-- Query for 3.1 Рятувальна Служба

-- Виводить список маршутів з їх поточним станом

SELECT 
	[Name],
	[Country],
	[State]
FROM [Routes] AS [R]
JOIN [RouteStates] AS [RS]
	ON [R].[RouteID] = [RS].[RouteID]
JOIN [AlpinistBases] AS [AB]
	ON [R].[AlpinistBaseID] = [AB].[AlpinistBaseID]
WHERE ([DateEnd] IS NULL)

-- Query for 3.2 Рятувальна Служба

-- Виводить всіх Альпіністів які зараз на маршутах

SELECT
	[FirstName],
	[LastName],
	[Name],
	[DateEnd]
FROM [Routes] AS [R]
JOIN [Walks] AS [W]
	ON [W].[RouteID] = [R].[RouteID]
JOIN [Alpinists] AS [A]
	ON [A].[AlpinistID] = [W].[AlpinistID]
WHERE ('2017-09-23' BETWEEN [DateStart] AND [DateEnd])

-- Query for 3.3 Рятувальна Служба

-- Змінює поточний стан маршуту

UPDATE [RouteStates] 
SET [DateEnd] = GETDATE()
WHERE ([RouteID] = 1) AND ([DateEnd] IS NULL)
GO

INSERT INTO [RouteStates] ([State], [RouteID], [DateStart], [DateEnd])
VALUES 
	('Very', 1, GETDATE(), NULL)
GO

-- Query for 4.1 Адміністрування

-- Добавляє Альпініта в таблицю Альпіністів
-- та реєструє його в Альпіністській Базі

INSERT INTO [Alpinists] ([FirstName], [LastName], [Phone])
VALUES
	('Valentine', 'Gladyshko', '099-545-14-33')
INSERT INTO [AlpinistsList] ([AlpinistID], [AlpinistBaseID])
VALUES(
	(
	SELECT TOP(1) [AlpinistID]     
	FROM [Coursework].[dbo].[Alpinists]
	ORDER BY [AlpinistID] DESC
	), 2)

-- Query for 4.2 Адміністрування

-- Добавляє Замовлення Харчування в таблицю FoodOrders

INSERT INTO [FoodOrders] ([AlpinistID], [FoodTypeID], [Date])
VALUES
	(1, 1, '2017-09-23')

-- Query for 4.3 Адміністрування

-- Добавляє Замовлення Харчування в таблицю FoodOrders

SELECT 
	[HouseID],
	[H].[Name],
	[HT].[Name]
	FROM [Coursework].[dbo].[Houses] AS [H]
JOIN [HouseTypes] AS [HT]
	ON [H].[HouseTypeID] = [HT].[HouseTypeID]
WHERE ([AlpinistBaseID] IN 
	(
	SELECT [AlpinistBaseID] FROM [AlpinistsList]
	WHERE [AlpinistID] = 1
	)
)
ORDER BY [H].[Name]