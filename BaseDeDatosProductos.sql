USE [Generacion23]
GO
/****** Object:  Table [dbo].[Departamentos]    Script Date: 25/12/2023 05:08:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departamentos](
	[idD] [int] IDENTITY(1,1) NOT NULL,
	[NombreD] [varchar](50) NULL,
 CONSTRAINT [PK_Departamentos] PRIMARY KEY CLUSTERED 
(
	[idD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Marcas]    Script Date: 25/12/2023 05:08:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marcas](
	[idM] [int] IDENTITY(1,1) NOT NULL,
	[NombreM] [varchar](50) NULL,
	[Estatus] [bit] NULL,
 CONSTRAINT [PK_Marcas] PRIMARY KEY CLUSTERED 
(
	[idM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 25/12/2023 05:08:19 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[FechaCaducidad] [date] NULL,
	[Marcaid] [int] NULL,
	[Departamentoid] [int] NULL,
 CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Departamentos] ON 

INSERT [dbo].[Departamentos] ([idD], [NombreD]) VALUES (1, N'Electronica')
INSERT [dbo].[Departamentos] ([idD], [NombreD]) VALUES (2, N'Abarrotes')
INSERT [dbo].[Departamentos] ([idD], [NombreD]) VALUES (3, N'Blancos')
SET IDENTITY_INSERT [dbo].[Departamentos] OFF
GO
SET IDENTITY_INSERT [dbo].[Marcas] ON 

INSERT [dbo].[Marcas] ([idM], [NombreM], [Estatus]) VALUES (1, N'HP', 1)
INSERT [dbo].[Marcas] ([idM], [NombreM], [Estatus]) VALUES (2, N'Gamesa', 1)
INSERT [dbo].[Marcas] ([idM], [NombreM], [Estatus]) VALUES (3, N'Coca-Cola', 1)
SET IDENTITY_INSERT [dbo].[Marcas] OFF
GO
SET IDENTITY_INSERT [dbo].[Productos] ON 

INSERT [dbo].[Productos] ([id], [Nombre], [FechaCaducidad], [Marcaid], [Departamentoid]) VALUES (1009, N'Teclado', CAST(N'2050-06-02' AS Date), 1, 1)
INSERT [dbo].[Productos] ([id], [Nombre], [FechaCaducidad], [Marcaid], [Departamentoid]) VALUES (2006, N'Monito', CAST(N'2029-02-02' AS Date), 1, 1)
INSERT [dbo].[Productos] ([id], [Nombre], [FechaCaducidad], [Marcaid], [Departamentoid]) VALUES (2014, N'Galletas', CAST(N'2024-06-02' AS Date), 2, 2)
INSERT [dbo].[Productos] ([id], [Nombre], [FechaCaducidad], [Marcaid], [Departamentoid]) VALUES (2015, N'Galletas', CAST(N'2024-01-01' AS Date), 3, 2)
INSERT [dbo].[Productos] ([id], [Nombre], [FechaCaducidad], [Marcaid], [Departamentoid]) VALUES (2018, N'mouse', CAST(N'2024-01-01' AS Date), 3, 3)
INSERT [dbo].[Productos] ([id], [Nombre], [FechaCaducidad], [Marcaid], [Departamentoid]) VALUES (2019, N'Oblea', CAST(N'2040-01-01' AS Date), 3, 2)
INSERT [dbo].[Productos] ([id], [Nombre], [FechaCaducidad], [Marcaid], [Departamentoid]) VALUES (2020, N'Chocolate', CAST(N'2024-06-02' AS Date), 2, 2)
SET IDENTITY_INSERT [dbo].[Productos] OFF
GO
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD  CONSTRAINT [FK_Productos_Departamentos] FOREIGN KEY([Departamentoid])
REFERENCES [dbo].[Departamentos] ([idD])
GO
ALTER TABLE [dbo].[Productos] CHECK CONSTRAINT [FK_Productos_Departamentos]
GO
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD  CONSTRAINT [FK_Productos_Marcas] FOREIGN KEY([Marcaid])
REFERENCES [dbo].[Marcas] ([idM])
GO
ALTER TABLE [dbo].[Productos] CHECK CONSTRAINT [FK_Productos_Marcas]
GO
