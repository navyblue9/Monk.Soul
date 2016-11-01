------------------------------------------------------------------------------------------------------
-- 文件名称：Monk.Soul 通用管理系统数据表设计
-- 文件作者：百小僧
-- 创建日期：2016年10月11日
-- 版权所有：百签软件（中山）有限公司、百小僧
-- 官方网站：www.baisoft.org
------------------------------------------------------------------------------------------------------
USE [Monk.Soul]
GO
-- 会员
IF(OBJECT_ID('dbo.[Member]',N'U') IS NOT NULL)
	DROP TABLE dbo.[Member]
GO
CREATE TABLE dbo.[Member]
(
	[MemberID] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,	-- ID
	[Account] NVARCHAR(32) NOT NULL,	-- 账号
	[Password] CHAR(32) NOT NULL,	-- 密码
	[Email] NVARCHAR(256) NOT NULL,	-- 邮箱
	[Phone] VARCHAR(32),	-- 手机
	[Photo] NVARCHAR(200),	-- 照片
	[Remark] NVARCHAR(200) DEFAULT('亲，你还没介绍自己哦~'),	-- 描述
	[GroupID] UNIQUEIDENTIFIER NOT NULL,	-- 会员组ID
	[Enable] BIT NOT NULL DEFAULT(1),	-- 启用
	[Pass] BIT NOT NULL DEFAULT(1),	-- 审核
	-- 以下为通用字段，除了UpdateTime，SerialNo，LogMemberID以外，其他禁止插入，禁止更新（但不包含软删除，硬删除）
	[SerialNo] INT IDENTITY(1,1),	-- 流水号
	[UpdateTime] DATETIME, -- 更新时间
	[Default] BIT NOT NULL DEFAULT(0),	-- 默认
	[Del] BIT NOT NULL DEFAULT(0),	-- 软删除
	[Destroy] BIT NOT NULL DEFAULT(0),	-- 硬删除
	[CreateTime] DATETIME NOT NULL DEFAULT(GETDATE()),	-- 创建时间
	[LogMemberID] UNIQUEIDENTIFIER NOT NULL	-- 记录会员
)
GO
EXEC sp_addextendedproperty N'MS_Description', N'会员', N'user', N'dbo', N'table', N'Member';
GO
EXEC sp_addextendedproperty N'MS_Description', N'ID', N'user', N'dbo', N'table', N'Member', N'column', N'MemberID';
EXEC sp_addextendedproperty N'MS_Description', N'账号', N'user', N'dbo', N'table', N'Member', N'column', N'Account';
EXEC sp_addextendedproperty N'MS_Description', N'密码', N'user', N'dbo', N'table', N'Member', N'column', N'Password';
EXEC sp_addextendedproperty N'MS_Description', N'邮箱', N'user', N'dbo', N'table', N'Member', N'column', N'Email';
EXEC sp_addextendedproperty N'MS_Description', N'手机', N'user', N'dbo', N'table', N'Member', N'column', N'Phone';
EXEC sp_addextendedproperty N'MS_Description', N'照片', N'user', N'dbo', N'table', N'Member', N'column', N'Photo';
EXEC sp_addextendedproperty N'MS_Description', N'描述', N'user', N'dbo', N'table', N'Member', N'column', N'Remark';
EXEC sp_addextendedproperty N'MS_Description', N'会员组ID', N'user', N'dbo', N'table', N'Member', N'column', N'GroupID';
EXEC sp_addextendedproperty N'MS_Description', N'启用', N'user', N'dbo', N'table', N'Member', N'column', N'Enable';
EXEC sp_addextendedproperty N'MS_Description', N'审核', N'user', N'dbo', N'table', N'Member', N'column', N'Pass';
EXEC sp_addextendedproperty N'MS_Description', N'流水号', N'user', N'dbo', N'table', N'Member', N'column', N'SerialNo';
EXEC sp_addextendedproperty N'MS_Description', N'更新时间', N'user', N'dbo', N'table', N'Member', N'column', N'UpdateTime';
EXEC sp_addextendedproperty N'MS_Description', N'默认', N'user', N'dbo', N'table', N'Member', N'column', N'Default';
EXEC sp_addextendedproperty N'MS_Description', N'软删除', N'user', N'dbo', N'table', N'Member', N'column', N'Del';
EXEC sp_addextendedproperty N'MS_Description', N'硬删除', N'user', N'dbo', N'table', N'Member', N'column', N'Destroy';
EXEC sp_addextendedproperty N'MS_Description', N'创建时间', N'user', N'dbo', N'table', N'Member', N'column', N'CreateTime';
EXEC sp_addextendedproperty N'MS_Description', N'记录会员', N'user', N'dbo', N'table', N'Member', N'column', N'LogMemberID';
GO


-- 会员组
IF(OBJECT_ID('dbo.[Group]',N'U') IS NOT NULL)
	DROP TABLE dbo.[Group]
GO
CREATE TABLE dbo.[Group]
(
	[GroupID] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,	-- ID
	[Name] NVARCHAR(32) NOT NULL,	-- 名称
	[Remark] NVARCHAR(200),	-- 描述
	[ParentID] UNIQUEIDENTIFIER,	-- 上级ID
	[Enable] BIT NOT NULL DEFAULT(1),	-- 启用
	-- 以下为通用字段，除了UpdateTime，SerialNo，LogMemberID以外，其他禁止插入，禁止更新（但不包含软删除，硬删除）
	[SerialNo] INT IDENTITY(1,1),	-- 流水号
	[UpdateTime] DATETIME, -- 更新时间
	[Default] BIT NOT NULL DEFAULT(0),	-- 默认
	[Del] BIT NOT NULL DEFAULT(0),	-- 软删除
	[Destroy] BIT NOT NULL DEFAULT(0),	-- 硬删除
	[CreateTime] DATETIME NOT NULL DEFAULT(GETDATE()),	-- 创建时间
	[LogMemberID] UNIQUEIDENTIFIER NOT NULL	-- 记录会员
)
GO
EXEC sp_addextendedproperty N'MS_Description', N'会员组', N'user', N'dbo', N'table', N'Group';
GO
EXEC sp_addextendedproperty N'MS_Description', N'ID', N'user', N'dbo', N'table', N'Group', N'column', N'GroupID';
EXEC sp_addextendedproperty N'MS_Description', N'名称', N'user', N'dbo', N'table', N'Group', N'column', N'Name';
EXEC sp_addextendedproperty N'MS_Description', N'描述', N'user', N'dbo', N'table', N'Group', N'column', N'Remark';
EXEC sp_addextendedproperty N'MS_Description', N'上级ID', N'user', N'dbo', N'table', N'Group', N'column', N'ParentID';
EXEC sp_addextendedproperty N'MS_Description', N'启用', N'user', N'dbo', N'table', N'Group', N'column', N'Enable';
EXEC sp_addextendedproperty N'MS_Description', N'流水号', N'user', N'dbo', N'table', N'Group', N'column', N'SerialNo';
EXEC sp_addextendedproperty N'MS_Description', N'更新时间', N'user', N'dbo', N'table', N'Group', N'column', N'UpdateTime';
EXEC sp_addextendedproperty N'MS_Description', N'默认', N'user', N'dbo', N'table', N'Group', N'column', N'Default';
EXEC sp_addextendedproperty N'MS_Description', N'软删除', N'user', N'dbo', N'table', N'Group', N'column', N'Del';
EXEC sp_addextendedproperty N'MS_Description', N'硬删除', N'user', N'dbo', N'table', N'Group', N'column', N'Destroy';
EXEC sp_addextendedproperty N'MS_Description', N'创建时间', N'user', N'dbo', N'table', N'Group', N'column', N'CreateTime';
EXEC sp_addextendedproperty N'MS_Description', N'记录会员', N'user', N'dbo', N'table', N'Group', N'column', N'LogMemberID';
GO


-- 角色
IF(OBJECT_ID('dbo.[Role]',N'U') IS NOT NULL)
	DROP TABLE dbo.[Role]
GO
CREATE TABLE dbo.[Role]
(
	[RoleID] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,	-- ID
	[Name] NVARCHAR(32) NOT NULL,	-- 名称
	[Remark] NVARCHAR(200),	-- 描述
	[Enable] BIT NOT NULL DEFAULT(1),	-- 启用
	-- 以下为通用字段，除了UpdateTime，SerialNo，LogMemberID以外，其他禁止插入，禁止更新（但不包含软删除，硬删除）
	[SerialNo] INT IDENTITY(1,1),	-- 流水号
	[UpdateTime] DATETIME, -- 更新时间
	[Default] BIT NOT NULL DEFAULT(0),	-- 默认
	[Del] BIT NOT NULL DEFAULT(0),	-- 软删除
	[Destroy] BIT NOT NULL DEFAULT(0),	-- 硬删除
	[CreateTime] DATETIME NOT NULL DEFAULT(GETDATE()),	-- 创建时间
	[LogMemberID] UNIQUEIDENTIFIER NOT NULL	-- 记录会员
)
GO
EXEC sp_addextendedproperty N'MS_Description', N'角色', N'user', N'dbo', N'table', N'Role';
GO
EXEC sp_addextendedproperty N'MS_Description', N'ID', N'user', N'dbo', N'table', N'Role', N'column', N'RoleID';
EXEC sp_addextendedproperty N'MS_Description', N'名称', N'user', N'dbo', N'table', N'Role', N'column', N'Name';
EXEC sp_addextendedproperty N'MS_Description', N'描述', N'user', N'dbo', N'table', N'Role', N'column', N'Remark';
EXEC sp_addextendedproperty N'MS_Description', N'启用', N'user', N'dbo', N'table', N'Role', N'column', N'Enable';
EXEC sp_addextendedproperty N'MS_Description', N'流水号', N'user', N'dbo', N'table', N'Role', N'column', N'SerialNo';
EXEC sp_addextendedproperty N'MS_Description', N'更新时间', N'user', N'dbo', N'table', N'Role', N'column', N'UpdateTime';
EXEC sp_addextendedproperty N'MS_Description', N'默认', N'user', N'dbo', N'table', N'Role', N'column', N'Default';
EXEC sp_addextendedproperty N'MS_Description', N'软删除', N'user', N'dbo', N'table', N'Role', N'column', N'Del';
EXEC sp_addextendedproperty N'MS_Description', N'硬删除', N'user', N'dbo', N'table', N'Role', N'column', N'Destroy';
EXEC sp_addextendedproperty N'MS_Description', N'创建时间', N'user', N'dbo', N'table', N'Role', N'column', N'CreateTime';
EXEC sp_addextendedproperty N'MS_Description', N'记录会员', N'user', N'dbo', N'table', N'Role', N'column', N'LogMemberID';
GO


-- 会员与角色关系
IF(OBJECT_ID('dbo.[Member_Role]',N'U') IS NOT NULL)
	DROP TABLE dbo.[Member_Role]
GO
CREATE TABLE dbo.[Member_Role]
(
	[MemberID] UNIQUEIDENTIFIER NOT NULL,	-- 会员ID
	[RoleID] UNIQUEIDENTIFIER NOT NULL,	-- 角色ID
	-- 以下为通用字段，除了UpdateTime，SerialNo，LogMemberID以外，其他禁止插入，禁止更新（但不包含软删除，硬删除）
	[SerialNo] INT IDENTITY(1,1) PRIMARY KEY,	-- 流水号
	[UpdateTime] DATETIME, -- 更新时间
	[Default] BIT NOT NULL DEFAULT(0),	-- 默认
	[Del] BIT NOT NULL DEFAULT(0),	-- 软删除
	[Destroy] BIT NOT NULL DEFAULT(0),	-- 硬删除
	[CreateTime] DATETIME NOT NULL DEFAULT(GETDATE()),	-- 创建时间
	[LogMemberID] UNIQUEIDENTIFIER NOT NULL	-- 记录会员
)
GO
EXEC sp_addextendedproperty N'MS_Description', N'会员与角色关系', N'user', N'dbo', N'table', N'Member_Role';
GO
EXEC sp_addextendedproperty N'MS_Description', N'会员ID', N'user', N'dbo', N'table', N'Member_Role', N'column', N'MemberID';
EXEC sp_addextendedproperty N'MS_Description', N'角色ID', N'user', N'dbo', N'table', N'Member_Role', N'column', N'RoleID';
EXEC sp_addextendedproperty N'MS_Description', N'流水号', N'user', N'dbo', N'table', N'Member_Role', N'column', N'SerialNo';
EXEC sp_addextendedproperty N'MS_Description', N'更新时间', N'user', N'dbo', N'table', N'Member_Role', N'column', N'UpdateTime';
EXEC sp_addextendedproperty N'MS_Description', N'默认', N'user', N'dbo', N'table', N'Member_Role', N'column', N'Default';
EXEC sp_addextendedproperty N'MS_Description', N'软删除', N'user', N'dbo', N'table', N'Member_Role', N'column', N'Del';
EXEC sp_addextendedproperty N'MS_Description', N'硬删除', N'user', N'dbo', N'table', N'Member_Role', N'column', N'Destroy';
EXEC sp_addextendedproperty N'MS_Description', N'创建时间', N'user', N'dbo', N'table', N'Member_Role', N'column', N'CreateTime';
EXEC sp_addextendedproperty N'MS_Description', N'记录会员', N'user', N'dbo', N'table', N'Member_Role', N'column', N'LogMemberID';
GO

