# RetailERP
# RetailERP

Modern Retail ERP backend project built with **.NET 9**, **Clean Architecture**, **CQRS**, and **Domain-Driven Design principles**.

This project is being developed as a real-world retail ERP system focused on:

* maintainable architecture
* scalable domain modeling
* inventory management
* branch operations
* clean backend engineering practices

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

* Domain → business rules and entities
* Application → use cases and CQRS flows
* Persistence → EF Core and database access
* API → controllers and HTTP layer

---

## CQRS (Command Query Responsibility Segregation)

Read and write operations are separated.

Example:

```text
Commands
 ├── CreateProduct
 ├── AddStock
 ├── TransferStock
 └── SellProduct

Queries
 ├── GetAllBrands
 ├── GetLowStockInventories
 └── GetAllSubCompanies
```

---

## Rich Domain Model

Business behavior lives inside entities instead of services.

Example:

```csharp
inventory.IncreaseStock(quantity);
inventory.DecreaseStock(quantity);
product.UpdatePrice(price);
```

The goal is to keep business rules protected inside the domain layer.

---

## Vertical Slice Architecture

Each feature is organized independently.

```text
Features/
 ├── Products/
 ├── Brands/
 ├── Branches/
 └── BranchInventories/
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

Product
   ↓
BranchInventory
   ↓
Branch
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
* Composite business constraints
* Branch activation structure

---

## Product Catalog

* Create Product
* Barcode-based business identity
* Brand ↔ Product relationship
* Product catalog foundation

---

## Branch Inventory Management

Implemented retail inventory operations:

### Inventory Activation

```text
Product + Branch → BranchInventory
```

### Stock Operations

* Add Stock
* Sell Product
* Transfer Stock Between Branches

### Inventory Monitoring

* Low stock query system
* Minimum stock level tracking

---

# Inventory Modeling Approach

The project separates:

## Catalog Data

```text
Product
```

from:

## Operational Inventory State

```text
BranchInventory
```

This allows:

* same product in multiple branches
* different stock levels per branch
* branch-specific selling state
* future warehouse support
* transfer operations
* inventory analytics

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
Result.Failure("Insufficient stock.");
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
* Result Pattern
* Rich Domain Model
* Vertical Slice Architecture
* Unit of Work
* DTO Pattern
* Read Model Pattern
* Soft Delete Pattern
* Business Key Pattern

---

# Current Features

## Inventory Operations

* stock increase
* stock deduction
* branch transfer
* low stock monitoring

---

# Planned Features

The project will continue evolving with:

* Sales module
* Order management
* Warehouse management
* Employee management
* Payroll system
* Reporting & analytics
* Notifications
* Authentication & authorization
* Role & permission management
* Audit logging

---

# Project Goals

This project is being developed to:

* practice enterprise backend architecture
* understand real-world ERP domain modeling
* improve Clean Architecture knowledge
* learn scalable system design
* build production-level backend engineering skills

---

# Status

Current state:

```text
Retail catalog and inventory foundation completed.
Core operational inventory workflows are working.
```

The project is actively evolving feature by feature.
