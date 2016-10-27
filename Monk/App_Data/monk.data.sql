USE [Monk.Soul]
GO
INSERT  INTO dbo.Member
        ( MemberID ,
          Account ,
          Password ,
          Email ,
          Phone ,
          Photo ,
          Remark ,
          GroupID ,
          Enable ,
          Pass ,
          UpdateTime ,
          [Default] ,
          Del ,
          Destroy ,
          CreateTime ,
          LogMemberID
        )
VALUES  ( '6a0c65d8-3649-4745-b50e-57273feaa274' , -- MemberID - uniqueidentifier
          N'百小僧' , -- Account - nvarchar(32)
          'b65b24c2f2ec609b0104eb8fb743b29a' , -- Password - char(32)
          N'monk@baisoft.org' , -- Email - nvarchar(256)
          '18676265646' , -- Phone - varchar(32)
          N'' , -- Photo - nvarchar(200)
          N'百签软件，源于百签。' , -- Remark - nvarchar(200)
          'cbd35057-2b4e-4578-b08f-5c9ccd65dab5' , -- GroupID - uniqueidentifier
          1 , -- Enable - bit
          1 , -- Pass - bit
          GETDATE() , -- UpdateTime - datetime
          1 , -- Default - bit
          0 , -- Del - bit
          0 , -- Destroy - bit
          GETDATE() , -- CreateTime - datetime
          '00000000-0000-0000-0000-000000000000'  -- LogMemberID - uniqueidentifier
        );
GO
INSERT  INTO dbo.[Group]
        ( GroupID ,
          Name ,
          Remark ,
          ParentID ,
          Enable ,
          UpdateTime ,
          [Default] ,
          Del ,
          Destroy ,
          CreateTime ,
          LogMemberID
        )
VALUES  ( 'cbd35057-2b4e-4578-b08f-5c9ccd65dab5' , -- GroupID - uniqueidentifier
          N'超级管理组' , -- Name - nvarchar(32)
          N'超级管理组' , -- Remark - nvarchar(200)
          '00000000-0000-0000-0000-000000000000' , -- ParentID - uniqueidentifier
          1 , -- Enable - bit
          GETDATE() , -- UpdateTime - datetime
          1 , -- Default - bit
          0 , -- Del - bit
          0 , -- Destroy - bit
          GETDATE() , -- CreateTime - datetime
          '00000000-0000-0000-0000-000000000000'  -- LogMemberID - uniqueidentifier
        );
INSERT  INTO dbo.SysSet
        ( SetID ,
          Logo ,
          Name ,
          Version ,
          Keywords ,
          Description ,
          Support ,
          CopyRight ,
          Site ,
          PageSize ,
          ImageMaxSize ,
          VideoMaxSize ,
          AttachMaxSize ,
          UpdateTime ,
          [Default] ,
          Del ,
          Destroy ,
          CreateTime ,
          LogMemberID
        )
VALUES  ( NEWID() , -- SetID - uniqueidentifier
          N'/Areas/Backend/Assets/Images/baisoft-logo.png' , -- Logo - nvarchar(200)
          N'Monk.Soul' , -- Name - nvarchar(100)
          N'1.0.0' , -- Version - nvarchar(50)
          N'Monk.Soul,百签软件,百小僧,baisoft,baisoft.org' , -- Keywords - nvarchar(200)
          N'Monk.Soul 是百签软件（中山）有限公司 旗下一款开源CAS管理系统。' , -- Description - nvarchar(320)
          N'百签软件（中山）有限公司' , -- Support - nvarchar(100)
          N'Copyright ©  2016 百签软件（中山）有限公司. All rights reserved.' , -- CopyRight - nvarchar(200)
          N'http://www.baisoft.org/' , -- Site - nvarchar(200)
          15 , -- PageSize - int
          2 , -- ImageMaxSize - int
          5 , -- VideoMaxSize - int
          10 , -- AttachMaxSize - int
          GETDATE() , -- UpdateTime - datetime
          1 , -- Default - bit
          0 , -- Del - bit
          0 , -- Destroy - bit
          GETDATE() , -- CreateTime - datetime
          '00000000-0000-0000-0000-000000000000'  -- LogMemberID - uniqueidentifier
        );
INSERT INTO dbo.Module
        ( ModuleID ,
          Name ,
          Remark ,
          Sort ,
          TagAttr ,
          ParentID ,
          Iconfont ,
          Enable ,
          UpdateTime ,
          [Default] ,
          Del ,
          Destroy ,
          CreateTime ,
          LogMemberID
        )
VALUES  ( '11111111-1111-1111-1111-111111111111' , -- ModuleID - uniqueidentifier
          N'根站点栏目' , -- Name - nvarchar(32)
          N'顶级栏目' , -- Remark - nvarchar(200)
          0 , -- Sort - int
          N'' , -- TagAttr - nvarchar(200)
          '00000000-0000-0000-0000-000000000000' , -- ParentID - uniqueidentifier
          N'icon-backend-file' , -- Iconfont - nvarchar(100)
          1 , -- Enable - bit
          GETDATE() , -- UpdateTime - datetime
          1 , -- Default - bit
          0 , -- Del - bit
          0 , -- Destroy - bit
          GETDATE() , -- CreateTime - datetime
          '00000000-0000-0000-0000-000000000000'  -- LogMemberID - uniqueidentifier
        );
INSERT INTO dbo.Module
        ( ModuleID ,
          Name ,
          Remark ,
          Sort ,
          TagAttr ,
          ParentID ,
          Iconfont ,
          Enable ,
          UpdateTime ,
          [Default] ,
          Del ,
          Destroy ,
          CreateTime ,
          LogMemberID
        )
