using Microsoft.EntityFrameworkCore;

namespace VeduboxAPI.Data
{

    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        public DbSet<Course> Course => Set<Course>();
        public DbSet<Teacher> Teacher => Set<Teacher>();
        public DbSet<Student> Student => Set<Student>();
        public DbSet<Enrollment> Enrollment => Set<Enrollment>();
        public DbSet<User> User => Set<User>();
        
    }
}
