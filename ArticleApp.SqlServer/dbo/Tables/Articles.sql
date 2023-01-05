-- 게시판 테이블
CREATE TABLE [dbo].[Articles]
(
	[Id] INT NOT Null PRIMARY KEY Identity(1,1),	-- 일련번호
	[Title] NVarChar(255) Not Null,					-- 제목
	[Contents] NVarChar(Max) Null,					-- 내용
	[IsPinned] Bit Null Default(0),					-- 공지글로 올리기
	[CreatedBy] NVarChar(255) Null,					-- 등록자
	[Created]DateTime Default(GetDate()),			-- 생성일
	[ModifiedBy] NVarChar(255) Null,				-- 수정자
	[Modified] DateTime Null,						-- 수정일
)
Go
