/*Table Modification and Constraints*/
/*Modifying 'tbUser' Table*/
-- Adds new column 'userID' to 'tbUser'
/*ALTER TABLE dbo.tbUser
ADD userID int IDENTITY(1,1) NOT NULL;*/

-- Removes existing primary key constraint from 'tbUser'
/*ALTER TABLE dbo.tbUser
DROP CONSTRAINT [PK__tmp_ms_x__F3DBC5738A56F1FA];*/

-- Adds new primary key constraint to 'userID' in 'tbUser'
/*ALTER TABLE dbo.tbUser
ADD PRIMARY KEY (userID);*/

-- Adds unique constraint to 'username' in 'tbUser'
/*ALTER TABLE dbo.tbUser
ADD CONSTRAINT UC_Users_Username UNIQUE (username);*/

/*Creating 'tbUserNew' Table*/
-- Creates new table 'tbUserNew'
/*CREATE TABLE dbo.tbUserNew
(
    userID INT PRIMARY KEY,
    username VARCHAR(50) NOT NULL,
    fullname VARCHAR(50),
    password VARCHAR(50),
    phone VARCHAR(50)
);*/

-- Adds unique constraint to 'username' in 'tbUserNew'
/*ALTER TABLE dbo.tbUserNew
ADD CONSTRAINT UC_tbUser_username UNIQUE (username);*/

/*Inserting Data and Table Renaming*/
-- Inserts records from 'tbUser' to 'tbUserNew'
/*INSERT INTO dbo.tbUserNew(userID, username, fullname, password, phone)
SELECT userID, username, fullname, password, phone FROM dbo.tbUser;*/

-- Deletes 'tbUser' table
/*DROP TABLE dbo.tbUser;*/

-- Renames 'tbUserNew' to 'tbUser'
/*EXEC sp_rename 'dbo.tbUserNew', 'tbUser';*/

/*Role and Permission Management*/
/*Creating Role and Permission Tables*/
-- Create 'tbRole' table
/*CREATE TABLE tbRole (
    roleID INT PRIMARY KEY IDENTITY(1,1),
    roleName VARCHAR(255)
);*/

-- Create 'tbUserRole' table
/*CREATE TABLE tbUserRole (
    userID INT,
    roleID INT,
    FOREIGN KEY (userID) REFERENCES tbUser(userID),
    FOREIGN KEY (roleID) REFERENCES tbRole(roleID)
);*/

-- Create 'tbPermission' table
/*CREATE TABLE tbPermission (
    permissionID INT PRIMARY KEY IDENTITY(1,1),
    permissionName VARCHAR(255),
    roleID INT,
    FOREIGN KEY (roleID) REFERENCES tbRole(roleID)
);*/

/*Populating Roles and Permissions*/
-- Populate 'tbRole'
/*INSERT INTO tbRole (roleName) VALUES ('Admin');
INSERT INTO tbRole (roleName) VALUES ('Manager');
INSERT INTO tbRole (roleName) VALUES ('Employee');*/

-- Populate 'tbPermission' for Admin
/*INSERT INTO tbPermission (permissionName, roleID) VALUES ('User Management: Full Control', 1);
... [more permissions for Admin]*/

-- Populate 'tbPermission' for Manager
/*INSERT INTO tbPermission (permissionName, roleID) VALUES ('User Management: View and Reset Password', 2);
... [more permissions for Manager]*/

-- Populate 'tbPermission' for Employee
/*INSERT INTO tbPermission (permissionName, roleID) VALUES ('User Management: No Access', 3);
... [more permissions for Employee]*/

/* User Role Assignment*/
/*Adding and Assigning User Roles in 'tbUser'*/
-- Add 'userRole' column to 'tbUser'
/*ALTER TABLE tbUser ADD userRole INT;*/

-- Add foreign key constraint
/*ALTER TABLE tbUser
ADD FOREIGN KEY (userRole) REFERENCES tbRole(roleID);*/

-- Rename 'userRole' to 'roleID'
/*EXEC sp_rename 'tbUser.userRole', 'roleID', 'COLUMN';*/

-- Update specific users with roles
/*UPDATE tbUser SET roleID = 1 WHERE username = 'admin';
... [other user updates]*/

/*Additional Table Alterations*/
/*Altering 'tbUser' Table Further*/
-- Add 'isPasswordReset' column
/*ALTER TABLE tbUser ADD IsPasswordReset BIT NOT NULL DEFAULT 0;*/

-- Rename 'IsPasswordReset' to 'isPasswordReset'
/*EXEC sp_rename 'tbUser.IsPasswordReset', 'isPasswordReset', 'COLUMN';*/

-- Alter 'password' column data type
/*ALTER TABLE tbUser
ALTER COLUMN password NVARCHAR(64) NOT NULL;*/
/*Altering 'tbOrder' Table*/
-- Change data type of 'price' and 'total' columns
/*ALTER TABLE tbOrder ALTER COLUMN price DECIMAL(10, 2);*/
/*ALTER TABLE tbOrder ALTER COLUMN total DECIMAL(10, 2);*/

