using Microsoft.EntityFrameworkCore;
using RegistroDeUsuarios.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroDeUsuarios.DAL
{
    public class Contexto :DbContext
    {
        public DbSet<Roles> rol { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=DATA\TeacherControl.db");
        }
    }
}
