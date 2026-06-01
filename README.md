
# Warehouse Inventory Management System

## Overview

This project is a desktop-based warehouse and inventory management system developed using **C# Windows Forms** and **SQL Server**.

The application allows users to manage products, suppliers, stock entries, stock outputs, and inventory movements. It also includes database-level structures such as stored procedures, triggers, views, transactions, and log tables to provide a more reliable and structured data management process.

## Features

* User login system
* Product management
* Supplier management
* Stock entry operations
* Stock output operations
* Automatic stock quantity updates
* Critical stock level tracking
* Stock movement history
* Last purchase price tracking
* Supplier listing and deletion
* Database view for critical stock products
* Stored procedures for controlled database operations
* Triggers for automatic stock and log updates
* Transaction-based operations
* Log table support for important actions

## Technologies Used

* C#
* Windows Forms
* SQL Server
* Object-Oriented Programming

## Database Features

This project uses SQL Server as the database system. The database includes:

* Tables
* Views
* Stored Procedures
* Triggers
* Transactions
* Log Tables
* Foreign Key Relationships

## Project Purpose

The main purpose of this project is to develop a practical inventory management system while improving database design, desktop application development, and SQL programming skills.

This project was developed as an academic software project and represents a complete desktop application connected to a relational database.

## What I Learned

Through this project, I improved my knowledge of:

* C# Windows Forms application development
* SQL Server database design
* Relational database relationships
* CRUD operations
* Stored procedure usage
* Trigger-based automation
* Transaction management
* DataGridView usage in Windows Forms
* Connecting C# applications with SQL Server
* Building structured desktop applications

## Database Setup

To run this project, create the database using the SQL scripts provided in the `database` folder.

Recommended order:

```text
1. database_schema.sql
2. views.sql
3. stored_procedures.sql
4. triggers.sql
5. sample_data.sql
```

After creating the database, update the connection string in the project according to your local SQL Server configuration.

## Detailed Project Report

A detailed academic report of the project can be found in the `docs` folder.

## How to Run

```text
1. Clone the repository
2. Open the project in Visual Studio
3. Create the SQL Server database using the scripts in the database folder
4. Update the connection string
5. Build and run the Windows Forms application
```

