USE [DboSifreliVt]
GO
/****** Object:  Table [dbo].[TBL_VERILER]    Script Date: 23.04.2019 23:18:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_VERILER](
	[ID] [smallint] IDENTITY(1,1) NOT NULL,
	[AD] [varchar](100) NULL,
	[SOYAD] [varchar](100) NULL,
	[MAIL] [varchar](100) NULL,
	[SIFRE] [varchar](100) NULL,
	[HESAPNO] [varchar](100) NULL
) ON [PRIMARY]
GO
