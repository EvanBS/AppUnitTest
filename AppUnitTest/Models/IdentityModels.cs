using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AppUnitTest.Models
{
    // В профиль пользователя можно добавить дополнительные данные, если указать больше свойств для класса ApplicationUser. Подробности см. на странице https://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Обратите внимание, что authenticationType должен совпадать с типом, определенным в CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Здесь добавьте утверждения пользователя
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<Computer> Computers { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }


    public interface IRepository : IDisposable
    {
        List<Computer> GetComputerList();
        Computer GetComputer(int id);
        void Create(Computer item);
        void Update(Computer item);
        void Delete(int id);
        Task<IEnumerable<Computer>> AllComputersAsync();
        void Save();
    }


    public class ComputerRepository : IRepository
    {
        private ApplicationDbContext db;
        public ComputerRepository()
        {
            this.db = new ApplicationDbContext();
        }
        public List<Computer> GetComputerList()
        {
            return db.Computers.ToList();
        }
        public Computer GetComputer(int id)
        {
            return db.Computers.Find(id);
        }

        public void Create(Computer c)
        {
            db.Computers.Add(c);
        }

        public void Update(Computer c)
        {
            db.Entry(c).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Computer c = db.Computers.Find(id);
            if (c != null)
                db.Computers.Remove(c);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<IEnumerable<Computer>> AllComputersAsync()
        {
            return await db.Computers.ToListAsync();
        }
    }
}