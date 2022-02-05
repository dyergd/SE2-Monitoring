/*
*	TEST SCRIPT FOR VISIT TABLE - (PASSES)
*/-------------------------------------------------------------------
DELETE FROM dbo.VISIT

SET IDENTITY_INSERT dbo.VISIT ON
INSERT INTO dbo.VISIT ([visit_id], [ip], [tstamp], [origin], [device_source])
VALUES 
(1,1921682324,'2018-06-23 07:30:21','Original1','PC'),
(2,191232823,'2019-06-23 07:30:20','Original2','Mobile Phone'),
(3,1921682324,'2017-06-23 07:30:21','Original3','Mobile Phone'),
(4,191232823,'2019-06-23 07:30:20','Original4','PC'),
(5,191232823,'2019-06-23 07:30:20','Original5','Mobile Phone'),
(6,191232823,'2019-06-23 07:30:20','Original6','PC');

SELECT * FROM dbo.VISIT

SET IDENTITY_INSERT dbo.VISIT OFF
DELETE FROM dbo.VISIT




/*-------------------------------------------------------------------
*	TEST SCRIPT FOR VISIT_CLICKS TABLE (PASSES)
*/-------------------------------------------------------------------
DELETE FROM dbo.VISIT_CLICKS

SET IDENTITY_INSERT dbo.VISIT_CLICKS ON
INSERT INTO dbo.VISIT_CLICKS([click_id], [visit_id], [click_tstamp], [currentpage], [nextpage], [x], [y])
VALUES 
(1,1, '2018-06-23 07:30:21', '1', '2', 5, 3),
(2,2,'2015-06-23 04:30:21','1','3',2,6),
(3,3, '2013-06-23 07:30:21', '1', '2', 5, 3),
(4,4,'2012-06-23 04:30:21','1','3',2,6),
(5,5, '2011-06-23 07:30:21', '1', '2', 5, 3),
(6,6,'2010-06-23 04:30:21','1','3',2,6);

SELECT * FROM dbo.VISIT_CLICKS

SET IDENTITY_INSERT dbo.VISIT_CLICKS OFF
DELETE FROM dbo.VISIT_CLICKS




/*-------------------------------------------------------------------
*	TEST SCRIPT FOR CLICK_RESPONSE TABLE (PASSES)
*/-------------------------------------------------------------------
DELETE FROM dbo.CLICK_RESPONSE

INSERT INTO dbo.CLICK_RESPONSE([click_id], [tstamp], [response_code], [message])
VALUES 
(1, '2018-06-23 07:30:21', 1, 'Example message'),
(2,'2015-06-23 04:30:21', 2, 'Example message'),
(3, '2013-06-23 07:30:21', 3, 'Example message'),
(4,'2012-06-23 04:30:21', 4, 'Example message'),
(5, '2011-06-23 07:30:21', 5, 'Example message'),
(6,'2010-06-23 04:30:21', 6, 'Example message');


SELECT* FROM dbo.CLICK_RESPONSE;


DELETE FROM dbo.CLICK_RESPONSE;





/*-------------------------------------------------------------------
*	TEST SCRIPT FOR CART TABLE (PASSES)
*/-------------------------------------------------------------------
DELETE FROM dbo.CART

SET IDENTITY_INSERT dbo.CART ON;
INSERT INTO dbo.CART ([cart_id], [tstamp], [visit_id], [purchased], [purch_timestamp])
VALUES
(1,'2015-06-23 04:30:21', 1,  1, '2015-06-23 04:30:21'),
(2,'2015-06-23 04:30:21', 2,  1, '2015-06-23 04:30:21'),
(3,'2015-06-23 04:30:21', 3,  0, '2015-06-23 04:30:21'),
(4,'2015-06-23 04:30:21', 4,  0, '2015-06-23 04:30:21'),
(5,'2015-06-23 04:30:21', 5,  1, '2015-06-23 04:30:21'),
(6,'2015-06-23 04:30:21', 6,  0, '2015-06-23 04:30:21');

SELECT * FROM dbo.CART

SET IDENTITY_INSERT dbo.CART OFF
DELETE FROM dbo.CART







/*-------------------------------------------------------------------
*	TEST SCRIPT FOR CART_ITEM TABLE (PASSES)
*/-------------------------------------------------------------------
DELETE FROM dbo.CART_ITEM

SET IDENTITY_INSERT dbo.CART_ITEM ON
INSERT INTO dbo.CART_ITEM([cart_item_id], [cart_id], [cart_tstamp], [item], [tstamp], [quantity], [removed], [cost])
VALUES 
(1, 1, '2015-06-23 04:30:21', 'Item1', '2018-06-23 07:30:21', 2, 0, 23.24),
(2, 2,'2015-06-23 04:30:21', 'Item2', '2015-06-23 04:30:21', 3, 0, 12.23),
(3, 3,'2015-06-23 04:30:21', 'Item3', '2013-06-23 07:30:21', 1, 0,  12.23),
(4, 4,'2015-06-23 04:30:21', 'Item4', '2012-06-23 04:30:21', 2, 0, 11.12),
(5, 5, '2015-06-23 04:30:21', 'Item5', '2011-06-23 07:30:21', 1, 0, 9.23),
(6, 6,'2015-06-23 04:30:21', 'Item6', '2010-06-23 04:30:21', 1, 0, 4.52);

