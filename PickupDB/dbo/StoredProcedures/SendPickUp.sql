CREATE PROCEDURE [dbo].[SendPickUp]
@ResidentId nchar(10) 
As
begin
	insert into dbo.PendingPickUp (ResidentId)
	values (@ResidentId);
end
