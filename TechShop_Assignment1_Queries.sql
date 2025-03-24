--TASK 1: 
--Database Design: 
--1. Create the database named "TechShop" 
--2. Define the schema for the Customers, Products, Orders, OrderDetails and Inventory tables based on the provided schema. 
--3. Create an ERD (Entity Relationship Diagram) for the database. 
--4. Create appropriate Primary Key and Foreign Key constraints for referential integrity. 
--5. Insert at least 10 sample records into each of the following tables.

--a.	Customers:

--QUERY

CREATE DATABASE JEROME_TechShop
use JEROME_TechShop

CREATE TABLE Customers 
(CustomerID int PRIMARY KEY identity(101,1),
FirstName varchar(100) NOT NULL,
LastName varchar(100),
EMail varchar(100),
Phone bigint NOT NULL,
Address varchar(100) NOT NULL
)

INSERT INTO Customers (FirstName,LastName,EMail,Phone,Address) VALUES
('Swetha','Priya','swetha@gmail.com',7997037993,'123 Gandhi Road'),
('Vivek','Kumar','vivek@gmail.com',9440584444,'54 Indhra Nagar'),
('Rahul','Raj','rahul@gmail.com',9398955692,'43/27 Choolai'),
('Mano','Prem','mano@gmail.com',7989603224,'91 T.Nagar'),
('Ranjith','Kumar','ranjith@gmail.com',8885911162,'17 Perambur'),
('Mary','John','mary@gmail.com',8927037982,'12 C.H Road'),
('Joseph','Raj','joseph@gmail.com',9946336553,'47 Aynavaram'),
('Lakshmi','Priya','lakshmi@gmail.com',798137944,'82 Nehru park'),
('Divya','Dharshini','divya@gmail.com',9043848146,'34/21 Annanagar'),
('Mani','Maran','mani@gmail.com',9471018240,'11 Creams Road')

Select *from Customers

 

--b. Products:
--QUERY:
CREATE TABLE Products 
(
ProductID int PRIMARY KEY identity(201,1),
ProductName varchar(100),
Description varchar(100),
Price DECIMAL(10,2) ,
)
GO

INSERT INTO Products (ProductName,Description,Price) VALUES
('Backpack','bag for laptop',1000),
('Mouse','good-rated mouse',2000),
('Keyboard','high efficiency',3000),
('Monitor','4k display',4000),
('Headphones','High Sound quality',5500),
('Pendrive','best class transfer',6000),
('CPU','Faster Performance',25000),
('Mobiles','All rounder',30000),
('PlayStation 5','Trending games',48000),
('Laptops','Multitasking',60000),
('Printer','Clear printouts',72000)

Select *from Products





 

--c. Orders:
--QUERY
CREATE TABLE Orders 
(
OrderID int PRIMARY KEY identity(301,1),
CustomerID int,
OrderDate DATE,
TotalAmount decimal(10,2) ,
CONSTRAINT fk_customId FOREIGN KEY(CustomerID) REFERENCES Customers(CustomerID)
)

INSERT INTO Orders(CustomerID,OrderDate,TotalAmount)
VALUES
(101,'2025-02-05',1000),
(102,'2025-02-16',2000),
(103,'2025-02-18',3000),
(104,'2025-02-23',4000),
(105,'2025-02-25',5500),
(106,'2025-02-28',6000),
(107,'2025-03-03',25000),
(108,'2025-03-09',30000),
(109,'2025-03-12',48000),
(110,'2025-03-15',60000)
Select *from Orders







--d. OrderDetails:
--QUERY
CREATE TABLE OrderDetails 
(
OrderDetailID int PRIMARY KEY identity(401,1),
OrderID int,
ProductID int,
Quantity int,
CONSTRAINT fk_orderId FOREIGN KEY(OrderID) REFERENCES Orders(OrderID),
CONSTRAINT fk_prodId FOREIGN KEY(ProductID) REFERENCES Products(ProductID)
)
GO

