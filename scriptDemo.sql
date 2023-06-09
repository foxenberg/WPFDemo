USE [CompanyDB]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 11.11.2020 21:20:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[Id] [int] NOT NULL,
	[Firstname] [nvarchar](50) NOT NULL,
	[Lastname] [nvarchar](50) NOT NULL,
	[Patronymic] [nvarchar](50) NULL,
	[BirthDate] [date] NOT NULL,
	[PhoneNumber] [nvarchar](30) NULL,
	[Email] [nvarchar](100) NULL,
	[AddedDate] [date] NULL,
	[Photo] [varbinary](max) NULL,
	[GenderId] [int] NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClientTag]    Script Date: 11.11.2020 21:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClientTag](
	[Id] [int] NOT NULL,
	[TagId] [int] NOT NULL,
	[ClientId] [int] NOT NULL,
 CONSTRAINT [PK_ClientTag] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Gender]    Script Date: 11.11.2020 21:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gender](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tag]    Script Date: 11.11.2020 21:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tag](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Color] [nvarchar](7) NOT NULL,
 CONSTRAINT [PK_Tag] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 11.11.2020 21:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] NOT NULL,
	[Login] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Visit]    Script Date: 11.11.2020 21:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Visit](
	[Id] [int] NOT NULL,
	[ClientId] [int] NOT NULL,
	[Date] [date] NOT NULL,
 CONSTRAINT [PK_Visit] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Client] ([Id], [Firstname], [Lastname], [Patronymic], [BirthDate], [PhoneNumber], [Email], [AddedDate], [Photo], [GenderId]) VALUES (1, N'Иванов', N'Дмитрий', N'Васильевич', CAST(N'1975-06-02' AS Date), N'79332749901', N'Dmitriy.Ivanov@yandex.ru', CAST(N'2020-03-03' AS Date), NULL, 1)
INSERT [dbo].[Client] ([Id], [Firstname], [Lastname], [Patronymic], [BirthDate], [PhoneNumber], [Email], [AddedDate], [Photo], [GenderId]) VALUES (2, N'Кимов', N'Иван', N'Лионтьевич', CAST(N'1993-11-13' AS Date), N'88027468292', N'ivan_kimov@mail.ru', CAST(N'2019-12-15' AS Date), NULL, 1)
INSERT [dbo].[Client] ([Id], [Firstname], [Lastname], [Patronymic], [BirthDate], [PhoneNumber], [Email], [AddedDate], [Photo], [GenderId]) VALUES (3, N'Бурятова', N'Мария', N'Георгиевна', CAST(N'1993-09-07' AS Date), N'84269369538', N'Mariya93@gmail.com', CAST(N'2020-07-20' AS Date), NULL, 2)
INSERT [dbo].[Client] ([Id], [Firstname], [Lastname], [Patronymic], [BirthDate], [PhoneNumber], [Email], [AddedDate], [Photo], [GenderId]) VALUES (4, N'Сафиуллина', N'Камила', N'Булатовна', CAST(N'1988-01-22' AS Date), N'71160689035', N'SaffKam@yandex.ru', CAST(N'2020-05-17' AS Date), NULL, 2)
INSERT [dbo].[ClientTag] ([Id], [TagId], [ClientId]) VALUES (1, 1, 2)
INSERT [dbo].[ClientTag] ([Id], [TagId], [ClientId]) VALUES (2, 1, 3)
INSERT [dbo].[ClientTag] ([Id], [TagId], [ClientId]) VALUES (3, 1, 4)
INSERT [dbo].[ClientTag] ([Id], [TagId], [ClientId]) VALUES (4, 2, 2)
INSERT [dbo].[ClientTag] ([Id], [TagId], [ClientId]) VALUES (5, 2, 1)
INSERT [dbo].[ClientTag] ([Id], [TagId], [ClientId]) VALUES (6, 3, 4)
INSERT [dbo].[ClientTag] ([Id], [TagId], [ClientId]) VALUES (8, 3, 2)
INSERT [dbo].[ClientTag] ([Id], [TagId], [ClientId]) VALUES (9, 4, 1)
SET IDENTITY_INSERT [dbo].[Gender] ON 

