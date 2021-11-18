using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Entities.Requests;

namespace WebApplication2.Models
{
    public class Vaccine
    {
        public Vaccine() { }
        public Vaccine(CreateVaccineRequest createVaccineRequest) 
        {
            FirstName = createVaccineRequest.FirstName;
            LastName = createVaccineRequest.LastName;
            Birthday = createVaccineRequest.Birthday;
            City = createVaccineRequest.City;
            DayOfVaccination = createVaccineRequest.DayOfVaccination;
            VaccineName = createVaccineRequest.VaccineName;
            VaccineDose = createVaccineRequest.VaccineDose;
        }

        public int Id { get; set; }
        public string  FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime Birthday { get; set; }
        public string City { get; set; }
        public DateTime DayOfVaccination { get; set; }
        public string VaccineName { get; set; }
        public int VaccineDose { get; set; }
    }
}