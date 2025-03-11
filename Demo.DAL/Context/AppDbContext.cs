using Demo.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public AppDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-FIK5SPH\\SQLEXPRESS;database=MVCDatabase;User Id=Shahd_Mostafa;Password=ColdYagami1258;TrustServerCertificate = True");
        }

        public DbSet<Department> departments { get; set; }
    }
}