INSERT INTO OrderDetails (OrderID,ProductID,Quantity)
VALUES
(301,201,1),
(302,202,1),
(303,203,1),
(304,204,1),
(305,205,1),
(306,206,1),
(307,207,1),
(308,208,1),
(309,209,1),
(310,210,1)


Select *from OrderDetails


 



--e. Inventory:
--QUERY
CREATE TABLE Inventory 
(
InventoryID int PRIMARY KEY identity(501,1),
ProductID int,
QuantityInStock int,
LastStockUpdate DATE,
CONSTRAINT fk_productId FOREIGN KEY(ProductID) REFERENCES Products(ProductID)
)
GO

INSERT INTO Inventory (ProductID,QuantityInStock,LastStockUpdate)
VALUES
(201,10,'2025-01-10'),
(202,15,'2025-01-10'),
(203,20,'2025-01-10'),
(204,25,'2025-01-10'),
(205,30,'2025-01-10'),
(206,35,'2025-01-20'),
(207,40,'2025-01-20'),
(208,45,'2025-01-20'),
(209,50,'2025-01-20'),
(210,55,'2025-01-20')


Select *from Inventory



--TASK 2: Select, Where, Between, AND, LIKE:

--1.	Write an SQL query to retrieve the names and emails of all customers.
--Query: 
select CONCAT(FirstName,' ',LastName) as Name,Email from Customers



 

--2.	Write an SQL query to list all orders with their order dates and corresponding customer names.

--Query :  
SELECT OrderID,OrderDate,CONCAT(FirstName,' ',LastName) AS Name
FROM Orders
JOIN Customers
ON Orders.CustomerID=Customers.CustomerID;

 

--3.	Write an SQL query to insert a new customer record into the "Customers" table. Include customer information such as name, email, and address.

--Query :
INSERT into Customers (FirstName,LastName,Email,Phone,Address) Values
('Prakash','Ram','prakash@gmail.com',9883942157,'23 Kumaran Nagar')
Select *From Customers

 




--4.	Write an SQL query to update the prices of all electronic gadgets in the "Products" table by increasing them by 10%.
--Query : 
Update Products
SET Price = Price * 1.1


--5. Write an SQL query to delete a specific order and its associated order details from the "Orders" and "OrderDetails" tables. Allow users to input the order ID as a parameter.
--Query:
Delete from Orders 
where OrderId = 301


--6. Write an SQL query to insert a new order into the "Orders" table. Include the customer ID, order date, and any other necessary information.

--Query: 
INSERT into Orders(OrderID, CustomerID,OrderDate,TotalAmount) Values
(310,110,'2025-03-15',62000)

 

--7. Write an SQL query to update the contact information (e.g., email and address) of a specific customer in the "Customers" table. Allow users to input the customer ID and new contact information.
--Query: 
Update Customers 
SET Email='joseph007@gmail.com',Phone = 9744205813
where customerID = 107
 

