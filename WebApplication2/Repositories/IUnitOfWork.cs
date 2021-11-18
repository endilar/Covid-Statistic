using WebApplication2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication2.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IVaccineRepository Vaccines { get; }

        void Save();

        Task SaveAsync();

        void BeginTransaction();

        void Commit();

        void Rollback();
    }
}
