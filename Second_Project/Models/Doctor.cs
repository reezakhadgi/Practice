using System.ComponentModel.DataAnnotations;

namespace Second_Project.Models
{
    public class Doctor
    {
        [Key]
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Specification { get; set; }
            public string Qualification { get; set; }
            public int NMC_Number { get; set; }
        public ICollection<Patient> Patients { get; set;}
    }
}
