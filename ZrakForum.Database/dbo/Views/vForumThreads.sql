CREATE VIEW [dbo].[vForumThreads]
AS
	SELECT
	t.[Id] AS ThreadId,t.[CreatedAt] AS StartedAt, t.[Name] AS ThreadName, t.[AuthorId], t.[ForumId],
	a.[Username] AS StartedBy,
	f.[Name] AS ForumName
	FROM [dbo].[Threads] t
	JOIN [dbo].[Accounts] a ON (t.[AuthorId] = a.[Id])
	JOIN [dbo].[Forums] f ON (t.[ForumId] = f.[Id])