SET DATEFORMAT YMD
USE [IstarRealEstate]
GO
/****** Object:  Trigger [ReportInsertTrigger]    Script Date: 05.08.2015 8:15:32 ******/
IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[ReportInsertTrigger]'))
DROP TRIGGER [dbo].[ReportInsertTrigger]
GO
/****** Object:  Trigger [OrderInsertTrigger]    Script Date: 05.08.2015 8:15:32 ******/
IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[OrderInsertTrigger]'))
DROP TRIGGER [dbo].[OrderInsertTrigger]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.Services_dbo.Buildings_Buildingid]') AND parent_object_id = OBJECT_ID(N'[dbo].[Services]'))
ALTER TABLE [dbo].[Services] DROP CONSTRAINT [FK_dbo.Services_dbo.Buildings_Buildingid]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.Reports_dbo.Counters_Counterid]') AND parent_object_id = OBJECT_ID(N'[dbo].[Reports]'))
ALTER TABLE [dbo].[Reports] DROP CONSTRAINT [FK_dbo.Reports_dbo.Counters_Counterid]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.Renters_dbo.Offices_Officeid]') AND parent_object_id = OBJECT_ID(N'[dbo].[Renters]'))
ALTER TABLE [dbo].[Renters] DROP CONSTRAINT [FK_dbo.Renters_dbo.Offices_Officeid]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.Renters_dbo.Customers_Customerid]') AND parent_object_id = OBJECT_ID(N'[dbo].[Renters]'))
ALTER TABLE [dbo].[Renters] DROP CONSTRAINT [FK_dbo.Renters_dbo.Customers_Customerid]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.Orders_dbo.Renters_Renterid]') AND parent_object_id = OBJECT_ID(N'[dbo].[Orders]'))
ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_dbo.Orders_dbo.Renters_Renterid]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.Orders_dbo.Paytypes_Paytypeid]') AND parent_object_id = OBJECT_ID(N'[dbo].[Orders]'))
ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_dbo.Orders_dbo.Paytypes_Paytypeid]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.Offices_dbo.Buildings_Buildingid]') AND parent_object_id = OBJECT_ID(N'[dbo].[Offices]'))
ALTER TABLE [dbo].[Offices] DROP CONSTRAINT [FK_dbo.Offices_dbo.Buildings_Buildingid]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.Customers_dbo.Buildings_Buildingid]') AND parent_object_id = OBJECT_ID(N'[dbo].[Customers]'))
ALTER TABLE [dbo].[Customers] DROP CONSTRAINT [FK_dbo.Customers_dbo.Buildings_Buildingid]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.Counters_dbo.Services_Serviceid]') AND parent_object_id = OBJECT_ID(N'[dbo].[Counters]'))
ALTER TABLE [dbo].[Counters] DROP CONSTRAINT [FK_dbo.Counters_dbo.Services_Serviceid]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.Buildings_dbo.Companies_Companyid]') AND parent_object_id = OBJECT_ID(N'[dbo].[Buildings]'))
ALTER TABLE [dbo].[Buildings] DROP CONSTRAINT [FK_dbo.Buildings_dbo.Companies_Companyid]
GO
/****** Object:  Index [IX_Buildingid]    Script Date: 05.08.2015 8:15:32 ******/
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Services]') AND name = N'IX_Buildingid')
DROP INDEX [IX_Buildingid] ON [dbo].[Services]
GO
/****** Object:  Index [IX_Counterid]    Script Date: 05.08.2015 8:15:32 ******/
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Reports]') AND name = N'IX_Counterid')
DROP INDEX [IX_Counterid] ON [dbo].[Reports]
GO
/****** Object:  Index [IX_Officeid]    Script Date: 05.08.2015 8:15:32 ******/
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Renters]') AND name = N'IX_Officeid')
DROP INDEX [IX_Officeid] ON [dbo].[Renters]
GO
/****** Object:  Index [IX_Customerid]    Script Date: 05.08.2015 8:15:32 ******/
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Renters]') AND name = N'IX_Customerid')
DROP INDEX [IX_Customerid] ON [dbo].[Renters]
GO
/****** Object:  Index [IX_Renterid]    Script Date: 05.08.2015 8:15:32 ******/
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Orders]') AND name = N'IX_Renterid')
DROP INDEX [IX_Renterid] ON [dbo].[Orders]
GO
/****** Object:  Index [IX_Paytypeid]    Script Date: 05.08.2015 8:15:32 ******/
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Orders]') AND name = N'IX_Paytypeid')
DROP INDEX [IX_Paytypeid] ON [dbo].[Orders]
GO
/****** Object:  Index [IX_Buildingid]    Script Date: 05.08.2015 8:15:32 ******/
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Offices]') AND name = N'IX_Buildingid')
DROP INDEX [IX_Buildingid] ON [dbo].[Offices]
GO
/****** Object:  Index [IX_Buildingid]    Script Date: 05.08.2015 8:15:32 ******/
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Customers]') AND name = N'IX_Buildingid')
DROP INDEX [IX_Buildingid] ON [dbo].[Customers]
GO
/****** Object:  Index [IX_Serviceid]    Script Date: 05.08.2015 8:15:32 ******/
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Counters]') AND name = N'IX_Serviceid')
DROP INDEX [IX_Serviceid] ON [dbo].[Counters]
GO
/****** Object:  Index [IX_Companyid]    Script Date: 05.08.2015 8:15:32 ******/
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Buildings]') AND name = N'IX_Companyid')
DROP INDEX [IX_Companyid] ON [dbo].[Buildings]
GO
/****** Object:  Table [dbo].[Services]    Script Date: 05.08.2015 8:15:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Services]') AND type in (N'U'))
DROP TABLE [dbo].[Services]
GO
/****** Object:  Table [dbo].[Reports]    Script Date: 05.08.2015 8:15:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Reports]') AND type in (N'U'))
DROP TABLE [dbo].[Reports]
GO
/****** Object:  Table [dbo].[Renters]    Script Date: 05.08.2015 8:15:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Renters]') AND type in (N'U'))
DROP TABLE [dbo].[Renters]
GO
/****** Object:  Table [dbo].[Periods]    Script Date: 05.08.2015 8:15:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Periods]') AND type in (N'U'))
DROP TABLE [dbo].[Periods]
GO
/****** Object:  Table [dbo].[Paytypes]    Script Date: 05.08.2015 8:15:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Paytypes]') AND type in (N'U'))
DROP TABLE [dbo].[Paytypes]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 05.08.2015 8:15:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Orders]') AND type in (N'U'))
DROP TABLE [dbo].[Orders]
GO
/****** Object:  Table [dbo].[Offices]    Script Date: 05.08.2015 8:15:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Offices]') AND type in (N'U'))
DROP TABLE [dbo].[Offices]
GO
/****** Object:  Table [dbo].[Jobs]    Script Date: 05.08.2015 8:15:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Jobs]') AND type in (N'U'))
DROP TABLE [dbo].[Jobs]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 05.08.2015 8:15:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customers]') AND type in (N'U'))
DROP TABLE [dbo].[Customers]
GO
/****** Object:  Table [dbo].[Counters]    Script Date: 05.08.2015 8:15:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Counters]') AND type in (N'U'))
DROP TABLE [dbo].[Counters]
GO
/****** Object:  Table [dbo].[Companies]    Script Date: 05.08.2015 8:15:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Companies]') AND type in (N'U'))
DROP TABLE [dbo].[Companies]
GO
/****** Object:  Table [dbo].[Buildings]    Script Date: 05.08.2015 8:15:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Buildings]') AND type in (N'U'))
DROP TABLE [dbo].[Buildings]
GO
/****** Object:  Table [dbo].[Buildings]    Script Date: 05.08.2015 8:15:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Buildings]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Buildings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Companyid] [int] NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[Phone] [nvarchar](max) NULL,
	[Photo] [image] NULL,
 CONSTRAINT [PK_dbo.Buildings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Companies]    Script Date: 05.08.2015 8:15:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Companies]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Companies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[Phone] [nvarchar](max) NULL,
	[Inn] [decimal](12, 0) NOT NULL,
	[Kpp] [decimal](9, 0) NOT NULL,
	[Curaccount] [decimal](20, 0) NOT NULL,
	[Bank] [nvarchar](max) NOT NULL,
	[Coraccount] [decimal](20, 0) NOT NULL,
	[Bik] [decimal](9, 0) NOT NULL,
	[Manager] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_dbo.Companies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Counters]    Script Date: 05.08.2015 8:15:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Counters]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Counters](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Serviceid] [int] NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Setdate] [datetime] NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_dbo.Counters] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 05.08.2015 8:15:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customers]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Customers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Buildingid] [int] NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[Phone] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Contact] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_dbo.Customers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Jobs]    Script Date: 05.08.2015 8:15:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Jobs]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Jobs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Jobdate] [datetime] NOT NULL,
	[Jobtitle] [nvarchar](max) NOT NULL,
	[Jobtext] [nvarchar](max) NOT NULL,
	[Ismonthly] [bit] NOT NULL,
	[Iscomplete] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Jobs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Offices]    Script Date: 05.08.2015 8:15:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Offices]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Offices](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Buildingid] [int] NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Area] [decimal](4, 1) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Total] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_dbo.Offices] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 05.08.2015 8:15:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Orders]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Renterid] [int] NOT NULL,
	[Paytypeid] [int] NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Orderdate] [datetime] NOT NULL,
	[Total] [decimal](18, 2) NOT NULL,
	[Paidtotal] [decimal](18, 2) NOT NULL,
	[Paid] [bit] NOT NULL,
	[Period] [nvarchar](65) NULL,
 CONSTRAINT [PK_dbo.Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Paytypes]    Script Date: 05.08.2015 8:15:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Paytypes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Paytypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_dbo.Paytypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Periods]    Script Date: 05.08.2015 8:15:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Periods]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Periods](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Workingstart] [datetime] NOT NULL,
	[Workingperiod] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_dbo.Periods] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Renters]    Script Date: 05.08.2015 8:15:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Renters]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Renters](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Customerid] [int] NOT NULL,
	[Officeid] [int] NOT NULL,
	[Contract] [nvarchar](max) NOT NULL,
	[Occupation] [nvarchar](max) NULL,
	[Total] [decimal](18, 2) NOT NULL,
	[Rentdate] [datetime] NOT NULL,
	[Rentend] [datetime] NULL,
	[Isend] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Renters] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Reports]    Script Date: 05.08.2015 8:15:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Reports]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Reports](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Counterid] [int] NOT NULL,
	[Reportdate] [datetime] NOT NULL,
	[Period] [nvarchar](65) NULL,
	[Newdata] [decimal](18, 1) NOT NULL,
	[Prevdata] [decimal](18, 1) NOT NULL,
	[Point] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_dbo.Reports] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Services]    Script Date: 05.08.2015 8:15:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Services]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Services](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Buildingid] [int] NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Contract] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[Phone] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Manager] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_dbo.Services] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET IDENTITY_INSERT [dbo].[Jobs] ON 

INSERT [dbo].[Jobs] ([Id], [Jobdate], [Jobtitle], [Jobtext], [Ismonthly], [Iscomplete]) VALUES (1, CAST(GETDATE() AS Date), N'ВНИМАНИЕ! Необходимо заполнить базу данных.', N'Для продолжения работы с программой требуется выполнить скрипт для заполнения базы данных.', 1, 0)
SET IDENTITY_INSERT [dbo].[Jobs] OFF
/****** Object:  Index [IX_Companyid]    Script Date: 05.08.2015 8:15:32 ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Buildings]') AND name = N'IX_Companyid')
CREATE NONCLUSTERED INDEX [IX_Companyid] ON [dbo].[Buildings]
(
	[Companyid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Serviceid]    Script Date: 05.08.2015 8:15:32 ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Counters]') AND name = N'IX_Serviceid')
CREATE NONCLUSTERED INDEX [IX_Serviceid] ON [dbo].[Counters]
(
	[Serviceid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Buildingid]    Script Date: 05.08.2015 8:15:32 ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Customers]') AND name = N'IX_Buildingid')
CREATE NONCLUSTERED INDEX [IX_Buildingid] ON [dbo].[Customers]
(
	[Buildingid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Buildingid]    Script Date: 05.08.2015 8:15:32 ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Offices]') AND name = N'IX_Buildingid')
CREATE NONCLUSTERED INDEX [IX_Buildingid] ON [dbo].[Offices]
(
	[Buildingid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Paytypeid]    Script Date: 05.08.2015 8:15:32 ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Orders]') AND name = N'IX_Paytypeid')
CREATE NONCLUSTERED INDEX [IX_Paytypeid] ON [dbo].[Orders]
(
	[Paytypeid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Renterid]    Script Date: 05.08.2015 8:15:32 ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Orders]') AND name = N'IX_Renterid')
CREATE NONCLUSTERED INDEX [IX_Renterid] ON [dbo].[Orders]
(
	[Renterid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Customerid]    Script Date: 05.08.2015 8:15:32 ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Renters]') AND name = N'IX_Customerid')
CREATE NONCLUSTERED INDEX [IX_Customerid] ON [dbo].[Renters]
(
	[Customerid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Officeid]    Script Date: 05.08.2015 8:15:32 ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Renters]') AND name = N'IX_Officeid')
CREATE NONCLUSTERED INDEX [IX_Officeid] ON [dbo].[Renters]
(
	[Officeid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Counterid]    Script Date: 05.08.2015 8:15:32 ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Reports]') AND name = N'IX_Counterid')
CREATE NONCLUSTERED INDEX [IX_Counterid] ON [dbo].[Reports]
(
	[Counterid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Buildingid]    Script Date: 05.08.2015 8:15:32 ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Services]') AND name = N'IX_Buildingid')
CREATE NONCLUSTERED INDEX [IX_Buildingid] ON [dbo].[Services]
(
	[Buildingid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.Buildings_dbo.Companies_Companyid]') AND parent_object_id = OBJECT_ID(N'[dbo].[Buildings]'))
ALTER TABLE [dbo].[Buildings]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Buildings_dbo.Companies_Companyid] FOREIGN KEY([Companyid])
REFERENCES [dbo].[Companies] ([Id])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.Buildings_dbo.Companies_Companyid]') AND parent_object_id = OBJECT_ID(N'[dbo].[Buildings]'))
ALTER TABLE [dbo].[Buildings] CHECK CONSTRAINT [FK_dbo.Buildings_dbo.Companies_Companyid]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.Counters_dbo.Services_Serviceid]') AND parent_object_id = OBJECT_ID(N'[dbo].[Counters]'))
ALTER TABLE [dbo].[Counters]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Counters_dbo.Services_Serviceid] FOREIGN KEY([Serviceid])
REFERENCES [dbo].[Services] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.Counters_dbo.Services_Serviceid]') AND parent_object_id = OBJECT_ID(N'[dbo].[Counters]'))
ALTER TABLE [dbo].[Counters] CHECK CONSTRAINT [FK_dbo.Counters_dbo.Services_Serviceid]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.Customers_dbo.Buildings_Buildingid]') AND parent_object_id = OBJECT_ID(N'[dbo].[Customers]'))
ALTER TABLE [dbo].[Customers]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Customers_dbo.Buildings_Buildingid] FOREIGN KEY([Buildingid])
REFERENCES [dbo].[Buildings] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.Customers_dbo.Buildings_Buildingid]') AND parent_object_id = OBJECT_ID(N'[dbo].[Customers]'))
ALTER TABLE [dbo].[Customers] CHECK CONSTRAINT [FK_dbo.Customers_dbo.Buildings_Buildingid]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.Offices_dbo.Buildings_Buildingid]') AND parent_object_id = OBJECT_ID(N'[dbo].[Offices]'))
ALTER TABLE [dbo].[Offices]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Offices_dbo.Buildings_Buildingid] FOREIGN KEY([Buildingid])
REFERENCES [dbo].[Buildings] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.Offices_dbo.Buildings_Buildingid]') AND parent_object_id = OBJECT_ID(N'[dbo].[Offices]'))
ALTER TABLE [dbo].[Offices] CHECK CONSTRAINT [FK_dbo.Offices_dbo.Buildings_Buildingid]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.Orders_dbo.Paytypes_Paytypeid]') AND parent_object_id = OBJECT_ID(N'[dbo].[Orders]'))
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Orders_dbo.Paytypes_Paytypeid] FOREIGN KEY([Paytypeid])
REFERENCES [dbo].[Paytypes] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.Orders_dbo.Paytypes_Paytypeid]') AND parent_object_id = OBJECT_ID(N'[dbo].[Orders]'))
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_dbo.Orders_dbo.Paytypes_Paytypeid]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.Orders_dbo.Renters_Renterid]') AND parent_object_id = OBJECT_ID(N'[dbo].[Orders]'))
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Orders_dbo.Renters_Renterid] FOREIGN KEY([Renterid])
REFERENCES [dbo].[Renters] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.Orders_dbo.Renters_Renterid]') AND parent_object_id = OBJECT_ID(N'[dbo].[Orders]'))
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_dbo.Orders_dbo.Renters_Renterid]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.Renters_dbo.Customers_Customerid]') AND parent_object_id = OBJECT_ID(N'[dbo].[Renters]'))
ALTER TABLE [dbo].[Renters]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Renters_dbo.Customers_Customerid] FOREIGN KEY([Customerid])
REFERENCES [dbo].[Customers] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.Renters_dbo.Customers_Customerid]') AND parent_object_id = OBJECT_ID(N'[dbo].[Renters]'))
ALTER TABLE [dbo].[Renters] CHECK CONSTRAINT [FK_dbo.Renters_dbo.Customers_Customerid]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.Renters_dbo.Offices_Officeid]') AND parent_object_id = OBJECT_ID(N'[dbo].[Renters]'))
ALTER TABLE [dbo].[Renters]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Renters_dbo.Offices_Officeid] FOREIGN KEY([Officeid])
REFERENCES [dbo].[Offices] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.Renters_dbo.Offices_Officeid]') AND parent_object_id = OBJECT_ID(N'[dbo].[Renters]'))
ALTER TABLE [dbo].[Renters] CHECK CONSTRAINT [FK_dbo.Renters_dbo.Offices_Officeid]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.Reports_dbo.Counters_Counterid]') AND parent_object_id = OBJECT_ID(N'[dbo].[Reports]'))
ALTER TABLE [dbo].[Reports]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Reports_dbo.Counters_Counterid] FOREIGN KEY([Counterid])
REFERENCES [dbo].[Counters] ([Id])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.Reports_dbo.Counters_Counterid]') AND parent_object_id = OBJECT_ID(N'[dbo].[Reports]'))
ALTER TABLE [dbo].[Reports] CHECK CONSTRAINT [FK_dbo.Reports_dbo.Counters_Counterid]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.Services_dbo.Buildings_Buildingid]') AND parent_object_id = OBJECT_ID(N'[dbo].[Services]'))
ALTER TABLE [dbo].[Services]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Services_dbo.Buildings_Buildingid] FOREIGN KEY([Buildingid])
REFERENCES [dbo].[Buildings] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.Services_dbo.Buildings_Buildingid]') AND parent_object_id = OBJECT_ID(N'[dbo].[Services]'))
ALTER TABLE [dbo].[Services] CHECK CONSTRAINT [FK_dbo.Services_dbo.Buildings_Buildingid]
GO
/****** Object:  Trigger [dbo].[OrderInsertTrigger]    Script Date: 05.08.2015 8:15:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[OrderInsertTrigger]'))
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[OrderInsertTrigger]
   ON  [dbo].[Orders]
   AFTER INSERT
AS 

If Not Exists (Select workingperiod from Periods f
inner join inserted i on f.workingperiod = i.Period where
f.workingperiod = i.Period)
BEGIN
	declare @workingstart datetime

	declare @workingperiod nvarchar(50);

	select @workingstart=i.Orderdate, @workingperiod=i.Period from inserted i;

	insert into [dbo].[Periods]
		   (workingstart, workingperiod) 
	values(@workingstart, @workingperiod);
END
' 
GO
/****** Object:  Trigger [dbo].[ReportInsertTrigger]    Script Date: 05.08.2015 8:15:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[ReportInsertTrigger]'))
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[ReportInsertTrigger]
   ON  [dbo].[Reports]
   AFTER INSERT
AS 

If Not Exists (Select workingperiod from Periods f
inner join inserted i on f.workingperiod = i.Period where
f.workingperiod = i.Period)
BEGIN

	declare @workingstart datetime

	declare @workingperiod nvarchar(50);

	select @workingstart=i.Reportdate, @workingperiod=i.Period from inserted i;

	insert into [dbo].[Periods]
		   (workingstart, workingperiod) 
	values(@workingstart, @workingperiod);
END
' 
GO