-- 会员组与角色关系
IF(OBJECT_ID('dbo.[Group_Role]',N'U') IS NOT NULL)
	DROP TABLE dbo.[Group_Role]
GO
CREATE TABLE dbo.[Group_Role]
(
	[GroupID] UNIQUEIDENTIFIER NOT NULL,	-- 会员组ID
	[RoleID] UNIQUEIDENTIFIER NOT NULL,	-- 角色ID
	-- 以下为通用字段，除了UpdateTime，SerialNo，LogMemberID以外，其他禁止插入，禁止更新（但不包含软删除，硬删除）
	[SerialNo] INT IDENTITY(1,1) PRIMARY KEY,	-- 流水号
	[UpdateTime] DATETIME, -- 更新时间
	[Default] BIT NOT NULL DEFAULT(0),	-- 默认
	[Del] BIT NOT NULL DEFAULT(0),	-- 软删除
	[Destroy] BIT NOT NULL DEFAULT(0),	-- 硬删除
	[CreateTime] DATETIME NOT NULL DEFAULT(GETDATE()),	-- 创建时间
	[LogMemberID] UNIQUEIDENTIFIER NOT NULL	-- 记录会员
)
GO
EXEC sp_addextendedproperty N'MS_Description', N'会员组与角色关系', N'user', N'dbo', N'table', N'Group_Role';
GO
EXEC sp_addextendedproperty N'MS_Description', N'会员ID', N'user', N'dbo', N'table', N'Group_Role', N'column', N'GroupID';
EXEC sp_addextendedproperty N'MS_Description', N'角色ID', N'user', N'dbo', N'table', N'Group_Role', N'column', N'RoleID';
EXEC sp_addextendedproperty N'MS_Description', N'流水号', N'user', N'dbo', N'table', N'Group_Role', N'column', N'SerialNo';
EXEC sp_addextendedproperty N'MS_Description', N'更新时间', N'user', N'dbo', N'table', N'Group_Role', N'column', N'UpdateTime';
EXEC sp_addextendedproperty N'MS_Description', N'默认', N'user', N'dbo', N'table', N'Group_Role', N'column', N'Default';
EXEC sp_addextendedproperty N'MS_Description', N'软删除', N'user', N'dbo', N'table', N'Group_Role', N'column', N'Del';
EXEC sp_addextendedproperty N'MS_Description', N'硬删除', N'user', N'dbo', N'table', N'Group_Role', N'column', N'Destroy';
EXEC sp_addextendedproperty N'MS_Description', N'创建时间', N'user', N'dbo', N'table', N'Group_Role', N'column', N'CreateTime';
EXEC sp_addextendedproperty N'MS_Description', N'记录会员', N'user', N'dbo', N'table', N'Group_Role', N'column', N'LogMemberID';
GO


-- 登录日志
IF(OBJECT_ID('dbo.[LoginLog]',N'U') IS NOT NULL)
	DROP TABLE dbo.[LoginLog]
GO
CREATE TABLE dbo.[LoginLog]
(
	[LogID] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,	-- ID
	[Account] NVARCHAR(32) NOT NULL,	-- 账号
	[Password] NVARCHAR(64) NOT NULL,	-- 密码
	[InTime] DATETIME NOT NULL DEFAULT(GETDATE()),	-- 试登时间
	[OffTime] DATETIME,	-- 登出时间
	[Sucessed] BIT NOT NULL DEFAULT(0),	-- 成功
	[MemberID] UNIQUEIDENTIFIER,	-- 会员ID
	[IPAddress] NVARCHAR(16) NOT NULL,	-- IP地址
	[IPDetail] NVARCHAR(100),	-- IP详情
	[HttpMethod] VARCHAR(32) NOT NULL,	-- HTTP方式
	[AjaxRequest] BIT NOT NULL,	-- 异步请求
	[MobileDevice] BIT NOT NULL,	-- 移动设备
	[Platform] NVARCHAR(100) NOT NULL,	-- 操作系统
	[Browser] NVARCHAR(100) NOT NULL,	--浏览器
	-- 以下为通用字段，除了UpdateTime，SerialNo，LogMemberID以外，其他禁止插入，禁止更新（但不包含软删除，硬删除）
	[SerialNo] INT IDENTITY(1,1),	-- 流水号
	[UpdateTime] DATETIME, -- 更新时间
	[Default] BIT NOT NULL DEFAULT(0),	-- 默认
	[Del] BIT NOT NULL DEFAULT(0),	-- 软删除
	[Destroy] BIT NOT NULL DEFAULT(0),	-- 硬删除
	[CreateTime] DATETIME NOT NULL DEFAULT(GETDATE()),	-- 创建时间
	[LogMemberID] UNIQUEIDENTIFIER NOT NULL	-- 记录会员
)
GO
EXEC sp_addextendedproperty N'MS_Description', N'登录日志', N'user', N'dbo', N'table', N'LoginLog';
GO
EXEC sp_addextendedproperty N'MS_Description', N'ID', N'user', N'dbo', N'table', N'LoginLog', N'column', N'LogID';
EXEC sp_addextendedproperty N'MS_Description', N'账号', N'user', N'dbo', N'table', N'LoginLog', N'column', N'Account';
EXEC sp_addextendedproperty N'MS_Description', N'密码', N'user', N'dbo', N'table', N'LoginLog', N'column', N'Password';
EXEC sp_addextendedproperty N'MS_Description', N'试登时间', N'user', N'dbo', N'table', N'LoginLog', N'column', N'InTime';
EXEC sp_addextendedproperty N'MS_Description', N'登出时间', N'user', N'dbo', N'table', N'LoginLog', N'column', N'OffTime';
EXEC sp_addextendedproperty N'MS_Description', N'成功', N'user', N'dbo', N'table', N'LoginLog', N'column', N'Sucessed';
EXEC sp_addextendedproperty N'MS_Description', N'会员ID', N'user', N'dbo', N'table', N'LoginLog', N'column', N'MemberID';
EXEC sp_addextendedproperty N'MS_Description', N'IP地址', N'user', N'dbo', N'table', N'LoginLog', N'column', N'IPAddress';
EXEC sp_addextendedproperty N'MS_Description', N'IP详情', N'user', N'dbo', N'table', N'LoginLog', N'column', N'IPDetail';
EXEC sp_addextendedproperty N'MS_Description', N'HTTP方式', N'user', N'dbo', N'table', N'LoginLog', N'column', N'HttpMethod';
EXEC sp_addextendedproperty N'MS_Description', N'异步请求', N'user', N'dbo', N'table', N'LoginLog', N'column', N'AjaxRequest';
EXEC sp_addextendedproperty N'MS_Description', N'移动设备', N'user', N'dbo', N'table', N'LoginLog', N'column', N'MobileDevice';
EXEC sp_addextendedproperty N'MS_Description', N'操作系统', N'user', N'dbo', N'table', N'LoginLog', N'column', N'Platform';
EXEC sp_addextendedproperty N'MS_Description', N'浏览器', N'user', N'dbo', N'table', N'LoginLog', N'column', N'Browser';
EXEC sp_addextendedproperty N'MS_Description', N'流水号', N'user', N'dbo', N'table', N'LoginLog', N'column', N'SerialNo';
EXEC sp_addextendedproperty N'MS_Description', N'更新时间', N'user', N'dbo', N'table', N'LoginLog', N'column', N'UpdateTime';
EXEC sp_addextendedproperty N'MS_Description', N'默认', N'user', N'dbo', N'table', N'LoginLog', N'column', N'Default';
EXEC sp_addextendedproperty N'MS_Description', N'软删除', N'user', N'dbo', N'table', N'LoginLog', N'column', N'Del';
EXEC sp_addextendedproperty N'MS_Description', N'硬删除', N'user', N'dbo', N'table', N'LoginLog', N'column', N'Destroy';
EXEC sp_addextendedproperty N'MS_Description', N'创建时间', N'user', N'dbo', N'table', N'LoginLog', N'column', N'CreateTime';
EXEC sp_addextendedproperty N'MS_Description', N'记录会员', N'user', N'dbo', N'table', N'LoginLog', N'column', N'LogMemberID';
GO

-- 请求日志
IF(OBJECT_ID('dbo.[HttpLog]',N'U') IS NOT NULL)
	DROP TABLE dbo.[HttpLog]
GO
CREATE TABLE dbo.[HttpLog]
(
	[LogID] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,	-- ID
	[Referrer] NVARCHAR(512),	-- 来源地址
	[Url] NVARCHAR(512) NOT NULL,	-- 请求地址
	[Data] TEXT,	-- 传输数据
	[MemberID] UNIQUEIDENTIFIER,	-- 会员ID
	[IPAddress] NVARCHAR(16) NOT NULL,	-- IP地址
	[IPDetail] NVARCHAR(100),	-- IP详情
	[HttpMethod] VARCHAR(32) NOT NULL,	-- HTTP方式
	[AjaxRequest] BIT NOT NULL,	-- 异步请求
	[MobileDevice] BIT NOT NULL,	-- 移动设备
	[Platform] NVARCHAR(100) NOT NULL,	-- 操作系统
	[Browser] NVARCHAR(100) NOT NULL,	--浏览器
	-- 以下为通用字段，除了UpdateTime，SerialNo，LogMemberID以外，其他禁止插入，禁止更新（但不包含软删除，硬删除）
	[SerialNo] INT IDENTITY(1,1),	-- 流水号
	[UpdateTime] DATETIME, -- 更新时间
	[Default] BIT NOT NULL DEFAULT(0),	-- 默认
	[Del] BIT NOT NULL DEFAULT(0),	-- 软删除
	[Destroy] BIT NOT NULL DEFAULT(0),	-- 硬删除
	[CreateTime] DATETIME NOT NULL DEFAULT(GETDATE()),	-- 创建时间
	[LogMemberID] UNIQUEIDENTIFIER NOT NULL	-- 记录会员
)
GO
EXEC sp_addextendedproperty N'MS_Description', N'登录日志', N'user', N'dbo', N'table', N'HttpLog';
GO
EXEC sp_addextendedproperty N'MS_Description', N'ID', N'user', N'dbo', N'table', N'HttpLog', N'column', N'LogID';
EXEC sp_addextendedproperty N'MS_Description', N'来源地址', N'user', N'dbo', N'table', N'HttpLog', N'column', N'Referrer';
EXEC sp_addextendedproperty N'MS_Description', N'请求地址', N'user', N'dbo', N'table', N'HttpLog', N'column', N'Url';
EXEC sp_addextendedproperty N'MS_Description', N'传输数据', N'user', N'dbo', N'table', N'HttpLog', N'column', N'Data';
EXEC sp_addextendedproperty N'MS_Description', N'会员ID', N'user', N'dbo', N'table', N'HttpLog', N'column', N'MemberID';
EXEC sp_addextendedproperty N'MS_Description', N'IP地址', N'user', N'dbo', N'table', N'HttpLog', N'column', N'IPAddress';
EXEC sp_addextendedproperty N'MS_Description', N'IP详情', N'user', N'dbo', N'table', N'HttpLog', N'column', N'IPDetail';
EXEC sp_addextendedproperty N'MS_Description', N'HTTP方式', N'user', N'dbo', N'table', N'HttpLog', N'column', N'HttpMethod';
EXEC sp_addextendedproperty N'MS_Description', N'异步请求', N'user', N'dbo', N'table', N'HttpLog', N'column', N'AjaxRequest';
EXEC sp_addextendedproperty N'MS_Description', N'移动设备', N'user', N'dbo', N'table', N'HttpLog', N'column', N'MobileDevice';
EXEC sp_addextendedproperty N'MS_Description', N'操作系统', N'user', N'dbo', N'table', N'HttpLog', N'column', N'Platform';
EXEC sp_addextendedproperty N'MS_Description', N'浏览器', N'user', N'dbo', N'table', N'HttpLog', N'column', N'Browser';
EXEC sp_addextendedproperty N'MS_Description', N'流水号', N'user', N'dbo', N'table', N'HttpLog', N'column', N'SerialNo';
EXEC sp_addextendedproperty N'MS_Description', N'更新时间', N'user', N'dbo', N'table', N'HttpLog', N'column', N'UpdateTime';
EXEC sp_addextendedproperty N'MS_Description', N'默认', N'user', N'dbo', N'table', N'HttpLog', N'column', N'Default';
EXEC sp_addextendedproperty N'MS_Description', N'软删除', N'user', N'dbo', N'table', N'HttpLog', N'column', N'Del';
EXEC sp_addextendedproperty N'MS_Description', N'硬删除', N'user', N'dbo', N'table', N'HttpLog', N'column', N'Destroy';
EXEC sp_addextendedproperty N'MS_Description', N'创建时间', N'user', N'dbo', N'table', N'HttpLog', N'column', N'CreateTime';
EXEC sp_addextendedproperty N'MS_Description', N'记录会员', N'user', N'dbo', N'table', N'HttpLog', N'column', N'LogMemberID';
GO