INSERT [dbo].[Gender] ([Id], [Name]) VALUES (1, N'Мужчина                       ')
INSERT [dbo].[Gender] ([Id], [Name]) VALUES (2, N'Женщина                       ')
SET IDENTITY_INSERT [dbo].[Gender] OFF
INSERT [dbo].[Tag] ([Id], [Name], [Color]) VALUES (1, N'Комедия', N'AA8F66')
INSERT [dbo].[Tag] ([Id], [Name], [Color]) VALUES (2, N'Драма', N'ED9B40')
INSERT [dbo].[Tag] ([Id], [Name], [Color]) VALUES (3, N'Приключение', N'FFEEDB')
INSERT [dbo].[Tag] ([Id], [Name], [Color]) VALUES (4, N'Боевик', N'61C9A8')
INSERT [dbo].[Tag] ([Id], [Name], [Color]) VALUES (5, N'Байопик', N'BA3B46')
INSERT [dbo].[User] ([Id], [Login], [Password]) VALUES (1, N'Administrator', N'Administrator514')
INSERT [dbo].[User] ([Id], [Login], [Password]) VALUES (2, N'User', N'User6724')
INSERT [dbo].[Visit] ([Id], [ClientId], [Date]) VALUES (1, 1, CAST(N'2020-09-02' AS Date))
INSERT [dbo].[Visit] ([Id], [ClientId], [Date]) VALUES (2, 2, CAST(N'2020-09-03' AS Date))
INSERT [dbo].[Visit] ([Id], [ClientId], [Date]) VALUES (3, 3, CAST(N'2020-09-04' AS Date))
INSERT [dbo].[Visit] ([Id], [ClientId], [Date]) VALUES (4, 4, CAST(N'2020-09-05' AS Date))
INSERT [dbo].[Visit] ([Id], [ClientId], [Date]) VALUES (5, 1, CAST(N'2020-09-06' AS Date))
INSERT [dbo].[Visit] ([Id], [ClientId], [Date]) VALUES (6, 2, CAST(N'2020-09-07' AS Date))
INSERT [dbo].[Visit] ([Id], [ClientId], [Date]) VALUES (7, 3, CAST(N'2020-09-08' AS Date))
INSERT [dbo].[Visit] ([Id], [ClientId], [Date]) VALUES (8, 4, CAST(N'2020-09-09' AS Date))
ALTER TABLE [dbo].[Client]  WITH CHECK ADD FOREIGN KEY([GenderId])
REFERENCES [dbo].[Gender] ([Id])
GO
ALTER TABLE [dbo].[Client]  WITH CHECK ADD FOREIGN KEY([GenderId])
REFERENCES [dbo].[Gender] ([Id])
GO
ALTER TABLE [dbo].[ClientTag]  WITH CHECK ADD  CONSTRAINT [FK_ClientTag_Client] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Client] ([Id])
GO
ALTER TABLE [dbo].[ClientTag] CHECK CONSTRAINT [FK_ClientTag_Client]
GO
ALTER TABLE [dbo].[ClientTag]  WITH CHECK ADD  CONSTRAINT [FK_ClientTag_Tag] FOREIGN KEY([TagId])
REFERENCES [dbo].[Tag] ([Id])
GO
ALTER TABLE [dbo].[ClientTag] CHECK CONSTRAINT [FK_ClientTag_Tag]
GO
ALTER TABLE [dbo].[Visit]  WITH CHECK ADD  CONSTRAINT [FK_Visit_Client] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Client] ([Id])
GO
ALTER TABLE [dbo].[Visit] CHECK CONSTRAINT [FK_Visit_Client]
GO
