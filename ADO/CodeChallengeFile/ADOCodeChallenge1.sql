--1 Question

create or alter procedure insert_employee
    @name varchar(100),
    @givensalary decimal(10,2),
    @gender varchar(10),
    @newempid int output,
    @salary decimal(10,2) output,
    @netsalary decimal(10,2) output
as
begin
    insert into employee_details(name, givensalary, gender)
    values(@name, @givensalary, @gender);

    select @newempid = SCOPE_IDENTITY();

    select 
        @salary = salary, 
        @netsalary = netsalary 
    from employee_details 
    where empid = @newempid;
end;

select * from employee_details;

exec insert_employee 
    @name = 'Hem', 
    @givensalary = 20000, 
    @gender = 'Male', 
    @newempid = NULL, 
    @salary = NULL, 
    @netsalary = NULL;

	--2 Question

	create or alter procedure update_employee_salary
    @empid int,
    @updatedsalary decimal(10,2) output,
    @updatednetsalary decimal(10,2) output
as
begin

    update employee_details
    set givensalary = givensalary + 100
    where empid = @empid;

    select 
        @updatedsalary = givensalary,
        @updatednetsalary = givensalary - (givensalary * 0.10)
    from employee_details
    where empid = @empid;
end;
