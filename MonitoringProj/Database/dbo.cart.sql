CREATE TABLE [dbo].[cart]
(
	cart_id INT IDENTITY(1,1) NOT NULL,
	tstamp datetime2 NOT NULL,
	visit_id INT NOT NULL,
	purchased BIT,
	purch_timestamp DATETIME2,
	CONSTRAINT cart_id_PK PRIMARY KEY (cart_id,tstamp),
	CONSTRAINT visit_id_FK FOREIGN KEY (visit_id)
	REFERENCES visit(visit_id),
)
