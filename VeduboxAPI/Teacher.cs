using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeduboxAPI
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Education { get; set; } = string.Empty;
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
    }


}
