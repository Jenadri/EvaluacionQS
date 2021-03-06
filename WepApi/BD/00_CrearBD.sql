USE [EvaluacionQS_BD]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 30/01/2021 09:00:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cliente](
	[ClienteId] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [varchar](50) NOT NULL,
	[Apellidos] [varchar](50) NOT NULL,
	[Nic] [varchar](12) NOT NULL,
	[Categoria] [char](1) NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[ClienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DetalleFactura]    Script Date: 30/01/2021 09:00:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleFactura](
	[DetalleFacturaId] [int] IDENTITY(1,1) NOT NULL,
	[FacturaId] [int] NOT NULL,
	[ProductoId] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[PrecioUnitario] [decimal](18, 5) NOT NULL,
 CONSTRAINT [PK_DetalleFactura] PRIMARY KEY CLUSTERED 
(
	[DetalleFacturaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Factura]    Script Date: 30/01/2021 09:00:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Factura](
	[FacturaId] [int] IDENTITY(1,1) NOT NULL,
	[Serie] [varchar](3) NOT NULL,
	[Codigo] [varchar](5) NOT NULL,
	[VendedorId] [int] NOT NULL,
	[ClienteId] [int] NOT NULL,
	[Fecha] [date] NOT NULL,
	[Moneda] [char](3) NOT NULL,
 CONSTRAINT [PK_Factura] PRIMARY KEY CLUSTERED 
(
	[FacturaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 30/01/2021 09:00:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Producto](
	[ProductoId] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](80) NOT NULL,
	[PrecioUnitario] [decimal](18, 5) NOT NULL,
	[Categoria] [char](2) NOT NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[ProductoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Vendedor]    Script Date: 30/01/2021 09:00:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Vendedor](
	[VendedorId] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [varchar](50) NOT NULL,
	[Apellidos] [varchar](50) NOT NULL,
	[DNI] [char](8) NOT NULL,
	[FechaIngreso] [date] NOT NULL,
 CONSTRAINT [PK_Vendedor] PRIMARY KEY CLUSTERED 
(
	[VendedorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Cliente] ON 

GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombres], [Apellidos], [Nic], [Categoria]) VALUES (1, N'Jenner', N'Vela', N'201234567891', N'A')
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombres], [Apellidos], [Nic], [Categoria]) VALUES (2, N'Adrian', N'Inoñan', N'209876543210', N'B')
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombres], [Apellidos], [Nic], [Categoria]) VALUES (3, N'Luana', N'Vela', N'204060809010', N'A')
GO
INSERT [dbo].[Cliente] ([ClienteId], [Nombres], [Apellidos], [Nic], [Categoria]) VALUES (4, N'Edward', N'Vela', N'203040506070', N'B')
GO
SET IDENTITY_INSERT [dbo].[Cliente] OFF
GO
SET IDENTITY_INSERT [dbo].[DetalleFactura] ON 

GO
INSERT [dbo].[DetalleFactura] ([DetalleFacturaId], [FacturaId], [ProductoId], [Cantidad], [PrecioUnitario]) VALUES (1, 1, 1, 2, CAST(40.00000 AS Decimal(18, 5)))
GO
INSERT [dbo].[DetalleFactura] ([DetalleFacturaId], [FacturaId], [ProductoId], [Cantidad], [PrecioUnitario]) VALUES (2, 1, 2, 2, CAST(81.00000 AS Decimal(18, 5)))
GO
INSERT [dbo].[DetalleFactura] ([DetalleFacturaId], [FacturaId], [ProductoId], [Cantidad], [PrecioUnitario]) VALUES (3, 2, 1, 1, CAST(20.00000 AS Decimal(18, 5)))
GO
INSERT [dbo].[DetalleFactura] ([DetalleFacturaId], [FacturaId], [ProductoId], [Cantidad], [PrecioUnitario]) VALUES (4, 2, 2, 1, CAST(40.50000 AS Decimal(18, 5)))
GO
INSERT [dbo].[DetalleFactura] ([DetalleFacturaId], [FacturaId], [ProductoId], [Cantidad], [PrecioUnitario]) VALUES (5, 3, 1, 3, CAST(60.00000 AS Decimal(18, 5)))
GO
INSERT [dbo].[DetalleFactura] ([DetalleFacturaId], [FacturaId], [ProductoId], [Cantidad], [PrecioUnitario]) VALUES (6, 3, 2, 3, CAST(121.50000 AS Decimal(18, 5)))
GO
INSERT [dbo].[DetalleFactura] ([DetalleFacturaId], [FacturaId], [ProductoId], [Cantidad], [PrecioUnitario]) VALUES (7, 4, 1, 4, CAST(80.00000 AS Decimal(18, 5)))
GO
INSERT [dbo].[DetalleFactura] ([DetalleFacturaId], [FacturaId], [ProductoId], [Cantidad], [PrecioUnitario]) VALUES (8, 4, 2, 4, CAST(162.00000 AS Decimal(18, 5)))
GO
INSERT [dbo].[DetalleFactura] ([DetalleFacturaId], [FacturaId], [ProductoId], [Cantidad], [PrecioUnitario]) VALUES (9, 5, 1, 2, CAST(40.00000 AS Decimal(18, 5)))
GO
SET IDENTITY_INSERT [dbo].[DetalleFactura] OFF
GO
SET IDENTITY_INSERT [dbo].[Factura] ON 

