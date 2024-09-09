GO

SET ANSI_NULLS ON
GO
 
SET QUOTED_IDENTIFIER ON
GO
 
CREATE TABLE [dbo].[CityNames](
	[Cityname] [varchar](50) NOT NULL,
	[CityCode] [varchar](10) NOT NULL
) ON [PRIMARY]
GO

INSERT INTO CityNames (CityName, CityCode) VALUES
('Mumbai', 'mbi'),
('Delhi', 'dli'),
('Bangalore', 'bgl'),
('Kolkata', 'kok'),
('Chennai', 'chn'),
('Hyderabad', 'hyd'),
('Pune', 'pne'),
('Ahmedabad', 'ahd'),
('Surat', 'srt'),
('Visakhapatnam', 'vkp'),
('Kanpur', 'kpr'),
('Jaipur', 'jpr'),
('Lucknow', 'lkn'),
('Nagpur', 'ngr'),
('Indore', 'ide'),
('Agra', 'agr'),
('Varanasi', 'vri'),
('Amritsar', 'atr'),
('Allahabad', 'ald'),
('Bhopal', 'bpl'),
('Madurai', 'mdu'),
('Vadodara', 'vda'),
('Bhubaneswar', 'bbr'),
('Kochi', 'koc'),
('Guwahati', 'gwh')

select * from CityNames