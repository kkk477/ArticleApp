-- 게시판 테이블
CREATE TABLE [dbo].[Articles]
(
	[Id] INT NOT NULL PRIMARY KEY Identity(1,1),	-- 일련번호
	[Title] NVarChar(255) Not NULL,					-- 제목
)
Go
