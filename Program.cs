using System;
using System.Collections.Generic;
using System.Linq;

// ENUM: Defining a fixed set of states for the registration process
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
        // POLYMORPHISM: One list to manage all vehicle types (Cars and Trucks)
        List<Vehicle> vehicles = new List<Vehicle>();

        // SEEDING DATA: Adding mixed test cases
        vehicles.Add(new Vehicle(true, true, true, 2015, "Audi A4"));
        vehicles.Add(new Vehicle(false, true, true, 2005, "Yugo"));
        vehicles.Add(new Vehicle(true, false, true, 2022, "Tesla Model 3"));
        vehicles.Add(new Vehicle(true, true, true, 2029, "Audi A3")); // Testing future date validation
        
        // INHERITANCE: Adding a Truck to the Vehicle list
        vehicles.Add(new Truck(true, true, true, 2018, "Volvo FH16", 5000));
        
        // Testing data validation with a missing model name
        vehicles.Add(new Vehicle(true, true, true, 2013, ""));

        Console.WriteLine("--- VEHICLE REGISTRATION SYSTEM ---\n");

        // FIRST PASS: Processing and updating statuses
        foreach (var v in vehicles)
        {
            // DATA VALIDATION: Skipping entries with critical missing data
            if (string.IsNullOrEmpty(v.Model)) 
            {
                Console.WriteLine("CRITICAL ERROR: Entry missing a model name!");
                continue; 
            }

            Console.WriteLine($"Processing: {v.Model}");
            // POLYMORPHISM IN ACTION: Calls the appropriate method version for Vehicle or Truck
            Console.WriteLine($"- Status: {v.GetRegistrationReport()}");
            Console.WriteLine("---------------------------");
        }
        
        // LINQ: SQL-like filtering for modern vehicles
        var modernCars = vehicles.Where(v => v.Year > 2010 && !string.IsNullOrEmpty(v.Model)).ToList();
        Console.WriteLine("\n--- SQL SIMULATION: Modern Cars (>2010) ---");
        foreach (var car in modernCars)
        {
             Console.WriteLine($"Found: {car.Model}");
        }
        
        // LINQ: Filtering by ENUM status
        var rejectedCars = vehicles.Where(v => v.CurrentStatus == RegistrationStatus.Rejected).ToList();
        Console.WriteLine("\n--- SQL SIMULATION: Rejected Vehicles ---");
        foreach (var car in rejectedCars)
        {
             Console.WriteLine($"Found: {car.Model}");
        }

        // LINQ: Counting broken vehicles
        int brokenCount = vehicles.Count(v => !v.IsFunctional);
        Console.WriteLine($"\nNumber of broken vehicles in database: {brokenCount}");
    }
}

// BASE CLASS (Parent)
public class Vehicle
{
    // ENCAPSULATION: Managing internal state through properties
    public string Model { get; set; }
    public int Year { get; set; }
    public bool IsFunctional { get; set; }
    public bool TaxPaid { get; set; }
    public bool HasTitle { get; set; }
    public RegistrationStatus CurrentStatus { get; set; }

    // CONSTRUCTOR: Initializing properties and setting default Enum status
    public Vehicle(bool functional, bool tax, bool title, int year, string model)
    {
        IsFunctional = functional;
        TaxPaid = tax;
        HasTitle = title;
        Year = year;
        Model = model;
        CurrentStatus = RegistrationStatus.Pending;
    }

    // ABSTRACTION: Complex logic is hidden inside this method
    // 'virtual' allows subclasses like Truck to override this behavior
    public virtual string GetRegistrationReport()
    {
        int currentYear = 2026;
        int maxAge = 20;
        string errors = "";

        if (!IsFunctional) errors += "Broken. ";
        if (!TaxPaid) errors += "Tax unpaid. ";
        if (!HasTitle) errors += "No title. ";
        
        if (currentYear - Year > maxAge) 
        {
            errors += "Exceeds age limit (20+ years). ";
        }
        if (Year > currentYear) 
        {
            errors += "Invalid year: Future date. ";
        }

        // Updating the ENUM status based on validation results
        if (errors == "")
        {
            CurrentStatus = RegistrationStatus.Active;
            return "SUCCESS: Registered";
        }
        else
        {
            CurrentStatus = RegistrationStatus.Rejected;
            return "FAILED: " + errors;
        }
    }
}

// DERIVED CLASS (Child) - INHERITANCE
public class Truck : Vehicle
{
    public int MaxWeight { get; set; }

    // Using 'base' to pass data to the Parent class constructor
    public Truck(bool functional, bool tax, bool title, int year, string model, int weight) 
        : base(functional, tax, title, year, model)
    {
        MaxWeight = weight;
    }

    // METHOD OVERRIDING: Customizing behavior for heavy vehicles
    public override string GetRegistrationReport()
    {
        string baseStatus = base.GetRegistrationReport();
        
        if (baseStatus.Contains("SUCCESS") && MaxWeight > 3500)
        {
            return "SUCCESS (Special Heavy License Required)";
        }
        return baseStatus;
    }
}
