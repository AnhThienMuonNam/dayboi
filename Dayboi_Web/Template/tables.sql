USE [master]
GO
/****** Object:  Database [DB_Dayboi]    Script Date: 11/16/2018 00:07:34 ******/
CREATE DATABASE [DB_Dayboi]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DB_Dayboi', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\DB_Dayboi.mdf' , SIZE = 6336KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DB_Dayboi_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\DB_Dayboi_log.ldf' , SIZE = 816KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DB_Dayboi] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DB_Dayboi].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DB_Dayboi] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DB_Dayboi] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DB_Dayboi] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DB_Dayboi] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DB_Dayboi] SET ARITHABORT OFF 
GO
ALTER DATABASE [DB_Dayboi] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DB_Dayboi] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DB_Dayboi] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DB_Dayboi] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DB_Dayboi] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DB_Dayboi] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DB_Dayboi] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DB_Dayboi] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DB_Dayboi] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DB_Dayboi] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DB_Dayboi] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DB_Dayboi] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DB_Dayboi] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DB_Dayboi] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DB_Dayboi] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DB_Dayboi] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [DB_Dayboi] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DB_Dayboi] SET RECOVERY FULL 
GO
ALTER DATABASE [DB_Dayboi] SET  MULTI_USER 
GO
ALTER DATABASE [DB_Dayboi] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DB_Dayboi] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DB_Dayboi] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DB_Dayboi] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [DB_Dayboi] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'DB_Dayboi', N'ON'
GO
USE [DB_Dayboi]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 11/16/2018 00:07:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ApplicationGroups]    Script Date: 11/16/2018 00:07:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApplicationGroups](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[Description] [nvarchar](250) NULL,
 CONSTRAINT [PK_dbo.ApplicationGroups] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ApplicationRoleGroups]    Script Date: 11/16/2018 00:07:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApplicationRoleGroups](
	[GroupId] [int] NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.ApplicationRoleGroups] PRIMARY KEY CLUSTERED 