--8. Write an SQL query to recalculate and update the total cost of each order in the "Orders" table based on the prices and quantities in the "OrderDetails" table.
UPDATE Orders
SET TotalAmount = (
SELECT SUM(Quantity * Price
FROM OrderDetails
JOIN Products ON OrderDetails.ProductID = Products.ProductID
WHERE OrderDetails.OrderID = Orders.OrderID
);

Select *from Orders

 
--9. Write an SQL query to delete all orders and their associated order details for a specific customer from the "Orders" and "OrderDetails" tables. Allow users to input the customer ID as a parameter.
Delete from Orders 
where OrderId = 301

 
--10. Write an SQL query to insert a new electronic gadget product into the "Products" table, including product name, category, price, and any other relevant details.
--Query: 
insert into Products values('Television','Entertainment',70000)
select *from Products


 

--11. Write an SQL query to update the status of a specific order in the "Orders" table (e.g., from "Pending" to "Shipped"). Allow users to input the order ID and the new status.
--Query:
Update Orders
Set Order_Status = 'Pending'
where OrderId between 301 and 310

select *from Orders

Update Orders
SET Order_Status = 'Shipped'
Where OrderID in (301,304,305)
 




--Task 3. Aggregate functions, Having, Order By, GroupBy and Joins:
--1. Write an SQL query to retrieve a list of all orders along with customer information (e.g., customer name) for each order.
Query: Select Concat(Customers.FirstName,' ',Customers.LastName) as
CustomerName,Customers.CustomerID,Orders.OrderID,Orders.Order_Status
from Orders
Join Customers
On Orders.CustomerID = Customers.CustomerID

 

--2. Write an SQL query to find the total revenue generated by each electronic gadget product. Include the product name and the total revenue.
--Query: 
SELECT Products.ProductID, Products.ProductName,SUM(OrderDetails.Quantity * 
Products.Price)
AS TotalRevenue
FROM Products
JOIN OrderDetails ON Products.ProductID = OrderDetails.ProductID
JOIN Orders ON OrderDetails.OrderID = Orders.OrderID
GROUP BY Products.ProductID, Products.ProductName
order by Products.ProductID, Products.ProductName

 
--3. Write an SQL query to list all customers who have made at least one purchase. Include their names and contact information.
--Query: 
SELECT Customers.CustomerID, CONCAT(Customers.FirstName, ' ', Customers.LastName)
AS CustomerName, Customers.Email, Customers.Phone
FROM Customers
JOIN Orders ON Customers.CustomerID = Orders.CustomerID
GROUP BY Customers.CustomerID, Customers.FirstName,Customers.LastName, Customers.Email, Customers.Phone
HAVING COUNT(Orders.OrderID) > 0;

 

--4. Write an SQL query to find the most popular electronic gadget, which is the one with the highest total quantity ordered. Include the product name and the total quantity ordered.
--Query:
SELECT Products.ProductID, Products.ProductName, SUM(OrderDetails.Quantity) AS TotalQuantityOrdered
FROM Products
JOIN OrderDetails ON Products.ProductID = OrderDetails.ProductID
GROUP BY Products.ProductID, Products.ProductName
ORDER BY TotalQuantityOrdered DESC

 
--5. Write an SQL query to retrieve a list of electronic gadgets along with their corresponding categories.
--Query:
SELECT ProductName, ProductId FROM Products;

 

--6. Write an SQL query to calculate the average order value for each customer. Include the customer's name and their average order value.
--Query: 
SELECT Customers.CustomerID, CONCAT(Customers.FirstName, ' ', Customers.LastName) AS CustomerName,
AVG(Orders.TotalAmount) AS AvgOrderValue
FROM Customers
JOIN Orders ON Customers.CustomerID = Orders.CustomerID
GROUP BY Customers.CustomerID, Customers.FirstName, Customers.LastName;

 

--7. Write an SQL query to find the order with the highest total revenue. Include the order ID, customer information, and the total revenue.
--Query: 
SELECT Orders.OrderID, CONCAT(Customers.FirstName, ' ', Customers.LastName) AS CustomerName, SUM(OrderDetails.Quantity * Products.Price) AS TotalRevenue
FROM Orders
JOIN Customers ON Orders.CustomerID = Customers.CustomerID
JOIN OrderDetails ON Orders.OrderID = OrderDetails.OrderID
JOIN Products ON OrderDetails.ProductID = Products.ProductID
GROUP BY Orders.OrderID, Customers.FirstName, Customers.LastName
ORDER BY TotalRevenue DESC

 
--8. Write an SQL query to list electronic gadgets and the number of times each product has been ordered.
--Query :
SELECT Products.ProductName, COUNT(OrderDetails.OrderID) AS OrderCount
FROM Products
JOIN OrderDetails ON Products.ProductID = OrderDetails.ProductID
GROUP BY Products.ProductName

 
--9. Write an SQL query to find customers who have purchased a specific electronic gadget product. Allow users to input the product name as a parameter.
--Query:
SELECT Customers.CustomerID, CONCAT(Customers.FirstName, ' ', Customers.LastName)
AS CustomerName, Customers.Email, Customers.Phone
FROM Customers
JOIN Orders ON Customers.CustomerID = Orders.CustomerID
JOIN OrderDetails ON Orders.OrderID = OrderDetails.OrderID
JOIN Products ON OrderDetails.ProductID = Products.ProductID
WHERE Products.ProductName = 'Mobiles';

 

--10. Write an SQL query to calculate the total revenue generated by all orders placed within a specific time period. Allow users to input the start and end dates as parameters.
--Query:
SELECT SUM(totalamount) AS total_revenue
FROM orders
WHERE OrderDate BETWEEN '2025-01-01' AND '2025-02-28'






--Task 4. Subquery and its type:
--1. Write an SQL query to find out which customers have not placed any orders.
--Query:
SELECT CustomerID, CONCAT(FirstName, ' ', LastName) AS CustomerName
FROM Customers
WHERE CustomerID NOT IN (SELECT DISTINCT CustomerID FROM Orders)


 

--2. Write an SQL query to find the total number of products available for sale.
--Query:
SELECT COUNT(*) AS TotalProducts
FROM Products;

 

--3. Write an SQL query to calculate the total revenue generated by TechShop.
--Query:
SELECT SUM(TotalAmount) AS TotalRevenue
FROM Orders;

 





--4. Write an SQL query to calculate the average quantity ordered for products in a specific category. Allow users to input the category name as a parameter.
 
--5. Write an SQL query to calculate the total revenue generated by a specific customer. Allow users to input the customer ID as a parameter.
--Query:
SELECT SUM(TotalAmount) AS TotalRevenue
FROM Orders WHERE CustomerID = 107;

 


--6. Write an SQL query to find the customers who have placed the most orders. List their names and the number of orders they've placed.
--Query:
SELECT customers.CustomerID, CONCAT(FirstName, ' ', LastName) AS CustomerName, COUNT(OrderID) AS OrderCount
FROM orders
left JOIN customers ON customers.CustomerID = orders.CustomerID
GROUP BY customers.CustomerID,FirstName, LastName
ORDER BY OrderCount DESC
 

--7. Write an SQL query to find the most popular product category, which is the one with the highest total quantity ordered across all orders.
--Query:
SELECT ProductName, SUM(OrderDetails.Quantity) AS TotalQuantityOrdered
FROM Products
JOIN OrderDetails ON Products.ProductID = OrderDetails.ProductID
GROUP BY ProductName
ORDER BY TotalQuantityOrdered DESC

 
--8. Write an SQL query to find the customer who has spent the most money (highest total revenue) on electronic gadgets. List their name and total spending.
--Query:
SELECT Customers.CustomerID, CONCAT(FirstName, ' ', LastName) AS CustomerName, SUM(OrderDetails.Quantity * Products.Price) AS TotalSpending
FROM Customers
JOIN Orders ON Customers.CustomerID = Orders.CustomerID
JOIN OrderDetails ON Orders.OrderID = OrderDetails.OrderID
JOIN Products ON OrderDetails.ProductID = Products.ProductID
GROUP BY Customers.CustomerID, FirstName, LastName
ORDER BY TotalSpending DESC

 
--9. Write an SQL query to calculate the average order value (total revenue divided by the number of orders) for all customers.
--Query:
SELECT AVG(TotalAmount) AS AvgOrderValue
FROM Orders;

 
--10. Write an SQL query to find the total number of orders placed by each customer and list their names along with the order count.
--Query:
SELECT Customers.CustomerID, CONCAT(FirstName, ' ', LastName) AS CustomerName, COUNT(OrderID) AS OrderCount
FROM Customers
LEFT JOIN Orders ON Customers.CustomerID = Orders.CustomerID
GROUP BY Customers.CustomerID, FirstName, LastName;

 


