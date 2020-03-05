CREATE PROCEDURE [dbo].[spForumThreads_GetByForumName]
	@ForumName NVARCHAR(255)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT * FROM [dbo].[vForumThreads]
	WHERE [ForumName] = @ForumName;
END