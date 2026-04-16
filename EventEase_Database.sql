USE master;
GO

-- Dropping the database if it does exist
DROP DATABASE IF EXISTS EventEaseDB;
GO

-- Creating a new database
CREATE DATABASE EventEaseDB;
GO

-- Switching to the new database
USE EventEaseDB;
GO

-- Creating the Venue table
CREATE TABLE Venues (
VenueID INT PRIMARY KEY IDENTITY(1,1),
NameOfVenue VARCHAR(100) NOT NULL,
VenueAddress VARCHAR(200) NOT NULL,
Capacity INT NOT NULL,
VenueLocation VARCHAR(100) NOT NULL,
Email VARCHAR(100) NOT NULL
);
GO

-- Creating the Event table
CREATE TABLE Event (
EventID INT PRIMARY KEY IDENTITY(1,1),
EventDate DATE NOT NULL,
StartOfEvent TIME NOT NULL,
EndOfEvent TIME NOT NULL,
TotalSeats INT NOT NULL,
VenueID INT NOT NULL,
CONSTRAINT FK_Event_Venues FOREIGN KEY (VenueID) REFERENCES Venues(VenueID)
);
GO
-- Creating the Customer table
CREATE TABLE Customer (
CustomerID INT PRIMARY KEY IDENTITY(1,1),
FirstName VARCHAR(100) NOT NULL,
Email VARCHAR(100) NOT NULL,
PhoneNumber VARCHAR(20) NOT NULL
);
GO

-- Creating the Booking table
CREATE TABLE Booking (
BookingID INT PRIMARY KEY IDENTITY(1,1),
Status VARCHAR(50) NOT NULL,
TotalAmount DECIMAL(10,2) NOT NULL,
NumberOfSeats INT NOT NULL,
BookedAt DATETIME NOT NULL DEFAULT GETDATE(),
EventID INT NOT NULL,
CustomerID INT NOT NULL,
CONSTRAINT FK_Booking_Event FOREIGN KEY (EventID) REFERENCES Event(EventID),
CONSTRAINT FK_Booking_Customer FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID)
);
GO

-- Implementing the CRUD Functionality in the Venue, Event, Customer and Booking tables
-- CREATE in Venues
INSERT INTO Venues (NameOfVenue, VenueAddress, Capacity, VenueLocation, Email)
VALUES ('The Grand Hall', '9 Avenue street, Newcastle', 600, 'Newcastle', 'thegrandhall@gmail.com');
INSERT INTO Venues (NameOfVenue, VenueAddress, Capacity, VenueLocation, Email)
VALUES ('Luxury Arena', '18 GoldenCity, Santon', 800, 'Santon', 'luxuryarena@gmail.com');
GO

-- UPDATE in Venue
UPDATE Venues
SET Capacity = 700, Email = 'grandhall_updated@gmail.com'
WHERE VenueID = 1;

-- READ in Venues
SELECT * FROM Venues;
SELECT * FROM Venues WHERE VenueID = 1;

--DELETE in Venues
--DELETE FROM Venue WHERE VenueID = 2;



-- CREATE in Event
INSERT INTO Event (EventDate, StartOfEvent, EndOfEvent, TotalSeats, VenueID)
VALUES ('2026-06-15', '09:00', '20:00', 300, 1);
INSERT INTO Event (EventDate, StartOfEvent, EndOfEvent, TotalSeats, VenueID)
VALUES ('2026-07-20', '10:00', '18:00', 800, 2);
GO

UPDATE Event
SET TotalSeats = 500, StartOfEvent = '12:00'
WHERE EventID = 1;

-- READ in Event
SELECT * FROM Event;
SELECT e.EventID, e.EventDate, e.StartOfEvent, e.EndOfEvent, e.TotalSeats, v.NameOfVenue, v.VenueLocation
FROM Event e
JOIN Venues v ON e.VenueID = v.VenueID;
-- UPDATE in Event

-- DELETE in Event
-- DELETE FROM Event WHERE EventID = 2;



-- CREATE in Customer
INSERT INTO Customer (FirstName, Email, PhoneNumber)
VALUES ('Luhle Mncwabe', 'Lu@email.com', '023 456 7890');
INSERT INTO Customer (FirstName, Email, PhoneNumber)
VALUES ('Sphindile Mncwabe', 'sphi@email.com', '013 579 1357');
GO
-- READ in Customer
SELECT * FROM Customer;
SELECT * FROM Customer WHERE CustomerID = 1;

-- UPDATE in Customer
UPDATE Customer
SET Email = 'lu_new@email.com', PhoneNumber = '016 385 6746'
WHERE CustomerID = 1;

-- DELETE in Customer
-- DELETE FROM Customer WHERE CustomerID = 2;   



-- CREATE in Booking
INSERT INTO Booking (Status, TotalAmount, NumberOfSeats, BookedAt, EventID, CustomerID)
VALUES ('Confirmed', 750.00, 500, GETDATE(), 1, 1);
INSERT INTO Booking (Status, TotalAmount, NumberOfSeats, BookedAt, EventID, CustomerID)
VALUES ('Pending', 500.00, 600, GETDATE(), 2, 2);
GO

-- UPDATE in Booking
UPDATE Booking
SET Status = 'Cancelled', TotalAmount = 0.00
WHERE BookingID = 2;

-- READ in Booking
SELECT * FROM Booking;
SELECT b.BookingID, c.FirstName AS Customer, e.EventDate, v.NameOfVenue AS Venues, b.NumberOfSeats, b.TotalAmount, b.Status, b.BookedAt
FROM Booking b
JOIN Customer c ON b.CustomerID = c.CustomerID
JOIN Event e ON b.EventID = e.EventID
JOIN Venues v ON e.VenueID = v.VenueID;

-- DELETE in Booking
-- DELETE FROM Booking WHERE BookingID = 2;