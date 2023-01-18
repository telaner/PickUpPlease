CREATE TABLE [dbo].[Residents]
(
	[Id] INT NOT NULL PRIMARY KEY Identity, 
    [Building] NCHAR(10) NULL, 
    [HouseNumber] NCHAR(10) NULL, 
    [TrashValet] NCHAR(10) NULL
)
