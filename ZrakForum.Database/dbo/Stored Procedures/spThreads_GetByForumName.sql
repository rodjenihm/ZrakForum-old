CREATE PROCEDURE [dbo].[spThreads_GetByForumName]
	@ForumName NVARCHAR(255)
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @ForumId INT;

	SET @ForumId = 
	(
		SELECT [Id] FROM [dbo].[Forums]
		WHERE [Name] = @ForumName
	);

	SELECT * FROM [dbo].[Threads]
	WHERE [ForumId] = @ForumId;
END
