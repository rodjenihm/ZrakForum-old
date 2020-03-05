CREATE VIEW [dbo].[vForumThreads]
AS
	SELECT
	[Threads].[Id] AS ThreadId, [Threads].[CreatedAt] AS StartedAt, [Threads].[Name] AS ThreadName,
	[Accounts].[Username] AS StartedBy,
	[Forums].[Name] AS ForumName
	FROM [dbo].[Threads]
	JOIN [dbo].[Accounts] ON ([Threads].[AuthorId] = [Accounts].[Id])
	JOIN [dbo].[Forums] ON ([Threads].[ForumId] = [Forums].[Id])