-- Create DEPT table
create table DEPT (
    DeptNo INT PRIMARY KEY,
    DName VARCHAR(20) not null,
    Loc VARCHAR(20) not null
);

insert into DEPT values
(10, 'ACCOUNTING', 'NEW YORK'),
(20, 'RESEARCH', 'DALLAS'),
(30, 'SALES', 'CHICAGO'),
(40, 'OPERATIONS', 'BOSTON');

--Create EMP table
create table EMP (
    EmpNo INT PRIMARY KEY,
    EName VARCHAR(20) not null,
    Job VARCHAR(20) not null,
    Mgr INT,
    HireDate DATE,
    Sal DECIMAL not null,
    Comm DECIMAL,
    DeptNo INT FOREIGN KEY REFERENCES DEPT(DeptNo)
);

insert into EMP values
(7369, 'SMITH', 'CLERK', 7902, '1980-12-17', 800, null, 20),
(7499, 'ALLEN', 'SALESMAN', 7698, '1981-02-20', 1600, 300, 30),
(7521, 'WARD', 'SALESMAN', 7698, '1981-02-22', 1250, 500, 30),
(7566, 'JONES', 'MANAGER', 7839, '1981-04-02', 2975, null, 20),
(7654, 'MARTIN', 'SALESMAN', 7698, '1981-09-28', 1250, 1400, 30),
(7698, 'BLAKE', 'MANAGER', 7839, '1981-05-01', 2850, null, 30),
(7782, 'CLARK', 'MANAGER', 7839, '1981-06-09', 2450, null, 10),
(7788, 'SCOTT', 'ANALYST', 7566, '1987-04-19', 3000, null, 20),
(7839, 'KING', 'PRESIDENT', null, '1981-11-17', 5000, null, 10),
(7844, 'TURNER', 'SALESMAN', 7698, '1981-09-08', 1500, 0, 30),
(7876, 'ADAMS', 'CLERK', 7788, '1987-05-23', 1100, null, 20),
(7900, 'JAMES', 'CLERK', 7698, '1981-12-03', 950, null, 30),
(7902, 'FORD', 'ANALYST', 7566, '1981-12-03', 3000, null, 20),
(7934, 'MILLER', 'CLERK', 7782, '1982-01-23', 1300, null, 10);

-- 1
select * from EMP where EName like 'A%';

-- 2
select * from EMP where Mgr is null;

-- 3
select EmpNo, EName, Sal from EMP where Sal between 1200 and 1400;

-- 4
select * from EMP where DeptNo = 20; 
update EMP set Sal = Sal * 1.10 where DeptNo = 20;
select * from EMP where DeptNo = 20;

-- 5
select count(*) as Num_Clerks from EMP where Job = 'CLERK';

-- 6.
select Job, AVG(Sal) as Avg_Salary, COUNT(*) as Num_Employees from EMP group by Job;

-- 7
select * from EMP where Sal = (select MIN(Sal) from EMP)
union
select * from EMP where Sal = (select MAX(Sal) from EMP);

-- 8
select * from DEPT where DeptNo not in (select distinct DeptNo from EMP);

-- 9
select EName, Sal from EMP where Job = 'ANALYST' and Sal > 1200 and DeptNo = 20 order by EName asc;

-- 10
select D.DName, D.DeptNo, SUM(E.Sal) as Total_Salary
from DEPT D
join EMP E on D.DeptNo = E.DeptNo
group by D.DName, D.DeptNo;

-- 11
select EName, Sal from EMP where EName in ('MILLER', 'SMITH');

-- 12
select * from EMP where EName like 'A%' or EName like 'M%';

-- 13
select EName, Sal * 12 as Yearly_Salary from EMP where EName = 'SMITH';

-- 14
select EName, Sal from EMP where Sal not between 1500 and 2850;

-- 15
select Mgr, COUNT(*) as Num_Reports
from EMP
where Mgr is not null
group by Mgr
having count(*) > 2;
