USE [master]
GO
/****** Object:  Database [Integrantes]    Script Date: 17/7/2025 10:41:06 ******/
CREATE DATABASE [Integrantes]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Integrantes', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Integrantes.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Integrantes_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Integrantes_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Integrantes] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Integrantes].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Integrantes] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Integrantes] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Integrantes] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Integrantes] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Integrantes] SET ARITHABORT OFF 
GO
ALTER DATABASE [Integrantes] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Integrantes] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Integrantes] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Integrantes] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Integrantes] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Integrantes] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Integrantes] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Integrantes] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Integrantes] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Integrantes] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Integrantes] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Integrantes] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Integrantes] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Integrantes] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Integrantes] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Integrantes] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Integrantes] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Integrantes] SET RECOVERY FULL 
GO
ALTER DATABASE [Integrantes] SET  MULTI_USER 
GO
ALTER DATABASE [Integrantes] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Integrantes] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Integrantes] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Integrantes] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Integrantes] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Integrantes', N'ON'
GO
ALTER DATABASE [Integrantes] SET QUERY_STORE = OFF
GO
USE [Integrantes]
GO
/****** Object:  User [alumno]    Script Date: 17/7/2025 10:41:06 ******/
CREATE USER [alumno] FOR LOGIN [alumno] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[integrante]    Script Date: 17/7/2025 10:41:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[integrante](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[contraseña] [nvarchar](255) NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[nombreEquipo] [nvarchar](50) NOT NULL,
	[apellido] [nvarchar](50) NOT NULL,
	[genero] [nvarchar](50) NULL,
	[mail] [nvarchar](50) NULL,
	[fechaNacimiento] [datetime] NULL,
	[datoCurioso] [nvarchar](max) NULL,
	[foto] [nvarchar](50) NULL,
 CONSTRAINT [PK_integrante] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[integrante] ON 

INSERT [dbo].[integrante] ([id], [contraseña], [nombre], [nombreEquipo], [apellido], [genero], [mail], [fechaNacimiento], [datoCurioso], [foto]) VALUES (1, N'$2a$11$cBl5w6xWZMwOZM5cE29/7OEZbozg/ALYfWkPp7Zxu9DQYTkbW8t4i', N'Maica', N'MIDEMA', N'Trutner', N'Femenino', N'maica.trutner@gmail.com', CAST(N'2008-12-30T10:26:00.000' AS DateTime), N'Soy Maica', NULL)
INSERT [dbo].[integrante] ([id], [contraseña], [nombre], [nombreEquipo], [apellido], [genero], [mail], [fechaNacimiento], [datoCurioso], [foto]) VALUES (2, N'$2a$11$cfCCFDPhmMOVcHLmdcD0/eayOb0MYTUKzULezGiPdQqSs53Nt1dw.', N'Delfina', N'MIDEMA', N'Kaltman', N'Femenino', N'delfi.kaltman@gmail.com', CAST(N'2008-09-02T10:27:00.000' AS DateTime), N'Me gusta contar chistes', NULL)
INSERT [dbo].[integrante] ([id], [contraseña], [nombre], [nombreEquipo], [apellido], [genero], [mail], [fechaNacimiento], [datoCurioso], [foto]) VALUES (3, N'$2a$11$Aly5ogbOtTOEZ/W2ktpgX.mtApmdAz7ab45941HklojydHisY38yy', N'Augusto', N'La banda del morgan', N'Traverso', N'Hombre', N'49315675@est.ort.edu.ar', CAST(N'2009-01-05T10:10:00.000' AS DateTime), N'Me gusta nicki nicole', NULL)
INSERT [dbo].[integrante] ([id], [contraseña], [nombre], [nombreEquipo], [apellido], [genero], [mail], [fechaNacimiento], [datoCurioso], [foto]) VALUES (4, N'$2a$11$IbMP2nbCsPITXL//Mk4nzOiu0cv7BATI59n6V95bxeH1TQxZMf27q', N'Milena', N'MIDEMA', N'Svatzky', N'Femenino', N'mile.svatzky@gmail.com', CAST(N'2008-09-15T10:34:00.000' AS DateTime), N'Me gusta jugar voley', NULL)
INSERT [dbo].[integrante] ([id], [contraseña], [nombre], [nombreEquipo], [apellido], [genero], [mail], [fechaNacimiento], [datoCurioso], [foto]) VALUES (5, N'$2a$11$t4jttlVQo2LLW2vJIRa1HOj3rugAee8WL6MOtLosjmvyEXjhqeVK6', N'Ludmi', N'Ludmi Team', N'Grun', N'Femenino', N'ludmigrun@gmail.com', CAST(N'2009-03-10T03:45:00.000' AS DateTime), N'Jugar hocky y tenia una tortuga', NULL)
INSERT [dbo].[integrante] ([id], [contraseña], [nombre], [nombreEquipo], [apellido], [genero], [mail], [fechaNacimiento], [datoCurioso], [foto]) VALUES (6, N'$2a$11$UN/eGN0CqdYHrmQPk3IEFO5ceblOhwsSpfCiblW5S9lZN98aGqXbK', N'Mica', N'bjz', N'Berman', N'Femenino', N'mica.berman@gmail.com', CAST(N'2009-05-16T10:38:00.000' AS DateTime), N'Me gusta', NULL)
SET IDENTITY_INSERT [dbo].[integrante] OFF
GO
USE [master]
GO
ALTER DATABASE [Integrantes] SET  READ_WRITE 
GO
