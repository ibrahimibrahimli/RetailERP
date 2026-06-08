# RetailERP

A practical, real-world Domain-Driven Design (DDD), Clean Architecture, and CQRS example for managing retail operations.

RetailERP is a backend application responsible for managing the core operations of a retail business, including:

* Product Catalog Management
* Product Variant Management
* Inventory Management
* Stock Transfers
* Sales Management
* Employee Management
* Sales Analytics

Built with C#, the project demonstrates how to structure enterprise applications using Domain-Driven Design (DDD), CQRS, Rich Domain Models, and Clean Architecture principles.

---

# 📖 Table of Contents

* Features
* Clean Architecture Overview
* Domain-Driven Design Principles and Patterns
* Design Patterns Used
* Technologies Used
* Project Structure
* Current Domain Model
* Current Features
* Planned Features
* Status

---

# ✨ Features

## Product Catalog

* Create Products
* Brand-Based Product Management
* Product Variant Management
* SKU Tracking
* Barcode Tracking
* Color & Size Variants

---

## Inventory Management

* Inventory Activation
* Add Stock
* Transfer Stock Between Branches
* Low Stock Monitoring
* Inventory Availability Tracking

---

## Inventory Transactions

* Stock In
* Stock Out
* Stock Transfers
* Sale Transactions
* Reference Code Tracking
* Inventory Audit Trail

---

## Sales Management

* Create Sales
* Multi Item Sales
* Invoice Number Generation
* Payment Method Support
* Inventory Integration

---

## Employee Management

* Create Employees
* Activate Employees
* Deactivate Employees
* Employee Branch Assignment
* Employee Sales Tracking

---

## Sales Analytics

* Revenue By Employee
* Top Employees
* Revenue By Branch
* Top Selling Products
* Sales Summary By Date Range

---

# 🏗 Clean Architecture Overview

RetailERP follows Clean Architecture principles.

## Domain Layer

Contains the core business rules and domain entities.

Examples:

* Product
* ProductVariant
* BranchInventory
* Sale
* SaleItem
* Employee

---

## Application Layer

Contains CQRS commands, queries, DTOs, validators, and business workflows.

Examples:

* CreateSaleCommand
* AddStockCommand
* TransferStockCommand
* GetTopEmployeesQuery

---

## Persistence Layer

Handles Entity Framework Core configurations, repositories, and database interactions.

---

## API Layer

Exposes REST endpoints using ASP.NET Core Web API.

---

# ⚙️ Domain-Driven Design Principles and Patterns

## Entities

Rich domain models encapsulating business rules.

Examples:

* Product
* ProductVariant
* BranchInventory
* Employee
* Sale
* SaleItem

---

## Aggregates

Aggregate roots manage consistency across related entities.

Examples:

* Product
* BranchInventory
* Sale
* Employee

---

## Repositories

Repositories abstract persistence concerns.

Examples:

* IProductReadRepository
* IProductWriteRepository
* ISaleReadRepository
* IEmployeeReadRepository

---

## Ubiquitous Language

Shared business terminology:

* Branch
* Product Variant
* Inventory
* Sale
* Employee
* Revenue
* Stock Transfer

---

## Bounded Context

RetailERP is currently organized around the Retail Management bounded context.

Core modules:

* Catalog Management
* Inventory Management
* Sales Management
* Employee Management

---

# 🎯 Design Patterns Used

## CQRS (Command Query Responsibility Segregation)

Separates write and read operations.

Examples:

* Commands → CreateSale, AddStock, TransferStock
* Queries → TopEmployees, RevenueByBranch

---

## Repository Pattern

Abstracts database access from application logic.

---

## Result Pattern

Provides consistent success/failure responses.

---

## Mediator Pattern

Implemented using MediatR.

---

## Factory Method Pattern

Used for controlled entity creation.

Examples:

* Product.Create()
* ProductVariant.Create()
* Sale.Create()
* Employee.Create()

---

## Unit of Work Pattern

Ensures transactional consistency.

---

# 💻 Technologies Used

* C#
* .NET 9
* ASP.NET Core Web API
* Entity Framework Core
* PostgreSQL
* MediatR
* FluentValidation
* Swagger / OpenAPI

---

# 📂 Project Structure

```text
src/
├── RetailERP.API
├── RetailERP.Application
├── RetailERP.Domain
└── RetailERP.Persistence
```

---

# 🧩 Current Domain Model

```text
SubCompany
 ↓
Brand
 ↓
Branch

Brand
 ↓
Product
 ↓
ProductVariant

Branch
 ↓
BranchInventory
 ↓
InventoryTransaction

Employee
 ↓
Sale
 ↓
SaleItem
```

---

# 🛠 Current Features

## Catalog Management

* Product Creation
* Product Variant Creation
* SKU Tracking
* Barcode Tracking

---

## Inventory Management

* Inventory Activation
* Add Stock
* Stock Transfers
* Inventory Availability Lookup
* Low Stock Monitoring

---

## Sales Management

* Create Sale
* Multi Item Sales
* Invoice Generation
* Payment Tracking

---

## Employee Management

* Employee Creation
* Activation / Deactivation
* Employee Revenue Tracking
* Employee Performance Tracking

---

## Analytics

* Revenue By Employee
* Top Employees
* Revenue By Branch
* Top Selling Products
* Sales Summary By Date Range

---

# 🚀 Planned Features

* Supplier Management
* Purchase Management
* Warehouse Management
* Authentication
* Authorization
* Role & Permission Management
* Audit Logging
* Notifications
* Reporting Dashboard

---

# 📊 Status

Current state:

```text
Catalog Management            ✅
Product Variants             ✅
Inventory Management         ✅
Inventory Transactions       ✅
Sales Management             ✅
Employee Management          ✅
Sales Analytics              ✅
```

The project is actively evolving feature by feature while following Domain-Driven Design, CQRS, and Clean Architecture principles.