-- 操作日志
IF(OBJECT_ID('dbo.[OperateLog]',N'U') IS NOT NULL)
	DROP TABLE dbo.[OperateLog]
GO
CREATE TABLE dbo.[OperateLog]
(
	[LogID] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,	-- ID
	[TableName] VARCHAR(100) NOT NULL,	-- 表名称
	[TableRemark] NVARCHAR(100) NOT NULL,	-- 表描述
	[HandleType] INT NOT NULL,	-- 操作类型
	[MemberID] UNIQUEIDENTIFIER,	-- 会员ID
	-- 以下为通用字段，除了UpdateTime，SerialNo，LogMemberID以外，其他禁止插入，禁止更新（但不包含软删除，硬删除）
	[SerialNo] INT IDENTITY(1,1),	-- 流水号
	[UpdateTime] DATETIME, -- 更新时间
	[Default] BIT NOT NULL DEFAULT(0),	-- 默认
	[Del] BIT NOT NULL DEFAULT(0),	-- 软删除
	[Destroy] BIT NOT NULL DEFAULT(0),	-- 硬删除
	[CreateTime] DATETIME NOT NULL DEFAULT(GETDATE()),	-- 创建时间
	[LogMemberID] UNIQUEIDENTIFIER NOT NULL	-- 记录会员
)
GO
EXEC sp_addextendedproperty N'MS_Description', N'操作日志', N'user', N'dbo', N'table', N'OperateLog';
GO
EXEC sp_addextendedproperty N'MS_Description', N'ID', N'user', N'dbo', N'table', N'OperateLog', N'column', N'LogID';
EXEC sp_addextendedproperty N'MS_Description', N'表名称', N'user', N'dbo', N'table', N'OperateLog', N'column', N'TableName';
EXEC sp_addextendedproperty N'MS_Description', N'表描述', N'user', N'dbo', N'table', N'OperateLog', N'column', N'TableRemark';
EXEC sp_addextendedproperty N'MS_Description', N'操作类型', N'user', N'dbo', N'table', N'OperateLog', N'column', N'HandleType';
EXEC sp_addextendedproperty N'MS_Description', N'会员ID', N'user', N'dbo', N'table', N'OperateLog', N'column', N'MemberID';
EXEC sp_addextendedproperty N'MS_Description', N'流水号', N'user', N'dbo', N'table', N'OperateLog', N'column', N'SerialNo';
EXEC sp_addextendedproperty N'MS_Description', N'更新时间', N'user', N'dbo', N'table', N'OperateLog', N'column', N'UpdateTime';
EXEC sp_addextendedproperty N'MS_Description', N'默认', N'user', N'dbo', N'table', N'OperateLog', N'column', N'Default';
EXEC sp_addextendedproperty N'MS_Description', N'软删除', N'user', N'dbo', N'table', N'OperateLog', N'column', N'Del';
EXEC sp_addextendedproperty N'MS_Description', N'硬删除', N'user', N'dbo', N'table', N'OperateLog', N'column', N'Destroy';
EXEC sp_addextendedproperty N'MS_Description', N'创建时间', N'user', N'dbo', N'table', N'OperateLog', N'column', N'CreateTime';
EXEC sp_addextendedproperty N'MS_Description', N'记录会员', N'user', N'dbo', N'table', N'OperateLog', N'column', N'LogMemberID';
GO


-- 操作明细
IF(OBJECT_ID('dbo.[OperateDetail]',N'U') IS NOT NULL)
	DROP TABLE dbo.[OperateDetail]
GO
CREATE TABLE dbo.[OperateDetail]
(
	[DetailID] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,	-- ID
	[LogID] UNIQUEIDENTIFIER NOT NULL,	-- 操作日志ID
	[ColumnName] VARCHAR(100) NOT NULL,	-- 字段名称
	[ColumnRemark] NVARCHAR(100) NOT NULL,	-- 字段描述
	[OldValue] TEXT NOT NULL,	-- 旧值
	[NewValue] TEXT NOT NULL,	-- 新值
	[MemberID] UNIQUEIDENTIFIER,	-- 会员ID
	-- 以下为通用字段，除了UpdateTime，SerialNo，LogMemberID以外，其他禁止插入，禁止更新（但不包含软删除，硬删除）
	[SerialNo] INT IDENTITY(1,1),	-- 流水号
	[UpdateTime] DATETIME, -- 更新时间
	[Default] BIT NOT NULL DEFAULT(0),	-- 默认
	[Del] BIT NOT NULL DEFAULT(0),	-- 软删除
	[Destroy] BIT NOT NULL DEFAULT(0),	-- 硬删除
	[CreateTime] DATETIME NOT NULL DEFAULT(GETDATE()),	-- 创建时间
	[LogMemberID] UNIQUEIDENTIFIER NOT NULL	-- 记录会员
)
GO
EXEC sp_addextendedproperty N'MS_Description', N'操作明细', N'user', N'dbo', N'table', N'OperateDetail';
GO
EXEC sp_addextendedproperty N'MS_Description', N'ID', N'user', N'dbo', N'table', N'OperateDetail', N'column', N'DetailID';
EXEC sp_addextendedproperty N'MS_Description', N'操作日志ID', N'user', N'dbo', N'table', N'OperateDetail', N'column', N'LogID';
EXEC sp_addextendedproperty N'MS_Description', N'字段名称', N'user', N'dbo', N'table', N'OperateDetail', N'column', N'ColumnName';
EXEC sp_addextendedproperty N'MS_Description', N'字段描述', N'user', N'dbo', N'table', N'OperateDetail', N'column', N'ColumnRemark';
EXEC sp_addextendedproperty N'MS_Description', N'旧值', N'user', N'dbo', N'table', N'OperateDetail', N'column', N'OldValue';
EXEC sp_addextendedproperty N'MS_Description', N'新值', N'user', N'dbo', N'table', N'OperateDetail', N'column', N'NewValue';
EXEC sp_addextendedproperty N'MS_Description', N'会员ID', N'user', N'dbo', N'table', N'OperateDetail', N'column', N'MemberID';
EXEC sp_addextendedproperty N'MS_Description', N'流水号', N'user', N'dbo', N'table', N'OperateDetail', N'column', N'SerialNo';
EXEC sp_addextendedproperty N'MS_Description', N'更新时间', N'user', N'dbo', N'table', N'OperateDetail', N'column', N'UpdateTime';
EXEC sp_addextendedproperty N'MS_Description', N'默认', N'user', N'dbo', N'table', N'OperateDetail', N'column', N'Default';
EXEC sp_addextendedproperty N'MS_Description', N'软删除', N'user', N'dbo', N'table', N'OperateDetail', N'column', N'Del';
EXEC sp_addextendedproperty N'MS_Description', N'硬删除', N'user', N'dbo', N'table', N'OperateDetail', N'column', N'Destroy';
EXEC sp_addextendedproperty N'MS_Description', N'创建时间', N'user', N'dbo', N'table', N'OperateDetail', N'column', N'CreateTime';
EXEC sp_addextendedproperty N'MS_Description', N'记录会员', N'user', N'dbo', N'table', N'OperateDetail', N'column', N'LogMemberID';
GO

-- 错误日志
IF(OBJECT_ID('dbo.[ErrorLog]',N'U') IS NOT NULL)
	DROP TABLE dbo.[ErrorLog]
GO
CREATE TABLE dbo.[ErrorLog]
(
	[LogID] UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,	-- ID
	[Message] TEXT,	-- 异常消息
	[Source] TEXT,-- 应用程序
	[TargetSite] TEXT,	-- 引起异常的方法
	[StackTrace] TEXT,	-- 异常堆栈信息
	[HResult] TEXT,	-- 异常编码数字
	[HelpLink] TEXT,	-- 异常帮助文档
	[LogTime] DATETIME NOT NULL,	-- 记录时间
	[Account] NVARCHAR(32) NOT NULL,	-- 账号
	[ErrorUrl] NVARCHAR(500),	-- 出错地址
	[View] BIT NOT NULL DEFAULT(0),	-- 查看状态
	-- 以下为通用字段，除了UpdateTime，SerialNo，LogMemberID以外，其他禁止插入，禁止更新（但不包含软删除，硬删除）
	[SerialNo] INT IDENTITY(1,1),	-- 流水号
	[UpdateTime] DATETIME, -- 更新时间
	[Default] BIT NOT NULL DEFAULT(0),	-- 默认
	[Del] BIT NOT NULL DEFAULT(0),	-- 软删除
	[Destroy] BIT NOT NULL DEFAULT(0),	-- 硬删除
	[CreateTime] DATETIME NOT NULL DEFAULT(GETDATE()),	-- 创建时间
	[LogMemberID] UNIQUEIDENTIFIER NOT NULL	-- 记录会员
)
GO
EXEC sp_addextendedproperty N'MS_Description', N'错误日志', N'user', N'dbo', N'table', N'ErrorLog';
GO
EXEC sp_addextendedproperty N'MS_Description', N'ID', N'user', N'dbo', N'table', N'ErrorLog', N'column', N'LogID';
EXEC sp_addextendedproperty N'MS_Description', N'异常消息', N'user', N'dbo', N'table', N'ErrorLog', N'column', N'Message';
EXEC sp_addextendedproperty N'MS_Description', N'应用程序', N'user', N'dbo', N'table', N'ErrorLog', N'column', N'Source';
EXEC sp_addextendedproperty N'MS_Description', N'引起异常的方法', N'user', N'dbo', N'table', N'ErrorLog', N'column', N'TargetSite';
EXEC sp_addextendedproperty N'MS_Description', N'异常堆栈信息', N'user', N'dbo', N'table', N'ErrorLog', N'column', N'StackTrace';
EXEC sp_addextendedproperty N'MS_Description', N'异常编码数字', N'user', N'dbo', N'table', N'ErrorLog', N'column', N'HResult';
EXEC sp_addextendedproperty N'MS_Description', N'异常帮助文档', N'user', N'dbo', N'table', N'ErrorLog', N'column', N'HelpLink';
EXEC sp_addextendedproperty N'MS_Description', N'记录时间', N'user', N'dbo', N'table', N'ErrorLog', N'column', N'LogTime';
EXEC sp_addextendedproperty N'MS_Description', N'账号', N'user', N'dbo', N'table', N'ErrorLog', N'column', N'Account';
EXEC sp_addextendedproperty N'MS_Description', N'出错地址', N'user', N'dbo', N'table', N'ErrorLog', N'column', N'ErrorUrl';
EXEC sp_addextendedproperty N'MS_Description', N'查看状态', N'user', N'dbo', N'table', N'ErrorLog', N'column', N'View';
EXEC sp_addextendedproperty N'MS_Description', N'流水号', N'user', N'dbo', N'table', N'ErrorLog', N'column', N'SerialNo';
EXEC sp_addextendedproperty N'MS_Description', N'更新时间', N'user', N'dbo', N'table', N'ErrorLog', N'column', N'UpdateTime';
EXEC sp_addextendedproperty N'MS_Description', N'默认', N'user', N'dbo', N'table', N'ErrorLog', N'column', N'Default';
EXEC sp_addextendedproperty N'MS_Description', N'软删除', N'user', N'dbo', N'table', N'ErrorLog', N'column', N'Del';
EXEC sp_addextendedproperty N'MS_Description', N'硬删除', N'user', N'dbo', N'table', N'ErrorLog', N'column', N'Destroy';
EXEC sp_addextendedproperty N'MS_Description', N'创建时间', N'user', N'dbo', N'table', N'ErrorLog', N'column', N'CreateTime';
EXEC sp_addextendedproperty N'MS_Description', N'记录会员', N'user', N'dbo', N'table', N'ErrorLog', N'column', N'LogMemberID';
GO


