CREATE PROCEDURE [dbo].[GetPickUpId]
	@ResidentId int
AS
BEGIN
	select PickUpId
	from dbo.[PendingPickUp]
	where ResidentId = @ResidentId; 
END
