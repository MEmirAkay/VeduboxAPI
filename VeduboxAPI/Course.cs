namespace VeduboxAPI
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string TeacherName { get; set; } = string.Empty;
        public int TeacherId { get; set; }
        public string Date { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    
    }
}
