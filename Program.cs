using System;
using System.Collections.Generic;
using System.Linq;

// Enum for managing the lifecycle of a registration request
public enum RegistrationStatus
{
    Pending,
    Active,
    Rejected
}

public class Program
{
    public static void Main()
    {
        // Polymorphism in action: A list of 'Vehicle' can store both Vehicle and Truck objects
        List<Vehicle> vehicles = new List<Vehicle>();

        // Adding test data to the collection
        vehicles.Add(new Vehicle(true, true, true, 2015, "Audi A4"));
        vehicles.Add(new Vehicle(false, true, true, 2005, "Yugo"));
        vehicles.Add(new Vehicle(true, false, true, 2022, "Tesla Model 3"));
        vehicles.Add(new Vehicle(true, true, true, 2029, "Audi A3")); // Edge case: Future year
        vehicles.Add(new Truck(true, true, true, 2018, "Volvo FH16", 5000));
        vehicles.Add(new Vehicle(true, true, true, 2013, "")); // Edge case: Missing model name
        vehicles.Add(new Vehicle(true, true, true, 2000, "Fiat")); // Eligible for discount

        Console.WriteLine("================================================================================");
        Console.WriteLine("📊 VEHICLE REGISTRATION SYSTEM - FINAL REPORT (2026)");
        Console.WriteLine("================================================================================");
        
        // TABLE HEADER: Using PadRight to ensure fixed-width columns for a professional terminal UI
        Console.WriteLine("MODEL".PadRight(18) + "| YEAR | STATUS".PadRight(15) + "| PRICE    | NOTES");
        Console.WriteLine(new string('-', 80));

        foreach (var v in vehicles)
        {
            // Trigger the business logic to determine the CurrentStatus (Active/Rejected)
            string report = v.GetRegistrationReport();
            
            // Calculate fee based on the business rule (discounts for old vehicles)
            double finalPrice = v.CalculateRegistrationFee(200);

            // Ternary operator for handling empty data points
            string displayName = string.IsNullOrEmpty(v.Model) ? "UNKNOWN MODEL" : v.Model;

            // Context-aware notes to provide more information about the row
            string note = "";
            if (v.Year > 2026) note = "FUTURE YEAR ERROR!";
            else if (v.Year <= 2001) note = "40% Discount applied";
            else if (report.Contains("FAILED")) note = "Check inspection logs";
            
            // Type checking: Identify specific vehicle types during iteration
            if (v is Truck) note += " [Heavy Duty]";

            // FINAL TABULAR OUTPUT
            Console.WriteLine(
                displayName.PadRight(18) + "| " + 
                v.Year.ToString().PadRight(5) + "| " + 
                v.CurrentStatus.ToString().PadRight(13) + "| " + 
                (finalPrice + " EUR").PadRight(9) + "| " + 
                note
            );
        }

        Console.WriteLine(new string('-', 80));

        // DATABASE INSIGHTS: Using LINQ (Language Integrated Query) for data analysis
        Console.WriteLine("\n🔍 DATABASE INSIGHTS (SQL SIMULATION):");
        int brokenCount = vehicles.Count(v => !v.IsFunctional);
        int rejectedCount = vehicles.Count(v => v.CurrentStatus == RegistrationStatus.Rejected);
        
        Console.WriteLine($"- Total Vehicles in system: {vehicles.Count}");
        Console.WriteLine($"- Non-functional vehicles: {brokenCount}");
        Console.WriteLine($"- Rejected applications: {rejectedCount}");
        Console.WriteLine("================================================================================");
    }
}

public class Vehicle
{
    // Properties representing the core state of a vehicle
    public string Model { get; set; }
    public int Year { get; set; }
    public bool IsFunctional { get; set; }
    public bool TaxPaid { get; set; }
    public bool HasTitle { get; set; }
    public RegistrationStatus CurrentStatus { get; set; }

    // Constructor to initialize a new Vehicle instance
    public Vehicle(bool functional, bool tax, bool title, int year, string model)
    {
        IsFunctional = functional;
        TaxPaid = tax;
        HasTitle = title;
        Year = year;
        Model = model;
        CurrentStatus = RegistrationStatus.Pending;
    }

    // Business Logic Method: Validates if the vehicle meets legal requirements
    // Marked as 'virtual' to allow specialized logic in derived classes (Truck)
    public virtual string GetRegistrationReport()
    {
        string errors = "";

        if (!IsFunctional) errors += "Broken. ";
        if (!TaxPaid) errors += "Tax unpaid. ";
        if (!HasTitle) errors += "No title. ";
        if (2026 - Year > 20) errors += "Age exceeds 20y. ";
        if (Year > 2026) errors += "Invalid future year. ";

        // Validating both physical conditions and data integrity
        if (errors == "" && !string.IsNullOrEmpty(Model))
        {
            CurrentStatus = RegistrationStatus.Active;
            return "SUCCESS";
        }
        else
        {
            CurrentStatus = RegistrationStatus.Rejected;
            return "FAILED: " + errors;
        }
    }

    // Encapsulated Logic: Determines registration costs based on vehicle age
    public double CalculateRegistrationFee(double basePrice)
    {
        int age = 2026 - Year;
        // Discount policy: 40% off for vehicles older than 25 years
        if (age > 25) return basePrice * 0.6; 
        return basePrice;
    }
}

// Inheritance: Truck inherits all properties and methods from Vehicle
public class Truck : Vehicle
{
    public int MaxWeight { get; set; }

    // Using the 'base' keyword to call the parent class constructor
    public Truck(bool functional, bool tax, bool title, int year, string model, int weight) 
        : base(functional, tax, title, year, model)
    {
        MaxWeight = weight;
    }

    // Method Overriding: Adding custom business logic specific to Trucks
    public override string GetRegistrationReport()
    {
        string baseReport = base.GetRegistrationReport();
        
        // Even if basic checks pass, trucks have an additional weight restriction
        if (baseReport == "SUCCESS" && MaxWeight > 3500)
        {
            return "SUCCESS (Heavy Vehicle Permit Required)";
        }
        return baseReport;
    }
}
