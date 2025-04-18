using IDSCStudentPortal.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IDSCStudentPortal.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<DepProgram> DepPrograms { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<InstructorDetail> InstructorDetails { get; set; }
        public DbSet<PreRegistration> PreRegistrations { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Strand> Strands { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentDetail> StudentDetails { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Dean> Deans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Course
            modelBuilder.Entity<Course>()
                .HasOne(c => c.Instructor)
                .WithMany(i => i.Course)
                .HasForeignKey(c => c.InstructorId)
                .OnDelete(DeleteBehavior.ClientNoAction);

            modelBuilder.Entity<Course>()
                .HasOne(c => c.Student)
                .WithMany()
                .HasForeignKey(c => c.StudentId)
                .OnDelete(DeleteBehavior.ClientNoAction);


            modelBuilder.Entity<DepProgram>()
                .HasMany(p => p.Student)
                .WithOne(s => s.DepProgram)
                .HasForeignKey(s => s.DepProgramId)
                .OnDelete(DeleteBehavior.ClientNoAction);

            modelBuilder.Entity<DepProgram>()
                .HasMany(p => p.PreRegistration)
                .WithOne(s => s.DepProgram)
                .HasForeignKey(pr => pr.DepProgramId)
                .OnDelete(DeleteBehavior.ClientNoAction);


            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Course)
                .WithMany()
                .HasForeignKey(e => e.CourseId)
                .OnDelete(DeleteBehavior.ClientNoAction);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.PreRegistration)
                .WithMany(pr => pr.Enrollment)
                .HasForeignKey(e => e.PreRegistrationId)
                .OnDelete(DeleteBehavior.ClientNoAction);

            // Grades
            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Student)
                .WithMany(s => s.Grades)
                .HasForeignKey(g => g.StudentId)
                .OnDelete(DeleteBehavior.ClientNoAction);

            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Course)
                .WithMany()
                .HasForeignKey(g => g.CourseId)
                .OnDelete(DeleteBehavior.ClientNoAction);

            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Strand)
                .WithMany()
                .HasForeignKey(g => g.StrandId)
                .OnDelete(DeleteBehavior.ClientNoAction);

            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Program)
                .WithMany()
                .HasForeignKey(g => g.DepProgramId)
                .OnDelete(DeleteBehavior.ClientNoAction);

            // Instructor
            modelBuilder.Entity<Instructor>()
                .HasOne(i => i.InstructorDetail)
                .WithMany(d => d.Instructor)
                .HasForeignKey(i => i.InstructorDetailId)
                .OnDelete(DeleteBehavior.ClientNoAction);

            modelBuilder.Entity<Instructor>()
                .HasOne(i => i.Student)
                .WithMany()
                .HasForeignKey(i => i.StudentId)
                .OnDelete(DeleteBehavior.ClientNoAction);

            // InstructorDetail
            modelBuilder.Entity<InstructorDetail>()
                .HasOne(d => d.Program)
                .WithMany()
                .HasForeignKey(d => d.ProgramId)
                .OnDelete(DeleteBehavior.ClientNoAction);

            modelBuilder.Entity<InstructorDetail>()
                .HasOne(d => d.Strand)
                .WithMany()
                .HasForeignKey(d => d.StrandId)
                .OnDelete(DeleteBehavior.ClientNoAction);

            modelBuilder.Entity<InstructorDetail>()
                .HasOne(d => d.Schedule)
                .WithMany(s => s.InstructorDetails)
                .HasForeignKey(d => d.ScheduleId)
                .OnDelete(DeleteBehavior.ClientNoAction);

            modelBuilder.Entity<InstructorDetail>()
                .HasOne(d => d.PreRegistration)
                .WithMany()
                .HasForeignKey(d => d.PreRegistrationId)
                .OnDelete(DeleteBehavior.ClientNoAction);

            // Strand
            modelBuilder.Entity<Strand>()
                .HasMany(s => s.PreRegistrations)
                .WithOne(pr => pr.Strand)
                .HasForeignKey(pr => pr.StrandId)
                .OnDelete(DeleteBehavior.ClientNoAction);

            // Student
            modelBuilder.Entity<Student>()
                .HasOne(s => s.PreRegistration)
                .WithMany(p => p.Student)
                .HasForeignKey(s => s.PreRegistrationId)
                .OnDelete(DeleteBehavior.ClientNoAction);

            // StudentDetail
            modelBuilder.Entity<StudentDetail>()
                .HasOne(sd => sd.Enrollment)
                .WithMany()
                .HasForeignKey(sd => sd.EnrollmentId)
                .OnDelete(DeleteBehavior.ClientNoAction);

            modelBuilder.Entity<StudentDetail>()
                .HasOne(sd => sd.Program)
                .WithMany()
                .HasForeignKey(sd => sd.ProgramId)
                .OnDelete(DeleteBehavior.ClientNoAction);

            modelBuilder.Entity<StudentDetail>()
                .HasOne(sd => sd.Course)
                .WithMany()
                .HasForeignKey(sd => sd.CourseId)
                .OnDelete(DeleteBehavior.ClientNoAction);

            modelBuilder.Entity<StudentDetail>()
                .HasOne(sd => sd.Strand)
                .WithMany()
                .HasForeignKey(sd => sd.StrandId)
                .OnDelete(DeleteBehavior.ClientNoAction);

            modelBuilder.Entity<StudentDetail>()
                .HasOne(sd => sd.Schedule)
                .WithMany()
                .HasForeignKey(sd => sd.ScheduleId)
                .OnDelete(DeleteBehavior.ClientNoAction);

            base.OnModelCreating(modelBuilder);
        }
    }
}

    

    

