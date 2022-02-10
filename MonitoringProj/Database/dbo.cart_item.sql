CREATE TABLE [dbo].[cart_item]
(
	cart_item_id INT IDENTITY(1,1) NOT NULL,
	cart_id int,
	cart_tstamp datetime2,
	item varchar(255),
    tstamp datetime2,
	quantity int,
	removed Bit,
	cost Decimal(6,2),
	CONSTRAINT cart_item_PK PRIMARY KEY (cart_item_id),
	CONSTRAINT cart_item_FK FOREIGN KEY (cart_id, cart_tstamp)
	REFERENCES CART(cart_id, tstamp),
)
