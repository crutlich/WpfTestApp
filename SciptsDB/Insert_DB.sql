INSERT INTO dbo.Manager
values('Иванов Петр'),
	  ('Волков Сергей');

INSERT INTO dbo.Client_status
values('Ключевой клиент'),
	  ('Обычный клиент');

INSERT INTO dbo.Product
values('Word',5000,'Подписка','месяц'),
	  ('Excel',3000,'Постоянная лицензия',NULL),
	  ('Project',7000,'Подписка','год')



--DELETE FROM dbo.Client
--DBCC CHECKIDENT ('dbo.Client',RESEED, 0)

INSERT INTO dbo.Client
values('физ','Виктор Резнов',1,1),
('юр','ООО Random Company',2,2),
('физ','Владимир Пушкин',1,1),
('юр','ООО NoName Company',2,2),
('физ','Билл Гейтс',1,1),
('юр','Microsoft',2,2);

INSERT INTO dbo.ClientsProducts
values(1,1),
(1,2),
(2,1),
(3,3),
(4,2),
(5,3),
(6,1);