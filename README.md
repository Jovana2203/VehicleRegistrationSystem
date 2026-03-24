Vehicle Registration System (C# OOP & Business Logic)
Overview
This project is a Vehicle Registration Management System developed in C#. It demonstrates the application of core Object-Oriented Programming (OOP) principles to solve a real-world business scenario: automating vehicle inspections and registration fee calculations.

The system processes a fleet of vehicles, applies specific business rules (such as age-based discounts and safety checks), and generates a structured report for the user.

* Key Technical Features
Encapsulation: Used to protect vehicle data and bundle logic (like fee calculation) directly within the classes.

Inheritance & Polymorphism: Implemented a base Vehicle class and a derived Truck class to handle specialized data and behavior.

Method Overriding: Specialized registration logic for heavy-duty vehicles using the override keyword.

LINQ (Language Integrated Query): Utilized for efficient data filtering and generating database-style insights (e.g., counting non-functional vehicles).

Error Handling & Data Integrity: Implemented checks for edge cases such as missing model names or invalid manufacturing years.

* Business Logic Implemented
Safety First: Vehicles older than 20 years or those marked as non-functional are automatically rejected.

Sustainability Incentives: A 40% discount is applied to registration fees for vintage vehicles (older than 25 years).

Heavy Duty Regulations: Trucks exceeding 3,500kg require a special permit, demonstrated through polymorphic method calls.
