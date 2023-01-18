CREATE PROCEDURE [dbo].[residents_GetId]	

@HouseNumber nchar(10),
@Building nchar(10)

AS
begin
	select Id
	from dbo.[Residents]
	where HouseNumber = @HouseNumber and Building = @Building;
end
