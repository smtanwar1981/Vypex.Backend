/****** Object:  Table [dbo].[Employee]    Script Date: 14/04/2025 6:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](max) NOT NULL,
 CONSTRAINT [PK_dbo.Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeLeave]    Script Date: 14/04/2025 6:51:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeLeave](
	[Id] [uniqueidentifier] NOT NULL,
	[EmployeeId] [uniqueidentifier] NOT NULL,
	[StartDate] [date] NULL,
	[EndDate] [date] NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NULL,
	[UpdatedBy] [varchar](100) NULL,
 CONSTRAINT [PK_EmployeeLeave] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Employee] ([Id], [Name]) VALUES (N'aa4b5c30-6b82-4f3c-a767-0900a13cdd20', N'Kristina Zboncak')
GO
INSERT [dbo].[Employee] ([Id], [Name]) VALUES (N'b98d6c25-4376-4ceb-aaae-355d5bd42d30', N'Nigel Zboncak')
GO
INSERT [dbo].[Employee] ([Id], [Name]) VALUES (N'425a2b62-3a9c-4e89-ba86-460bb8ad2825', N'Kiara Weber')
GO
INSERT [dbo].[Employee] ([Id], [Name]) VALUES (N'ce8e9385-e7d8-4390-81d7-ba312a5cbf5c', N'Joelle Bergstrom')
GO
INSERT [dbo].[Employee] ([Id], [Name]) VALUES (N'5167b5c5-7f51-442e-8211-eb2eebdc7812', N'Coralie O''Kon')
GO
INSERT [dbo].[EmployeeLeave] ([Id], [EmployeeId], [StartDate], [EndDate], [CreatedOn], [UpdatedOn], [UpdatedBy]) VALUES (N'76651583-29ae-43f8-9ccc-4931719491c8', N'425a2b62-3a9c-4e89-ba86-460bb8ad2825', CAST(N'2025-04-14' AS Date), CAST(N'2025-04-15' AS Date), CAST(N'2025-04-14T06:05:19.710' AS DateTime), CAST(N'2025-04-14T06:05:19.710' AS DateTime), N'User')
GO
INSERT [dbo].[EmployeeLeave] ([Id], [EmployeeId], [StartDate], [EndDate], [CreatedOn], [UpdatedOn], [UpdatedBy]) VALUES (N'bc4ca0ec-65ea-463c-a0ff-605faf1f5653', N'aa4b5c30-6b82-4f3c-a767-0900a13cdd20', CAST(N'2024-04-01' AS Date), CAST(N'2024-04-30' AS Date), CAST(N'2025-04-14T03:16:58.253' AS DateTime), CAST(N'2025-04-14T05:40:21.397' AS DateTime), N'User')
GO
INSERT [dbo].[EmployeeLeave] ([Id], [EmployeeId], [StartDate], [EndDate], [CreatedOn], [UpdatedOn], [UpdatedBy]) VALUES (N'0f16cd1a-ef8e-4e7a-bc82-95e639617dc2', N'aa4b5c30-6b82-4f3c-a767-0900a13cdd20', CAST(N'2026-04-01' AS Date), CAST(N'2026-05-19' AS Date), CAST(N'2025-04-14T05:40:35.167' AS DateTime), CAST(N'2025-04-14T05:40:35.167' AS DateTime), N'User')
GO
INSERT [dbo].[EmployeeLeave] ([Id], [EmployeeId], [StartDate], [EndDate], [CreatedOn], [UpdatedOn], [UpdatedBy]) VALUES (N'f9f06960-8dbf-41be-9baa-b03ea58dd7da', N'b98d6c25-4376-4ceb-aaae-355d5bd42d30', CAST(N'2026-04-04' AS Date), CAST(N'2026-05-25' AS Date), CAST(N'2025-04-13T15:31:32.080' AS DateTime), CAST(N'2025-04-13T15:31:32.080' AS DateTime), N'User')
GO
INSERT [dbo].[EmployeeLeave] ([Id], [EmployeeId], [StartDate], [EndDate], [CreatedOn], [UpdatedOn], [UpdatedBy]) VALUES (N'5871e63b-5436-4f3c-b423-c3f26a7f89f7', N'ce8e9385-e7d8-4390-81d7-ba312a5cbf5c', CAST(N'2025-04-14' AS Date), CAST(N'2025-04-15' AS Date), CAST(N'2025-04-14T01:04:43.090' AS DateTime), CAST(N'2025-04-14T01:04:43.090' AS DateTime), N'User')
GO
INSERT [dbo].[EmployeeLeave] ([Id], [EmployeeId], [StartDate], [EndDate], [CreatedOn], [UpdatedOn], [UpdatedBy]) VALUES (N'833015a1-35c2-466b-988d-ec00955da83e', N'b98d6c25-4376-4ceb-aaae-355d5bd42d30', CAST(N'2025-04-11' AS Date), CAST(N'2025-05-16' AS Date), CAST(N'2025-04-14T01:46:06.570' AS DateTime), CAST(N'2025-04-14T01:46:06.570' AS DateTime), N'User')
GO
USE [master]
GO
ALTER DATABASE [Vypex] SET  READ_WRITE 
GO
