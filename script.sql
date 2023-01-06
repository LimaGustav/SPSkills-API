CREATE DATABASE [SPSkills]
GO

USE [SPSkills]
GO
/****** Object:  Table [dbo].[Competitors]    Script Date: 06/01/2023 11:36:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Competitors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdUser] [int] NOT NULL,
	[Image] [image] NULL,
	[Description] [varchar](200) NULL,
	[Birthday] [date] NULL,
 CONSTRAINT [PK_Competidores] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Expenses]    Script Date: 06/01/2023 11:36:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Expenses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdExpenseType] [int] NOT NULL,
	[IdCompetitor] [int] NOT NULL,
	[Value] [int] NOT NULL,
	[Date] [date] NOT NULL,
 CONSTRAINT [PK_Despesas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExpenseTypes]    Script Date: 06/01/2023 11:36:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExpenseTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TiposDespesa] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Frequency]    Script Date: 06/01/2023 11:36:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Frequency](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdCompetitor] [int] NOT NULL,
	[CheckIn] [datetime] NULL,
	[CheckOut] [datetime] NULL,
	[Descricao] [varchar](50) NULL,
 CONSTRAINT [PK_Frequencias] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Schools]    Script Date: 06/01/2023 11:36:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Schools](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Latitude] [float] NULL,
	[Logitude] [float] NULL,
 CONSTRAINT [PK_Escola] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Skills]    Script Date: 06/01/2023 11:36:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Skills](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](300) NULL,
 CONSTRAINT [PK_Modalidades] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 06/01/2023 11:36:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdUserType] [int] NOT NULL,
	[IdSchool] [int] NULL,
	[IdSkill] [int] NULL,
	[Name] [varchar](50) NOT NULL,
	[Cpf] [varchar](20) NULL,
	[Email] [varchar](255) NOT NULL,
	[Password] [varchar](100) NOT NULL,
	[DeviceId] [varchar](100) NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserTypes]    Script Date: 06/01/2023 11:36:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TiposUsuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Competitors] ON 
GO
INSERT [dbo].[Competitors] ([Id], [IdUser], [Image], [Description], [Birthday]) VALUES (1, 2, NULL, N'08', CAST(N'2002-01-20' AS Date))
GO
SET IDENTITY_INSERT [dbo].[Competitors] OFF
GO
SET IDENTITY_INSERT [dbo].[Frequency] ON 
GO
INSERT [dbo].[Frequency] ([Id], [IdCompetitor], [CheckIn], [CheckOut], [Descricao]) VALUES (1, 1, CAST(N'2023-01-05T08:00:00.000' AS DateTime), CAST(N'2023-01-05T17:00:00.000' AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[Frequency] OFF
GO
SET IDENTITY_INSERT [dbo].[Schools] ON 
GO
INSERT [dbo].[Schools] ([Id], [Name], [Latitude], [Logitude]) VALUES (1, N'Senai Informatica', 123456, -4657066192891861)
GO
SET IDENTITY_INSERT [dbo].[Schools] OFF
GO
SET IDENTITY_INSERT [dbo].[Skills] ON 
GO
INSERT [dbo].[Skills] ([Id], [Name], [Description]) VALUES (1, N'Soluções de Software Para Negócios', N'09')
GO
SET IDENTITY_INSERT [dbo].[Skills] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([Id], [IdUserType], [IdSchool], [IdSkill], [Name], [Cpf], [Email], [Password], [DeviceId]) VALUES (1, 1, 1, 1, N'Gustavo', N'43017102807', N'lima.gustavo100@hotmail.com', N'$2a$11$68tmo6Msex4Eo8ZduTkBI.p5QUsj3mii/CF9sdChBIXJN9h6FuZ/2', NULL)
GO
INSERT [dbo].[Users] ([Id], [IdUserType], [IdSchool], [IdSkill], [Name], [Cpf], [Email], [Password], [DeviceId]) VALUES (2, 3, 1, 1, N'Jao', N'4596847789', N'jao@email.com', N'123', NULL)
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET IDENTITY_INSERT [dbo].[UserTypes] ON 
GO
INSERT [dbo].[UserTypes] ([Id], [Name]) VALUES (1, N'Administrador')
GO
INSERT [dbo].[UserTypes] ([Id], [Name]) VALUES (2, N'Avaliador')
GO
INSERT [dbo].[UserTypes] ([Id], [Name]) VALUES (3, N'Competidor')
GO
INSERT [dbo].[UserTypes] ([Id], [Name]) VALUES (4, N'Comum')
GO
SET IDENTITY_INSERT [dbo].[UserTypes] OFF
GO
ALTER TABLE [dbo].[Competitors]  WITH CHECK ADD  CONSTRAINT [FK_Competidores_Usuarios] FOREIGN KEY([IdUser])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Competitors] CHECK CONSTRAINT [FK_Competidores_Usuarios]
GO
ALTER TABLE [dbo].[Expenses]  WITH CHECK ADD  CONSTRAINT [FK_Despesas_Competidores] FOREIGN KEY([IdCompetitor])
REFERENCES [dbo].[Competitors] ([Id])
GO
ALTER TABLE [dbo].[Expenses] CHECK CONSTRAINT [FK_Despesas_Competidores]
GO
ALTER TABLE [dbo].[Expenses]  WITH CHECK ADD  CONSTRAINT [FK_Despesas_TiposDespesa] FOREIGN KEY([IdExpenseType])
REFERENCES [dbo].[ExpenseTypes] ([Id])
GO
ALTER TABLE [dbo].[Expenses] CHECK CONSTRAINT [FK_Despesas_TiposDespesa]
GO
ALTER TABLE [dbo].[Frequency]  WITH CHECK ADD  CONSTRAINT [FK_Frequencias_Competidores] FOREIGN KEY([IdCompetitor])
REFERENCES [dbo].[Competitors] ([Id])
GO
ALTER TABLE [dbo].[Frequency] CHECK CONSTRAINT [FK_Frequencias_Competidores]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Escola] FOREIGN KEY([IdSchool])
REFERENCES [dbo].[Schools] ([Id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Usuarios_Escola]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Modalidades] FOREIGN KEY([IdSkill])
REFERENCES [dbo].[Skills] ([Id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Usuarios_Modalidades]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_TiposUsuario] FOREIGN KEY([IdUserType])
REFERENCES [dbo].[UserTypes] ([Id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Usuarios_TiposUsuario]
GO
