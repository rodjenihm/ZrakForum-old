﻿CREATE PROCEDURE [dbo].[spForums_GetAll]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM [dbo].[Forums];
END