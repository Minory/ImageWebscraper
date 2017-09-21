CREATE PROCEDURE [dbo].[Keyword_Insert]
	@Keyword NVARCHAR(128),
	@Id INT OUTPUT
AS
/*
DECLARE 
	@_id INT,
	@_keyword NVARCHAR(128) = 'Test01',
EXECUTE [Keyword_Insert]
	@_id OUT, 
	@_keyword;
SELECT * FROM Keyword WHERE Id = @_id;
*/
BEGIN
	INSERT INTO Keyword
	VALUES (@Keyword);

	SET @Id = SCOPE_IDENTITY();
END