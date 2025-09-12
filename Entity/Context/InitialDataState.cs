using Entity.Models;
using Entity.Models.ModelosParametros;
using Microsoft.EntityFrameworkCore;
using System;

namespace Entity.Context.Seed
{
    internal static class InitialDataState
    {
        public static void Seed(ModelBuilder modelBuilder, DateTime currentDate)

        {

            
            var StateRising = new State()
            {
                Id = 1,
                Name = "Naciente",
                State = true,
                Code = "01",
                CreatedAt = currentDate,
                DeletedAt = null!
            };

            var StateGrowing = new State()
            {
                Id = 2,
                Name = "Creciente",
                State = true,
                Code = "02",
                CreatedAt = currentDate,
                DeletedAt = null!
            };

            var StateInspirational = new State()
            {
                Id = 3,
                Name = "Inspiradora",
                State = true,
                Code = "03",
                CreatedAt = currentDate,
                DeletedAt = null!
            };

            // Registrar los datos en EF Core
            modelBuilder.Entity<State>().HasData(
                StateRising, StateGrowing, StateInspirational
            );
        }
    }
}

