USE [master]
GO
/****** Object:  Database [invent book]    Script Date: 20/11/2024 7:03:08 p. m. ******/
CREATE DATABASE [invent book]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'invent book', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\invent book.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'invent book_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\invent book_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [invent book] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [invent book].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [invent book] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [invent book] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [invent book] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [invent book] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [invent book] SET ARITHABORT OFF 
GO
ALTER DATABASE [invent book] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [invent book] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [invent book] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [invent book] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [invent book] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [invent book] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [invent book] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [invent book] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [invent book] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [invent book] SET  DISABLE_BROKER 
GO
ALTER DATABASE [invent book] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [invent book] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [invent book] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [invent book] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [invent book] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [invent book] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [invent book] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [invent book] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [invent book] SET  MULTI_USER 
GO
ALTER DATABASE [invent book] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [invent book] SET DB_CHAINING OFF 
GO
ALTER DATABASE [invent book] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [invent book] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [invent book] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [invent book] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [invent book] SET QUERY_STORE = OFF
GO
USE [invent book]
GO
/****** Object:  Table [dbo].[historialLibros]    Script Date: 20/11/2024 7:03:08 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[historialLibros](
	[cedulaUsuario] [varchar](50) NULL,
	[nombreUsuario] [varchar](50) NULL,
	[apellidoUsuario] [varchar](50) NULL,
	[rolUsuario] [varchar](50) NULL,
	[identificadorLibro] [varchar](50) NULL,
	[tituloLibro] [varchar](50) NULL,
	[tipoLibro] [varchar](50) NULL,
	[tipoTransaccion] [int] NULL,
	[fechaTransaccion] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[historialPrestamos]    Script Date: 20/11/2024 7:03:08 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[historialPrestamos](
	[cedulaUsuario] [varchar](50) NULL,
	[nombreUsuario] [varchar](50) NULL,
	[apellidoUsuario] [varchar](50) NULL,
	[identificadorLibro] [varchar](50) NULL,
	[tituloLibro] [varchar](50) NULL,
	[tipoLibro] [varchar](50) NULL,
	[contadorPrestamo] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[libros]    Script Date: 20/11/2024 7:03:08 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[libros](
	[identificador] [int] NOT NULL,
	[titulo] [varchar](50) NULL,
	[fechaRegistro] [varchar](50) NULL,
	[tipo] [varchar](50) NULL,
	[cantidadInicial] [varchar](50) NULL,
	[cantidadActual] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[identificador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuario]    Script Date: 20/11/2024 7:03:08 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuario](
	[cedula] [int] NOT NULL,
	[nombre] [varchar](50) NULL,
	[apellido] [varchar](50) NULL,
	[rol] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[cedula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [invent book] SET  READ_WRITE 
GO
