# Enrollment API
CSCI 39537 (Intro to APIs) Final Project

## About
Three Tables:

Courses (CourseID, CourseName, ProfessorName)

Students (StudentID, FirstName, MiddleName, LastName, Email)

Enrollment (CourseID, StudentID)

## How to Call API Endpoints
### 1. Course API Endpoints:

GET: https://localhost:7237/api/course

GET: https://localhost:7237/api/course/1

POST: https://localhost:7237/api/course


{

    "CourseName": "Chemistry",
    "ProfessorName": "Mabel Shah"

}


DELETE: https://localhost:7237/api/course/1

### 2. Student API Endpoints:

GET: https://localhost:7237/api/student

GET: https://localhost:7237/api/student/1

POST: https://localhost:7237/api/student


{

    "FirstName": "Halle",
    "MiddleName": "",
    "LastName": "Hampton",
    "Email": "HalleHampton@gmail.com"

}


DELETE: https://localhost:7237/api/student/1

### 3. Enrollment API Endpoints:

GET: https://localhost:7237/api/enrollment
