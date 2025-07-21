use Assignment

drop table if EXISTS Student;

create table Student (
    sid int primary key,
    sname varchar(20)
);

-- Inserting into Student table
insert into Student values
(1, 'Jack'),
(2, 'Rithvik'),
(3, 'Jaspreeth'),
(4, 'Praveen'),
(5, 'Bisa'),
(6, 'Suraj');

-- Displaying Student table
select * from Student;

create table Marks (
    mid int primary key,
    sid int references Student(sid),
    score int NOT NULL
);

-- Inserting into Marks table
insert into Marks values
(1, 1, 23),
(2, 6, 95),
(3, 4, 98),
(4, 2, 17),
(5, 3, 53),
(6, 5, 13);

-- Displaying Marks table
select * from Marks;

declare @n int = 5, @num int, @result int = 1;
set @num = @n;

while (@n > 0)
begin
    set @result = @result * @n;
    set @n = @n - 1;
end;

print 'Factorial of ' + CAST(@num as varchar(20)) + ' is ' + CAST(@result as varchar(20));
select @num as Number, @result as Factorial;

create or alter procedure sp_MultyTable @num int
as
begin
    declare @i int = 1;
    while (@i <= 10)
    begin
        print cast(@num as varchar(10)) + ' * ' + cast(@i as varchar(10)) + ' = ' + cast(@num * @i as varchar(10));
        set @i = @i + 1;
    end
end;

-- Executing the stored procedure
declare @n int = 5;
print 'The Multiplication Table is:';
exec sp_MultyTable @n;


create or alter function dbo.Calculate(@score int)
returns varchar(10)
as
begin
    return (
        case 
            when @score >= 50 then 'Pass'
            else 'Fail'
        end
    );
end;

select 
    s.sid, 
    s.sname, 
    m.score, 
    dbo.Calculate(m.score) as Result
from 
    Student s
join 
    Marks m on s.sid = m.sid;


