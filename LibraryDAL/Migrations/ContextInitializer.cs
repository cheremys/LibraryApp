using LibraryDAL.EF;
using LibraryDAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL.Migrations
{
    internal sealed class ContextInitializer : DropCreateDatabaseIfModelChanges<LibraryContext>
    {
        protected override void Seed(LibraryContext dataBase)
        {
            var nimona = new Book { Title = "Nimona", Author = "Noelle Stevenson", PublicationDate = new DateTime(2015,5,12), Description = "Lord Blackheart, a villain with a vendetta, and his sidekick, Nimona, an impulsive young shapeshifter, must prove to the kingdom that Sir Goldenloin and the Institution of Law Enforcement and Heroics aren't the heroes everyone thinks they are." };
            var watchmen = new Book { Title = "Watchmen", Author = "Alan Moore", PublicationDate = new DateTime(2008, 9, 20), Description= "Everything you've heard about this graphic novel, first published as a 12-issue series in 1986 and 1987, is true. It broke the ground; it changed the game. There is a reason people still press it into the hands of those who've never read a comic before."};

            var escape = new Book { Title = "Escape from Baghdad!", Author = "Saad Z. Hossain", PublicationDate = new DateTime(2015, 3, 17), Description = "Welcome to Baghdad during the US invasion. A desperate American military has created a power vacuum that needs to be filled. Religious fanatics, mercenaries, occultists, and soldiers are all vying for power. So how do regular folks try to get by?" };
            var darkestPart = new Book { Title = "The Darkest Part of the Forest", Author = "Holly Black", PublicationDate = new DateTime(2016, 1, 19), Description = "In the woods is a glass coffin. It rests on the ground, and in it sleeps a boy with horns on his head and ears as pointed as knives...." };

            var sheWasGone = new Book { Title = "Then She Was Gone: A Novel", Author = "Lisa Jewell", PublicationDate = new DateTime(2018, 11, 18), Description = "Ellie Mack was the perfect daughter. She was fifteen, the youngest of three. Beloved by her parents, friends, and teachers, and half of a teenaged golden couple. Ellie was days away from an idyllic post-exams summer vacation, with her whole life ahead of her." };
            var before = new Book { Title = "Before We Were Yours: A Novel", Author = "Alan Moore", PublicationDate = new DateTime(2019, 5, 21), Description = "Twelve-year-old Rill Foss and her four younger siblings live a magical life aboard their family’s Mississippi River shantyboat. " };


            dataBase.Books.AddRange(new List<Book> { nimona, watchmen, escape, darkestPart, sheWasGone, before });
            dataBase.SaveChanges();

            var comicBook = new Category
            {
                Name = "Comic book",
                Books = new List<Book> { nimona, watchmen }
            };

            var actionAndAdventure = new Category
            {
                Name = "Action and adventure",
                Books = new List<Book> { escape, darkestPart }
            };

            var drama = new Category
            {
                Name = "Drama",
                Books = new List<Book> { sheWasGone, before }
            };

            dataBase.Categories.AddRange(new List<Category> { comicBook, actionAndAdventure, drama });
            dataBase.SaveChanges();
        }
    }
}
