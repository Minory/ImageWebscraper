CREATE PROCEDURE [dbo].[Images_Insert]
	@KeyId int,
	@Image NVARCHAR(MAX)
AS
/*
DECLARE 
	@_id INT = 1,
	@_image NVARCHAR(MAX) = 'Test01'
EXECUTE [Images_Insert]
	@_id, 
	@_image;
SELECT * FROM Images WHERE KeyId = @_id;
*/
BEGIN
	INSERT INTO Images
	VALUES (@KeyId, @Image);
END