-- 게시판 테이블
CREATE TABLE [dbo].[Articles]
(
	[Id] INT NOT Null PRIMARY KEY Identity(1,1),	-- 일련번호
	[Title] NVarChar(255) Not Null,					-- 제목
	[CreatedBy] NVarChar(255) Null,
	[Created]DateTime Default(GetDate()),
	[ModifiedBy] NVarChar(255) Null,
	[Modified] DateTime Null,
)
Go
