using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using VeduboxAPI.Data;


namespace VeduboxAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly DataContext _context;

        public EnrollmentController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Enrollment>>> Get()
        { 
            return Ok(await _context.Enrollment.ToListAsync());
        }
        [HttpPost]
        public async Task<ActionResult<List<Enrollment>>> Post(Enrollment enrollment)
        {
            _context.Enrollment.Add(enrollment);
            await _context.SaveChangesAsync();

            return Ok("Enrollment Success");
        }

        [HttpGet("sortByStudent/{id}")]
        public async Task<ActionResult<List<Course>>> GetByStudentId(int id)
        {
            var enrolls = await _context.Enrollment.ToListAsync();
            var enrollmentlist = enrolls.Where(c => c.StudentId == id);

            if (enrollmentlist == null)
                return BadRequest("Enrollment not found.");

            return Ok(enrollmentlist);
        }


    }
}
