**Tasks 1: Database Design:**
1. Create the database named "HMBank" 
2. Define the schema for the Customers, Accounts, and Transactions tables based on the provided schema. 
3. Create an ERD (Entity Relationship Diagram) for the database. 
4. Create appropriate Primary Key and Foreign Key constraints for referential integrity. 
5. Write SQL scripts to create the mentioned tables with appropriate data types, constraints, and relationships. 
•	Customers 
•	Accounts 
•	Transactions

Query:

```sql
CREATE DATABASE HMBank_System;

USE HMBank_System;


CREATE TABLE Customers (
    customer_id INT PRIMARY KEY IDENTITY(1,1),
    first_name VARCHAR(50) NOT NULL,
    last_name VARCHAR(50) NOT NULL,
    DOB DATE NOT NULL,
    email VARCHAR(100) NOT NULL,
    phone_number VARCHAR(15) NOT NULL,
    address VARCHAR(255) NOT NULL
);
GO

CREATE TABLE Accounts (
    account_id INT PRIMARY KEY IDENTITY(1,1),
    customer_id INT FOREIGN KEY REFERENCES Customers(customer_id),
    account_type VARCHAR(50) NOT NULL,
    balance DECIMAL(18, 2) NOT NULL
);
GO

CREATE TABLE Transactions (
    transaction_id INT PRIMARY KEY IDENTITY(1,1),
    account_id INT FOREIGN KEY REFERENCES Accounts(account_id),
    transaction_type NVARCHAR(50) NOT NULL,
    amount DECIMAL(18, 2) NOT NULL,
    transaction_date DATETIME DEFAULT GETDATE()
);
GO
```

Entity Relationship Diagram:


![image](https://github.com/user-attachments/assets/64060d84-d561-47df-9997-b8d6a62d8916)



Tasks 2: Select, Where, Between, AND, LIKE:

1.	Insert at least 10 sample records into each of the following tables. 
• Customers 
• Accounts 
• Transactions

Query:

```sql
INSERT INTO Customers (first_name, last_name, DOB, email, phone_number, address)
VALUES 
('John', 'Doe', '1990-01-15', 'john.doe@example.com', '1234567890', '123 Main St'),
('Jane', 'Smith', '1985-05-20', 'jane.smith@example.com', '0987654321', '456 Elm St'),
('Alice', 'Johnson', '1978-12-30', 'alice.johnson@example.com', '1122334455', '789 Oak St'),
('Bob', 'Brown', '1995-07-25', 'bob.brown@example.com', '5566778899', '321 Pine St'),
('Charlie', 'Davis', '1980-03-10', 'charlie.davis@example.com', '9988776655', '654 Birch St'),
('Eva', 'Green', '1992-09-05', 'eva.green@example.com', '4433221100', '987 Cedar St'),
('Frank', 'Wilson', '1975-11-12', 'frank.wilson@example.com', '7788990011', '135 Maple St'),
('Grace', 'Harris', '1988-06-18', 'grace.harris@example.com', '6677889900', '246 Walnut St'),
('Henry', 'Clark', '1993-02-22', 'henry.clark@example.com', '5544332211', '369 Spruce St'),
('Ivy', 'Lewis', '1983-04-14', 'ivy.lewis@example.com', '2233445566', '753 Fir St');
GO
```

![image](https://github.com/user-attachments/assets/d618e41c-489d-468b-be5a-42a473f63ab8)
 

```sql
INSERT INTO Accounts (customer_id, account_type, balance)
VALUES 
(1, 'Savings', 1500.00),
(2, 'Current', 2500.00),
(3, 'Savings', 3000.00),
(4, 'Current', 4000.00),
(5, 'Savings', 5000.00),
(6, 'Current', 6000.00),
(7, 'Savings', 7000.00),
(8, 'Current', 8000.00),
(9, 'Savings', 9000.00),
(10, 'Current', 10000.00);
GO
```
 
![image](https://github.com/user-attachments/assets/a55a171b-cb9d-472d-aee0-bf8a16c32587)



```sql
INSERT INTO Transactions (account_id, transaction_type, amount, transaction_date)
VALUES 
(1, 'Deposit', 500.00,'2025-03-20'),
(2, 'Withdrawal', 200.00,'2025-03-11'),
(3, 'Deposit', 1000.00,'2025-02-26'),
(4, 'Withdrawal', 300.00,'2025-02-19'),
(5, 'Deposit', 1500.00,'2025-02-07'),
(6, 'Withdrawal', 400.00,'2025-01-28'),
(7, 'Deposit', 2000.00,'2025-01-14'),
(8, 'Withdrawal', 500.00,'2025-01-03'),
(9, 'Deposit', 2500.00,'2025-12-25'),
(10, 'Withdrawal', 600.00,'2025-12-17');
GO
```

![image](https://github.com/user-attachments/assets/f8726b8c-3db1-48a4-bcda-f9c9d5316c1e)
	

*2. Write SQL queries for the following tasks:*

1. Write a SQL query to retrieve the name, account type and email of all customers.
```sql
SELECT c.first_name, c.last_name, a.account_type, c.email
FROM Customers c
JOIN Accounts a ON c.customer_id = a.customer_id;
```
![image](https://github.com/user-attachments/assets/44de647f-c97c-4b67-9bcd-40ea5d68deba)

2. Write a SQL query to list all transaction corresponding customer.
```sql
SELECT t.transaction_id, t.transaction_type, t.amount, t.transaction_date
FROM Transactions t
JOIN Accounts a ON t.account_id = a.account_id
WHERE a.customer_id = 1;
```
![image](https://github.com/user-attachments/assets/0c81bb8d-80f9-4279-b103-6ddb46f94f02)


3. Write a SQL query to increase the balance of a specific account by a certain amount.
```sql
UPDATE Accounts
SET balance = balance + 500
WHERE account_id = 1;
```
![image](https://github.com/user-attachments/assets/0c91cc5f-7026-4b89-bd6f-8ef218b9322f)
 

4. Write a SQL query to Combine first and last names of customers as a full_name.
```sql
SELECT concat(first_name , ' ' ,last_name) AS full_name
FROM Customers;
```
![image](https://github.com/user-attachments/assets/0d96a6a8-9b26-45ed-88a6-9be6cfed8494)
 

5. Write a SQL query to remove accounts with a balance of zero where the account type is savings.
```sql
DELETE FROM Accounts
WHERE balance = 0 AND account_type = 'Savings';
``` 
![image](https://github.com/user-attachments/assets/997c6eea-c8e0-40c5-afc9-2eac0930818c)

6. Write a SQL query to Find customers living in a specific city.
```sql
SELECT *
FROM Customers
WHERE address LIKE '%Main St%';
``` 
![image](https://github.com/user-attachments/assets/a6ab6821-8944-4008-b00d-9a71d7144ea7)


7. Write a SQL query to Get the account balance for a specific account.
```sql
SELECT balance
FROM Accounts
WHERE account_id = 1;
``` 
![image](https://github.com/user-attachments/assets/658b2395-9f5f-4dfd-913a-64ab41d4d57b)

8. Write a SQL query to List all current accounts with a balance greater than $1,000.
```sql
SELECT *
FROM Accounts
WHERE account_type = 'Current' AND balance > 1000;
```
![image](https://github.com/user-attachments/assets/1a20b469-3472-4e01-bb1c-1895bb6eede2)
 

9. Write a SQL query to Retrieve all transactions for a specific account.
```sql
SELECT *
FROM Transactions
WHERE account_id = 1;
``` 
![image](https://github.com/user-attachments/assets/e39f93b2-f72a-4cb2-8b3c-1ede1d1d0838)

10. Write a SQL query to Calculate the interest accrued on savings accounts based on a given interest rate.
```sql
SELECT account_id, balance * 0.045 AS interest
FROM Accounts
WHERE account_type = 'Savings';
```
 ![image](https://github.com/user-attachments/assets/2e497901-a19b-4447-b54c-5ac005b4c848)

11. Write a SQL query to Identify accounts where the balance is less than a specified overdraft limit.
```sql
SELECT *
FROM Accounts
WHERE balance < 500;
```
![image](https://github.com/user-attachments/assets/84a98162-0251-4946-abd7-3addc4d53ba8)

 
12. Write a SQL query to Find customers not living in a specific city.
```sql
SELECT *
FROM Customers
WHERE address NOT LIKE '%Main St%';
``` 
![image](https://github.com/user-attachments/assets/b3c4e1fd-e8d3-4a35-94a1-64239b36fef1)

*Tasks 3: Aggregate functions, Having, Order By, GroupBy and Joins:*

1. Write a SQL query to Find the average account balance for all customers.
```sql
SELECT AVG(balance) AS average_balance
FROM Accounts;
```
![image](https://github.com/user-attachments/assets/9ff3743e-4110-4263-bcd9-f5b9f055a60e)

 
2. Write a SQL query to Retrieve the top 10 highest account balances.
```sql
SELECT TOP 10 *
FROM Accounts
ORDER BY balance DESC;
```
![image](https://github.com/user-attachments/assets/58245441-a870-4525-b87b-e6b9822f6b4d)

 
3. Write a SQL query to Calculate Total Deposits for All Customers in specific date.
```sql
SELECT SUM(amount) AS total_deposits
FROM Transactions
WHERE transaction_type = 'Deposit' AND CAST(transaction_date AS DATE) = '2023-10-01';
``` 
![image](https://github.com/user-attachments/assets/e6dda000-6cc1-4ada-92fa-ed365f0effe3)

4. Write a SQL query to Find the Oldest and Newest Customers.
```sql
SELECT MIN(DOB) AS oldest_customer, MAX(DOB) AS newest_customer
FROM Customers;
```
![image](https://github.com/user-attachments/assets/c57d63da-26e4-49d9-b7f0-fab28b565778)


5. Write a SQL query to Retrieve transaction details along with the account type.
```sql
SELECT t.transaction_id, t.transaction_type, t.amount, t.transaction_date, a.account_type
FROM Transactions t
JOIN Accounts a ON t.account_id = a.account_id;
```
![image](https://github.com/user-attachments/assets/0385a149-d72b-4350-aad9-8a5a9272d777)
 

6. Write a SQL query to Get a list of customers along with their account details.
```sql
SELECT c.first_name, c.last_name, a.account_id, a.account_type, a.balance
FROM Customers c
JOIN Accounts a ON c.customer_id = a.customer_id;
```
![image](https://github.com/user-attachments/assets/17949d8b-309d-41da-9699-7ea90ecbe7a6)


7. Write a SQL query to Retrieve transaction details along with customer information for a specific account.
```sql
SELECT t.transaction_id, t.transaction_type, t.amount, t.transaction_date, c.first_name, c.last_name
FROM Transactions t
JOIN Accounts a ON t.account_id = a.account_id
JOIN Customers c ON a.customer_id = c.customer_id
WHERE a.account_id = 1;
``` 
![image](https://github.com/user-attachments/assets/33b62c79-eaaf-46de-8553-7d94750a9b90)


8. Write a SQL query to Identify customers who have more than one account.
```sql
SELECT c.customer_id, c.first_name, c.last_name, COUNT(a.account_id) AS num_accounts
FROM Customers c
JOIN Accounts a ON c.customer_id = a.customer_id
GROUP BY c.customer_id, c.first_name, c.last_name
HAVING COUNT(a.account_id) > 1;
```

9. Write a SQL query to Calculate the difference in transaction amounts between deposits and withdrawals.
```sql
SELECT 
    SUM(CASE WHEN transaction_type = 'Deposit' THEN amount ELSE 0 END) - 
    SUM(CASE WHEN transaction_type = 'Withdrawal' THEN amount ELSE 0 END) AS net_difference
FROM Transactions;
``` 
![image](https://github.com/user-attachments/assets/d1990385-4b8d-44ef-961b-11ea45fc5bb5)


10. Write a SQL query to Calculate the average daily balance for each account over a specified period.

```sql
SELECT account_id, AVG(balance) AS average_daily_balance
FROM Accounts
WHERE account_id IN (
    SELECT DISTINCT account_id
    FROM Transactions
    WHERE transaction_date BETWEEN '2024-10-01' AND '2025-01-31'
)
GROUP BY account_id;
```
![image](https://github.com/user-attachments/assets/1e2bd725-9a41-4452-a91c-d391eabe0eb1)


11. Calculate the total balance for each account type.
```sql
SELECT account_type, SUM(balance) AS total_balance
FROM Accounts
GROUP BY account_type;
``` 
![image](https://github.com/user-attachments/assets/608a6ae5-d71d-4431-a14f-a4797d199aea)

12. Identify accounts with the highest number of transactions order by descending order.
```sql
SELECT account_id, COUNT(transaction_id) AS num_transactions
FROM Transactions
GROUP BY account_id
ORDER BY num_transactions DESC;
``` 
![image](https://github.com/user-attachments/assets/9993e659-ab87-4e54-9dc6-0f517a8f7752)


13. List customers with high aggregate account balances, along with their account types.
```sql
SELECT c.first_name, c.last_name, a.account_type, SUM(a.balance) AS total_balance
FROM Customers c
JOIN Accounts a ON c.customer_id = a.customer_id
GROUP BY c.first_name, c.last_name, a.account_type
HAVING SUM(a.balance) > 5000;
```
![image](https://github.com/user-attachments/assets/a15722d8-633e-4f25-ad2d-6cba9e05a516)
 

14. Identify and list duplicate transactions based on transaction amount, date, and account.
```sql
SELECT account_id, amount, transaction_date, COUNT(*) AS duplicate_count
FROM Transactions
GROUP BY account_id, amount, transaction_date
HAVING COUNT(*) > 1;
```

*Tasks 4: Subquery and its type:*

1. Retrieve the customer(s) with the highest account balance.
```sql
SELECT c.first_name, c.last_name, a.balance
FROM Customers c
JOIN Accounts a ON c.customer_id = a.customer_id
WHERE a.balance = (SELECT MAX(balance) FROM Accounts);
```
![image](https://github.com/user-attachments/assets/12c5da4a-93fc-413a-8c9f-c5e8cf7daa15)

 
2. Calculate the average account balance for customers who have more than one account.
```sql
SELECT AVG(balance) AS average_balance
FROM Accounts
WHERE customer_id IN (
    SELECT customer_id
    FROM Accounts
    GROUP BY customer_id
    HAVING COUNT(account_id) > 1
);
```
![image](https://github.com/user-attachments/assets/43029616-09bf-4e96-832b-b97b9cea20a9)

 
3. Retrieve accounts with transactions whose amounts exceed the average transaction amount.
```sql
SELECT DISTINCT a.account_id, a.balance
FROM Accounts a
JOIN Transactions t ON a.account_id = t.account_id
WHERE t.amount > (SELECT AVG(amount) FROM Transactions);
```
![image](https://github.com/user-attachments/assets/31e91df9-8492-4a64-8c67-92e9178e6daf)


4. Identify customers who have no recorded transactions.
```sql
SELECT c.customer_id, c.first_name, c.last_name
FROM Customers c
LEFT JOIN Accounts a ON c.customer_id = a.customer_id
LEFT JOIN Transactions t ON a.account_id = t.account_id
WHERE t.transaction_id IS NULL;
```
![image](https://github.com/user-attachments/assets/319f03dc-748d-48ef-9ded-e40f05bbaf93)


5. Calculate the total balance of accounts with no recorded transactions.
```sql
SELECT SUM(a.balance) AS total_balance
FROM Accounts a
LEFT JOIN Transactions t ON a.account_id = t.account_id
WHERE t.transaction_id IS NULL;
```
![image](https://github.com/user-attachments/assets/ab2d84f0-91da-46e6-afef-ddcbbc813a27)

 
6. Retrieve transactions for accounts with the lowest balance.
```sql
SELECT t.*
FROM Transactions t
JOIN Accounts a ON t.account_id = a.account_id
WHERE a.balance = (SELECT MIN(balance) FROM Accounts);
```
![image](https://github.com/user-attachments/assets/8d551f35-b51b-4587-a4c1-3bcec6860d54)

 
7. Identify customers who have accounts of multiple types.
```sql
SELECT c.customer_id, c.first_name, c.last_name
FROM Customers c
JOIN Accounts a ON c.customer_id = a.customer_id
GROUP BY c.customer_id, c.first_name, c.last_name
HAVING COUNT(DISTINCT a.account_type) > 1;
```

8. Calculate the percentage of each account type out of the total number of accounts.
```sql
SELECT 
    account_type, 
    COUNT(*) * 100.0 / (SELECT COUNT(*) FROM Accounts) AS percentage
FROM Accounts
GROUP BY account_type;
```
![image](https://github.com/user-attachments/assets/b4b93418-48f6-43fe-9a0a-d11a7b03a461)


9. Retrieve all transactions for a customer with a given customer_id.
```sql
SELECT t.*
FROM Transactions t
JOIN Accounts a ON t.account_id = a.account_id
WHERE a.customer_id = 1;
``` 
![image](https://github.com/user-attachments/assets/d961dfd5-292a-43fd-a539-a81303f8e8bc)


10. Calculate the total balance for each account type, including a subquery within the SELECT clause.
```sql
SELECT 
    account_type, 
    (SELECT SUM(balance) FROM Accounts a2 WHERE a2.account_type = a1.account_type) AS total_balance
FROM Accounts a1
GROUP BY account_type;
```

![image](https://github.com/user-attachments/assets/4e9894c5-666d-4c3a-96ae-502ad16f51ad)
 
