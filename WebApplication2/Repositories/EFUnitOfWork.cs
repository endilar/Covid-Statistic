using WebApplication2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

namespace WebApplication2.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private bool disposed = false;

        private ApplicationContext db;
        private IDbContextTransaction transaction;

        private VaccineRepository vaccineRepository;

        public EFUnitOfWork(ApplicationContext context)
        {
            db = context;
        }

        public IVaccineRepository Vaccines
        {
            get
            {
                if (vaccineRepository == null)
                    vaccineRepository = new VaccineRepository(db);
                return vaccineRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }

        public void BeginTransaction()
        {
            transaction = db.Database.BeginTransaction();
        }

        public void Commit()
        {
            transaction.Commit();
        }

        public void Rollback()
        {
            transaction.Rollback();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}