-- 字典类别
IF(OBJECT_ID('dbo.[DicType]',N'U') IS NOT NULL)
	DROP TABLE dbo.[DicType]
GO
CREATE TABLE dbo.[DicType]
(
	[TypeID] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,	-- ID
	[Name] NVARCHAR(32) NOT NULL,	-- 名称
	[Remark] NVARCHAR(200),	--描述
	-- 以下为通用字段，除了UpdateTime，SerialNo，LogMemberID以外，其他禁止插入，禁止更新（但不包含软删除，硬删除）
	[SerialNo] INT IDENTITY(1,1),	-- 流水号
	[UpdateTime] DATETIME, -- 更新时间
	[Default] BIT NOT NULL DEFAULT(0),	-- 默认
	[Del] BIT NOT NULL DEFAULT(0),	-- 软删除
	[Destroy] BIT NOT NULL DEFAULT(0),	-- 硬删除
	[CreateTime] DATETIME NOT NULL DEFAULT(GETDATE()),	-- 创建时间
	[LogMemberID] UNIQUEIDENTIFIER NOT NULL	-- 记录会员
)
GO
EXEC sp_addextendedproperty N'MS_Description', N'字典类别', N'user', N'dbo', N'table', N'DicType';
GO
EXEC sp_addextendedproperty N'MS_Description', N'ID', N'user', N'dbo', N'table', N'DicType', N'column', N'TypeID';
EXEC sp_addextendedproperty N'MS_Description', N'名称', N'user', N'dbo', N'table', N'DicType', N'column', N'Name';
EXEC sp_addextendedproperty N'MS_Description', N'描述', N'user', N'dbo', N'table', N'DicType', N'column', N'Remark';
EXEC sp_addextendedproperty N'MS_Description', N'流水号', N'user', N'dbo', N'table', N'DicType', N'column', N'SerialNo';
EXEC sp_addextendedproperty N'MS_Description', N'更新时间', N'user', N'dbo', N'table', N'DicType', N'column', N'UpdateTime';
EXEC sp_addextendedproperty N'MS_Description', N'默认', N'user', N'dbo', N'table', N'DicType', N'column', N'Default';
EXEC sp_addextendedproperty N'MS_Description', N'软删除', N'user', N'dbo', N'table', N'DicType', N'column', N'Del';
EXEC sp_addextendedproperty N'MS_Description', N'硬删除', N'user', N'dbo', N'table', N'DicType', N'column', N'Destroy';
EXEC sp_addextendedproperty N'MS_Description', N'创建时间', N'user', N'dbo', N'table', N'DicType', N'column', N'CreateTime';
EXEC sp_addextendedproperty N'MS_Description', N'记录会员', N'user', N'dbo', N'table', N'DicType', N'column', N'LogMemberID';
GO


-- 字典数据
IF(OBJECT_ID('dbo.[DicData]',N'U') IS NOT NULL)
	DROP TABLE dbo.[DicData]
GO
CREATE TABLE dbo.[DicData]
(
	[DicID] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,	-- ID
	[Name] NVARCHAR(32) NOT NULL,	-- 名称
	[Content] TEXT NOT NULL,	--内容
	[ParentID] UNIQUEIDENTIFIER,	-- 上级ID
	[Sort] INT NOT NULL DEFAULT(0),	-- 排序
	[TypeID] UNIQUEIDENTIFIER NOT NULL,	-- 字典类别ID
	[Enable] BIT DEFAULT(1) NOT NULL,	-- 启用
	-- 以下为通用字段，除了UpdateTime，SerialNo，LogMemberID以外，其他禁止插入，禁止更新（但不包含软删除，硬删除）
	[SerialNo] INT IDENTITY(1,1),	-- 流水号
	[UpdateTime] DATETIME, -- 更新时间
	[Default] BIT NOT NULL DEFAULT(0),	-- 默认
	[Del] BIT NOT NULL DEFAULT(0),	-- 软删除
	[Destroy] BIT NOT NULL DEFAULT(0),	-- 硬删除
	[CreateTime] DATETIME NOT NULL DEFAULT(GETDATE()),	-- 创建时间
	[LogMemberID] UNIQUEIDENTIFIER NOT NULL	-- 记录会员
)
GO
EXEC sp_addextendedproperty N'MS_Description', N'字典数据', N'user', N'dbo', N'table', N'DicData';
GO
EXEC sp_addextendedproperty N'MS_Description', N'ID', N'user', N'dbo', N'table', N'DicData', N'column', N'DicID';
EXEC sp_addextendedproperty N'MS_Description', N'名称', N'user', N'dbo', N'table', N'DicData', N'column', N'Name';
EXEC sp_addextendedproperty N'MS_Description', N'内容', N'user', N'dbo', N'table', N'DicData', N'column', N'Content';
EXEC sp_addextendedproperty N'MS_Description', N'上级ID', N'user', N'dbo', N'table', N'DicData', N'column', N'ParentID';
EXEC sp_addextendedproperty N'MS_Description', N'排序', N'user', N'dbo', N'table', N'DicData', N'column', N'Sort';
EXEC sp_addextendedproperty N'MS_Description', N'字典类别ID', N'user', N'dbo', N'table', N'DicData', N'column', N'TypeID';
EXEC sp_addextendedproperty N'MS_Description', N'启用', N'user', N'dbo', N'table', N'DicData', N'column', N'Enable';
EXEC sp_addextendedproperty N'MS_Description', N'流水号', N'user', N'dbo', N'table', N'DicData', N'column', N'SerialNo';
EXEC sp_addextendedproperty N'MS_Description', N'更新时间', N'user', N'dbo', N'table', N'DicData', N'column', N'UpdateTime';
EXEC sp_addextendedproperty N'MS_Description', N'默认', N'user', N'dbo', N'table', N'DicData', N'column', N'Default';
EXEC sp_addextendedproperty N'MS_Description', N'软删除', N'user', N'dbo', N'table', N'DicData', N'column', N'Del';
EXEC sp_addextendedproperty N'MS_Description', N'硬删除', N'user', N'dbo', N'table', N'DicData', N'column', N'Destroy';
EXEC sp_addextendedproperty N'MS_Description', N'创建时间', N'user', N'dbo', N'table', N'DicData', N'column', N'CreateTime';
EXEC sp_addextendedproperty N'MS_Description', N'记录会员', N'user', N'dbo', N'table', N'DicData', N'column', N'LogMemberID';
GO


-- 系统配置
IF(OBJECT_ID('dbo.[SysSet]',N'U') IS NOT NULL)
	DROP TABLE dbo.[SysSet]
GO
CREATE TABLE dbo.[SysSet]
(
	[SetID] UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,	-- ID
	[Logo] NVARCHAR(200),	-- LOGO
	[Name] NVARCHAR(100) NOT NULL,	-- 名称
	[Version] NVARCHAR(50) NOT NULL,	-- 版本
	[Keywords] NVARCHAR(200) DEFAULT('Monk.Soul,百签软件,百小僧,baisoft,baisoft.org'),	-- 关键字
	[Description] NVARCHAR(320),	-- 描述
	[Support] NVARCHAR(100) NOT NULL DEFAULT('百签软件（中山）有限公司'),	-- 技术支持
	[Copyright] NVARCHAR(200) NOT NULL DEFAULT('Copyright ©  2016 百签软件（中山）有限公司. All rights reserved.'),	-- 版权所有
	[Site] NVARCHAR(200),	-- 网址
	[PageSize] INT NOT NULL DEFAULT(15),	-- 页容量
	[ImageMaxSize] INT NOT NULL DEFAULT(2),	-- 图片最大上传大小
	[VideoMaxSize] INT NOT NULL DEFAULT(5),	-- 视频最大上传大小
	[AttachMaxSize] INT NOT NULL DEFAULT(10),	-- 附件最大上传大小
	-- 以下为通用字段，除了UpdateTime，SerialNo，LogMemberID以外，其他禁止插入，禁止更新（但不包含软删除，硬删除）
	[SerialNo] INT IDENTITY(1,1),	-- 流水号
	[UpdateTime] DATETIME, -- 更新时间
	[Default] BIT NOT NULL DEFAULT(0),	-- 默认
	[Del] BIT NOT NULL DEFAULT(0),	-- 软删除
	[Destroy] BIT NOT NULL DEFAULT(0),	-- 硬删除
	[CreateTime] DATETIME NOT NULL DEFAULT(GETDATE()),	-- 创建时间
	[LogMemberID] UNIQUEIDENTIFIER NOT NULL	-- 记录会员
)
GO
EXEC sp_addextendedproperty N'MS_Description', N'系统配置', N'user', N'dbo', N'table', N'SysSet';
GO
EXEC sp_addextendedproperty N'MS_Description', N'ID', N'user', N'dbo', N'table', N'SysSet', N'column', N'SetID';
EXEC sp_addextendedproperty N'MS_Description', N'LOGO', N'user', N'dbo', N'table', N'SysSet', N'column', N'Logo';
EXEC sp_addextendedproperty N'MS_Description', N'名称', N'user', N'dbo', N'table', N'SysSet', N'column', N'Name';
EXEC sp_addextendedproperty N'MS_Description', N'版本', N'user', N'dbo', N'table', N'SysSet', N'column', N'Version';
EXEC sp_addextendedproperty N'MS_Description', N'关键字', N'user', N'dbo', N'table', N'SysSet', N'column', N'Keywords';
EXEC sp_addextendedproperty N'MS_Description', N'描述', N'user', N'dbo', N'table', N'SysSet', N'column', N'Description';
EXEC sp_addextendedproperty N'MS_Description', N'技术支持', N'user', N'dbo', N'table', N'SysSet', N'column', N'Support';
EXEC sp_addextendedproperty N'MS_Description', N'版权所有', N'user', N'dbo', N'table', N'SysSet', N'column', N'Copyright';
EXEC sp_addextendedproperty N'MS_Description', N'网址', N'user', N'dbo', N'table', N'SysSet', N'column', N'Site';
EXEC sp_addextendedproperty N'MS_Description', N'页容量', N'user', N'dbo', N'table', N'SysSet', N'column', N'PageSize';
EXEC sp_addextendedproperty N'MS_Description', N'图片最大上传大小', N'user', N'dbo', N'table', N'SysSet', N'column', N'ImageMaxSize';
EXEC sp_addextendedproperty N'MS_Description', N'视频最大上传大小', N'user', N'dbo', N'table', N'SysSet', N'column', N'VideoMaxSize';
EXEC sp_addextendedproperty N'MS_Description', N'附件最大上传大小', N'user', N'dbo', N'table', N'SysSet', N'column', N'AttachMaxSize';
EXEC sp_addextendedproperty N'MS_Description', N'流水号', N'user', N'dbo', N'table', N'SysSet', N'column', N'SerialNo';
EXEC sp_addextendedproperty N'MS_Description', N'更新时间', N'user', N'dbo', N'table', N'SysSet', N'column', N'UpdateTime';
EXEC sp_addextendedproperty N'MS_Description', N'默认', N'user', N'dbo', N'table', N'SysSet', N'column', N'Default';
EXEC sp_addextendedproperty N'MS_Description', N'软删除', N'user', N'dbo', N'table', N'SysSet', N'column', N'Del';
EXEC sp_addextendedproperty N'MS_Description', N'硬删除', N'user', N'dbo', N'table', N'SysSet', N'column', N'Destroy';
EXEC sp_addextendedproperty N'MS_Description', N'创建时间', N'user', N'dbo', N'table', N'SysSet', N'column', N'CreateTime';
EXEC sp_addextendedproperty N'MS_Description', N'记录会员', N'user', N'dbo', N'table', N'SysSet', N'column', N'LogMemberID';
GO

-- 模块
IF(OBJECT_ID('dbo.[Module]',N'U') IS NOT NULL)
	DROP TABLE dbo.[Module]
