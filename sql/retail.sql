USE [Retail]
GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 03/26/2014 12:06:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Supplier](
	[SupplierID] [int] IDENTITY(1,1) NOT NULL,
	[NamaSupplier] [varchar](50) NULL,
	[Jalan] [varchar](100) NULL,
	[Kota] [varchar](50) NULL,
 CONSTRAINT [PK_Supplier] PRIMARY KEY CLUSTERED 
(
	[SupplierID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Barang]    Script Date: 03/26/2014 12:06:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Barang](
	[BarangID] [varchar](20) NOT NULL,
	[NamaBarang] [varchar](50) NULL,
	[HargaBeli] [int] NULL,
	[HargaJual] [int] NULL,
	[Stok] [nchar](10) NULL,
 CONSTRAINT [PK_Barang] PRIMARY KEY CLUSTERED 
(
	[BarangID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Beli]    Script Date: 03/26/2014 12:06:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Beli](
	[Nota] [varchar](10) NOT NULL,
	[SupplierID] [int] NULL,
	[Tanggal] [datetime] NULL,
	[Keterangan] [varchar](50) NULL,
 CONSTRAINT [PK_Beli] PRIMARY KEY CLUSTERED 
(
	[Nota] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ItemBeli]    Script Date: 03/26/2014 12:06:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ItemBeli](
	[ItemBeliID] [int] IDENTITY(1,1) NOT NULL,
	[Nota] [varchar](10) NULL,
	[BarangID] [varchar](20) NULL,
	[Jumlah] [int] NULL,
	[HargaBeli] [int] NULL,
	[HargaJual] [int] NULL,
 CONSTRAINT [PK_ItemBeli] PRIMARY KEY CLUSTERED 
(
	[ItemBeliID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  ForeignKey [FK_Beli_Supplier]    Script Date: 03/26/2014 12:06:46 ******/
ALTER TABLE [dbo].[Beli]  WITH CHECK ADD  CONSTRAINT [FK_Beli_Supplier] FOREIGN KEY([SupplierID])
REFERENCES [dbo].[Supplier] ([SupplierID])
GO
ALTER TABLE [dbo].[Beli] CHECK CONSTRAINT [FK_Beli_Supplier]
GO
/****** Object:  ForeignKey [FK_ItemBeli_Barang]    Script Date: 03/26/2014 12:06:46 ******/
ALTER TABLE [dbo].[ItemBeli]  WITH CHECK ADD  CONSTRAINT [FK_ItemBeli_Barang] FOREIGN KEY([BarangID])
REFERENCES [dbo].[Barang] ([BarangID])
GO
ALTER TABLE [dbo].[ItemBeli] CHECK CONSTRAINT [FK_ItemBeli_Barang]
GO
/****** Object:  ForeignKey [FK_ItemBeli_Beli]    Script Date: 03/26/2014 12:06:46 ******/
ALTER TABLE [dbo].[ItemBeli]  WITH CHECK ADD  CONSTRAINT [FK_ItemBeli_Beli] FOREIGN KEY([Nota])
REFERENCES [dbo].[Beli] ([Nota])
GO
ALTER TABLE [dbo].[ItemBeli] CHECK CONSTRAINT [FK_ItemBeli_Beli]
GO
