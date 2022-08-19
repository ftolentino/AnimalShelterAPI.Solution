using Microsoft.EntityFrameworkCore;
using System;



namespace AnimalShelter.Models
{
    public class AnimalShelterContext : DbContext
    {
        public AnimalShelterContext(DbContextOptions<AnimalShelterContext> options)
            : base(options)
        {
        }

        

        public DbSet<Animal> Animals { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
        builder.Entity<Animal>()
            .HasData(
                new Animal { AnimalId = 1, Name = "Dara", Species = "dog!!", Breed = "German Shepherd",PostDate = "16 August 2022" },
                new Animal { AnimalId = 2, Name = "Blaze", Species = "dog", Breed = "Klee Kai", PostDate = "16 August 2022" },
                new Animal { AnimalId = 3, Name = "Buddy", Species = "dog", Breed = "Klee Kai", PostDate = "16 August 2022" },
                new Animal { AnimalId = 4, Name = "Dodger", Species = "cat", Breed = "Siamese", PostDate = "16 August 2022" }
            );
        }
    }
}

