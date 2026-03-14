-- 1. Kreiranje tabele za automobile
CREATE TABLE Vehicles (
    VehicleID INT PRIMARY KEY IDENTITY(1,1),
    Model VARCHAR(50) NOT NULL,
    Year INT NOT NULL,
    IsFunctional BIT NOT NULL, -- U SQL-u je BIT zapravo naš bool (0 ili 1)
    TaxPaid BIT NOT NULL,
    HasTitle BIT NOT NULL
);

-- 2. Ubacivanje podataka (DML - Data Manipulation Language)
INSERT INTO Vehicles (Model, Year, IsFunctional, TaxPaid, HasTitle)
VALUES ('Audi A4', 2015, 1, 1, 1),
       ('Yugo', 2005, 0, 1, 1),
       ('Tesla Model 3', 2022, 1, 0, 1);