GO
INSERT [dbo].[Factura] ([FacturaId], [Serie], [Codigo], [VendedorId], [ClienteId], [Fecha], [Moneda]) VALUES (1, N'001', N'FACT', 1, 1, CAST(N'2021-02-02' AS Date), N'SOL')
GO
INSERT [dbo].[Factura] ([FacturaId], [Serie], [Codigo], [VendedorId], [ClienteId], [Fecha], [Moneda]) VALUES (2, N'002', N'FACT', 2, 2, CAST(N'2021-02-02' AS Date), N'SOL')
GO
INSERT [dbo].[Factura] ([FacturaId], [Serie], [Codigo], [VendedorId], [ClienteId], [Fecha], [Moneda]) VALUES (3, N'003', N'FACT', 1, 2, CAST(N'2021-02-03' AS Date), N'SOL')
GO
INSERT [dbo].[Factura] ([FacturaId], [Serie], [Codigo], [VendedorId], [ClienteId], [Fecha], [Moneda]) VALUES (4, N'004', N'FACT', 2, 1, CAST(N'2021-02-03' AS Date), N'SOL')
GO
INSERT [dbo].[Factura] ([FacturaId], [Serie], [Codigo], [VendedorId], [ClienteId], [Fecha], [Moneda]) VALUES (5, N'005', N'FACT', 1, 1, CAST(N'2021-04-01' AS Date), N'SOL')
GO
SET IDENTITY_INSERT [dbo].[Factura] OFF
GO
SET IDENTITY_INSERT [dbo].[Producto] ON 

GO
INSERT [dbo].[Producto] ([ProductoId], [Descripcion], [PrecioUnitario], [Categoria]) VALUES (1, N'Producto A', CAST(20.00000 AS Decimal(18, 5)), N'A ')
GO
INSERT [dbo].[Producto] ([ProductoId], [Descripcion], [PrecioUnitario], [Categoria]) VALUES (2, N'Producto B', CAST(40.50000 AS Decimal(18, 5)), N'B ')
GO
SET IDENTITY_INSERT [dbo].[Producto] OFF
GO
SET IDENTITY_INSERT [dbo].[Vendedor] ON 

GO
INSERT [dbo].[Vendedor] ([VendedorId], [Nombres], [Apellidos], [DNI], [FechaIngreso]) VALUES (1, N'Juan', N'Perez', N'87654321', CAST(N'2019-01-01' AS Date))
GO
INSERT [dbo].[Vendedor] ([VendedorId], [Nombres], [Apellidos], [DNI], [FechaIngreso]) VALUES (2, N'Rosa', N'Quispe', N'12345678', CAST(N'2021-02-01' AS Date))
GO
SET IDENTITY_INSERT [dbo].[Vendedor] OFF
GO
ALTER TABLE [dbo].[DetalleFactura]  WITH CHECK ADD  CONSTRAINT [FK_DetalleFactura_Factura] FOREIGN KEY([FacturaId])
REFERENCES [dbo].[Factura] ([FacturaId])
GO
ALTER TABLE [dbo].[DetalleFactura] CHECK CONSTRAINT [FK_DetalleFactura_Factura]
GO
ALTER TABLE [dbo].[DetalleFactura]  WITH CHECK ADD  CONSTRAINT [FK_DetalleFactura_Producto] FOREIGN KEY([ProductoId])
REFERENCES [dbo].[Producto] ([ProductoId])
GO
ALTER TABLE [dbo].[DetalleFactura] CHECK CONSTRAINT [FK_DetalleFactura_Producto]
GO
ALTER TABLE [dbo].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_Factura_Cliente] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Cliente] ([ClienteId])
GO
ALTER TABLE [dbo].[Factura] CHECK CONSTRAINT [FK_Factura_Cliente]
GO
ALTER TABLE [dbo].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_Factura_Vendedor] FOREIGN KEY([VendedorId])
REFERENCES [dbo].[Vendedor] ([VendedorId])
GO
ALTER TABLE [dbo].[Factura] CHECK CONSTRAINT [FK_Factura_Vendedor]
GO
