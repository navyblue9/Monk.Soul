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