GO
CREATE TABLE dbo.[Module]
(
	[ModuleID] UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,	-- ID
	[Name] NVARCHAR(32) NOT NULL,	-- 名称
	[Remark] NVARCHAR(200),	-- 描述
	[Sort] INT NOT NULL DEFAULT(0),	-- 排序
	[TagAttr] NVARCHAR(200),	-- 标签属性
	[ParentID] UNIQUEIDENTIFIER NOT NULL,	-- 上级ID
	[Iconfont] NVARCHAR(100) NOT NULL,	-- 字体图标
	[Enable] BIT DEFAULT(1) NOT NULL,	-- 启用
	-- 以下为通用字段，除了UpdateTime，SerialNo，LogMemberID以外，其他禁止插入，禁止更新（但不包含软删除，硬删除）
	[SerialNo] INT IDENTITY(1,1),	-- 流水号
	[UpdateTime] DATETIME, -- 更新时间
	[Default] BIT NOT NULL DEFAULT(0),	-- 默认
	[Del] BIT NOT NULL DEFAULT(0),	-- 软删除
	[Destroy] BIT NOT NULL DEFAULT(0),	-- 硬删除
	[CreateTime] DATETIME NOT NULL DEFAULT(GETDATE()),	-- 创建时间
	[LogMemberID] UNIQUEIDENTIFIER NOT NULL	-- 记录会员
)
GO
EXEC sp_addextendedproperty N'MS_Description', N'模块', N'user', N'dbo', N'table', N'Module';
GO
EXEC sp_addextendedproperty N'MS_Description', N'ID', N'user', N'dbo', N'table', N'Module', N'column', N'ModuleID';
EXEC sp_addextendedproperty N'MS_Description', N'名称', N'user', N'dbo', N'table', N'Module', N'column', N'Name';
EXEC sp_addextendedproperty N'MS_Description', N'描述', N'user', N'dbo', N'table', N'Module', N'column', N'Remark';
EXEC sp_addextendedproperty N'MS_Description', N'排序', N'user', N'dbo', N'table', N'Module', N'column', N'Sort';
EXEC sp_addextendedproperty N'MS_Description', N'标签属性', N'user', N'dbo', N'table', N'Module', N'column', N'TagAttr';
EXEC sp_addextendedproperty N'MS_Description', N'上级ID', N'user', N'dbo', N'table', N'Module', N'column', N'ParentID';
EXEC sp_addextendedproperty N'MS_Description', N'字体图标', N'user', N'dbo', N'table', N'Module', N'column', N'Iconfont';
EXEC sp_addextendedproperty N'MS_Description', N'启用', N'user', N'dbo', N'table', N'Module', N'column', N'Enable';
EXEC sp_addextendedproperty N'MS_Description', N'流水号', N'user', N'dbo', N'table', N'Module', N'column', N'SerialNo';
EXEC sp_addextendedproperty N'MS_Description', N'更新时间', N'user', N'dbo', N'table', N'Module', N'column', N'UpdateTime';
EXEC sp_addextendedproperty N'MS_Description', N'默认', N'user', N'dbo', N'table', N'Module', N'column', N'Default';
EXEC sp_addextendedproperty N'MS_Description', N'软删除', N'user', N'dbo', N'table', N'Module', N'column', N'Del';
EXEC sp_addextendedproperty N'MS_Description', N'硬删除', N'user', N'dbo', N'table', N'Module', N'column', N'Destroy';
EXEC sp_addextendedproperty N'MS_Description', N'创建时间', N'user', N'dbo', N'table', N'Module', N'column', N'CreateTime';
EXEC sp_addextendedproperty N'MS_Description', N'记录会员', N'user', N'dbo', N'table', N'Module', N'column', N'LogMemberID';
GO


-- 行为
IF(OBJECT_ID('dbo.[Havior]',N'U') IS NOT NULL)
	DROP TABLE dbo.[Havior]
GO
CREATE TABLE dbo.[Havior]
(
	[HaviorID] UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,	-- ID
	[Name] NVARCHAR(32) NOT NULL,	-- 名称
	[Remark] NVARCHAR(200),	-- 描述
	[Route] BIT DEFAULT(1) NOT NULL,	-- 路由
	[Url] NVARCHAR(300),	-- 请求地址
	[Area] VARCHAR(50),	-- 区域
	[Controller] VARCHAR(50),	-- 控制器
	[Action] VARCHAR(50),	-- 功能
	[Parameter] VARCHAR(200),	-- 路由参数
	[HttpMethod] VARCHAR(20) NOT NULL DEFAULT('GET'),	-- HTTP方式
	[HeadCode] TEXT,	-- 页头代码
	[FootCode] TEXT,	-- 页脚代码
	[Layout] VARCHAR(100),	-- 布局地址
	[ModuleID] UNIQUEIDENTIFIER NOT NULL,	-- 模块ID
	[Index] BIT NOT NULL DEFAULT(0),	-- 首页
	[Enable] BIT DEFAULT(1) NOT NULL,	-- 启用
	-- 以下为通用字段，除了UpdateTime，SerialNo，LogMemberID以外，其他禁止插入，禁止更新（但不包含软删除，硬删除）
	[SerialNo] INT IDENTITY(1,1),	-- 流水号
	[UpdateTime] DATETIME, -- 更新时间
	[Default] BIT NOT NULL DEFAULT(0),	-- 默认
	[Del] BIT NOT NULL DEFAULT(0),	-- 软删除
	[Destroy] BIT NOT NULL DEFAULT(0),	-- 硬删除
	[CreateTime] DATETIME NOT NULL DEFAULT(GETDATE()),	-- 创建时间
	[LogMemberID] UNIQUEIDENTIFIER NOT NULL	-- 记录会员
)
GO
EXEC sp_addextendedproperty N'MS_Description', N'行为', N'user', N'dbo', N'table', N'Havior';
GO
EXEC sp_addextendedproperty N'MS_Description', N'ID', N'user', N'dbo', N'table', N'Havior', N'column', N'HaviorID';
EXEC sp_addextendedproperty N'MS_Description', N'名称', N'user', N'dbo', N'table', N'Havior', N'column', N'Name';
EXEC sp_addextendedproperty N'MS_Description', N'关键字', N'user', N'dbo', N'table', N'Havior', N'column', N'Remark';
EXEC sp_addextendedproperty N'MS_Description', N'路由', N'user', N'dbo', N'table', N'Havior', N'column', N'Route';
EXEC sp_addextendedproperty N'MS_Description', N'请求地址', N'user', N'dbo', N'table', N'Havior', N'column', N'Url';
EXEC sp_addextendedproperty N'MS_Description', N'区域', N'user', N'dbo', N'table', N'Havior', N'column', N'Area';
EXEC sp_addextendedproperty N'MS_Description', N'控制器', N'user', N'dbo', N'table', N'Havior', N'column', N'Controller';
EXEC sp_addextendedproperty N'MS_Description', N'功能', N'user', N'dbo', N'table', N'Havior', N'column', N'Action';
EXEC sp_addextendedproperty N'MS_Description', N'路由参数', N'user', N'dbo', N'table', N'Havior', N'column', N'Parameter';
EXEC sp_addextendedproperty N'MS_Description', N'HTTP方式', N'user', N'dbo', N'table', N'Havior', N'column', N'HttpMethod';
EXEC sp_addextendedproperty N'MS_Description', N'页头代码', N'user', N'dbo', N'table', N'Havior', N'column', N'HeadCode';
EXEC sp_addextendedproperty N'MS_Description', N'页脚代码', N'user', N'dbo', N'table', N'Havior', N'column', N'FootCode';
EXEC sp_addextendedproperty N'MS_Description', N'布局地址', N'user', N'dbo', N'table', N'Havior', N'column', N'Layout';
EXEC sp_addextendedproperty N'MS_Description', N'模块ID', N'user', N'dbo', N'table', N'Havior', N'column', N'ModuleID';
EXEC sp_addextendedproperty N'MS_Description', N'首页', N'user', N'dbo', N'table', N'Havior', N'column', N'Index';
EXEC sp_addextendedproperty N'MS_Description', N'启用', N'user', N'dbo', N'table', N'Havior', N'column', N'Enable';
EXEC sp_addextendedproperty N'MS_Description', N'流水号', N'user', N'dbo', N'table', N'Havior', N'column', N'SerialNo';
EXEC sp_addextendedproperty N'MS_Description', N'更新时间', N'user', N'dbo', N'table', N'Havior', N'column', N'UpdateTime';
EXEC sp_addextendedproperty N'MS_Description', N'默认', N'user', N'dbo', N'table', N'Havior', N'column', N'Default';
EXEC sp_addextendedproperty N'MS_Description', N'软删除', N'user', N'dbo', N'table', N'Havior', N'column', N'Del';
EXEC sp_addextendedproperty N'MS_Description', N'硬删除', N'user', N'dbo', N'table', N'Havior', N'column', N'Destroy';
EXEC sp_addextendedproperty N'MS_Description', N'创建时间', N'user', N'dbo', N'table', N'Havior', N'column', N'CreateTime';
EXEC sp_addextendedproperty N'MS_Description', N'记录会员', N'user', N'dbo', N'table', N'Havior', N'column', N'LogMemberID';
GO


-- 按钮
IF(OBJECT_ID('dbo.[Button]',N'U') IS NOT NULL)
	DROP TABLE dbo.[Button]
GO
CREATE TABLE dbo.[Button]
(
	[ButtonID] UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,	-- ID
	[Name] NVARCHAR(32) NOT NULL,	-- 名称
	[Remark] NVARCHAR(200),	-- 描述
	[Sort] INT NOT NULL DEFAULT(0),	-- 排序
	[Event] VARCHAR(30) NOT NULL DEFAULT('onclick'),	-- 事件
	[Invoke] VARCHAR(50) NOT NULL,	-- 调用
	[Handle] TEXT NOT NULL DEFAULT(''),	-- 处理
	[TagAttr] NVARCHAR(200),	-- 标签属性
	[Iconfont] NVARCHAR(100) NOT NULL,	-- 字体图标
	[HaviorID] UNIQUEIDENTIFIER NOT NULL,	-- 行为ID
	[Enable] BIT DEFAULT(1) NOT NULL,	-- 启用
	-- 以下为通用字段，除了UpdateTime，SerialNo，LogMemberID以外，其他禁止插入，禁止更新（但不包含软删除，硬删除）
	[SerialNo] INT IDENTITY(1,1),	-- 流水号
	[UpdateTime] DATETIME, -- 更新时间
	[Default] BIT NOT NULL DEFAULT(0),	-- 默认
	[Del] BIT NOT NULL DEFAULT(0),	-- 软删除
	[Destroy] BIT NOT NULL DEFAULT(0),	-- 硬删除
	[CreateTime] DATETIME NOT NULL DEFAULT(GETDATE()),	-- 创建时间
	[LogMemberID] UNIQUEIDENTIFIER NOT NULL	-- 记录会员
)
GO
EXEC sp_addextendedproperty N'MS_Description', N'按钮', N'user', N'dbo', N'table', N'Button';
GO
EXEC sp_addextendedproperty N'MS_Description', N'ID', N'user', N'dbo', N'table', N'Button', N'column', N'ButtonID';
EXEC sp_addextendedproperty N'MS_Description', N'名称', N'user', N'dbo', N'table', N'Button', N'column', N'Name';
EXEC sp_addextendedproperty N'MS_Description', N'描述', N'user', N'dbo', N'table', N'Button', N'column', N'Remark';
EXEC sp_addextendedproperty N'MS_Description', N'排序', N'user', N'dbo', N'table', N'Button', N'column', N'Sort';
EXEC sp_addextendedproperty N'MS_Description', N'事件', N'user', N'dbo', N'table', N'Button', N'column', N'Event';
EXEC sp_addextendedproperty N'MS_Description', N'调用', N'user', N'dbo', N'table', N'Button', N'column', N'Invoke';
EXEC sp_addextendedproperty N'MS_Description', N'处理', N'user', N'dbo', N'table', N'Button', N'column', N'Handle';
EXEC sp_addextendedproperty N'MS_Description', N'标签属性', N'user', N'dbo', N'table', N'Button', N'column', N'TagAttr';
EXEC sp_addextendedproperty N'MS_Description', N'字体图标', N'user', N'dbo', N'table', N'Button', N'column', N'Iconfont';
EXEC sp_addextendedproperty N'MS_Description', N'行为ID', N'user', N'dbo', N'table', N'Button', N'column', N'HaviorID';
EXEC sp_addextendedproperty N'MS_Description', N'启用', N'user', N'dbo', N'table', N'Button', N'column', N'Enable';
EXEC sp_addextendedproperty N'MS_Description', N'流水号', N'user', N'dbo', N'table', N'Button', N'column', N'SerialNo';
EXEC sp_addextendedproperty N'MS_Description', N'更新时间', N'user', N'dbo', N'table', N'Button', N'column', N'UpdateTime';
EXEC sp_addextendedproperty N'MS_Description', N'默认', N'user', N'dbo', N'table', N'Button', N'column', N'Default';
EXEC sp_addextendedproperty N'MS_Description', N'软删除', N'user', N'dbo', N'table', N'Button', N'column', N'Del';
EXEC sp_addextendedproperty N'MS_Description', N'硬删除', N'user', N'dbo', N'table', N'Button', N'column', N'Destroy';
EXEC sp_addextendedproperty N'MS_Description', N'创建时间', N'user', N'dbo', N'table', N'Button', N'column', N'CreateTime';
EXEC sp_addextendedproperty N'MS_Description', N'记录会员', N'user', N'dbo', N'table', N'Button', N'column', N'LogMemberID';
GO


