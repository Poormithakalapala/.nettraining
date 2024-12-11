--Create a Function to calculate the course duration for the above relation by receiving start date and end date as input.
 
 create table CourseDetails(
 C_Id varchar(10),
 C_Name varchar(50),
 Start_date Date,
 End_date Date,
 fee int);

 insert into CourseDetails values
 ('DN003','DotNet','2018-02-01','2018-02-28',15000),
 ('DV004','Data Visualization','2018-03-01','2018-04-15',15000),
 ('JA002','Advanced Java','2018-01-02','2018-01-20',1000),
 ('JC001','CoreJava', '2018-01-02','2018-01-12',3000)

 create function CalculateCourseDuration(
 @StartDate date,
 @EndDate date
 )
 returns int
 as
 begin
 return datediff(day,@StartDate,@EndDate);
 end;

 select
    C_Id,
	C_Name,
    Start_date,
    End_date,
    fee,
    dbo.CalculateCourseDuration(Start_date, End_date) AS CourseDuration
from
    CourseDetails;


--Create a trigger to display the Course Name and Start date of the course
--(note: when ever the new course is entered in course details relation ,
--Course Name and Start date should get reflected  in T_CourseInfo table)
create table T_CourseInfo(
C_Name varchar(50),
Start_date date);

create trigger trgCourse
on CourseDetails
after insert
as
begin
insert into T_CourseInfo(C_Name,Start_date)
select C_Name,Start_date
from inserted;
end;

INSERT INTO CourseDetails values
('DN003', 'Dot Net', '2018-02-01', '2018-02-28', 15000),
('DV004', 'Data Visualization', '2018-03-01', '2018-04-15', 15000);

select * from T_CourseInfo;







 