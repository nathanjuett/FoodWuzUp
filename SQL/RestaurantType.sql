USE [FoodWuzUp]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[RestaurantTypes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](500) NULL,
 CONSTRAINT [PK_dbo.RestaurantTypes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


ALTER TABLE dbo.Restaurants ADD
	RestaurantTypeID int NULL
GO
ALTER TABLE dbo.Restaurants ADD CONSTRAINT
	FK_Restaurants_RestaurantTypes FOREIGN KEY
	(
	RestaurantTypeID
	) REFERENCES dbo.RestaurantTypes
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO

ALTER TABLE dbo.Restaurants ADD
	Phone nvarchar(32) NULL
GO
ALTER TABLE dbo.Restaurants ADD
	Url nvarchar(512) NULL
GO
ALTER TABLE dbo.Restaurants ADD
	Address nvarchar(512) NULL
GO