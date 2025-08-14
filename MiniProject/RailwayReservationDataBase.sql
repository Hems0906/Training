

create table Admins (
    AdminID int primary key identity(1,1),
    Username nvarchar(50) unique not null,
    Password nvarchar(100) not null
);


create table Customers (
    CustId int primary key identity(1,1),
    CustName nvarchar(100) not null,
    Phone nvarchar(15) not null,
    MailId nvarchar(100) not null,
    Password nvarchar(100) not null
);

create table Trains (
    TrainNo int primary key,
    TrainName nvarchar(100) not null,
    Source nvarchar(100) not null,
    Destination nvarchar(100) not null,
    DepartureTime time not null,
    ArrivalTime time not null
);

-- Drop in reverse dependency order
DROP TABLE IF EXISTS Reservations;
DROP TABLE IF EXISTS Customers;
DROP TABLE IF EXISTS Trains;
DROP TABLE IF EXISTS Admins;


create table Reservations (
    BookingId int primary key identity(1,1),
    CustId int foreign key references Customers(CustId),
    TrainNo int foreign key references Trains(TrainNo),
    TravelDate date not null,
    Class nvarchar(20) not null,
    TotalCost decimal(10, 2) not null,
    BookingDate datetime default getdate(),
    Status nvarchar(20) not null,
    WaitingNumber int null
);

create table Cancellations (
    CancelId int primary key identity(1,1),
    BookingId int foreign key references Reservations(BookingId),
    CancelDate datetime default getdate(),
    RefundAmount decimal(10, 2) not null
);

-- Insert default admin
insert into Admins (Username, Password) values ('admin', 'admin123');

-- Additional reporting stored procedures
create procedure sp_GetTrainReport
as
begin
    select 
        t.TrainNo,
        t.TrainName,
        t.Source,
        t.Destination,
        t.Class,
        t.Availability,
        t.Cost,
        convert(varchar(8), t.DepartureTime, 108) as DepartureTime,
        convert(varchar(8), t.ArrivalTime, 108) as ArrivalTime,
        count(r.BookingId) as TotalBookings,
        sum(case when r.Status = 'Confirmed' then 1 else 0 end) as ConfirmedBookings,
        sum(case when r.Status = 'Waiting' then 1 else 0 end) as WaitingList
    from 
        Trains t
    left join 
        Reservations r on t.TrainNo = r.TrainNo
    group by
        t.TrainNo, t.TrainName, t.Source, t.Destination, t.Class, t.Availability, 
        t.Cost, t.DepartureTime, t.ArrivalTime
    order by
        t.TrainNo;
end;

create procedure sp_GetTicketReport
    @FromDate date = null,
    @ToDate date = null
as
begin
    if @FromDate is null set @FromDate = dateadd(month, -1, getdate())
    if @ToDate is null set @ToDate = getdate()

    select 
        r.BookingId,
        c.CustName,
        t.TrainName,
        r.TravelDate,
        r.Class,
        r.TotalCost,
        r.BookingDate,
        r.Status,
        r.WaitingNumber
    from 
        Reservations r
    join 
        Customers c on r.CustId = c.CustId
    join 
        Trains t on r.TrainNo = t.TrainNo
    where 
        r.BookingDate between @FromDate and @ToDate
    order by 
        r.BookingDate desc;
end;

create procedure sp_GetCancellationReport
    @FromDate date = null,
    @ToDate date = null
as
begin
    if @FromDate is null set @FromDate = dateadd(month, -1, getdate())
    if @ToDate is null set @ToDate = getdate()

    select 
        cn.CancelId,
        r.BookingId,
        c.CustName,
        t.TrainName,
        cn.CancelDate,
        r.TotalCost as OriginalAmount,
        cn.RefundAmount,
        (r.TotalCost - cn.RefundAmount) as CancellationCharges
    from 
        Cancellations cn
    join 
        Reservations r on cn.BookingId = r.BookingId
    join 
        Customers c on r.CustId = c.CustId
    join 
        Trains t on r.TrainNo = t.TrainNo
    where 
        cn.CancelDate between @FromDate and @ToDate
    order by 
        cn.CancelDate desc;
end;

select * from Trains

SELECT COLUMN_NAME, DATA_TYPE 
FROM INFORMATION_SCHEMA.COLUMNS 
WHERE TABLE_NAME = 'Trains'
ORDER BY ORDINAL_POSITION;

drop table Trains


ALTER TABLE Trains
ADD 
    AvailabilityAC INT DEFAULT 0,
    Availability2AC INT DEFAULT 0,
    Availability3AC INT DEFAULT 0,
    AvailabilitySleeper INT DEFAULT 0,
    CostAC DECIMAL(18,2) DEFAULT 0,
    Cost2AC DECIMAL(18,2) DEFAULT 0,
    Cost3AC DECIMAL(18,2) DEFAULT 0,
    CostSleeper DECIMAL(18,2) DEFAULT 0;

	DROP TABLE IF EXISTS Trains;
	-- Find constraints pointing to Trains
SELECT 
    fk.name AS ForeignKeyName,
    tp.name AS ParentTable
FROM sys.foreign_keys fk
JOIN sys.tables tp ON fk.parent_object_id = tp.object_id
JOIN sys.tables tr ON fk.referenced_object_id = tr.object_id
WHERE tr.name = 'Trains';

-- Drop them (replace with actual FK names found above)
ALTER TABLE Reservation DROP CONSTRAINT FK_Reservation_Trains;
ALTER TABLE Cancellation DROP CONSTRAINT FK_Cancellation_Trains;
