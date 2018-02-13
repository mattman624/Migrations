using Microsoft.EntityFrameworkCore;
using Migrations.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Migrations.Data
{
    public class PersonContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        private string _dbPath;
        public PersonContext() :base()
        {

        }

        public PersonContext(string dbPath) : base()
        {
            _dbPath = dbPath;
        }
                
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_dbPath}");
        }
    }
}
