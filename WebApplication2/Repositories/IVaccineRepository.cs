using WebApplication2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication2.Repositories
{
    public interface IVaccineRepository
    {
        IQueryable<Vaccine> GetAll();

        void Create(Vaccine obj);

        void Update(Vaccine obj);

        Vaccine GetByFunc(Func<Vaccine, Boolean> predicate);
        
        void Remove(Vaccine obj);
    }
}