-- 会员与模块关系
IF(OBJECT_ID('dbo.[Member_Module]',N'U') IS NOT NULL)
	DROP TABLE dbo.[Member_Module]
GO
CREATE TABLE dbo.[Member_Module]
(
	[MemberID] UNIQUEIDENTIFIER NOT NULL,	-- 会员ID
	[ModuleID] UNIQUEIDENTIFIER NOT NULL,	-- 模块ID
	-- 以下为通用字段，除了UpdateTime，SerialNo，LogMemberID以外，其他禁止插入，禁止更新（但不包含软删除，硬删除）
	[SerialNo] INT IDENTITY(1,1) PRIMARY KEY,	-- 流水号
	[UpdateTime] DATETIME, -- 更新时间
	[Default] BIT NOT NULL DEFAULT(0),	-- 默认
	[Del] BIT NOT NULL DEFAULT(0),	-- 软删除
	[Destroy] BIT NOT NULL DEFAULT(0),	-- 硬删除
	[CreateTime] DATETIME NOT NULL DEFAULT(GETDATE()),	-- 创建时间
	[LogMemberID] UNIQUEIDENTIFIER NOT NULL	-- 记录会员
)
GO
EXEC sp_addextendedproperty N'MS_Description', N'会员与模块关系', N'user', N'dbo', N'table', N'Member_Module';
GO
EXEC sp_addextendedproperty N'MS_Description', N'会员ID', N'user', N'dbo', N'table', N'Member_Module', N'column', N'MemberID';
EXEC sp_addextendedproperty N'MS_Description', N'模块ID', N'user', N'dbo', N'table', N'Member_Module', N'column', N'ModuleID';
EXEC sp_addextendedproperty N'MS_Description', N'流水号', N'user', N'dbo', N'table', N'Member_Module', N'column', N'SerialNo';
EXEC sp_addextendedproperty N'MS_Description', N'更新时间', N'user', N'dbo', N'table', N'Member_Module', N'column', N'UpdateTime';
EXEC sp_addextendedproperty N'MS_Description', N'默认', N'user', N'dbo', N'table', N'Member_Module', N'column', N'Default';
EXEC sp_addextendedproperty N'MS_Description', N'软删除', N'user', N'dbo', N'table', N'Member_Module', N'column', N'Del';
EXEC sp_addextendedproperty N'MS_Description', N'硬删除', N'user', N'dbo', N'table', N'Member_Module', N'column', N'Destroy';
EXEC sp_addextendedproperty N'MS_Description', N'创建时间', N'user', N'dbo', N'table', N'Member_Module', N'column', N'CreateTime';
EXEC sp_addextendedproperty N'MS_Description', N'记录会员', N'user', N'dbo', N'table', N'Member_Module', N'column', N'LogMemberID';
GO


-- 会员组与模块关系
IF(OBJECT_ID('dbo.[Group_Module]',N'U') IS NOT NULL)
	DROP TABLE dbo.[Group_Module]
GO
CREATE TABLE dbo.[Group_Module]
(
	[GroupID] UNIQUEIDENTIFIER NOT NULL,	-- 会员组ID
	[ModuleID] UNIQUEIDENTIFIER NOT NULL,	-- 模块ID
	-- 以下为通用字段，除了UpdateTime，SerialNo，LogMemberID以外，其他禁止插入，禁止更新（但不包含软删除，硬删除）
	[SerialNo] INT IDENTITY(1,1) PRIMARY KEY,	-- 流水号
	[UpdateTime] DATETIME, -- 更新时间
	[Default] BIT NOT NULL DEFAULT(0),	-- 默认
	[Del] BIT NOT NULL DEFAULT(0),	-- 软删除
	[Destroy] BIT NOT NULL DEFAULT(0),	-- 硬删除
	[CreateTime] DATETIME NOT NULL DEFAULT(GETDATE()),	-- 创建时间
	[LogMemberID] UNIQUEIDENTIFIER NOT NULL	-- 记录会员
)
GO
EXEC sp_addextendedproperty N'MS_Description', N'会员组与模块关系', N'user', N'dbo', N'table', N'Group_Module';
GO
EXEC sp_addextendedproperty N'MS_Description', N'会员组ID', N'user', N'dbo', N'table', N'Group_Module', N'column', N'GroupID';
EXEC sp_addextendedproperty N'MS_Description', N'模块ID', N'user', N'dbo', N'table', N'Group_Module', N'column', N'ModuleID';
EXEC sp_addextendedproperty N'MS_Description', N'流水号', N'user', N'dbo', N'table', N'Group_Module', N'column', N'SerialNo';
EXEC sp_addextendedproperty N'MS_Description', N'更新时间', N'user', N'dbo', N'table', N'Group_Module', N'column', N'UpdateTime';
EXEC sp_addextendedproperty N'MS_Description', N'默认', N'user', N'dbo', N'table', N'Group_Module', N'column', N'Default';
EXEC sp_addextendedproperty N'MS_Description', N'软删除', N'user', N'dbo', N'table', N'Group_Module', N'column', N'Del';
EXEC sp_addextendedproperty N'MS_Description', N'硬删除', N'user', N'dbo', N'table', N'Group_Module', N'column', N'Destroy';
EXEC sp_addextendedproperty N'MS_Description', N'创建时间', N'user', N'dbo', N'table', N'Group_Module', N'column', N'CreateTime';
EXEC sp_addextendedproperty N'MS_Description', N'记录会员', N'user', N'dbo', N'table', N'Group_Module', N'column', N'LogMemberID';
GO


-- 角色与模块关系
IF(OBJECT_ID('dbo.[Role_Module]',N'U') IS NOT NULL)
	DROP TABLE dbo.[Role_Module]
GO
CREATE TABLE dbo.[Role_Module]
(
	[RoleID] UNIQUEIDENTIFIER NOT NULL,	-- 角色ID
	[ModuleID] UNIQUEIDENTIFIER NOT NULL,	-- 模块ID
	-- 以下为通用字段，除了UpdateTime，SerialNo，LogMemberID以外，其他禁止插入，禁止更新（但不包含软删除，硬删除）
	[SerialNo] INT IDENTITY(1,1) PRIMARY KEY,	-- 流水号
	[UpdateTime] DATETIME, -- 更新时间
	[Default] BIT NOT NULL DEFAULT(0),	-- 默认
	[Del] BIT NOT NULL DEFAULT(0),	-- 软删除
	[Destroy] BIT NOT NULL DEFAULT(0),	-- 硬删除
	[CreateTime] DATETIME NOT NULL DEFAULT(GETDATE()),	-- 创建时间
	[LogMemberID] UNIQUEIDENTIFIER NOT NULL	-- 记录会员
)
GO
EXEC sp_addextendedproperty N'MS_Description', N'角色与模块关系', N'user', N'dbo', N'table', N'Role_Module';
GO
EXEC sp_addextendedproperty N'MS_Description', N'角色ID', N'user', N'dbo', N'table', N'Role_Module', N'column', N'RoleID';
EXEC sp_addextendedproperty N'MS_Description', N'模块ID', N'user', N'dbo', N'table', N'Role_Module', N'column', N'ModuleID';
EXEC sp_addextendedproperty N'MS_Description', N'流水号', N'user', N'dbo', N'table', N'Role_Module', N'column', N'SerialNo';
EXEC sp_addextendedproperty N'MS_Description', N'更新时间', N'user', N'dbo', N'table', N'Role_Module', N'column', N'UpdateTime';
EXEC sp_addextendedproperty N'MS_Description', N'默认', N'user', N'dbo', N'table', N'Role_Module', N'column', N'Default';
EXEC sp_addextendedproperty N'MS_Description', N'软删除', N'user', N'dbo', N'table', N'Role_Module', N'column', N'Del';
EXEC sp_addextendedproperty N'MS_Description', N'硬删除', N'user', N'dbo', N'table', N'Role_Module', N'column', N'Destroy';
EXEC sp_addextendedproperty N'MS_Description', N'创建时间', N'user', N'dbo', N'table', N'Role_Module', N'column', N'CreateTime';
EXEC sp_addextendedproperty N'MS_Description', N'记录会员', N'user', N'dbo', N'table', N'Role_Module', N'column', N'LogMemberID';
GO


-- 会员与行为关系
IF(OBJECT_ID('dbo.[Member_Havior]',N'U') IS NOT NULL)
	DROP TABLE dbo.[Member_Havior]
GO
CREATE TABLE dbo.[Member_Havior]
(
	[MemberID] UNIQUEIDENTIFIER NOT NULL,	-- 会员ID
	[HaviorID] UNIQUEIDENTIFIER NOT NULL,	-- 行为ID
	-- 以下为通用字段，除了UpdateTime，SerialNo，LogMemberID以外，其他禁止插入，禁止更新（但不包含软删除，硬删除）
	[SerialNo] INT IDENTITY(1,1) PRIMARY KEY,	-- 流水号
	[UpdateTime] DATETIME, -- 更新时间
	[Default] BIT NOT NULL DEFAULT(0),	-- 默认
	[Del] BIT NOT NULL DEFAULT(0),	-- 软删除
	[Destroy] BIT NOT NULL DEFAULT(0),	-- 硬删除
	[CreateTime] DATETIME NOT NULL DEFAULT(GETDATE()),	-- 创建时间
	[LogMemberID] UNIQUEIDENTIFIER NOT NULL	-- 记录会员
)
GO
EXEC sp_addextendedproperty N'MS_Description', N'会员与行为关系', N'user', N'dbo', N'table', N'Member_Havior';
GO
EXEC sp_addextendedproperty N'MS_Description', N'会员ID', N'user', N'dbo', N'table', N'Member_Havior', N'column', N'MemberID';
EXEC sp_addextendedproperty N'MS_Description', N'行为ID', N'user', N'dbo', N'table', N'Member_Havior', N'column', N'HaviorID';
EXEC sp_addextendedproperty N'MS_Description', N'流水号', N'user', N'dbo', N'table', N'Member_Havior', N'column', N'SerialNo';
EXEC sp_addextendedproperty N'MS_Description', N'更新时间', N'user', N'dbo', N'table', N'Member_Havior', N'column', N'UpdateTime';
EXEC sp_addextendedproperty N'MS_Description', N'默认', N'user', N'dbo', N'table', N'Member_Havior', N'column', N'Default';
EXEC sp_addextendedproperty N'MS_Description', N'软删除', N'user', N'dbo', N'table', N'Member_Havior', N'column', N'Del';
EXEC sp_addextendedproperty N'MS_Description', N'硬删除', N'user', N'dbo', N'table', N'Member_Havior', N'column', N'Destroy';
EXEC sp_addextendedproperty N'MS_Description', N'创建时间', N'user', N'dbo', N'table', N'Member_Havior', N'column', N'CreateTime';
EXEC sp_addextendedproperty N'MS_Description', N'记录会员', N'user', N'dbo', N'table', N'Member_Havior', N'column', N'LogMemberID';
GO


-- 会员组与行为关系
IF(OBJECT_ID('dbo.[Group_Havior]',N'U') IS NOT NULL)
	DROP TABLE dbo.[Group_Havior]
GO
CREATE TABLE dbo.[Group_Havior]
(
	[GroupID] UNIQUEIDENTIFIER NOT NULL,	-- 会员组ID
	[HaviorID] UNIQUEIDENTIFIER NOT NULL,	-- 行为ID
	-- 以下为通用字段，除了UpdateTime，SerialNo，LogMemberID以外，其他禁止插入，禁止更新（但不包含软删除，硬删除）
	[SerialNo] INT IDENTITY(1,1) PRIMARY KEY,	-- 流水号
	[UpdateTime] DATETIME, -- 更新时间
	[Default] BIT NOT NULL DEFAULT(0),	-- 默认
	[Del] BIT NOT NULL DEFAULT(0),	-- 软删除
	[Destroy] BIT NOT NULL DEFAULT(0),	-- 硬删除
	[CreateTime] DATETIME NOT NULL DEFAULT(GETDATE()),	-- 创建时间
	[LogMemberID] UNIQUEIDENTIFIER NOT NULL	-- 记录会员
)
GO
EXEC sp_addextendedproperty N'MS_Description', N'会员组与行为关系', N'user', N'dbo', N'table', N'Group_Havior';
GO
EXEC sp_addextendedproperty N'MS_Description', N'会员组ID', N'user', N'dbo', N'table', N'Group_Havior', N'column', N'GroupID';
EXEC sp_addextendedproperty N'MS_Description', N'行为ID', N'user', N'dbo', N'table', N'Group_Havior', N'column', N'HaviorID';
EXEC sp_addextendedproperty N'MS_Description', N'流水号', N'user', N'dbo', N'table', N'Group_Havior', N'column', N'SerialNo';
EXEC sp_addextendedproperty N'MS_Description', N'更新时间', N'user', N'dbo', N'table', N'Group_Havior', N'column', N'UpdateTime';
EXEC sp_addextendedproperty N'MS_Description', N'默认', N'user', N'dbo', N'table', N'Group_Havior', N'column', N'Default';
EXEC sp_addextendedproperty N'MS_Description', N'软删除', N'user', N'dbo', N'table', N'Group_Havior', N'column', N'Del';
EXEC sp_addextendedproperty N'MS_Description', N'硬删除', N'user', N'dbo', N'table', N'Group_Havior', N'column', N'Destroy';
EXEC sp_addextendedproperty N'MS_Description', N'创建时间', N'user', N'dbo', N'table', N'Group_Havior', N'column', N'CreateTime';
EXEC sp_addextendedproperty N'MS_Description', N'记录会员', N'user', N'dbo', N'table', N'Group_Havior', N'column', N'LogMemberID';
GO


