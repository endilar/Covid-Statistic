using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Entities.Requests
{
    public class CreateVaccineRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime Birthday { get; set; }
        public string City { get; set; }
        public DateTime DayOfVaccination { get; set; }
        public string VaccineName { get; set; }
        public int VaccineDose { get; set; }
    }
}
