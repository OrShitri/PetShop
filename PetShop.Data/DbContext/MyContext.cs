using Microsoft.EntityFrameworkCore;
using PetShop.Models;

namespace PetShop.Data
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }

        public virtual DbSet<Category>? Categories { get; set; }
        public virtual DbSet<Animal>? Animals { get; set; }
        public virtual DbSet<Comment>? Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new { CategoryId = 1, Name = "Mammal" },
                new { CategoryId = 2, Name = "Reptile" },
                new { CategoryId = 3, Name = "Aquatic" }
            );

            modelBuilder.Entity<Animal>().HasData(
                new { AnimalId = 1, Name = "Dog", Age = 5, PictureName = "dog_pet.jpg", Description = "Dog, is the everyday name of the domestic dog, a subspecies of the common wolf (Canis lupus), from the canidae family, from the series of carnivores.The dog evolved from the wolf,and is the earliest domesticated animal.The average lifespan of the dogs is between 11 and 14 years.", CategoryId = 1 },
                new { AnimalId = 2, Name = "Lion", Age = 18, PictureName = "lion_afri.jpg", Description = "A lion is a species of large predator of the panther genus in the cat family, and is the second largest among the cat-like members of the group, after the Siberian subspecies of the tiger.The lion is common mainly on the continent of Africa,but also in the state of Gujarat in India.", CategoryId = 1 },
                new { AnimalId = 3, Name = "Lizard", Age = 19, PictureName = "lizard_agamidae.jpg", Description = "Lizards are a group of reptiles defined as including all reptiles of the Lepidosauria series, with the exception of cephalopods and snakes. In the past, the group of lizards was considered a subseries, but due to being paraphyletic, it is now considered a group that is not part of taxonomy. There are about 7,570 species of lizards from 36 families, ranging from tiny lizards to the giant Komodo dragon lizards.", CategoryId = 2 },
                new { AnimalId = 4, Name = "Snake", Age = 10, PictureName = "snake_pois.jpg", Description = "Snakes are limbless carnivorous reptiles, with an elongated body covered in scales. There are about 4,060 species of snakes from 30 families. Snakes are a sub-series of the Rattlesnake series, and belong to the Ophidia group.", CategoryId = 2 },
                new { AnimalId = 5, Name = "Dolphin", Age = 20, PictureName = "dolphin_blue.jpg", Description = "Dolphins are a paraphyletic (non-taxonomic) group of marine mammals belonging to the order of whales (Cetacea), and to the suborder of toothed whales. They are divided into two superfamilies: dolphins, in which there is a single family of dolphins - dolphins (but there are also pocans and neophytes, which are not considered dolphins), and river dolphins, in which there are four families.", CategoryId = 3 },
                new { AnimalId = 6, Name = "Swordfish", Age = 15, PictureName = "swordfish.jpg", Description = "The swordfish is a large predator with a round and elongated body, which often migrates, characterized by an elongated and flat upper jaw similar to the sword used by the fish as a weapon. During puberty, the swordfish loses its teeth and scales, but is still a deadly predator thanks to its high speed and long sword. The swordfish is a very large fish: its maximum length is about 455 centimeters and it reaches a weight of 650 kg.", CategoryId = 3 }
            );

            modelBuilder.Entity<Comment>().HasData(
                new { CommentId = 1, AnimalId = 1, Comments = "This is my favorite dog he is so cute and beautiful! =)" },
                new { CommentId = 2, AnimalId = 1, Comments = "He is the king of animals" },
                new { CommentId = 3, AnimalId = 1, Comments = "She always looks old because of the folds" },
                new { CommentId = 4, AnimalId = 2, Comments = "The animal that scares me the most" },
                new { CommentId = 5, AnimalId = 2, Comments = "He is so smart and cute" },
                new { CommentId = 6, AnimalId = 1, Comments = "This sword looks like a very long nose." }
            );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
