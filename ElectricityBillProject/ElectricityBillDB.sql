create database EBDB

use EBDB

create table Admins (
    AdminID int identity primary key,
    Username nvarchar(50) unique,
    Password nvarchar(50)
);

create table Bills (
    BillNo int identity primary key,
    ConsumerNo nvarchar(20) not null,
    ConsumerName nvarchar(100) not null,
    Units int not null,
    Amount float not null,
    BillDate datetime default getdate()
);



insert into Admins values ('admin','admin123');
select * from Bills
