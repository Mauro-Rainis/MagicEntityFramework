﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using WebPageEntityFrameworkMvc.Models;

namespace WebPageEntityFrameworkMvc.Data
{
    public class MagicContext : DbContext
    {
        private static string _connectionString;
        public MagicContext(DbContextOptions<MagicContext> options) : base(options)
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

