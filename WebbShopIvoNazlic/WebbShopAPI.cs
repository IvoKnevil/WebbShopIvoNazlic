using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebbShopIvoNazlic.Database;
using WebbShopIvoNazlic.Models;

namespace WebbShopIvoNazlic
{
    public static class WebbShopAPI
    {


        private static BookDatabase db = new BookDatabase();


        /* public static void AddBook(string title, string author, int amount, int price, Category [] category)
         {

                 var book = db.Books.FirstOrDefault(b => b.Title == title);

                 if (book == null)
                 {
                     book = db.Books.FirstOrDefault(b => b.Author == author);
                 }

                 if (book == null)
                 {
                     book = new Book { Title = title, Author = author, Amount = amount, Price = price, BookCategory = category };
                 }

         }
        */

        public static void ChangePrice()
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

        public static void RemoveBook()
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

        public static void SortByName()
        {
            using (var db = new BookDatabase())
            {
                foreach (var book in db.Books.OrderBy(b => b.Title))
                {
                    Console.WriteLine(book);
                }
            }

        }

        public static int Login(string username, string password)
        {
            var user = db.Users.FirstOrDefault(u => u.Name == username && u.Password == password);
            if (user != null)
            {
                user.LastLogin = DateTime.Now;
                user.SessionTimer = DateTime.Now;
                db.Users.Update(user);
                db.SaveChanges();
                return user.Id;
            }

            return 0;
        }

        public static void Logout(int id)
        {
            var user = db.Users.FirstOrDefault(u => u.Id == id && u.SessionTimer > DateTime.Now.AddMinutes(-15));
            if (user != null)
            {
                user.SessionTimer = DateTime.MinValue;
                db.Users.Update(user);
                db.SaveChanges();
            }

        }

        public static List<Category> GetCategories()
        {
            return db.BookCategories.ToList();
        }

        public static List<Category> GetCategories(string keyword)
        {
            List<Category> listOfCategories = new List<Category>();

            foreach (var category in db.BookCategories.Where(n => n.Name.ToLower().Contains(keyword.ToLower())))
            {
                if (category != null)
                {
                    listOfCategories.Add(category);
                }
            }

            return listOfCategories;
        }

        public static List<Book> GetCategory(int id)
        {
            List<Book> booksOfCategory = new List<Book>();

            foreach (var book in db.Books.Where(bc => bc.BookCategory.Id == id))
            {
                if (book != null)
                {
                    booksOfCategory.Add(book);
                }
            }

            return booksOfCategory;
        }

        public static List<Book> GetAvailableBooks(int id)
        {
            List<Book> availableBooks = new List<Book>();

            foreach (var book in db.Books.Where(b => b.Amount > 0 && b.BookCategory.Id == id))
            {
                if (book != null)
                {
                    availableBooks.Add(book);
                }
            }
            return availableBooks;
        }

        public static Book GetBook(int id)
        {
            var book = (db.Books.FirstOrDefault(b => b.Id == id));

            if (book != null)
            {
                return book;
            }
            return book;

        }

        public static List<Book> GetBooks(string keyword)
        {
            List<Book> matchingBooks = new List<Book>();

            foreach (var book in db.Books.Where(n => n.Title.ToLower().Contains(keyword.ToLower())))
            {
                if (book != null)
                {
                    matchingBooks.Add(book);
                }
            }

            return matchingBooks;
        }
    }
}
