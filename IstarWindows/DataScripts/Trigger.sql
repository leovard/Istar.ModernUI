USE [IstarRealEstate]
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