SELECT* FROM dbo.CART_ITEM;

SET IDENTITY_INSERT dbo.CART_ITEM OFF
DELETE FROM dbo.CART_ITEM;


/*--------------------------------------------------------------------------------------------------------------
*
* FAILING SCRIPTS BELOW
*
*/-------------------------------------------------------------------------------------------------------------
SET IDENTITY_INSERT dbo.VISIT ON
INSERT INTO dbo.VISIT ([visit_id], [ip], [tstamp], [origin], [device_source])
VALUES 
(1,1921682324,'2018-06-23 07:30:21','Original1','PC'),
(2,191232823,3,'Original2','Mobile Phone'),
(3,1921682324,4,'Original3',9),
(4,191232823,'2019-06-23 07:30:20','Original4',7),
(5,191232823,'2019-06-23 07:30:20','Original5','Mobile Phone'),
(6,191232823,'2019-06-23 07:30:20','Original6',5);

SET IDENTITY_INSERT dbo.VISIT OFF



/*-------------------------------------------------------------------
*	TEST SCRIPT FOR VISIT_CLICKS TABLE (FAILS)
*/-------------------------------------------------------------------
DELETE FROM dbo.VISIT_CLICKS

SET IDENTITY_INSERT dbo.VISIT_CLICKS ON
INSERT INTO dbo.VISIT_CLICKS([click_id], [visit_id], [click_tstamp], [currentpage], [nextpage], [x], [y])
VALUES 
(1,1, 'wwwwwww', '1', 'qwert', 5, 3),
(2,2,'2015-06-23 04:30:21','1','qere',2,6),
(3,3, '2013-06-23 07:30:21', '1', 'wewew', 5, 3),
(4,4,'2012-06-23 04:30:21','1','3',2,6),
(5,5, '2011-06-23 07:30:21', '1', '2', 5, 3),
(6,6,'04:30:21','1','3',2,6);

SET IDENTITY_INSERT dbo.VISIT_CLICKS OFF

/*-------------------------------------------------------------------
*	TEST SCRIPT FOR CLICK_RESPONSE TABLE (FAILS)
*/-------------------------------------------------------------------
DELETE FROM dbo.CLICK_RESPONSE

INSERT INTO dbo.CLICK_RESPONSE([click_id], [tstamp], [response_code], [message])
VALUES 
(1, '2018-06-23', 9, 'Example message'),
(2,'2015-06-23 04:30:21', 4, 'Example message'),
('third', '2013-06-23 07:30:21', 3, 'Example message'),
(4,'2012-06-23 04:30:21', 4, 'Example message'),
(5, '2011-06-23 07:30:21', 5, 'Example message'),
(6,'2010-06-23 04:30:21', 6, 'Example message');


/*------------------------------------------------------------------
*	TEST SCRIPT FOR CART TABLE (FAILS)
*/-------------------------------------------------------------------
DELETE FROM dbo.CART;

SET IDENTITY_INSERT dbo.CART ON;
INSERT INTO dbo.CART ([cart_id], [tstamp], [visit_id], [purchased], [purch_timestamp])
VALUES
(1,'2015-06-23 04:30:21', 1,  1, '2015-06-23 04:30:21'),
(2,'2015-06-23 0:21', 2,  1, '2015-06-23 04:30:21'),
(3,'2015-06-22 0:21', 3,  0, '2015-06-23 04:30:21'),
(4,'2015-06-23 04:30:21', 4,  0, '2015-06-23 04:30:21'),
(5,'2015-06-23 04:30:21', 5,  3, '2015-06-23 04:30:21'),
(6,'2015-06-23 04:30:21', 6,  'true', '2015-06-23 04:30:21');

SET IDENTITY_INSERT dbo.CART OFF


/*-------------------------------------------------------------------
*	TEST SCRIPT FOR CART_ITEM TABLE (FAILS)
*/-------------------------------------------------------------------
DELETE FROM dbo.CART_ITEM

SET IDENTITY_INSERT dbo.CART_ITEM ON
INSERT INTO dbo.CART_ITEM([cart_item_id], [cart_id], [cart_tstamp], [item], [tstamp], [quantity], [removed], [cost])
VALUES 
(1, 1, '2015-06-23 04:30:21', 1, '2018-06-23 07:30:21', 2, 0, 23.24),
(2, 2,'2015-06-23', 'orange', '2015-06-23 04:30:21', 3, 0, 12.23),
(3, 3,'2015-06-23 04:30:21', 'Item3', '2013-06-23 07:30:21', 1, 0,  12.23),
(4, 4,'2015-06-23 04:30:21', 'Item4', '2012-06-23 04:30:21', null, 0, 11.12),
(5, 5, '2015-06-23 04:30:21', 'Item5', '2011-06-23 07:30:21', 1, 0, 9.23),
(6, 6,'2015-06-23 04:30:21', null, '2010-06-23 04:30:21', 1, 0, 4.52);


SET IDENTITY_INSERT dbo.CART_ITEM OFF

-- Finished Testing? Use this order to delete quickly
DELETE FROM dbo.CART_ITEM;
DELETE FROM dbo.CART;
DELETE FROM dbo.CLICK_RESPONSE;
DELETE FROM dbo.VISIT_CLICKS;
DELETE FROM dbo.VISIT;

