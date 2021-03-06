USE [OrderDB]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 11/16/2017 09:11:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[OrderName] [varchar](50) NULL,
	[CreateTime] [datetime] NULL,
	[ProductID] [int] NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON
INSERT [dbo].[Orders] ([OrderID], [OrderName], [CreateTime], [ProductID]) VALUES (17, N'我的订单！', CAST(0x0000A82D0094A5FB AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Orders] OFF
