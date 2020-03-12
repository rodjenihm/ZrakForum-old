CREATE PROCEDURE [dbo].[spThreads_Create]
	@Name NVARCHAR(255),
	@AuthorId INT,
	@ForumId INT
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO [dbo].[Threads]
	([Name], [AuthorId], [ForumId])
	VALUES
	(@Name, @AuthorId, @ForumId);
END