using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Entities.Requests
{
    public class UpdateVaccineRequest
    {
        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(30)]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
        [Required]
        [StringLength(30)]
        public string City { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DayOfVaccination { get; set; }
        [Required]
        [StringLength(30)]
        public string VaccineName { get; set; }
        [Required]
        [Range(1,30)]
        public int VaccineDose { get; set; }
    }
}
