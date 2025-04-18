namespace IDSCStudentPortal.Models
{
    public class InstructorDetail
    {
        public int Id { get; set; }
        public int ProgramId { get; set; }
        public DepProgram Program { get; set; }
        public int StrandId { get; set; }
        public Strand Strand { get; set; }
        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; }
        public int PreRegistrationId { get; set; }
        public PreRegistration PreRegistration { get; set; }

        public ICollection<Instructor>? Instructor { get; set; }
    }
}
