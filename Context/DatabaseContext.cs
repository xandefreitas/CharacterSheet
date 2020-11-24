using System;
using CharacterSheet.Models;
using Microsoft.EntityFrameworkCore;

namespace CharacterSheet
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Personagem> Personagens { get; set; }
        public DbSet<User> Users { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Console.WriteLine("Contexto Criado");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            Console.WriteLine("Modelos Criados");
        }

    }
}