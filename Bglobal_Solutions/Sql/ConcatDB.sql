-- Crear la base de datos
CREATE DATABASE ContactDB;
GO

-- Usar la base de datos creada
USE ContactDB;
GO

-- Crear la tabla Contact
CREATE TABLE Contact (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(50) NOT NULL,
    Company NVARCHAR(50),
    ProfileImage NVARCHAR(255),
    Email NVARCHAR(50) NOT NULL,
    Birthdate DATE,
    WorkPhoneNumber NVARCHAR(20),
    PersonalPhoneNumber NVARCHAR(20),
    Address NVARCHAR(255),
    City NVARCHAR(50),
    State NVARCHAR(50)
);
GO

-- Insertar algunos registros
INSERT INTO Contact (Name, Company, ProfileImage, Email, Birthdate, WorkPhoneNumber, PersonalPhoneNumber, Address, City, State)
VALUES ('John Doe', 'Company A', 'https://images.com/profile1.jpg', 'john.doe@companya.com', '1980-01-01', '123-456-7890', '098-765-4321', '123 Main St, Apt 4B', 'New York', 'NY'),
       ('Jane Smith', 'Company B', 'https://images.com/profile2.jpg', 'jane.smith@companyb.com', '1985-02-02', '321-654-0987', '789-012-3456', '456 Elm St, Suite 200', 'Los Angeles', 'CA');
GO