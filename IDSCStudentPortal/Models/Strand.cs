namespace IDSCStudentPortal.Models
{
    public class Strand
    {
        public int Id { get; set; }
        public int YearLevel { get; set; }
        public string Name { get; set; }



        public ICollection<PreRegistration> PreRegistrations { get; set; }
    }
}
