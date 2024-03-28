create database AssessmentDB2

----1.Write a query to display your birthday( day of week)
select datename(dw, '2000-12-14') as BDay_Day_Of_Week
--output:BDay_Day_Of_Week
         Thursday


---2.Write a query to display your age in days
SELECT DATEDIFF(DD, '2000-12-14', GETDATE()) AS ageindays
---ouput:ageindays
          8505


----3. Write a query to display all employees information those who joined before 5 years in the current month
Create table tblempjoindate (
    empno INT PRIMARY KEY,ename VARCHAR(30), job VARCHAR(30), hiredate DATE, sal DECIMAL(10, 2))

 
Insert into  tblempjoindate
VALUES 
(7369, 'SMITH', 'CLERK', '1980-12-17', 800.00 ),
(7499, 'ALLEN', 'SALESMAN','2019-03-28',600.00),
(7521, 'WARD', 'SALESMAN', '1981-02-22', 1250.00),
(7566, 'JONES', 'MANAGER', '1981-04-02', 2975.00)

drop table  tblempjoindate
---Query
select * from tblempjoindate
where hiredate < dateadd(year, -5, getdate())
and month(hiredate) = month(getdate())

--output:
  empno   ename   job         hiredate    sal
  7499	  ALLEN	  SALESMAN	  2019-03-28  600.00

---4. Create table Employee with empno, ename, sal, doj columns and perform the following operations in a single transaction

  Create table tblempdoj (
    empno INT PRIMARY KEY,ename VARCHAR(30), hiredate DATE, sal DECIMAL(10, 2))

 
Insert into  tblempdoj
VALUES 
(7369, 'SMITH', '1980-12-17', 800.00 ),
(7499, 'ALLEN','2019-03-28',600.00),
(7521, 'WARD', '1981-02-22', 1250.00),
(7566, 'JONES', '1981-04-02', 2975.00)
drop table tblempdoj



--a.First insert 3 rows 
 BEGIN TRANSACTION;
 CREATE TABLE DeletedEmpDATEOFJOIN (
    empno INT PRIMARY KEY,
    ename VARCHAR(30),
    job VARCHAR(30),
    hiredate DATE,
    sal DECIMAL(10, 2)
)
commit transcation
INSERT INTO  DeletedEmpDATEOFJOIN
SELECT *
FROM tblempjoindate
WHERE empno = 7369
SELECT *FROM DeletedEmpDATEOFJOIN

--OUTPUT:7369	SMITH	CLERK	1980-12-17	920.00

---b. Update the second row sal with 15% increment 
update DeletedEmpDATEOFJOIN
set sal = sal * 1.15
where empno = 7369

---OUTPUT:7369	SMITH	CLERK	1980-12-17	1058.00

----c. Delete first row.
--After completing above all actions how to recall the deleted row without losing increment of second row.
DELETE FROM DeletedEmpDATEOFJOIN
WHERE empno = 7369

INSERT INTO tblempjoindate (empno, ename, job, hiredate, sal)
SELECT empno, ename, job, hiredate, sal
FROM DeletedEmpDATEOFJOIN
---5.Create a user defined function calculate Bonus for all employees of a  given job using 	following conditions

create or alter function Calcubonus (@deptno int , @sal decimal (10, 2)) 
returns decimal (10, 2)
as
begin
    declare @bonus decimal (10, 2)
 
   if  @deptno = 10
        set @bonus = @sal * 0.15;
   else if  @deptno = 20
        set @bonus = @sal * 0.20;
   else
        set @bonus = @sal * 0.05;
 
   return  @bonus
end 
select ename, sal, dbo.Calcubonus(deptno, sal) AS bonus from tblEmp where deptno = 10
--ouptput:
--CLARK	2450.00	367.50-
----KING	5000.00	750.00
----MILLER	1300.00	195.00

---b
select ename, sal, dbo.Calcubonus(deptno, sal) AS bonus from tblEmp where deptno = 20
---output:  SMITH	800.00	160.00
--JONES	2975.00	595.00
--SCOTT	3000.00	600.00
--ADAMS	1100.00	220.00
--FORD	3000.00	600.00

----c.
select ename, sal, dbo.Calcubonus(deptno, sal) AS bonus from tblEmp where deptno = 30
---output.
---ALLEN	1600.00	80.00
--WARD	1250.00	62.50
--MARTIN	1250.00	62.50
--BLAKE	2850.00	142.50
--TURNER	1500.00	75.00
--JAMES	950.00	47.50
 




