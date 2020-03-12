CREATE PROCEDURE [dbo].[spPosts_Create]
	@Content NVARCHAR(255),
	@AuthorId INT,
	@ThreadId INT
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO [dbo].[Posts]
	([Content], [AuthorId], [ThreadId])
	VALUES
	(@Content, @AuthorId, @ThreadId);
END