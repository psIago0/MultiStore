USE [MultiStoreDW]
GO
/****** Object:  Schema [stage]    Script Date: 04/05/2024 02:35:55 ******/
CREATE SCHEMA [stage]
GO
/****** Object:  Table [dbo].[ImportLog]    Script Date: 04/05/2024 02:35:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImportLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OriginalFileName] [nvarchar](50) NULL,
	[CurrentFileName] [nvarchar](50) NULL,
	[ImportDate] [datetime] NULL,
	[DeleteDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [stage].[MultiStore]    Script Date: 04/05/2024 02:35:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [stage].[MultiStore](
	[RowID] [int] NOT NULL,
	[OrderID] [nvarchar](255) NULL,
	[OrderDate] [int] NULL,
	[ShipDate] [int] NULL,
	[ShipMode] [nvarchar](255) NULL,
	[CustomerID] [nvarchar](255) NULL,
	[CustomerName] [nvarchar](255) NULL,
	[CustomerAge] [int] NULL,
	[CustomerBirthday] [nvarchar](255) NULL,
	[CustomerState] [nvarchar](255) NULL,
	[Segment] [nvarchar](255) NULL,
	[Country] [nvarchar](255) NULL,
	[City] [nvarchar](255) NULL,
	[State] [nvarchar](255) NULL,
	[RegionalManagerID] [nvarchar](255) NULL,
	[RegionalManager] [nvarchar](255) NULL,
	[PostalCode] [int] NULL,
	[Region] [nvarchar](255) NULL,
	[ProductID] [nvarchar](255) NULL,
	[Category] [nvarchar](255) NULL,
	[SubCategory] [nvarchar](255) NULL,
	[ProductName] [nvarchar](255) NULL,
	[Sales] [decimal](18, 2) NULL,
	[Quantity] [int] NULL,
	[Discount] [decimal](18, 2) NULL,
	[Profit] [decimal](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[RowID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
