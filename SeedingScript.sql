USE [POSDb]
GO
DELETE FROM [dbo].[Items]
GO
SET IDENTITY_INSERT [dbo].[Items] ON 

INSERT [dbo].[Items] ([Id], [Name], [Type], [Size], [Price]) VALUES (1, N'Small', 0, 1, CAST(160.00 AS Decimal(18, 2)))
INSERT [dbo].[Items] ([Id], [Name], [Type], [Size], [Price]) VALUES (2, N'Medium', 0, 2, CAST(200.00 AS Decimal(18, 2)))
INSERT [dbo].[Items] ([Id], [Name], [Type], [Size], [Price]) VALUES (3, N'Large', 0, 3, CAST(240.00 AS Decimal(18, 2)))
INSERT [dbo].[Items] ([Id], [Name], [Type], [Size], [Price]) VALUES (4, N'Onions', 1, 1, CAST(40.00 AS Decimal(18, 2)))
INSERT [dbo].[Items] ([Id], [Name], [Type], [Size], [Price]) VALUES (5, N'Onions', 1, 2, CAST(60.00 AS Decimal(18, 2)))
INSERT [dbo].[Items] ([Id], [Name], [Type], [Size], [Price]) VALUES (6, N'Onions', 1, 3, CAST(80.00 AS Decimal(18, 2)))
INSERT [dbo].[Items] ([Id], [Name], [Type], [Size], [Price]) VALUES (7, N'Mushrooms', 1, 3, CAST(90.00 AS Decimal(18, 2)))
INSERT [dbo].[Items] ([Id], [Name], [Type], [Size], [Price]) VALUES (8, N'Mushrooms', 1, 2, CAST(70.00 AS Decimal(18, 2)))
INSERT [dbo].[Items] ([Id], [Name], [Type], [Size], [Price]) VALUES (9, N'Mushrooms', 1, 1, CAST(55.00 AS Decimal(18, 2)))
INSERT [dbo].[Items] ([Id], [Name], [Type], [Size], [Price]) VALUES (10, N'CheeseBrust', 4, 1, CAST(80.00 AS Decimal(18, 2)))
INSERT [dbo].[Items] ([Id], [Name], [Type], [Size], [Price]) VALUES (11, N'CheeseBrust', 4, 2, CAST(120.00 AS Decimal(18, 2)))
INSERT [dbo].[Items] ([Id], [Name], [Type], [Size], [Price]) VALUES (12, N'CheeseBrust', 4, 3, CAST(150.00 AS Decimal(18, 2)))
INSERT [dbo].[Items] ([Id], [Name], [Type], [Size], [Price]) VALUES (13, N'HandTossed', 4, 1, CAST(60.00 AS Decimal(18, 2)))
INSERT [dbo].[Items] ([Id], [Name], [Type], [Size], [Price]) VALUES (14, N'HandTossed', 4, 2, CAST(70.00 AS Decimal(18, 2)))
INSERT [dbo].[Items] ([Id], [Name], [Type], [Size], [Price]) VALUES (15, N'HandTossed', 4, 3, CAST(80.00 AS Decimal(18, 2)))
INSERT [dbo].[Items] ([Id], [Name], [Type], [Size], [Price]) VALUES (16, N'GarlicRanch', 2, 1, CAST(20.00 AS Decimal(18, 2)))
INSERT [dbo].[Items] ([Id], [Name], [Type], [Size], [Price]) VALUES (17, N'GarlicRanch', 2, 2, CAST(40.00 AS Decimal(18, 2)))
INSERT [dbo].[Items] ([Id], [Name], [Type], [Size], [Price]) VALUES (18, N'GarlicRanch', 2, 3, CAST(60.00 AS Decimal(18, 2)))
INSERT [dbo].[Items] ([Id], [Name], [Type], [Size], [Price]) VALUES (19, N'Marinara', 2, 3, CAST(80.00 AS Decimal(18, 2)))
INSERT [dbo].[Items] ([Id], [Name], [Type], [Size], [Price]) VALUES (20, N'Marinara', 2, 2, CAST(60.00 AS Decimal(18, 2)))
INSERT [dbo].[Items] ([Id], [Name], [Type], [Size], [Price]) VALUES (21, N'Marinara', 2, 1, CAST(40.00 AS Decimal(18, 2)))
INSERT [dbo].[Items] ([Id], [Name], [Type], [Size], [Price]) VALUES (22, N'Ch-SM', 3, 1, CAST(40.00 AS Decimal(18, 2)))
INSERT [dbo].[Items] ([Id], [Name], [Type], [Size], [Price]) VALUES (23, N'Ch-L', 3, 3, CAST(60.00 AS Decimal(18, 2)))
INSERT [dbo].[Items] ([Id], [Name], [Type], [Size], [Price]) VALUES (24, N'Ch-M', 3, 2, CAST(50.00 AS Decimal(18, 2)))
INSERT [dbo].[Items] ([Id], [Name], [Type], [Size], [Price]) VALUES (25, N'ExCh-SM', 5, 1, CAST(30.00 AS Decimal(18, 2)))
INSERT [dbo].[Items] ([Id], [Name], [Type], [Size], [Price]) VALUES (26, N'ExCh-M', 5, 2, CAST(40.00 AS Decimal(18, 2)))
INSERT [dbo].[Items] ([Id], [Name], [Type], [Size], [Price]) VALUES (27, N'ExCh-L', 5, 3, CAST(60.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Items] OFF
GO
