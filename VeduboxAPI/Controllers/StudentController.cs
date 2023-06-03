using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeduboxAPI.Data;

namespace VeduboxAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController :ControllerBase
    {
        private readonly DataContext _context;

        public StudentController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Student>>> Get()
        {
            return Ok(await _context.Student.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Student>>> Get(int id)
        {
            var students = await _context.Student.ToListAsync();
            var student =students.Find(x => x.StudentId == id);
            if(student== null) { return BadRequest("Student not found.");}
            return Ok(student);
        }


        [HttpPost]
        public async Task<ActionResult<List<Student>>> Post(Student student)
        {
            _context.Student.Add(student);
            await _context.SaveChangesAsync();
            return Ok(await _context.Student.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Student>>> Put(Student request)
        {
            var students = await _context.Student.ToListAsync();
            var student = students.Find(c => c.StudentId == request.StudentId);
            if (student == null)
                return BadRequest("Course not found.");

            student.FullName = request.FullName;

            student.Education = request.Education;
            student.Fees = request.Fees;
           

            await _context.SaveChangesAsync();

            return Ok(students);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Student>>> Delete(int id)
        {
            var students = await _context.Student.ToListAsync();
            var student = students.Find(c => c.StudentId == id);
            if (student == null)
                return BadRequest("Course not found.");

            students.Remove(student);
            await _context.SaveChangesAsync();

            return Ok(student);
        }


    }
}
