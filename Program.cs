using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        // 1. Initialize a list to store multiple vehicle objects
        List<Vehicle> vehicles = new List<Vehicle>();

        // 2. Add test data: (isFunctional, isTaxPaid, hasTitle, year, model)
        vehicles.Add(new Vehicle(true, true, true, 2015, "Audi A4"));
        vehicles.Add(new Vehicle(false, true, true, 2005, "Yugo"));
        vehicles.Add(new Vehicle(true, false, true, 2022, "Tesla Model 3"));

        Console.WriteLine("--- VEHICLE REGISTRATION REPORT ---\n");

        // 3. Process each vehicle in the collection
        foreach (Vehicle car in vehicles)
        {
            Console.WriteLine($"Model: {car.Model} ({car.Year})");
            
            // Invoke the registration validation logic
            string report = car.GetRegistrationReport();
            Console.WriteLine($"- Status: {report}");
            
            Console.WriteLine("-----------------------------------");
        }
    }
}

public class Vehicle
{
    // Auto-implemented properties representing vehicle data
    public string Model { get; set; }
    public int Year { get; set; }
    public bool IsFunctional { get; set; }
    public bool TaxPaid { get; set; }
    public bool HasTitle { get; set; }

    // Constructor to initialize the Vehicle object with specific values
    public Vehicle(bool functional, bool tax, bool title, int year, string model)
    {
        IsFunctional = functional;
        TaxPaid = tax;
        HasTitle = title;
        Year = year;
        Model = model;
    }

    // Business logic method to validate if a vehicle meets registration requirements
    public string GetRegistrationReport()
    {
        int currentYear = 2026;
        int maxAge = 20;
        string errors = "";

        // Checking functional and legal requirements
        if (IsFunctional == false) errors += "Mechanical failure. ";
        if (TaxPaid == false) errors += "Outstanding tax balance. ";
        if (HasTitle == false) errors += "Proof of ownership missing. ";
        
        // Age validation: Vehicles older than 20 years are restricted
        if (currentYear - Year > maxAge) 
        {
            errors += "Vehicle exceeds age limit (20+ years). ";
        }

        // Return final status based on error collection
        if (errors == "")
        {
            return "SUCCESS: Approved for Registration";
        }
        else
        {
            return "FAILED: " + errors;
        }
    }
}
