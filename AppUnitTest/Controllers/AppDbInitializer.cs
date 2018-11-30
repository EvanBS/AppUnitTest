using AppUnitTest.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AppUnitTest.Controllers
{
    public class AppDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext db)
        {
            List<Computer> computers = new List<Computer>()
            {
                new Computer() { Id = 1, Name = "MacMini" },
                new Computer() { Id = 1, Name = "MiBook" },
                new Computer() { Id = 1, Name = "Dell" },
            };

            db.Computers.AddRange(computers);
            db.SaveChanges();
        }
    }
}