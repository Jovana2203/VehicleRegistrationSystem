-- 1. Create the table for vehicles
-- We added 'RegistrationStatus' to match our C# Enum (0=Pending, 1=Active, 2=Rejected)
-- We added 'VehicleType' to distinguish between standard Cars and Trucks
CREATE TABLE Vehicles (
    VehicleID INT PRIMARY KEY IDENTITY(1,1),
    Model VARCHAR(50) NOT NULL,
    Year INT NOT NULL,
    IsFunctional BIT NOT NULL,      -- Represents 'bool' in C# (0 or 1)
    TaxPaid BIT NOT NULL,
    HasTitle BIT NOT NULL,
    RegistrationStatus INT DEFAULT 0, -- Maps to our C# Enum
    VehicleType VARCHAR(20) DEFAULT 'Car', -- To identify 'Truck' vs 'Vehicle'
    MaxWeight INT NULL               -- Only used if VehicleType is 'Truck'
);

-- 2. Data Insertion (DML - Data Manipulation Language)
-- Populating the table with the same test data used in our C# application
INSERT INTO Vehicles (Model, Year, IsFunctional, TaxPaid, HasTitle, RegistrationStatus, VehicleType, MaxWeight)
VALUES 
    ('Audi A4', 2015, 1, 1, 1, 1, 'Car', NULL),
    ('Yugo', 2005, 0, 1, 1, 2, 'Car', NULL),
    ('Tesla Model 3', 2022, 1, 0, 1, 2, 'Car', NULL),
    ('Audi A3', 2029, 1, 1, 1, 2, 'Car', NULL),
    ('Volvo FH16', 2018, 1, 1, 1, 1, 'Truck', 5000),
    ('Fiat', 2000, 1, 1, 1, 2, 'Car', NULL);
