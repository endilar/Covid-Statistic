using WebApplication2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.Entities.Requests;

namespace WebApplication2.Services
{
    public interface IVaccineService
    {
        public List<Vaccine> GetAll(PaginationRequest paginationRequest);

        void Create(CreateVaccineRequest createVaccineRequest);
        void Create(Vaccine obj);

        void Update(int id, UpdateVaccineRequest updateVaccineRequest);
        void Update(Vaccine obj);

        Vaccine GetByFunc(Func<Vaccine, Boolean> predicate);

        void Remove(int id);
        void UploadFile(UploadFileRequest uploadFileRequest);

        void Dispose();
    }
}
