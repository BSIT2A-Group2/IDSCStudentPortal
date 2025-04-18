namespace IDSCStudentPortal.Models
{
    public class Admin
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int TotalStudents { get; set; }
        public int TotalInstructors { get; set; }
        public int TotalDeans { get; set; }
        public ICollection<Student> Student { get; set; }
        public ICollection<Instructor> Instructor { get; set; }
        public ICollection<Dean> Dean { get; set; }
        public int StudentId { get; set; }
        public int DeanId { get; set; }
        public int InstructorId { get; set; }
    }
}
