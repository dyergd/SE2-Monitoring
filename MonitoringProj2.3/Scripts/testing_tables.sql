/*
*	TEST SCRIPT FOR VISIT TABLE - (PASSES)
*/-------------------------------------------------------------------
DELETE FROM dbo.VISITS

SET IDENTITY_INSERT dbo.VISITS ON
INSERT INTO dbo.VISITS ([Id], [Ip], [Timestamp], [Origin], [DeviceSource])
VALUES 
(1,1921682324,'2018-06-23 07:30:21','Original1','PC'),
(2,191232823,'2019-06-23 07:30:20','Original2','Mobile Phone'),
(3,1921682324,'2017-06-23 07:30:21','Original3','Mobile Phone'),
(4,191232823,'2019-06-23 07:30:20','Original4','PC'),
(5,191232823,'2019-06-23 07:30:20','Original5','Mobile Phone'),
(6,191232823,'2019-06-23 07:30:20','Original6','PC');

SELECT * FROM dbo.VISITS

SET IDENTITY_INSERT dbo.VISITS OFF
DELETE FROM dbo.VISITS




/*-------------------------------------------------------------------
*	TEST SCRIPT FOR VISIT_CLICKS TABLE (PASSES)
*/-------------------------------------------------------------------
DELETE FROM dbo.VISITCLICKS

SET IDENTITY_INSERT dbo.VISITCLICKS ON
INSERT INTO dbo.VISITCLICKS([Id], [VisitID], [ClickTimestamp], [CurrentPage], [NextPage], [X], [Y])
VALUES 
(1,1, '2018-06-23 07:30:21', '1', '2', 5, 3),
(2,2,'2015-06-23 04:30:21','1','3',2,6),
(3,3, '2013-06-23 07:30:21', '1', '2', 5, 3),
(4,4,'2012-06-23 04:30:21','1','3',2,6),
(5,5, '2011-06-23 07:30:21', '1', '2', 5, 3),
(6,6,'2010-06-23 04:30:21','1','3',2,6);

SELECT * FROM dbo.VISITCLICKS

SET IDENTITY_INSERT dbo.VISITCLICKS OFF
DELETE FROM dbo.VISITCLICKS




/*-------------------------------------------------------------------
*	TEST SCRIPT FOR CLICK_RESPONSE TABLE (PASSES)
*/-------------------------------------------------------------------
DELETE FROM dbo.VISITRESPONSES

SET IDENTITY_INSERT dbo.VISITRESPONSES ON;
INSERT INTO dbo.VISITRESPONSES([Id], [Timestamp], [ResponseCode], [Message])
VALUES 
(1, '2018-06-23 07:30:21', 1, 'Example message'),
(2,'2015-06-23 04:30:21', 2, 'Example message'),
(3, '2013-06-23 07:30:21', 3, 'Example message'),
(4,'2012-06-23 04:30:21', 4, 'Example message'),
(5, '2011-06-23 07:30:21', 5, 'Example message'),
(6,'2010-06-23 04:30:21', 6, 'Example message');


SELECT* FROM dbo.VISITRESPONSES;
SET IDENTITY_INSERT dbo.VISITRESPONSES OFF;

DELETE FROM dbo.VISITRESPONSES;





/*-------------------------------------------------------------------
*	TEST SCRIPT FOR CART TABLE (PASSES)
*/-------------------------------------------------------------------
DELETE FROM dbo.CARTS

SET IDENTITY_INSERT dbo.CARTS ON;
INSERT INTO dbo.CARTS ([Id], [Timestamp], [VisitId], [Purchased], [PunchTimestamp], [Items])
VALUES
(1,'2015-06-23 04:30:21', 1,  1, '2015-06-23 04:30:21'),
(2,'2015-06-23 04:30:21', 2,  1, '2015-06-23 04:30:21'),
(3,'2015-06-23 04:30:21', 3,  0, '2015-06-23 04:30:21'),
(4,'2015-06-23 04:30:21', 4,  0, '2015-06-23 04:30:21'),
(5,'2015-06-23 04:30:21', 5,  1, '2015-06-23 04:30:21'),
(6,'2015-06-23 04:30:21', 6,  0, '2015-06-23 04:30:21');

SELECT * FROM dbo.CARTS

SET IDENTITY_INSERT dbo.CARTS OFF
DELETE FROM dbo.CARTS







/*-------------------------------------------------------------------
*	TEST SCRIPT FOR CART_ITEM TABLE (PASSES)
*/-------------------------------------------------------------------
DELETE FROM dbo.CARTITEMS

SET IDENTITY_INSERT dbo.CARTITEMS ON
INSERT INTO dbo.CARTITEMS([Id], [CartId], [Timestamp], [Item], [Quantity], [Removed], [Cost])
VALUES 
(1, 1, '2015-06-23 04:30:21', 'Item1', 2, 0, 23.24),
(2, 2,'2015-06-23 04:30:21', 'Item2', 3, 0, 12.23),
(3, 3,'2015-06-23 04:30:21', 'Item3', 1, 0,  12.23),
(4, 4,'2015-06-23 04:30:21', 'Item4', 2, 0, 11.12),
(5, 5, '2015-06-23 04:30:21', 'Item5', 1, 0, 9.23),
(6, 6,'2015-06-23 04:30:21', 'Item6', 1, 0, 4.52);

