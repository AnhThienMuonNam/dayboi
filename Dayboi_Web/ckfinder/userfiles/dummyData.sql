USE [DB_Dayboi]
GO
INSERT [dbo].[ApplicationRoles] ([Id], [Name], [Description], [Discriminator]) VALUES (N'806dd9fd-55e4-49c8-8bf3-37d7ca0c3448', N'client', NULL, N'ApplicationRole')
GO
INSERT [dbo].[ApplicationUsers] ([Id], [FullName], [Address], [BirthDay], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'341268d6-6cf2-4da5-9c2a-b95c85a27563', N'Thien', N'03182302', CAST(N'2018-08-25 18:27:29.560' AS DateTime), N'xuan01@gmail.com', 1, N'AAyWoSPtbhDYLGTPIl3bCJhXUxWOdnBQFuOVKb6rPk1zRgspZHN7fBEpIdKHAb7NWQ==', N'a7667295-db2a-4f29-b7c6-7c364be15c85', N'0893123', 0, 0, NULL, 0, 0, N'xuan012')
GO
INSERT [dbo].[ApplicationUsers] ([Id], [FullName], [Address], [BirthDay], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ed8d1c21-7236-437c-83ee-e6707c39c607', N'Thien', N'03182302', CAST(N'2018-08-25 18:29:37.087' AS DateTime), N'xuan02@gmail.com', 1, N'ADbo4FoH9AQVYbsCqJGvzk5EH2PdSuLy/AUmNMuRrIsWzbNUWy8w1Md7PP3F+AWDUQ==', N'42b0d40a-cde7-4557-a6ab-fbc907228441', N'0893123', 0, 0, NULL, 0, 0, N'xuan0123')
GO
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [ApplicationUser_Id], [IdentityRole_Id]) VALUES (N'0551b9c1-3521-4949-a5e0-6358e9cb9310', N'806dd9fd-55e4-49c8-8bf3-37d7ca0c3448', NULL, NULL)
GO
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [ApplicationUser_Id], [IdentityRole_Id]) VALUES (N'3132da59-3262-4374-bcb7-a95b66ba88cd', N'806dd9fd-55e4-49c8-8bf3-37d7ca0c3448', NULL, NULL)
GO
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [ApplicationUser_Id], [IdentityRole_Id]) VALUES (N'757159e9-7f14-4f39-ae6a-eef444053e5e', N'806dd9fd-55e4-49c8-8bf3-37d7ca0c3448', NULL, NULL)
GO
INSERT [dbo].[ApplicationUserRoles] ([UserId], [RoleId], [ApplicationUser_Id], [IdentityRole_Id]) VALUES (N'fe08fe6e-8c78-4ce5-847c-96f84dcc435d', N'806dd9fd-55e4-49c8-8bf3-37d7ca0c3448', NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

GO
INSERT [dbo].[Categories] ([Id], [Name], [Alias], [MetaKeyword], [Description], [Image], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsDeleted], [DisplayOrder], [IsActive]) VALUES (1, N'đồ bơi', N'do-boi', N'ok', N'đây là mô tả đồ bơi', N'/ckfinder/userfiles/images/28763403_2091105131172381_880871919526608896_n.jpg', CAST(N'2018-08-26 21:07:31.807' AS DateTime), CAST(N'2018-08-29 00:15:25.227' AS DateTime), NULL, N'ed8d1c21-7236-437c-83ee-e6707c39c607', 0, NULL, 1)
GO
INSERT [dbo].[Categories] ([Id], [Name], [Alias], [MetaKeyword], [Description], [Image], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsDeleted], [DisplayOrder], [IsActive]) VALUES (2, N'Đồ lặn đẹp', N'do-lan-dep', N'okok', N'Because I’m so lonely lonely, girl 
Xung quanh đông vui nhưng anh vẫn thấy sao mình thật cô đơn 
Bao nhiêu suy tư hoang mang cứ dồn vào lòng 
Chỉ riêng anh thôi 
Nên đôi khi anh muốn tâm sự cùng người lạ 
Một người không biết gì về đôi ta 
Không kêu lên “Ôi sao anh ngốc quá sao còn yêu cô ta” 
Không khuyên anh nên quên hay gắn hàn điều gì 
Vì anh đôi khi 
Chỉ cần một người ở bên lắng nghe anh nói ', N'/ckfinder/userfiles/images/116366845.jpg', CAST(N'2018-08-27 21:10:13.327' AS DateTime), CAST(N'2018-08-29 00:01:12.423' AS DateTime), NULL, N'ed8d1c21-7236-437c-83ee-e6707c39c607', 0, NULL, 1)
GO
INSERT [dbo].[Categories] ([Id], [Name], [Alias], [MetaKeyword], [Description], [Image], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsDeleted], [DisplayOrder], [IsActive]) VALUES (3, N'Đồ thở', N'do-tho', N'chanvit', N'mô tả chân vịt', N'/ckfinder/userfiles/images/28763403_2091105131172381_880871919526608896_n.jpg', CAST(N'2018-08-29 00:09:40.833' AS DateTime), NULL, NULL, NULL, 0, NULL, 1)
GO
INSERT [dbo].[Categories] ([Id], [Name], [Alias], [MetaKeyword], [Description], [Image], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsDeleted], [DisplayOrder], [IsActive]) VALUES (4, N'Quần áo bơi', N'quan-ao-boi', N'quanaoboi', N'không có mô tả', N'/ckfinder/userfiles/images/296-1246544205ElRY-960x720(1).jpg', CAST(N'2018-08-29 00:11:04.737' AS DateTime), CAST(N'2018-08-31 22:43:33.073' AS DateTime), NULL, N'ed8d1c21-7236-437c-83ee-e6707c39c607', 0, NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

GO
INSERT [dbo].[Products] ([Id], [Name], [Alias], [MetaKeyword], [Description], [Images], [Price], [IsPromotion], [Tags], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsDeleted], [DisplayOrder], [IsActive], [CategoryId]) VALUES (1, N'áo mưa max đẹp vcl', N'ao-mua-max-dep-vcl', N'ok9', N'mo tả áo mưa9', N'/ckfinder/userfiles/images/116366845.jpg,/ckfinder/userfiles/images/960x720.jpg,/ckfinder/userfiles/images/960x720.jpg', CAST(900009.00 AS Decimal(18, 2)), 0, NULL, CAST(N'2018-08-27 22:18:15.753' AS DateTime), CAST(N'2018-08-31 00:25:10.060' AS DateTime), NULL, N'ed8d1c21-7236-437c-83ee-e6707c39c607', 0, NULL, 1, 2)
GO
INSERT [dbo].[Products] ([Id], [Name], [Alias], [MetaKeyword], [Description], [Images], [Price], [IsPromotion], [Tags], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsDeleted], [DisplayOrder], [IsActive], [CategoryId]) VALUES (2, N'máy sấy tóc một hai ba bốn năm sáu', N'may-say-toc-mot-hai-ba-bon-nam-sau', N'okha', N'mo tả máy', N'/ckfinder/userfiles/images/116366845.jpg,/ckfinder/userfiles/images/28763403_2091105131172381_880871919526608896_n.jpg,/ckfinder/userfiles/images/960x720.jpg,/ckfinder/userfiles/images/28763403_2091105131172381_880871919526608896_n.jpg', CAST(80000.00 AS Decimal(18, 2)), 0, NULL, CAST(N'2018-08-27 22:19:01.017' AS DateTime), CAST(N'2018-08-31 21:39:35.550' AS DateTime), NULL, N'ed8d1c21-7236-437c-83ee-e6707c39c607', 0, NULL, 1, 1)
GO
INSERT [dbo].[Products] ([Id], [Name], [Alias], [MetaKeyword], [Description], [Images], [Price], [IsPromotion], [Tags], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsDeleted], [DisplayOrder], [IsActive], [CategoryId]) VALUES (3, N'Kính bơi đẹp bao mát nhật Sản Phẩm 100% vinamillk', N'kinh-boi-dep-bao-mat-nhat-san-pham-100-vinamillk', N'ok', N'Đôi lúc tôi hay một mình 
Tự hỏi rằng đời này có bao nhiêu ngày vui 
Đôi lúc tôi mơ một mình 
Ngồi lặng im nghe và đếm bao nhiêu ngày trôi 
Đôi lúc tôi yêu một mình 
Đường về riêng tôi lặng lẽ chẳng ai đợi tôi vuốt ve bàn tay vỗ về 
Buồn làm sao buông...? 
Đôi lúc tôi hay tự hỏi rằng 
Một mai đây mình chết có ai buồn không? 
Đôi lúc tôi hay ngộ nhận 
Nhiều điều xa xôi lạ lẫm ngỡ như là quen 
Đôi lúc muốn sống thật chậm 
Để kịp yêu thương kịp nói những điều vấn vương 
Giá như ở đâu đó người đợi lắng nghe tôi kể ', N'/ckfinder/userfiles/images/caribbean_cinemas_montehedra_17-uai-960x720.jpg,/ckfinder/userfiles/images/gk-20-site-1-960x720.jpg,/ckfinder/userfiles/images/296-1246544205ElRY-960x720.jpg,/ckfinder/userfiles/images/960x720.jpg', CAST(40000.00 AS Decimal(18, 2)), 0, NULL, CAST(N'2018-08-29 21:25:31.267' AS DateTime), CAST(N'2018-08-31 00:42:01.990' AS DateTime), NULL, N'ed8d1c21-7236-437c-83ee-e6707c39c607', 0, NULL, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderStatuses] ON 

GO
INSERT [dbo].[OrderStatuses] ([Id], [Name], [IsDeleted], [DisplayOrder], [IsActive]) VALUES (1, N'Chờ xác nhận', 0, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[OrderStatuses] OFF
GO
SET IDENTITY_INSERT [dbo].[PaymentMethods] ON 

GO
INSERT [dbo].[PaymentMethods] ([Id], [Name], [IsDeleted], [DisplayOrder], [IsActive]) VALUES (3, N'Thanh toán khi nhận hàng', 0, NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[PaymentMethods] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

GO
INSERT [dbo].[Orders] ([Id], [Name], [Email], [Phone], [Address], [TotalPrice], [OrderStatusId], [PaymentMethodId], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsDeleted]) VALUES (3, N'thiện', N'thiendandy@gmail.com', N'0312301293', NULL, CAST(440000.00 AS Decimal(18, 2)), 1, 3, CAST(N'2018-08-31 19:15:21.487' AS DateTime), NULL, NULL, NULL, 0)
GO
INSERT [dbo].[Orders] ([Id], [Name], [Email], [Phone], [Address], [TotalPrice], [OrderStatusId], [PaymentMethodId], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsDeleted]) VALUES (4, N'Thien', N'bccthien@gmail.com', N'0218312', NULL, CAST(120000.00 AS Decimal(18, 2)), 1, 3, CAST(N'2018-08-31 19:34:57.677' AS DateTime), NULL, NULL, NULL, 0)
GO
INSERT [dbo].[Orders] ([Id], [Name], [Email], [Phone], [Address], [TotalPrice], [OrderStatusId], [PaymentMethodId], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsDeleted]) VALUES (5, N'Thien', N'bccthien@gmail.com', N'0218312', NULL, CAST(200000.00 AS Decimal(18, 2)), 1, 3, CAST(N'2018-08-31 19:37:49.177' AS DateTime), NULL, NULL, NULL, 0)
GO
INSERT [dbo].[Orders] ([Id], [Name], [Email], [Phone], [Address], [TotalPrice], [OrderStatusId], [PaymentMethodId], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsDeleted]) VALUES (6, N'Thien', N'thiendandy@gmail.com', N'0218312', NULL, CAST(480000.00 AS Decimal(18, 2)), 1, 3, CAST(N'2018-08-31 19:41:04.400' AS DateTime), NULL, NULL, NULL, 0)
GO
INSERT [dbo].[Orders] ([Id], [Name], [Email], [Phone], [Address], [TotalPrice], [OrderStatusId], [PaymentMethodId], [CreatedOn], [UpdatedOn], [CreatedBy], [UpdatedBy], [IsDeleted]) VALUES (7, N'thiện', N'thiendandy@gmail.com', N'02193012', NULL, CAST(40000.00 AS Decimal(18, 2)), 1, 3, CAST(N'2018-08-31 21:52:58.187' AS DateTime), NULL, NULL, NULL, 0)
GO
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderDetails] ON 

