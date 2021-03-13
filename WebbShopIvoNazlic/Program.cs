using System;
using System.Collections.Generic;
using System.Linq;
using WebbShopIvoNazlic.Database;
using WebbShopIvoNazlic.Models;

namespace WebbShopIvoNazlic
{
    class Program
    {
        static void Main(string[] args)
        {


            AddMockData();
            //SortByName();
            //ChangePrice();
            //RemoveBook();

        }



        private static void AddBook(string title, string author, int amount, int price, params Category[] categories)
        {

            using (var db = new BookDatabase())
            {
                var book = db.Books.FirstOrDefault(b => b.Title == title);
                if (book == null)
                {
                    book = db.Books.FirstOrDefault(b => b.Author == author);
                }
                if (book == null)
                {

                    book = new Book { Title = title, Author = author, Amount = amount, Price = price, };

                }


            }

        }







        private static void AddMockData()
        {
            using (var db = new BookDatabase())
            {
                //Add data for users
                if (db.Users.Count() == 0)
                {
                    db.Users.Add(new User { Name = "Administrator", Password = "CodicRulez" });
                    db.Users.Add(new User { Name = "TestCustomer", Password = "Codic2021" });

                }

                //Add data for book categories
                if (db.BookCategories.Count() == 0)
                {
                    db.BookCategories.Add(new Category { Name = "Horror" });
                    db.BookCategories.Add(new Category { Name = "Humor" });
                    db.BookCategories.Add(new Category { Name = "Science Fiction" });
                    db.BookCategories.Add(new Category { Name = "Romance" });
                    db.SaveChanges();
                }

                //Add data for books
                if (db.Books.Count() == 0)
                {
                    db.Books.Add(new Book
                    {
                        Title = "Cabal (Nightbreed)",
                        Author = "Clive Barker",
                        Amount = 3,
                        Price = 250,
                        BookCategory = db.BookCategories.FirstOrDefault(c => c.Name == "Horror") //Code to add BookCategory copied from Discord - Bästkusten code from David Ström
                    }); 

                    db.Books.Add(new Book
                    {
                        Title = "The Shinng",
                        Author = "Stephen King",
                        Amount = 2,
                        Price = 200,
                        BookCategory = db.BookCategories.FirstOrDefault(c => c.Name == "Horror")
                    });

                    db.Books.Add(new Book
                    {
                        Title = "Doctor Sleep",
                        Author = "Stephen King",
                        Amount = 1,
                        Price = 200,
                        BookCategory = db.BookCategories.FirstOrDefault(c => c.Name == "Horror")
                    });

                    db.Books.Add(new Book
                    {
                        Title = "I Robot",
                        Author = "Isaac Asimov",
                        Amount = 4,
                        Price = 150,
                        BookCategory = db.BookCategories.FirstOrDefault(c => c.Name == "Science Fiction")
                    });
                }

                db.SaveChanges();
            }

        }

        private static void ChangePrice()
        {

            using (var db = new BookDatabase())
            {
                var cabal = db.Books.FirstOrDefault(b => b.Title == "Cabal (Nightbreed)");

                if (cabal != null)

                {
                    cabal.Price = 300;
                }

                db.Update(cabal);
                db.SaveChanges();

            }
        }

        private static void RemoveBook()
        {

            using (var db = new BookDatabase())
            {
                var cabal = db.Books.FirstOrDefault(b => b.Title == "Cabal (Nightbreed)");

                if (cabal != null)

                {
                    db.Books.Remove(cabal);
                }

                db.SaveChanges();

            }
        }

        private static void SortByName()
        {
            using (var db = new BookDatabase())
            {
                foreach (var book in db.Books.OrderBy(b => b.Title))
                {
                    Console.WriteLine(book);
                }
            }

        }



    }
}
