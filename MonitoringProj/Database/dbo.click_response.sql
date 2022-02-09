CREATE TABLE  [dbo].[click_response]
(
	click_id int,
	tstamp datetime2,
	response_code int,
	message varchar(30),
	CONSTRAINT click_response_PK PRIMARY KEY (click_id, tstamp)
)
