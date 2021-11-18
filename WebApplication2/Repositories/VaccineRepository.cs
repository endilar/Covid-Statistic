using WebApplication2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Repositories
{
    public class VaccineRepository : IVaccineRepository
    {
        readonly ApplicationContext db;

        public VaccineRepository(ApplicationContext context)
        {
            this.db = context;
        }

        public void Create(Vaccine vaccine)
        {
            db.Vaccines.Add(vaccine);
        }

        public IQueryable<Vaccine> GetAll()
        {
            return db.Vaccines.AsQueryable();
        }

        public Vaccine GetByFunc(Func<Vaccine, Boolean> predicate)
        {
            return db.Vaccines.Where(predicate).FirstOrDefault();
        }

        public void Remove(Vaccine obj)
        {
            db.Vaccines.Remove(obj);
        }

        public void Update(Vaccine vaccine)
        {
            db.Vaccines.Update(vaccine);
        }
    }
}