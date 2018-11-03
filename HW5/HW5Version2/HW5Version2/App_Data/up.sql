CREATE TABLE [dbo].[Requests]
(
	[ID] INT IDENTITY (1,1)		NOT NULL,
	[FirstName]	NVARCHAR(60)			NOT NULL,
	[LastName] NVARCHAR(80)			NOT NULL,
	[Phone]	NVARCHAR(22)			NOT NULL,
	[ApartmentName]	NVARCHAR(64)				NOT NULL,
	[UnitNum] INT						NOT NULL,
	[InfoReq] NVARCHAR(128)			NOT NULL,
	[SubmitTime] DATETIME2			NOT NULL,
	CONSTRAINT [PK_dbo.Requests] PRIMARY KEY CLUSTERED ([ID] ASC)
);

INSERT INTO [dbo].[Requests] (FirstName, LastName, Phone, ApartmentName, UnitNum, InfoReq, SubmitTime) VALUES
	('Jane', 'Johnson', '208-377-9634', 'Legacy Oaks Apartments', 120, 'Fire alarm battery needs to be replaced in living room.', '2018-06-18T10:34:09'),
	('Robbert', 'Peterson', '503-241-4679', 'Creekside Meadow Apartments', 430, 'Refigerator lightbulb went out and needs to be replaced.', '2018-08-18T11:14:16' ),
	('Lorie', 'Smith', '808-521-7436', 'Legacy Oaks Apartments', 272, 'Neighbors in unit 274 are violating quite time hours.', '2018-09-21T09:26:35'),
	('Jacob', 'Harper', '208-858-1280', 'Brookeside Apartments', 158, 'Front door lock keeps getting jammed and is difficult to unlock it.', '2018-10-01T02:13:14'),
	('Sarah','Hamilton', '503-479-4279', 'Creekside Meadow Apartments', 210, 'Washer and dryer are out of date. Would like a possible upgrade.', '2018-10-17T10:15:20')
GO