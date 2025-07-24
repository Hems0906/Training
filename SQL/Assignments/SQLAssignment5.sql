--1
create procedure sp_generate_payslip
    @EmpNo int
as
begin
    declare 
        @Ename varchar(50),
        @Job varchar(50),
        @Salary decimal(10,2),
        @HRA decimal(10,2),
        @DA decimal(10,2),
        @PF decimal(10,2),
        @IT decimal(10,2),
        @Deductions decimal(10,2),
        @GrossSalary decimal(10,2),
        @NetSalary decimal(10,2);


    select 
        @Ename = Ename,
        @Job = Job,
        @Salary = Salary
    from Employees
    where Empno = @EmpNo;

    if @Salary IS NULL
    begin
        print 'Invalid Employee Number.';
        return;
    end

    -- Calculate salary components
    set @HRA = 0.10 * @Salary;
    set @DA = 0.20 * @Salary;
    set @PF = 0.08 * @Salary;
    set @IT = 0.05 * @Salary;
    set @Deductions = @PF + @IT;
    set @GrossSalary = @Salary + @HRA + @DA;
    set @NetSalary = @GrossSalary - @Deductions;

    -- Display Payslip
    print '---------------- EMPLOYEE PAYSLIP ----------------';
    print 'Employee No   : ' + cast(@EmpNo as varchar);
    print 'Employee Name : ' + @Ename;
    print 'Job Role      : ' + @Job;
    print '-----------------------------------------------';
    print 'Basic Salary  : Rs. ' + cast(@Salary as varchar);
    print 'HRA (10%)     : Rs. ' + cast(@HRA as varchar);
    print 'DA (20%)      : Rs. ' + cast(@DA as varchar);
    print 'Gross Salary  : Rs. ' + cast(@GrossSalary as varchar);
    print '-----------------------------------------------';
    print 'PF (8%)       : Rs. ' + cast(@PF as varchar);
    print 'IT (5%)       : Rs. ' + cast(@IT as varchar);
    print 'Deductions    : Rs. ' + cast(@Deductions as varchar);
    print '-----------------------------------------------';
    print 'Net Salary    : Rs. ' + cast(@NetSalary as varchar);
    print '-----------------------------------------------';
end

exec sp_generate_payslip @EmpNo = 7001;

--2

create table holidays (
    holiday_date date primary key,
    holiday_name varchar(50)
);

insert into holidays values
('2025-08-15', 'independence day'),
('2025-10-23', 'diwali'),
('2025-01-26', 'republic day'),
('2025-12-25', 'christmas');

create trigger trg_restrict_on_holiday
on employees
after insert, update, delete
as
begin
    declare @today date = cast(getdate() as date);
    declare @holiday_name varchar(50);

    select @holiday_name = holiday_name 
    from holidays
    where holiday_date = @today;

    if @holiday_name is not null
    begin
        raiserror('due to %s, you cannot manipulate data.', 16, 1, @holiday_name);
        rollback transaction;
    end
end

insert into holidays values (cast(getdate() as date), 'test day');

insert into employees values (7013, 'naveen', 'intern', 18000, 10);

--delete from holidays where holiday_name = 'test day';

