create database assignment3
 
use assignment3
 
create  table Dept(Deptno int Primary key,
Dname varchar(40),
loc varchar(40))
 
create table Emp(Empno int primary key,
Ename varchar(20) not null,
Job varchar(20),
MGR_Id int,
HireDate Date, 
Sal float,
Comm int,
Deptno  int foreign key references Dept(Deptno))
 
 
insert into Dept values(10,'Accounting','New York'),
(20,'Research','Dallas'),
(30,'Sales','Chicago'),
(40,'Operations','Boston')
 
 
insert into Emp values
(7369,'SMITH','CLERK',7902,'17-Dec-80',800,null,20),
(7499,'ALLEN','SALESMAN',7698,'20-FEB-81',1600,300,30),
(7521,'WARD','SALESMAN',7698,'22-FEB-81',1250,500,30),
(7566,'JONES','MANAGER',7839,'02-APR-81',2975,null,20),
(7654,'MARTIN','SALESMAN',7698,'28-SEP-81',1250,1400,30),
(7698,'BLAKE','MANAGER',7839,'01-MAY-81',2850,null,30),
(7782,'CLARK','MANAGER',7839,'09-JUN-81',2450,null,10),
(7788,'SCOTT','ANALYST',7566,'19-APR-87',3000,null,20),
(7839,'KING','PRESIDENT',null,'17-NOV-81',5000,null,10),
(7844,'TURNER','SALESMAN',7698,'08-SEP-81',1500,0,30),
(7876,'ADAMS','CLERK',7788,'23-MAY-87',1100,null,20),
(7900,'JAMES','CLERK',7698,'03-DEC-81',950,null,30),
(7902,'FORD','ANALYST',7566,'03-DEC-81',3000,null,20),
(7934,'MILLER','CLERK',7782,'23-JAN-82',1300,null,10)
 
 
select*from Dept
select*from Emp
 
------1)
select * from Emp where Job='Manager'
 
-----2)
select Ename,Sal from Emp Where Sal>1000
 
 
-------3)
select Ename,Sal from Emp where Ename not like'James'
 
 
------ 4)
select * from Emp where Ename like'S%'
 
--------- 5)
select Ename from Emp where Ename like'%a%'
 
----------6)
select EName from Emp where Ename like'__l%'
 
-----------7)
select Ename,Sal=Sal/30 from Emp Where Ename='Jones'
 
 
----------8)
select Sum(Sal) as 'Total Salary of all Employee' from Emp
 
-------------9)
select Avg(Sal*12)as'Average annual salary' from Emp
 
------------10)
select Ename,Job,Sal,Deptno from Emp where job not like'Salesman'
 
 
----------------11)
select distinct deptno from Emp
 
 
---------12)
select Ename,Sal,Deptno from Emp where Sal>1500 and Deptno in(10,30)
 
 
--------------13)
select Ename,Job,Sal from Emp where Job in('Manager','Analyst')and Sal not in(1000,3000,5000)
 
 
------------14)
select Ename,Sal=sal+sal*0.1,Comm from Emp where comm>sal
 
 
-----------15)
select Ename from Emp where Ename like'%ls%' and (Deptno=30 or MGR_Id=7782)
 
 
------16)--
 
select Ename, HireDate, 
       datediff(year, HireDate, getdate()) AS ' Experience'
from emp
where datediff(year, HireDate, getDate()) > 30
  and datediff(year, HireDate, getdate()) < 40;
select count(*) AS 'Total employee'
from Emp
where datediff(year, HireDate, getdate()) > 30
  and datediff(year, HireDate, getDate()) < 40;
 
 
 
--------------17)
select d.Dname as Department_Name, e.Ename as Employee_Name FROM EMP e join Dept d ON e.Deptno = d.Deptno order by  e.Ename desc,d.Dname Asc
 