(
	[GroupId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ApplicationRoles]    Script Date: 11/16/2018 00:07:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApplicationRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](250) NULL,
	[Discriminator] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.ApplicationRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ApplicationUserClaims]    Script Date: 11/16/2018 00:07:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApplicationUserClaims](
	[UserId] [nvarchar](128) NOT NULL,
	[Id] [int] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	[ApplicationUser_Id] [nvarchar](128) NULL,
 CONSTRAINT [PK_dbo.ApplicationUserClaims] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ApplicationUserGroups]    Script Date: 11/16/2018 00:07:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApplicationUserGroups](
	[UserId] [nvarchar](128) NOT NULL,
	[GroupId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.ApplicationUserGroups] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[GroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ApplicationUserLogins]    Script Date: 11/16/2018 00:07:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApplicationUserLogins](
	[UserId] [nvarchar](128) NOT NULL,
	[LoginProvider] [nvarchar](max) NULL,
	[ProviderKey] [nvarchar](max) NULL,
	[ApplicationUser_Id] [nvarchar](128) NULL,
 CONSTRAINT [PK_dbo.ApplicationUserLogins] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ApplicationUserRoles]    Script Date: 11/16/2018 00:07:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApplicationUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
	[ApplicationUser_Id] [nvarchar](128) NULL,
	[IdentityRole_Id] [nvarchar](128) NULL,
 CONSTRAINT [PK_dbo.ApplicationUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ApplicationUsers]    Script Date: 11/16/2018 00:07:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApplicationUsers](
	[Id] [nvarchar](128) NOT NULL,
	[FullName] [nvarchar](256) NULL,
	[Address] [nvarchar](256) NULL,
	[BirthDay] [datetime] NULL,
	[Email] [nvarchar](max) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.ApplicationUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Blogs]    Script Date: 11/16/2018 00:07:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Blogs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](200) NULL,
	[SortDescription] [nvarchar](500) NULL,
	[Content] [nvarchar](max) NULL,
	[ViewCount] [int] NULL,
	[Image] [nvarchar](200) NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[UpdatedBy] [nvarchar](max) NULL,
	[IsDeleted] [bit] NOT NULL,
	[DisplayOrder] [int] NULL,
	[IsActive] [bit] NOT NULL,
	[Alias] [nvarchar](200) NULL,
	[MetaKeyword] [nvarchar](250) NULL,
 CONSTRAINT [PK_dbo.Blogs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BlogTags]    Script Date: 11/16/2018 00:07:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BlogTags](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tag] [nvarchar](200) NULL,
	[BlogId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.BlogTags] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Categories]    Script Date: 11/16/2018 00:07:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Alias] [nvarchar](200) NULL,
	[MetaKeyword] [nvarchar](250) NULL,
	[Description] [nvarchar](500) NULL,
	[Image] [nvarchar](500) NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NULL,
	[CreatedBy] [nvarchar](128) NULL,
	[UpdatedBy] [nvarchar](128) NULL,
	[IsDeleted] [bit] NOT NULL,
	[DisplayOrder] [int] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Courses]    Script Date: 11/16/2018 00:07:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NULL,
	[Alias] [nvarchar](200) NULL,
	[MetaKeyword] [nvarchar](250) NULL,
	[Description] [nvarchar](500) NULL,
	[Content] [nvarchar](max) NULL,
	[ViewCount] [int] NULL,
	[Image] [nvarchar](200) NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[UpdatedBy] [nvarchar](max) NULL,
	[IsDeleted] [bit] NOT NULL,
	[DisplayOrder] [int] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Courses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CourseTags]    Script Date: 11/16/2018 00:07:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseTags](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tag] [nvarchar](200) NULL,
	[CourseId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.CourseTags] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Districts]    Script Date: 11/16/2018 00:07:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Districts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[IsDeleted] [bit] NOT NULL,
	[DisplayOrder] [int] NULL,
	[ProvinceId] [int] NOT NULL,
	[Type] [nvarchar](100) NULL,
	[LatiLongTude] [nvarchar](100) NULL,
	[IsPublished] [bit] NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_dbo.Districts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EnrollmentCourses]    Script Date: 11/16/2018 00:07:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EnrollmentCourses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](200) NULL,
	[Phone] [nvarchar](max) NULL,
	[StartDate] [datetime] NULL,
	[Note] [nvarchar](200) NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[UpdatedBy] [nvarchar](max) NULL,
	[IsDeleted] [bit] NOT NULL,
	[CourseId] [int] NOT NULL,
	[UserId] [nvarchar](128) NULL,
	[EnrollmentCourseStatusId] [int] NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_dbo.EnrollmentCourses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EnrollmentCourseStatues]    Script Date: 11/16/2018 00:07:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EnrollmentCourseStatues](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[IsDeleted] [bit] NOT NULL,
	[DisplayOrder] [int] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.EnrollmentCourseStatues] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 11/16/2018 00:07:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](100) NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[SumPrice] [decimal](18, 2) NOT NULL,
	[Quantity] [int] NOT NULL,
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.OrderDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Orders]    Script Date: 11/16/2018 00:07:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Email] [nvarchar](100) NULL,
	[Phone] [nvarchar](50) NULL,
	[Address] [nvarchar](500) NULL,
	[TotalPrice] [decimal](18, 2) NOT NULL,
	[OrderStatusId] [int] NOT NULL,
	[PaymentMethodId] [int] NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NULL,
	[CreatedBy] [nvarchar](128) NULL,
	[UpdatedBy] [nvarchar](128) NULL,
	[IsDeleted] [bit] NOT NULL,
	[ProvinceName] [nvarchar](50) NULL,
	[DistrictName] [nvarchar](50) NULL,
	[WardName] [nvarchar](50) NULL,
	[ProvinceId] [int] NULL,
	[DistrictId] [int] NULL,
	[WardId] [int] NULL,
	[ShippingFee] [decimal](18, 2) NULL,
	[Note] [nvarchar](200) NULL,
 CONSTRAINT [PK_dbo.Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderStatues]    Script Date: 11/16/2018 00:07:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderStatues](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[IsDeleted] [bit] NOT NULL,
	[DisplayOrder] [int] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.OrderStatues] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PaymentMethods]    Script Date: 11/16/2018 00:07:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentMethods](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[IsDeleted] [bit] NOT NULL,
	[DisplayOrder] [int] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.PaymentMethods] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PoolCategories]    Script Date: 11/16/2018 00:07:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PoolCategories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Alias] [nvarchar](200) NULL,
	[MetaKeyword] [nvarchar](250) NULL,
	[Image] [nvarchar](500) NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[UpdatedBy] [nvarchar](max) NULL,
	[IsDeleted] [bit] NOT NULL,
	[DisplayOrder] [int] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.PoolCategories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Pools]    Script Date: 11/16/2018 00:07:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pools](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NULL,
	[Alias] [nvarchar](200) NULL,
	[MetaKeyword] [nvarchar](250) NULL,
	[Address] [nvarchar](500) NULL,
	[Content] [nvarchar](max) NULL,
	[ViewCount] [int] NULL,
	[Image] [nvarchar](200) NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[UpdatedBy] [nvarchar](max) NULL,
	[IsDeleted] [bit] NOT NULL,
	[DisplayOrder] [int] NULL,
	[IsActive] [bit] NOT NULL,
	[PoolCategoryId] [int] NOT NULL,
	[Fare] [decimal](18, 2) NULL,
	[OpeningHour] [int] NULL,
	[ClosedHour] [int] NULL,
	[OpeningDay] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Pools] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PoolTags]    Script Date: 11/16/2018 00:07:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PoolTags](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tag] [nvarchar](200) NULL,
	[PoolId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.PoolTags] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Products]    Script Date: 11/16/2018 00:07:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Alias] [nvarchar](200) NULL,
	[MetaKeyword] [nvarchar](250) NULL,
	[Description] [nvarchar](1000) NULL,
	[Images] [nvarchar](1000) NULL,
	[Price] [decimal](18, 2) NULL,
	[IsPromotion] [bit] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NULL,
	[CreatedBy] [nvarchar](128) NULL,
	[UpdatedBy] [nvarchar](128) NULL,
	[IsDeleted] [bit] NOT NULL,
	[DisplayOrder] [int] NULL,
	[IsActive] [bit] NOT NULL,
	[CategoryId] [int] NULL,
	[OtherPrice] [decimal](18, 2) NULL,
 CONSTRAINT [PK_dbo.Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProductTags]    Script Date: 11/16/2018 00:07:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductTags](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tag] [nvarchar](200) NULL,
	[ProductId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.ProductTags] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Provinces]    Script Date: 11/16/2018 00:07:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Provinces](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[IsDeleted] [bit] NOT NULL,
	[DisplayOrder] [int] NULL,
	[Type] [nvarchar](50) NULL,
	[ZipCode] [nvarchar](20) NULL,
	[CountryId] [int] NOT NULL DEFAULT ((0)),
	[CountryCode] [nvarchar](5) NULL,
	[TelephoneCode] [int] NOT NULL DEFAULT ((0)),
	[IsPublished] [bit] NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_dbo.Provinces] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Skills]    Script Date: 11/16/2018 00:07:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Skills](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NULL,
	[Alias] [nvarchar](200) NULL,
	[MetaKeyword] [nvarchar](250) NULL,
	[Description] [nvarchar](500) NULL,
	[Content] [nvarchar](max) NULL,
	[ViewCount] [int] NULL,
	[Image] [nvarchar](200) NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[UpdatedBy] [nvarchar](max) NULL,
	[IsDeleted] [bit] NOT NULL,
	[DisplayOrder] [int] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Skills] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SkillTags]    Script Date: 11/16/2018 00:07:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SkillTags](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tag] [nvarchar](200) NULL,
	[SkillId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.SkillTags] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Wards]    Script Date: 11/16/2018 00:07:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Wards](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[IsDeleted] [bit] NOT NULL,
	[DisplayOrder] [int] NULL,
	[DistrictId] [int] NOT NULL,
	[Type] [nvarchar](100) NULL,
	[LatiLongTude] [nvarchar](100) NULL,
	[IsPublished] [bit] NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_dbo.Wards] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Index [IX_GroupId]    Script Date: 11/16/2018 00:07:34 ******/