/* Alert System Implementation*/
/*Creating Alert Settings and Logs*/
-- Create 'tbAlertSettings' table
/*CREATE TABLE tbAlertSettings (
    alertID INT PRIMARY KEY IDENTITY(1,1),
    alertType VARCHAR(255),
    threshold INT,
    isEnabled BIT
);*/

-- Populate 'tbAlertSettings' with default alert types
/*INSERT INTO tbAlertSettings (alertType, threshold, isEnabled) VALUES 
    ('Low-Stock', 0, 1),
    ... [other alert types]*/

-- Create 'tbAlertLog' table
/*CREATE TABLE tbAlertLog (
    logID INT PRIMARY KEY IDENTITY(1,1),
    alertID INT,
    triggeredOn DATETIME,
    message VARCHAR(255),
    isResolved BIT,
    FOREIGN KEY (alertID) REFERENCES tbAlertSettings(alertID)
);*/
/*Modifying 'tbProduct' and 'tbOrder' for Alerts*/
-- Add 'LowStockThreshold', 'expiredatee', and 'status' columns to 'tbProduct'
/*ALTER TABLE tbProduct
ADD LowStockThreshold INT NOT NULL DEFAULT 10;
ALTER TABLE tbProduct
ADD expiredatee DATE NULL;

-- Add 'status' column to 'tbOrder'
ALTER TABLE tbOrder
ADD status VARCHAR(50) DEFAULT 'Pending';

-- Rename 'LowStockThreshold' to 'lowstockthreshold'
EXEC sp_rename 'tbProduct.LowStockThreshold', 'lowstockthreshold', 'COLUMN';*/

/*System Information Retrieval*/
/*Retrieving System InformatioN*/
-- Get column information for 'tbUser' and 'tbRole'
/*EXEC sp_columns 'tbUser';*/
/*EXEC sp_columns 'tbRole';*/

-- Select information from schema tables
/*SELECT * FROM information_schema.tables;*/
/*SELECT * FROM information_schema.columns;*/

-- Get information on 'tbOrder'
/*sp_help tbOrder;*/

/*Product and Order Management*/
/*Inserting and Updating Products and Orders*/
-- Insert new products into 'tbProduct'
/*INSERT INTO tbProduct (pname, pqty, pprice, pdescription, pcategory, lowstockthreshold, expiredatee)
VALUES ('Product Name', 10, 100, 'Description', 'Category', 5, '2023-01-01');
... [other product insertions]*/

-- Insert new orders into 'tbOrder'
/*INSERT INTO tbOrder (odate, pid, cid, qty, price, total, status)
VALUES (GETDATE() - 5, 1, 1, 5, 9.99, 49.95, 'Pending');
... [other order insertions]*/

-- Update product prices and alert log related to products
/*ALTER TABLE tbProduct
ALTER COLUMN pprice money;*/

/*Clean-up and Reset Operations*/
/*Alert Log Maintenance*/
-- Delete all entries from 'tbAlertLog' and reset identity
/*DELETE FROM tbAlertLog;
DBCC CHECKIDENT ('tbAlertLog', RESEED, 0);*/

-- Add 'LastCheckedOn' in 'tbAlertLog' and 'tbProduct'
/*ALTER TABLE tbAlertLog
ADD LastCheckedOn DATETIME NULL;*/
/*ALTER TABLE tbProduct
ADD lastCheckedOn DATETIME NULL;*/

-- Truncate 'tbAlertLog' and reseed identity
/*TRUNCATE TABLE tbAlertLog;
DBCC CHECKIDENT ('tbAlertLog', RESEED, 1);*/

/*Financial and Sales Management*/
/*Creating 'tbSales' Table*/
-- Define structure for tracking sales with foreign key references
/*CREATE TABLE tbSales (
    saleID INT PRIMARY KEY IDENTITY(1,1),
    productID INT NOT NULL,
    quantitySold INT NOT NULL,
    totalAmount DECIMAL(18, 2) NOT NULL,
    saleDate DATETIME NOT NULL,
    customerID INT,
    FOREIGN KEY (productID) REFERENCES tbProduct(pid),
    FOREIGN KEY (customerID) REFERENCES tbCustomer(cid)
);*/

/*Product Expiration and Perishability*/
/*Handling Product Expiration and Perishability*/
-- Alter 'tbProduct' to include 'isPerishable'
/*ALTER TABLE tbProduct
ADD isPerishable BIT DEFAULT 0 NOT NULL;*/

-- Insert new alert type for expired products
/*INSERT INTO tbAlertSettings (alertType, threshold, isEnabled)
VALUES ('Expired-Product', 0, 'True');*/

-- Select perishable grocery products based on expiration date
/*SELECT * FROM tbProduct WHERE expiredatee BETWEEN '2023-11-01' AND '2023-11-29' AND pcategory = 'Groceries' AND isPerishable = 1*/
