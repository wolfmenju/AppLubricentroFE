USE [BdInguiriLubricentro]
GO
/****** Object:  Table [dbo].[Almacen]    Script Date: 11/12/2021 21:46:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Almacen](
	[IdAlmacen] [int] NOT NULL,
	[Descripcion] [varchar](150) NOT NULL,
	[Direccion] [varchar](150) NOT NULL,
	[IdSede] [int] NOT NULL,
	[UsuarioCrea] [varchar](50) NOT NULL,
	[FechaCrea] [datetime] NOT NULL,
	[UsuarioModifica] [varchar](50) NULL,
	[FechaModifica] [datetime] NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Almacen] PRIMARY KEY CLUSTERED 
(
	[IdAlmacen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AuditoriaHistorialProducto]    Script Date: 11/12/2021 21:46:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuditoriaHistorialProducto](
	[IdAuditoriaHistorialProducto] [int] NOT NULL,
	[IdHistorial] [int] NOT NULL,
	[IdProducto] [int] NOT NULL,
	[nStock] [int] NOT NULL,
	[PrecioVenta] [decimal](18, 2) NULL,
	[UsuarioCrea] [varchar](50) NOT NULL,
	[FechaCrea] [datetime] NOT NULL,
	[FechaRegistro] [datetime] NOT NULL,
	[Estado] [int] NOT NULL,
 CONSTRAINT [PK_AuditoriaHistorialProducto] PRIMARY KEY CLUSTERED 
(
	[IdAuditoriaHistorialProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Caja]    Script Date: 11/12/2021 21:46:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Caja](
	[IdCaja] [int] NOT NULL,
	[IdTurno] [int] NOT NULL,
	[UsuarioAbre] [varchar](50) NOT NULL,
	[FechaInicio] [datetime] NOT NULL,
	[MontoInicio] [decimal](18, 2) NOT NULL,
	[FechaFinal] [datetime] NULL,
	[MontoFinal] [decimal](18, 2) NOT NULL,
	[UsuarioCrea] [varchar](50) NOT NULL,
	[FechaCrea] [datetime] NOT NULL,
	[UsuarioModifica] [varchar](50) NULL,
	[FechaModifica] [datetime] NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Caja] PRIMARY KEY CLUSTERED 
(
	[IdCaja] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 11/12/2021 21:46:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[IdCategoria] [int] NOT NULL,
	[Descripcion] [varchar](150) NOT NULL,
	[UsuarioCrea] [varchar](50) NOT NULL,
	[FechaCrea] [datetime] NOT NULL,
	[UsuarioModifica] [varchar](50) NULL,
	[FechaModifica] [datetime] NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 11/12/2021 21:46:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[IdCliente] [int] NOT NULL,
	[Nombres] [varchar](350) NOT NULL,
	[TipoPersona] [bit] NOT NULL,
	[Dni] [varchar](15) NOT NULL,
	[Direccion] [varchar](350) NOT NULL,
	[Celular] [varchar](10) NOT NULL,
	[UsuarioCrea] [varchar](50) NOT NULL,
	[FechaCrea] [datetime] NOT NULL,
	[UsuarioModifica] [varchar](50) NULL,
	[FechaModifica] [datetime] NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Compra]    Script Date: 11/12/2021 21:46:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Compra](
	[IdCompra] [int] NOT NULL,
	[IdAlmacen] [int] NOT NULL,
	[IdDocumento] [varchar](2) NOT NULL,
	[Serie] [varchar](10) NOT NULL,
	[Numero] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Porcentaje] [int] NOT NULL,
	[SubTotal] [decimal](18, 2) NOT NULL,
	[Igv] [decimal](18, 2) NOT NULL,
	[Total] [decimal](18, 2) NOT NULL,
	[IdProveedor] [int] NOT NULL,
	[Credito] [bit] NOT NULL,
	[Dias] [int] NULL,
	[UsuarioCrea] [varchar](50) NOT NULL,
	[FechaCrea] [datetime] NOT NULL,
	[UsuarioModifica] [varchar](50) NULL,
	[FechaModifica] [datetime] NULL,
	[Estado] [int] NOT NULL,
 CONSTRAINT [PK_Compra] PRIMARY KEY CLUSTERED 
(
	[IdCompra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleCompra]    Script Date: 11/12/2021 21:46:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleCompra](
	[IdDetalleCompra] [int] NOT NULL,
	[IdCompra] [int] NOT NULL,
	[IdTarjeta] [int] NULL,
	[IdProducto] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[Precio] [decimal](18, 2) NOT NULL,
	[Ganancia] [decimal](18, 2) NOT NULL,
	[Lote] [varchar](50) NOT NULL,
	[UsuarioCrea] [varchar](50) NOT NULL,
	[FechaCrea] [datetime] NOT NULL,
	[UsuarioModifica] [varchar](50) NULL,
	[FechaModifica] [datetime] NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_DetalleCompra] PRIMARY KEY CLUSTERED 
(
	[IdDetalleCompra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleDeuda]    Script Date: 11/12/2021 21:46:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleDeuda](
	[IdDetalleDeuda] [int] NOT NULL,
	[IdDeuda] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Observacion] [varchar](500) NULL,
	[Monto] [decimal](18, 2) NOT NULL,
	[UsuarioCrea] [varchar](50) NOT NULL,
	[FechaCrea] [datetime] NOT NULL,
	[UsuarioModifica] [varchar](50) NULL,
	[FechaModifica] [datetime] NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_DetalleDeuda] PRIMARY KEY CLUSTERED 
(
	[IdDetalleDeuda] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleInventario]    Script Date: 11/12/2021 21:46:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleInventario](
	[IdDetalleInventario] [int] NOT NULL,
	[IdInventario] [int] NOT NULL,
	[IdProducto] [int] NOT NULL,
	[Lote] [varchar](20) NULL,
	[Vencimiento] [datetime] NULL,
	[Stock] [int] NULL,
	[PrecioCompra] [decimal](18, 2) NULL,
	[Ganancia] [decimal](18, 2) NULL,
	[PrecioVenta] [decimal](18, 2) NULL,
	[UsuarioCrea] [varchar](50) NOT NULL,
	[FechaCrea] [datetime] NOT NULL,
	[UsuarioModifica] [varchar](50) NULL,
	[FechaModifica] [datetime] NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_DetalleInventario] PRIMARY KEY CLUSTERED 
(
	[IdDetalleInventario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetallePedido]    Script Date: 11/12/2021 21:46:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetallePedido](
	[IdDetallePedido] [int] NOT NULL,
	[IdPedido] [int] NULL,
	[IdProducto] [int] NOT NULL,
	[IdTarjeta] [int] NULL,
	[Cantidad] [decimal](18, 2) NOT NULL,
	[PrecioCompra] [decimal](18, 2) NOT NULL,
	[Ganancia] [decimal](18, 2) NOT NULL,
	[PrecioVenta] [decimal](18, 2) NOT NULL,
	[Lote] [varchar](50) NULL,
	[Fecha] [datetime] NULL,
	[UsuarioCrea] [varchar](50) NOT NULL,
	[FechaCrea] [datetime] NOT NULL,
	[UsuarioModifica] [varchar](50) NULL,
	[FechaModifica] [datetime] NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_DetallePedido] PRIMARY KEY CLUSTERED 
(
	[IdDetallePedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleSalida]    Script Date: 11/12/2021 21:46:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleSalida](
	[IdDetalleSalida] [int] NOT NULL,
	[IdSalida] [int] NOT NULL,
	[IdTarjeta] [int] NULL,
	[IdProducto] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[Precio] [decimal](18, 2) NOT NULL,
	[Ganancia] [decimal](18, 2) NOT NULL,
	[Lote] [varchar](50) NULL,
	[Descuento] [decimal](18, 2) NOT NULL,
	[Total] [decimal](18, 2) NOT NULL,
	[UsuarioCrea] [varchar](50) NOT NULL,
	[FechaCrea] [datetime] NOT NULL,
	[UsuarioModifica] [varchar](50) NULL,
	[FechaModifica] [datetime] NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_DetalleSalida] PRIMARY KEY CLUSTERED 
(
	[IdDetalleSalida] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleTransferencia]    Script Date: 11/12/2021 21:46:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleTransferencia](
	[IdDetalleTransferencia] [int] NOT NULL,
	[IdTransferencia] [int] NOT NULL,
	[IdProducto] [int] NOT NULL,
	[IdTarjeta] [int] NOT NULL,
	[IdTarjetaDestino] [int] NOT NULL,
	[Lote] [varchar](50) NOT NULL,
	[PrecioVenta] [decimal](18, 2) NOT NULL,
	[Ganancia] [decimal](18, 2) NOT NULL,
	[PrecioCompra] [decimal](18, 2) NOT NULL,
	[UsuarioCrea] [varchar](50) NOT NULL,
	[FechaCrea] [datetime] NOT NULL,
	[UsuarioModifica] [varchar](50) NULL,
	[FechaModifica] [datetime] NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_DetalleTransferencia] PRIMARY KEY CLUSTERED 
(
	[IdDetalleTransferencia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleVenta]    Script Date: 11/12/2021 21:46:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleVenta](
	[IdDetalleVenta] [int] NOT NULL,
	[IdVenta] [int] NOT NULL,
	[IdTarjeta] [int] NULL,
	[IdProducto] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[Precio] [decimal](18, 2) NOT NULL,
	[Ganancia] [decimal](18, 2) NOT NULL,
	[Lote] [varchar](50) NULL,
	[Descuento] [decimal](18, 2) NOT NULL,
	[Total] [decimal](18, 2) NOT NULL,
	[UsuarioCrea] [varchar](50) NOT NULL,
	[FechaCrea] [datetime] NOT NULL,
	[UsuarioModifica] [varchar](50) NULL,
	[FechaModifica] [datetime] NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_DetalleVenta] PRIMARY KEY CLUSTERED 
(
	[IdDetalleVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Deuda]    Script Date: 11/12/2021 21:46:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Deuda](
	[IdDeuda] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[FechaPago] [datetime] NOT NULL,
	[IdProveedor] [int] NOT NULL,
	[IdReferencia] [int] NOT NULL,
	[Entrada] [bit] NOT NULL,
	[IdDocumento] [varchar](2) NOT NULL,
	[Serie] [varchar](10) NOT NULL,
	[Numero] [int] NOT NULL,
	[Monto] [decimal](18, 2) NOT NULL,
	[Saldo] [decimal](18, 2) NOT NULL,
	[UsuarioCrea] [varchar](50) NOT NULL,
	[FechaCrea] [datetime] NOT NULL,
	[UsuarioModifica] [varchar](50) NULL,
	[FechaModifica] [datetime] NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Deuda] PRIMARY KEY CLUSTERED 
(
	[IdDeuda] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Documento]    Script Date: 11/12/2021 21:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Documento](
	[IdDocumento] [varchar](2) NOT NULL,
	[Descripcion] [varchar](100) NOT NULL,
	[Abreviatura] [varchar](15) NOT NULL,
	[UsuarioCrea] [varchar](50) NOT NULL,
	[FechaCrea] [datetime] NOT NULL,
	[UsuarioModifica] [varchar](50) NULL,
	[FechaModifica] [datetime] NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Documento] PRIMARY KEY CLUSTERED 
(
	[IdDocumento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DocumentoSerie]    Script Date: 11/12/2021 21:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DocumentoSerie](
	[IdDocumentoSerie] [int] NOT NULL,
	[IdDocumento] [varchar](2) NOT NULL,
	[Serie] [varchar](10) NOT NULL,
	[Ultimo] [int] NOT NULL,
	[UsuarioCrea] [varchar](50) NOT NULL,
	[FechaCrea] [datetime] NOT NULL,
	[UsuarioModifica] [varchar](50) NULL,
	[FechaModifica] [datetime] NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_DocumentoSerie] PRIMARY KEY CLUSTERED 
(
	[IdDocumentoSerie] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HistorialProducto]    Script Date: 11/12/2021 21:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HistorialProducto](
	[IdHistorial] [int] NOT NULL,
	[IdProducto] [int] NOT NULL,
	[IdAlmacen] [int] NOT NULL,
	[Lote] [varchar](50) NULL,
	[PrecioCompra] [decimal](18, 2) NOT NULL,
	[Ganancia] [decimal](18, 2) NOT NULL,
	[PrecioVenta] [decimal](18, 2) NOT NULL,
	[Stock] [int] NOT NULL,
	[Vencimiento] [datetime] NULL,
	[UsuarioCrea] [varchar](50) NOT NULL,
	[FechaCrea] [datetime] NOT NULL,
	[UsuarioModifica] [varchar](50) NULL,
	[FechaModifica] [datetime] NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_HistorialProducto] PRIMARY KEY CLUSTERED 
(
	[IdHistorial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HistorialServicio]    Script Date: 11/12/2021 21:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HistorialServicio](
	[IdHistorialServicio] [int] NOT NULL,
	[IdServicio] [int] NOT NULL,
	[PrecioActual] [decimal](18, 2) NOT NULL,
	[PrecioAntiguo] [decimal](18, 2) NOT NULL,
	[UsuarioCrea] [varchar](50) NOT NULL,
	[FechaCrea] [datetime] NOT NULL,
	[UsuarioModifica] [varchar](50) NULL,
	[FechaModifica] [datetime] NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_HistorialServicio] PRIMARY KEY CLUSTERED 
(
	[IdHistorialServicio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inventario]    Script Date: 11/12/2021 21:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventario](
	[IdInventario] [int] NOT NULL,
	[Item] [int] NOT NULL,
	[FechaInicia] [datetime] NOT NULL,
	[FechaFin] [datetime] NULL,
	[IdAlmacen] [int] NOT NULL,
	[UsuarioCrea] [varchar](50) NOT NULL,
	[FechaCrea] [datetime] NOT NULL,
	[UsuarioModifica] [varchar](50) NULL,
	[FechaModifica] [datetime] NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Inventario] PRIMARY KEY CLUSTERED 
(
	[IdInventario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Laboratorio]    Script Date: 11/12/2021 21:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Laboratorio](
	[IdLaboratorio] [int] NOT NULL,
	[Descripcion] [varchar](150) NOT NULL,
	[UsuarioCrea] [varchar](50) NOT NULL,
	[FechaCrea] [datetime] NOT NULL,
	[UsuarioModifica] [varchar](50) NULL,
	[FechaModifica] [datetime] NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Laboratorio] PRIMARY KEY CLUSTERED 
(
	[IdLaboratorio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menu]    Script Date: 11/12/2021 21:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[IdMenu] [int] NOT NULL,
	[Descripcion] [varchar](250) NOT NULL,
	[Tag] [varchar](10) NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Menu] PRIMARY KEY CLUSTERED 
(
	[IdMenu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MovimientoCaja]    Script Date: 11/12/2021 21:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MovimientoCaja](
	[IdMovimiento] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[IdReferencia] [int] NULL,
	[Entrada] [bit] NOT NULL,
	[IdDocumento] [varchar](2) NOT NULL,
	[Serie] [varchar](10) NOT NULL,
	[Numero] [int] NOT NULL,
	[Monto] [decimal](18, 2) NOT NULL,
	[UsuarioCrea] [varchar](50) NOT NULL,
	[FechaCrea] [datetime] NOT NULL,
	[UsuarioModifica] [varchar](50) NULL,
	[FechaModifica] [datetime] NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_MovimientoCaja] PRIMARY KEY CLUSTERED 
(
	[IdMovimiento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PaqueteServicio]    Script Date: 11/12/2021 21:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaqueteServicio](
	[IdPaqueteServicio] [int] NOT NULL,
	[IdPaquete] [int] NOT NULL,
	[IdServicio] [int] NOT NULL,
	[UsuarioCrea] [varchar](50) NOT NULL,
	[FechaCrea] [datetime] NOT NULL,
	[UsuarioModifica] [varchar](50) NULL,
	[FechaModifica] [datetime] NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_PaqueteServicio] PRIMARY KEY CLUSTERED 
(
	[IdPaqueteServicio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Parametros]    Script Date: 11/12/2021 21:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Parametros](
	[IdParametro] [int] NOT NULL,
	[Clave] [varchar](100) NOT NULL,
	[Valor] [varchar](100) NOT NULL,
	[Descripcion] [varchar](500) NOT NULL,
	[UsuarioCrea] [varchar](50) NOT NULL,
	[FechaCrea] [datetime] NOT NULL,
	[UsuarioModifica] [varchar](50) NULL,
	[FechaModifica] [datetime] NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Parametros] PRIMARY KEY CLUSTERED 
(
	[IdParametro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pedido]    Script Date: 11/12/2021 21:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedido](
	[IdPedido] [int] NOT NULL,
	[IdAlmacen] [int] NOT NULL,
	[Numero] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Porcentaje] [decimal](18, 2) NOT NULL,
	[SubTotal] [decimal](18, 2) NOT NULL,
	[Igv] [decimal](18, 2) NOT NULL,
	[Total] [decimal](18, 2) NOT NULL,
	[IdCliente] [int] NOT NULL,
	[Nombre] [varchar](250) NOT NULL,
	[UsuarioCrea] [varchar](50) NOT NULL,
	[FechaCrea] [datetime] NOT NULL,
	[UsuarioModifica] [varchar](50) NULL,
	[FechaModifica] [datetime] NULL,
	[Estado] [tinyint] NOT NULL,
 CONSTRAINT [PK_Pedido] PRIMARY KEY CLUSTERED 
(
	[IdPedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permiso]    Script Date: 11/12/2021 21:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permiso](
	[IdPermiso] [int] NOT NULL,
	[IdMenu] [int] NOT NULL,
	[IdUsuario] [varchar](50) NOT NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Permiso] PRIMARY KEY CLUSTERED 
(
	[IdPermiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Presentacion]    Script Date: 11/12/2021 21:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Presentacion](
	[IdPresentacion] [int] NOT NULL,
	[Descripcion] [varchar](150) NOT NULL,
	[UsuarioCrea] [varchar](50) NOT NULL,
	[FechaCrea] [datetime] NOT NULL,
	[UsuarioModifica] [varchar](50) NULL,
	[FechaModifica] [datetime] NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Presentacion] PRIMARY KEY CLUSTERED 
(
	[IdPresentacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 11/12/2021 21:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[IdProducto] [int] NOT NULL,
	[PrincipioActivo] [varchar](5000) NOT NULL,
	[IdLaboratorio] [int] NOT NULL,
	[IdPresenta] [int] NOT NULL,
	[Alternativo] [bit] NOT NULL,
	[StockMinimo] [int] NOT NULL,
	[UsuarioCrea] [varchar](50) NOT NULL,
	[FechaCrea] [datetime] NOT NULL,
	[UsuarioModifica] [varchar](50) NULL,
	[FechaModifica] [datetime] NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductoFinal]    Script Date: 11/12/2021 21:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductoFinal](
	[IdProducto] [int] NOT NULL,
	[CodigoInterno] [varchar](5) NOT NULL,
	[Descripcion] [varchar](5000) NOT NULL,
	[UsuarioCrea] [varchar](50) NOT NULL,
	[FechaCrea] [datetime] NOT NULL,
	[UsuarioModifica] [varchar](50) NULL,
	[FechaModifica] [datetime] NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_ProductoFinal] PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proveedor]    Script Date: 11/12/2021 21:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proveedor](
	[IdProveedor] [int] NOT NULL,
	[RazonSocial] [varchar](500) NOT NULL,
	[Ruc] [varchar](15) NOT NULL,
	[Direccion] [varchar](350) NOT NULL,
	[Celular] [varchar](10) NOT NULL,
	[Contacto] [varchar](100) NOT NULL,
	[UsuarioCrea] [varchar](50) NOT NULL,
	[FechaCrea] [datetime] NOT NULL,
	[UsuarioModifica] [varchar](50) NULL,
	[FechaModifica] [datetime] NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Proveedor] PRIMARY KEY CLUSTERED 
(
	[IdProveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Salida]    Script Date: 11/12/2021 21:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Salida](
	[IdSalida] [int] NOT NULL,
	[IdAlmacen] [int] NOT NULL,
	[IdPedido] [int] NULL,
	[IdDocumento] [varchar](2) NOT NULL,
	[Serie] [varchar](10) NOT NULL,
	[Numero] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Porcentaje] [decimal](18, 2) NOT NULL,
	[SubTotal] [decimal](18, 2) NOT NULL,
	[Igv] [decimal](18, 2) NOT NULL,
	[Total] [decimal](18, 2) NOT NULL,
	[IdProveedor] [int] NOT NULL,
	[Nombre] [varchar](250) NOT NULL,
	[UsuarioCrea] [varchar](50) NOT NULL,
	[FechaCrea] [datetime] NOT NULL,
	[UsuarioModifica] [varchar](50) NULL,
	[FechaModifica] [datetime] NULL,
	[Estado] [int] NOT NULL,
 CONSTRAINT [PK_Salida] PRIMARY KEY CLUSTERED 
(
	[IdSalida] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sede]    Script Date: 11/12/2021 21:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sede](
	[IdSede] [int] NOT NULL,
	[Descripcion] [varchar](150) NOT NULL,
	[Direccion] [varchar](150) NOT NULL,
	[UsuarioCrea] [varchar](50) NOT NULL,
	[FechaCrea] [datetime] NOT NULL,
	[UsuarioModifica] [varchar](50) NULL,
	[FechaModifica] [datetime] NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Sede] PRIMARY KEY CLUSTERED 
(
	[IdSede] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Servicio]    Script Date: 11/12/2021 21:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Servicio](
	[IdServicio] [int] NOT NULL,
	[Precio] [decimal](18, 2) NOT NULL,
	[Paquete] [bit] NOT NULL,
	[UsuarioCrea] [varchar](50) NOT NULL,
	[FechaCrea] [datetime] NOT NULL,
	[UsuarioModifica] [varchar](50) NULL,
	[FechaModifica] [datetime] NULL,
 CONSTRAINT [PK_Servicio] PRIMARY KEY CLUSTERED 
(
	[IdServicio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tarjeta]    Script Date: 11/12/2021 21:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tarjeta](
	[IdTarjeta] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[IdHistorial] [int] NULL,
	[IdAlmacen] [int] NOT NULL,
	[TipoMovimiento] [int] NOT NULL,
	[IdReferencia] [int] NULL,
	[Lote] [varchar](50) NULL,
	[Vencimiento] [datetime] NULL,
	[IdDocumento] [varchar](2) NULL,
	[Serie] [varchar](10) NULL,
	[Numero] [int] NULL,
	[IdProducto] [int] NOT NULL,
	[Entrada] [int] NOT NULL,
	[Salida] [int] NOT NULL,
	[Existencia] [int] NOT NULL,
	[PrecioCompra] [decimal](18, 2) NOT NULL,
	[PrecioVenta] [decimal](18, 2) NOT NULL,
	[Debe] [decimal](18, 2) NOT NULL,
	[Haber] [decimal](18, 2) NOT NULL,
	[Saldo] [decimal](18, 2) NOT NULL,
	[UsuarioCrea] [varchar](50) NOT NULL,
	[FechaCrea] [datetime] NOT NULL,
	[UsuarioModifica] [varchar](50) NULL,
	[FechaModifica] [datetime] NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Tarjeta] PRIMARY KEY CLUSTERED 
(
	[IdTarjeta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transferencia]    Script Date: 11/12/2021 21:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transferencia](
	[IdTransferencia] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[IdAlmacenOrigen] [int] NOT NULL,
	[IdAlmacenDestino] [int] NOT NULL,
	[IdDocumento] [varchar](2) NOT NULL,
	[Serie] [varchar](10) NOT NULL,
	[Numero] [int] NOT NULL,
	[UsuarioCrea] [varchar](50) NOT NULL,
	[FechaCrea] [datetime] NOT NULL,
	[UsuarioModifica] [varchar](50) NULL,
	[FechaModifica] [datetime] NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Transferencia] PRIMARY KEY CLUSTERED 
(
	[IdTransferencia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UnidadMedida]    Script Date: 11/12/2021 21:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UnidadMedida](
	[IdUnidad] [int] NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
	[UsuarioCrea] [varchar](50) NOT NULL,
	[FechaCrea] [datetime] NOT NULL,
	[UsuarioModifica] [varchar](50) NULL,
	[FechaModifica] [datetime] NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_UnidadMedida] PRIMARY KEY CLUSTERED 
(
	[IdUnidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 11/12/2021 21:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[IdUsuario] [int] NOT NULL,
	[Nombres] [varchar](300) NOT NULL,
	[Dni] [varchar](10) NOT NULL,
	[Direccion] [varchar](250) NOT NULL,
	[Celular] [varchar](10) NULL,
	[Login] [varchar](50) NOT NULL,
	[Clave] [varbinary](8000) NOT NULL,
	[UsuarioCrea] [varchar](50) NOT NULL,
	[FechaCrea] [datetime] NOT NULL,
	[UsuarioModifica] [varchar](50) NULL,
	[FechaModifica] [datetime] NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Venta]    Script Date: 11/12/2021 21:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Venta](
	[IdVenta] [int] NOT NULL,
	[IdAlmacen] [int] NOT NULL,
	[IdPedido] [int] NULL,
	[IdDocumento] [varchar](2) NOT NULL,
	[Serie] [varchar](10) NOT NULL,
	[Numero] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Porcentaje] [decimal](18, 2) NOT NULL,
	[SubTotal] [decimal](18, 2) NOT NULL,
	[Igv] [decimal](18, 2) NOT NULL,
	[Total] [decimal](18, 2) NOT NULL,
	[IdCliente] [int] NOT NULL,
	[Nombre] [varchar](250) NOT NULL,
	[IdVendedor] [varchar](50) NULL,
	[IdCajero] [varchar](50) NULL,
	[UsuarioCrea] [varchar](50) NOT NULL,
	[FechaCrea] [datetime] NOT NULL,
	[UsuarioModifica] [varchar](50) NULL,
	[FechaModifica] [datetime] NULL,
	[Estado] [int] NOT NULL,
 CONSTRAINT [PK_Venta] PRIMARY KEY CLUSTERED 
(
	[IdVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Almacen]  WITH CHECK ADD  CONSTRAINT [FK_Almacen_Sede] FOREIGN KEY([IdSede])
REFERENCES [dbo].[Sede] ([IdSede])
GO
ALTER TABLE [dbo].[Almacen] CHECK CONSTRAINT [FK_Almacen_Sede]
GO
ALTER TABLE [dbo].[Compra]  WITH CHECK ADD  CONSTRAINT [FK_Compra_Almacen] FOREIGN KEY([IdAlmacen])
REFERENCES [dbo].[Almacen] ([IdAlmacen])
GO
ALTER TABLE [dbo].[Compra] CHECK CONSTRAINT [FK_Compra_Almacen]
GO
ALTER TABLE [dbo].[Compra]  WITH CHECK ADD  CONSTRAINT [FK_Compra_Documento] FOREIGN KEY([IdDocumento])
REFERENCES [dbo].[Documento] ([IdDocumento])
GO
ALTER TABLE [dbo].[Compra] CHECK CONSTRAINT [FK_Compra_Documento]
GO
ALTER TABLE [dbo].[Compra]  WITH CHECK ADD  CONSTRAINT [FK_Compra_Proveedor] FOREIGN KEY([IdProveedor])
REFERENCES [dbo].[Proveedor] ([IdProveedor])
GO
ALTER TABLE [dbo].[Compra] CHECK CONSTRAINT [FK_Compra_Proveedor]
GO
ALTER TABLE [dbo].[DetalleCompra]  WITH CHECK ADD  CONSTRAINT [FK_DetalleCompra_Compra] FOREIGN KEY([IdCompra])
REFERENCES [dbo].[Compra] ([IdCompra])
GO
ALTER TABLE [dbo].[DetalleCompra] CHECK CONSTRAINT [FK_DetalleCompra_Compra]
GO
ALTER TABLE [dbo].[DetalleCompra]  WITH CHECK ADD  CONSTRAINT [FK_DetalleCompra_Producto] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Producto] ([IdProducto])
GO
ALTER TABLE [dbo].[DetalleCompra] CHECK CONSTRAINT [FK_DetalleCompra_Producto]
GO
ALTER TABLE [dbo].[DetalleCompra]  WITH CHECK ADD  CONSTRAINT [FK_DetalleCompra_Tarjeta] FOREIGN KEY([IdTarjeta])
REFERENCES [dbo].[Tarjeta] ([IdTarjeta])
GO
ALTER TABLE [dbo].[DetalleCompra] CHECK CONSTRAINT [FK_DetalleCompra_Tarjeta]
GO
ALTER TABLE [dbo].[DetalleDeuda]  WITH CHECK ADD  CONSTRAINT [FK_DetalleDeuda_Deuda] FOREIGN KEY([IdDeuda])
REFERENCES [dbo].[Deuda] ([IdDeuda])
GO
ALTER TABLE [dbo].[DetalleDeuda] CHECK CONSTRAINT [FK_DetalleDeuda_Deuda]
GO
ALTER TABLE [dbo].[DetalleInventario]  WITH CHECK ADD  CONSTRAINT [FK_DetalleInventario_Inventario] FOREIGN KEY([IdInventario])
REFERENCES [dbo].[Inventario] ([IdInventario])
GO
ALTER TABLE [dbo].[DetalleInventario] CHECK CONSTRAINT [FK_DetalleInventario_Inventario]
GO
ALTER TABLE [dbo].[DetalleInventario]  WITH CHECK ADD  CONSTRAINT [FK_DetalleInventario_Producto] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Producto] ([IdProducto])
GO
ALTER TABLE [dbo].[DetalleInventario] CHECK CONSTRAINT [FK_DetalleInventario_Producto]
GO
ALTER TABLE [dbo].[DetalleSalida]  WITH CHECK ADD  CONSTRAINT [FK_DetalleSalida_ProductoFinal] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[ProductoFinal] ([IdProducto])
GO
ALTER TABLE [dbo].[DetalleSalida] CHECK CONSTRAINT [FK_DetalleSalida_ProductoFinal]
GO
ALTER TABLE [dbo].[DetalleSalida]  WITH CHECK ADD  CONSTRAINT [FK_DetalleSalida_Salida1] FOREIGN KEY([IdSalida])
REFERENCES [dbo].[Salida] ([IdSalida])
GO
ALTER TABLE [dbo].[DetalleSalida] CHECK CONSTRAINT [FK_DetalleSalida_Salida1]
GO
ALTER TABLE [dbo].[DetalleSalida]  WITH CHECK ADD  CONSTRAINT [FK_DetalleSalida_Tarjeta] FOREIGN KEY([IdTarjeta])
REFERENCES [dbo].[Tarjeta] ([IdTarjeta])
GO
ALTER TABLE [dbo].[DetalleSalida] CHECK CONSTRAINT [FK_DetalleSalida_Tarjeta]
GO
ALTER TABLE [dbo].[DetalleTransferencia]  WITH CHECK ADD  CONSTRAINT [FK_DetalleTransferencia_Producto] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Producto] ([IdProducto])
GO
ALTER TABLE [dbo].[DetalleTransferencia] CHECK CONSTRAINT [FK_DetalleTransferencia_Producto]
GO
ALTER TABLE [dbo].[DetalleTransferencia]  WITH CHECK ADD  CONSTRAINT [FK_DetalleTransferencia_Transferencia] FOREIGN KEY([IdTransferencia])
REFERENCES [dbo].[Transferencia] ([IdTransferencia])
GO
ALTER TABLE [dbo].[DetalleTransferencia] CHECK CONSTRAINT [FK_DetalleTransferencia_Transferencia]
GO
ALTER TABLE [dbo].[DetalleVenta]  WITH CHECK ADD  CONSTRAINT [FK_DetalleVenta_ProductoFinal] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[ProductoFinal] ([IdProducto])
GO
ALTER TABLE [dbo].[DetalleVenta] CHECK CONSTRAINT [FK_DetalleVenta_ProductoFinal]
GO
ALTER TABLE [dbo].[DetalleVenta]  WITH CHECK ADD  CONSTRAINT [FK_DetalleVenta_Tarjeta] FOREIGN KEY([IdTarjeta])
REFERENCES [dbo].[Tarjeta] ([IdTarjeta])
GO
ALTER TABLE [dbo].[DetalleVenta] CHECK CONSTRAINT [FK_DetalleVenta_Tarjeta]
GO
ALTER TABLE [dbo].[DetalleVenta]  WITH CHECK ADD  CONSTRAINT [FK_DetalleVenta_Venta1] FOREIGN KEY([IdVenta])
REFERENCES [dbo].[Venta] ([IdVenta])
GO
ALTER TABLE [dbo].[DetalleVenta] CHECK CONSTRAINT [FK_DetalleVenta_Venta1]
GO
ALTER TABLE [dbo].[DocumentoSerie]  WITH CHECK ADD  CONSTRAINT [FK_DocumentoSerie_Documento] FOREIGN KEY([IdDocumento])
REFERENCES [dbo].[Documento] ([IdDocumento])
GO
ALTER TABLE [dbo].[DocumentoSerie] CHECK CONSTRAINT [FK_DocumentoSerie_Documento]
GO
ALTER TABLE [dbo].[HistorialProducto]  WITH CHECK ADD  CONSTRAINT [FK_HistorialProducto_Almacen] FOREIGN KEY([IdAlmacen])
REFERENCES [dbo].[Almacen] ([IdAlmacen])
GO
ALTER TABLE [dbo].[HistorialProducto] CHECK CONSTRAINT [FK_HistorialProducto_Almacen]
GO
ALTER TABLE [dbo].[HistorialProducto]  WITH CHECK ADD  CONSTRAINT [FK_HistorialProducto_Producto] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Producto] ([IdProducto])
GO
ALTER TABLE [dbo].[HistorialProducto] CHECK CONSTRAINT [FK_HistorialProducto_Producto]
GO
ALTER TABLE [dbo].[HistorialServicio]  WITH CHECK ADD  CONSTRAINT [FK_HistorialServicio_Servicio] FOREIGN KEY([IdServicio])
REFERENCES [dbo].[Servicio] ([IdServicio])
GO
ALTER TABLE [dbo].[HistorialServicio] CHECK CONSTRAINT [FK_HistorialServicio_Servicio]
GO
ALTER TABLE [dbo].[Inventario]  WITH CHECK ADD  CONSTRAINT [FK_Inventario_Almacen] FOREIGN KEY([IdAlmacen])
REFERENCES [dbo].[Almacen] ([IdAlmacen])
GO
ALTER TABLE [dbo].[Inventario] CHECK CONSTRAINT [FK_Inventario_Almacen]
GO
ALTER TABLE [dbo].[MovimientoCaja]  WITH CHECK ADD  CONSTRAINT [FK_MovimientoCaja_Documento] FOREIGN KEY([IdDocumento])
REFERENCES [dbo].[Documento] ([IdDocumento])
GO
ALTER TABLE [dbo].[MovimientoCaja] CHECK CONSTRAINT [FK_MovimientoCaja_Documento]
GO
ALTER TABLE [dbo].[PaqueteServicio]  WITH CHECK ADD  CONSTRAINT [FK_PaqueteServicio_Servicio] FOREIGN KEY([IdPaquete])
REFERENCES [dbo].[Servicio] ([IdServicio])
GO
ALTER TABLE [dbo].[PaqueteServicio] CHECK CONSTRAINT [FK_PaqueteServicio_Servicio]
GO
ALTER TABLE [dbo].[PaqueteServicio]  WITH CHECK ADD  CONSTRAINT [FK_PaqueteServicio_Servicio1] FOREIGN KEY([IdServicio])
REFERENCES [dbo].[Servicio] ([IdServicio])
GO
ALTER TABLE [dbo].[PaqueteServicio] CHECK CONSTRAINT [FK_PaqueteServicio_Servicio1]
GO
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Pedido_Cliente] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([IdCliente])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_Pedido_Cliente]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Laboratorio] FOREIGN KEY([IdLaboratorio])
REFERENCES [dbo].[Laboratorio] ([IdLaboratorio])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_Laboratorio]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_ProductoFinal] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[ProductoFinal] ([IdProducto])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_ProductoFinal]
GO
ALTER TABLE [dbo].[Salida]  WITH CHECK ADD  CONSTRAINT [FK_Salida_Almacen] FOREIGN KEY([IdAlmacen])
REFERENCES [dbo].[Almacen] ([IdAlmacen])
GO
ALTER TABLE [dbo].[Salida] CHECK CONSTRAINT [FK_Salida_Almacen]
GO
ALTER TABLE [dbo].[Salida]  WITH CHECK ADD  CONSTRAINT [FK_Salida_Documento] FOREIGN KEY([IdDocumento])
REFERENCES [dbo].[Documento] ([IdDocumento])
GO
ALTER TABLE [dbo].[Salida] CHECK CONSTRAINT [FK_Salida_Documento]
GO
ALTER TABLE [dbo].[Salida]  WITH CHECK ADD  CONSTRAINT [FK_Salida_Proveedor] FOREIGN KEY([IdProveedor])
REFERENCES [dbo].[Proveedor] ([IdProveedor])
GO
ALTER TABLE [dbo].[Salida] CHECK CONSTRAINT [FK_Salida_Proveedor]
GO
ALTER TABLE [dbo].[Servicio]  WITH CHECK ADD  CONSTRAINT [FK_Servicio_ProductoFinal] FOREIGN KEY([IdServicio])
REFERENCES [dbo].[ProductoFinal] ([IdProducto])
GO
ALTER TABLE [dbo].[Servicio] CHECK CONSTRAINT [FK_Servicio_ProductoFinal]
GO
ALTER TABLE [dbo].[Tarjeta]  WITH CHECK ADD  CONSTRAINT [FK_Tarjeta_Almacen] FOREIGN KEY([IdAlmacen])
REFERENCES [dbo].[Almacen] ([IdAlmacen])
GO
ALTER TABLE [dbo].[Tarjeta] CHECK CONSTRAINT [FK_Tarjeta_Almacen]
GO
ALTER TABLE [dbo].[Tarjeta]  WITH CHECK ADD  CONSTRAINT [FK_Tarjeta_Documento] FOREIGN KEY([IdDocumento])
REFERENCES [dbo].[Documento] ([IdDocumento])
GO
ALTER TABLE [dbo].[Tarjeta] CHECK CONSTRAINT [FK_Tarjeta_Documento]
GO
ALTER TABLE [dbo].[Tarjeta]  WITH CHECK ADD  CONSTRAINT [FK_Tarjeta_HistorialProducto] FOREIGN KEY([IdHistorial])
REFERENCES [dbo].[HistorialProducto] ([IdHistorial])
GO
ALTER TABLE [dbo].[Tarjeta] CHECK CONSTRAINT [FK_Tarjeta_HistorialProducto]
GO
ALTER TABLE [dbo].[Tarjeta]  WITH CHECK ADD  CONSTRAINT [FK_Tarjeta_Producto] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Producto] ([IdProducto])
GO
ALTER TABLE [dbo].[Tarjeta] CHECK CONSTRAINT [FK_Tarjeta_Producto]
GO
ALTER TABLE [dbo].[Transferencia]  WITH CHECK ADD  CONSTRAINT [FK_Transferencia_Almacen] FOREIGN KEY([IdAlmacenOrigen])
REFERENCES [dbo].[Almacen] ([IdAlmacen])
GO
ALTER TABLE [dbo].[Transferencia] CHECK CONSTRAINT [FK_Transferencia_Almacen]
GO
ALTER TABLE [dbo].[Transferencia]  WITH CHECK ADD  CONSTRAINT [FK_Transferencia_Almacen1] FOREIGN KEY([IdAlmacenDestino])
REFERENCES [dbo].[Almacen] ([IdAlmacen])
GO
ALTER TABLE [dbo].[Transferencia] CHECK CONSTRAINT [FK_Transferencia_Almacen1]
GO
ALTER TABLE [dbo].[Venta]  WITH CHECK ADD  CONSTRAINT [FK_Venta_Almacen] FOREIGN KEY([IdAlmacen])
REFERENCES [dbo].[Almacen] ([IdAlmacen])
GO
ALTER TABLE [dbo].[Venta] CHECK CONSTRAINT [FK_Venta_Almacen]
GO
ALTER TABLE [dbo].[Venta]  WITH CHECK ADD  CONSTRAINT [FK_Venta_Cliente] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([IdCliente])
GO
ALTER TABLE [dbo].[Venta] CHECK CONSTRAINT [FK_Venta_Cliente]
GO
ALTER TABLE [dbo].[Venta]  WITH CHECK ADD  CONSTRAINT [FK_Venta_Documento] FOREIGN KEY([IdDocumento])
REFERENCES [dbo].[Documento] ([IdDocumento])
GO
ALTER TABLE [dbo].[Venta] CHECK CONSTRAINT [FK_Venta_Documento]
GO
ALTER TABLE [dbo].[Venta]  WITH CHECK ADD  CONSTRAINT [FK_Venta_Pedido] FOREIGN KEY([IdPedido])
REFERENCES [dbo].[Pedido] ([IdPedido])
GO
ALTER TABLE [dbo].[Venta] CHECK CONSTRAINT [FK_Venta_Pedido]
GO
/****** Object:  StoredProcedure [dbo].[IAE_Almacen]    Script Date: 11/12/2021 21:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[IAE_Almacen]
	@Tipo Int,
	@IdAlmacen Int,
	@Descripcion Varchar(150),
	@Direccion Varchar(150),
	@IdSede Int,
	@Usuario Varchar(50),
	@Estado Bit
As
Begin
	If @Tipo=1
	Begin
		Select IdAlmacen,Descripcion,Direccion,IdSede From Almacen Where Estado=@Estado
		Order By Descripcion
	End
	If @Tipo=2
	Begin
		Set @IdAlmacen=IsNull((Select Max(IdAlmacen) From Almacen),0)+1
		Insert Into Almacen Values(@IdAlmacen,@Descripcion,@Direccion,@IdSede,@Usuario,GETDATE(),NULL,NULL,1)
	End
	If @Tipo=3
	Begin
		Update Almacen Set Descripcion=@Descripcion,Direccion=@Direccion,IdSede=@IdSede ,UsuarioModifica=@Usuario,FechaModifica=Getdate()
		Where IdAlmacen=@IdAlmacen
	End
	If @Tipo=4
	Begin
		Update Almacen Set Estado=@Estado,UsuarioModifica=@Usuario,FechaModifica=Getdate()
		Where IdAlmacen=@IdAlmacen
	End
	If @Tipo=5
	Begin
		Select IdAlmacen,Descripcion From Almacen WHere IdAlmacen Not In(Select IdAlmacen From Inventario Where Estado=1)
	End
	If @Tipo=6
	Begin
		Select IdAlmacen,Descripcion From Almacen Where IdAlmacen <> @IdAlmacen And Estado=1
	End
	If @Tipo=7
	Begin
		Select IdAlmacen,Descripcion,Direccion,IdSede From Almacen Where Estado=@Estado
	End
End
GO
/****** Object:  StoredProcedure [dbo].[IAE_Caja]    Script Date: 11/12/2021 21:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[IAE_Caja]
	@Tipo Int,
	@IdCaja Int,
	@IdTurno Int,
	@FechaInicio Datetime,
	@MontoInicio Decimal(18,2),
	@FechaFinal Datetime,
	@MontoFinal Decimal(18,2),
	@Usuario Varchar(50),
	@Estado Tinyint
As
Begin
	If @Tipo=1 -- Aperturar Caja
	Begin
		Set @IdCaja=IsNull((Select Max(IdCaja) From Caja),0)+1
		Set @IdTurno=IsNull((Select Max(IdTurno) From Caja Where DATEDIFF(Day,FechaInicio,@FechaInicio)=0),0)+1
		Insert Into Caja Values(@IdCaja,@IdTurno,@Usuario,@FechaInicio,@MontoInicio,NULL,@MontoFinal,@Usuario,GETDATE(),NULL,NULL,1)
	End
	If @Tipo=2 -- Cerrar Caja
	Begin
		Update Caja Set Estado=0, FechaFinal=@FechaFinal,UsuarioModifica=@Usuario,FechaModifica=GETDATE()
		Where DATEDIFF(Day,@FechaInicio,FechaInicio)=0 And Estado=1
	End
	If @Tipo=3
	Begin
		Update Caja Set MontoFinal=MontoFinal-@MontoFinal Where DATEDIFF(Day,@FechaInicio,FechaInicio)=0 And Estado=1
	End
	If @Tipo=4
	Begin
		Update Caja Set MontoFinal=MontoFinal+@MontoFinal Where DATEDIFF(Day,@FechaInicio,FechaInicio)=0 And Estado=1
	End
	If @Tipo=5
	Begin
		Select Count(IdCaja) From Caja Where DATEDIFF(Day,@FechaInicio,FechaInicio)=0 And Estado=1
	End
	If @Tipo=6
	Begin
		Select Convert(Varchar(10),FechaInicio,103), MontoFinal From Caja Where DATEDIFF(Day,@FechaInicio,FechaInicio)=0 And Estado=1
	End
	If @Tipo=7 -- Indica Cual Es La Fecha De La Ultima Caja Aperturada
	Begin
		Select FechaInicio From Caja Where Estado=1
	End
	If @Tipo=8
	Begin
		Select IsNull(Count(IdCaja),0) From Caja Where Estado=1
	End
	If @Tipo=9
	Begin
		Select MontoInicio,MontoFinal From Caja Where DATEDIFF(Day,@FechaInicio,FechaInicio)=0 And Estado=1
	End
	If @Tipo=10
	Begin
		Select IdCaja,IdTurno,UsuarioAbre,FechaInicio,MontoInicio,FechaFinal,MontoFinal From Caja
		Where DATEDIFF(Day,FechaInicio,@FechaInicio)<=0 And DATEDIFF(Day,FechaInicio,@FechaFinal)>=0
	End
End
GO
/****** Object:  StoredProcedure [dbo].[IAE_Cliente]    Script Date: 11/12/2021 21:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[IAE_Cliente]
	@Tipo Int,
	@IdCliente Int,
	@Nombres Varchar(350),
	@TipoPersona Bit,
	@Dni Varchar(15),
	@Direccion Varchar(300),
	@Celular Varchar(10),
	@Usuario Varchar(50),
	@Estado Bit
As
Begin
	If @Tipo=1
	Begin
		Select IdCliente,Nombres,TipoPersona ,Dni,Direccion,Celular From Cliente
		Where Estado=@Estado Order By Nombres
	End
	If @Tipo=2
	Begin
		Set @IdCliente=IsNull((Select MAX(IdCliente) From Cliente),0)+1
		Insert Into Cliente Values(@IdCliente,@Nombres,@TipoPersona,@Dni,@Direccion,@Celular,@Usuario,GETDATE(),NULL,NULL,1)
	End
	If @Tipo=3 
	Begin
		Update Cliente Set Nombres=@Nombres,TipoPersona=@TipoPersona,Dni=@Dni,Direccion=@Direccion,Celular=@Celular,
		FechaModifica=GETDATE(),UsuarioModifica=@Usuario 
		Where IdCliente=@IdCliente
	End
	If @Tipo=4
	Begin
		Update Cliente Set Estado=@Estado,FechaModifica=GETDATE(),UsuarioModifica=@Usuario 
		Where IdCliente=@IdCliente
	End
	If @Tipo=5
	Begin
		Select IdCliente,Nombres,Dni,Direccion From Cliente Where Estado=@Estado
	End
	If @Tipo=6
	Begin
		Select IdCliente,Nombres,Dni,TipoPersona From Cliente
		Where Dni=(Select Valor From Parametros Where Clave='ID_CLIENTE')
	End
	
End
GO
/****** Object:  StoredProcedure [dbo].[IAE_Compra]    Script Date: 11/12/2021 21:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[IAE_Compra]
	@Tipo Int,
	@IdCompra Int,
	@IdAlmacen Int,
	@IdDocumento Varchar(2),
	@Serie Varchar(10),
	@Numero Int,
	@Fecha Datetime,
	@Porcentaje Int,
	@SubTotal Decimal(18,2),
	@Igv Decimal(18,2),
	@Total Decimal(18,2),
	@IdProveedor Int,
	@Credito Bit,
	@Dias Int,
	@Usuario Varchar(50),
	@Estado Bit,
	@Codigo Int Output
As
Begin
	If @Tipo=1
	Begin
		Set @IdCompra=IsNull((Select MAX(IdCompra) From Compra),0)+1
		Set @Codigo=@IdCompra
		Insert Into Compra Values(@IdCompra,@IdAlmacen,@IdDocumento,@Serie,@Numero,@Fecha,@Porcentaje,
							@SubTotal,@Igv,@Total,@IdProveedor,@Credito,@Dias,@Usuario,Getdate(),NULL,NULL,1)
	End
	If @Tipo=2
	Begin
		Select C.IdCompra,A.IdAlmacen,P.IdProveedor,P.RazonSocial,Credito,
		D.Abreviatura + '/' + Right('0000000000'+C.Serie,10) + ' - ' + Right('0000000000' +Convert(Varchar,C.Numero),10) 'Documento',Fecha,Total,C.Estado 
		From Compra C Inner Join Proveedor P
		On P.IdProveedor=C.IdProveedor Inner Join Documento D On D.IdDocumento=C.IdDocumento Inner Join Almacen A
		On A.IdAlmacen=C.IdAlmacen
		Where C.IdAlmacen=@IdAlmacen And DATEDIFF(DAY,C.Fecha,@Fecha)<=0 And DATEDIFF(DAY,C.Fecha,Convert(Date,@Serie))>=0
	End
	If @Tipo=3
	Begin
		Select IdDetalleCompra,IdCompra,IdTarjeta,P.IdProducto,P.Descripcion,Lote, Cantidad,Precio, Cantidad*Precio 'SubTotal'  From DetalleCompra DC
		Inner Join ProductoFinal P On P.IdProducto=DC.IdProducto
		Where IdCompra=@IdCompra
	End
	If @Tipo=4
	Begin
		Update Compra Set Estado=0,UsuarioModifica=@Usuario,FechaModifica=Getdate()
		Where IdCompra=@IdCompra
	End
	If @Tipo=5
	Begin
	Select C.IdCompra,A.IdAlmacen,P.IdProveedor,P.Ruc,P.RazonSocial,Credito,
		D.Abreviatura + '/' + Right('0000000000'+C.Serie,10) + ' - ' + Right('0000000000' +Convert(Varchar,C.Numero),10) 'Documento',Fecha,Total,C.Estado 
		From Compra C Inner Join Proveedor P
		On P.IdProveedor=C.IdProveedor Inner Join Documento D On D.IdDocumento=C.IdDocumento Inner Join Almacen A
		On A.IdAlmacen=C.IdAlmacen
		Where C.IdAlmacen=@IdAlmacen 
		And (DATEDIFF(DAY,C.Fecha,@Fecha)<=0 And DATEDIFF(DAY,C.Fecha,Convert(Date,@Serie))>=0) 
		And (C.IdProveedor=@IdProveedor OR @IdProveedor IS NULL)
		And (C.Credito=@Credito OR @Credito IS NULL)
	End

End

GO
/****** Object:  StoredProcedure [dbo].[IAE_DetalleCompra]    Script Date: 11/12/2021 21:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[IAE_DetalleCompra]
	@Tipo Int,
	@IdDetalleCompra Int,
	@IdTarjeta Int,
	@IdCompra Int,
	@IdProducto Int,
	@Cantidad Int,
	@Precio Decimal(18,2),
	@Ganancia Decimal(18,2),
	@Lote Varchar(50),
	@Usuario Varchar(50),
	@Estado Bit
As
Begin
	If @Tipo=1
	Begin
		Set @IdDetalleCompra=IsNull((Select Max(IdDetalleCompra) From DetalleCompra),0)+1
		Insert Into DetalleCompra Values(@IdDetalleCompra,@IdCompra,@IdTarjeta,@IdProducto,@Cantidad,@Precio,@Ganancia,
					@Lote,@Usuario,Getdate(),NULL,NULL,1)
	End
	If @Tipo=2
	Begin
		Update DetalleCompra Set Estado=0,UsuarioModifica=@Usuario,FechaModifica=Getdate()
		Where IdDetalleCompra=@IdDetalleCompra
	End
End
GO
/****** Object:  StoredProcedure [dbo].[IAE_DetalleDeuda]    Script Date: 11/12/2021 21:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[IAE_DetalleDeuda]
	@Tipo Int,
	@IdDetalleDeuda Int,
	@IdDeuda Int,
	@Fecha Datetime,
	@Observacion Varchar(500),
	@Monto Decimal(18,2),
	@Usuario Varchar(50),
	@Estado Bit
As
Begin
	If @Tipo=1
	Begin
		Set @IdDetalleDeuda=IsNull((Select Max(IdDetalleDeuda) From DetalleDeuda),0)+1
		Insert Into DetalleDeuda Values(@IdDetalleDeuda,@IdDeuda,@Fecha,@Observacion,@Monto,@Usuario,GETDATE(),NULL,NULL,1)
	End
	If @Tipo=2
	Begin
		Update DetalleDeuda Set Estado=0,UsuarioModifica=@Usuario,FechaModifica=Getdate()
		Where IdDetalleDeuda=@IdDetalleDeuda
	End
End
GO
/****** Object:  StoredProcedure [dbo].[IAE_DetalleInventario]    Script Date: 11/12/2021 21:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[IAE_DetalleInventario]
	@Tipo Int,
	@IdDetalleInventario Int,
	@IdInventario Int,
	@IdProducto Int,
	@IdLote Varchar(50),
	@Vencimiento Datetime,
	@Stock Int,
	@PrecioCompra Decimal(18,2),
	@Ganancia Decimal(18,2),
	@PrecioVenta Decimal(18,2),
	@Usuario Varchar(50),
	@Estado Bit
As
Begin
	If @Tipo=1
	Begin
		Set @Ganancia=@PrecioVenta-@PrecioCompra
		Declare @Verifica Int
		Set @Verifica=(Select COUNT(*) From DetalleInventario Where IdProducto=@IdProducto And IdInventario=@IdInventario)
		If @Verifica=0
		Begin
			Set @IdDetalleInventario=IsNull((Select Max(IdDetalleInventario) From DetalleInventario),0)+1
			Insert Into DetalleInventario Values(@IdDetalleInventario,@IdInventario,@IdProducto,@IdLote,@Vencimiento,@Stock,
											@PrecioCompra,@Ganancia,@PrecioVenta,@Usuario,Getdate(),NULL,NULL,1)
		End
		Else
		Begin
			Update DetalleInventario Set Lote=@IdLote,Vencimiento=@Vencimiento,Stock=@Stock,PrecioCompra=@PrecioCompra,
			Ganancia=@Ganancia,PrecioVenta=@PrecioVenta,UsuarioModifica=@Usuario,FechaModifica=Getdate()
			Where IdInventario=@IdInventario And IdProducto=@IdProducto
		End
	End
End
GO
/****** Object:  StoredProcedure [dbo].[IAE_DetallePedido]    Script Date: 11/12/2021 21:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[IAE_DetallePedido]
	@Tipo Int,
	@IdDetallePedido Int,
	@IdPedido Int,
	@IdProducto Int,
	@IdTarjeta Int,
	@Cantidad Int,
	@PrecioCompra Decimal(18,2),
	@Ganancia Decimal(18,2),
	@PrecioVenta Decimal(18,2),
	@Lote Varchar(50),
	@Fecha Datetime,
	@Usuario Varchar(50),
	@Estado Bit
As
Begin
	If @Tipo=1
	Begin
		Set @IdDetallePedido=IsNull((Select Max(IdDetallePedido)From DetallePedido),0)+1
		If @Estado=1
		Begin
			Insert Into DetallePedido Values(@IdDetallePedido,@IdPedido,@IdProducto,@IdTarjeta,@Cantidad,
					@PrecioCompra,@Ganancia,@PrecioVenta,@Lote,@Fecha,@Usuario,Getdate(),NULL,NULL,1)
		End
		Else
		Begin
			Insert Into DetallePedido Values(@IdDetallePedido,@IdPedido,@IdProducto,@IdTarjeta,@Cantidad,
					@PrecioCompra,@Ganancia,@PrecioVenta,Null,Null,@Usuario,Getdate(),NULL,NULL,1)
		End	
		
	End
	If @Tipo=2
	Begin
		Update DetallePedido Set Estado=0,UsuarioModifica=@Usuario,FechaModifica=Getdate()
		Where IdDetallePedido=@IdDetallePedido
	End
End
GO
/****** Object:  StoredProcedure [dbo].[IAE_DetalleSalida]    Script Date: 11/12/2021 21:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[IAE_DetalleSalida]
	@Tipo Int,
	@IdDetalleSalida Int,
	@IdSalida Int,
	@IdTarjeta Int,
	@IdProducto Int,
	@Cantidad Int,
	@Precio Decimal(18,2),
	@Ganancia Decimal(18,2),
	@Lote Varchar(50),
	@Descuento Decimal(18,2),
	@Total Decimal(18,2),
	@Usuario Varchar(50),
	@Estado Bit
	
As
Begin
	If @Tipo=1
	Begin
		Set @IdDetalleSalida=IsNull((Select Max(IdDetalleSalida) From DetalleSalida),0)+1
		Set @Total=(@Cantidad*@Precio)-@Descuento
		Insert Into DetalleSalida Values(@IdDetalleSalida,@IdSalida,@IdTarjeta,@IdProducto,@Cantidad,@Precio,
					@Ganancia,@Lote,@Descuento,@Total,@Usuario,Getdate(),NULL,NULL,1)
	End
	If @Tipo=2
	Begin
		Update DetalleSalida Set Estado=0,UsuarioModifica=@Usuario,FechaModifica=Getdate()
		Where IdDetalleSalida=@IdDetalleSalida
	End
End
GO
/****** Object:  StoredProcedure [dbo].[IAE_DetalleTransferencia]    Script Date: 11/12/2021 21:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[IAE_DetalleTransferencia]
	@Tipo Int,
	@IdDetalleTransferencia Int,
	@IdTransferencia Int,
	@IdProducto Int,
	@IdTarjeta Int,
	@IdTarjetaDestino Int,
	@Lote Varchar(50),
	@PrecioVenta Decimal(18,2),
	@Ganancia Decimal(18,2),
	@PrecioCompra Decimal(18,2),
	@Usuario Varchar(50),
	@Estado Bit
As
Begin
	If @Tipo=1
	Begin
		Set @IdDetalleTransferencia=IsNull((Select Max(IdDetalleTransferencia) From DetalleTransferencia),0)+1
		Insert Into DetalleTransferencia Values(@IdDetalleTransferencia,@IdTransferencia,@IdProducto,@IdTarjeta,
					@IdTarjetaDestino,@Lote,@PrecioVenta,@Ganancia,@PrecioCompra,@Usuario,GETDATE(),NULL,NULL,1)
	End 
End
GO
/****** Object:  StoredProcedure [dbo].[IAE_DetalleVenta]    Script Date: 11/12/2021 21:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[IAE_DetalleVenta]
	@Tipo Int,
	@IdDetalleVenta Int,
	@IdVenta Int,
	@IdTarjeta Int,
	@IdProducto Int,
	@Cantidad Int,
	@Precio Decimal(18,2),
	@Ganancia Decimal(18,2),
	@Lote Varchar(50),
	@Descuento Decimal(18,2),
	@Total Decimal(18,2),
	@Usuario Varchar(50),
	@Estado Bit
	
As
Begin
	If @Tipo=1
	Begin
		Set @IdDetalleVenta=IsNull((Select Max(IdDetalleVenta) From DetalleVenta),0)+1
		Set @Total=(@Cantidad*@Precio)-@Descuento
		Insert Into DetalleVenta Values(@IdDetalleVenta,@IdVenta,@IdTarjeta,@IdProducto,@Cantidad,@Precio,
					@Ganancia,@Lote,@Descuento,@Total,@Usuario,Getdate(),NULL,NULL,1)
	End
	If @Tipo=2
	Begin
		Update DetalleVenta Set Estado=0,UsuarioModifica=@Usuario,FechaModifica=Getdate()
		Where IdDetalleVenta=@IdDetalleVenta
	End
End
GO
/****** Object:  StoredProcedure [dbo].[IAE_Deuda]    Script Date: 11/12/2021 21:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[IAE_Deuda]
	@Tipo Int,
	@IdDeuda Int,
	@Fecha Datetime,
	@FechaPago Datetime,
	@IdProveedor Int,
	@IdReferencia Int,
	@Entrada Bit,
	@IdDocumento Varchar(2),
	@Serie Varchar(10),
	@Numero Int,
	@Monto Decimal(18,2),
	@Saldo Decimal(18,2),
	@Usuario Varchar(50),
	@Estado Bit
As
Begin
	If @Tipo=1
	Begin
		Set @IdDeuda=IsNull((Select Max(IdDeuda) From Deuda),0)+1
		Insert Into Deuda Values(@IdDeuda,@Fecha,@FechaPago,@IdProveedor,@IdReferencia,@Entrada,@IdDocumento,@Serie,@Numero,
								@Monto,@Saldo,@Usuario,Getdate(),NULL,NULL,1)
	End
	If @Tipo=2
	Begin
		Update Deuda Set Estado=0,UsuarioModifica=@Usuario,FechaModifica=Getdate()
		Where IdReferencia=@IdReferencia
	End
	If @Tipo=3
	Begin
		Select D.IdDeuda,Dc.Descripcion 'Documento',
		Right('0000000000'+D.Serie,10) + ' - ' + Right('0000000000' +Convert(Varchar,D.Numero),10) 'Numeracion',
		D.Fecha,P.Ruc,P.RazonSocial,DATEDIFF(Day,Fecha,FechaPago) 'Dias',Monto,Saldo
		From Deuda D Inner Join Proveedor P
		On D.IdProveedor=P.IdProveedor Inner Join Documento Dc On Dc.IdDocumento=D.IdDocumento
		Where D.Saldo>0 And DATEDIFF(DAY,D.Fecha,@Fecha)<=0 And DATEDIFF(DAY,D.Fecha,Convert(Date,@FechaPago))>=0
	End
	If @Tipo=4
	Begin
		Select D.IdDeuda,Dc.Descripcion 'Documento',
		Right('0000000000'+D.Serie,10) + ' - ' + Right('0000000000' +Convert(Varchar,D.Numero),10) 'Numeracion',
		D.Fecha,P.Ruc,P.RazonSocial,DATEDIFF(Day,Fecha,FechaPago) 'Dias',Monto,Saldo
		From Deuda D Inner Join Proveedor P
		On D.IdProveedor=P.IdProveedor Inner Join Documento Dc On Dc.IdDocumento=D.IdDocumento
		Where D.Saldo>0 And D.IdProveedor=@IdProveedor
	End
	If @Tipo=5
	Begin
		Select IdDetalleDeuda,IdDeuda,Fecha,Observacion,Monto From DetalleDeuda
		Where IdDeuda=@IdDeuda And Estado=1
	End
	If @Tipo=6
	Begin
		Set @Monto=(Select Saldo From Deuda Where IdDeuda=@IdDeuda And Estado=1)
		If @Monto>@Saldo
		Begin
			Update Deuda Set Saldo=Saldo-@Saldo,UsuarioModifica=@Usuario,FechaModifica=GETDATE()
			Where IdDeuda=@IdDeuda And Estado=1
		End
		If @Monto=@Saldo
		Begin
			Update Deuda Set Saldo=Saldo-@Saldo,UsuarioModifica=@Usuario,FechaModifica=GETDATE()
			Where IdDeuda=@IdDeuda And Estado=1
		End
	End
	If @Tipo=7
	Begin
		Set @Monto=(Select Saldo From Deuda Where IdDeuda=@IdDeuda And Estado=1)
		If @Monto>@Saldo
		Begin
			Update Deuda Set Saldo=Saldo+@Saldo,UsuarioModifica=@Usuario,FechaModifica=GETDATE()
			Where IdDeuda=@IdDeuda And Estado=1
		End
		If @Monto=@Saldo
		Begin
			Update Deuda Set Saldo=Saldo+@Saldo,UsuarioModifica=@Usuario,FechaModifica=GETDATE()
			Where IdDeuda=@IdDeuda And Estado=1
		End
	End
	If @Tipo=8
	Begin
		Select D.IdDeuda,Dc.Descripcion 'Documento',
		Right('0000000000'+D.Serie,10) + ' - ' + Right('0000000000' +Convert(Varchar,D.Numero),10) 'Numeracion',
		D.Fecha,P.Ruc,P.RazonSocial,DATEDIFF(Day,Fecha,FechaPago) 'Dias',Saldo
		From Deuda D Inner Join Proveedor P
		On D.IdProveedor=P.IdProveedor Inner Join Documento Dc On Dc.IdDocumento=D.IdDocumento
		Where D.Saldo>0 And DATEDIFF(Day,Fecha,FechaPago)<=@Numero
		Order By DATEDIFF(Day,Fecha,FechaPago) Asc
	End
	If @Tipo=9
	Begin
		Select D.IdDeuda,Dc.Descripcion 'Documento',
		Right('0000000000'+D.Serie,10) + ' - ' + Right('0000000000' +Convert(Varchar,D.Numero),10) 'Numeracion',
		D.Fecha,P.Ruc,P.RazonSocial,DATEDIFF(Day,Fecha,FechaPago) 'Dias',Saldo
		From Deuda D Inner Join Proveedor P
		On D.IdProveedor=P.IdProveedor Inner Join Documento Dc On Dc.IdDocumento=D.IdDocumento
		Where D.Saldo>0 And P.IdProveedor=@IdProveedor And DATEDIFF(Day,Fecha,FechaPago)<=@Numero
		Order By DATEDIFF(Day,Fecha,FechaPago) Asc
	End
End
GO
/****** Object:  StoredProcedure [dbo].[IAE_Documento]    Script Date: 11/12/2021 21:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[IAE_Documento]
	@Tipo Int,
	@IdDocumento Varchar(10),
	@Descripcion Varchar(100),
	@Abreviatura Varchar(15),
	@Usuario Varchar(50),
	@Estado Bit
As
Begin
	If @Tipo=1
	Begin
		Select IdDocumento,Descripcion,Abreviatura From Documento Where Estado=@Estado
	End
	If @Tipo=2
	Begin
		Insert Into Documento Values(@IdDocumento,@Descripcion,@Abreviatura,@Usuario,GETDATE(),NULL,NULL,1)
	End
	If @Tipo=3
	Begin
		Update Documento Set Descripcion=@Descripcion,Abreviatura=@Abreviatura,UsuarioModifica=@Usuario,FechaModifica=Getdate()
		Where IdDocumento=@IdDocumento
	End
	If @Tipo=4
	Begin
		Update Documento Set Estado=@Estado,UsuarioModifica=@Usuario,FechaModifica=Getdate()
		Where IdDocumento=@IdDocumento
	End
	If @Tipo=5
	Begin
		Select IdDocumento,Descripcion From Documento
		Where Estado=@Estado And
		IdDocumento In (Select Valor From Parametros Where Clave IN('ID_BOLETA','ID_TICKET','ID_FACTURA','ID_NOTA_VENTA','ID_GUIA_DEVOLUCION','ID_AJUSTESTOCK_ENT','ID_AJUSTESTOCK_SAL'))
	End
	If @Tipo=6
	Begin
		Select IdDocumento,Descripcion From Documento
		Where IdDocumento In (Select Valor From Parametros Where Clave='ID_TRANSFERENCIA') And Estado=@Estado
	End
End

GO
/****** Object:  StoredProcedure [dbo].[IAE_DocumentoSerie]    Script Date: 11/12/2021 21:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[IAE_DocumentoSerie]
	@Tipo Int,
	@IdDocumentoSerie Int,
	@IdDocumento Varchar(2),
	@Serie Varchar(10),
	@Ultimo Int,
	@Usuario Varchar(50),
	@Estado Bit
As
Begin
	If @Tipo=1
	Begin
		Select IdDocumentoSerie,S.IdDocumento,D.Descripcion,Serie,Ultimo From DocumentoSerie S
		Inner Join Documento D On D.IdDocumento=S.IdDocumento
		Where S.Estado=@Estado
	End
	If @Tipo=2
	Begin
		Set @IdDocumentoSerie=IsNull((Select Max(IdDocumentoSerie) From DocumentoSerie),0)+1
		Insert Into DocumentoSerie Values(@IdDocumentoSerie,@IdDocumento,@Serie,@Ultimo,@Usuario,GETDATE(),NULL,NULL,1)
	End
	If @Tipo=3
	Begin
		Update DocumentoSerie Set Serie=@Serie,UsuarioModifica=@Usuario,FechaModifica=Getdate()
		Where IdDocumentoSerie=@IdDocumentoSerie
	End
	If @Tipo=4
	Begin
		Update DocumentoSerie Set Estado=@Estado,UsuarioModifica=@Usuario,FechaModifica=Getdate()
		Where IdDocumentoSerie=@IdDocumentoSerie
	End
	If @Tipo=5
	Begin
		Select Serie,Ultimo From DocumentoSerie
		Where IdDocumento=@IdDocumento
	End
	If @Tipo=6
	Begin
		Update DocumentoSerie Set Ultimo=Ultimo+1,UsuarioModifica=@Usuario,FechaModifica=Getdate()
		Where Estado=1 And IdDocumento=@IdDocumento And Serie=@Serie
	End
End
GO
/****** Object:  StoredProcedure [dbo].[IAE_HistorialProducto]    Script Date: 11/12/2021 21:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[IAE_HistorialProducto]
	@Tipo Int,
	@IdHistorial Int,
	@IdProducto Int,
	@IdAlmacen Int,
	@Lote Varchar(50),
	@IdLote Varchar(50),
	@PrecioCompra Decimal(18,2),
	@Ganancia Decimal(18,2),
	@PrecioVenta Decimal(18,2),
	@Stock Int,
	@Vencimiento Date,
	@Usuario Varchar(50),
	@Codigo Int =0 OutPut,
	@Estado Bit
As
Begin
	Declare @Verifica Int
	Declare @Alcanza Int
	Set @Lote=ISNULL(@Lote,'')
	Set @IdLote=ISNULL(@IdLote,'')
	If @Tipo=1
	Begin
		Set @Verifica =(Select COUNT(*) From HistorialProducto Where IdProducto=@IdProducto And IdAlmacen=@IdAlmacen )
		If @Verifica=0
		Begin
			Set @IdHistorial=IsNull((Select Max(IdHistorial) From HistorialProducto),0)+1
			Set @Ganancia=@PrecioVenta-@PrecioCompra
			Set @Codigo=@IdHistorial
			Insert Into HistorialProducto Values(@IdHistorial,@IdProducto,@IdAlmacen,@Lote,@PrecioCompra,@Ganancia,@PrecioVenta,
			@Stock,@Vencimiento,@Usuario,Getdate(),NULL,NULL,1)
		End
		Else
		Begin
			Update HistorialProducto Set Lote=@Lote,PrecioCompra=@PrecioCompra,Ganancia=@PrecioVenta-@PrecioCompra,
			PrecioVenta=@PrecioVenta,Stock=@Stock,Vencimiento=@Vencimiento,UsuarioModifica=@Usuario,FechaModifica=GETDATE()
			Where IdAlmacen=@IdAlmacen And IdProducto=@IdProducto --And IdDocumento=@IdDocumento
			Set @Codigo=IsNull((Select IdHistorial From HistorialProducto Where IdAlmacen=@IdAlmacen And IdProducto=@IdProducto And Estado=1),1)
		End
	End
	If @Tipo=2
	Begin
		Declare @Seleccionar Bit
		Set @Seleccionar=0;
		With xTemporal
		As
		(
		Select IdProducto,IdHistorial,Lote,Convert(Date,Vencimiento) 'Vencimiento',SUM(Entrada) - SUM(Salida) 'Stock','' 'Movimiento',@Seleccionar 'Seleccionar' From Tarjeta 
		Where Estado=1
		Group By IdProducto,IdHistorial,Lote,Convert(Date,Vencimiento)
		)
		Select Hp.IdHistorial,Hp.Lote,Hp.Vencimiento,Hp.PrecioCompra,Hp.PrecioVenta,T.Stock,T.Seleccionar From xTemporal T Inner Join HistorialProducto Hp
		On Hp.IdHistorial=T.IdHistorial
		Where T.IdProducto=@IdProducto And HP.IdAlmacen=@IdAlmacen And HP.Stock>0 And T.Stock>0
	End
	If @Tipo=3
	Begin
		Set @Verifica =(Select COUNT(*) From HistorialProducto Where IdProducto=@IdProducto And IdAlmacen=@IdAlmacen And IdHistorial=@IdHistorial And Estado=1)
		If @Verifica=0
		Begin
			If @Estado=0 Begin Set @Vencimiento=Null End
			Set @IdHistorial=IsNull((Select Max(IdHistorial) From HistorialProducto),0)+1
			Set @Ganancia=@PrecioVenta-@PrecioCompra
			Set @Codigo=@IdHistorial
			Insert Into HistorialProducto Values(@IdHistorial,@IdProducto,@IdAlmacen,@Lote,@PrecioCompra,@Ganancia,@PrecioVenta,
			@Stock,@Vencimiento,@Usuario,Getdate(),NULL,NULL,1)
		End
		Else
		Begin
			Update HistorialProducto Set Lote=@Lote,PrecioCompra=@PrecioCompra,Ganancia=@PrecioVenta-@PrecioCompra,
			PrecioVenta=@PrecioVenta,Stock=Stock+@Stock,Vencimiento=Vencimiento,UsuarioModifica=@Usuario,FechaModifica=GETDATE()
			Where IdAlmacen=@IdAlmacen And IdProducto=@IdProducto And IdHistorial=@IdHistorial -- And Lote=@Lote
			Set @Codigo=@IdHistorial
		End
	End
	If @Tipo=4
	Begin
		--If @Estado=0
		--Begin
		--	@
		--End
		Update HistorialProducto Set Lote=@Lote,PrecioCompra=@PrecioCompra,Ganancia=@PrecioVenta-@PrecioCompra,
		PrecioVenta=@PrecioVenta,Stock=Stock-@Stock,Vencimiento=Vencimiento,UsuarioModifica=@Usuario,FechaModifica=GETDATE()
		Where IdAlmacen=@IdAlmacen And IdProducto=@IdProducto And IdHistorial=@IdHistorial
		Set @Codigo=IsNull((Select IdHistorial From HistorialProducto Where IdAlmacen=@IdAlmacen And IdProducto=@IdProducto And IdHistorial=@IdHistorial And Estado=1),1)
	End
	If @Tipo=5
	Begin
		Set @Alcanza=(Select Stock From HistorialProducto Where IdProducto=@IdProducto And IdAlmacen=@IdAlmacen And IdHistorial=@IdHistorial And Estado=1)
		If @Alcanza>@Stock
		Begin
			Update HistorialProducto Set Stock=Stock-@Stock,UsuarioModifica=@Usuario,FechaModifica=GETDATE()
			Where IdProducto=@IdProducto And IdAlmacen=@IdAlmacen And Lote=@Lote And IdHistorial=@IdHistorial
		End
		If @Alcanza=@Stock
		Begin
			Update HistorialProducto Set Stock=Stock-@Stock,Estado=0,UsuarioModifica=@Usuario,FechaModifica=GETDATE()
			Where IdProducto=@IdProducto And IdAlmacen=@IdAlmacen And Lote=@Lote And IdHistorial=@IdHistorial
		End
		If @Alcanza=0
		Begin
			Update HistorialProducto Set Stock=Stock+@Stock,Estado=1,UsuarioModifica=@Usuario,FechaModifica=GETDATE()
			Where IdProducto=@IdProducto And IdAlmacen=@IdAlmacen And Lote=@Lote And IdHistorial=@IdHistorial
		End
	End
	If @Tipo=6
	Begin
		Set @Alcanza=(Select Stock From HistorialProducto Where IdProducto=@IdProducto And IdAlmacen=@IdAlmacen And IdHistorial=@IdHistorial And Estado=1)
		If @Alcanza>@Stock
		Begin
			Update HistorialProducto Set Stock=Stock+@Stock,UsuarioModifica=@Usuario,FechaModifica=GETDATE()
			Where IdProducto=@IdProducto And IdAlmacen=@IdAlmacen And Lote=@Lote And IdHistorial=@IdHistorial
		End
		If @Alcanza=@Stock
		Begin
			Update HistorialProducto Set Stock=Stock+@Stock,Estado=1,UsuarioModifica=@Usuario,FechaModifica=GETDATE()
			Where IdProducto=@IdProducto And IdAlmacen=@IdAlmacen And Lote=@Lote And IdHistorial=@IdHistorial
		End
	End
	If @Tipo=7
	Begin
		Select T.Fecha,D.Descripcion 'Documento',Right('0000000'+T.Serie,7) + '-' + 
		Right('0000000' + CONVERT(Varchar,T.Numero),7) 'Numeracion',T.Lote,Entrada,Salida
		 From Tarjeta T Inner Join Documento D
		On D.IdDocumento=T.IdDocumento
		Where T.Estado=1 And T.IdAlmacen=@IdAlmacen And T.IdProducto=@IdProducto
	End
	If @Tipo=8
	Begin
		Select T.Fecha,D.Descripcion 'Documento',Right('0000000'+T.Serie,7) + '-' + 
		Right('0000000' + CONVERT(Varchar,T.Numero),7) 'Numeracion',T.Lote,Entrada,Salida
		 From Tarjeta T Inner Join Documento D
		On D.IdDocumento=T.IdDocumento
		Where T.Estado=1 And T.IdAlmacen=@IdAlmacen And T.IdProducto=@IdProducto
		And DATEDIFF(DAY,@Lote,Fecha)>=0 And DATEDIFF(DAY,@IdLote,Fecha)<=0
	End
	If @Tipo=9
	Begin
		Select P.IdProducto,A.Descripcion 'Almacen',PF.Descripcion 'Medicamento',P.Alternativo,L.Descripcion 'Laboratorio',HP.Lote,Hp.Vencimiento,Hp.Stock From HistorialProducto HP Inner Join Producto P On P.IdProducto=HP.IdProducto
		Inner Join ProductoFinal PF On P.IdProducto=PF.IdProducto Inner Join Laboratorio L
		On L.IdLaboratorio=P.IdLaboratorio Inner Join Almacen A
		On A.IdAlmacen=HP.IdAlmacen
		Where HP.IdAlmacen=@IdAlmacen And HP.Stock>=@Stock And HP.Stock<=@IdProducto
		Order By Medicamento
	End
	If @Tipo=10
	Begin
		Select P.IdProducto,A.Descripcion 'Almacen',PF.Descripcion 'Medicamento',P.Alternativo,L.Descripcion 'Laboratorio',HP.Lote,Hp.Vencimiento,Hp.Stock From HistorialProducto HP Inner Join Producto P On P.IdProducto=HP.IdProducto
		Inner Join ProductoFinal PF On P.IdProducto=PF.IdProducto Inner Join Laboratorio L
		On L.IdLaboratorio=P.IdLaboratorio Inner Join Almacen A
		On A.IdAlmacen=HP.IdAlmacen
		Where HP.Stock>=@Stock And HP.Stock<=@IdProducto
		Order By Medicamento
	End
	If @Tipo=11
	Begin
		With xTemporal
		As
		(
			Select IdProducto,IdAlmacen, Sum(Stock) 'Total' From HistorialProducto 
			Group By IdProducto,IdAlmacen
		)
		Select HP.IdProducto,HP.IdAlmacen,A.Descripcion 'Almacen',PF.Descripcion 'Medicamento',P.Alternativo,L.Descripcion 'Laboratorio',P.StockMinimo,HP.Total From xTemporal HP
		Inner Join Producto P 
		On P.IdProducto=HP.IdProducto Inner Join ProductoFinal PF 
		On PF.IdProducto=P.IdProducto And HP.Total<=P.StockMinimo Inner Join Laboratorio L On L.IdLaboratorio=P.IdLaboratorio
		Inner Join Almacen A On A.IdAlmacen=HP.IdAlmacen
	End
	If @Tipo=12
	Begin
		With xTemporal
		As
		(
			Select IdProducto,IdAlmacen, Sum(Stock) 'Total' From HistorialProducto 
			Where IdAlmacen=@IdAlmacen
			Group By IdProducto,IdAlmacen
		)
		Select HP.IdProducto,HP.IdAlmacen,A.Descripcion 'Almacen',PF.Descripcion 'Medicamento',P.Alternativo,L.Descripcion 'Laboratorio',P.StockMinimo,HP.Total From xTemporal HP
		Inner Join Producto P 
		On P.IdProducto=HP.IdProducto Inner Join ProductoFinal PF 
		On PF.IdProducto=P.IdProducto And HP.Total<=P.StockMinimo Inner Join Laboratorio L On L.IdLaboratorio=P.IdLaboratorio
		Inner Join Almacen A On A.IdAlmacen=HP.IdAlmacen
	End
	If @Tipo=13
	Begin
		Select HP.IdProducto,HP.IdAlmacen,A.Descripcion 'Almacen',PF.Descripcion 'Medicamento',P.Alternativo,L.Descripcion 'Laboratorio',HP.Lote,HP.Vencimiento,Datediff(Day,GETDATE(),HP.Vencimiento) 'Dias' From HistorialProducto HP
		Inner Join Producto P 
		On P.IdProducto=HP.IdProducto Inner Join ProductoFinal PF 
		On PF.IdProducto=P.IdProducto Inner Join Laboratorio L On L.IdLaboratorio=P.IdLaboratorio
		Inner Join Almacen A On A.IdAlmacen=HP.IdAlmacen
		Where Stock>0 And Datediff(Day,GETDATE(),HP.Vencimiento)<=@Stock
	End
	If @Tipo=14
	Begin
		Select HP.IdProducto,HP.IdAlmacen,A.Descripcion 'Almacen',PF.Descripcion 'Medicamento',P.Alternativo,L.Descripcion 'Laboratorio',HP.Lote,HP.Vencimiento,Datediff(Day,GETDATE(),HP.Vencimiento) 'Dias' From HistorialProducto HP
		Inner Join Producto P 
		On P.IdProducto=HP.IdProducto Inner Join ProductoFinal PF 
		On PF.IdProducto=P.IdProducto Inner Join Laboratorio L On L.IdLaboratorio=P.IdLaboratorio
		Inner Join Almacen A On A.IdAlmacen=HP.IdAlmacen
		Where Stock>0 And Datediff(Day,GETDATE(),HP.Vencimiento)<=@Stock And  Hp.IdAlmacen=@IdAlmacen
	End
	If @Tipo=15
	Begin
		Select HP.IdProducto,HP.IdAlmacen,A.Descripcion 'Almacen',PF.Descripcion 'Medicamento',P.Alternativo,L.Descripcion 'Laboratorio',HP.Lote,HP.Vencimiento,HP.Stock From HistorialProducto HP
		Inner Join Producto P 
		On P.IdProducto=HP.IdProducto Inner Join ProductoFinal PF 
		On PF.IdProducto=P.IdProducto Inner Join Laboratorio L On L.IdLaboratorio=P.IdLaboratorio
		Inner Join Almacen A On A.IdAlmacen=HP.IdAlmacen
		Order By Medicamento
	End
	If @Tipo=16
	Begin
		Update HistorialProducto Set PrecioCompra=@PrecioCompra,PrecioVenta=@PrecioVenta,FechaModifica=GETDATE(),
		UsuarioModifica=@Usuario, Ganancia=@PrecioVenta-@PrecioCompra
		Where IdProducto=@IdProducto And IdAlmacen=@IdAlmacen And IdHistorial=@IdHistorial
	End
	If @Tipo=17
	Begin
		Declare @UsuarioModifica varchar(20)='';
		select @UsuarioModifica=h.UsuarioModifica from HistorialProducto h
		where IdHistorial=@IdHistorial

		If @UsuarioModifica!=NULL OR @UsuarioModifica!=''
		Begin
			Declare @IdAuditoriaHistorialProducto int=0
			Set @IdAuditoriaHistorialProducto=IsNull((Select MAX(IdAuditoriaHistorialProducto) From AuditoriaHistorialProducto),0)+1

			Insert Into AuditoriaHistorialProducto (IdAuditoriaHistorialProducto,IdHistorial,IdProducto,nStock,PrecioVenta,UsuarioCrea,FechaCrea,FechaRegistro,Estado)
			Select @IdAuditoriaHistorialProducto,T.IdHistorial,t.IdProducto,t.Stock,t.PrecioVenta,t.UsuarioModifica,t.FechaModifica,GETDATE(),1 from HistorialProducto t 
			WHERE IdHistorial=@IdHistorial AND t.Estado=1
		end

		Update HistorialProducto Set Stock=@Stock ,FechaModifica=GETDATE(),UsuarioModifica=@Usuario
		Where IdProducto=@IdProducto And IdAlmacen=@IdAlmacen And IdHistorial=@IdHistorial

		Update Tarjeta Set Entrada=@Stock ,FechaModifica=GETDATE(),UsuarioModifica=@Usuario
		Where IdHistorial=@IdHistorial And IdAlmacen=@IdAlmacen And IdProducto=@IdProducto



	End

End
GO
/****** Object:  StoredProcedure [dbo].[IAE_Inventario]    Script Date: 11/12/2021 21:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[IAE_Inventario]
	@Tipo Int,
	@IdInventario Int,
	@Item Int,
	@FechaInicia Datetime,
	@FechaFin Datetime,
	@IdAlmacen Int,
	@Usuario Varchar(50),
	@Estado Bit
As
Begin
	If @Tipo=1
	Begin
		Select IdInventario,Item,A.IdAlmacen,A.Descripcion,FechaInicia,FechaFin,I.Estado From Inventario I Inner Join Almacen A
		On I.IdAlmacen=A.IdAlmacen Where I.Estado=1
	End
	If @Tipo=2
	Begin
		Set @IdInventario=IsNull((Select Max(IdInventario) From Inventario),0)+1
		Set @Item=IsNull((Select Max(Item) From Inventario),0)+1
		Insert Into Inventario Values(@IdInventario,@Item,@FechaInicia,NULL,@IdAlmacen,@Usuario,Getdate(),NULL,NULL,1)
	End
	If @Tipo=3
	Begin
		Update Inventario Set Estado=@Estado,FechaFin=Getdate(),UsuarioModifica=@Usuario,FechaModifica=Getdate() Where IdInventario=@IdInventario
	End
	If @Tipo=4
	Begin
		Select IdInventario,Item,A.Descripcion,FechaInicia,FechaFin,I.Estado From Inventario I Inner Join Almacen A
		On I.IdAlmacen=A.IdAlmacen
		Where I.Estado=0 And DATEDIFF(DAY,I.FechaInicia,@FechaInicia)<=0 And DATEDIFF(DAY,I.FechaFin,@FechaFin)>=0
	End
	If @Tipo=5
	Begin
		Select PF.IdProducto,PF.Descripcion,P.Alternativo,DI.Lote,DI.Vencimiento,DI.Stock From DetalleInventario DI Inner Join ProductoFinal PF
		On PF.IdProducto=DI.IdProducto Inner Join Producto P On P.IdProducto=PF.IdProducto
		Where DI.IdInventario=@IdInventario
	End
End
GO
/****** Object:  StoredProcedure [dbo].[IAE_Laboratorio]    Script Date: 11/12/2021 21:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[IAE_Laboratorio]
	@Tipo Int,
	@IdLaboratorio Int,
	@Descripcion Varchar(150),
	@Usuario Varchar(50),
	@Estado Bit
As
Begin
	If @Tipo=1
	Begin
		Select IdLaboratorio,Descripcion From Laboratorio Where Estado=@Estado
		Order By Descripcion
	End
	If @Tipo=2
	Begin
		Set @IdLaboratorio=IsNull((Select Max(IdLaboratorio) From Laboratorio),0)+1
		Insert Into Laboratorio Values(@IdLaboratorio,@Descripcion,@Usuario,GETDATE(),NULL,NULL,1)
	End
	If @Tipo=3
	Begin
		Update Laboratorio Set Descripcion=@Descripcion,UsuarioModifica=@Usuario,FechaModifica=Getdate()
		Where IdLaboratorio=@IdLaboratorio
	End
	If @Tipo=4
	Begin
		Update Laboratorio Set Estado=@Estado,UsuarioModifica=@Usuario,FechaModifica=Getdate()
		Where IdLaboratorio=@IdLaboratorio
	End
End
GO
/****** Object:  StoredProcedure [dbo].[IAE_Paquete]    Script Date: 11/12/2021 21:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[IAE_Paquete]
	@Tipo Int,
	@IdPaqueteServicio Int,
	@IdPaquete Int,
	@IdServicio Int,
	@Usuario Varchar(50),
	@Estado Bit
As
Begin
	If @Tipo=1
	Begin
		Select P.IdProducto,P.Descripcion,S.Precio,S.Paquete From Servicio S Inner Join ProductoFinal P On S.IdServicio=P.IdProducto
		Where P.Estado=@Estado
	End
	If @Tipo=2
	Begin
		Set @IdPaqueteServicio=IsNull(Convert(Int,(Select Estado From PaqueteServicio Where IdPaquete=@IdPaquete And IdServicio=@IdServicio)),2)
		If @IdPaqueteServicio=2 And @Estado=1
		Begin
			Set @IdPaqueteServicio=ISNULL((Select Max(IdPaqueteServicio) From PaqueteServicio),0)+1
			Insert Into PaqueteServicio Values(@IdPaqueteServicio,@IdPaquete,@IdServicio,@Usuario,Getdate(),
			Null,Null,1)
		End
		Else		
		Begin
			Update PaqueteServicio Set Estado=@Estado,UsuarioModifica=@Usuario,FechaModifica=GETDATE()
			Where IdPaquete=@IdPaquete And IdServicio=@IdServicio
		End
	End
End
GO
/****** Object:  StoredProcedure [dbo].[IAE_Parametro]    Script Date: 11/12/2021 21:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[IAE_Parametro]
	@Tipo Int,
	@IdParametro Int,
	@Clave Varchar(80),
	@Valor Varchar(500),
	@Descripcion Varchar(500),
	@Usuario Varchar(8),
	@Estado Bit
As
Begin
	If @Tipo=1 
	Begin
		Select IdParametro,Clave,Valor,Descripcion From Parametros
		Where Estado=@Estado
	End
	If @Tipo=2
	Begin
		Set @IdParametro=(ISNULL((Select Max(IdParametro) From Parametros),0))+1
		Insert Into Parametros Values(@IdParametro,@Clave,@Valor,@Descripcion,@Usuario,GETDATE(),NULL,NULL,1)
	End
	If @Tipo=3
	Begin
		Update Parametros Set Descripcion=@Descripcion,Valor=@Valor,UsuarioModifica=@Usuario,
		FechaModifica=GETDATE() Where Idparametro=@IdParametro
	End
	If @Tipo=4
	Begin
		Update Parametros Set Estado=@Estado,UsuarioModifica=@Usuario,
		FechaModifica=GETDATE() Where Idparametro=@IdParametro
	End
	If @Tipo=5
	Begin
		Set @Valor=IsNull((Select Valor From Parametros Where  Clave=@Clave),'')
		Select @Valor 
	End
End
GO
/****** Object:  StoredProcedure [dbo].[IAE_Pedido]    Script Date: 11/12/2021 21:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[IAE_Pedido]
	@Tipo Int,
	@IdPedido Int,
	@IdAlmacen Int,
	@Numero Int Output,
	@Fecha Datetime,
	@Porcentaje Decimal(18,2),
	@SubTotal Decimal(18,2),
	@Igv Decimal(18,2),
	@Total Decimal(18,2),
	@IdCliente Int,
	@Nombre Varchar(250),
	@Codigo Int Output,
	@Usuario Varchar(50),
	@Estado Int
As
Begin
	If @Tipo=1
	Begin
		Set @IdPedido=IsNull((Select MAX(IdPedido) From Pedido ),0)+1
		Set @Numero=IsNull((Select MAX(Numero) From Pedido Where Datediff(Day,Getdate(),FechaCrea)=0 and IdAlmacen=@IdAlmacen),0)+1
		Set @Codigo=@IdPedido
		Insert Into Pedido Values(@IdPedido,@IdAlmacen,@Numero,@Fecha,@Porcentaje,@SubTotal,@Igv,@Total,@IdCliente,@Nombre,
						@Usuario,Getdate(),NULL,NULL,1)
	End
	If @Tipo=2
	Begin
		Select V.IdPedido,A.IdAlmacen,A.Descripcion 'Almacen',Right('0000000'+Convert(Varchar,Numero),7)'Numero',C.IdCliente,C.Nombres,Fecha,Total,V.Estado 
		From Pedido V Inner Join Cliente C
		On C.IdCliente=V.IdCliente Inner Join Almacen A
		On A.IdAlmacen=V.IdAlmacen
		Where V.IdAlmacen=@IdAlmacen And DATEDIFF(DAY,V.Fecha,@Fecha)<=0 And DATEDIFF(DAY,V.Fecha,Convert(Date,@Nombre))>=0
	End
	If @Tipo=3
	Begin
		Select IdDetallePedido,IdPedido,IdTarjeta,P.IdProducto,P.Descripcion,Lote, Cantidad,PrecioVenta 'Precio', Cantidad*PrecioVenta 'SubTotal'  From DetallePedido DV
		Inner Join ProductoFinal P On P.IdProducto=DV.IdProducto
		Where IdPedido=@IdPedido
	End
	If @Tipo=4
	Begin
		Update Pedido Set Estado=0,UsuarioModifica=@Usuario,FechaModifica=Getdate()
		Where IdPedido=@IdPedido
	End
	If @Tipo=5
	Begin
		Update Pedido Set Estado=2,UsuarioModifica=@Usuario,FechaModifica=Getdate()
		Where IdPedido=@IdPedido
	End
	If @Tipo=6
	Begin
		Select P.IdPedido,P.IdAlmacen,P.Numero,P.SubTotal,P.Igv,P.Total,P.IdCliente,P.Nombre,P.UsuarioCrea,
		DP.IdProducto,PF.Descripcion,IsNull(DP.IdTarjeta,0)'IdTarjeta',DP.Cantidad,DP.PrecioCompra,DP.Ganancia,DP.PrecioVenta,DP.Lote,DP.Fecha,
		DP.Cantidad*DP.PrecioVenta 'SubTotal', 0.0 'Descuento'
		From Pedido P Inner Join DetallePedido DP ON P.IdPedido=DP.IdPedido Inner Join ProductoFinal PF
		On PF.IdProducto=DP.IdProducto
		Where P.Numero=@Numero And P.Estado=1 And P.IdAlmacen=@IdAlmacen And DATEDIFF(Day,P.Fecha,@Fecha)=0
	End
End
GO
/****** Object:  StoredProcedure [dbo].[IAE_Permiso]    Script Date: 11/12/2021 21:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[IAE_Permiso]
	@Tipo Int,
	@IdPermiso Int,
	@IdMenu Int,
	@IdUsuario Varchar(50),
	@Estado Bit
As
Begin
	If @Tipo=1
	Begin
		Select P.IDPermiso,M.IdMenu,M.Tag,M.Descripcion From Permiso P Inner Join Menu M
		On M.IdMenu=P.IdMenu Where P.IdUsuario=@IdUsuario And P.Estado=1
		Order By M.Tag
	End
	If @Tipo=2
	Begin
		Select IdMenu,Tag,Descripcion From Menu Where IdMenu Not In (Select P.IdMenu From Permiso P Inner Join Menu M
		On M.IdMenu=P.IdMenu 
		Where P.IdUsuario=@IdUsuario And P.Estado=1)
	End
	If @Tipo=3
	Begin
		Declare @Indica Int
		Set @Indica=IsNull((Select IdPermiso From Permiso Where IdMenu=@IdMenu And IdUsuario=@IdUsuario And Estado=1),0)
		If @Indica=0
		Begin
			Set @IdPermiso=IsNull((Select Max(IdPermiso) From Permiso ),0)+1
			Insert Into Permiso Values(@IdPermiso,@IdMenu,@IdUsuario,1)
		End
		If @Indica>0
		Begin
			Update Permiso Set Estado=0
			Where IdPermiso=@Indica
		End
	End
End
GO
/****** Object:  StoredProcedure [dbo].[IAE_Presentacion]    Script Date: 11/12/2021 21:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[IAE_Presentacion]
	@Tipo Int,
	@IdPresentacion Int,
	@Descripcion Varchar(150),
	@Usuario Varchar(50),
	@Estado Bit
As
Begin
	If @Tipo=1
	Begin
		Select IdPresentacion,Descripcion From Presentacion Where Estado=@Estado
		Order By Descripcion
	End
	If @Tipo=2
	Begin
		Set @IdPresentacion=IsNull((Select Max(IdPresentacion) From Presentacion),0)+1
		Insert Into Presentacion Values(@IdPresentacion,@Descripcion,@Usuario,GETDATE(),NULL,NULL,1)
	End
	If @Tipo=3
	Begin
		Update Presentacion Set Descripcion=@Descripcion,UsuarioModifica=@Usuario,FechaModifica=Getdate()
		Where IdPresentacion=@IdPresentacion
	End
	If @Tipo=4
	Begin
		Update Presentacion Set Estado=@Estado,UsuarioModifica=@Usuario,FechaModifica=Getdate()
		Where IdPresentacion=@IdPresentacion
	End
End
GO
/****** Object:  StoredProcedure [dbo].[IAE_Producto]    Script Date: 11/12/2021 21:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[IAE_Producto]
	@Tipo Int,
	@IdProducto Int,
	@PrincipioActivo Varchar(5000),
	@IdLaboratorio Int,
	@IdPresenta Int,
	@Alternativo Bit,
	@StockMinimo Int,
	@Usuario Varchar(50),
	@Estado Bit
As
Begin
	If @Tipo=1
	Begin
		Select P.IdProducto,p.CodigoInterno,P.Descripcion,S.PrincipioActivo,S.IdLaboratorio,S.IdPresenta,S.Alternativo,S.StockMinimo From Producto S Inner Join ProductoFinal P On S.IdProducto=P.IdProducto
		Where P.Estado=@Estado Order By P.Descripcion
	End
	If @Tipo=2
	Begin
		Set @IdProducto=ISNULL((Select Max(IdProducto) From ProductoFinal),0)
		Insert Into Producto Values(@IdProducto,@PrincipioActivo,@IdLaboratorio,@IdPresenta,@Alternativo,@StockMinimo,@Usuario,Getdate(),Null,Null)
	End
	If @Tipo=3
	Begin
		Update Producto Set PrincipioActivo=@PrincipioActivo,IdLaboratorio=@IdLaboratorio,
		IdPresenta=@IdPresenta,Alternativo=@Alternativo,StockMinimo=@StockMinimo,
		UsuarioModifica=@Usuario,FechaModifica=Getdate()
		Where IdProducto=@IdProducto
	End
	If @Tipo=4
	Begin
		Select P.IdProducto,PF.Descripcion,P.Alternativo,
		IsNull((Select Vencimiento From DetalleInventario Where IdInventario=@IdLaboratorio And IdProducto=P.IdProducto And Estado=1),NULL ) 'Vencimiento',
		IsNull((Select Stock From DetalleInventario Where IdInventario=@IdLaboratorio And IdProducto=P.IdProducto And Estado=1),NULL ) 'Stock',
		IsNull((Select Lote From DetalleInventario Where IdInventario=@IdLaboratorio And IdProducto=P.IdProducto And Estado=1),NULL ) 'Lote',
		IsNull((Select PrecioCompra From DetalleInventario Where IdInventario=@IdLaboratorio And IdProducto=P.IdProducto And Estado=1),NULL ) 'PrecioCompra',
		IsNull((Select PrecioVenta From DetalleInventario Where IdInventario=@IdLaboratorio And IdProducto=P.IdProducto And Estado=1),NULL ) 'PrecioVenta',L.Descripcion 'Laboratorio',Pr.Descripcion 'Presentacion'
		From Producto P Inner Join ProductoFinal PF 
		On P.IdProducto=PF.IdProducto Inner Join Laboratorio L
			On L.IdLaboratorio=P.IdLaboratorio Inner Join Presentacion Pr On P.IdPresenta=Pr.IdPresentacion
	End
	If @Tipo=5
	Begin
		If @Estado=1
		Begin
			With xTemporal
			As
			(
			Select P.IdProducto,PF.Descripcion,P.Alternativo,L.Descripcion 'Laboratorio',P.PrincipioActivo,Px.Descripcion 'Presentacion' From Producto P   Inner Join ProductoFinal PF 
			On PF.IdProducto=P.IdProducto Inner Join Laboratorio L On P.IdLaboratorio=L.IdLaboratorio Inner Join Presentacion Px
			On Px.IdPresentacion=P.IdPresenta
			Where PF.Estado=1
			)
			Select T.*,IsNull(Sum(HP.Stock),0) 'Total' From xTemporal As T Left Join HistorialProducto HP
			On T.IdProducto=HP.IdProducto
			Where Descripcion Like '%' + @PrincipioActivo +  '%'
			Group By T.IdProducto,T.Descripcion,T.Alternativo,T.PrincipioActivo,T.Laboratorio,T.Presentacion
			Order By T.Descripcion
		End
		If @Estado=0
		Begin
			With xTemporal
			As
			(
			Select P.IdProducto,PF.Descripcion,P.Alternativo,L.Descripcion 'Laboratorio',P.PrincipioActivo,Px.Descripcion 'Presentacion' From Producto P   Inner Join ProductoFinal PF 
			On PF.IdProducto=P.IdProducto Inner Join Laboratorio L On P.IdLaboratorio=L.IdLaboratorio Inner Join Presentacion Px
			On Px.IdPresentacion=P.IdPresenta
			Where PF.Estado=1
			)
			Select T.*,IsNull(Sum(HP.Stock),0) 'Total' From xTemporal As T Left Join HistorialProducto HP
			On T.IdProducto=HP.IdProducto
			Where PrincipioActivo Like '%' + @PrincipioActivo +  '%'
			Group By T.IdProducto,T.Descripcion,T.Alternativo,T.PrincipioActivo,T.Laboratorio,T.Presentacion
			Order By T.Descripcion		
		End
	End
	If @Tipo=6
	Begin
		If @Estado=1
		Begin
			With xTemporal
			As
			(
			Select P.IdProducto,PF.Descripcion,P.Alternativo,L.Descripcion 'Laboratorio',P.PrincipioActivo,Px.Descripcion 'Presentacion' From Producto P   Inner Join ProductoFinal PF 
			On PF.IdProducto=P.IdProducto Inner Join Laboratorio L On P.IdLaboratorio=L.IdLaboratorio Inner Join Presentacion Px
			On Px.IdPresentacion=P.IdPresenta
			Where PF.Estado=1
			)
			Select T.*,IsNull(Sum(HP.Stock),0) 'Total' From xTemporal As T Left Join HistorialProducto HP
			On T.IdProducto=HP.IdProducto
			Where IdAlmacen=@IdProducto And Descripcion Like '%' + @PrincipioActivo +  '%'
			--And Stock>0
			Group By T.IdProducto,T.Descripcion,T.Alternativo,T.PrincipioActivo,T.Laboratorio,T.Presentacion
			Order By T.Descripcion
		End
		If @Estado=0
		Begin
			With xTemporal
			As
			(
			Select P.IdProducto,PF.Descripcion,P.Alternativo,L.Descripcion 'Laboratorio',P.PrincipioActivo,Px.Descripcion 'Presentacion' From Producto P   Inner Join ProductoFinal PF 
			On PF.IdProducto=P.IdProducto Inner Join Laboratorio L On P.IdLaboratorio=L.IdLaboratorio Inner Join Presentacion Px
			On Px.IdPresentacion=P.IdPresenta
			Where PF.Estado=1
			)
			Select T.*,IsNull(Sum(HP.Stock),0) 'Total' From xTemporal As T Left Join HistorialProducto HP
			On T.IdProducto=HP.IdProducto
			Where IdAlmacen=@IdProducto And PrincipioActivo Like '%' + @PrincipioActivo +  '%'
			--And Stock>0
			Group By T.IdProducto,T.Descripcion,T.Alternativo,T.PrincipioActivo,T.Laboratorio,T.Presentacion
			Order By T.Descripcion
		End
	End
	If @Tipo=7
	Begin
		Select P.IdProducto,P.Descripcion,S.PrincipioActivo,L.Descripcion 'Laboratorio',Pr.Descripcion 'Presentacion',S.Alternativo,S.StockMinimo From Producto S Inner Join ProductoFinal P On S.IdProducto=P.IdProducto
		Inner Join Presentacion Pr On S.IdPresenta=Pr.IdPresentacion Inner Join Laboratorio L
		On L.IdLaboratorio=S.IdLaboratorio
		Where P.Estado=@Estado
	End
	If @Tipo=8
	Begin
		With xTemporal
		As
		(
		Select P.IdProducto,PF.Descripcion,P.Alternativo,L.Descripcion 'Laboratorio',Px.Descripcion 'Presentacion' From Producto P   Inner Join ProductoFinal PF 
		On PF.IdProducto=P.IdProducto Inner Join Laboratorio L On P.IdLaboratorio=L.IdLaboratorio
		Inner Join Presentacion Px On Px.IdPresentacion=P.IdPresenta
		Where PF.Estado=1
		)
		Select T.*,IsNull(Sum(HP.Stock),0) 'Total' From xTemporal As T Left Join HistorialProducto HP
		On T.IdProducto=HP.IdProducto 
		Where IdAlmacen=@IdProducto And Descripcion Like '%' + @PrincipioActivo +  '%'
		Group By T.IdProducto,T.Descripcion,T.Alternativo,T.Laboratorio,T.Presentacion
		Order By T.Descripcion
	End
	If @Tipo=9
	Begin
		If @Estado=1
		Begin
			With xTemporal
			As
			(
			Select P.IdProducto,PF.Descripcion,P.Alternativo,L.Descripcion 'Laboratorio',P.PrincipioActivo,Pr.Descripcion 'Presentacion' From Producto P   Inner Join ProductoFinal PF 
			On PF.IdProducto=P.IdProducto Inner Join Laboratorio L On P.IdLaboratorio=L.IdLaboratorio Inner Join Presentacion Pr
			On Pr.IdPresentacion=P.IdPresenta
			Where PF.Estado=1
			)
			Select T.*,IsNull(Sum(HP.Stock),0) 'Total' From xTemporal As T Left Join HistorialProducto HP
			On T.IdProducto=HP.IdProducto
			Where Descripcion Like '%' + @PrincipioActivo +  '%'
			Group By T.IdProducto,T.Descripcion,T.Alternativo,T.PrincipioActivo,T.Laboratorio,T.Presentacion
			Order By T.Descripcion,T.Alternativo,T.Presentacion
		End
		If @Estado=0
		Begin
			With xTemporal
			As
			(
			Select P.IdProducto,PF.Descripcion,P.Alternativo,L.Descripcion 'Laboratorio',P.PrincipioActivo,Pr.Descripcion 'Presentacion' From Producto P   Inner Join ProductoFinal PF 
			On PF.IdProducto=P.IdProducto Inner Join Laboratorio L On P.IdLaboratorio=L.IdLaboratorio Inner Join Presentacion Pr
			On Pr.IdPresentacion=P.IdPresenta
			Where PF.Estado=1
			)
			Select T.*,IsNull(Sum(HP.Stock),0) 'Total' From xTemporal As T Left Join HistorialProducto HP
			On T.IdProducto=HP.IdProducto
			Where PrincipioActivo Like '%' + @PrincipioActivo +  '%'
			Group By T.IdProducto,T.Descripcion,T.Alternativo,T.PrincipioActivo,T.Laboratorio,T.Presentacion
		End
	End
	If @Tipo=10
	Begin
			With xTemporal
			As
			(
			Select P.IdProducto,PF.Descripcion,P.Alternativo,L.Descripcion 'Laboratorio',P.PrincipioActivo,Px.Descripcion 'Presentacion' From Producto P   Inner Join ProductoFinal PF 
			On PF.IdProducto=P.IdProducto Inner Join Laboratorio L On P.IdLaboratorio=L.IdLaboratorio Inner Join Presentacion Px
			On Px.IdPresentacion=P.IdPresenta
			Where PF.Estado=1
			)
			Select T.*,IsNull(Sum(HP.Stock),0) 'Total' From xTemporal As T Left Join HistorialProducto HP
			On T.IdProducto=HP.IdProducto
			Where T.IdProducto=@IdProducto 
			Group By T.IdProducto,T.Descripcion,T.Alternativo,T.PrincipioActivo,T.Laboratorio,T.Presentacion
			Order By T.Descripcion
     End
End

GO
/****** Object:  StoredProcedure [dbo].[IAE_ProductoFinal]    Script Date: 11/12/2021 21:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[IAE_ProductoFinal]
	@Tipo Int,
	@IdProducto Int,
	@CodigoInterno Varchar(5),
	@Descripcion Varchar(1000),
	@Usuario Varchar(50),
	@Estado Bit
As
Begin
	If @Tipo=1
	Begin
		Set @IdProducto=IsNull((Select MAX(IdProducto) From ProductoFinal),0)+1
		Insert Into ProductoFinal Values(@IdProducto,@CodigoInterno,@Descripcion,@Usuario,Getdate(),NULL,NULL,1)
	End
	If @Tipo=2
	Begin
		Update ProductoFinal Set Descripcion=@Descripcion,UsuarioModifica=@Usuario,FechaModifica=GETDATE()
		Where IdProducto=@IdProducto
	End
	If @Tipo=3
	Begin
		Update ProductoFinal Set Estado=@Estado Where IdProducto=@IdProducto
	End
End
GO
/****** Object:  StoredProcedure [dbo].[IAE_Proveedor]    Script Date: 11/12/2021 21:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[IAE_Proveedor]
	@Tipo Int,
	@IdProveedor Int,
	@RazonSocial Varchar(500),
	@Ruc Varchar(15),
	@Direccion Varchar(350),
	@Celular Varchar(10),
	@Contacto Varchar(100),
	@Usuario Varchar(50),
	@Estado Bit
As
Begin
	If @Tipo=1
	Begin
		Select IdProveedor,RazonSocial,Ruc,Direccion,Celular,Contacto From Proveedor
		Where Estado=@Estado Order By RazonSocial
	End
	If @Tipo=2
	Begin
		Set @IdProveedor=IsNull((Select MAX(IdProveedor) From Proveedor),0)+1
		Insert Into Proveedor Values(@IdProveedor,@RazonSocial,@Ruc,@Direccion,@Celular,@Contacto,@Usuario,GETDATE(),NULL,NULL,1)
	End
	If @Tipo=3 
	Begin
		Update Proveedor Set RazonSocial=@RazonSocial,Ruc=@Ruc,Direccion=@Direccion,Celular=@Celular,Contacto=@Contacto,
		FechaModifica=GETDATE(),UsuarioModifica=@Usuario Where IdProveedor=@IdProveedor
	End
	If @Tipo=4
	Begin
		Update Proveedor Set Estado=@Estado,FechaModifica=GETDATE(),UsuarioModifica=@Usuario 
		Where IdProveedor=@IdProveedor
	End
	If @Tipo=5
	Begin
		Select IdProveedor,Ruc,RazonSocial,Direccion From Proveedor Where Estado=@Estado
	End
End
GO
/****** Object:  StoredProcedure [dbo].[IAE_Salida]    Script Date: 11/12/2021 21:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[IAE_Salida]
	@Tipo Int,
	@IdSalida Int,
	@IdAlmacen Int,
	@IdPedido Int,
	@IdDocumento Varchar(2),
	@Serie Varchar(10),
	@Numero Int,
	@Fecha Datetime,
	@Porcentaje Decimal(18,2),
	@SubTotal Decimal(18,2),
	@Igv Decimal(18,2),
	@Total Decimal(18,2),
	@IdProveedor Int,
	@Nombre Varchar(250),
	@Codigo Int Output,
	@Usuario Varchar(50),
	@Estado Int
As 
Begin
	If @Tipo=1
	Begin
		Set @IdSalida=IsNull((Select MAX(IdSalida) From Salida),0)+1
		Set @Codigo=@IdSalida
		Set @Numero=(Select Top 1 Ultimo From DocumentoSerie Where Estado=1 And IdDocumento=@IdDocumento And Serie=@Serie)+1
		Insert Into Salida Values(@IdSalida,@IdAlmacen,@IdPedido,@IdDocumento,@Serie,@Numero,@Fecha,@Porcentaje,@SubTotal,
					@Igv,@Total,@IdProveedor,@Nombre,@Usuario,Getdate(),NULL,NULL,1)
	End
End

GO
/****** Object:  StoredProcedure [dbo].[IAE_Sede]    Script Date: 11/12/2021 21:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[IAE_Sede]
	@Tipo Int,
	@IdSede Int,
	@Descripcion Varchar(150),
	@Direccion Varchar(150),
	@Usuario Varchar(50),
	@Estado Bit
As
Begin
	If @Tipo=1
	Begin
		Select IdSede,Descripcion,Direccion From Sede Where Estado=@Estado
		Order By Descripcion
	End
	If @Tipo=2
	Begin
		Set @IdSede=IsNull((Select Max(IdSede) From Sede),0)+1
		Insert Into Sede Values(@IdSede,@Descripcion,@Direccion,@Usuario,GETDATE(),NULL,NULL,1)
	End
	If @Tipo=3
	Begin
		Update Sede Set Descripcion=@Descripcion,Direccion=@Direccion, UsuarioModifica=@Usuario,FechaModifica=Getdate()
		Where IdSede=@IdSede
	End
	If @Tipo=4
	Begin
		Update Sede Set Estado=@Estado,UsuarioModifica=@Usuario,FechaModifica=Getdate()
		Where IdSede=@IdSede
	End
End
GO
/****** Object:  StoredProcedure [dbo].[IAE_Servicio]    Script Date: 11/12/2021 21:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[IAE_Servicio]
	@Tipo Int,
	@IdServicio Int,
	@Paquete Bit,
	@Precio Decimal(18,2),
	@Usuario Varchar(50),
	@Estado Bit
As
Begin
	If @Tipo=1
	Begin
		Select P.IdProducto,P.Descripcion,S.Precio,S.Paquete From Servicio S Inner Join ProductoFinal P On S.IdServicio=P.IdProducto
		Where P.Estado=@Estado Order By P.Descripcion
	End
	If @Tipo=2
	Begin
		Set @IdServicio=ISNULL((Select Max(IdProducto) From ProductoFinal),0)
		Insert Into Servicio Values(@IdServicio,@Precio,@Paquete,@Usuario,Getdate(),Null,Null)
	End
	If @Tipo=3
	Begin
		Update Servicio Set Precio=@Precio,Paquete=@Paquete,UsuarioModifica=@Usuario,FechaModifica=Getdate()
		Where IdServicio=@IdServicio
	End
	If @Tipo=4
	Begin
		Select S.IdServicio,Pr.Descripcion,
		Case When Exists(Select *From PaqueteServicio P Where P.Estado=1 And P.IdPaquete=@IdServicio And P.IdServicio=S.IdServicio ) Then 1 Else 0 End 'Seleccionar'
		From Servicio S Inner Join ProductoFinal Pr On S.IdServicio=Pr.IdProducto
		Where Paquete=0
	End
	If @Tipo=5
	Begin
		Select S.IdServicio,PF.Descripcion,S.Paquete,S.Precio From Servicio S Inner Join ProductoFinal PF
		On S.IdServicio=PF.IdProducto Where PF.Estado=1
	End
End
GO
/****** Object:  StoredProcedure [dbo].[IAE_Tarjeta]    Script Date: 11/12/2021 21:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[IAE_Tarjeta]
	@Tipo Int,
	@IdTarjeta Int,
	@Fecha Datetime,
	@IdHistorial Int,
	@IdAlmacen Int,
	@TipoMovimiento Int,
	@IdReferencia Int,
	@Lote Varchar(50),
	@Vencimiento Datetime,
	@IdDocumento Varchar(2),
	@Serie Varchar(10),
	@Numero Int,
	@IdProducto Int,
	@Entrada Int,
	@Salida Int,
	@Existencia Int,
	@PrecioCompra Decimal(18,2),
	@PrecioVenta Decimal(18,2),
	@Debe Decimal(18,2),
	@Haber Decimal(18,2),
	@Saldo Decimal(18,2),
	@Usuario Varchar(50),
	@Codigo Int Output,
	@Estado Bit
As
Begin
	Set @Lote=ISNULL(@Lote,'')
	Declare @Verifica Int
	If @Tipo=1
	Begin
		Set @Verifica=(Select COUNT(*) From Tarjeta Where IdProducto=@IdProducto And IdAlmacen=@IdAlmacen )
		Set @IdDocumento=IsNull((Select Valor From Parametros Where Clave='ID_INVENTARIO'),NULL)
		Set @Serie=IsNull((Select Serie From DocumentoSerie Where IdDocumento=@IdDocumento And Estado=1),'')
		Set @Numero=IsNull((Select Count(IdInventario) From Inventario Where IdAlmacen=@IdAlmacen),0)
		Set @Saldo=@PrecioCompra*@Entrada
		If @Verifica=0
		Begin
			Set @IdTarjeta=IsNull((Select MAX(IdTarjeta) From Tarjeta) ,0)+1
			Set @Codigo=@IdTarjeta
			Insert Into Tarjeta Values(@IdTarjeta,@Fecha,@IdHistorial,@IdAlmacen,@TipoMovimiento,@IdReferencia,@Lote,@Vencimiento,@IdDocumento,@Serie,@Numero,@IdProducto,
			@Existencia,0,@Existencia,@PrecioCompra,@PrecioVenta,@Debe,@Haber,@Saldo,@Usuario,Getdate(),NULL,NULL,1)
		End
		Else
		Begin
			Update Tarjeta Set Entrada=@Existencia,Salida=0,Existencia=@Existencia,PrecioCompra=@PrecioCompra,Vencimiento=@Vencimiento,
			Serie=@Serie,Numero=@Numero,Lote=@Lote, 
			PrecioVenta=@PrecioVenta,Debe=@Debe,Haber=@Haber,Saldo=@Saldo,UsuarioModifica=@Usuario,FechaModifica=Getdate()
			Where IdAlmacen=@IdAlmacen And IdProducto=@IdProducto And IdDocumento=@IdDocumento
		End
	End
	If @Tipo=2
	Begin
		If @Estado=0 Begin Set @Vencimiento=Null End Else Begin Set @Vencimiento=Convert(date,@Vencimiento) End
		Set @Saldo=@PrecioCompra*@Entrada
		Set @IdTarjeta=IsNull((Select MAX(IdTarjeta) From Tarjeta) ,0)+1
		Set @Existencia=IsNull((Select Top 1 Existencia From Tarjeta Where IdProducto=@IdProducto And IdAlmacen=@IdAlmacen
						 And Lote=@Lote Order By IdTarjeta Desc),0)+@Entrada 
		Set @Saldo=IsNull((Select Top 1 Saldo From Tarjeta Where IdProducto=@IdProducto And IdAlmacen=@IdAlmacen
						 And Lote=@Lote Order By IdTarjeta Desc),0)+@Saldo 
		Set @Debe=@PrecioCompra*@Entrada
		Set @Codigo=@IdTarjeta
		Insert Into Tarjeta Values(@IdTarjeta,@Fecha,@IdHistorial,@IdAlmacen,@TipoMovimiento,@IdReferencia,@Lote,@Vencimiento,@IdDocumento,@Serie,@Numero,@IdProducto,
		@Entrada,0,@Existencia,@PrecioCompra,@PrecioVenta,@Debe,@Haber,@Saldo,@Usuario,Getdate(),NULL,NULL,1)
	End
	If @Tipo=3
	Begin
		If @Estado=0 Begin Set @Vencimiento=Null End
		Set @Saldo=@PrecioCompra*@Entrada
		Set @IdTarjeta=IsNull((Select MAX(IdTarjeta) From Tarjeta) ,0)+1
		Set @Existencia=IsNull((Select Top 1 Existencia From Tarjeta Where IdProducto=@IdProducto And IdAlmacen=@IdAlmacen
						 And Lote=@Lote Order By IdTarjeta Desc),0)-@Salida 
						 Set @Haber=@PrecioCompra*@Salida
		Set @Saldo=IsNull((Select Top 1 Saldo From Tarjeta Where IdProducto=@IdProducto And IdAlmacen=@IdAlmacen
						 And Lote=@Lote Order By IdTarjeta Desc),0)-(@PrecioCompra*@Salida)
		Set @Codigo=@IdTarjeta
		Insert Into Tarjeta Values(@IdTarjeta,@Fecha,@IdHistorial,@IdAlmacen,@TipoMovimiento,@IdReferencia,@Lote,@Vencimiento,@IdDocumento,@Serie,@Numero,@IdProducto,
		0,@Salida,@Existencia,@PrecioCompra,@PrecioVenta,@Debe,@Haber,@Saldo,@Usuario,Getdate(),NULL,NULL,1)
	End
	If @Tipo=4
	Begin
		Set @Codigo=(Select IdHistorial From Tarjeta Where IdTarjeta=@IdTarjeta)
		Update Tarjeta Set Estado=0,UsuarioModifica=@Usuario,FechaModifica=Getdate()
		Where IdTarjeta=@IdTarjeta
	End
End
GO
/****** Object:  StoredProcedure [dbo].[IAE_Transferencia]    Script Date: 11/12/2021 21:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[IAE_Transferencia]
	@Tipo Int,
	@IdTransferencia Int,
	@Fecha Datetime,
	@IdAlmacenOrigen Int,
	@IdAlmacenDestino Int,
	@IdDocumento Varchar(2),
	@Serie Varchar(10),
	@Numero Int,
	@Codigo Int Output,
	@Usuario Varchar(50),
	@Estado Bit
As
Begin
	If @Tipo=1
	Begin
		Set @IdTransferencia=IsNull((Select Max(IdTransferencia) From Transferencia),0)+1
		Set @Codigo=@IdTransferencia
		Insert Into Transferencia Values(@IdTransferencia,@Fecha,@IdAlmacenOrigen,@IdAlmacenDestino,@IdDocumento,
										@Serie,@Numero,@Usuario,Getdate(),NULL,NULL,1)
	End
End
GO
/****** Object:  StoredProcedure [dbo].[IAE_Usuario]    Script Date: 11/12/2021 21:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[IAE_Usuario] 
	@Tipo Int,
	@IdUsuario Int,
	@Nombres Varchar(300),
	@Dni Varchar(8),
	@Direccion Varchar(300),
	@Celular Varchar(10),
	@Login Varchar(50),
	@Clave Varchar(8000),
	@Usuario Varchar(11),
	@Estado Bit
As
Begin
	If @Tipo=1
	Begin
		Select IdUsuario,Nombres,Login,Dni,Direccion,Celular From Usuario
		Where Estado=@Estado Order By Nombres
	End
	If @Tipo=2
	Begin
		Declare @Verifica Int
		Set @Verifica=IsNull((Select Count(*) From Usuario Where Login=@Login),0)
		If @Verifica=0
		Begin
			Set @IdUsuario=IsNull((Select MAX(IdUsuario) From Usuario),0)+1
			Insert Into Usuario Values(@IdUsuario,@Nombres,@Dni,@Direccion,@Celular,@Login,ENCRYPTBYPASSPHRASE('INGUIRI.JULIO',@Clave),@Usuario,GETDATE(),NULL,NULL,1)
		End
	End
	If @Tipo=3 
	Begin
		Update Usuario Set Estado=0,FechaModifica=GETDATE(),UsuarioModifica=@Usuario 
		Where IdUsuario=@IdUsuario
	End
	If @Tipo=4
	Begin
		Select COUNT(*) From Usuario Where Login=@Login
		And CONVERT(varchar,DECRYPTBYPASSPHRASE('INGUIRI.JULIO',Clave))=@Clave
	End
	If @Tipo=5
	Begin
		Update Usuario Set Clave=ENCRYPTBYPASSPHRASE('INGUIRI.JULIO',@Clave),UsuarioModifica=@Usuario,
		FechaModifica=Getdate() Where Login=@Login
	End
	If @Tipo=6
	Begin
		Select Login From Usuario Where IdUsuario=@IdUsuario
	End
	If @Tipo=7
	Begin
		Declare @Fecha Varchar(30)
		Set @Fecha=(Select Top 1 IsNull(FechaInicio,'') From Caja Where Estado=1 Order By IdCaja Desc)
		Set @Fecha=IsNull(@Fecha,'')
		--Select Convert(Varchar,Convert(Datetime,@Fecha),103)
		--Select Case When @Fecha <>'' Then CONVERT(Varchar(300),@Fecha,103) Else @Fecha End
		Select IdUsuario,Nombres,Login,Case When @Fecha <>'' Then Convert(Varchar,Convert(Datetime,@Fecha),103) Else @Fecha End From Usuario
		Where Login=@Login And CONVERT(varchar,DECRYPTBYPASSPHRASE('INGUIRI.JULIO',Clave))=@Clave
	End
End
GO
/****** Object:  StoredProcedure [dbo].[IAE_Venta]    Script Date: 11/12/2021 21:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[IAE_Venta]
	@Tipo Int,
	@IdVenta Int,
	@IdAlmacen Int,
	@IdPedido Int,
	@IdDocumento Varchar(2),
	@Serie Varchar(10),
	@Numero Int,
	@Fecha Datetime,
	@Porcentaje Decimal(18,2),
	@SubTotal Decimal(18,2),
	@Igv Decimal(18,2),
	@Total Decimal(18,2),
	@IdCliente Int,
	@Nombre Varchar(250),
	@IdVendedor Varchar(50),
	@IdCajero Varchar(50),
	@Codigo Int Output,
	@Usuario Varchar(50),
	@Estado Int
As 
Begin
	If @Tipo=1
	Begin
		Set @IdVenta=IsNull((Select MAX(IdVenta) From Venta),0)+1
		Set @Codigo=@IdVenta
		Set @Numero=(Select Top 1 Ultimo From DocumentoSerie Where Estado=1 And IdDocumento=@IdDocumento And Serie=@Serie)+1
		Insert Into Venta Values(@IdVenta,@IdAlmacen,@IdPedido,@IdDocumento,@Serie,@Numero,@Fecha,@Porcentaje,@SubTotal,
					@Igv,@Total,@IdCliente,@Nombre,@IdVendedor,@IdCajero,@Usuario,Getdate(),NULL,NULL,1)
	End
	If @Tipo=2
	Begin
		Select V.IdVenta,A.IdAlmacen,D.Descripcion 'Documento',
		Right('0000000000'+V.Serie,10) + ' - ' + Right('0000000000' +Convert(Varchar,V.Numero),10) 'Numeracion',
		C.IdCliente,C.Nombres,V.Fecha,V.Total,V.Estado,P.Numero 
		From Venta V Inner Join Cliente C
		On C.IdCliente=V.IdCliente Inner Join Documento D On D.IdDocumento=V.IdDocumento Inner Join Almacen A
		On A.IdAlmacen=V.IdAlmacen Left Join Pedido P On P.IdPedido=V.IdPedido
		Where V.IdAlmacen=@IdAlmacen And DATEDIFF(DAY,V.Fecha,@Fecha)<=0 And DATEDIFF(DAY,V.Fecha,Convert(Date,@Serie))>=0
	End
	If @Tipo=3
	Begin
		Select IdDetalleVenta,IdVenta,IdTarjeta,P.IdProducto,P.Descripcion,Lote, Cantidad,Precio, Cantidad*Precio 'SubTotal',Descuento,(Cantidad*Precio -Descuento) 'Total' From DetalleVenta DV
		Inner Join ProductoFinal P On P.IdProducto=DV.IdProducto
		Where IdVenta=@IdVenta
	End
	If @Tipo=4
	Begin
		Update Venta Set Estado=0,UsuarioModifica=@Usuario,FechaModifica=Getdate()
		Where IdVenta=@IdVenta
	End
	If @Tipo=5
	Begin
		With xTemporal
		As
		(
		Select DV.IdProducto,PF.Descripcion,SUM(Cantidad) 'Total' From DetalleVenta DV 
		Inner Join Producto P On P.IdProducto=Dv.IdProducto
		Inner Join Venta V On V.IdVenta=DV.IdVenta Inner Join ProductoFinal PF
		On PF.IdProducto=P.IdProducto
		Where DATEDIFF(DAY,V.Fecha,@Fecha)<=0 And DATEDIFF(DAY,V.Fecha,Convert(Date,@Serie))>=0
		And V.IdAlmacen=@IdAlmacen
		Group By Dv.IdProducto,PF.Descripcion
		)
		Select Top (@Numero) T.IdProducto,T.Descripcion,P.Alternativo,L.Descripcion 'Laboratorio',T.Total From xTemporal T Inner Join Producto P On P.IdProducto=T.IdProducto
		Inner Join Laboratorio L On L.IdLaboratorio=p.IdLaboratorio
		Order By Total Desc
	End
	If @Tipo=6
	Begin
		With xTemporal
		As
		(
		Select DV.IdProducto,PF.Descripcion,SUM(Cantidad) 'Total' From DetalleVenta DV 
		Inner Join Producto P On P.IdProducto=Dv.IdProducto
		Inner Join Venta V On V.IdVenta=DV.IdVenta Inner Join ProductoFinal PF
		On PF.IdProducto=P.IdProducto
		Where DATEDIFF(DAY,V.Fecha,@Fecha)<=0 And DATEDIFF(DAY,V.Fecha,Convert(Date,@Serie))>=0
		And V.IdAlmacen=@IdAlmacen And V.Estado=1 And DV.Estado=1
		Group By Dv.IdProducto,PF.Descripcion
		)
		Select Top (@Numero) T.IdProducto,T.Descripcion,P.Alternativo,L.Descripcion 'Laboratorio',T.Total From xTemporal T Inner Join Producto P On P.IdProducto=T.IdProducto
		Inner Join Laboratorio L On L.IdLaboratorio=p.IdLaboratorio
		Order By Total Asc
	End
	If @Tipo=7
	Begin
		Select Convert(Varchar,V.Fecha,103) 'Fecha',SUM((DV.Cantidad*DV.Precio)-Descuento) 'Total',SUM((DV.Cantidad*DV.Ganancia)-Descuento) 'Ganancia' From Venta V Inner Join DetalleVenta DV On V.IdVenta=DV.IdVenta
		Where V.IdAlmacen=@IdAlmacen And DATEDIFF(DAY,V.Fecha,@Fecha)<=0 And DATEDIFF(DAY,V.Fecha,Convert(Date,@Serie))>=0
		Group By Convert(Varchar,V.Fecha,103)
	End
	If @Tipo=8
	Begin
		Select V.IdVenta,V.Fecha,V.Serie,D.Descripcion 'Documento',V.Numero,V.Total,V.Nombre,PF.Descripcion 'Producto',(Dv.Precio*Dv.Cantidad) 'Precio',Dv.Cantidad,V.UsuarioCrea 'IdVendedor',V.FechaCrea,Dv.Descuento From Venta V Inner Join DetalleVenta Dv On V.IdVenta=Dv.IdVenta 
		Inner Join Documento D On D.IdDocumento=V.IdDocumento Inner Join ProductoFinal PF On PF.IdProducto=Dv.IdProducto
		Where V.IdVenta= @IdVenta
	End
	If @Tipo=9
	Begin
		Select P.IdProducto,V.FechaCrea,P.Descripcion,Lote, Cantidad,Precio, Cantidad*Precio 'SubTotal',Descuento,(Cantidad*Precio -Descuento) 'Total' From DetalleVenta DV
		Inner Join ProductoFinal P On P.IdProducto=DV.IdProducto Inner Join Venta V On V.IdVenta=Dv.IdVenta
		Where Dv.IdProducto=@IdPedido and V.IdAlmacen=@IdAlmacen
		And DATEDIFF(Day,@Fecha,V.Fecha)>=0  And DATEDIFF(Day,CONVERT(Date,@IdVendedor),V.Fecha)<=0  
	End
	If @Tipo=10
	Begin
		Select V.IdVenta,C.Nombres,V.Fecha,D.Descripcion + '-' +V.Serie + '/' + RIGHT('0000000000'+ Convert(Varchar,V.Numero),9) 'Documento',V.IdCajero,PF.Descripcion 'Medicamento',DV.Cantidad,DV.Precio,DV.Descuento From Venta V Inner Join DetalleVenta DV
		On V.IdVenta=DV.IdVenta Inner Join ProductoFinal PF On PF.IdProducto=DV.IdProducto Inner Join Cliente C
		On C.IdCliente=V.IdCliente Inner Join Documento D On D.IdDocumento=V.IdDocumento
		Where DATEDIFF(Day,@Fecha,V.Fecha)>=0  And DATEDIFF(Day,CONVERT(Date,@IdVendedor),V.Fecha)<=0  
		Order By Fecha
	End
End

GO
