namespace IDSCStudentPortal.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ProfilePictureUrl { get; set; }

        public int PreRegistrationId { get; set; }
        public PreRegistration PreRegistration { get; set; }

        public int DepProgramId { get; set; }
        public DepProgram DepProgram { get; set; }

        public ICollection<StudentDetail>? StudentDetail { get; set; }
        public ICollection<Grade>? Grades { get; set; }
    }
}
