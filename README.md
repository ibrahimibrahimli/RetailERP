# RetailERP

Modern Retail ERP backend project built with **.NET 9**, **Clean Architecture**, **CQRS**, and **Domain-Driven Design principles**.

This project is being developed as a real-world retail ERP system focused on:

* Maintainable architecture
* Scalable domain modeling
* Inventory management
* Sales operations
* Branch management
* Clean backend engineering practices

---

# Current Architecture

The project follows a layered Clean Architecture structure.

```text
src/
 ├── RetailERP.API
 ├── RetailERP.Application
 ├── RetailERP.Domain
 └── RetailERP.Persistence
```

---

# Technologies

* .NET 9 Web API
* Entity Framework Core
* PostgreSQL
* MediatR
* FluentValidation
* Swagger / OpenAPI

---

# Architectural Approaches

## Clean Architecture

Responsibilities are separated into different layers:

* Domain → Business rules and entities
* Application → Use cases and CQRS flows
* Persistence → EF Core and database access
* API → Controllers and HTTP layer

---

## CQRS (Command Query Responsibility Segregation)

Read and write operations are separated.

### Commands

```text
CreateBrand
CreateBranch
CreateProduct
CreateProductVariant
CreateSale

AddStock
TransferStock
```

### Queries

```text
GetAllBrands
GetAllSales
GetSalesByBranch
GetSalesByDateRange

GetLowStockInventories
GetProductVariantAvailability
```

---

## Rich Domain Model

Business behavior lives inside entities instead of services.

Example:

```csharp
inventory.AddStock(quantity, referenceCode);

inventory.TransferOut(
    quantity,
    referenceCode);

inventory.SellProduct(
    quantity,
    referenceCode);
```

The goal is to keep business rules protected inside the domain layer.

---

## Vertical Slice Architecture

Each feature is organized independently.

```text
Features/
 ├── Brands/
 ├── Branches/
 ├── Products/
 ├── ProductVariants/
 ├── BranchInventories/
 └── Sales/
```

---

# Current Domain Structure

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
      ↓
BranchInventory
             ↓
InventoryTransaction

Branch
   ↓
BranchInventory

Sale
   ↓
SaleItem
```

---

# Implemented Modules

## SubCompany Management

* Create SubCompany
* Get All SubCompanies
* Soft delete support
* CQRS flow
* Validation pipeline

---

## Brand Management

* Create Brand
* Update Brand
* Delete Brand (Soft Delete)
* Get All Brands
* Brand ↔ SubCompany relationship

---

## Branch Management

* Create Branch
* Brand ↔ Branch relationship
* Branch activation structure

---

## Product Catalog

* Create Product
* Brand ↔ Product relationship
* Product catalog foundation

---

## Product Variant Management

Implemented SKU-based retail product modeling.

### Features

* Create Product Variant
* Color support
* Size support
* SKU support
* Barcode support

### Example

```text
Nike Air Max 90
 ├── Black / 41
 ├── Black / 42
 ├── White / 41
 └── White / 42
```

### Domain Model

```text
Product
   ↓
ProductVariant
```

---

## Branch Inventory Management

Implemented inventory management using product variants.

### Inventory Activation

```text
ProductVariant + Branch
            ↓
     BranchInventory
```

### Stock Operations

* Add Stock
* Transfer Stock Between Branches

### Inventory Monitoring

* Low Stock Query
* Minimum Stock Level Tracking
* Variant Availability Across Branches

---

## Inventory Transactions

Implemented inventory audit trail.

### Supported Transaction Types

* Add Stock
* Transfer In
* Transfer Out
* Sale

### Features

* Reference Code Tracking
* Inventory History
* Audit Trail
* Operational Traceability

---

## Sales Management

Implemented complete sales workflow.

### Features

* Create Sale
* Multi-item Sales
* Invoice Number Generation
* Payment Method Support
* Inventory Integration

### Sales Flow

```text
Sale
   ↓
SaleItem
   ↓
Inventory Decrease
   ↓
InventoryTransaction
```

---

## Sale Item Snapshots

Historical sales information is stored as immutable snapshots.

### Stored Data

* Product Name
* Color
* Size
* SKU
* Unit Price

This ensures historical invoices remain unchanged even if product data changes later.

---

## Sales Reporting

Implemented reporting queries for operational analytics.

### Available Reports

* Get All Sales
* Get Sale By Id
* Get Sales By Branch
* Get Sales By Date Range

---

## Variant Availability

Implemented cross-branch variant availability lookup.

### Example

```text
Nike Air Max 90
Black / 41
```

Availability:

```text
Podgorica → 10
Budva     → 4
Bar       → 2
```

This allows store employees to check stock availability across branches.

---

# Validation & Error Handling

## FluentValidation Pipeline

Validation is centralized using MediatR pipeline behaviors.

---

## Global Exception Middleware

Unhandled exceptions are captured centrally.

---

## Result Pattern

Business failures return controlled results instead of throwing exceptions.

Example:

```csharp
Result.Success();

Result.Failure(
    "Insufficient stock.");
```

---

# Design Patterns Used

## GoF Patterns

* Factory Method
* Mediator
* Decorator
* Chain of Responsibility

---

## Enterprise / Modern Patterns

* CQRS
* Repository Pattern
* Unit of Work
* Result Pattern
* DTO Pattern
* Read Model Pattern
* Rich Domain Model
* Vertical Slice Architecture
* Aggregate Root Pattern
* Soft Delete Pattern
* Business Key Pattern

---

# Design Principles

* SOLID
* Separation of Concerns
* Encapsulation
* Single Source of Truth
* Ubiquitous Language
* Transactional Consistency
* Historical Snapshot Modeling

---

# Current Features

## Inventory

* Inventory activation
* Stock increase
* Stock transfer
* Low stock monitoring
* Inventory transaction tracking
* Variant availability search

---

## Sales

* Sales workflow
* Invoice generation
* Sales history
* Branch sales reporting
* Date range sales reporting

---

# Planned Features

The project will continue evolving with:

* Employee Management
* Employee-Based Sales Tracking
* Bonus System
* Advanced Product Search
* Top Selling Products Reports
* Inventory Valuation Reports
* Supplier Management
* Purchase Management
* Warehouse Management
* Authentication & Authorization
* Role & Permission Management
* Audit Logging

---

# Project Goals

This project is being developed to:

* Practice enterprise backend architecture
* Understand real-world ERP domain modeling
* Improve Clean Architecture knowledge
* Learn scalable system design
* Build production-level backend engineering skills

---

# Status

Current state:

```text
Retail catalog completed.
Product variant system completed.
Inventory management completed.
Sales management completed.
Sales reporting completed.
Cross-branch variant availability completed.
Inventory audit trail completed.
```

The project is actively evolving feature by feature following real-world ERP requirements and domain-driven design practices.
