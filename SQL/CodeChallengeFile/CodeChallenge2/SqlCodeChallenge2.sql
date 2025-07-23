
create table Department
( Deptid int primary key,
DeptName varchar(30) not null,
DeptBudget float )
 
insert into Department values(2,'HR',15000),(4,'Operations',20000),
(1,'Accounts',10000),(3,'Admin',50000), (5,'Testing',12000)
 
select * from department

create table Employee
(EmpId int not null,
 EmpName varchar(50) not null,
 Gender char(7),
 Salary decimal,
 DepartmentId int references Department(deptid),
 Phone varchar(20),
 Doj date)

 insert into Employee (EmpId, EmpName, Gender, Salary, DepartmentId, Phone, Doj) values
(100, 'Vidushi', 'Female', 6560, 3, NULL, '2018-07-15'),
(101, 'Akhilesh', 'Male', 6510, 2, '12345', '2020-07-10'),
(102, 'Hemachandra', 'Male', 6710, 1, '88777', '2019-07-01'),
(103, 'Adithya', 'Male', 6510, 2, '212345', '2021-07-09'),
(104, 'PoornA', 'Female', 6510, 1, '333333', '2022-03-15'),
(105, 'Shreya', 'Female', 6460, NULL, '7777', '2017-07-05'),
(106, 'Syam', 'Male', 6560, 3, '334455', '2024-01-01'),
(107, 'Hari', NULL, 6300, NULL, '222222', '2016-07-23'),
(108, 'Taraka Lakshmi', 'Female', 6550, 1, '776655', '2020-10-10'),
(109, 'Banurekha', 'Female', 6250, 1, '34343434', '2015-07-01')

create table Employee3 (
    EmpId int not null primary key,
    EmpName varchar(50) not null,
    Gender char(7),
    Salary decimal,
    DepartmentId int references Department(deptid),
    Phone varchar(20),
    Doj date
);

insert into Employee3 (EmpId, EmpName, Gender, Salary, DepartmentId, Phone, Doj) values
(201, 'Kiran', 'Male', 1200, 10, '9999988888', '2021-05-10'),
(202, 'Meena', 'Female', 1400, 10, '8888877777', '2020-07-15'),
(203, 'Ravi', 'Male', 5000, 2, '7777766666', '2019-08-20'),
(204, 'Divya', 'Female', 7500, 4, '6666655555', '2018-09-25'),
(205, 'Arun', 'Male', 1000, 10, '5555544444', '2022-10-10'),
(206, 'Sneha', 'Female', 1800, 3, '4444433333', '2017-11-12');




--1.	Write a query to display your birthday( day of week)
select datename(weekday, '2004-01-09') as TheDayOfBorn
    
--2.	Write a query to display your age in days
select datediff(day, cast('2004-01-09' as date), getdate()) as ageindays

--3.	Write a query to display all employees information those who joined before 5 years in the current month
 select * from employee 
where datediff(year, doj, getdate()) >= 5 
and month(doj) = month(getdate())


--4.Create table Employee with empno, ename, sal, doj columns or use your emp table and perform the following operations in a single transaction

create table employee2
(empno int primary key, ename varchar(30), sal float, doj date)

begin transaction
--	a. First insert 3 rows 
insert into employee2 values (1, 'Karthik', 10000, '2019-06-01'),
                            (2, 'Preethi', 15000, '2020-07-01'),
                            (3, 'Sanjay', 12000, '2021-08-01')

--	b. Update the second row sal with 15% increment  
update employee2 set sal = sal + (sal * 0.15) where empno = 2

save transaction BeforeDelete

--  c. Delete first row.
delete from employee2 where empno = 1

--  After completing above all actions, recall the deleted row without losing increment of second row.

rollback transaction BeforeDelete
commit
select * from employee2


--5.      Create a user defined function calculate Bonus for all employees of a  given dept using 	following conditions
--	a.     For Deptno 10 employees 15% of sal as bonus.
--	b.     For Deptno 20 employees  20% of sal as bonus
--	c      For Others employees 5%of sal as bonus

create function fn_bonus2 (@deptid int, @sal float)
returns float
as
begin
declare @bonus float

if @deptid = 10
 set @bonus = @sal * 0.15
else if @deptid = 20
 set @bonus = @sal * 0.20
else
 set @bonus = @sal * 0.05

return @bonus
end

select empname, salary, dbo.fn_bonus2(departmentid, salary) as Bonus from employee

insert into Department values (10, 'Sales', 30000)

update Employee set DepartmentId = 10 where EmpId = 104




-- 6. Create a procedure to update the salary of employee by 500 whose dept name is Sales and current salary is below 1500 (use emp table)

create procedure sp_update_sales
as
begin
 update employee3
 set salary = salary + 500
 where departmentid in (select deptid from department where deptname = 'Sales')
 and salary < 1500
end
exec sp_update_sales

select * from employee3;


