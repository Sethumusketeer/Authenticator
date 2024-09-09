GO

SET ANSI_NULLS ON
GO
 
SET QUOTED_IDENTIFIER ON
GO
 
CREATE TABLE [dbo].[Notes](
	[userId] [int] NULL,
	[recordId] [int] IDENTITY(101,1) NOT NULL,
	[content] [varchar](max) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
 
ALTER TABLE [dbo].[Notes]  WITH CHECK ADD FOREIGN KEY([userId])
REFERENCES [dbo].[WeatherUser] ([UserId])
GO

SET IDENTITY_INSERT Notes ON;
INSERT INTO Notes (userId, recordId, content) VALUES 
(1001, 101, 'first note modified 1'),
(1001, 102, 'second note'),
(1002, 103, 'Hello There...'),
(1002, 104, 'Third Note')
SET IDENTITY_INSERT Notes OFF;


select * from Notes