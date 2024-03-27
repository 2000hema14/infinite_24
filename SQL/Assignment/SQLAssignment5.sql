CREATE DATABASE ASSIGNMENTDB_5

----1.write a tsql based procedure to generate complete payslip of agiven employee with respect of the following conditions:
----A.HRA as 10% of salaray
----B.DA as 20%of salary
----C.PF as 8% of salary
----D.IT as 5% of salary
----E.deductions as sum of PF AND IT
 
 Create table tblEMPslip (
    empno int primary key,ename Varchar(30), job Varchar(30), sal decimal(10, 2))

Insert into tblEMPslip 
VALUES 
(7369, 'SMITH', 'ANALYST', 8500.00),
(7499, 'ALLEN', 'SALESMAN', 300.00),
(7521, 'WARD', 'SALESMAN', 1250.00 ),
(7566, 'JONES', 'MANAGER', 2000.00),
(7654, 'MARTIN', 'SALESMAN', 3500.00),
(7698, 'BLAKE', 'MANAGER', 25000.00),
(7782, 'CLARK', 'MANAGER', 8500.00),
(7788, 'SCOTT', 'ANALYST', 8600.00)
Select * from tblEMPslip
---------------------------------------------------------------------------------------------------------------------------------------
create OR alter procedure EMPslip
    @eid int
as
begin
    declare @sal decimal(10, 2) = (select sal from tblEMPslip where empno = @eid);
    declare @hra decimal(10, 2) = @sal * 0.1;
    declare @da decimal(10, 2) = @sal * 0.2;
    declare @pf decimal(10, 2) = @sal * 0.08;
    declare @it decimal(10, 2) = @sal * 0.05;
    declare @deductions decimal(10, 2) = @hra + @da + @pf + @it;
    declare @grosssal decimal(10, 2) = @sal + @hra + @da;
    declare @netsal decimal(10, 2) = @sal - @deductions;

    select
        @eid as EmployeeID,
        @sal as BasicSalary,
        @hra as HRA,
        @da as DA,
        @pf as PF,
        @it as IT,
        @deductions as Deductions,
        @grosssal as GrossSalary,
        @netsal as NetSalary;
end

-----To display the output of the emppayslip procedure
exec EMPslip @eid = 7788