CREATE NONCLUSTERED INDEX [IX_GroupId] ON [dbo].[ApplicationRoleGroups]
(
	[GroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_RoleId]    Script Date: 11/16/2018 00:07:34 ******/
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[ApplicationRoleGroups]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_ApplicationUser_Id]    Script Date: 11/16/2018 00:07:34 ******/
CREATE NONCLUSTERED INDEX [IX_ApplicationUser_Id] ON [dbo].[ApplicationUserClaims]
(
	[ApplicationUser_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_GroupId]    Script Date: 11/16/2018 00:07:34 ******/
CREATE NONCLUSTERED INDEX [IX_GroupId] ON [dbo].[ApplicationUserGroups]
(
	[GroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 11/16/2018 00:07:34 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[ApplicationUserGroups]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_ApplicationUser_Id]    Script Date: 11/16/2018 00:07:34 ******/
CREATE NONCLUSTERED INDEX [IX_ApplicationUser_Id] ON [dbo].[ApplicationUserLogins]
(
	[ApplicationUser_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_ApplicationUser_Id]    Script Date: 11/16/2018 00:07:34 ******/
CREATE NONCLUSTERED INDEX [IX_ApplicationUser_Id] ON [dbo].[ApplicationUserRoles]
(
	[ApplicationUser_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_IdentityRole_Id]    Script Date: 11/16/2018 00:07:34 ******/
CREATE NONCLUSTERED INDEX [IX_IdentityRole_Id] ON [dbo].[ApplicationUserRoles]
(
	[IdentityRole_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_BlogId]    Script Date: 11/16/2018 00:07:34 ******/
CREATE NONCLUSTERED INDEX [IX_BlogId] ON [dbo].[BlogTags]
(
	[BlogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_CreatedBy]    Script Date: 11/16/2018 00:07:34 ******/
CREATE NONCLUSTERED INDEX [IX_CreatedBy] ON [dbo].[Categories]
(
	[CreatedBy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UpdatedBy]    Script Date: 11/16/2018 00:07:34 ******/
CREATE NONCLUSTERED INDEX [IX_UpdatedBy] ON [dbo].[Categories]
(
	[UpdatedBy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CourseId]    Script Date: 11/16/2018 00:07:34 ******/
CREATE NONCLUSTERED INDEX [IX_CourseId] ON [dbo].[CourseTags]
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProvinceId]    Script Date: 11/16/2018 00:07:34 ******/
CREATE NONCLUSTERED INDEX [IX_ProvinceId] ON [dbo].[Districts]
(
	[ProvinceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CourseId]    Script Date: 11/16/2018 00:07:34 ******/
CREATE NONCLUSTERED INDEX [IX_CourseId] ON [dbo].[EnrollmentCourses]
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_EnrollmentCourseStatusId]    Script Date: 11/16/2018 00:07:34 ******/
CREATE NONCLUSTERED INDEX [IX_EnrollmentCourseStatusId] ON [dbo].[EnrollmentCourses]
(
	[EnrollmentCourseStatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 11/16/2018 00:07:34 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[EnrollmentCourses]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderId]    Script Date: 11/16/2018 00:07:34 ******/
CREATE NONCLUSTERED INDEX [IX_OrderId] ON [dbo].[OrderDetails]
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductId]    Script Date: 11/16/2018 00:07:34 ******/
CREATE NONCLUSTERED INDEX [IX_ProductId] ON [dbo].[OrderDetails]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_CreatedBy]    Script Date: 11/16/2018 00:07:34 ******/
CREATE NONCLUSTERED INDEX [IX_CreatedBy] ON [dbo].[Orders]
(
	[CreatedBy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderStatusId]    Script Date: 11/16/2018 00:07:34 ******/
CREATE NONCLUSTERED INDEX [IX_OrderStatusId] ON [dbo].[Orders]
(
	[OrderStatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PaymentMethodId]    Script Date: 11/16/2018 00:07:34 ******/
CREATE NONCLUSTERED INDEX [IX_PaymentMethodId] ON [dbo].[Orders]
(
	[PaymentMethodId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UpdatedBy]    Script Date: 11/16/2018 00:07:34 ******/
CREATE NONCLUSTERED INDEX [IX_UpdatedBy] ON [dbo].[Orders]
(
	[UpdatedBy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PoolCategoryId]    Script Date: 11/16/2018 00:07:34 ******/
CREATE NONCLUSTERED INDEX [IX_PoolCategoryId] ON [dbo].[Pools]
(
	[PoolCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PoolId]    Script Date: 11/16/2018 00:07:34 ******/
CREATE NONCLUSTERED INDEX [IX_PoolId] ON [dbo].[PoolTags]
(
	[PoolId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CategoryId]    Script Date: 11/16/2018 00:07:34 ******/
CREATE NONCLUSTERED INDEX [IX_CategoryId] ON [dbo].[Products]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_CreatedBy]    Script Date: 11/16/2018 00:07:34 ******/
CREATE NONCLUSTERED INDEX [IX_CreatedBy] ON [dbo].[Products]
(
	[CreatedBy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UpdatedBy]    Script Date: 11/16/2018 00:07:34 ******/
CREATE NONCLUSTERED INDEX [IX_UpdatedBy] ON [dbo].[Products]
(
	[UpdatedBy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductId]    Script Date: 11/16/2018 00:07:34 ******/
CREATE NONCLUSTERED INDEX [IX_ProductId] ON [dbo].[ProductTags]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_SkillId]    Script Date: 11/16/2018 00:07:34 ******/
CREATE NONCLUSTERED INDEX [IX_SkillId] ON [dbo].[SkillTags]
(
	[SkillId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_DistrictId]    Script Date: 11/16/2018 00:07:34 ******/
CREATE NONCLUSTERED INDEX [IX_DistrictId] ON [dbo].[Wards]
(
	[DistrictId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ApplicationRoleGroups]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ApplicationRoleGroups_dbo.ApplicationGroups_GroupId] FOREIGN KEY([GroupId])
REFERENCES [dbo].[ApplicationGroups] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ApplicationRoleGroups] CHECK CONSTRAINT [FK_dbo.ApplicationRoleGroups_dbo.ApplicationGroups_GroupId]
GO
ALTER TABLE [dbo].[ApplicationRoleGroups]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ApplicationRoleGroups_dbo.ApplicationRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[ApplicationRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ApplicationRoleGroups] CHECK CONSTRAINT [FK_dbo.ApplicationRoleGroups_dbo.ApplicationRoles_RoleId]
GO
ALTER TABLE [dbo].[ApplicationUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ApplicationUserClaims_dbo.ApplicationUsers_ApplicationUser_Id] FOREIGN KEY([ApplicationUser_Id])
REFERENCES [dbo].[ApplicationUsers] ([Id])
GO
ALTER TABLE [dbo].[ApplicationUserClaims] CHECK CONSTRAINT [FK_dbo.ApplicationUserClaims_dbo.ApplicationUsers_ApplicationUser_Id]
GO
ALTER TABLE [dbo].[ApplicationUserGroups]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ApplicationUserGroups_dbo.ApplicationGroups_GroupId] FOREIGN KEY([GroupId])
REFERENCES [dbo].[ApplicationGroups] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ApplicationUserGroups] CHECK CONSTRAINT [FK_dbo.ApplicationUserGroups_dbo.ApplicationGroups_GroupId]
GO
ALTER TABLE [dbo].[ApplicationUserGroups]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ApplicationUserGroups_dbo.ApplicationUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[ApplicationUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ApplicationUserGroups] CHECK CONSTRAINT [FK_dbo.ApplicationUserGroups_dbo.ApplicationUsers_UserId]
GO
ALTER TABLE [dbo].[ApplicationUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ApplicationUserLogins_dbo.ApplicationUsers_ApplicationUser_Id] FOREIGN KEY([ApplicationUser_Id])
REFERENCES [dbo].[ApplicationUsers] ([Id])
GO
ALTER TABLE [dbo].[ApplicationUserLogins] CHECK CONSTRAINT [FK_dbo.ApplicationUserLogins_dbo.ApplicationUsers_ApplicationUser_Id]
GO
ALTER TABLE [dbo].[ApplicationUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ApplicationUserRoles_dbo.ApplicationRoles_IdentityRole_Id] FOREIGN KEY([IdentityRole_Id])
REFERENCES [dbo].[ApplicationRoles] ([Id])
GO
ALTER TABLE [dbo].[ApplicationUserRoles] CHECK CONSTRAINT [FK_dbo.ApplicationUserRoles_dbo.ApplicationRoles_IdentityRole_Id]
GO
ALTER TABLE [dbo].[ApplicationUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ApplicationUserRoles_dbo.ApplicationUsers_ApplicationUser_Id] FOREIGN KEY([ApplicationUser_Id])
REFERENCES [dbo].[ApplicationUsers] ([Id])
GO
ALTER TABLE [dbo].[ApplicationUserRoles] CHECK CONSTRAINT [FK_dbo.ApplicationUserRoles_dbo.ApplicationUsers_ApplicationUser_Id]
GO
ALTER TABLE [dbo].[BlogTags]  WITH CHECK ADD  CONSTRAINT [FK_dbo.BlogTags_dbo.Blogs_BlogId] FOREIGN KEY([BlogId])
REFERENCES [dbo].[Blogs] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BlogTags] CHECK CONSTRAINT [FK_dbo.BlogTags_dbo.Blogs_BlogId]
GO
ALTER TABLE [dbo].[Categories]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Categories_dbo.ApplicationUsers_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[ApplicationUsers] ([Id])
GO
ALTER TABLE [dbo].[Categories] CHECK CONSTRAINT [FK_dbo.Categories_dbo.ApplicationUsers_CreatedBy]
GO
ALTER TABLE [dbo].[Categories]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Categories_dbo.ApplicationUsers_UpdatedBy] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[ApplicationUsers] ([Id])
GO
ALTER TABLE [dbo].[Categories] CHECK CONSTRAINT [FK_dbo.Categories_dbo.ApplicationUsers_UpdatedBy]
GO
ALTER TABLE [dbo].[CourseTags]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CourseTags_dbo.Courses_CourseId] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CourseTags] CHECK CONSTRAINT [FK_dbo.CourseTags_dbo.Courses_CourseId]
GO
ALTER TABLE [dbo].[Districts]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Districts_dbo.Provinces_ProvinceId] FOREIGN KEY([ProvinceId])
REFERENCES [dbo].[Provinces] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Districts] CHECK CONSTRAINT [FK_dbo.Districts_dbo.Provinces_ProvinceId]
GO
ALTER TABLE [dbo].[EnrollmentCourses]  WITH CHECK ADD  CONSTRAINT [FK_dbo.EnrollmentCourses_dbo.ApplicationUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[ApplicationUsers] ([Id])
GO
ALTER TABLE [dbo].[EnrollmentCourses] CHECK CONSTRAINT [FK_dbo.EnrollmentCourses_dbo.ApplicationUsers_UserId]
GO
ALTER TABLE [dbo].[EnrollmentCourses]  WITH CHECK ADD  CONSTRAINT [FK_dbo.EnrollmentCourses_dbo.Courses_CourseId] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EnrollmentCourses] CHECK CONSTRAINT [FK_dbo.EnrollmentCourses_dbo.Courses_CourseId]
GO
ALTER TABLE [dbo].[EnrollmentCourses]  WITH CHECK ADD  CONSTRAINT [FK_dbo.EnrollmentCourses_dbo.EnrollmentCourseStatues_EnrollmentCourseStatusId] FOREIGN KEY([EnrollmentCourseStatusId])
REFERENCES [dbo].[EnrollmentCourseStatues] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EnrollmentCourses] CHECK CONSTRAINT [FK_dbo.EnrollmentCourses_dbo.EnrollmentCourseStatues_EnrollmentCourseStatusId]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_dbo.OrderDetails_dbo.Orders_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_dbo.OrderDetails_dbo.Orders_OrderId]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_dbo.OrderDetails_dbo.Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_dbo.OrderDetails_dbo.Products_ProductId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Orders_dbo.ApplicationUsers_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[ApplicationUsers] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_dbo.Orders_dbo.ApplicationUsers_CreatedBy]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Orders_dbo.ApplicationUsers_UpdatedBy] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[ApplicationUsers] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_dbo.Orders_dbo.ApplicationUsers_UpdatedBy]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Orders_dbo.OrderStatuses_OrderStatusId] FOREIGN KEY([OrderStatusId])
REFERENCES [dbo].[OrderStatues] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_dbo.Orders_dbo.OrderStatuses_OrderStatusId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Orders_dbo.PaymentMethods_PaymentMethodId] FOREIGN KEY([PaymentMethodId])
REFERENCES [dbo].[PaymentMethods] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_dbo.Orders_dbo.PaymentMethods_PaymentMethodId]
GO
ALTER TABLE [dbo].[Pools]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Pools_dbo.PoolCategories_PoolCategoryId] FOREIGN KEY([PoolCategoryId])
REFERENCES [dbo].[PoolCategories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Pools] CHECK CONSTRAINT [FK_dbo.Pools_dbo.PoolCategories_PoolCategoryId]
GO
ALTER TABLE [dbo].[PoolTags]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PoolTags_dbo.Pools_PoolId] FOREIGN KEY([PoolId])
REFERENCES [dbo].[Pools] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PoolTags] CHECK CONSTRAINT [FK_dbo.PoolTags_dbo.Pools_PoolId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Products_dbo.ApplicationUsers_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[ApplicationUsers] ([Id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_dbo.Products_dbo.ApplicationUsers_CreatedBy]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Products_dbo.ApplicationUsers_UpdatedBy] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[ApplicationUsers] ([Id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_dbo.Products_dbo.ApplicationUsers_UpdatedBy]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Products_dbo.Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_dbo.Products_dbo.Categories_CategoryId]
GO
ALTER TABLE [dbo].[ProductTags]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ProductTags_dbo.Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductTags] CHECK CONSTRAINT [FK_dbo.ProductTags_dbo.Products_ProductId]
GO
ALTER TABLE [dbo].[SkillTags]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SkillTags_dbo.Skills_SkillId] FOREIGN KEY([SkillId])
REFERENCES [dbo].[Skills] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SkillTags] CHECK CONSTRAINT [FK_dbo.SkillTags_dbo.Skills_SkillId]
GO
ALTER TABLE [dbo].[Wards]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Wards_dbo.Districts_DistrictId] FOREIGN KEY([DistrictId])
REFERENCES [dbo].[Districts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Wards] CHECK CONSTRAINT [FK_dbo.Wards_dbo.Districts_DistrictId]
GO
USE [master]
GO
ALTER DATABASE [DB_Dayboi] SET  READ_WRITE 
GO
