namespace IDSCStudentPortal.Models
{
    public class DepProgram
    {
        public int Id { get; set; }
        public int YearLevel { get; set; }
        public string Name { get; set; }

        public ICollection<Student>? Student { get; set; }
        public ICollection<PreRegistration>? PreRegistration { get; set; }
    }
}
