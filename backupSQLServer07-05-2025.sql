USE [master]
GO
/****** Object:  Database [Integraecomex]    Script Date: 07/05/2025 23:01:04 ******/
CREATE DATABASE [Integraecomex]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Integraecomex', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Integraecomex.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Integraecomex_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Integraecomex_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Integraecomex] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Integraecomex].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Integraecomex] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Integraecomex] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Integraecomex] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Integraecomex] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Integraecomex] SET ARITHABORT OFF 
GO
ALTER DATABASE [Integraecomex] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Integraecomex] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Integraecomex] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Integraecomex] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Integraecomex] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Integraecomex] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Integraecomex] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Integraecomex] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Integraecomex] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Integraecomex] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Integraecomex] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Integraecomex] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Integraecomex] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Integraecomex] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Integraecomex] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Integraecomex] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Integraecomex] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Integraecomex] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Integraecomex] SET  MULTI_USER 
GO
ALTER DATABASE [Integraecomex] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Integraecomex] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Integraecomex] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Integraecomex] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Integraecomex] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Integraecomex] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Integraecomex] SET QUERY_STORE = OFF
GO
USE [Integraecomex]
GO
/****** Object:  User [sax]    Script Date: 07/05/2025 23:01:04 ******/
CREATE USER [sax] FOR LOGIN [sax] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [sax]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 07/05/2025 23:01:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Cuit] [varchar](11) NOT NULL,
	[RazonSocial] [nvarchar](200) NULL,
	[Telefono] [nvarchar](20) NULL,
	[Direccion] [nvarchar](200) NULL,
	[Activo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Clientes] ON 

INSERT [dbo].[Clientes] ([Id], [Cuit], [RazonSocial], [Telefono], [Direccion], [Activo]) VALUES (2, N'27345678901', NULL, N'011-9876-5432', N'Calle Falsa 456, Rosario, Santa Tucuman', 1)
INSERT [dbo].[Clientes] ([Id], [Cuit], [RazonSocial], [Telefono], [Direccion], [Activo]) VALUES (3, N'30456789012', NULL, N'+5492615551212', N'Rivadavia 789, Mendoza', 0)
INSERT [dbo].[Clientes] ([Id], [Cuit], [RazonSocial], [Telefono], [Direccion], [Activo]) VALUES (4, N'20334844723', N'Error al obtener Razón Social', N'155555555', N'Av. Corrientes 1234, CABA', 1)
INSERT [dbo].[Clientes] ([Id], [Cuit], [RazonSocial], [Telefono], [Direccion], [Activo]) VALUES (5, N'20123456788', N'Error al obtener Razón Social', N'+54 11 1234-5678', N'Av. Corrientes 1234, CABA', 1)
SET IDENTITY_INSERT [dbo].[Clientes] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Clientes__AFA91786A48C4652]    Script Date: 07/05/2025 23:01:05 ******/
ALTER TABLE [dbo].[Clientes] ADD UNIQUE NONCLUSTERED 
(
	[Cuit] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Clientes] ADD  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD CHECK  ((NOT [Cuit] like '%[^0-9]%'))
GO
ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD CHECK  ((NOT [Telefono] like '%[^0-9+ -]%'))
GO
USE [master]
GO
ALTER DATABASE [Integraecomex] SET  READ_WRITE 
GO
