create database assignmentDb4
use AssignmentDB2

----1.Write a T-SQL Program to find the factorial of a given number.

declare @NumberToCalculateFactorialFor INT = 10
declare @Result BIGINT = 1
declare @Iteration INT = 1

set @Result = 1
set @Iteration = 1

if @NumberToCalculateFactorialFor < 0
    print 'Factorial is not defined for negative numbers'
else if @NumberToCalculateFactorialFor = 0
    print 'The factorial of 0 is 1'
else
begin
    while @Iteration <=  @NumberToCalculateFactorialFor
    begin
        set @Result = @Iteration * @Result
        set @Iteration = @Iteration + 1
    end

    print 'The factorial of ' + cast( @NumberToCalculateFactorialFor AS VARCHAR(10)) + ' is ' + cast(@Result AS VARCHAR(50))
END

------2.

create or alter procedure MultiplicationTable
    @MaxMultiplier INT
as
begin 
    declare @TableNumber INT = 1;
    
    while @TableNumber <= @MaxMultiplier 
    begin
        declare @MultiplierNumber INT = 1;

        while @MultiplierNumber <= 10
        begin
            declare @Result INT = @TableNumber * @MultiplierNumber;
            print CAST(@TableNumber AS VARCHAR) + ' * ' + CAST(@MultiplierNumber AS VARCHAR) + ' = ' + CAST(@Result AS VARCHAR);
            set @MultiplierNumber = @MultiplierNumber + 1;
        end

       print ''
        set  @TableNumber = @TableNumber + 1;
    end
end
--to execute
EXEC MultiplicationTable @MaxMultiplier = 10;

-----3.
create table tblHoliday (
    holiday_date  date primary key ,
    holiday_name varchar(250)
)
 drop table tblholiday
insert into  tblHoliday (holiday_date, holiday_name) values
('2024-01-14', 'Pongal'),
('2024-11-04', 'Diwali'),
('2024-01-26','Republic Day'),
('2025-01-01', 'New Year')
 
select * from tblEMP
-------------------------------------------------------------------------------------------------------------------------------
Create table tblEMP (
    empno INT PRIMARY KEY,ename VARCHAR(30), job VARCHAR(30),mgr_id INT, hiredate DATE, sal DECIMAL(10, 2),
     comm DECIMAL(10, 2), deptno INT);

 
Insert into tblEMP (empno, ename, job, mgr_id, hiredate, sal, comm, deptno)
VALUES 
(7369, 'SMITH', 'CLERK', 7902, '1980-12-17', 800.00, NULL, 20),
(7499, 'ALLEN', 'SALESMAN', 7698, '1981-02-20', 1600.00, 300.00, 30),
(7521, 'WARD', 'SALESMAN', 7698, '1981-02-22', 1250.00, 500.00, 30),
(7566, 'JONES', 'MANAGER', 7839, '1981-04-02', 2975.00, NULL, 20)
----------------
CREATE OR ALTER TRIGGER Restrict_HolidayData_Manipulation
ON tblEMP
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    DECLARE @HolidayName VARCHAR(255);
    
    SELECT @HolidayName = Holiday_name
    FROM tblHoliday
    WHERE holiday_date = '2024-01-15'

    IF @HolidayName IS NOT NULL
    BEGIN
        RAISERROR ('Due to %s, you cannot manipulate data', 16, 1, @HolidayName);
        ROLLBACK TRANSACTION;
    END
END;
insert into tblHoliday (holiday_date, holiday_name) values ('2024-08-26' , 'Republic Day')
insert into  tblEMP (empno, ename) values  (7497, 'hema')
delete from  tblEMP where  empno = 7497

