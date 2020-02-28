CREATE PROCEDURE [dbo].[spRoles_GetById]
	@Id int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM [dbo].[Roles]
	WHERE [Id] = @Id;
END
