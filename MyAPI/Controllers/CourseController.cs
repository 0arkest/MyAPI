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
    public class CourseController : ControllerBase
    {
        private readonly MyAPIDBContext _context;

        public CourseController(MyAPIDBContext context)
        {
            _context = context;
        }

        // GET: api/Course
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
        {
            return await _context.Courses.ToListAsync();
        }

        // GET: api/Course/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetCourse(int id)
        {
            var course = await _context.Courses.FindAsync(id);

            var response = new Response
            {
                statusCode = 400,
                statusDescription = "Error. No course found for the given id."
            };

            if (course != null)
            {
                response.statusCode = 200;
                response.statusDescription = "Success! The request was successfully completed.";
                response.course = course;
            }

            return response;
        }

        // POST: api/Course
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Response>> PostCourse(Course course)
        {
            var response = new Response();

            try
            {
                _context.Courses.Add(course);
                await _context.SaveChangesAsync();
                response.statusCode = 200;
                response.statusDescription = "Success! The request was successfully completed.";
                response.course = course;
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.statusDescription = "Error. Wrong input format";
            }

            return response;
        }

        // DELETE: api/Course/5
        [HttpDelete("{id}")]
        public async Task<Response> DeleteCourse(int id)
        {
            var course = await _context.Courses.FindAsync(id);

            var response = new Response
            {
                statusCode = 200,
                statusDescription = "Success! The request was successfully completed.",
                course = course
            };

            if (course == null)
            {
                response.statusCode = 400;
                response.statusDescription = "Error. No course found for the given id.";
                return response;
            }

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();

            return response;
        }

        private bool CourseExists(int id)
        {
            return _context.Courses.Any(e => e.CourseID == id);
        }
    }
}
