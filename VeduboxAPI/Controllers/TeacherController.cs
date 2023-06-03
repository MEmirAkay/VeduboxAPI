using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using VeduboxAPI.Data;

namespace VeduboxAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]



    public class TeacherController : ControllerBase
    {

        private readonly DataContext _context;
        public TeacherController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Teacher>>> Get()
        {     
            return Ok(await _context.Teacher.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Teacher>>> Get(int id)
        {
            var teachers = await _context.Teacher.ToListAsync();
            var teacher = teachers.Find(c => c.TeacherId == id);
            if (teacher == null)
                return BadRequest("Teacher not found.");

            return Ok(teacher);
        }


        [HttpPost]
        public async Task<ActionResult<List<Teacher>>> Post(Teacher teacher)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            teacher.User.LoginToken= new string(Enumerable.Repeat(chars, 16)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            _context.Teacher.Add(teacher);
            await _context.SaveChangesAsync();
            return Ok(await _context.Teacher.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Teacher>>> Put(Teacher request)
        {
            var teachers = await _context.Teacher.ToListAsync();
            var teacher = teachers.Find(c => c.TeacherId == request.TeacherId);
            if (teacher == null)
                return BadRequest("Teacher not found.");

            teacher.FullName = request.FullName;
            teacher.Education = request.Education;
            

            await _context.SaveChangesAsync();

            return Ok(teachers);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Teacher>>> Delete(int id)
        {
            var teachers = await _context.Teacher.ToListAsync();
            var teacher = teachers.Find(c => c.TeacherId == id);
            if (teacher == null)
                return BadRequest("Teacher not found.");

            teachers.Remove(teacher);

            await _context.SaveChangesAsync();

            return Ok(teacher);
        }


    }
}
