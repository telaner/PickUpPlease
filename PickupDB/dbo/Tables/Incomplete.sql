CREATE TABLE [dbo].[Incomplete]
(
	[incompleteId] INT NOT NULL PRIMARY KEY Identity, 
    [messageID] NCHAR(10) NULL, 
    [pickupID] NCHAR(10) NULL, 
    [time] TIMESTAMP NULL
)
