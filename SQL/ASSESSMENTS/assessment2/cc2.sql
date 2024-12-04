--1.write a query to display your birthday(day of week)

select datename(weekday,'2003-08-08') as DayOfWeek;



--2.write a query to display your age in days

select datediff(day,'2024-08-08',getdate()) as AgeInDays;

--3. write a query to display all employees information those who joined before 5 years in cureent month.

select *
from emp
where datediff(year,hiredate,getdate())>=5
and month(hiredate)=month(getdate());

--4.create table employee with empno, ename, sal, doj columns or use and perform the following operation in a single transaction.
-- Create the Employee table
BEGIN TRANSACTION;
CREATE TABLE Employ(
    empno INT PRIMARY KEY,
    ename VARCHAR(20),
    sal FLOAT,
    doj DATE
);
INSERT INTO Employ (empno, ename, sal, doj) VALUES (1, 'sara', 1500, '2020-08-11'),(2, 'rina', 2000, '2023-09-20'),
(3, 'sana', 3000, '2022-09-25');
-- Update second row's salary 15% increment
UPDATE Employ
SET sal = sal * 1.15 
WHERE empno = 2;

select * from employ
-- Delete first row
DELETE FROM Employ WHERE empno = 1;

select * from employ
-- Commit the transaction
COMMIT;
 

-- Re-insert the deleted row with the updated salary
INSERT INTO Employ (empno, ename, sal, doj) VALUES (1, 'sara', 1500, '2020-08-11'); 
SELECT * FROM Employ;

--5.create user defined function calculate, Bonus for all employees of a given dept using
--a. for deptno 10 employees 15% of sal as bonus.
--b. for deptno 20 employees 20% of sal as bonus.
--c. for others employees 5% of sal as bonus.
CREATE FUNCTION CalBonus(@deptno INT, @emp_sal FLOAT) 
RETURNS FLOAT
AS
BEGIN
    DECLARE @bonus FLOAT;
 
    IF @deptno = 10
        SET @bonus = @emp_sal * 0.15;
    ELSE IF @deptno = 20
        SET @bonus = @emp_sal * 0.20;
    ELSE
        SET @bonus = @emp_sal * 0.05;
 
    RETURN @bonus;
END;
 
SELECT empno, ename, sal, deptno, dbo.CalBonus(deptno, sal) AS bonus
FROM Emp;
 


--6. create a procedure to update the salary of employee by 500 whose
--dept name is sales and current salary is below 1500(use emp table)
CREATE PROCEDURE UpdateSalForSales
AS
BEGIN
    UPDATE Emp
    SET sal = sal + 500
    WHERE Deptno = (SELECT Deptno FROM Dept WHERE Dname = 'Sales')
    AND sal < 1500;
END;
 

EXEC UpdateSalForSales;
select *from Emp