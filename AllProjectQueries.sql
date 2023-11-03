-- This command alters the table 'tbUser' by adding a new column called 'userID' of type 'int'. The 'IDENTITY(1,1)' means the column will auto-increment starting from 1 and will increment by 1 each time a new row is added. 'NOT NULL' specifies that the column cannot have NULL values.
/*ALTER TABLE dbo.tbUser
ADD userID int IDENTITY(1,1) NOT NULL;*/

-- This query retrieves the name of the primary key constraint associated with the 'tbUser' table from system views.
/*SELECT name AS ConstraintName 
FROM sys.key_constraints 
WHERE type = 'PK' AND [parent_object_id] = OBJECT_ID('tbUser');*/

-- Removes the existing primary key constraint from the 'tbUser' table. The constraint name is specified within square brackets.
/*ALTER TABLE dbo.tbUser
DROP CONSTRAINT [PK__tmp_ms_x__F3DBC5738A56F1FA];*/

-- Adds a new primary key constraint to the 'userID' column in the 'tbUser' table.
/*ALTER TABLE dbo.tbUser
ADD PRIMARY KEY (userID);*/

-- Adds a unique constraint to the 'username' column in the 'tbUser' table, ensuring that no two rows can have the same username.
/*ALTER TABLE dbo.tbUser
ADD CONSTRAINT UC_Users_Username UNIQUE (username);*/

-- Creates a new table named 'tbUserNew' with specified columns and their data types. 'userID' is set as the primary key, and 'username' cannot be NULL.
/*CREATE TABLE dbo.tbUserNew
(
    userID INT PRIMARY KEY,
    username VARCHAR(50) NOT NULL,
    fullname VARCHAR(50),
    password VARCHAR(50),
    phone VARCHAR(50)
);*/

-- Adds a unique constraint to the 'username' column in the newly created 'tbUserNew' table.
/*ALTER TABLE dbo.tbUserNew
ADD CONSTRAINT UC_tbUser_username UNIQUE (username);*/

-- Inserts records from the 'tbUser' table into the 'tbUserNew' table by selecting all columns.
/*INSERT INTO dbo.tbUserNew(userID, username, fullname, password, phone)
SELECT userID, username, fullname, password, phone FROM dbo.tbUser;*/

-- Deletes the 'tbUser' table from the database.
/*DROP TABLE dbo.tbUser;*/

-- Renames the 'tbUserNew' table to 'tbUser'.
/*EXEC sp_rename 'dbo.tbUserNew', 'tbUser';*/

-- Create a Roles Table
/*CREATE TABLE tbRole (
    roleID INT PRIMARY KEY IDENTITY(1,1),
    roleName VARCHAR(255)
);*/

--Create a UserRoles Table
/*CREATE TABLE tbUserRole (
    userID INT,
    roleID INT,
    FOREIGN KEY (userID) REFERENCES tbUser(userID),
    FOREIGN KEY (roleID) REFERENCES tbRole(roleID)
);*/

--Create a Permissions Table
/*CREATE TABLE tbPermission (
    permissionID INT PRIMARY KEY IDENTITY(1,1),
    permissionName VARCHAR(255),
    roleID INT,
    FOREIGN KEY (roleID) REFERENCES tbRole(roleID)
);*/

--Populate tbRole
/*INSERT INTO tbRole (roleName) VALUES ('Admin');
INSERT INTO tbRole (roleName) VALUES ('Manager');
INSERT INTO tbRole (roleName) VALUES ('Employee');*/

--Populate tbPermission
-- For Admin (assuming Admin has roleID 1)
/*INSERT INTO tbPermission (permissionName, roleID) VALUES ('User Management: Full Control', 1);
INSERT INTO tbPermission (permissionName, roleID) VALUES ('Inventory Management: Full Control', 1);
INSERT INTO tbPermission (permissionName, roleID) VALUES ('Alerts and Notifications: Full Control', 1);
INSERT INTO tbPermission (permissionName, roleID) VALUES ('Reporting and Analytics: Full Control', 1);
INSERT INTO tbPermission (permissionName, roleID) VALUES ('Supplier Ordering: Full Control', 1);*/

--For the Manager
-- For Manager
/*INSERT INTO tbPermission (permissionName, roleID) VALUES ('User Management: View and Reset Password', 2);
INSERT INTO tbPermission (permissionName, roleID) VALUES ('Inventory Management: Add, Edit, Delete Products', 2);
INSERT INTO tbPermission (permissionName, roleID) VALUES ('Alerts and Notifications: View and Customize', 2);
INSERT INTO tbPermission (permissionName, roleID) VALUES ('Reporting and Analytics: Generate and Customize Reports', 2);
INSERT INTO tbPermission (permissionName, roleID) VALUES ('Supplier Ordering: View and Approve', 2);*/

--for the Employee
-- For Employee
/*INSERT INTO tbPermission (permissionName, roleID) VALUES ('User Management: No Access', 3);
INSERT INTO tbPermission (permissionName, roleID) VALUES ('Inventory Management: Add and Edit Products', 3);
INSERT INTO tbPermission (permissionName, roleID) VALUES ('Alerts and Notifications: Receive and View', 3);
INSERT INTO tbPermission (permissionName, roleID) VALUES ('Reporting and Analytics: View Reports', 3);
INSERT INTO tbPermission (permissionName, roleID) VALUES ('Supplier Ordering: No Access', 3);*/

/*EXEC sp_columns 'tbUser';*/
/*EXEC sp_columns 'tbRole';*/

/*ALTER TABLE tbUser ADD userRole INT;*/

/*ALTER TABLE tbUser
ADD FOREIGN KEY (userRole) REFERENCES tbRole(roleID);*/

/*EXEC sp_rename 'tbUser.userRole', 'roleID', 'COLUMN';*/

/*UPDATE tbUser SET roleID = 1 WHERE username = 'admin';*/
/*UPDATE tbUser SET roleID = 1 WHERE username = 'nmanning';*/
/*UPDATE tbUser SET roleID = 2 WHERE username = 'Manager';*/
/*UPDATE tbUser SET roleID = 3 WHERE username = 'brad';*/
/*UPDATE tbUser SET roleID = 2 WHERE username = 'Simoney';*/

/*ALTER TABLE tbUser ADD IsPasswordReset BIT NOT NULL DEFAULT 0;*/


































