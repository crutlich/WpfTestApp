INSERT INTO dbo.Manager
values('������ ����'),
	  ('������ ������');

INSERT INTO dbo.Client_status
values('�������� ������'),
	  ('������� ������');

INSERT INTO dbo.Product
values('Word',5000,'��������','�����'),
	  ('Excel',3000,'���������� ��������',NULL),
	  ('Project',7000,'��������','���')



--DELETE FROM dbo.Client
--DBCC CHECKIDENT ('dbo.Client',RESEED, 0)

INSERT INTO dbo.Client
values('���','������ ������',1,1),
('��','��� Random Company',2,2),
('���','�������� ������',1,1),
('��','��� NoName Company',2,2),
('���','���� �����',1,1),
('��','Microsoft',2,2);

INSERT INTO dbo.ClientsProducts
values(1,1),
(1,2),
(2,1),
(3,3),
(4,2),
(5,3),
(6,1);