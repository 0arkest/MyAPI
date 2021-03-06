# Enrollment API
CSCI 39537 (Intro to APIs) Final Project

## About
Three Tables:

Courses (CourseID, CourseName, ProfessorName)

Students (StudentID, FirstName, MiddleName, LastName, Email)

Enrollment (CourseID, StudentID)

Table Enrollment is added for create many-to-many relationships between table Courses and table Students.

## How to Call API Endpoints
### 1. Course API Endpoints:

#### GET: https://localhost:7237/api/course

#### GET: https://localhost:7237/api/course/1

#### Sample Response Body:

if success:

{

    "statusCode": 200,
    "statusDescription": "Success! The request was successfully completed.",
    "course": {
        "courseID": 1,
        "courseName": "Chemistry",
        "professorName": "Mabel Shah"
    },
    "student": null

}

if failed:

{

    "statusCode": 400,
    "statusDescription": "Error. No course found for the given id.",
    "course": null,
    "student": null

}

#### POST: https://localhost:7237/api/course

#### Sample Request Body:

{

    "CourseName": "Chemistry",
    "ProfessorName": "Mabel Shah"

}

#### Sample Response Body:

if success:

{

    "statusCode": 200,
    "statusDescription": "Success! The request was successfully completed.",
    "course": {
        "courseID": 1,
        "courseName": "Chemistry",
        "professorName": "Mabel Shah"
    },
    "student": null

}

if failed:

{

    "statusCode": 400,
    "statusDescription": "Error. Wrong input format",
    "course": null,
    "student": null

}

#### DELETE: https://localhost:7237/api/course/1

#### Sample Response Body:

if success:

{

    "statusCode": 200,
    "statusDescription": "Success! The request was successfully completed.",
    "course": {
        "courseID": 1,
        "courseName": "Chemistry",
        "professorName": "Mabel Shah"
    },
    "student": null

}

if failed:

{

    "statusCode": 400,
    "statusDescription": "Error. No course found for the given id.",
    "course": null,
    "student": null

}

### 2. Student API Endpoints:

#### GET: https://localhost:7237/api/student

#### GET: https://localhost:7237/api/student/1

#### POST: https://localhost:7237/api/student

#### Sample Request Body:

{

    "FirstName": "Halle",
    "MiddleName": "",
    "LastName": "Hampton",
    "Email": "HalleHampton@gmail.com"

}

#### DELETE: https://localhost:7237/api/student/1

### 3. Enrollment API Endpoints:

#### GET: https://localhost:7237/api/enrollment
