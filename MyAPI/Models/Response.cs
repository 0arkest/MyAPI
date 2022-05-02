using System;
namespace MyAPI.Models
{
    public class Response
    {
        public int statusCode { get; set; }
        public string? statusDescription { get; set; }
        public List<Course>? courses = new();
        public List<Student>? students = new();
        public List<Enrollment>? enrollment = new();
    }
}
