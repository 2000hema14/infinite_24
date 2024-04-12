create database EmployeeManagementDB
use EmployeeManagementDB

create table  Employee_Details (
    Empno INT PRIMARY KEY,
    EmpName VARCHAR(50) NOT NULL,
    Empsal NUMERIC(10,2) CHECK (Empsal >= 25000),
    Emptype CHAR(1) CHECK (Emptype IN ('P', 'C'))
);

-----PROCEDURE--------

CREATE PROCEDURE AddEmployee
    @EmpName VARCHAR(50),
    @Empsal NUMERIC(10,2),
    @Emptype CHAR(1)
AS
BEGIN
    DECLARE @NewEmpno INT;
    SELECT @NewEmpno = ISNULL(MAX(Empno), 0) + 1 FROM Employee_Details;

    -- Insert the new employee
    INSERT INTO Employee_Details (Empno, EmpName, Empsal, Emptype)
    VALUES (@NewEmpno, @EmpName, @Empsal, @Emptype);
END


-----OUTPUT-------

Enter Employee_name:
Tarun
Enter Employee_Salary:
55000
Enter employee type ( Permanent (P),Contract(C)):
c
Employee Management details added successfully!
All Employee Rows:
Empno: 1, EmpName: Varun, Empsal: 25000.00, Emptype: C
Empno: 2, EmpName: HEMA, Empsal: 75000.00, Emptype: P
Empno: 3, EmpName: RAGHAVA, Empsal: 85000.00, Emptype: P
Empno: 4, EmpName: RAMYA SHREE, Empsal: 65000.00, Emptype: C
Empno: 5, EmpName: gowtham, Empsal: 60000.00, Emptype: C
Empno: 6, EmpName: Tarun, Empsal: 55000.00, Emptype: c