-- 角色与行为关系
IF(OBJECT_ID('dbo.[Role_Havior]',N'U') IS NOT NULL)
	DROP TABLE dbo.[Role_Havior]
GO
CREATE TABLE dbo.[Role_Havior]
(
	[RoleID] UNIQUEIDENTIFIER NOT NULL,	-- 角色ID
	[HaviorID] UNIQUEIDENTIFIER NOT NULL,	-- 行为ID
	-- 以下为通用字段，除了UpdateTime，SerialNo，LogMemberID以外，其他禁止插入，禁止更新（但不包含软删除，硬删除）
	[SerialNo] INT IDENTITY(1,1) PRIMARY KEY,	-- 流水号
	[UpdateTime] DATETIME, -- 更新时间
	[Default] BIT NOT NULL DEFAULT(0),	-- 默认
	[Del] BIT NOT NULL DEFAULT(0),	-- 软删除
	[Destroy] BIT NOT NULL DEFAULT(0),	-- 硬删除
	[CreateTime] DATETIME NOT NULL DEFAULT(GETDATE()),	-- 创建时间
	[LogMemberID] UNIQUEIDENTIFIER NOT NULL	-- 记录会员
)
GO
EXEC sp_addextendedproperty N'MS_Description', N'角色与行为关系', N'user', N'dbo', N'table', N'Role_Havior';
GO
EXEC sp_addextendedproperty N'MS_Description', N'角色ID', N'user', N'dbo', N'table', N'Role_Havior', N'column', N'RoleID';
EXEC sp_addextendedproperty N'MS_Description', N'行为ID', N'user', N'dbo', N'table', N'Role_Havior', N'column', N'HaviorID';
EXEC sp_addextendedproperty N'MS_Description', N'流水号', N'user', N'dbo', N'table', N'Role_Havior', N'column', N'SerialNo';
EXEC sp_addextendedproperty N'MS_Description', N'更新时间', N'user', N'dbo', N'table', N'Role_Havior', N'column', N'UpdateTime';
EXEC sp_addextendedproperty N'MS_Description', N'默认', N'user', N'dbo', N'table', N'Role_Havior', N'column', N'Default';
EXEC sp_addextendedproperty N'MS_Description', N'软删除', N'user', N'dbo', N'table', N'Role_Havior', N'column', N'Del';
EXEC sp_addextendedproperty N'MS_Description', N'硬删除', N'user', N'dbo', N'table', N'Role_Havior', N'column', N'Destroy';
EXEC sp_addextendedproperty N'MS_Description', N'创建时间', N'user', N'dbo', N'table', N'Role_Havior', N'column', N'CreateTime';
EXEC sp_addextendedproperty N'MS_Description', N'记录会员', N'user', N'dbo', N'table', N'Role_Havior', N'column', N'LogMemberID';
GO


-- 会员与按钮关系
IF(OBJECT_ID('dbo.[Member_Button]',N'U') IS NOT NULL)
	DROP TABLE dbo.[Member_Button]
GO
CREATE TABLE dbo.[Member_Button]
(
	[MemberID] UNIQUEIDENTIFIER NOT NULL,	-- 会员ID
	[ButtonID] UNIQUEIDENTIFIER NOT NULL,	-- 按钮ID
	-- 以下为通用字段，除了UpdateTime，SerialNo，LogMemberID以外，其他禁止插入，禁止更新（但不包含软删除，硬删除）
	[SerialNo] INT IDENTITY(1,1) PRIMARY KEY,	-- 流水号
	[UpdateTime] DATETIME, -- 更新时间
	[Default] BIT NOT NULL DEFAULT(0),	-- 默认
	[Del] BIT NOT NULL DEFAULT(0),	-- 软删除
	[Destroy] BIT NOT NULL DEFAULT(0),	-- 硬删除
	[CreateTime] DATETIME NOT NULL DEFAULT(GETDATE()),	-- 创建时间
	[LogMemberID] UNIQUEIDENTIFIER NOT NULL	-- 记录会员
)
GO
EXEC sp_addextendedproperty N'MS_Description', N'会员与按钮关系', N'user', N'dbo', N'table', N'Member_Button';
GO
EXEC sp_addextendedproperty N'MS_Description', N'会员ID', N'user', N'dbo', N'table', N'Member_Button', N'column', N'MemberID';
EXEC sp_addextendedproperty N'MS_Description', N'按钮ID', N'user', N'dbo', N'table', N'Member_Button', N'column', N'ButtonID';
EXEC sp_addextendedproperty N'MS_Description', N'流水号', N'user', N'dbo', N'table', N'Member_Button', N'column', N'SerialNo';
EXEC sp_addextendedproperty N'MS_Description', N'更新时间', N'user', N'dbo', N'table', N'Member_Button', N'column', N'UpdateTime';
EXEC sp_addextendedproperty N'MS_Description', N'默认', N'user', N'dbo', N'table', N'Member_Button', N'column', N'Default';
EXEC sp_addextendedproperty N'MS_Description', N'软删除', N'user', N'dbo', N'table', N'Member_Button', N'column', N'Del';
EXEC sp_addextendedproperty N'MS_Description', N'硬删除', N'user', N'dbo', N'table', N'Member_Button', N'column', N'Destroy';
EXEC sp_addextendedproperty N'MS_Description', N'创建时间', N'user', N'dbo', N'table', N'Member_Button', N'column', N'CreateTime';
EXEC sp_addextendedproperty N'MS_Description', N'记录会员', N'user', N'dbo', N'table', N'Member_Button', N'column', N'LogMemberID';
GO


-- 会员组与按钮关系
IF(OBJECT_ID('dbo.[Group_Button]',N'U') IS NOT NULL)
	DROP TABLE dbo.[Group_Button]
GO
CREATE TABLE dbo.[Group_Button]
(
	[GroupID] UNIQUEIDENTIFIER NOT NULL,	-- 会员组ID
	[ButtonID] UNIQUEIDENTIFIER NOT NULL,	-- 按钮ID
	-- 以下为通用字段，除了UpdateTime，SerialNo，LogMemberID以外，其他禁止插入，禁止更新（但不包含软删除，硬删除）
	[SerialNo] INT IDENTITY(1,1) PRIMARY KEY,	-- 流水号
	[UpdateTime] DATETIME, -- 更新时间
	[Default] BIT NOT NULL DEFAULT(0),	-- 默认
	[Del] BIT NOT NULL DEFAULT(0),	-- 软删除
	[Destroy] BIT NOT NULL DEFAULT(0),	-- 硬删除
	[CreateTime] DATETIME NOT NULL DEFAULT(GETDATE()),	-- 创建时间
	[LogMemberID] UNIQUEIDENTIFIER NOT NULL	-- 记录会员
)
GO
EXEC sp_addextendedproperty N'MS_Description', N'会员组与按钮关系', N'user', N'dbo', N'table', N'Group_Button';
GO
EXEC sp_addextendedproperty N'MS_Description', N'会员组ID', N'user', N'dbo', N'table', N'Group_Button', N'column', N'GroupID';
EXEC sp_addextendedproperty N'MS_Description', N'按钮ID', N'user', N'dbo', N'table', N'Group_Button', N'column', N'ButtonID';
EXEC sp_addextendedproperty N'MS_Description', N'流水号', N'user', N'dbo', N'table', N'Group_Button', N'column', N'SerialNo';
EXEC sp_addextendedproperty N'MS_Description', N'更新时间', N'user', N'dbo', N'table', N'Group_Button', N'column', N'UpdateTime';
EXEC sp_addextendedproperty N'MS_Description', N'默认', N'user', N'dbo', N'table', N'Group_Button', N'column', N'Default';
EXEC sp_addextendedproperty N'MS_Description', N'软删除', N'user', N'dbo', N'table', N'Group_Button', N'column', N'Del';
EXEC sp_addextendedproperty N'MS_Description', N'硬删除', N'user', N'dbo', N'table', N'Group_Button', N'column', N'Destroy';
EXEC sp_addextendedproperty N'MS_Description', N'创建时间', N'user', N'dbo', N'table', N'Group_Button', N'column', N'CreateTime';
EXEC sp_addextendedproperty N'MS_Description', N'记录会员', N'user', N'dbo', N'table', N'Group_Button', N'column', N'LogMemberID';
GO


-- 角色与按钮关系
IF(OBJECT_ID('dbo.[Role_Button]',N'U') IS NOT NULL)
	DROP TABLE dbo.[Role_Button]
GO
CREATE TABLE dbo.[Role_Button]
(
	[RoleID] UNIQUEIDENTIFIER NOT NULL,	-- 角色ID
	[ButtonID] UNIQUEIDENTIFIER NOT NULL,	-- 按钮ID
	-- 以下为通用字段，除了UpdateTime，SerialNo，LogMemberID以外，其他禁止插入，禁止更新（但不包含软删除，硬删除）
	[SerialNo] INT IDENTITY(1,1) PRIMARY KEY,	-- 流水号
	[UpdateTime] DATETIME, -- 更新时间
	[Default] BIT NOT NULL DEFAULT(0),	-- 默认
	[Del] BIT NOT NULL DEFAULT(0),	-- 软删除
	[Destroy] BIT NOT NULL DEFAULT(0),	-- 硬删除
	[CreateTime] DATETIME NOT NULL DEFAULT(GETDATE()),	-- 创建时间
	[LogMemberID] UNIQUEIDENTIFIER NOT NULL	-- 记录会员
)
GO
EXEC sp_addextendedproperty N'MS_Description', N'角色与按钮关系', N'user', N'dbo', N'table', N'Role_Button';
GO
EXEC sp_addextendedproperty N'MS_Description', N'角色ID', N'user', N'dbo', N'table', N'Role_Button', N'column', N'RoleID';
EXEC sp_addextendedproperty N'MS_Description', N'按钮ID', N'user', N'dbo', N'table', N'Role_Button', N'column', N'ButtonID';
EXEC sp_addextendedproperty N'MS_Description', N'流水号', N'user', N'dbo', N'table', N'Role_Button', N'column', N'SerialNo';
EXEC sp_addextendedproperty N'MS_Description', N'更新时间', N'user', N'dbo', N'table', N'Role_Button', N'column', N'UpdateTime';
EXEC sp_addextendedproperty N'MS_Description', N'默认', N'user', N'dbo', N'table', N'Role_Button', N'column', N'Default';
EXEC sp_addextendedproperty N'MS_Description', N'软删除', N'user', N'dbo', N'table', N'Role_Button', N'column', N'Del';
EXEC sp_addextendedproperty N'MS_Description', N'硬删除', N'user', N'dbo', N'table', N'Role_Button', N'column', N'Destroy';
EXEC sp_addextendedproperty N'MS_Description', N'创建时间', N'user', N'dbo', N'table', N'Role_Button', N'column', N'CreateTime';
EXEC sp_addextendedproperty N'MS_Description', N'记录会员', N'user', N'dbo', N'table', N'Role_Button', N'column', N'LogMemberID';
GO


-- 内容分类
IF(OBJECT_ID('dbo.[Classify]',N'U') IS NOT NULL)
	DROP TABLE dbo.[Classify]
