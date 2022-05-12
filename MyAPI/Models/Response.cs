using System;
namespace MyAPI.Models
{
    public class Response
    {
        public int statusCode { get; set; }
        public string? statusDescription { get; set; }
        public Course? course { get; set; }
        public Student? student { get; set; }
    }
}
