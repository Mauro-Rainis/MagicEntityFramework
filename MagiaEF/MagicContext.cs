using MagiaEF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace MagiaEF
{
    class MagicContext : DbContext
    {
        private static string _connectionString;
        public MagicContext() : base()
        {

        }
        public DbSet<Sport> Sport { get; set; }
        public DbSet<Studente> Studenti { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (string.IsNullOrEmpty(_connectionString))
            {
                LoadConnectionString();
            }

            optionsBuilder.UseSqlServer(_connectionString);
        }

        private static void LoadConnectionString()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                ;

            var configuration = builder.Build();
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
    }
}

    