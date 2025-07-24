--1NF
create table ClientRental_1NF (
    clientNo varchar(10),
    cName varchar(50),
    propertyNo varchar(10),
    pAddress varchar(100),
    rentStart date,
    rentFinish date,
    rent int,
    ownerNo varchar(10),
    oName varchar(50)
);
insert into ClientRental_1NF values 
('CR676', 'John Kay', 'PG4', '6 Lawrence St, Glasgow', '2000-07-01', '2001-08-31', 350, 'C040', 'Tina Murphy'),
('CR676', 'John Kay', 'PG16', '5 Novar Dr, Glasgow', '2002-09-01', '2002-09-01', 450, 'C093', 'Tony Shaw'),
('CR856', 'Aline Stewart', 'PG4', '6 Lawrence St, Glasgow', '1999-09-01', '2000-06-10', 350, 'C040', 'Tina Murphy'),
('CR856', 'Aline Stewart', 'PG36', '2 Manor Rd, Glasgow', '2000-10-10', '2001-12-01', 370, 'C093', 'Tony Shaw'),
('CR856', 'Aline Stewart', 'PG16', '5 Novar Dr, Glasgow', '2002-11-01', '2003-08-01', 450, 'C093', 'Tony Shaw');

--2NF

create table Clients_2NF (
    clientNo varchar(10) primary key,
    cName varchar(50)
);
insert into Clients_2NF values
('CR676', 'John Kay'),
('CR856', 'Aline Stewart');


create table Properties_2NF (
    propertyNo varchar(10) primary key,
    pAddress varchar(100)
);
insert into Properties_2NF values
('PG4', '6 Lawrence St, Glasgow'),
('PG16', '5 Novar Dr, Glasgow'),
('PG36', '2 Manor Rd, Glasgow');

create table Rentals_2NF (
    clientNo varchar(10) foreign key references Clients_2NF(clientNo),
    propertyNo varchar(10) foreign key references Properties_2NF(propertyNo),
    rentStart date,
    rentFinish date,
    rent int,
    ownerNo varchar(10),
    oName varchar(50),
    primary key (clientNo, propertyNo, rentStart)
);

insert into Rentals_2NF values
('CR676', 'PG4', '2000-07-01', '2001-08-31', 350, 'C040', 'Tina Murphy'),
('CR676', 'PG16', '2002-09-01', '2002-09-01', 450, 'C093', 'Tony Shaw'),
('CR856', 'PG4', '1999-09-01', '2000-06-10', 350, 'C040', 'Tina Murphy'),
('CR856', 'PG36', '2000-10-10', '2001-12-01', 370, 'C093', 'Tony Shaw'),
('CR856', 'PG16', '2002-11-01', '2003-08-01', 450, 'C093', 'Tony Shaw');

--3NF

create table Owners_3NF (
    ownerNo varchar(10) primary key,
    oName varchar(50)
);

create table Rentals_3NF (
    clientNo varchar(10) foreign key references Clients_2NF(clientNo),
    propertyNo varchar(10) foreign key references Properties_2NF(propertyNo),
    rentStart date,
    rentFinish date,
    rent int,
    ownerNo varchar(10) foreign key references Owners_3NF(ownerNo),
    primary key (clientNo, propertyNo, rentStart)
);

insert into Owners_3NF values
('C040', 'Tina Murphy'),
('C093', 'Tony Shaw');

insert into Rentals_3NF values
('CR676', 'PG4', '2000-07-01', '2001-08-31', 350, 'C040'),
('CR676', 'PG16', '2002-09-01', '2002-09-01', 450, 'C093'),
('CR856', 'PG4', '1999-09-01', '2000-06-10', 350, 'C040'),
('CR856', 'PG36', '2000-10-10', '2001-12-01', 370, 'C093'),
('CR856', 'PG16', '2002-11-01', '2003-08-01', 450, 'C093');


create view Final_Rental_View2 as
select 
    c.clientNo,
    c.cName,
    p.propertyNo,
    p.pAddress,
    format(r.rentStart, 'dd-MMM-yyyy') as rentStart,
    format(r.rentFinish, 'dd-MMM-yyyy') as rentFinish,
    r.rent,
    o.ownerNo,
    o.oName
from Rentals_3NF r
join Clients_2NF c on r.clientNo = c.clientNo
join Properties_2NF p on r.propertyNo = p.propertyNo
join Owners_3NF o on r.ownerNo = o.ownerNo;

select * from Final_Rental_View2;
