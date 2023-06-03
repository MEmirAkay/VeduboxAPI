using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeduboxAPI.Data;

namespace VeduboxAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly DataContext _context;

        public CourseController(DataContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Course>>> Get()
        {
            
            return Ok(await _context.Course.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Course>>> Get(int id)
        {
            var courses = await _context.Course.ToListAsync();
            var course = courses.Find(c => c.CourseId == id);

            if(course == null)
                return BadRequest("Course not found.");

            return Ok(course);
        }

        [HttpGet("sortByTeacher/{id}")]
        public async Task<ActionResult<List<Course>>> GetByTeacherId(int id)
        {
            var courses = await _context.Course.ToListAsync();
            var courselist = courses.Where(c => c.TeacherId == id);

            if (courselist == null)
                return BadRequest("Course not found.");

            return Ok(courselist);
        }




        [HttpPost]
        public async Task<ActionResult<List<Course>>> Post(Course course)
        {
            _context.Course.Add(course);
            await _context.SaveChangesAsync();
            return Ok(await _context.Course.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Course>>> Put(Course request)
        {
            var courses = await _context.Course.ToListAsync();
            var course = courses.Find(c => c.CourseId == request.CourseId);
            if (course == null)
                return BadRequest("Course not found.");

            course.Name = request.Name;
            course.Description = request.Description;

            await _context.SaveChangesAsync();

            return Ok(courses);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Course>>> Delete(int id)
        {
            var courses = await _context.Course.ToListAsync();
            var course = courses.Find(c => c.CourseId == id);
            if (course == null)
                return BadRequest("Course not found.");

            courses.Remove(course);
            await _context.SaveChangesAsync();

            return Ok(course);
        }


    }
}
