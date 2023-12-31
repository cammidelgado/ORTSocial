USE [master]
GO
/****** Object:  Database [ORTSocialDB]    Script Date: 22/11/2023 21:48:02 ******/
CREATE DATABASE [ORTSocialDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ORTSocialDB', FILENAME = N'C:\SQLData\ORTSocialDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ORTSocialDB_log', FILENAME = N'C:\SQLData\ORTSocialDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [ORTSocialDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ORTSocialDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ORTSocialDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ORTSocialDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ORTSocialDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ORTSocialDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ORTSocialDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ORTSocialDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ORTSocialDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ORTSocialDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ORTSocialDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ORTSocialDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ORTSocialDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ORTSocialDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ORTSocialDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ORTSocialDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ORTSocialDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ORTSocialDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ORTSocialDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ORTSocialDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ORTSocialDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ORTSocialDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ORTSocialDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [ORTSocialDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ORTSocialDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ORTSocialDB] SET  MULTI_USER 
GO
ALTER DATABASE [ORTSocialDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ORTSocialDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ORTSocialDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ORTSocialDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ORTSocialDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ORTSocialDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ORTSocialDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [ORTSocialDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [ORTSocialDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 22/11/2023 21:48:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cartillas]    Script Date: 22/11/2023 21:48:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cartillas](
	[IdCartilla] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Cartillas] PRIMARY KEY CLUSTERED 
(
	[IdCartilla] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CartillasMedicos]    Script Date: 22/11/2023 21:48:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CartillasMedicos](
	[idCartillaMedico] [int] NOT NULL,
	[IdCartilla] [int] NOT NULL,
	[IdMedico] [int] NOT NULL,
 CONSTRAINT [PK_CartillasMedicos] PRIMARY KEY CLUSTERED 
(
	[idCartillaMedico] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Familiares]    Script Date: 22/11/2023 21:48:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Familiares](
	[IdFamiliar] [int] IDENTITY(1,1) NOT NULL,
	[Dni] [int] NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[Apellido] [nvarchar](max) NOT NULL,
	[IdGrupoFamiliar] [int] NOT NULL,
 CONSTRAINT [PK_Familiares] PRIMARY KEY CLUSTERED 
(
	[IdFamiliar] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GruposFamiliares]    Script Date: 22/11/2023 21:48:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GruposFamiliares](
	[IdGrupoFamiliar] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[Cantidad] [int] NOT NULL,
 CONSTRAINT [PK_GruposFamiliares] PRIMARY KEY CLUSTERED 
(
	[IdGrupoFamiliar] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Medicos]    Script Date: 22/11/2023 21:48:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medicos](
	[IdMedico] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[Dni] [nvarchar](max) NOT NULL,
	[Especialidad] [int] NOT NULL,
 CONSTRAINT [PK_Medicos] PRIMARY KEY CLUSTERED 
(
	[IdMedico] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Planes]    Script Date: 22/11/2023 21:48:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Planes](
	[IdPlan] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[Costo] [real] NOT NULL,
	[CantFamiliares] [int] NOT NULL,
	[IdCartilla] [int] NOT NULL,
 CONSTRAINT [PK_Planes] PRIMARY KEY CLUSTERED 
(
	[IdPlan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Socios]    Script Date: 22/11/2023 21:48:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Socios](
	[IdSocio] [int] IDENTITY(1,1) NOT NULL,
	[Dni] [int] NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[Apellido] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Telefono] [int] NOT NULL,
	[Provincia] [nvarchar](max) NOT NULL,
	[Ciudad] [nvarchar](max) NOT NULL,
	[IdPlan] [int] NOT NULL,
	[IdGrupoFamiliar] [int] NOT NULL,
 CONSTRAINT [PK_Socios] PRIMARY KEY CLUSTERED 
(
	[IdSocio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TurnosMedicos]    Script Date: 22/11/2023 21:48:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TurnosMedicos](
	[idTurno] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime2](7) NOT NULL,
	[IdMedico] [int] NOT NULL,
	[IdSocio] [int] NOT NULL,
 CONSTRAINT [PK_TurnosMedicos] PRIMARY KEY CLUSTERED 
(
	[idTurno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231117151634_1', N'7.0.13')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231117200733_2', N'7.0.13')
GO
SET IDENTITY_INSERT [dbo].[Cartillas] ON 

INSERT [dbo].[Cartillas] ([IdCartilla], [Nombre]) VALUES (1, N'Bronce')
INSERT [dbo].[Cartillas] ([IdCartilla], [Nombre]) VALUES (2, N'Plata')
INSERT [dbo].[Cartillas] ([IdCartilla], [Nombre]) VALUES (3, N'Oro')
SET IDENTITY_INSERT [dbo].[Cartillas] OFF
GO
INSERT [dbo].[CartillasMedicos] ([idCartillaMedico], [IdCartilla], [IdMedico]) VALUES (1, 3, 1)
INSERT [dbo].[CartillasMedicos] ([idCartillaMedico], [IdCartilla], [IdMedico]) VALUES (2, 3, 2)
INSERT [dbo].[CartillasMedicos] ([idCartillaMedico], [IdCartilla], [IdMedico]) VALUES (3, 3, 3)
INSERT [dbo].[CartillasMedicos] ([idCartillaMedico], [IdCartilla], [IdMedico]) VALUES (4, 3, 4)
INSERT [dbo].[CartillasMedicos] ([idCartillaMedico], [IdCartilla], [IdMedico]) VALUES (5, 3, 5)
INSERT [dbo].[CartillasMedicos] ([idCartillaMedico], [IdCartilla], [IdMedico]) VALUES (6, 3, 6)
INSERT [dbo].[CartillasMedicos] ([idCartillaMedico], [IdCartilla], [IdMedico]) VALUES (7, 3, 7)
INSERT [dbo].[CartillasMedicos] ([idCartillaMedico], [IdCartilla], [IdMedico]) VALUES (8, 2, 1)
INSERT [dbo].[CartillasMedicos] ([idCartillaMedico], [IdCartilla], [IdMedico]) VALUES (9, 2, 3)
INSERT [dbo].[CartillasMedicos] ([idCartillaMedico], [IdCartilla], [IdMedico]) VALUES (10, 2, 5)
INSERT [dbo].[CartillasMedicos] ([idCartillaMedico], [IdCartilla], [IdMedico]) VALUES (11, 2, 7)
INSERT [dbo].[CartillasMedicos] ([idCartillaMedico], [IdCartilla], [IdMedico]) VALUES (12, 1, 2)
INSERT [dbo].[CartillasMedicos] ([idCartillaMedico], [IdCartilla], [IdMedico]) VALUES (13, 1, 4)
INSERT [dbo].[CartillasMedicos] ([idCartillaMedico], [IdCartilla], [IdMedico]) VALUES (14, 1, 6)
GO
SET IDENTITY_INSERT [dbo].[Familiares] ON 

INSERT [dbo].[Familiares] ([IdFamiliar], [Dni], [Nombre], [Apellido], [IdGrupoFamiliar]) VALUES (7, 20457102, N'Karina', N'Castrignano', 16)
INSERT [dbo].[Familiares] ([IdFamiliar], [Dni], [Nombre], [Apellido], [IdGrupoFamiliar]) VALUES (8, 12345678, N'Prueba', N'Delgado', 12)
SET IDENTITY_INSERT [dbo].[Familiares] OFF
GO
SET IDENTITY_INSERT [dbo].[GruposFamiliares] ON 

INSERT [dbo].[GruposFamiliares] ([IdGrupoFamiliar], [Nombre], [Cantidad]) VALUES (12, N'Default', 1)
INSERT [dbo].[GruposFamiliares] ([IdGrupoFamiliar], [Nombre], [Cantidad]) VALUES (16, N'Familia Delgado', 3)
INSERT [dbo].[GruposFamiliares] ([IdGrupoFamiliar], [Nombre], [Cantidad]) VALUES (17, N'Familia Calvo', 1)
SET IDENTITY_INSERT [dbo].[GruposFamiliares] OFF
GO
SET IDENTITY_INSERT [dbo].[Medicos] ON 

INSERT [dbo].[Medicos] ([IdMedico], [Nombre], [Dni], [Especialidad]) VALUES (1, N'Juan Perez', N'12345678', 0)
INSERT [dbo].[Medicos] ([IdMedico], [Nombre], [Dni], [Especialidad]) VALUES (2, N'Christian Slapak', N'87654321', 1)
INSERT [dbo].[Medicos] ([IdMedico], [Nombre], [Dni], [Especialidad]) VALUES (3, N'Camila Delgado', N'12121212', 2)
INSERT [dbo].[Medicos] ([IdMedico], [Nombre], [Dni], [Especialidad]) VALUES (4, N'Tobias Calvo', N'34343434', 3)
INSERT [dbo].[Medicos] ([IdMedico], [Nombre], [Dni], [Especialidad]) VALUES (5, N'Florencia Torres', N'56565656', 4)
INSERT [dbo].[Medicos] ([IdMedico], [Nombre], [Dni], [Especialidad]) VALUES (6, N'Ramiro Lopez', N'78787878', 5)
INSERT [dbo].[Medicos] ([IdMedico], [Nombre], [Dni], [Especialidad]) VALUES (7, N'Agostina Martinez', N'90909090', 6)
SET IDENTITY_INSERT [dbo].[Medicos] OFF
GO
SET IDENTITY_INSERT [dbo].[Planes] ON 

INSERT [dbo].[Planes] ([IdPlan], [Nombre], [Costo], [CantFamiliares], [IdCartilla]) VALUES (1, N'Bronce', 30000, 3, 1)
INSERT [dbo].[Planes] ([IdPlan], [Nombre], [Costo], [CantFamiliares], [IdCartilla]) VALUES (2, N'Plata', 45000, 5, 2)
INSERT [dbo].[Planes] ([IdPlan], [Nombre], [Costo], [CantFamiliares], [IdCartilla]) VALUES (3, N'Oro', 65000, 7, 3)
SET IDENTITY_INSERT [dbo].[Planes] OFF
GO
SET IDENTITY_INSERT [dbo].[Socios] ON 

INSERT [dbo].[Socios] ([IdSocio], [Dni], [Nombre], [Apellido], [Email], [Telefono], [Provincia], [Ciudad], [IdPlan], [IdGrupoFamiliar]) VALUES (11, 44871993, N'Camila', N'Delgado', N'camiladelgado187@gmail.com', 1134464656, N'Buenos Aires', N'Buenos Aires', 2, 16)
INSERT [dbo].[Socios] ([IdSocio], [Dni], [Nombre], [Apellido], [Email], [Telefono], [Provincia], [Ciudad], [IdPlan], [IdGrupoFamiliar]) VALUES (12, 20587412, N'Dario', N'Delgado', N'dariodel68@gmail.com', 1141445396, N'Buenos Aires', N'Buenos Aires', 1, 16)
INSERT [dbo].[Socios] ([IdSocio], [Dni], [Nombre], [Apellido], [Email], [Telefono], [Provincia], [Ciudad], [IdPlan], [IdGrupoFamiliar]) VALUES (13, 87654321, N'Tobias', N'Calvo', N'tb@gmail.com', 115789634, N'Buenos Aires', N'Buenos Aires', 2, 17)
SET IDENTITY_INSERT [dbo].[Socios] OFF
GO
SET IDENTITY_INSERT [dbo].[TurnosMedicos] ON 

INSERT [dbo].[TurnosMedicos] ([idTurno], [Fecha], [IdMedico], [IdSocio]) VALUES (24, CAST(N'2023-11-30T15:00:00.0000000' AS DateTime2), 5, 11)
INSERT [dbo].[TurnosMedicos] ([idTurno], [Fecha], [IdMedico], [IdSocio]) VALUES (25, CAST(N'2023-11-24T21:36:00.0000000' AS DateTime2), 5, 13)
SET IDENTITY_INSERT [dbo].[TurnosMedicos] OFF
GO
/****** Object:  Index [IX_CartillasMedicos_IdCartilla]    Script Date: 22/11/2023 21:48:02 ******/
CREATE NONCLUSTERED INDEX [IX_CartillasMedicos_IdCartilla] ON [dbo].[CartillasMedicos]
(
	[IdCartilla] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_CartillasMedicos_IdMedico]    Script Date: 22/11/2023 21:48:02 ******/
CREATE NONCLUSTERED INDEX [IX_CartillasMedicos_IdMedico] ON [dbo].[CartillasMedicos]
(
	[IdMedico] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Familiares_IdGrupoFamiliar]    Script Date: 22/11/2023 21:48:02 ******/
CREATE NONCLUSTERED INDEX [IX_Familiares_IdGrupoFamiliar] ON [dbo].[Familiares]
(
	[IdGrupoFamiliar] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Planes_IdCartilla]    Script Date: 22/11/2023 21:48:02 ******/
CREATE NONCLUSTERED INDEX [IX_Planes_IdCartilla] ON [dbo].[Planes]
(
	[IdCartilla] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Socios_IdGrupoFamiliar]    Script Date: 22/11/2023 21:48:02 ******/
CREATE NONCLUSTERED INDEX [IX_Socios_IdGrupoFamiliar] ON [dbo].[Socios]
(
	[IdGrupoFamiliar] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Socios_IdPlan]    Script Date: 22/11/2023 21:48:02 ******/
CREATE NONCLUSTERED INDEX [IX_Socios_IdPlan] ON [dbo].[Socios]
(
	[IdPlan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TurnosMedicos_IdMedico]    Script Date: 22/11/2023 21:48:02 ******/
CREATE NONCLUSTERED INDEX [IX_TurnosMedicos_IdMedico] ON [dbo].[TurnosMedicos]
(
	[IdMedico] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TurnosMedicos_IdSocio]    Script Date: 22/11/2023 21:48:02 ******/
CREATE NONCLUSTERED INDEX [IX_TurnosMedicos_IdSocio] ON [dbo].[TurnosMedicos]
(
	[IdSocio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CartillasMedicos]  WITH CHECK ADD  CONSTRAINT [FK_CartillasMedicos_Cartillas_IdCartilla] FOREIGN KEY([IdCartilla])
REFERENCES [dbo].[Cartillas] ([IdCartilla])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CartillasMedicos] CHECK CONSTRAINT [FK_CartillasMedicos_Cartillas_IdCartilla]
GO
ALTER TABLE [dbo].[CartillasMedicos]  WITH CHECK ADD  CONSTRAINT [FK_CartillasMedicos_Medicos_IdMedico] FOREIGN KEY([IdMedico])
REFERENCES [dbo].[Medicos] ([IdMedico])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CartillasMedicos] CHECK CONSTRAINT [FK_CartillasMedicos_Medicos_IdMedico]
GO
ALTER TABLE [dbo].[Familiares]  WITH CHECK ADD  CONSTRAINT [FK_Familiares_GruposFamiliares_IdGrupoFamiliar] FOREIGN KEY([IdGrupoFamiliar])
REFERENCES [dbo].[GruposFamiliares] ([IdGrupoFamiliar])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Familiares] CHECK CONSTRAINT [FK_Familiares_GruposFamiliares_IdGrupoFamiliar]
GO
ALTER TABLE [dbo].[Planes]  WITH CHECK ADD  CONSTRAINT [FK_Planes_Cartillas_IdCartilla] FOREIGN KEY([IdCartilla])
REFERENCES [dbo].[Cartillas] ([IdCartilla])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Planes] CHECK CONSTRAINT [FK_Planes_Cartillas_IdCartilla]
GO
ALTER TABLE [dbo].[Socios]  WITH CHECK ADD  CONSTRAINT [FK_Socios_GruposFamiliares_IdGrupoFamiliar] FOREIGN KEY([IdGrupoFamiliar])
REFERENCES [dbo].[GruposFamiliares] ([IdGrupoFamiliar])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Socios] CHECK CONSTRAINT [FK_Socios_GruposFamiliares_IdGrupoFamiliar]
GO
ALTER TABLE [dbo].[Socios]  WITH CHECK ADD  CONSTRAINT [FK_Socios_Planes_IdPlan] FOREIGN KEY([IdPlan])
REFERENCES [dbo].[Planes] ([IdPlan])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Socios] CHECK CONSTRAINT [FK_Socios_Planes_IdPlan]
GO
ALTER TABLE [dbo].[TurnosMedicos]  WITH CHECK ADD  CONSTRAINT [FK_TurnosMedicos_Medicos_IdMedico] FOREIGN KEY([IdMedico])
REFERENCES [dbo].[Medicos] ([IdMedico])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TurnosMedicos] CHECK CONSTRAINT [FK_TurnosMedicos_Medicos_IdMedico]
GO
ALTER TABLE [dbo].[TurnosMedicos]  WITH CHECK ADD  CONSTRAINT [FK_TurnosMedicos_Socios_IdSocio] FOREIGN KEY([IdSocio])
REFERENCES [dbo].[Socios] ([IdSocio])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TurnosMedicos] CHECK CONSTRAINT [FK_TurnosMedicos_Socios_IdSocio]
GO
USE [master]
GO
ALTER DATABASE [ORTSocialDB] SET  READ_WRITE 
GO
