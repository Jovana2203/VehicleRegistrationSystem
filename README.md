# Vehicle Registration & Validation System

This project is a technical simulation of a **Governmental Registration System**, designed to demonstrate core proficiency in **C#**, **Object-Oriented Programming (OOP)**, and **Relational Database Logic (SQL)**.

## 🚀 Key Features & Technical Implementation

### 1. Object-Oriented Programming (OOP)
The system is built on a clean, hierarchical structure:
- **Encapsulation**: Used classes and properties to manage vehicle states (Model, Year, Status).
- **Inheritance**: Implemented a `Truck` class that inherits from a base `Vehicle` class, demonstrating code reusability.
- **Polymorphism**: Utilized `virtual` and `override` methods to apply specific registration rules for different vehicle types within a single collection.

### 2. Business Logic & Data Validation
Focused on the role of an **Implementation Consultant**, the code handles real-world data constraints:
- **Age Validation**: Automatically flags vehicles older than 20 years.
- **Future-Proofing**: Prevents data entry errors for vehicle years set in the future.
- **Null-Safety**: Includes checks for missing or corrupted data (e.g., empty model names).
- **Special Requirements**: Automated checks for heavy-duty vehicles requiring specific licenses.

### 3. Data Management (SQL & LINQ)
- **SQL Integration**: Includes a `Database.sql` script for table creation and data seeding.
- **LINQ Queries**: Demonstrated the ability to perform complex data filtering and reporting directly within the application logic.

---
*Developed as part of a technical refresh to align with industry standards for Data Engineering and Implementation Consultant roles.*
