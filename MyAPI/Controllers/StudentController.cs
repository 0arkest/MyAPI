#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAPI.Models;

namespace MyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly MyAPIDBContext _context;

        public StudentController(MyAPIDBContext context)
        {
            _context = context;
        }

        // GET: api/Student
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            return await _context.Students.ToListAsync();
        }

        // GET: api/Student/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);

            var response = new Response
            {
                statusCode = 400,
                statusDescription = "Error. No student found for the given id."
            };

            if (student != null)
            {
                response.statusCode = 200;
                response.statusDescription = "Success! The request was successfully completed.";
                response.student = student;
            }

            return response;
        }

        // POST: api/Student
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Response>> PostStudent(Student student)
        {

            var response = new Response();

            try
            {
                _context.Students.Add(student);
                await _context.SaveChangesAsync();
                response.statusCode = 200;
                response.statusDescription = "Success! The request was successfully completed.";
                response.student = student;
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.statusDescription = "Error. Wrong input format";
            }

            return response;
        }

        // DELETE: api/Student/5
        [HttpDelete("{id}")]
        public async Task<Response> DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);

            var response = new Response
            {
                statusCode = 200,
                statusDescription = "Success! The request was successfully completed.",
                student = student
            };

            if (student == null)
            {
                response.statusCode = 400;
                response.statusDescription = "Error. No course found for the given id.";
                return response;
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return response;
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.StudentID == id);
        }
    }
}