VALUES  ( 'ce9c77a6-efab-4b29-adde-55102d2432c7' , -- ModuleID - uniqueidentifier
          N'站点管理' , -- Name - nvarchar(32)
          N'站点管理' , -- Remark - nvarchar(200)
          0 , -- Sort - int
          N'' , -- TagAttr - nvarchar(200)
          '11111111-1111-1111-1111-111111111111' , -- ParentID - uniqueidentifier
          N'icon-backend-file' , -- Iconfont - nvarchar(100)
          1 , -- Enable - bit
          GETDATE() , -- UpdateTime - datetime
          1 , -- Default - bit
          0 , -- Del - bit
          0 , -- Destroy - bit
          GETDATE() , -- CreateTime - datetime
          '00000000-0000-0000-0000-000000000000'  -- LogMemberID - uniqueidentifier
        );
INSERT INTO dbo.Module
        ( ModuleID ,
          Name ,
          Remark ,
          Sort ,
          TagAttr ,
          ParentID ,
          Iconfont ,
          Enable ,
          UpdateTime ,
          [Default] ,
          Del ,
          Destroy ,
          CreateTime ,
          LogMemberID
        )
VALUES  ( '9762f805-c619-4a06-b294-755c4619c738' , -- ModuleID - uniqueidentifier
          N'站点设置' , -- Name - nvarchar(32)
          N'站点设置' , -- Remark - nvarchar(200)
          0 , -- Sort - int
          N'' , -- TagAttr - nvarchar(200)
          'ce9c77a6-efab-4b29-adde-55102d2432c7' , -- ParentID - uniqueidentifier
          N'icon-backend-file' , -- Iconfont - nvarchar(100)
          1 , -- Enable - bit
          GETDATE() , -- UpdateTime - datetime
          1 , -- Default - bit
          0 , -- Del - bit
          0 , -- Destroy - bit
          GETDATE() , -- CreateTime - datetime
          '00000000-0000-0000-0000-000000000000'  -- LogMemberID - uniqueidentifier
        );
INSERT INTO dbo.Module
        ( ModuleID ,
          Name ,
          Remark ,
          Sort ,
          TagAttr ,
          ParentID ,
          Iconfont ,
          Enable ,
          UpdateTime ,
          [Default] ,
          Del ,
          Destroy ,
          CreateTime ,
          LogMemberID
        )
VALUES  ( '32b1b9e9-ee08-4609-98dd-d555c11decf4' , -- ModuleID - uniqueidentifier
          N'内容管理' , -- Name - nvarchar(32)
          N'内容管理' , -- Remark - nvarchar(200)
          0 , -- Sort - int
          N'' , -- TagAttr - nvarchar(200)
          'ce9c77a6-efab-4b29-adde-55102d2432c7' , -- ParentID - uniqueidentifier
          N'icon-backend-file' , -- Iconfont - nvarchar(100)
          1 , -- Enable - bit
          GETDATE() , -- UpdateTime - datetime
          1 , -- Default - bit
          0 , -- Del - bit
          0 , -- Destroy - bit
          GETDATE() , -- CreateTime - datetime
          '00000000-0000-0000-0000-000000000000'  -- LogMemberID - uniqueidentifier
        );
INSERT INTO dbo.Module
        ( ModuleID ,
          Name ,
          Remark ,
          Sort ,
          TagAttr ,
          ParentID ,
          Iconfont ,
          Enable ,
          UpdateTime ,
          [Default] ,
          Del ,
          Destroy ,
          CreateTime ,
          LogMemberID
        )
VALUES  ( 'af2fb712-c886-4dc6-ae4a-a77909d3270a' , -- ModuleID - uniqueidentifier
          N'分类管理' , -- Name - nvarchar(32)
          N'分类管理' , -- Remark - nvarchar(200)
          0 , -- Sort - int
          N'' , -- TagAttr - nvarchar(200)
          '32b1b9e9-ee08-4609-98dd-d555c11decf4' , -- ParentID - uniqueidentifier
          N'icon-backend-file' , -- Iconfont - nvarchar(100)
          1 , -- Enable - bit
          GETDATE() , -- UpdateTime - datetime
          1 , -- Default - bit
          0 , -- Del - bit
          0 , -- Destroy - bit
          GETDATE() , -- CreateTime - datetime
          '00000000-0000-0000-0000-000000000000'  -- LogMemberID - uniqueidentifier
        );
INSERT INTO dbo.Module
        ( ModuleID ,
          Name ,
          Remark ,
          Sort ,
          TagAttr ,
          ParentID ,
          Iconfont ,
          Enable ,
          UpdateTime ,
          [Default] ,
          Del ,
          Destroy ,
          CreateTime ,
          LogMemberID
        )
VALUES  ( '7f6407f3-6629-4542-92f1-906f98d12166' , -- ModuleID - uniqueidentifier
          N'文章管理' , -- Name - nvarchar(32)
          N'文章管理' , -- Remark - nvarchar(200)
          0 , -- Sort - int
          N'' , -- TagAttr - nvarchar(200)
          '32b1b9e9-ee08-4609-98dd-d555c11decf4' , -- ParentID - uniqueidentifier
          N'icon-backend-file' , -- Iconfont - nvarchar(100)
          1 , -- Enable - bit
          GETDATE() , -- UpdateTime - datetime
          1 , -- Default - bit
          0 , -- Del - bit
          0 , -- Destroy - bit
          GETDATE() , -- CreateTime - datetime
          '00000000-0000-0000-0000-000000000000'  -- LogMemberID - uniqueidentifier
        );