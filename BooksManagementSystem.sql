USE [master]
GO
/****** Object:  Database [BooksManagementSystem]    Script Date: 2020/6/5 15:20:01 ******/
CREATE DATABASE [BooksManagementSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BooksManagementSystem', FILENAME = N'G:\学校\作业\大二\大二下\数据库\课设\BooksManagementSystem.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BooksManagementSystem_log', FILENAME = N'G:\学校\作业\大二\大二下\数据库\课设\BooksManagementSystem_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BooksManagementSystem] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BooksManagementSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BooksManagementSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BooksManagementSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BooksManagementSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BooksManagementSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BooksManagementSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [BooksManagementSystem] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BooksManagementSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BooksManagementSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BooksManagementSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BooksManagementSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BooksManagementSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BooksManagementSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BooksManagementSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BooksManagementSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BooksManagementSystem] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BooksManagementSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BooksManagementSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BooksManagementSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BooksManagementSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BooksManagementSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BooksManagementSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BooksManagementSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BooksManagementSystem] SET RECOVERY FULL 
GO
ALTER DATABASE [BooksManagementSystem] SET  MULTI_USER 
GO
ALTER DATABASE [BooksManagementSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BooksManagementSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BooksManagementSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BooksManagementSystem] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BooksManagementSystem] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'BooksManagementSystem', N'ON'
GO
ALTER DATABASE [BooksManagementSystem] SET QUERY_STORE = OFF
GO
USE [BooksManagementSystem]
GO
/****** Object:  Table [dbo].[AdministratorInfo]    Script Date: 2020/6/5 15:20:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdministratorInfo](
	[Aid] [int] IDENTITY(0,1) NOT NULL,
	[Apassword] [varchar](50) NOT NULL,
 CONSTRAINT [PK_AdministratorInfo] PRIMARY KEY CLUSTERED 
(
	[Aid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookInfo]    Script Date: 2020/6/5 15:20:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookInfo](
	[Bid] [int] IDENTITY(1,1) NOT NULL,
	[Bname] [varchar](50) NOT NULL,
	[Bwriter] [varchar](50) NOT NULL,
	[Bpublisher] [varchar](50) NOT NULL,
	[Bsort] [varchar](50) NOT NULL,
	[IsDeleted] [int] NOT NULL,
 CONSTRAINT [PK_BookInfo] PRIMARY KEY CLUSTERED 
(
	[Bid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookSortList]    Script Date: 2020/6/5 15:20:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookSortList](
	[BSortId] [int] NOT NULL,
	[BSortName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_BookSortList] PRIMARY KEY CLUSTERED 
(
	[BSortId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LendBookInfo]    Script Date: 2020/6/5 15:20:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LendBookInfo](
	[Bid] [int] IDENTITY(1,1) NOT NULL,
	[Bname] [varchar](50) NOT NULL,
	[Bwriter] [varchar](50) NOT NULL,
	[Bpublisher] [varchar](50) NOT NULL,
	[Bsort] [varchar](50) NOT NULL,
	[Bout] [date] NOT NULL,
	[Bback] [date] NOT NULL,
	[Rid] [int] NOT NULL,
	[IsDeleted] [int] NOT NULL,
 CONSTRAINT [PK_LendBookInfo] PRIMARY KEY CLUSTERED 
(
	[Bid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReaderInfo]    Script Date: 2020/6/5 15:20:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReaderInfo](
	[Rid] [int] IDENTITY(1001,1) NOT NULL,
	[Rpassword] [varchar](50) NOT NULL,
 CONSTRAINT [PK_ReaderInfo] PRIMARY KEY CLUSTERED 
(
	[Rid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SelectList]    Script Date: 2020/6/5 15:20:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SelectList](
	[SID] [int] NOT NULL,
	[Sname] [varchar](50) NOT NULL,
 CONSTRAINT [PK_SelectList] PRIMARY KEY CLUSTERED 
(
	[SID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BookInfo] ADD  CONSTRAINT [DF_BookInfo_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[LendBookInfo] ADD  CONSTRAINT [DF_LendBookInfo_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[LendBookInfo]  WITH CHECK ADD  CONSTRAINT [FK_LendBookInfo_BookInfo] FOREIGN KEY([Bid])
REFERENCES [dbo].[BookInfo] ([Bid])
GO
ALTER TABLE [dbo].[LendBookInfo] CHECK CONSTRAINT [FK_LendBookInfo_BookInfo]
GO
USE [master]
GO
ALTER DATABASE [BooksManagementSystem] SET  READ_WRITE 
GO
