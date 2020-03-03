CREATE PROCEDURE [dbo].[spThreads_GetForumDetailsViewModel]
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

	SELECT
	[Threads].[CreatedAt] AS [StartedAt], [Threads].[Name] AS [ThreadName], [Accounts].[Username] AS [StartedBy]
	FROM [dbo].[Threads]
	JOIN [dbo].[Accounts]
	ON ([Threads].[AuthorId] = [Accounts].[Id])
	WHERE [ForumId] = @ForumId;
END