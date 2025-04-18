namespace IDSCStudentPortal.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int TotalStudents { get; set; }

        public int InstructorDetailId { get; set; }
        public InstructorDetail InstructorDetail { get; set; }

        public ICollection<Course>? Course { get; set; }
        public ICollection<Admin>? Admin { get; set; }
        public ICollection<Dean>? Dean { get; set; }
        public Student Student { get; set; }
        public int StudentId { get; set; }
    }
}
