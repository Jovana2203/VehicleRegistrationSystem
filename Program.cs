using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        // POLYMORPHISM: One list can hold both Vehicles and Trucks
        List<Vehicle> vehicles = new List<Vehicle>();

        // Populating the list with various data (Success, Fail, Future year, and Missing model)
        vehicles.Add(new Vehicle(true, true, true, 2015, "Audi A4"));
        vehicles.Add(new Vehicle(false, true, true, 2005, "Yugo"));
        vehicles.Add(new Vehicle(true, false, true, 2022, "Tesla Model 3"));
        vehicles.Add(new Vehicle(true, true, true, 2029, "Audi A3")); // Testing future year validation
        vehicles.Add(new Vehicle(true, true, true, 2013, "")); // Testing data validation with an empty model name
        // INHERITANCE: Truck is added to the Vehicle list because it 'is-a' Vehicle
        vehicles.Add(new Truck(true, true, true, 2018, "Volvo FH16", 5000));
        
        Console.WriteLine("--- VEHICLE REGISTRATION SYSTEM ---\n");

        foreach (var v in vehicles)
        {
            // DATA VALIDATION: Handling edge cases (Empty strings)
            if (string.IsNullOrEmpty(v.Model)) 
            {
                Console.WriteLine("CRITICAL ERROR: Vehicle entry is missing a model name!");
                Console.WriteLine("-----------------------------------");
                continue; 
            }

            Console.WriteLine($"Processing Model: {v.Model} ({v.Year})");
            
            // POLYMORPHISM IN ACTION: 
            // The program calls the correct GetRegistrationReport version at runtime.
            Console.WriteLine($"- Status: {v.GetRegistrationReport()}");
            Console.WriteLine("-----------------------------------");
        }

        // LINQ: Simulating SQL-like data filtering
        var modernCars = vehicles.Where(v => v.Year > 2010 && !string.IsNullOrEmpty(v.Model)).ToList();
        Console.WriteLine($"\nSQL SIMULATION: Found {modernCars.Count} modern cars in the registry.");
    }
}

// BASE CLASS (Parent)
public class Vehicle
{
    // ENCAPSULATION: Properties to store vehicle state
    public string Model { get; set; }
    public int Year { get; set; }
    public bool IsFunctional { get; set; }
    public bool TaxPaid { get; set; }
    public bool HasTitle { get; set; }

    // CONSTRUCTOR: Ensuring objects are initialized with mandatory data
    public Vehicle(bool functional, bool tax, bool title, int year, string model)
    {
        IsFunctional = functional;
        TaxPaid = tax;
        HasTitle = title;
        Year = year;
        Model = model;
    }

    // ABSTRACTION: Hiding complex validation logic inside a method
    // 'virtual' allows child classes to modify this behavior
    public virtual string GetRegistrationReport()
    {
        int currentYear = 2026;
        int maxAge = 20;
        string errors = "";

        if (!IsFunctional) errors += "Mechanical failure. ";
        if (!TaxPaid) errors += "Tax unpaid. ";
        if (!HasTitle) errors += "Title missing. ";
        
        // LOGIC VALIDATION: Checking for old vehicles
        if (currentYear - Year > maxAge) 
        {
            errors += "Vehicle exceeds age limit (20+ years). ";
        }

        // LOGIC VALIDATION: Future-proofing the data
        if (Year > currentYear) 
        {
            errors += "Invalid year: Date is in the future. ";
        }

        return (errors == "") ? "SUCCESS: Registered" : "FAILED: " + errors;
    }
}

// DERIVED CLASS (Child) - INHERITANCE
public class Truck : Vehicle
{
    public int MaxWeight { get; set; }

    // CONSTRUCTOR: Uses 'base' to pass data up to the parent Vehicle class
    public Truck(bool functional, bool tax, bool title, int year, string model, int weight) 
        : base(functional, tax, title, year, model)
    {
        MaxWeight = weight;
    }

    // METHOD OVERRIDING: Customizing behavior specifically for Trucks
    public override string GetRegistrationReport()
    {
        // First, check the standard rules from the parent class
        string baseStatus = base.GetRegistrationReport();
        
        // Then, add specific rules for heavy vehicles
        if (baseStatus.Contains("SUCCESS") && MaxWeight > 3500)
        {
            return "SUCCESS (Special Heavy License Required)";
        }
        return baseStatus;
    }
}
