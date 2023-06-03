using System.ComponentModel.DataAnnotations.Schema;

namespace VeduboxAPI
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Education { get; set; } = string.Empty;
        public int Fees { get; set; } = 0;

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        ICollection<Course> Courses { get; set; }

    }
}
