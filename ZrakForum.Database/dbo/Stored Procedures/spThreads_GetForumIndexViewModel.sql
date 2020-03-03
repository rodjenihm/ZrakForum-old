CREATE PROCEDURE [dbo].[spThreads_GetForumIndexViewModel]
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

	SELECT [Threads].[Id] as [ThreadId], [Threads].[CreatedAt], [Threads].[Name], [Accounts].[Username] 
	FROM [dbo].[Threads]
	JOIN [dbo].[Accounts]
	ON ([Threads].[AuthorId] = [Accounts].[Id])
	WHERE [ForumId] = @ForumId;
END