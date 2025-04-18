namespace IDSCStudentPortal.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public ICollection<Enrollment>? Enrollment { get; set; }
        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int EnrollmentId { get; set; }
    }
}
