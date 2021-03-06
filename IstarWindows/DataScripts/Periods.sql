SET DATEFORMAT YMD
USE [IstarRealEstate]
GO
/****** Object:  Table [dbo].[Periods]    Script Date: 04.08.2015 22:14:54 ******/
DROP TABLE [dbo].[Periods]
GO
/****** Object:  Table [dbo].[Periods]    Script Date: 04.08.2015 22:14:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Periods](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Workingstart] [datetime] NOT NULL,
	[Workingperiod] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_dbo.Periods] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Periods] ON 

INSERT [dbo].[Periods] ([Id], [Workingstart], [Workingperiod]) VALUES (1, CAST(N'2013-07-15 00:00:00.000' AS DateTime), N'Июль, 2013 г.')
INSERT [dbo].[Periods] ([Id], [Workingstart], [Workingperiod]) VALUES (2, CAST(N'2013-08-15 00:00:00.000' AS DateTime), N'Август, 2013 г.')
INSERT [dbo].[Periods] ([Id], [Workingstart], [Workingperiod]) VALUES (3, CAST(N'2013-09-13 00:00:00.000' AS DateTime), N'Сентябрь, 2013 г.')
INSERT [dbo].[Periods] ([Id], [Workingstart], [Workingperiod]) VALUES (4, CAST(N'2013-10-23 00:00:00.000' AS DateTime), N'Октябрь, 2013 г.')
INSERT [dbo].[Periods] ([Id], [Workingstart], [Workingperiod]) VALUES (5, CAST(N'2013-11-28 00:00:00.000' AS DateTime), N'Ноябрь, 2013 г.')
INSERT [dbo].[Periods] ([Id], [Workingstart], [Workingperiod]) VALUES (6, CAST(N'2013-12-24 00:00:00.000' AS DateTime), N'Декабрь, 2013 г.')
INSERT [dbo].[Periods] ([Id], [Workingstart], [Workingperiod]) VALUES (7, CAST(N'2014-01-22 00:00:00.000' AS DateTime), N'Январь, 2014 г.')
INSERT [dbo].[Periods] ([Id], [Workingstart], [Workingperiod]) VALUES (8, CAST(N'2014-02-17 00:00:00.000' AS DateTime), N'Февраль, 2014 г.')
INSERT [dbo].[Periods] ([Id], [Workingstart], [Workingperiod]) VALUES (9, CAST(N'2014-03-17 00:00:00.000' AS DateTime), N'Март, 2014 г.')
INSERT [dbo].[Periods] ([Id], [Workingstart], [Workingperiod]) VALUES (10, CAST(N'2014-04-14 00:00:00.000' AS DateTime), N'Апрель, 2014 г.')
INSERT [dbo].[Periods] ([Id], [Workingstart], [Workingperiod]) VALUES (11, CAST(N'2014-05-21 00:00:00.000' AS DateTime), N'Май, 2014 г.')
INSERT [dbo].[Periods] ([Id], [Workingstart], [Workingperiod]) VALUES (12, CAST(N'2014-06-11 00:00:00.000' AS DateTime), N'Июнь, 2014 г.')
INSERT [dbo].[Periods] ([Id], [Workingstart], [Workingperiod]) VALUES (13, CAST(N'2014-07-16 00:00:00.000' AS DateTime), N'Июль, 2014 г.')
INSERT [dbo].[Periods] ([Id], [Workingstart], [Workingperiod]) VALUES (14, CAST(N'2014-08-19 00:00:00.000' AS DateTime), N'Август, 2014 г.')
INSERT [dbo].[Periods] ([Id], [Workingstart], [Workingperiod]) VALUES (15, CAST(N'2014-09-15 00:00:00.000' AS DateTime), N'Сентябрь, 2014 г.')
INSERT [dbo].[Periods] ([Id], [Workingstart], [Workingperiod]) VALUES (16, CAST(N'2014-10-15 00:00:00.000' AS DateTime), N'Октябрь, 2014 г.')
INSERT [dbo].[Periods] ([Id], [Workingstart], [Workingperiod]) VALUES (17, CAST(N'2014-11-19 00:00:00.000' AS DateTime), N'Ноябрь, 2014 г.')
INSERT [dbo].[Periods] ([Id], [Workingstart], [Workingperiod]) VALUES (18, CAST(N'2014-12-19 00:00:00.000' AS DateTime), N'Декабрь, 2014 г.')
INSERT [dbo].[Periods] ([Id], [Workingstart], [Workingperiod]) VALUES (19, CAST(N'2015-01-19 00:00:00.000' AS DateTime), N'Январь, 2015 г.')
INSERT [dbo].[Periods] ([Id], [Workingstart], [Workingperiod]) VALUES (20, CAST(N'2015-02-17 00:00:00.000' AS DateTime), N'Февраль, 2015 г.')
INSERT [dbo].[Periods] ([Id], [Workingstart], [Workingperiod]) VALUES (21, CAST(N'2015-03-17 00:00:00.000' AS DateTime), N'Март, 2015 г.')
INSERT [dbo].[Periods] ([Id], [Workingstart], [Workingperiod]) VALUES (22, CAST(N'2015-04-14 00:00:00.000' AS DateTime), N'Апрель, 2015 г.')
INSERT [dbo].[Periods] ([Id], [Workingstart], [Workingperiod]) VALUES (23, CAST(N'2015-05-18 00:00:00.000' AS DateTime), N'Май, 2015 г.')
INSERT [dbo].[Periods] ([Id], [Workingstart], [Workingperiod]) VALUES (24, CAST(N'2015-06-16 00:00:00.000' AS DateTime), N'Июнь, 2015 г.')
INSERT [dbo].[Periods] ([Id], [Workingstart], [Workingperiod]) VALUES (25, CAST(N'2015-07-15 00:00:00.000' AS DateTime), N'Июль, 2015 г.')
SET IDENTITY_INSERT [dbo].[Periods] OFF

GO
/****** Object:  Trigger [dbo].[ReportInsertTrigger]    Script Date: 04.08.2015 22:14:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF OBJECT_ID ('[ReportInsertTrigger]', 'TR') IS NOT NULL
   DROP TRIGGER ReportInsertTrigger;
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER dbo.ReportInsertTrigger
   ON  Reports
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
GO
/****** Object:  Trigger [dbo].[ReportInsertTrigger]    Script Date: 04.08.2015 22:14:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF OBJECT_ID ('[OrderInsertTrigger]', 'TR') IS NOT NULL
   DROP TRIGGER OrderInsertTrigger;
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER dbo.OrderInsertTrigger
   ON  Orders
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
GO