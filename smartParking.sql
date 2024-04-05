USE [zx_sp_record1]
GO
SET IDENTITY_INSERT [dbo].[menus] ON 

INSERT [dbo].[menus] ([menu_id], [menu_header], [target_view], [parent_id], [menu_icon], [index], [menu_type], [state]) VALUES (14, N'系统维护', NULL, 0, N'e618', 1, 1, 1)
INSERT [dbo].[menus] ([menu_id], [menu_header], [target_view], [parent_id], [menu_icon], [index], [menu_type], [state]) VALUES (15, N'菜单管理', N'MenuManagementView', 14, NULL, 0, 0, 1)
INSERT [dbo].[menus] ([menu_id], [menu_header], [target_view], [parent_id], [menu_icon], [index], [menu_type], [state]) VALUES (16, N'升级文件上传', N'FileUploadView', 14, NULL, 2, 0, 1)
INSERT [dbo].[menus] ([menu_id], [menu_header], [target_view], [parent_id], [menu_icon], [index], [menu_type], [state]) VALUES (17, N'基础信息管理', NULL, 0, N'e6b8', 2, 1, 1)
INSERT [dbo].[menus] ([menu_id], [menu_header], [target_view], [parent_id], [menu_icon], [index], [menu_type], [state]) VALUES (18, N'系统用户', N'UserManagementView', 17, NULL, 1, 0, 1)
INSERT [dbo].[menus] ([menu_id], [menu_header], [target_view], [parent_id], [menu_icon], [index], [menu_type], [state]) VALUES (19, N'用户角色', N'RoleManagementView', 17, NULL, 2, 0, 1)
INSERT [dbo].[menus] ([menu_id], [menu_header], [target_view], [parent_id], [menu_icon], [index], [menu_type], [state]) VALUES (25, N'车辆计费管理', NULL, 0, N'e605', 4, 1, 1)
INSERT [dbo].[menus] ([menu_id], [menu_header], [target_view], [parent_id], [menu_icon], [index], [menu_type], [state]) VALUES (26, N'会员车辆登录', N'AutoRegisterView', 25, NULL, 1, 0, 1)
INSERT [dbo].[menus] ([menu_id], [menu_header], [target_view], [parent_id], [menu_icon], [index], [menu_type], [state]) VALUES (27, N'报表与统计', NULL, 0, N'e624', 8, 1, 1)
INSERT [dbo].[menus] ([menu_id], [menu_header], [target_view], [parent_id], [menu_icon], [index], [menu_type], [state]) VALUES (28, N'车辆出入记录统计', N'ReportView', 27, NULL, 1, 1, 1)
INSERT [dbo].[menus] ([menu_id], [menu_header], [target_view], [parent_id], [menu_icon], [index], [menu_type], [state]) VALUES (29, N'设备管理', N'DeviceManagementView', 17, NULL, 3, 0, 1)
INSERT [dbo].[menus] ([menu_id], [menu_header], [target_view], [parent_id], [menu_icon], [index], [menu_type], [state]) VALUES (31, N'会员续费记录', N'MembershipFeeView', 25, NULL, 2, 0, 1)
INSERT [dbo].[menus] ([menu_id], [menu_header], [target_view], [parent_id], [menu_icon], [index], [menu_type], [state]) VALUES (32, N'订单管理', NULL, 0, N'e604', 5, 1, 1)
INSERT [dbo].[menus] ([menu_id], [menu_header], [target_view], [parent_id], [menu_icon], [index], [menu_type], [state]) VALUES (33, N'订单记录', N'OrderRecordView', 32, NULL, 1, 0, 1)
INSERT [dbo].[menus] ([menu_id], [menu_header], [target_view], [parent_id], [menu_icon], [index], [menu_type], [state]) VALUES (34, N'放行记录', N'PassRecordView', 32, NULL, 2, 0, 1)
INSERT [dbo].[menus] ([menu_id], [menu_header], [target_view], [parent_id], [menu_icon], [index], [menu_type], [state]) VALUES (36, N'优惠活动', NULL, 0, N'e66d', 6, 1, 1)
INSERT [dbo].[menus] ([menu_id], [menu_header], [target_view], [parent_id], [menu_icon], [index], [menu_type], [state]) VALUES (37, N'优惠券管理', N'DiscountView', 36, NULL, 1, 0, 1)
INSERT [dbo].[menus] ([menu_id], [menu_header], [target_view], [parent_id], [menu_icon], [index], [menu_type], [state]) VALUES (38, N'优惠券使用记录', N'DiscountUseView', 36, NULL, 2, 0, 1)
INSERT [dbo].[menus] ([menu_id], [menu_header], [target_view], [parent_id], [menu_icon], [index], [menu_type], [state]) VALUES (39, N'访客管理', NULL, 0, N'e606', 7, 1, 1)
INSERT [dbo].[menus] ([menu_id], [menu_header], [target_view], [parent_id], [menu_icon], [index], [menu_type], [state]) VALUES (40, N'访客人员登记', N'VisitorRecordView', 39, NULL, 1, 0, 1)
INSERT [dbo].[menus] ([menu_id], [menu_header], [target_view], [parent_id], [menu_icon], [index], [menu_type], [state]) VALUES (41, N'业主记录', N'OwnerRecordView', 39, NULL, 2, 0, 1)
INSERT [dbo].[menus] ([menu_id], [menu_header], [target_view], [parent_id], [menu_icon], [index], [menu_type], [state]) VALUES (43, N'收费员日报', N'CollectorReportView', 27, NULL, 2, 0, 1)
INSERT [dbo].[menus] ([menu_id], [menu_header], [target_view], [parent_id], [menu_icon], [index], [menu_type], [state]) VALUES (44, N'车场月报', N'ParkingReportView', 27, NULL, 3, 0, 1)
INSERT [dbo].[menus] ([menu_id], [menu_header], [target_view], [parent_id], [menu_icon], [index], [menu_type], [state]) VALUES (45, N'一级菜单', NULL, 0, N'e618', 9, 1, 1)
INSERT [dbo].[menus] ([menu_id], [menu_header], [target_view], [parent_id], [menu_icon], [index], [menu_type], [state]) VALUES (46, N'二级菜单', NULL, 45, NULL, 1, 1, 1)
INSERT [dbo].[menus] ([menu_id], [menu_header], [target_view], [parent_id], [menu_icon], [index], [menu_type], [state]) VALUES (47, N'三级菜单', NULL, 46, NULL, 1, 1, 1)
INSERT [dbo].[menus] ([menu_id], [menu_header], [target_view], [parent_id], [menu_icon], [index], [menu_type], [state]) VALUES (48, N'四级菜单', N'DashboardView', 47, NULL, 1, 0, 1)
SET IDENTITY_INSERT [dbo].[menus] OFF
GO
INSERT [dbo].[role_menu] ([role_id], [menu_id]) VALUES (1, 14)
INSERT [dbo].[role_menu] ([role_id], [menu_id]) VALUES (2, 14)
INSERT [dbo].[role_menu] ([role_id], [menu_id]) VALUES (1, 15)
INSERT [dbo].[role_menu] ([role_id], [menu_id]) VALUES (2, 15)
INSERT [dbo].[role_menu] ([role_id], [menu_id]) VALUES (1, 16)
INSERT [dbo].[role_menu] ([role_id], [menu_id]) VALUES (2, 16)
INSERT [dbo].[role_menu] ([role_id], [menu_id]) VALUES (1, 17)
INSERT [dbo].[role_menu] ([role_id], [menu_id]) VALUES (1, 18)
INSERT [dbo].[role_menu] ([role_id], [menu_id]) VALUES (1, 19)
INSERT [dbo].[role_menu] ([role_id], [menu_id]) VALUES (1, 25)
INSERT [dbo].[role_menu] ([role_id], [menu_id]) VALUES (1, 26)
INSERT [dbo].[role_menu] ([role_id], [menu_id]) VALUES (1, 27)
INSERT [dbo].[role_menu] ([role_id], [menu_id]) VALUES (1, 28)
INSERT [dbo].[role_menu] ([role_id], [menu_id]) VALUES (1, 29)
INSERT [dbo].[role_menu] ([role_id], [menu_id]) VALUES (1, 31)
INSERT [dbo].[role_menu] ([role_id], [menu_id]) VALUES (1, 32)
INSERT [dbo].[role_menu] ([role_id], [menu_id]) VALUES (1, 33)
INSERT [dbo].[role_menu] ([role_id], [menu_id]) VALUES (1, 34)
INSERT [dbo].[role_menu] ([role_id], [menu_id]) VALUES (1, 36)
INSERT [dbo].[role_menu] ([role_id], [menu_id]) VALUES (1, 37)
INSERT [dbo].[role_menu] ([role_id], [menu_id]) VALUES (1, 38)
INSERT [dbo].[role_menu] ([role_id], [menu_id]) VALUES (1, 39)
INSERT [dbo].[role_menu] ([role_id], [menu_id]) VALUES (1, 40)
INSERT [dbo].[role_menu] ([role_id], [menu_id]) VALUES (1, 41)
INSERT [dbo].[role_menu] ([role_id], [menu_id]) VALUES (1, 43)
INSERT [dbo].[role_menu] ([role_id], [menu_id]) VALUES (1, 44)
INSERT [dbo].[role_menu] ([role_id], [menu_id]) VALUES (1, 45)
INSERT [dbo].[role_menu] ([role_id], [menu_id]) VALUES (1, 46)
INSERT [dbo].[role_menu] ([role_id], [menu_id]) VALUES (1, 47)
INSERT [dbo].[role_menu] ([role_id], [menu_id]) VALUES (1, 48)
GO
SET IDENTITY_INSERT [dbo].[roles] ON 

INSERT [dbo].[roles] ([role_id], [role_name], [state]) VALUES (1, N'超级管理员', 1)
INSERT [dbo].[roles] ([role_id], [role_name], [state]) VALUES (2, N'Zhaoxi', 1)
INSERT [dbo].[roles] ([role_id], [role_name], [state]) VALUES (1002, N'123', 1)
INSERT [dbo].[roles] ([role_id], [role_name], [state]) VALUES (1003, N'456', 1)
INSERT [dbo].[roles] ([role_id], [role_name], [state]) VALUES (1004, N'789', 1)
SET IDENTITY_INSERT [dbo].[roles] OFF
GO
INSERT [dbo].[user_role] ([user_id], [role_id]) VALUES (1, 1)
INSERT [dbo].[user_role] ([user_id], [role_id]) VALUES (1, 2)
INSERT [dbo].[user_role] ([user_id], [role_id]) VALUES (2, 2)
INSERT [dbo].[user_role] ([user_id], [role_id]) VALUES (6, 4)
GO
