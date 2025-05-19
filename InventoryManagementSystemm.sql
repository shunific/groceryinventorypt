CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) NOT NULL UNIQUE,
    Password NVARCHAR(100) NOT NULL,
    FullName NVARCHAR(100) NOT NULL,
    Role NVARCHAR(20) NOT NULL CHECK (Role IN ('Admin', 'Staff')),
    LastLogin DATETIME,
    IsActive BIT DEFAULT 1
);

-- Categories table
CREATE TABLE Categories (
    CategoryID INT PRIMARY KEY IDENTITY(1,1),
    CategoryName NVARCHAR(100) NOT NULL UNIQUE,
    Description NVARCHAR(255)
);

-- Items table
CREATE TABLE Items (
    ItemID INT PRIMARY KEY IDENTITY(1,1),
    ItemName NVARCHAR(100) NOT NULL,
    Description NVARCHAR(255),
    CategoryID INT FOREIGN KEY REFERENCES Categories(CategoryID),
    Quantity INT NOT NULL DEFAULT 0,
    MinimumThreshold INT NOT NULL DEFAULT 5,
    Price DECIMAL(10, 2) NOT NULL,
    LastUpdated DATETIME DEFAULT GETDATE()
);

-- Audit log table
CREATE TABLE AuditLog (
    LogID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT FOREIGN KEY REFERENCES Users(UserID),
    Action NVARCHAR(50) NOT NULL,
    Details NVARCHAR(MAX),
    Timestamp DATETIME DEFAULT GETDATE()
);

-- Insert default admin user
INSERT INTO Users (Username, Password, FullName, Role)
VALUES ('admin', 'admin123', 'System Administrator', 'Admin');
INSERT INTO Users (Role)
VALUES ('Staff');