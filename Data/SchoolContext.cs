using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AplicatieManagementStudenti.Models;

namespace AplicatieManagementStudenti.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext (DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Studenti { get; set; }
        public DbSet<Inscriere> Inscrieri { get; set; }
        public DbSet<Curs> Cursuri { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Curs>().ToTable("Curs");
            modelBuilder.Entity<Inscriere>().ToTable("Inscriere");
            modelBuilder.Entity<Student>().ToTable("Student");
        }
    }
}
