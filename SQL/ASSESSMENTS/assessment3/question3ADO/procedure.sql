CREATE TABLE Products_Details (
    ProductId INT PRIMARY KEY,  
    ProductName VARCHAR(55) ,
    Price DECIMAL(10, 2) ,
    DiscountedPrice AS (Price - (Price * 0.1)) 
);
select * from Products_Details;


create proc Insert_ProdDetails
    @ProductName VARCHAR(55),
    @Price DECIMAL(10, 2),
    @GeneratedProductId INT OUTPUT,
    @DiscountedPrice DECIMAL(10, 2) OUTPUT
as
begin
    declare @InsertedProducts table (ProductId INT);
    INSERT INTO Products_Details (ProductName, Price)
    OUTPUT INSERTED.ProductId INTO @InsertedProducts
    VALUES (@ProductName, @Price);
    SELECT @GeneratedProductId = ProductId FROM @InsertedProducts;
    SET @DiscountedPrice = @Price - (@Price * 0.1);
END;

 