GO
INSERT [dbo].[OrderDetails] ([Id], [ProductName], [Price], [SumPrice], [Quantity], [OrderId], [ProductId]) VALUES (1, N'Kính bơi đẹp bao mát nhật Sản Phẩm 100% vinamillk', CAST(40000.00 AS Decimal(18, 2)), CAST(280000.00 AS Decimal(18, 2)), 7, 3, 3)
GO
INSERT [dbo].[OrderDetails] ([Id], [ProductName], [Price], [SumPrice], [Quantity], [OrderId], [ProductId]) VALUES (2, N'máy sấy tóc một hai ba bốn năm sáu bảydasd', CAST(80000.00 AS Decimal(18, 2)), CAST(160000.00 AS Decimal(18, 2)), 2, 3, 2)
GO
INSERT [dbo].[OrderDetails] ([Id], [ProductName], [Price], [SumPrice], [Quantity], [OrderId], [ProductId]) VALUES (3, N'Kính bơi đẹp bao mát nhật Sản Phẩm 100% vinamillk', CAST(40000.00 AS Decimal(18, 2)), CAST(40000.00 AS Decimal(18, 2)), 1, 4, 3)
GO
INSERT [dbo].[OrderDetails] ([Id], [ProductName], [Price], [SumPrice], [Quantity], [OrderId], [ProductId]) VALUES (4, N'máy sấy tóc một hai ba bốn năm sáu bảydasd', CAST(80000.00 AS Decimal(18, 2)), CAST(80000.00 AS Decimal(18, 2)), 1, 4, 2)
GO
INSERT [dbo].[OrderDetails] ([Id], [ProductName], [Price], [SumPrice], [Quantity], [OrderId], [ProductId]) VALUES (5, N'Kính bơi đẹp bao mát nhật Sản Phẩm 100% vinamillk', CAST(40000.00 AS Decimal(18, 2)), CAST(40000.00 AS Decimal(18, 2)), 1, 5, 3)
GO
INSERT [dbo].[OrderDetails] ([Id], [ProductName], [Price], [SumPrice], [Quantity], [OrderId], [ProductId]) VALUES (6, N'máy sấy tóc một hai ba bốn năm sáu bảydasd', CAST(80000.00 AS Decimal(18, 2)), CAST(160000.00 AS Decimal(18, 2)), 2, 5, 2)
GO
INSERT [dbo].[OrderDetails] ([Id], [ProductName], [Price], [SumPrice], [Quantity], [OrderId], [ProductId]) VALUES (7, N'Kính bơi đẹp bao mát nhật Sản Phẩm 100% vinamillk', CAST(40000.00 AS Decimal(18, 2)), CAST(240000.00 AS Decimal(18, 2)), 6, 6, 3)
GO
INSERT [dbo].[OrderDetails] ([Id], [ProductName], [Price], [SumPrice], [Quantity], [OrderId], [ProductId]) VALUES (8, N'máy sấy tóc một hai ba bốn năm sáu bảydasd', CAST(80000.00 AS Decimal(18, 2)), CAST(240000.00 AS Decimal(18, 2)), 3, 6, 2)
GO
INSERT [dbo].[OrderDetails] ([Id], [ProductName], [Price], [SumPrice], [Quantity], [OrderId], [ProductId]) VALUES (9, N'Kính bơi đẹp bao mát nhật Sản Phẩm 100% vinamillk', CAST(40000.00 AS Decimal(18, 2)), CAST(40000.00 AS Decimal(18, 2)), 1, 7, 3)
GO
SET IDENTITY_INSERT [dbo].[OrderDetails] OFF
GO
