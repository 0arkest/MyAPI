DROP DATABASE IF EXISTS EnrollmentDataService;
CREATE DATABASE EnrollmentDataService;
USE EnrollmentDataService;

# Courses(CourseID, CourseName, ProfessorName)
DROP TABLE IF EXISTS Courses;
CREATE TABLE Courses(
    CourseID INT NOT NULL AUTO_INCREMENT,
    PRIMARY KEY (CourseID),
    CourseName VARCHAR(100) NOT NULL,
    ProfessorName VARCHAR(100) NOT NULL
);

# Students(StudentID, FirstName, MiddleName, LastName, Email)
# extra constraint called FullName
DROP TABLE IF EXISTS Students;
CREATE TABLE Students(
    StudentID INT NOT NULL AUTO_INCREMENT,
    PRIMARY KEY (StudentID),
    FirstName VARCHAR(100) NOT NULL,
    MiddleName VARCHAR(100),
    LastName VARCHAR(100) NOT NULL,
    CONSTRAINT FullName UNIQUE (FirstName, MiddleName, LastName),
    Email VARCHAR(100) NOT NULL
);

/*
Enrollment(CourseID, StudentID)
many-to-many relationships between table Courses and table Students.
stores foreign keys of tables.
*/
DROP TABLE IF EXISTS Enrollment;
CREATE TABLE Enrollment(
	CourseID INT NOT NULL,
    StudentID INT NOT NULL,
    FOREIGN KEY (CourseID) REFERENCES Courses(CourseID),
    FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
    PRIMARY KEY (CourseID, StudentID)
);

/*
INSERT INTO Courses(CourseName, ProfessorName) VALUES("Computer Science", "Homer Lim");
INSERT INTO Students(FirstName, LastName, Email) VALUES("Bobby", "Downes", "BobbyDownes@gmail.com");
INSERT INTO Enrollment(CourseID, StudentID) VALUES("1", "1");

INSERT INTO Courses(CourseName, ProfessorName) VALUES("Algebra", "Tazmin Kaiser");
INSERT INTO Students(FirstName, LastName, Email) VALUES("Melisa", "Cartwright", "MelisaCartwright@gmail.com");
INSERT INTO Enrollment(CourseID, StudentID) VALUES("2", "2");

INSERT INTO Courses(CourseName, ProfessorName) VALUES("English", "Dario Hobbs");
INSERT INTO Students(FirstName, LastName, Email) VALUES("Samad", "Wallis", "SamadWallis@gmail.com");
INSERT INTO Enrollment(CourseID, StudentID) VALUES("3", "3");

INSERT INTO Enrollment(CourseID, StudentID) VALUES("1", "3");
*/

/* see all student info
SELECT s.FirstName, s.LastName, s.Email, c.CourseName, c.ProfessorName FROM Enrollment e
INNER JOIN Students s on s.StudentID = e.StudentID
INNER JOIN Courses c on c.CourseID = e.CourseID;
*/