
# Vehicle Registration Validator

A simple C# console application designed to demonstrate **Object-Oriented Programming (OOP)** principles and data validation logic. This project simulates a government vehicle registry system that evaluates vehicles based on technical, legal, and age requirements.

## 🚀 Key Features
- **Object-Oriented Design**: Utilizes a `Vehicle` class to encapsulate data and behavior.
- **Automated Validation**: Checks for mechanical functionality, tax compliance, and ownership documentation.
- **Custom Business Rules**: Implements an age-limit check (restricting vehicles older than 20 years).
- **Collection Management**: Demonstrates the use of `List<T>` and `foreach` loops to process multiple records efficiently.

## 🛠️ Technical Implementation
- **Language**: C#
- **Concepts**: Classes, Constructors, Auto-Implemented Properties, String Interpolation, and Conditional Logic.

## 📋 How It Works
The program iterates through a collection of vehicles. For each vehicle, it executes the `GetRegistrationReport()` method, which aggregates all failed conditions into a single report. If no errors are found, the vehicle is marked as "Approved".