SELECT* FROM dbo.CARTITEMS;

SET IDENTITY_INSERT dbo.CARTITEMS OFF
DELETE FROM dbo.CARTITEMS;


/*--------------------------------------------------------------------------------------------------------------
*
* FAILING SCRIPTS BELOW
*
*/-------------------------------------------------------------------------------------------------------------
SET IDENTITY_INSERT dbo.VISITS ON
INSERT INTO dbo.VISITS ([Id], [Ip], [Timestamp], [Origin], [DeviceSource])
VALUES 
(1,1921682324,'2018-06-23 07:30:21','Original1','PC'),
(2,191232823,3,'Original2','Mobile Phone'),
(3,1921682324,4,'Original3',9),
(4,191232823,'2019-06-23 07:30:20','Original4',7),
(5,191232823,'2019-06-23 07:30:20','Original5','Mobile Phone'),
(6,191232823,'2019-06-23 07:30:20','Original6',5);

SET IDENTITY_INSERT dbo.VISITS OFF



/*-------------------------------------------------------------------
*	TEST SCRIPT FOR VISIT_CLICKS TABLE (FAILS)
*/-------------------------------------------------------------------
DELETE FROM dbo.VISITCLICKS

SET IDENTITY_INSERT dbo.VISITCLICKS ON
INSERT INTO dbo.VISITCLICKS([Id], [VisitID], [ClickTimestamp], [CurrentPage], [NextPage], [X], [Y])
VALUES 
(1,1, 'wwwwwww', '1', 'qwert', 5, 3),
(2,2,'2015-06-23 04:30:21','1','qere',2,6),
(3,3, '2013-06-23 07:30:21', '1', 'wewew', 5, 3),
(4,4,'2012-06-23 04:30:21','1','3',2,6),
(5,5, '2011-06-23 07:30:21', '1', '2', 5, 3),
(6,6,'04:30:21','1','3',2,6);

SET IDENTITY_INSERT dbo.VISITCLICKS OFF

/*-------------------------------------------------------------------
*	TEST SCRIPT FOR CLICK_RESPONSE TABLE (FAILS)
*/-------------------------------------------------------------------
DELETE FROM dbo.VISITRESPONSES

INSERT INTO dbo.VISITRESPONSES([Id], [Timestamp], [ResponseCode], [Message])
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
DELETE FROM dbo.CARTS;

SET IDENTITY_INSERT dbo.CARTS ON;
INSERT INTO dbo.CARTS ([Id], [Timestamp], [VisitId], [Purchased], [PunchTimestamp])
VALUES
(1,'2015-06-23 04:30:21', 1,  1, '2015-06-23 04:30:21'),
(2,'2015-06-23 0:21', 2,  1, '2015-06-23 04:30:21'),
(3,'2015-06-22 0:21', 3,  0, '2015-06-23 04:30:21'),
(4,'2015-06-23 04:30:21', 4,  0, '2015-06-23 04:30:21'),
(5,'2015-06-23 04:30:21', 5,  3, '2015-06-23 04:30:21'),
(6,'2015-06-23 04:30:21', 6,  'true', '2015-06-23 04:30:21');

SET IDENTITY_INSERT dbo.CARTS OFF


/*-------------------------------------------------------------------
*	TEST SCRIPT FOR CART_ITEM TABLE (FAILS)
*/-------------------------------------------------------------------
DELETE FROM dbo.CARTITEMS

SET IDENTITY_INSERT dbo.CARTITEMS ON
INSERT INTO dbo.CARTITEMS([Id], [CartId], [Timestamp], [Item], [Quantity], [Removed], [Cost])
VALUES 
(1, 1, '2015-06-23 04:30:21', 1, '2018-06-23 07:30:21', 2, 0, 23.24),
(2, 2,'2015-06-23', 'orange', '2015-06-23 04:30:21', 3, 0, 12.23),
(3, 3,'2015-06-23 04:30:21', 'Item3', '2013-06-23 07:30:21', 1, 0,  12.23),
(4, 4,'2015-06-23 04:30:21', 'Item4', '2012-06-23 04:30:21', null, 0, 11.12),
(5, 5, '2015-06-23 04:30:21', 'Item5', '2011-06-23 07:30:21', 1, 0, 9.23),
(6, 6,'2015-06-23 04:30:21', null, '2010-06-23 04:30:21', 1, 0, 4.52);


SET IDENTITY_INSERT dbo.CARTITEMS OFF

-- Finished Testing? Use this order to delete quickly
DELETE FROM dbo.CARTITEMS;
DELETE FROM dbo.CARTS;
DELETE FROM dbo.VISITRESPONSES;
DELETE FROM dbo.VISITCLICKS;
DELETE FROM dbo.VISITS;

