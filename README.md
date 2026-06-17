# RetailERP

A practical, real-world Domain-Driven Design (DDD), Clean Architecture, and CQRS example for managing retail operations.

RetailERP is a backend application responsible for managing the core operations of a retail business, including:

* Product Catalog Management
* Product Variant Management
* Inventory Management
* Stock Transfers
* Sales Management
* Employee Management
* Employee Transfer Management
* Bonus Eligibility Management
* Sales Analytics

Built with C#, the project demonstrates how to structure enterprise applications using Domain-Driven Design (DDD), CQRS, Rich Domain Models, Specification Pattern, Factory Method Pattern, and Clean Architecture principles.

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
* Employee Position Assignment
* Employee Sales Tracking
* Employee Transfer Tracking

---

## Bonus Management

* Bonus Eligibility Validation
* Active Employee Validation
* Full Month Employment Validation
* Transfer-Based Bonus Restrictions
* Composite Eligibility Rules
* Dynamic Bonus Rule Infrastructure

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
* InventoryTransaction
* Employee
* EmployeeTransfer
* Sale
* SaleItem

---

## Application Layer

Contains CQRS commands, queries, DTOs, validators, specifications, factories, and business workflows.

Examples:

* CreateSaleCommand
* AddStockCommand
* TransferStockCommand
* CreateEmployeeTransferCommand
* CheckBonusEligibilityQuery
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
* EmployeeTransfer
* Sale
* SaleItem

---

## Aggregates

Aggregate roots manage consistency across related entities.

Examples:

* Product
* BranchInventory
* Employee
* EmployeeTransfer
* Sale

---

## Repositories

Repositories abstract persistence concerns.

Examples:

* IProductReadRepository
* IProductWriteRepository
* ISaleReadRepository
* IEmployeeReadRepository
* IEmployeeTransferReadRepository

---

## Ubiquitous Language

Shared business terminology:

* Branch
* Product Variant
* Inventory
* Sale
* Employee
* Employee Transfer
* Revenue
* Stock Transfer
* Bonus Eligibility

---

## Bounded Context

RetailERP is currently organized around the Retail Management bounded context.

Core modules:

* Catalog Management
* Inventory Management
* Sales Management
* Employee Management
* Bonus Management

---

# 🎯 Design Patterns Used

## CQRS (Command Query Responsibility Segregation)

Separates write and read operations.

Examples:

* Commands → CreateSale, AddStock, TransferStock, CreateEmployeeTransfer
* Queries → TopEmployees, RevenueByBranch, CheckBonusEligibility

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

Used for controlled object creation and business rule composition.

### DDD Factory Methods

Used to enforce invariants and create valid domain entities.

Examples:

* Product.Create()
* ProductVariant.Create()
* Sale.Create()
* Employee.Create()
* EmployeeTransfer.Create()

### GOF Factory Method

Used to encapsulate complex object creation and business rule assembly.

Examples:

* EmployeeBonusEligibilitySpecificationFactory

Responsibilities:

* Builds bonus eligibility specifications
* Encapsulates specification composition
* Centralizes business rule construction
* Keeps handlers focused on orchestration rather than object creation

Benefits:

* Improves maintainability
* Supports Open/Closed Principle
* Reduces handler complexity
* Simplifies future bonus rule extensions

---

## Specification Pattern

Encapsulates business rules into reusable specification objects.

Examples:

* ActiveEmployeeSpecification
* WorkedFullMonthSpecification
* NoTransferDuringMonthSpecification

---

## Composite Specification Pattern

Combines multiple specifications into a single business rule.

Examples:

* BonusEligibilitySpecification

---

## Unit of Work Pattern

Ensures transactional consistency across multiple operations.

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
EmployeeTransfer

Employee
 ↓
Sale
 ↓
SaleItem

Employee
 ↓
Bonus Eligibility
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
* Employee Activation / Deactivation
* Employee Transfer Management
* Employee Revenue Tracking
* Employee Performance Tracking

---

## Bonus Management

* Bonus Eligibility Validation
* Active Employee Validation
* Full Month Employment Validation
* Transfer Restriction Validation
* Composite Eligibility Evaluation

---

## Analytics

* Revenue By Employee
* Top Employees
* Revenue By Branch
* Top Selling Products
* Sales Summary By Date Range

---

# 🚀 Planned Features

* Fixed Bonus Strategy
* Percentage Bonus Strategy
* Top N Bonus Strategy
* Over Limit Bonus Strategy
* Combined Bonus Strategy
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
Catalog Management                ✅
Product Variants                  ✅
Inventory Management              ✅
Inventory Transactions            ✅
Sales Management                  ✅
Employee Management               ✅
Employee Transfers                ✅
Bonus Eligibility Engine          ✅
Sales Analytics                   ✅

Fixed Bonus Engine                🚧
Percentage Bonus Engine           🚧
Top N Bonus Engine                🚧
Over Limit Bonus Engine           🚧
```

The project is actively evolving feature by feature while following Domain-Driven Design, CQRS, Clean Architecture, Rich Domain Models, Specification Pattern, Factory Method Pattern, and modern enterprise application design principles.
