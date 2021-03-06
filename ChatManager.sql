USE [master]
GO
/****** Object:  Database [datatormim]    Script Date: 10/07/2020 18:38:08 ******/
CREATE DATABASE [datatormim]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'datatormim', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\datatormim.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'datatormim_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\datatormim_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [datatormim] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [datatormim].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [datatormim] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [datatormim] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [datatormim] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [datatormim] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [datatormim] SET ARITHABORT OFF 
GO
ALTER DATABASE [datatormim] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [datatormim] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [datatormim] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [datatormim] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [datatormim] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [datatormim] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [datatormim] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [datatormim] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [datatormim] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [datatormim] SET  DISABLE_BROKER 
GO
ALTER DATABASE [datatormim] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [datatormim] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [datatormim] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [datatormim] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [datatormim] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [datatormim] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [datatormim] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [datatormim] SET RECOVERY FULL 
GO
ALTER DATABASE [datatormim] SET  MULTI_USER 
GO
ALTER DATABASE [datatormim] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [datatormim] SET DB_CHAINING OFF 
GO
ALTER DATABASE [datatormim] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [datatormim] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [datatormim] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'datatormim', N'ON'
GO
ALTER DATABASE [datatormim] SET QUERY_STORE = OFF
GO
USE [datatormim]
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [datatormim]
GO
/****** Object:  Table [dbo].[ChatDetail]    Script Date: 10/07/2020 18:38:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChatDetail](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[FromNumOved] [int] NULL,
	[ToNumOved] [int] NULL,
	[FromUserAd] [varchar](50) NULL,
	[ToUserAd] [varchar](50) NULL,
	[FromUserHeb] [varchar](50) NULL,
	[ToUserHeb] [varchar](50) NULL,
	[odaa] [text] NULL,
	[ReadOdaa] [bit] NULL,
	[dateAdd] [datetime] NULL,
	[dateRead] [datetime] NULL,
 CONSTRAINT [PK_ChatDetail] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChatUser]    Script Date: 10/07/2020 18:38:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChatUser](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[NumOved] [int] NULL,
	[UserAd] [varchar](50) NULL,
	[UserHeb] [varchar](50) NULL,
	[ArshaaAdmin] [bit] NULL,
 CONSTRAINT [PK_ChatUser] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[ChatUser] ON 

INSERT [dbo].[ChatUser] ([id], [NumOved], [UserAd], [UserHeb], [ArshaaAdmin]) VALUES (1001, 1, N'user1', N'משה', 1)
INSERT [dbo].[ChatUser] ([id], [NumOved], [UserAd], [UserHeb], [ArshaaAdmin]) VALUES (1002, 55, N'user2', N'שרה', 0)
INSERT [dbo].[ChatUser] ([id], [NumOved], [UserAd], [UserHeb], [ArshaaAdmin]) VALUES (1003, 22, N'user3', N'אברהם', 0)
INSERT [dbo].[ChatUser] ([id], [NumOved], [UserAd], [UserHeb], [ArshaaAdmin]) VALUES (1004, 10, N'user4', N'רות', 0)
INSERT [dbo].[ChatUser] ([id], [NumOved], [UserAd], [UserHeb], [ArshaaAdmin]) VALUES (1004, 10, N'user5', N'אהרן', 0)
INSERT [dbo].[ChatUser] ([id], [NumOved], [UserAd], [UserHeb], [ArshaaAdmin]) VALUES (1005, 2, N'yourUserName@YOUR-LOCALHOST-NAME', N'אריאל', 1)
SET IDENTITY_INSERT [dbo].[ChatUser] OFF
ALTER TABLE [dbo].[ChatDetail] ADD  CONSTRAINT [DF_Table_1_read]  DEFAULT ((0)) FOR [ReadOdaa]
GO
ALTER TABLE [dbo].[ChatDetail] ADD  CONSTRAINT [DF_ChatDetail_dateAdd]  DEFAULT (getdate()) FOR [dateAdd]
GO
ALTER TABLE [dbo].[ChatUser] ADD  CONSTRAINT [DF_ChatUser_ArshaaAdmin]  DEFAULT ((0)) FOR [ArshaaAdmin]
GO
/****** Object:  StoredProcedure [dbo].[StartChat]    Script Date: 10/07/2020 18:38:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[StartChat] 


AS
BEGIN


	  	BEGIN TRY

	     
	SET NOCOUNT ON;

	
	delete from  chatuser

	 insert into chatuser (NumOved,UserAd,UserHeb,ArshaaAdmin) values (1,'user1','משה',1)
	 
	 insert into chatuser (NumOved,UserAd,UserHeb,ArshaaAdmin) values (55,'user2','שרה',0)
	 
	 insert into chatuser (NumOved,UserAd,UserHeb,ArshaaAdmin) values (22,'user3','אברהם',0)
	 
	 insert into chatuser (NumOved,UserAd,UserHeb,ArshaaAdmin) values (10,'user4','רות',0)

	 insert into chatuser (NumOved,UserAd,UserHeb,ArshaaAdmin) values (11,'user5','אהרן',0)

	 insert into chatuser (NumOved,UserAd,UserHeb,ArshaaAdmin) values (2,'yourUserName@YOUR-LOCALHOST-NAME','אריאל',1)

	 
	 
	
	 


END TRY  


BEGIN CATCH  


    SELECT   
        ERROR_NUMBER() AS ErrorNumber  
       ,ERROR_MESSAGE() AS ErrorMessage;  
	 --  exec ReraiseError
END CATCH  
END




GO
USE [master]
GO
ALTER DATABASE [datatormim] SET  READ_WRITE 
GO
