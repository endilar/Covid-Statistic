using WebApplication2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Repositories;
using WebApplication2.Entities.Requests;

namespace WebApplication2.Services
{
    public class VaccineService : IVaccineService
    {
        private IUnitOfWork Database { get; set; }

        public VaccineService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public Vaccine GetByFunc(Func<Vaccine, Boolean> predicate)
        {
            try
            {
                return Database.Vaccines.GetByFunc(predicate);
            }
            catch
            {
                throw;
            }
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public void Create(Vaccine vaccine)
        {
            try
            {
                Database.BeginTransaction();
                Database.Vaccines.Create(vaccine);
                Database.Save();
                Database.Commit();
            }
            catch
            {
                Database.Rollback();
                throw;
            }
        }

        public void Update(Vaccine vaccine)
        {
            try
            {
                Database.BeginTransaction();
                Database.Vaccines.Update(vaccine);
                Database.Save();
                Database.Commit();
            }
            catch
            {
                Database.Rollback();
                throw;
            }
        }

        public List<Vaccine> GetAll(PaginationRequest paginationRequest)
        {
            try
            {
                var x = Database.Vaccines.GetAll();

                List<Vaccine> users = Database.Vaccines.GetAll()
                    .Where(u => u.FirstName.Contains(paginationRequest.Query))
                    .Skip(paginationRequest.Offset)
                    .Take(paginationRequest.Limit)
                    .ToList();

                return users;
            }
            catch
            {
                throw;
            }
        }

        public void Create(CreateVaccineRequest createVaccineRequest)
        {
            Vaccine vaccine = new Vaccine(createVaccineRequest);
            Create(vaccine);
        }

        public void Update(int id, UpdateVaccineRequest updateVaccineRequest)
        {
            Vaccine vaccine = GetByFunc(u => u.Id == id);


            vaccine.FirstName = updateVaccineRequest.FirstName;
            vaccine.LastName = updateVaccineRequest.LastName;
            vaccine.Birthday = updateVaccineRequest.Birthday;
            vaccine.City = updateVaccineRequest.City;
            vaccine.DayOfVaccination = updateVaccineRequest.DayOfVaccination;
            vaccine.VaccineName = updateVaccineRequest.VaccineName;
            vaccine.VaccineDose = updateVaccineRequest.VaccineDose;

            Update(vaccine);
        }

        public void Remove(int id)
        {
            Database.BeginTransaction();
            try
            {
                Vaccine vaccine = GetByFunc(u => u.Id == id);

                if (vaccine != null)
                {
                    Database.Vaccines.Remove(vaccine);
                    Database.Save();
                }
                    
                Database.Commit();
            }
            catch
            {
                Database.Rollback();
                throw;
            }
            
        }

        public void UploadFile(UploadFileRequest uploadFileRequest)
        {
            List<Vaccine> vaccines = new List<Vaccine>();

            System.IO.StreamReader file = new System.IO.StreamReader(uploadFileRequest.File.OpenReadStream());
            int counter = 0;
            string line;
            while ((line = file.ReadLine()) != null)
            {
                if (counter == 0)
                {
                    counter++;
                    continue;
                }

                string[] fields = line.Split(",", 7);

                Vaccine vaccine = new Vaccine
                {
                    FirstName = fields[0],
                    LastName = fields[1],
                    Birthday = DateTime.Parse(fields[2]),
                    City = fields[3],
                    DayOfVaccination = DateTime.Parse(fields[4]),
                    VaccineName = fields[5],
                    VaccineDose = Int32.Parse(fields[6])
                };

                Vaccine existVaccine = GetByFunc(u => u.FirstName == vaccine.FirstName && u.LastName == vaccine.LastName);

                if (existVaccine == null)
                {
                    Create(vaccine);
                }

                counter++;
            }
            file.Close();
        }
    }
}