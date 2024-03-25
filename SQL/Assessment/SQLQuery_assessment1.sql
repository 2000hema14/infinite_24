Create database AssessmentDB1
----1.Write a query to fetch the details of the books written by author whose name ends with er.
SELECT *from tblbook

  create table tblbook(
  Bid int  PRIMARY KEY,
  btitle varchar(20) not null,
  bauthor varchar(20) not null,
  B_isbn int unique not null,
   PublishedDate DATE)

INSERT INTO tblbook VALUES (1, 'MY SQL BOOK', 'MARY PARKER', '981029127', '2012-02-22 12:08:17'),
           (2, 'MY SECOND SQL BOOK', 'JOHN MAYER', '856785678', '1972-07-03 09:22:45'),
            (3, 'MY THIRD SQL BOOK', 'CARY FLINT', '523127812', '2015-10-18 14:05:44');

-----1.QUERY
-------  Write a query to fetch the details of the books written by author whose name ends with er.
SELECT *from tblbook
where bauthor like '%er'

create table tblReviews(
Rid int Primary key,
bid int,
reviewer_name varchar (20),
content varchar(20),
rating int,
PublishedDate DATE)

insert into tblReviews VALUES
(1, 1, 'SMITH', 'MY FIRST REVIEW', 4, '2017-12-10 05:50:11'),
(2, 2, 'SMITH', 'MY SECOND REVIEW', 5, '2017-10-13 15:05:12'),
(3, 3, 'WALKER', 'ANOTHER REVIEW', 1, '2017-10-22 23:47:10');

select * from tblReviews
select* from  tblbook 

----Display the Title ,Author and ReviewerName for all the books from the above table 
SELECT b.btitle, b.bauthor, r.reviewer_name
FROM tblbook b
JOIN tblReviews r ON b.Bid = r.bid

---2.Display the  reviewer name who reviewed more than one book.
Select reviewer_name
from tblReviews
group by reviewer_name
having count(DISTINCT bid) > 1

---3..Display the Name for the customer from above customer table  who live in same address which has character o anywhere in address
create table tblCustomers (
CID int primary key ,
Cname varchar(20),
cage int,
Caddress varchar(20),csalary int)


insert into tblCustomers 
values 
(1, 'Ramesh',32, 'Ahmedabad', 2000.00),
(2, 'Khilan',25, 'Delhi', 1500.00),
(3, 'Kaushik',23, 'Kota', 2000.00),
(4, 'Chaitali',25, 'Mumbai', 6500.00),
(5, 'Hardik',27, 'Bhopal', 8500.00),
(6, 'Komal',22, 'MP', 4500.00),
(7, 'Muffy',24, 'Indore', 10000.00)
select * from tblCustomers

----query
select Cname
from tblCustomers
where Caddress  LIKE '%o%'

---4.
create table tblorders (
OID INT,
ODATE DATE,
CUSTOMER_ID INT,
OAMOUNT INT)

INSERT INTO tblorders VALUES(102, '2009-10-08', 3, 3000),
(100, '2009-10-08', 3, 1500), (101, '2009-11-20', 2, 1560),
 (103, '2008-05-20', 4, 2060);
 SELECT * FROM tblorders
-----Write a query to display the   Date,Total no of customer  placed order on same Date 
Select ODATE,
COUNT(DISTINCT CUSTOMER_ID) AS TotalC
FROM tblorders
GROUP BY ODATE;

----5.Display the Names of the Employee in lower case, whose salary is null 

create table TBLempLOYEES(
    EID int primary key,
    Ename varchar(10),
    AGE int,
    E_Address varchar(50),
    Salary DECIMAL(10, 2)
)
 
 
insert into TBLempLOYEES values
(1, 'Ramesh', 32, 'Ahmedabad', 2000.00),
(2, 'Khilan', 25, 'Delhi', 1500.00),
(3, 'Kaushik', 23, 'Kota', 2000.00),
(4, 'Chaitali', 25, 'Mumbai', 6500.00),
(5, 'Hardik', 27, 'Bhopal', 8500.00),
(6, 'Komal', 22, 'MP',NULL),
(7, 'Muffy', 24, 'Indore',NULL)

----QUERY
 Select LOWER(Ename) AS LowerCaseName
FROM TBLempLOYEES
WHERE Salary IS NULL;


----6.Write a sql server query to display the Gender,Total no of male and female from the above 
create table tblStudentDetails (
    Register_no INT,
    Sname VARCHAR(20),
    Sage INT,
    Squalification VARCHAR(10),
    MOBILE_NO INT,
    MAIL_ID VARCHAR(30),
    SLocation VARCHAR(20),
    gender VARCHAR(10)
)
INSERT INTO tblStudentDetails VALUES
(2, 'SAI', 22, 'B.E', 99245667, 'SAI@GMAIL.COM', 'CHENNAI', 'M'),
(3, 'KUMAR', 20, 'BSC',78904567, 'KUMAR@GAMIL.COM', 'MADURAI', 'M'),
(4, 'SELVI', 22, 'B.TECH', 89044673, 'SELVI@GAMIL.COM', 'SELAM', 'F'),
(5, 'NISHA', 25, 'M.E', 78345678, 'NISHA@GAMIL.COM', 'THENI', 'F'),
(6, 'SAISARAN', 21, 'B.A', 789067867, 'SAISARAN@GAMIL.COM', 'MADURAI', 'F'),
(7, 'TOM', 23, 'BCA', 890123456, 'TOM@GAMIL.COM', 'PUNE', 'M');

----QUERY
select gender, COUNT(*) AS Total_N0_OF_M_F
from tblStudentDetails
group by gender;





