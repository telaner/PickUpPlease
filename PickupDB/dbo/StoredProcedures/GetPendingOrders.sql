CREATE PROCEDURE [dbo].[GetPendingOrders]
	
AS
Begin
Select ResidentId
from PendingPickUp
End