GO
CREATE TABLE dbo.[Classify]
(
	[ClassifyID] UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,	-- ID
	[Name] NVARCHAR(32) NOT NULL,	-- 名称
	[Remark] NVARCHAR(200),	-- 描述
	[Sort] INT NOT NULL DEFAULT(0),	-- 排序
	[ParentID] UNIQUEIDENTIFIER NOT NULL,	-- 上级ID
	[Enable] BIT DEFAULT(1) NOT NULL,	-- 启用
	-- 以下为通用字段，除了UpdateTime，SerialNo，LogMemberID以外，其他禁止插入，禁止更新（但不包含软删除，硬删除）
	[SerialNo] INT IDENTITY(1,1),	-- 流水号
	[UpdateTime] DATETIME, -- 更新时间
	[Default] BIT NOT NULL DEFAULT(0),	-- 默认
	[Del] BIT NOT NULL DEFAULT(0),	-- 软删除
	[Destroy] BIT NOT NULL DEFAULT(0),	-- 硬删除
	[CreateTime] DATETIME NOT NULL DEFAULT(GETDATE()),	-- 创建时间
	[LogMemberID] UNIQUEIDENTIFIER NOT NULL	-- 记录会员
)
GO
EXEC sp_addextendedproperty N'MS_Description', N'内容分类', N'user', N'dbo', N'table', N'Classify';
GO
EXEC sp_addextendedproperty N'MS_Description', N'ID', N'user', N'dbo', N'table', N'Classify', N'column', N'ClassifyID';
EXEC sp_addextendedproperty N'MS_Description', N'名称', N'user', N'dbo', N'table', N'Classify', N'column', N'Name';
EXEC sp_addextendedproperty N'MS_Description', N'描述', N'user', N'dbo', N'table', N'Classify', N'column', N'Remark';
EXEC sp_addextendedproperty N'MS_Description', N'排序', N'user', N'dbo', N'table', N'Classify', N'column', N'Sort';
EXEC sp_addextendedproperty N'MS_Description', N'上级ID', N'user', N'dbo', N'table', N'Classify', N'column', N'ParentID';
EXEC sp_addextendedproperty N'MS_Description', N'启用', N'user', N'dbo', N'table', N'Classify', N'column', N'Enable';
EXEC sp_addextendedproperty N'MS_Description', N'流水号', N'user', N'dbo', N'table', N'Classify', N'column', N'SerialNo';
EXEC sp_addextendedproperty N'MS_Description', N'更新时间', N'user', N'dbo', N'table', N'Classify', N'column', N'UpdateTime';
EXEC sp_addextendedproperty N'MS_Description', N'默认', N'user', N'dbo', N'table', N'Classify', N'column', N'Default';
EXEC sp_addextendedproperty N'MS_Description', N'软删除', N'user', N'dbo', N'table', N'Classify', N'column', N'Del';
EXEC sp_addextendedproperty N'MS_Description', N'硬删除', N'user', N'dbo', N'table', N'Classify', N'column', N'Destroy';
EXEC sp_addextendedproperty N'MS_Description', N'创建时间', N'user', N'dbo', N'table', N'Classify', N'column', N'CreateTime';
EXEC sp_addextendedproperty N'MS_Description', N'记录会员', N'user', N'dbo', N'table', N'Classify', N'column', N'LogMemberID';
GO


-- 内容
IF(OBJECT_ID('dbo.[Content]',N'U') IS NOT NULL)
	DROP TABLE dbo.[Content]
GO
CREATE TABLE dbo.[Content]
(
	[ContentID] UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,	-- ID
	[Title] NVARCHAR(200) NOT NULL,	-- 标题
	[HtmlText] TEXT NOT NULL,	-- Html内容
	[MarkdownText] TEXT,	-- Markdown内容
	[ClassifyID] UNIQUEIDENTIFIER NOT NULL,	-- 分类ID
	[Author] NVARCHAR(50),	-- 作者
	[Source] NVARCHAR(100),	-- 来源
	[PushTime] DATETIME NOT NULL,	-- 发布时间
	[IPAddress] NVARCHAR(16) NOT NULL,	-- IP地址
	[IPDetail] NVARCHAR(100),	-- IP详情
	[MemberID] UNIQUEIDENTIFIER NOT NULL,	-- 发布人
	[Pass] BIT NOT NULL DEFAULT(0),	-- 审核状态
	-- 以下为通用字段，除了UpdateTime，SerialNo，LogMemberID以外，其他禁止插入，禁止更新（但不包含软删除，硬删除）
	[SerialNo] INT IDENTITY(1,1),	-- 流水号
	[UpdateTime] DATETIME, -- 更新时间
	[Default] BIT NOT NULL DEFAULT(0),	-- 默认
	[Del] BIT NOT NULL DEFAULT(0),	-- 软删除
	[Destroy] BIT NOT NULL DEFAULT(0),	-- 硬删除
	[CreateTime] DATETIME NOT NULL DEFAULT(GETDATE()),	-- 创建时间
	[LogMemberID] UNIQUEIDENTIFIER NOT NULL	-- 记录会员
)
GO
EXEC sp_addextendedproperty N'MS_Description', N'内容', N'user', N'dbo', N'table', N'Content';
GO
EXEC sp_addextendedproperty N'MS_Description', N'ID', N'user', N'dbo', N'table', N'Content', N'column', N'ContentID';
EXEC sp_addextendedproperty N'MS_Description', N'标题', N'user', N'dbo', N'table', N'Content', N'column', N'Title';
EXEC sp_addextendedproperty N'MS_Description', N'Html内容', N'user', N'dbo', N'table', N'Content', N'column', N'HtmlText';
EXEC sp_addextendedproperty N'MS_Description', N'Markdown内容', N'user', N'dbo', N'table', N'Content', N'column', N'MarkdownText';
EXEC sp_addextendedproperty N'MS_Description', N'分类ID', N'user', N'dbo', N'table', N'Content', N'column', N'ClassifyID';
EXEC sp_addextendedproperty N'MS_Description', N'作者', N'user', N'dbo', N'table', N'Content', N'column', N'Author';
EXEC sp_addextendedproperty N'MS_Description', N'来源', N'user', N'dbo', N'table', N'Content', N'column', N'Source';
EXEC sp_addextendedproperty N'MS_Description', N'发布时间', N'user', N'dbo', N'table', N'Content', N'column', N'PushTime';
EXEC sp_addextendedproperty N'MS_Description', N'IP地址', N'user', N'dbo', N'table', N'Content', N'column', N'IPAddress';
EXEC sp_addextendedproperty N'MS_Description', N'IP详情', N'user', N'dbo', N'table', N'Content', N'column', N'IPDetail';
EXEC sp_addextendedproperty N'MS_Description', N'发布人', N'user', N'dbo', N'table', N'Content', N'column', N'MemberID';
EXEC sp_addextendedproperty N'MS_Description', N'审核状态', N'user', N'dbo', N'table', N'Content', N'column', N'Pass';
EXEC sp_addextendedproperty N'MS_Description', N'流水号', N'user', N'dbo', N'table', N'Content', N'column', N'SerialNo';
EXEC sp_addextendedproperty N'MS_Description', N'更新时间', N'user', N'dbo', N'table', N'Content', N'column', N'UpdateTime';
EXEC sp_addextendedproperty N'MS_Description', N'默认', N'user', N'dbo', N'table', N'Content', N'column', N'Default';
EXEC sp_addextendedproperty N'MS_Description', N'软删除', N'user', N'dbo', N'table', N'Content', N'column', N'Del';
EXEC sp_addextendedproperty N'MS_Description', N'硬删除', N'user', N'dbo', N'table', N'Content', N'column', N'Destroy';
EXEC sp_addextendedproperty N'MS_Description', N'创建时间', N'user', N'dbo', N'table', N'Content', N'column', N'CreateTime';
EXEC sp_addextendedproperty N'MS_Description', N'记录会员', N'user', N'dbo', N'table', N'Content', N'column', N'LogMemberID';
GO

-- 内容浏览记录
IF(OBJECT_ID('dbo.[BrowseLog]',N'U') IS NOT NULL)
	DROP TABLE dbo.[BrowseLog]
GO
CREATE TABLE dbo.[BrowseLog]
(
	[LogID] UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,	-- ID
	[ContentID] UNIQUEIDENTIFIER NOT NULL,	-- 内容ID
	[MemberID] UNIQUEIDENTIFIER,	-- 会员ID
	[LogTime] DATETIME NOT NULL,	-- 浏览时间
	[IPAddress] NVARCHAR(16) NOT NULL,	-- IP地址
	[IPDetail] NVARCHAR(100),	-- IP详情
	-- 以下为通用字段，除了UpdateTime，SerialNo，LogMemberID以外，其他禁止插入，禁止更新（但不包含软删除，硬删除）
	[SerialNo] INT IDENTITY(1,1),	-- 流水号
	[UpdateTime] DATETIME, -- 更新时间
	[Default] BIT NOT NULL DEFAULT(0),	-- 默认
	[Del] BIT NOT NULL DEFAULT(0),	-- 软删除
	[Destroy] BIT NOT NULL DEFAULT(0),	-- 硬删除
	[CreateTime] DATETIME NOT NULL DEFAULT(GETDATE()),	-- 创建时间
	[LogMemberID] UNIQUEIDENTIFIER NOT NULL	-- 记录会员
)
GO
EXEC sp_addextendedproperty N'MS_Description', N'内容', N'user', N'dbo', N'table', N'BrowseLog';
GO
EXEC sp_addextendedproperty N'MS_Description', N'ID', N'user', N'dbo', N'table', N'BrowseLog', N'column', N'LogID';
EXEC sp_addextendedproperty N'MS_Description', N'内容ID', N'user', N'dbo', N'table', N'BrowseLog', N'column', N'ContentID';
EXEC sp_addextendedproperty N'MS_Description', N'会员ID', N'user', N'dbo', N'table', N'BrowseLog', N'column', N'MemberID';
EXEC sp_addextendedproperty N'MS_Description', N'浏览时间', N'user', N'dbo', N'table', N'BrowseLog', N'column', N'LogTime';
EXEC sp_addextendedproperty N'MS_Description', N'IP地址', N'user', N'dbo', N'table', N'BrowseLog', N'column', N'IPAddress';
EXEC sp_addextendedproperty N'MS_Description', N'IP详情', N'user', N'dbo', N'table', N'BrowseLog', N'column', N'IPDetail';
EXEC sp_addextendedproperty N'MS_Description', N'流水号', N'user', N'dbo', N'table', N'BrowseLog', N'column', N'SerialNo';
EXEC sp_addextendedproperty N'MS_Description', N'更新时间', N'user', N'dbo', N'table', N'BrowseLog', N'column', N'UpdateTime';
EXEC sp_addextendedproperty N'MS_Description', N'默认', N'user', N'dbo', N'table', N'BrowseLog', N'column', N'Default';
EXEC sp_addextendedproperty N'MS_Description', N'软删除', N'user', N'dbo', N'table', N'BrowseLog', N'column', N'Del';
EXEC sp_addextendedproperty N'MS_Description', N'硬删除', N'user', N'dbo', N'table', N'BrowseLog', N'column', N'Destroy';
EXEC sp_addextendedproperty N'MS_Description', N'创建时间', N'user', N'dbo', N'table', N'BrowseLog', N'column', N'CreateTime';
EXEC sp_addextendedproperty N'MS_Description', N'记录会员', N'user', N'dbo', N'table', N'BrowseLog', N'column', N'LogMemberID';
GO


-- 创建模块视图
IF ( OBJECT_ID('dbo.[V_Module]', 'V') IS NOT NULL )
    DROP VIEW dbo.[V_Module];
GO
CREATE VIEW dbo.[V_Module]
AS
    SELECT  module.* ,
            parentModule.Name AS ParentName ,
            havior.HaviorID ,
            havior.Name AS HaviorName ,
            havior.HttpMethod ,
            havior.Url
    FROM    dbo.Module module
            LEFT JOIN ( SELECT  *
                        FROM    dbo.Havior
                        WHERE   Del = 0
                                AND Destroy = 0
                                AND [Enable] = 1
                                AND [Index] = 1
                      ) havior ON module.ModuleID = havior.ModuleID
            LEFT JOIN ( SELECT  *
                        FROM    dbo.Module
                        WHERE   Del = 0
                                AND Destroy = 0
                      ) parentModule ON module.ParentID = parentModule.ModuleID;
GO
-- 创建行为视图
IF ( OBJECT_ID('dbo.[V_Havior]', 'V') IS NOT NULL )
    DROP VIEW dbo.[V_Havior];
GO
CREATE VIEW dbo.[V_Havior]
AS
    SELECT  havior.* ,
            module.Name AS ModuleName ,
            module.Sort AS ModuleSort
    FROM    dbo.Havior havior
            LEFT JOIN ( SELECT  *
                        FROM    dbo.Module
                        WHERE   Del = 0
                                AND Destroy = 0
                      ) module ON havior.ModuleID = module.ModuleID;