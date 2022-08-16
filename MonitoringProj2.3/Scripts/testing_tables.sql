/*
*	TEST SCRIPT FOR VISIT TABLE - (PASSES)
*/-------------------------------------------------------------------
DELETE FROM Team6MinusOne.visits;

-- ALTER TABLE Team6MinusOne.visits MODIFY id INT NOT NULL AUTO_INCREMENT;

INSERT INTO Team6MinusOne.visits (Id, Ip, Timestamp, DeviceSource)
VALUES 
(1,1921682324,'2018-06-23 07:30:21','PC'),
(2,191232823,'2019-06-23 07:30:20','Mobile Phone'),
(3,1921682324,'2017-06-23 07:30:21','Mobile Phone'),
(4,191232823,'2019-06-23 07:30:20','PC'),
(5,191232823,'2019-06-23 07:30:20','Mobile Phone'),
(6,191232823,'2019-06-23 07:30:20','PC');

Insert into Team6MinusOne.visits (Ip, Timestamp, Origin, DeviceSource)
VALUES
(1921682324,'2018-06-23 07:30:21','Bobyboi','PSP');

SELECT * FROM Team6MinusOne.visits;

DELETE FROM Team6MinusOne.visits;




/*-------------------------------------------------------------------
*	TEST SCRIPT FOR CART TABLE (PASSES)
*/-------------------------------------------------------------------
DELETE FROM Team6MinusOne.Carts;

INSERT INTO Team6MinusOne.Carts (Timestamp, VisitId, Purchased, PunchTimestamp)
VALUES
('2015-06-23 04:30:21', 1,  1, '2015-06-23 04:30:21'),
('2015-06-23 04:30:21', 2,  1, '2015-06-23 04:30:21'),
('2015-06-23 04:30:21', 3,  0, '2015-06-23 04:30:21'),
('2015-06-23 04:30:21', 4,  0, '2015-06-23 04:30:21'),
('2015-06-23 04:30:21', 5,  1, '2015-06-23 04:30:21'),
('2015-06-23 04:30:21', 6,  0, '2015-06-23 04:30:21');

SELECT * FROM Team6MinusOne.Carts;

DELETE FROM Team6MinusOne.Carts;



/*-------------------------------------------------------------------
*	TEST SCRIPT FOR CART_ITEM TABLE (PASSES)
*/-------------------------------------------------------------------
DELETE FROM Team6MinusOne.CartItems;

INSERT INTO Team6MinusOne.CartItems(Id, CartId, Timestamp, Item, Quantity, Removed, Cost)
VALUES 
(1, 1, '2015-06-23 04:30:21', 'Item1', 2, 0, 23.24),
(2, 2,'2015-06-23 04:30:21', 'Item2', 3, 0, 12.23),
(3, 3,'2015-06-23 04:30:21', 'Item3', 1, 0,  12.23),
(4, 4,'2015-06-23 04:30:21', 'Item4', 2, 0, 11.12),
(5, 5, '2015-06-23 04:30:21', 'Item5', 1, 0, 9.23),
(6, 6,'2015-06-23 04:30:21', 'Item6', 1, 0, 4.52);

SELECT * FROM Team6MinusOne.CartItems;

DELETE FROM Team6MinusOne.CartItems;



-- Finished Testing? Use this order to delete quickly
DELETE FROM Team6MinusOne.CARTITEMS;
DELETE FROM Team6MinusOne.CARTS;
DELETE FROM Team6MinusOne.VISITRESPONSES;
DELETE FROM Team6MinusOne.VISITCLICKS;
DELETE FROM Team6MinusOne.VISITS;

