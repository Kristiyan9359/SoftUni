-- PROBLEM 1

CREATE TABLE [Passports](
  [PassportID] INT PRIMARY KEY IDENTITY (101, 1),
  [PassportNumber] VARCHAR(80) NOT NULL
  )

  CREATE TABLE [Persons](
  [PersonID] INT PRIMARY KEY IDENTITY,
  [FirstName] VARCHAR (50) NOT NULL,
  [Salary] DECIMAL(18, 2) NOT NULL,
  [PassportID] INT FOREIGN KEY REFERENCES [Passports]([PassportID]),
  )

  INSERT INTO [Passports] (PassportNumber)
        VALUES ('N34FG21B'),
               ('K65LO4R7'),
               ('ZE657QP2')

  INSERT INTO [Persons] (FirstName, Salary, PassportID)
       VALUES ('Roberto', 43300.00, 102),
              ('Tom', 56100.00, 103),
              ('Yana', 60200.00, 101)

GO


-- PROBLEM 2

CREATE TABLE [Manufacturers](
[ManufacturerID] INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL,
[EstablishedOn] DATE NOT NULL
)

CREATE TABLE [Models](
[ModelID] INT PRIMARY KEY IDENTITY (101, 1),
[Name] VARCHAR(50) NOT NULL,
[ManufacturerID] INT FOREIGN KEY REFERENCES [Manufacturers] ([ManufacturerID])
)

INSERT INTO [Manufacturers] ([Name], [EstablishedOn])
    VALUES ('BMW', '07/03/1916'),
            ('Tesla', '01/01/2003'),
            ('Lada', '01/05/1966')

INSERT INTO [Models] ([Name], [ManufacturerID])
    VALUES ('X1', 1),
           ('i6', 1),
           ('Model S', 2),
           ('Model X', 2),
           ('Model 3', 2),
           ('Nova', 3)

SELECT * FROM Manufacturers
SELECT * FROM Models


GO


-- PROBLEM 3

CREATE TABLE [Students](
[StudentID] INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(80) NOT NULL
)

CREATE TABLE [Exams](
[ExamID] INT PRIMARY KEY IDENTITY (101, 1),
[Name] VARCHAR(100) NOT NULL
)

CREATE TABLE StudentsExams (
    StudentID INT,
    ExamID INT,
    PRIMARY KEY (StudentID, ExamID),
    FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
    FOREIGN KEY (ExamID) REFERENCES Exams(ExamID)
)

INSERT INTO Students([Name])
     VALUES ('Mila'),
             ('Toni'),
             ('Ron')

INSERT INTO Exams([Name])
     VALUES ('SpringMVC'),
            ('Neo4j'),
            ('Oracle 11g')


INSERT INTO StudentsExams([StudentID], [ExamID])
     VALUES (1, 101),
            (1, 102),
            (2, 101),
            (3, 103),
            (2, 102),
            (2, 103)



GO


-- POBLEM 4


CREATE TABLE Teachers(
[TeacherID] INT PRIMARY KEY IDENTITY (101, 1),
[Name] VARCHAR(80) NOT NULL,
[ManagerID] INT FOREIGN KEY REFERENCES [Teachers]([TeacherID])
)

INSERT INTO [Teachers]([Name])
     VALUES ('John'),
            ('Maya'),
            ('Silvia'),
            ('Ted'),
            ('Mark'),
            ('Greta')



GO


-- PROBLEM 5

CREATE TABLE Cities(
[CityID] INT PRIMARY KEY IDENTITY,
[Name] VARCHAR (80) NOT NULL
)


CREATE TABLE ItemTypes(
[ItemTypeID] INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(100) NOT NULL
)


CREATE TABLE Items(
[ItemID] INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(100) NOT NULL,
[ItemTypeID] INT FOREIGN KEY REFERENCES [ItemTypes]([ItemTypeID])
)


CREATE TABLE Customers(
[CustomerID] INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(80) NOT NULL,
[Birthday] DATE NOT NULL,
[CityID] INT FOREIGN KEY REFERENCES [Cities]([CityID])
)


CREATE TABLE Orders(
[OrderID] INT PRIMARY KEY IDENTITY,
[CustomerID] INT FOREIGN KEY REFERENCES [Customers]([CustomerID])
)


CREATE TABLE OrderItems(
[OrderID] INT,
[ItemID] INT,
PRIMARY KEY (OrderID, ItemID),
FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
FOREIGN KEY (ItemID) REFERENCES Items(ItemID)
)


GO



-- PROBLEM 6

CREATE TABLE Majors(
[MajorID] INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(100) NOT NULL
)


CREATE TABLE Subjects(
[SubjectID] INT PRIMARY KEY IDENTITY,
[SubjectName] VARCHAR(100) NOT NULL
)


CREATE TABLE Students(
[StudentID] INT PRIMARY KEY IDENTITY,
[StudentNumber] INT NOT NULL,
[StudentName] VARCHAR NOT NULL,
[MajorID] INT FOREIGN KEY REFERENCES [Majors]([MajorID])
)



CREATE TABLE Payments(
[PaymentID] INT PRIMARY KEY IDENTITY,
[PaymentDate] DATETIME2 NOT NULL,
[PaymentAmount] DECIMAL NOT NULL,
[StudentID] INT FOREIGN KEY REFERENCES [Students]([StudentID])
)



CREATE TABLE Agenda(
[StudentID] INT,
[SubjectID] INT,
PRIMARY KEY (StudentID, SubjectID),
FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
FOREIGN KEY (SubjectID) REFERENCES Subjects(SubjectID)
)

GO