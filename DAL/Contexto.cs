using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SegundoParcial.DAL
{
    public class Contexto : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source: BaseDatos\Parcial2.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          //  modelBuilder.Entity<Productos>().HasData(new Productos { ProductoId = 1, Descripcion = "Chocolate", Precio = 100 });

            //modelBuilder.Entity<Productos>().HasData(new Productos { ProductoId = 2, Descripcion = "cafe", Precio = 100 });

            //modelBuilder.Entity<Productos>().HasData(new Productos { ProductoId = 3, Descripcion = "arroz", Precio = 100 });


        }
    }
}
