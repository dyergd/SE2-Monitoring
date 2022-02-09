CREATE TABLE  [dbo].[visit_clicks]
(
	click_id int IDENTITY(1,1),
	visit_id int,
	click_tstamp datetime2,
	currentpage varchar,
	nextpage varchar,
	x int,
	y int,
	CONSTRAINT visit_clicks_click_id_PK PRIMARY KEY (click_id),
	CONSTRAINT visit_clicks_visit_id_FK FOREIGN KEY (visit_id)
	REFERENCES VISIT(visit_id)
)