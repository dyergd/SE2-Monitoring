CREATE TABLE [dbo].[visit]
(
	visit_id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	ip varchar(15) NOT NULL,
	visit_timestamp datetime2 NOT NULL,
	origin VARCHAR(25)  null,
	device_source VARCHAR(25) null,
	--cookie_id(?) Possible in future?
	CONSTRAINT visit_id_PK PRIMARY KEY (visit_id),
)