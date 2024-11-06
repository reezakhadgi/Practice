using Microsoft.AspNetCore.Mvc;

namespace Second_Project.Viewmodels
{
    public class DoctorViewModel 
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Specification { get; set; }
        public string Qualification { get; set; }
        public int NMC_Number { get; set; }
    }
}
